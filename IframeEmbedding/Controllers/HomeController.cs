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
            var nonce = Guid.NewGuid().ToString(); // random string
            var userInfo = EmbedProperties.UserEmail; // email address of the user
            bool canSaveView = true; // enable or disable permission to create, open, update, delete view 
            bool hasViews = true; // enable or disable the permission to check the views of the dashboard
            bool hasExport = true; // enable or disable the permission to export the dashboards and widgets
            bool hasDashboardComments = true; // enable or disable the permission to comment related actions to dashboards
            bool hasWidgetComments = true; // enable or disable the permission to comment related actions to widgets
            bool isMarkFavorite = true; // enable to disable the permission to make the dashboard favorite
            double timeStamp = DateTimeToUnixTimeStamp(DateTime.UtcNow); // current time as UNIX time stamp
            var expirationTime = "100"; // alive time of the token

            string embedMessage = "embed_nonce=" + nonce + "&embed_user_email=" + userInfo + "&embed_dashboard_views_edit=" + canSaveView + "&hide_header=" + false + "&embed_dashboard_views=" + hasViews + "&embed_dashboard_export=" + hasExport + "&embed_dashboard_comments=" + hasDashboardComments + "&embed_widget_comments=" + hasWidgetComments + "&embed_dashboard_favorite=" + isMarkFavorite + "&embed_timestamp=" + timeStamp + "&embed_expirationtime=" + expirationTime;

            string signature = SignURL(embedMessage, EmbedProperties.EmbedSecret);
            string embedSignature = embedMessage + "&embed_signature=" + signature;

            ViewBag.EmbedSignature = embedSignature;

            return View();
        }

        static string SignURL(string embedMessage, string secretcode)
        {
            var encoding = new UTF8Encoding();
            var keyBytes = encoding.GetBytes(secretcode);
            var messageBytes = encoding.GetBytes(embedMessage);
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