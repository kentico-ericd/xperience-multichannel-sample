# Xperience by Kentico multi-channel sample

This repository is a sample Xperience by Kentico 30.4.0 application which is capable of hosting two website channels according to [our recommendations](https://docs.kentico.com/developers-and-admins/configuration/website-channel-management/manage-multiple-websites).

## Solution structure

Our recommendation for multi-channel instances is to create an RCL for each website and an RCL for components used by both websites. As such, the `MultiSiteSolution.sln` contains the following projects:

![Solution preview](/img/solution.png)

The projects reference each other as follows:

 - Common
   - (No references)
 - MainApp
   - Common.csproj
   - SiteAWebsite.csproj
   - SiteBWebsite.csproj
 - SiteAWebsite
   - Common.csproj
 - SiteBWebsite
   - Common.csproj

## Website configuration

To host this sample application on IIS, first publish the `MainApp.csproj` project:

```powershell
dotnet publish MainApp.csproj -o publish
```

In IIS, create a single website which will host both channels. Add bindings to the site for your two website channels. Below, localhost:1001 is for SiteA and localhost:1002 is for SiteB:

![IIS bindings](/img/bindings.png)

Access the Xperience by Kentico administration using either bound domain. In the __Channel management__ application, add your channels with the following code names and domains:

![Channels](/img/channels.png)

In the __Content types__ application, create the "common.home" content type, assign it to each channel, assign it the "/" scope, and create the Home page for each channel:

![Home page](/img/home.png)

## Notable features

### Automatic routing

You can see in the [`Program.cs`](/Program.cs) that it isn't necessary to implement complex routing when hosting two website channels on the same application. This is thanks to Content-tree based routing and the `RegisterWebPageRoute` attribute, which contains the `WebsiteChannelNames` property. See [SiteAHomeController](/SiteAWebsite/Controllers/SiteAHomeController.cs) and [SiteBHomeController](/SiteBWebsite/Controllers/SiteBHomeController.cs). The proper Controller is selected automatically based on the request's domain.

### Common and site-specific widgets

The `SiteAWebsite` project contains the code for a widget meant only for that website. However, because `MainApp` references both website RCLs, SiteB will still "see" the widget and use it in the page builder. To restrict widget usage, you must set the [allowed widgets](https://docs.kentico.com/developers-and-admins/development/reference-tag-helpers#editable-area) for your zones:

__SiteA Home page__
```cshtml
<editable-area area-identifier="top"
    area-options-allowed-widgets="new[] { CommonWidgetProperties.IDENTIFIER, SiteAWidgetProperties.IDENTIFIER, SystemComponentIdentifiers.RICH_TEXT_WIDGET_IDENTIFIER, SystemComponentIdentifiers.FORM_WIDGET_IDENTIFIER }" />
```

__SiteB Home page__
```cshtml
<editable-area area-identifier="top"
    area-options-allowed-widgets="new string[] { CommonWidgetProperties.IDENTIFIER, SystemComponentIdentifiers.RICH_TEXT_WIDGET_IDENTIFIER, SystemComponentIdentifiers.FORM_WIDGET_IDENTIFIER }" />
```

Both editable areas also reference a widget which is available on both sites, stored in the `Common` project.

### Site-specific layouts and resources, common view components

Each site in this project uses its own layout file, e.g. [`_Layout.cshtml`](/SiteAWebsite/Views/Shared/_SiteALayout.cshtml). You can see in this layout it is possible to load CSS that applies to both websites, and CSS specific to only that site:

```html
<link rel="stylesheet" href="/_content/Common/Styles/common.css" />
<link rel="stylesheet" href="/_content/SiteAWebsite/site.css" />
```

The correct layout is automatically selected by the [`_ViewStart.cshtml`](/Common/Views/_ViewStart.cshtml) file. While the layouts can be entirely different, it is also possible to incorporate common elements in the layout. For example, if both of these websites should have a common footer element, it can be created in the `Common` project. This repository contains the [`FooterViewComponent.cs`](/Common/Components/ViewComponents/Footer/FooterViewComponent.cs) which is placed on each site's main layout:

```cshtml
@using Common.Components.ViewComponents.Footer
<vc:footer />
```