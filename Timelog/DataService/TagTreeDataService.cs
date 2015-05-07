using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timelog.DataAccess;
using Timelog.DataAccess.Interface;
using Timelog.DataService.Interface;
using Timelog.Model;
using TimeLog.EntityFramework.Interfaces;

namespace Timelog.DataService
{
    public class TagTreeDataService : ITagTreeDataService
    {
        private readonly IDbContextScopeFactory _dbContextScopeFactory;
        ITagTreeRepository _tagTreeRepository;

        public TagTreeDataService(IDbContextScopeFactory dbContextScopeFactory, ITagTreeRepository tagTreeRepository)
        {
            if (dbContextScopeFactory == null) throw new ArgumentNullException("dbContextScopeFactory");
            if (tagTreeRepository == null) throw new ArgumentNullException("tagTreeRepository");
            _dbContextScopeFactory = dbContextScopeFactory;
            _tagTreeRepository = tagTreeRepository;
        }

        public void Add(TagTree tagTreeToCreate)
        {
            if (tagTreeToCreate == null)
                throw new ArgumentNullException("tagTreeToCreate");

            using (var dbContextScope = _dbContextScopeFactory.Create())
            {
                //-- Persist
                _tagTreeRepository.Add(tagTreeToCreate);
                dbContextScope.SaveChanges();
            }
        }

        public bool Delete(int tagTreeToDelete)
        {
            if (tagTreeToDelete == null)
                throw new ArgumentNullException("tagTreeToDelete");

            using (var dbContextScope = _dbContextScopeFactory.Create())
            {
                //-- Persist
                _tagTreeRepository.Delete(tagTreeToDelete);
                var result = dbContextScope.SaveChanges();
               
                return true;
            }
        }

        public IEnumerable<TagTree> GetAll()
        {
            using (var dbContextScope = _dbContextScopeFactory.CreateReadOnly())
            {
                var dbContext = dbContextScope.DbContexts.Get<TimeLogContext>();
                var result = _tagTreeRepository.GetAll();
                return result;
            }
        }

        public TagTree GetById(int id)
        {
            using (var dbContextScope = _dbContextScopeFactory.CreateReadOnly())
            {
                var dbContext = dbContextScope.DbContexts.Get<TimeLogContext>();
                var result = _tagTreeRepository.GetById(id);
                return result;
            }
        }
    }
}
