using CMS.Websites.Routing;

using Microsoft.AspNetCore.Mvc;

namespace Common.Components.ViewComponents.Footer
{
    public class FooterViewComponent(IWebsiteChannelContext websiteChannelContext) : ViewComponent
    {
        private readonly IWebsiteChannelContext websiteChannelContext = websiteChannelContext;

        public IViewComponentResult Invoke()
        {
            var channelName = websiteChannelContext.WebsiteChannelName;

            return View("~/Components/ViewComponents/Footer/Default.cshtml", channelName);
        }
    }
}
