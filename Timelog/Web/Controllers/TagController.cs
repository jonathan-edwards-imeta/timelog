using System.Web.Http;
using Timelog.Common.Interface;

namespace Web.Controllers
{
    public class TagController : ApiController
    {
        private readonly ITagDataService _dataService;

        public TagController(ITagDataService dataService)
        {
            _dataService = dataService;
        }

        public IHttpActionResult Get()
        {
            var tags = _dataService.GetAll();

            if (tags == null)
            {
                return NotFound();
            }
            return Ok(tags);
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