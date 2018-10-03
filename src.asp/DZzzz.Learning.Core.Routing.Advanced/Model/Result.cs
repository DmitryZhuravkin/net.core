using System.Collections.Generic;

namespace DZzzz.Learning.Core.Routing.Advanced.Model
{
    public class Result
    {
        public string Controller { get; set; }

        public string Action { get; set; }

        public Dictionary<string, string> Data { get; } = new Dictionary<string, string>();
    }
}