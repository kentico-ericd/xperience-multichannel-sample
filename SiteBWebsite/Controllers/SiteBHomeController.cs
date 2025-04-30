using Common;

using Kentico.Content.Web.Mvc.Routing;

using Microsoft.AspNetCore.Mvc;

using SiteBWebsite.Controllers;

[assembly: RegisterWebPageRoute(Home.CONTENT_TYPE_NAME, typeof(SiteBHomeController), WebsiteChannelNames = [Constants.WEBSITE_B_CHANNEL_NAME])]
namespace SiteBWebsite.Controllers
{
    public class SiteBHomeController : Controller
    {
        public IActionResult Index() => View("~/Views/SiteBHome/_Index.cshtml");
    }
}
