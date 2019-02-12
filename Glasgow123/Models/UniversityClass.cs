using Glasgow123.MobileAppService.Models;
using Glasgow123.MobileAppService.Models.Relationships;
using System.Collections.Generic;

namespace Glasgow123.Models
{
    public class UniversityClass
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Person Lecturer { get; set; }
        public ICollection<PersonClass> PersonClasses { get; set; }
    }
}
