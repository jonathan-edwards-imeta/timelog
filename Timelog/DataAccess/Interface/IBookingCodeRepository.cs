using System.Collections.Generic;
using Timelog.Model;

namespace Timelog.DataAccess.Interface
{
    public interface IBookingCodeRepository
    {
        IEnumerable<BookingCode> GetAll();
        BookingCode GetById(int id);
        
        //Personal preference, do we need to have the naming convention, BookingCodeTo<Action> - doesn't the method name make it obvious?
        void Add(BookingCode bookingCodeToAdd);
        bool Delete(int bookingCodeIdToDelete);
    }
}
