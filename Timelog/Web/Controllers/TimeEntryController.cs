﻿using System.Web.Http;
using Timelog.Common.Interface;
using Timelog.Model;

namespace Web.Controllers
{
    public class TimeEntryController : ApiController
    {
        private readonly ITimeEntryDataService _dataService;

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
        public IHttpActionResult Post(TimeEntry timeEntry)
        {
            _dataService.Add(timeEntry);

            return Ok();
        }

        // PUT /api/TimeEntry/???
        public IHttpActionResult Put(TimeEntry value)
        {
            _dataService.Put(value);

            return Ok();
        }

        // DELETE /api/TimeEntry/5
        public IHttpActionResult Delete(int id)
        {
            _dataService.Delete(id);

            return Ok();
        }
    }
}