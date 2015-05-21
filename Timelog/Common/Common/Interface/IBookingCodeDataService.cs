using Timelog.Model;

namespace Timelog.Common.Interface
{
    public interface IBookingCodeDataService : IGetAllDataService<BookingCode>
    {
        void Create(BookingCode bookingCode);
    }
}
