using Timelog.DataService.Interface;
using System.Collections.Generic;
using System.Web.Http;
using Timelog.Model;

namespace Web.Controllers
{
    public class TagTreeController : ApiController
    {
        ITagTreeDataService _dataService;

        public TagTreeController(ITagTreeDataService dataService)
        {
            _dataService = dataService;
        }       

        public IEnumerable<TagTree> Get()
        {
            return _dataService.GetAll();
        }

        public IHttpActionResult Get(int id)
        {
            var tagTree = _dataService.GetById(id);
            if (tagTree == null)
            {
                return NotFound();
            }
            return Ok(tagTree);
        }
    }
}
