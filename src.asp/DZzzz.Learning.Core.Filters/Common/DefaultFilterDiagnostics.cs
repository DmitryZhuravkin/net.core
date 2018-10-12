using System.Collections.Generic;

namespace DZzzz.Learning.Core.Filters.Common
{
    public class DefaultFilterDiagnostics : IFilterDiagnostics
    {
        private readonly List<string> messages = new List<string>();

        public IEnumerable<string> Messages => messages;

        public void AddMessage(string message) => messages.Add(message);
    }
}