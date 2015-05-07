using System.Collections.Generic;
using Timelog.Model;

namespace Timelog.DataAccess.Interface
{
    public interface IBookingCodeRepository
    {
        IEnumerable<BookingCode> GetAll();
        BookingCode GetById(int id);
        void Add(BookingCode bookingCodeToAdd);
        bool Delete(int bookingCodeIdToDelete);
    }
}
