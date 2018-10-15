using System.Collections.Generic;

namespace DZzzz.Learning.Core.Api.Models
{
    public interface IRepository
    {
        IEnumerable<Reservation> Reservations { get; }
        Reservation this[int id] { get; }

        Reservation AddReservation(Reservation reservation);
        Reservation UpdateReservation(Reservation reservation);

        void DeleteReservation(int id);
    }
}