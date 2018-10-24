using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace DZzzz.Learning.Core.Model.Binding.Models
{
    //[Bind(nameof(City))] - can be applied to class, and will be used for ALL actions
    public class AddressSummary
    {
        // [BindRequired] - mark property as required for binding, will generate Model Validation Error
        public string City { get; set; }
        //[BindNever] - will exclude property from binding
        public string Country { get; set; }
    }
}