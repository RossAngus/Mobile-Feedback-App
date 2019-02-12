using Glasgow123.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Glasgow123.MobileAppService.Models.Repositories
{
    public class PersonRepository : IModelRepository<Person>
    {
        private SQLItemContext _dbContext;

        public PersonRepository(SQLItemContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Person Get(int id)
        {
            return _dbContext.Persons
                .Where(item => item.Id == id).First();
        }

        public IEnumerable<Person> GetAll()
        {
            return _dbContext.Persons;
        }

        public void Add(Person item)
        {
            _dbContext.Persons.Add(item);
            _dbContext.SaveChanges();
        }

        public Person Find(int id)
        {
            return _dbContext.Persons.First(item => item.Id == id);
        }

        public Person Remove(int id)
        {
            var item = _dbContext.Persons.First(itemToRemove => itemToRemove.Id == id);
            _dbContext.Persons.Attach(item);
            _dbContext.Persons.Remove(item);
            _dbContext.SaveChanges();

            return item;
        }

        public void Update(Person updatedItem)
        {
            var oldItem = _dbContext.Persons.First(item => item.Id == updatedItem.Id);
            oldItem.Name = updatedItem.Name;
            oldItem.Surname = updatedItem.Surname;
            oldItem.Email = updatedItem.Email;
            oldItem.Password = updatedItem.Password;
            oldItem.IsTeacher = updatedItem.IsTeacher;

            _dbContext.Persons.Update(oldItem);
            _dbContext.SaveChanges();
        }
    }
}
