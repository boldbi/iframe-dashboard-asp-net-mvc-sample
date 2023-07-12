using IframeEmbedding.Models;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Web.Mvc;

namespace IframeEmbedding.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            // Mandatory Parameters to embed the dashboard with token based authentication.
            var nonce = Guid.NewGuid().ToString(); // To generate random GUID string
            var userEmail = EmbedProperties.UserEmail; // User email id
            double timeStamp = DateTimeToUnixTimeStamp(DateTime.UtcNow); // current time as UNIX time stamp
            //double timeStamp = Math.Round((DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds); // Current time as UNIX time stamp

            // Optional dashboard embed parameter
            bool canSaveView = true; // To show or hide the Save and SaveAs icon in the filter overview. 
            bool hasViews = true; // To show or hide the views icon from the toolbar.
            bool hasExport = true; // To show or hide the export icon from the toolbar.
            bool hasDashboardComments = true; // To show or hide the dashboard comments icon from the toolbar.
            bool hasWidgetComments = true; // To show or hide the widget comments icon from the toolbar.
            bool isMarkFavorite = true; // To show or hide the dashboard favorite icon from the toolbar.
            var expirationTime = "518400"; // Alive time of the token(Expiration time is 518400s)

            // Variable declaration to form the signature for the embed URL 
            string embedParameters = "embed_nonce=" + nonce + "&embed_user_email=" + userEmail + "&embed_dashboard_views_edit=" + canSaveView + "&hide_header=" + false + "&embed_dashboard_views=" + hasViews + "&embed_dashboard_export=" + hasExport + "&embed_dashboard_comments=" + hasDashboardComments + "&embed_widget_comments=" + hasWidgetComments + "&embed_dashboard_favorite=" + isMarkFavorite + "&embed_timestamp=" + timeStamp + "&embed_expirationtime=" + expirationTime;

            string signature = SignURL(embedParameters, EmbedProperties.EmbedSecret);
            string embedSignature = embedParameters + "&embed_signature=" + signature;
            ViewBag.EmbedSignature = embedSignature;

            return View();
        }

        // This method generates the hashed signature using the HMACSHA256 algorithm, which should be appended to the embedParameters with a query parameter named ‘embed_signature’.
        static string SignURL(string embedParameters, string embedSecretKey)
        {
            var encoding = new UTF8Encoding();
            var keyBytes = encoding.GetBytes(embedSecretKey);
            var messageBytes = encoding.GetBytes(embedParameters);
            using (var hmacsha1 = new HMACSHA256(keyBytes))
            {
                var hashMessage = hmacsha1.ComputeHash(messageBytes);
                return Convert.ToBase64String(hashMessage);
            }
        }

        static double DateTimeToUnixTimeStamp(DateTime dateTime)
        {
            DateTime unixStart = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            long unixTimeStampInTicks = (dateTime.ToUniversalTime() - unixStart).Ticks;
            return unixTimeStampInTicks / TimeSpan.TicksPerSecond;
        }
    }
}
