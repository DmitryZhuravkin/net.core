using System.ComponentModel.DataAnnotations;

namespace DZzzz.Learning.Core.BuiltIn.Tag.Helpers.Models
{
    public class City
    {
        [Display(Name = "City")]
        public string Name { get; set; }

        public string Country { get; set; }

        [DisplayFormat(DataFormatString = "{0:F2}", ApplyFormatInEditMode = true)]
        public int? Population { get; set; }

        public string Notes { get; set; }
    }
}