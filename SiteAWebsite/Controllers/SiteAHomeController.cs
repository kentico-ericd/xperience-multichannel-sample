using Common;

using Kentico.Content.Web.Mvc.Routing;

using Microsoft.AspNetCore.Mvc;

using SiteAWebsite.Controllers;

[assembly: RegisterWebPageRoute(Home.CONTENT_TYPE_NAME, typeof(SiteAHomeController), WebsiteChannelNames = [Constants.WEBSITE_A_CHANNEL_NAME])]
namespace SiteAWebsite.Controllers
{
    public class SiteAHomeController : Controller
    {
        public IActionResult Index() => View("~/Views/SiteAHome/_Index.cshtml");
    }
}
