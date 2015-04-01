using System.Collections.Generic;
using Timelog.Model;

namespace Timelog.DataService.Interface
{
    public interface IBookingCodeRepository
    {
        IEnumerable<BookingCode> GetAll();
        BookingCode GetById(int id);
        void Add(BookingCode bookingCode);
    }
}
