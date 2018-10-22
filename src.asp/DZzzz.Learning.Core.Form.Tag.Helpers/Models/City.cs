using System.ComponentModel.DataAnnotations;

namespace DZzzz.Learning.Core.Form.Tag.Helpers.Models
{
    public class City
    {
        //[UIHint()] - attribute is used to override default mapping between c# type and browser type attribute
        public string Name { get; set; }
        public string Country { get; set; }

        [DisplayFormat(DataFormatString = "{0:F2}", ApplyFormatInEditMode = true)] // data format
        public int? Population { get; set; }
    }
}