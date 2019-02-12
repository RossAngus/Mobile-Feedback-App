using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using Glasgow123.MobileAppService.Models;
using System.Linq;

namespace Glasgow123.Models
{
    public class UniversityClassRepository : IModelRepository<UniversityClass>
    {
        private SQLItemContext _dbContext;

        public UniversityClassRepository(SQLItemContext dbContext)
        {
            _dbContext = dbContext;
        }

        public UniversityClass Get(int id)
        {
            return _dbContext.UniversityClasses
                .Where(item => item.Id == id).First();
        }

        public IEnumerable<UniversityClass> GetAll()
        {
            return _dbContext.UniversityClasses;
        }

        public void Add(UniversityClass item)
        {
            _dbContext.UniversityClasses.Add(item);
            _dbContext.SaveChanges();
        }

        public UniversityClass Find(int id)
        {
            return _dbContext.UniversityClasses.First(item => item.Id == id);
        }

        public UniversityClass Remove(int id)
        {
            var item = _dbContext.UniversityClasses.First(itemToRemove => itemToRemove.Id == id);
            _dbContext.UniversityClasses.Attach(item);
            _dbContext.UniversityClasses.Remove(item);
            _dbContext.SaveChanges();

            return item;
        }

        public void Update(UniversityClass updatedItem)
        {
            var oldItem = _dbContext.UniversityClasses.First(item => item.Id == updatedItem.Id);
            oldItem.Title = updatedItem.Title;
            oldItem.Description = updatedItem.Description;
            oldItem.Lecturer = updatedItem.Lecturer;

            _dbContext.UniversityClasses.Update(oldItem);
            _dbContext.SaveChanges();
        }
    }
}
