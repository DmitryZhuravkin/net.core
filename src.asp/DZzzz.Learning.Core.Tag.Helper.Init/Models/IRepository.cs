using System.Collections.Generic;

namespace DZzzz.Learning.Core.Tag.Helper.Init.Models
{
    public interface IRepository
    {
        IEnumerable<City> Cities { get; }

        void AddCity(City newCity);
    }
}