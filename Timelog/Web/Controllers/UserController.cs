using System;
using System.Web.Http;
using Timelog.Common.Interface;
using Timelog.Model;

namespace Web.Controllers
{
    public class UserController : ApiController
    {
        private readonly IUserDataService _dataService;

        public UserController(IUserDataService dataService)
        {
            _dataService = dataService;
        }

        public IHttpActionResult Get()
        {
            var users = _dataService.GetAll();
            if (users == null)
            {
                return NotFound();
            }
            return Ok(users);
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

        // POST /api/User/5
        //public IHttpActionResult Post(User user)
        //{
        //    _dataService.Add(user);
        //    return Created(new Uri(Url.Link("Api", new { controller = "TimeEntry", id = timeEntry.Id })), timeEntry);
        //}

        // PUT /api/TimeEntry/???
        public IHttpActionResult Put(User value)
        {
            _dataService.Put(value);

            return Ok();
        }

        // DELETE /api/TimeEntry/5
        public IHttpActionResult Delete(int id)
        {
            var status = _dataService.Delete(id);
            if (status)
                return Ok();
            else
                return NotFound();
        }
    }
}
