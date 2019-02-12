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
    public class FeedbackController : Controller
    {

        private readonly IModelRepository<Feedback> FeedbackRepository;
        private SQLItemContext _dbContext;

        public FeedbackController(IModelRepository<Feedback> feedbackRepository, SQLItemContext dbContext)
        {
            FeedbackRepository = feedbackRepository;
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult List()
        {
            return Ok(FeedbackRepository.GetAll());
        }

        [HttpGet("{id}")]
        public Feedback GetItem(int id)
        {
            Feedback item = FeedbackRepository.Get(id);
            return item;
        }

        [HttpPost]
        public IActionResult Create([FromBody]Feedback item)
        {
            try
            {
                if (item == null || !ModelState.IsValid)
                {
                    return BadRequest("Invalid State");
                }

                FeedbackRepository.Add(item);

            }
            catch (Exception)
            {
                return BadRequest("Error while creating");
            }
            return Ok(item);
        }

        [HttpPut]
        public IActionResult Edit([FromBody] Feedback item)
        {
            try
            {
                if (item == null || !ModelState.IsValid)
                {
                    return BadRequest("Invalid State");
                }
                FeedbackRepository.Update(item);
            }
            catch (Exception)
            {
                return BadRequest("Error while creating");
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            FeedbackRepository.Remove(id);
        }
    }
}
