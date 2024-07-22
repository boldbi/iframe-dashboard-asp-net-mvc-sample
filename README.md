# Dashboard Iframe Embedding with ASP.NET MVC

This project was created using ASP.NET MVC 4.8. This application aims to demonstrate how to embed the Bold BI dashboard by providing the dashboard URL.

## Dashboard view

![Dashboard View](https://github.com/boldbi/iframe-dashboard-asp-net-mvc-sample/assets/129487075/df676da3-280d-4006-9914-8d140d279e6c)

## Prerequisites

* [Visual Studio 2022](https://visualstudio.microsoft.com/downloads/)
* [.NET Framework 4.8](https://dotnet.microsoft.com/en-us/download/dotnet-framework)

### Supported browsers
  
* Google Chrome, Microsoft Edge, Mozilla Firefox.

## Configuration

To set the following properties in the `EmbedProperties.cs` file, follow these instructions:

![EmbedProperties.cs](https://github.com/boldbi/iframe-dashboard-asp-net-mvc-sample/assets/129487075/27284c21-401f-43da-8ae7-d51d998e55ec)

| **Parameter**     | **Description**                                                                                                    |
|-------------------|------------------------------------------------------------------------------------------------------------------------|
| **UserEmail**     | UserEmail of the Admin in your Bold BI, which will be used to get the dashboard.                                                                                   |
| **EmbedSecret**   | Get your EmbedSecret key from the embed tab by enabling `Enable embed authentication` in the [Administration page](https://help.boldbi.com/embedded-bi/site-administration/embed-settings/). |
| **DashboardUrl**  | Get the [dashboard URL](https://help.boldbi.com/working-with-dashboards/share-dashboards/get-dashboard-link/#get-link) of the dashboard in your Bold BI.           |

## Developer IDE

* [Visual Studio 2022](https://visualstudio.microsoft.com/downloads/)

### Run a Sample Using Visual Studio 2022

* Open the solution file `IframeEmbedding.sln` in **Visual Studio**.

* Run your `ASP.NET MVC` sample in Visual Studio.

    ![Dashboard View](https://github.com/boldbi/iframe-dashboard-asp-net-mvc-sample/assets/129487075/df676da3-280d-4006-9914-8d140d279e6c)

> **NOTE:** If you are facing an error related to `bin\roslyn\csc.ex`, it indicates that performing a `clean build` and `rebuild` is necessary.

Please refer to the [help documentation](https://help.boldbi.com/embedding-options/iframe-embedding/sample/dashboard-embedding/asp.net-mvc/#how-to-run-the-sample) to know how to run the sample.

## Important notes

It is recommended not to store passwords and sensitive information in configuration files for security reasons in a real-world application. Instead, it would be best if you considered using a secure application, such as Key Vault, to safeguard your credentials.

## Online demos

Look at the Bold BI Embedding sample to live demo [here](https://samples.boldbi.com/embed).

## Documentation

A complete Bold BI Embedding documentation can be found on [Bold BI Embedding Help](https://help.boldbi.com/embedding-options/iframe-embedding/).
