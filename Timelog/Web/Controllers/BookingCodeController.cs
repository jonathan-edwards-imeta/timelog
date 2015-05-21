using System.Collections.Generic;
using System.Web.Http;
using Timelog.Common.Interface;
using Timelog.Model;

namespace Web.Controllers
{
    public class BookingCodeController : ApiController
    {
        IBookingCodeDataService _dataService;

        public BookingCodeController(IBookingCodeDataService dataService)
        {
            _dataService = dataService;
        }

        public IEnumerable<BookingCode> Get()
        {
            return _dataService.GetAll();
        }

        public IHttpActionResult Get(int id)
        {
            var bookingCode = _dataService.GetById(id);
            if (bookingCode == null)
            {
                return NotFound();
            }
            return Ok(bookingCode);
        }

        // POST /api/BookingCode/5
        public void Post(BookingCode bookingCode)
        {
            _dataService.Create(bookingCode);
        }
    }
}
