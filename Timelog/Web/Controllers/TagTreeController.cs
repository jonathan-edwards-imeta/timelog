using System.Web.Http;
using Timelog.Common.Interface;

namespace Web.Controllers
{
    public class TagTreeController : ApiController
    {
        private readonly ITagTreeDataService _dataService;

        public TagTreeController(ITagTreeDataService dataService)
        {
            _dataService = dataService;
        }

        public IHttpActionResult Get()
        {
            var tagTrees = _dataService.GetAll();

            if (tagTrees == null)
            {
                return NotFound();
            }
            return Ok(tagTrees);
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