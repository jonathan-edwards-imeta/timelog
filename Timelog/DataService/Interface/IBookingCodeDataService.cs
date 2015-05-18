using System.Collections.Generic;
using Timelog.Model;

namespace Timelog.DataService.Interface
{
    //CR-SKG: We should move this into the common assembly, this will save referencing this assembly if anyone needs
    //to use these interfaces. Also considering converting to IDataService<T> - See TagTreeDataService.cs
    public interface IBookingCodeDataService
    {
        IEnumerable<BookingCode> GetAll();
        BookingCode GetById(int id);
        void CreateBookingCode(BookingCode bookingCodeToCreate);
        bool Delete(int bookingCodeIdToDelete);
    }
}
