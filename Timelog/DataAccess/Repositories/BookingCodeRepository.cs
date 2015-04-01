using System;
using System.Collections.Generic;
using System.Linq;
using Timelog.DataService.Interface;
using Timelog.Model;

namespace Timelog.DataAccess.Repositories
{
    public class BookingCodeRepository : IBookingCodeRepository, IDisposable
    {
        private TimeLogContext db = new TimeLogContext();

        public IEnumerable<BookingCode> GetAll()
        {
            return db.BookingCodes;
        }
        public BookingCode GetById(int id)
        {
            return db.BookingCodes.FirstOrDefault(p => p.Id == id);
        }
        public void Add(BookingCode BookingCode)
        {
            db.BookingCodes.Add(BookingCode);
            db.SaveChanges();
        }

        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (db != null)
                {
                    db.Dispose();
                    db = null;
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
