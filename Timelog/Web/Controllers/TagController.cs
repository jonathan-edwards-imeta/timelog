using Timelog.DataService.Interface;
using System.Collections.Generic;
using System.Web.Http;
using Timelog.Model;

namespace Web.Controllers
{
    public class TagController : ApiController
    {
        ITagDataService _dataService;

        public TagController(ITagDataService dataService)
        {
            _dataService = dataService;
        }


        public IEnumerable<Tag> Get()
        {
            return _dataService.GetAll();
        }

        public IHttpActionResult Get(int id)
        {
            var tag = _dataService.GetById(id);
            if (tag == null)
            {
                return NotFound();
            }
            return Ok(tag);
        }
    }
}
