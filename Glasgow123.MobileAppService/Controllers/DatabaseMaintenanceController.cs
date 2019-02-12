using Glasgow123.MobileAppService.Engine;
using Glasgow123.MobileAppService.Models;
using Glasgow123.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Glasgow123.MobileAppService.Controllers
{
    [Route("api/[controller]")]
    public class DatabaseMaintenanceController
    {
        private readonly IModelRepository<Feedback> FeedbackRepository;

        private SQLItemContext _dbContext;

        public DatabaseMaintenanceController(IModelRepository<Feedback> feedbackRepository,
            SQLItemContext dbContext)
        {
            FeedbackRepository = feedbackRepository;
            _dbContext = dbContext;
        }

        [HttpPut]
        public void AddMockedData()
        {
            MockDataGenerator.AddData(FeedbackRepository, _dbContext);
        }

        [HttpDelete]
        public void RemoveAllData()
        {
            _dbContext.Feedbacks.RemoveRange(_dbContext.Feedbacks);
            _dbContext.PersonClasses.RemoveRange(_dbContext.PersonClasses);
            _dbContext.UniversityClasses.RemoveRange(_dbContext.UniversityClasses);
            _dbContext.Persons.RemoveRange(_dbContext.Persons);
            _dbContext.SaveChanges();
        }
    }
}
