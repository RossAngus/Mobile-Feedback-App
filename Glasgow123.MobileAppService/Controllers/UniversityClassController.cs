using System;
using Microsoft.AspNetCore.Mvc;

using Glasgow123.Models;
using Glasgow123.MobileAppService.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Glasgow123.Controllers
{
    [Route("api/[controller]")]
    public class UniversityClassController : Controller
    {

        private readonly IModelRepository<UniversityClass> ClassRepository;
        private SQLItemContext _dbContext;

        public UniversityClassController(IModelRepository<UniversityClass> classRepository, SQLItemContext dbContext)
        {
            ClassRepository = classRepository;
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult List()
        {
            return Ok(ClassRepository.GetAll());
        }

        [HttpGet("enrolled")]
        public IActionResult Enrolled(int id)
        {
            var result = _dbContext.UniversityClasses
                .Where(p => p.PersonClasses.Any(c => c.PersonId == id)) // Filter by student id
                .Include(uniClass => uniClass.Lecturer)
                .Include(uniClass => uniClass.PersonClasses)
                    .ThenInclude(personClasses => personClasses.Person);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public UniversityClass GetItem(int id)
        {
            UniversityClass item = ClassRepository.Get(id);
            return item;
        }

        [HttpPost]
        public IActionResult Create([FromBody]UniversityClass item)
        {
            try
            {
                if (item == null || !ModelState.IsValid)
                {
                    return BadRequest("Invalid State");
                }

                ClassRepository.Add(item);

            }
            catch (Exception)
            {
                return BadRequest("Error while creating");
            }
            return Ok(item);
        }

        [HttpPut]
        public IActionResult Edit([FromBody] UniversityClass item)
        {
            try
            {
                if (item == null || !ModelState.IsValid)
                {
                    return BadRequest("Invalid State");
                }
                ClassRepository.Update(item);
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
            ClassRepository.Remove(id);
        }
    }
}
