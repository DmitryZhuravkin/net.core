using Microsoft.AspNetCore.Razor.TagHelpers;

namespace DZzzz.Learning.Core.Tag.Helper.Init.Infrastructure.TagHelpers
{
    // NOTE: by default tag helpers are applied to ALL <button> elements ({elementName}TagHelper is naming template)
    // HtmlTargetElement is used to restrict tag helper usage
    [HtmlTargetElement("button", Attributes = "bs-button-color", ParentTag = "form")]// will be applied for all <button> with attribute "bs-button-color" and "form" as a parent
    //[HtmlTargetElement(Attributes = "bs-button-color", ParentTag = "form")]// will be applied for all elements with attribute "bs-button-color" and "form" as a parent
    public class ButtonTagHelper : TagHelper
    {
        // bs-button-color will be automatically converter to this property
        // HtmlAttributeName can be used to use different attribute name
        public string BsButtonColor { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Attributes.SetAttribute("class", $"btn btn-{BsButtonColor}");
        }
    }
}