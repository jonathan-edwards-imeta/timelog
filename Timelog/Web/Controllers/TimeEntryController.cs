using Timelog.DataService.Interface;
using System.Collections.Generic;
using System.Web.Http;
using Timelog.Model;

namespace Web.Controllers
{
    public class TimeEntryController : ApiController
    {
        ITimeEntryRepository _repository;

        public TimeEntryController(ITimeEntryRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<TimeEntry> Get()
        {
            return _repository.GetAll();
        }

        public IHttpActionResult Get(int id)
        {
            var timeEntry = _repository.GetById(id);
            if (timeEntry == null)
            {
                return NotFound();
            }
            return Ok(timeEntry);
        }
    }
}
