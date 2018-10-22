using Microsoft.AspNetCore.Razor.TagHelpers;

namespace DZzzz.Learning.Core.Tag.Helper.Init.Infrastructure.TagHelpers
{
    [HtmlTargetElement("div", Attributes = "theme")]
    public class ButtonGroupThemeTagHelper : TagHelper
    {
        public string Theme { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            context.Items["theme"] = Theme;
        }
    }
}