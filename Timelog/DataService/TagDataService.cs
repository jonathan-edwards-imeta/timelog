using System;
using System.Collections.Generic;
using Timelog.DataAccess;
using Timelog.DataAccess.Interface;
using Timelog.DataService.Interface;
using Timelog.Model;
using TimeLog.EntityFramework.Interfaces;

namespace Timelog.DataService
{
    //CR-SKG: Same problems as TagDataService
    //Could our dataservice be replaced with a single DataService<T>
    //and then we could create each implementation as an inheritance from DataService<T> where T is the correct type. for example.
    //public interface ITagTreeDataService : IDataService<TagTree>
    //public class TagTreeDataService : DataService<TagTree>, ITagTreeDataService
    public class TagDataService : ITagDataService
    {
        private readonly IDbContextScopeFactory _dbContextScopeFactory;

        //CR-SKG: This can be made readonly.
        ITagRepository _tagRepository;

        public TagDataService(IDbContextScopeFactory dbContextScopeFactory, ITagRepository tagRepository)
        {
            if (dbContextScopeFactory == null) throw new ArgumentNullException("dbContextScopeFactory");
            if (tagRepository == null) throw new ArgumentNullException("tagRepository");
            _dbContextScopeFactory = dbContextScopeFactory;
            _tagRepository = tagRepository;
        }

        public void Add(Tag tagToCreate)    
        {
            if (tagToCreate == null)
                throw new ArgumentNullException("tagToCreate");

            using (var dbContextScope = _dbContextScopeFactory.Create())
            {
                //-- Persist
                _tagRepository.Add(tagToCreate);
                dbContextScope.SaveChanges();
            }
        }

        public bool Delete(int tagToDelete)
        {
            //CR-SKG: This is always false, did you mean int? or tagToDelete == 0
            if (tagToDelete == null)
                throw new ArgumentNullException("tagToDelete");

            using (var dbContextScope = _dbContextScopeFactory.Create())
            {
                //-- Persist
                _tagRepository.Delete(tagToDelete);

                //CR-SKG: do we need the result?
                var result = dbContextScope.SaveChanges();
               
                return true;
            }
        }

        public IEnumerable<Tag> GetAll()
        {
            using (var dbContextScope = _dbContextScopeFactory.CreateReadOnly())
            {
                //CR-SKG: Do we need to get the dbContext from the dbContextScope?
                var dbContext = dbContextScope.DbContexts.Get<TimeLogContext>();
                var result = _tagRepository.GetAll();
                return result;
            }
        }

        public Tag GetById(int id)
        {
            using (var dbContextScope = _dbContextScopeFactory.CreateReadOnly())
            {
                //CR-SKG: Do we need to get the dbContext from the dbContextScope?
                var dbContext = dbContextScope.DbContexts.Get<TimeLogContext>();
                var result = _tagRepository.GetById(id);
                return result;
            }
        }
    }
}
