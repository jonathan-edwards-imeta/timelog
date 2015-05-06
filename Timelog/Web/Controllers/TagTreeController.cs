using Timelog.DataService.Interface;
using System.Collections.Generic;
using System.Web.Http;
using Timelog.Model;

namespace Web.Controllers
{
    public class TagTreeController : ApiController
    {
        private readonly ITagTreeRepository _repository;

        public TagTreeController(ITagTreeRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<TagTree> Get()
        {
            return _repository.GetAll();
        }

        public IHttpActionResult Get(int id)
        {
            var tagTree = _repository.GetById(id);
            if (tagTree == null)
            {
                return NotFound();
            }
            return Ok(tagTree);
        }
    }
}
