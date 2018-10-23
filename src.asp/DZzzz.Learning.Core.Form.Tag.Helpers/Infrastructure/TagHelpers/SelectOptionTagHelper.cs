using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

using DZzzz.Learning.Core.Form.Tag.Helpers.Models;

using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace DZzzz.Learning.Core.Form.Tag.Helpers.Infrastructure.TagHelpers
{
    // tag helper to fill <select> element with options
    // this approach is better then ViewBag because we don`t need to specify for each controller action
    [HtmlTargetElement("select", Attributes = "model-for")]
    public class SelectOptionTagHelper : TagHelper
    {
        private readonly IRepository repository;

        public SelectOptionTagHelper(IRepository repo)
        {
            repository = repo;
        }
        public ModelExpression ModelFor { get; set; }

        // async tag helper
        public override async Task ProcessAsync(TagHelperContext context,
            TagHelperOutput output)
        {
            output.Content.AppendHtml((await output.GetChildContentAsync(false)).GetContent()); // add existing content

            string selected = ModelFor.Model as string;

            PropertyInfo property = typeof(City).GetTypeInfo().GetDeclaredProperty(ModelFor.Name);

            foreach (string country in repository.Cities
                .Select(c => property.GetValue(c)).Distinct())
            {
                if (selected != null && selected.Equals(country,
                        StringComparison.OrdinalIgnoreCase))
                {
                    output.Content
                        .AppendHtml($"<option selected>{country}</option>");
                }
                else
                {
                    output.Content.AppendHtml($"<option>{country}</option>");
                }
            }
            output.Attributes.SetAttribute("Name", ModelFor.Name);
            output.Attributes.SetAttribute("Id", ModelFor.Name);
        }
    }
}