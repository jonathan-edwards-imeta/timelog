using System.Collections.Generic;
using Timelog.Model;

namespace Timelog.DataService.Interface
{
    public interface IBookingCodeDataService
    {
        IEnumerable<BookingCode> GetAll();
        BookingCode GetById(int id);
        void CreateBookingCode(BookingCode bookingCodeToCreate);
        bool Delete(int bookingCodeIdToDelete);
    }
}
