using Kentico.PageBuilder.Web.Mvc;

using Kentico.Xperience.Admin.Base.FormAnnotations;

using SiteAWebsite.Components.Widgets.SiteAWidget;

[assembly: RegisterWidget(
    SiteAWidgetProperties.IDENTIFIER,
    "Site A Widget",
    typeof(SiteAWidgetProperties),
    "~/Components/Widgets/SiteAWidget/_Index.cshtml",
    Description = "A widget only available on Site A",
    IconClass = "icon-rectangle-a")]
namespace SiteAWebsite.Components.Widgets.SiteAWidget
{
    /// <summary>
    /// Properties for a widget only available on SiteA.
    /// </summary>
    public class SiteAWidgetProperties : IWidgetProperties
    {
        public const string IDENTIFIER = "SiteAWidget";

        [TextInputComponent(Label = "Widget text")]
        public string? Text { get; set; }
    }
}
