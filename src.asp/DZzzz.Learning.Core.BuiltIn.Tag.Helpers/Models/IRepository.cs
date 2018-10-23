using System.Collections.Generic;

namespace DZzzz.Learning.Core.BuiltIn.Tag.Helpers.Models
{
    public interface IRepository
    {
        IEnumerable<City> Cities { get; }

        void AddCity(City newCity);
    }
}