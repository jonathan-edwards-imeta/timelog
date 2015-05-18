using System;
using System.Collections.Generic;
using Timelog.DataAccess;
using Timelog.DataAccess.Interface;
using Timelog.DataService.Interface;
using Timelog.Model;
using TimeLog.EntityFramework.Interfaces;

namespace Timelog.DataService
{
    public class TagDataService : ITagDataService
    {
        private readonly IDbContextScopeFactory _dbContextScopeFactory;
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
            if (tagToDelete == null)
                throw new ArgumentNullException("tagToDelete");

            using (var dbContextScope = _dbContextScopeFactory.Create())
            {
                //-- Persist
                _tagRepository.Delete(tagToDelete);
                var result = dbContextScope.SaveChanges();
               
                return true;
            }
        }

        public IEnumerable<Tag> GetAll()
        {
            using (var dbContextScope = _dbContextScopeFactory.CreateReadOnly())
            {
                var dbContext = dbContextScope.DbContexts.Get<TimeLogContext>();
                var result = _tagRepository.GetAll();
                return result;
            }
        }

        public Tag GetById(int id)
        {
            using (var dbContextScope = _dbContextScopeFactory.CreateReadOnly())
            {
                var dbContext = dbContextScope.DbContexts.Get<TimeLogContext>();
                var result = _tagRepository.GetById(id);
                return result;
            }
        }
    }
}
