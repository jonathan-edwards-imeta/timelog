using System;
using Timelog.Common.Interface;
using Timelog.Model;
using TimeLog.EntityFramework.Interfaces;

namespace Timelog.Common
{
    public class BookingCodeDataService : GetAllDataService<BookingCode>, IBookingCodeDataService
    {
        public BookingCodeDataService(IDbContextScopeFactory dbContextScopeFactory, IBookingCodeRepository BookingCodeRepository) :
             base(dbContextScopeFactory, BookingCodeRepository)
        { }

        public void Create(BookingCode bookingCode)
        {
           
            if (bookingCode == null)
                throw new ArgumentNullException("bookingCode");

            using (var dbContextScope = DbContextScopeFactory.Create())
            {
                ((IBookingCodeRepository)Repository).Add(bookingCode);
                dbContextScope.SaveChanges();
            }
        }
    }
}
