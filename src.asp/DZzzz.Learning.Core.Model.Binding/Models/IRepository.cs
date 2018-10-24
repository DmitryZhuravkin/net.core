using System.Collections.Generic;

namespace DZzzz.Learning.Core.Model.Binding.Models
{
    public interface IRepository
    {
        IEnumerable<Person> People { get; }
        Person this[int id] { get; set; }
    }
}