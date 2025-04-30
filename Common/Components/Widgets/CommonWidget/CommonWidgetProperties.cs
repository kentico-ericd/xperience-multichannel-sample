using Kentico.PageBuilder.Web.Mvc;

using Kentico.Xperience.Admin.Base.FormAnnotations;

using Common.Components.Widgets.CommonWidget;

[assembly: RegisterWidget(
    CommonWidgetProperties.IDENTIFIER,
    "Common Widget",
    typeof(CommonWidgetProperties),
    "~/Components/Widgets/CommonWidget/_Index.cshtml",
    Description = "A widget available on both sites",
    IconClass = "icon-right-double-quotation-mark")]
namespace Common.Components.Widgets.CommonWidget
{
    /// <summary>
    /// Properties for a widget available on both sites.
    /// </summary>
    public class CommonWidgetProperties : IWidgetProperties
    {
        public const string IDENTIFIER = "CommonWidget";

        [TextInputComponent(Label = "Widget text")]
        public string? Text { get; set; }
    }
}
