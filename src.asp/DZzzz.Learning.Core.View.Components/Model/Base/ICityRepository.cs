using System.Collections.Generic;

namespace DZzzz.Learning.Core.View.Components.Model.Base
{
    public interface ICityRepository
    {
        IEnumerable<City> Cities { get; }

        void AddCity(City newCity);
    }
}