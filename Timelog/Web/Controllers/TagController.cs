using Timelog.DataService.Interface;
using System.Collections.Generic;
using System.Web.Http;
using Timelog.Model;

namespace Web.Controllers
{
    public class TagController : ApiController
    {
        ITagRepository _repository;

        public TagController(ITagRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Tag> Get()
        {
            return _repository.GetAll();
        }

        public IHttpActionResult Get(int id)
        {
            var tag = _repository.GetById(id);
            if (tag == null)
            {
                return NotFound();
            }
            return Ok(tag);
        }
    }
}
