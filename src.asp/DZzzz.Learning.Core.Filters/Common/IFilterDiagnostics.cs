using System.Collections.Generic;

namespace DZzzz.Learning.Core.Filters.Common
{
    public interface IFilterDiagnostics
    {
        IEnumerable<string> Messages { get; }
        void AddMessage(string message);
    }
}