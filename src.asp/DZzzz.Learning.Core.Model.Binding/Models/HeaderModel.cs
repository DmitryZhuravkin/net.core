using Microsoft.AspNetCore.Mvc;

namespace DZzzz.Learning.Core.Model.Binding.Models
{
    public class HeaderModel
    {
        [FromHeader]
        public string Accept { get; set; }

        [FromHeader(Name = "Accept-Language")]
        public string AcceptLanguage { get; set; }

        [FromHeader(Name = "Accept-Encoding")]
        public string AcceptEncoding { get; set; }

        public override string ToString()
        {
            return $"Accept:{Accept};\r\nAcceptLanguage:{AcceptLanguage};\r\nAcceptEncoding:{AcceptEncoding}";
        }
    }
}