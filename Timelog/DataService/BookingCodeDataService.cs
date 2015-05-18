using System;
using System.Collections.Generic;
using Timelog.DataAccess;
using Timelog.DataAccess.Interface;
using Timelog.DataService.Interface;
using Timelog.Model;
using TimeLog.EntityFramework.Interfaces;

namespace Timelog.DataService
{
    //CR-SKG: Same problems as TagDataService
    //Could our dataservice be replaced with a single DataService<T>
    //and then we could create each implementation as an inheritance from DataService<T> where T is the correct type. for example.
    //public interface ITagTreeDataService : IDataService<TagTree>
    //public class TagTreeDataService : DataService<TagTree>, ITagTreeDataService
    public class BookingCodeDataService : IBookingCodeDataService
    {
        private readonly IDbContextScopeFactory _dbContextScopeFactory;
        IBookingCodeRepository _bookingCodeRepository;
        
        public BookingCodeDataService(IDbContextScopeFactory dbContextScopeFactory, IBookingCodeRepository bookingCodeRepository)
        {
            if (dbContextScopeFactory == null) throw new ArgumentNullException("dbContextScopeFactory");
            if (bookingCodeRepository == null) throw new ArgumentNullException("bookingCodeRepository");
            _dbContextScopeFactory = dbContextScopeFactory;
            _bookingCodeRepository = bookingCodeRepository;
        }

        public void CreateBookingCode(BookingCode bookingCodeToCreate)
        {
            if (bookingCodeToCreate == null)
                throw new ArgumentNullException("bookingCodeToCreate");

            using (var dbContextScope = _dbContextScopeFactory.Create())
            {               
                //-- Persist
                _bookingCodeRepository.Add(bookingCodeToCreate);
                dbContextScope.SaveChanges();
            }
        }

        public IEnumerable<BookingCode> GetAll()
        {
            using (var dbContextScope = _dbContextScopeFactory.CreateReadOnly())
            {
                var dbContext = dbContextScope.DbContexts.Get<TimeLogContext>();
                var result = _bookingCodeRepository.GetAll();
                return result;
            }
        }

        public BookingCode GetById(int id)
        {
            using (var dbContextScope = _dbContextScopeFactory.CreateReadOnly())
            {
                var dbContext = dbContextScope.DbContexts.Get<TimeLogContext>();
                var result = _bookingCodeRepository.GetById(id);
                return result;
            }
        }

        public bool Delete(int bookingCodeIdToDelete)
        {
            if (bookingCodeIdToDelete == null)
                throw new ArgumentNullException("bookingCodeTodelete");

            using (var dbContextScope = _dbContextScopeFactory.Create())
            {
                //-- Persist
                _bookingCodeRepository.Delete(bookingCodeIdToDelete);
                var result = dbContextScope.SaveChanges();
                return true;
            }            
        }
    }
}
