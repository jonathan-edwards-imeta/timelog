using System.Web.Http;
using Timelog.Common.Interface;
using Timelog.Model;

namespace Web.Controllers
{
    public class BookingCodeController : ApiController
    {
        private readonly IBookingCodeDataService _dataService;

        public BookingCodeController(IBookingCodeDataService dataService)
        {
            _dataService = dataService;
        }

        public IHttpActionResult Get()
        {
            var bookingCodes = _dataService.GetAll();

            if (bookingCodes == null)
            {
                return NotFound();
            }
            return Ok(bookingCodes);
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
        public IHttpActionResult Post(BookingCode bookingCode)
        {
            _dataService.Create(bookingCode);

            return Ok();
        }
    }
}