using System.Collections.Generic;
using System.Web.Http;
using Timelog.Common.Interface;
using Timelog.Model;

namespace Web.Controllers
{
    public class TimeEntryController : ApiController
    {
        ITimeEntryDataService _dataService;

        public TimeEntryController(ITimeEntryDataService dataService)
        {
            _dataService = dataService;
        }

        // GET /api/TimeEntry/5
        public IHttpActionResult Get(int id)
        {
            var timeEntry = _dataService.GetById(id);
            if (timeEntry == null)
            {
                return NotFound();
            }
            return Ok(timeEntry);
        }

        // POST /api/TimeEntry/5
        public void Post(TimeEntry timeEntry)
        {
            _dataService.Add(timeEntry);
        }

        // PUT /api/TimeEntry/???
        public void Put(TimeEntry value)
        {
            _dataService.Put(value);           
        }

        // DELETE /api/TimeEntry/5
        public void Delete(int id)
        {
            _dataService.Delete(id);
        }
    }
}
