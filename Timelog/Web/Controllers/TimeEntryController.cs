using System.Collections.Generic;
using System.Web.Http;
using Timelog.DataService.Interface;
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

        // GET /api/TimeEntry
        public IEnumerable<TimeEntry> Get()
        {
            return _repository.GetAll();
        }

        // GET /api/TimeEntry/5
        public IHttpActionResult Get(int id)
        {
            var timeEntry = _repository.GetById(id);
            if (timeEntry == null)
            {
                return NotFound();
            }
            return Ok(timeEntry);
        }

        // POST /api/TimeEntry/5
        public void Post(TimeEntry timeEntry)
        {
            _repository.Add(timeEntry);
        }

        // PUT /api/TimeEntry/???
        public void Put(TimeEntry value)
        {
            _repository.Put(value);           
        }

        // DELETE /api/TimeEntry/5
        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
