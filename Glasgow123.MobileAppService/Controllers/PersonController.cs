using System;
using System.Linq;
using Glasgow123.MobileAppService.Models;
using Glasgow123.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Glasgow123.MobileAppService.Controllers
{
    [Route("api/[controller]")]
    public class PersonController : Controller
    {

        private readonly IModelRepository<Person> PersonRepository;
        private SQLItemContext _dbContext;

        public PersonController(IModelRepository<Person> personRepository, SQLItemContext dbContext)
        {
            PersonRepository = personRepository;
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult List()
        {
            return Ok(PersonRepository.GetAll());
        }

        [HttpGet("{id}")]
        public Person GetItem(int id)
        {
            Person item = PersonRepository.Get(id);
            return item;
        }

        [HttpGet("login")]
        public IActionResult Login(string email, string password)
        {
            Person person = _dbContext.Persons
                .Include(p => p.FeedbackGiven)
                .Include(p => p.FeedbackReceived)
                .SingleOrDefault(user => user.Email == email && user.Password == password);

            if (person != null)
            {
                return Ok(person);
            }
            return Unauthorized();
        }

        [HttpPost]
        public IActionResult Create([FromBody]Person item)
        {
            try
            {
                if (item == null || !ModelState.IsValid)
                {
                    return BadRequest("Invalid State");
                }

                PersonRepository.Add(item);

            }
            catch (Exception)
            {
                return BadRequest("Error while creating");
            }
            return Ok(item);
        }

        [HttpPut]
        public IActionResult Edit([FromBody] Person item)
        {
            try
            {
                if (item == null || !ModelState.IsValid)
                {
                    return BadRequest("Invalid State");
                }
                PersonRepository.Update(item);
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
            PersonRepository.Remove(id);
        }
    }
}
