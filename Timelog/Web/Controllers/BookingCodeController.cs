using System.Collections.Generic;
using System.Web.Http;
using Timelog.DataService.Interface;
using Timelog.Model;

namespace Web.Controllers
{
    public class BookingCodeController : ApiController
    {
        IBookingCodeRepository _repository;

        public BookingCodeController(IBookingCodeRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<BookingCode> Get()
        {
            return _repository.GetAll();
        }

        public IHttpActionResult Get(int id)
        {
            var bookingCode = _repository.GetById(id);
            if (bookingCode == null)
            {
                return NotFound();
            }
            return Ok(bookingCode);
        }
    }
}
