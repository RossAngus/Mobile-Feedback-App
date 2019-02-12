using Glasgow123.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Glasgow123.MobileAppService.Models.Repositories
{
    public class FeedbackRepository : IModelRepository<Feedback>
    {
        private SQLItemContext _dbContext;

        public FeedbackRepository(SQLItemContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Feedback Get(int id)
        {
            return _dbContext.Feedbacks
                .Where(item => item.Id == id).First();
        }

        public IEnumerable<Feedback> GetAll()
        {
            return _dbContext.Feedbacks;
        }

        public void Add(Feedback item)
        {
            _dbContext.Feedbacks.Add(item);
            _dbContext.SaveChanges();
        }

        public Feedback Find(int id)
        {
            return _dbContext.Feedbacks.First(item => item.Id == id);
        }

        public Feedback Remove(int id)
        {
            var item = _dbContext.Feedbacks.First(itemToRemove => itemToRemove.Id == id);
            _dbContext.Feedbacks.Attach(item);
            _dbContext.Feedbacks.Remove(item);
            _dbContext.SaveChanges();

            return item;
        }

        public void Update(Feedback updatedItem)
        {
            var oldItem = _dbContext.Feedbacks.First(item => item.Id == updatedItem.Id);
            oldItem.Date = updatedItem.Date;
            oldItem.UniversityClass = updatedItem.UniversityClass;
            oldItem.Comment = updatedItem.Comment;
            oldItem.Score = updatedItem.Score;
            oldItem.ToPerson = updatedItem.ToPerson;

            _dbContext.Feedbacks.Update(oldItem);
            _dbContext.SaveChanges();
        }
    }
}
