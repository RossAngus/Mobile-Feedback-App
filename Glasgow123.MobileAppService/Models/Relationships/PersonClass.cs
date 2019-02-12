using Glasgow123.Models;

namespace Glasgow123.MobileAppService.Models.Relationships
{
    public class PersonClass
    {
        public int PersonId { get; set; }
        public Person Person { get; set; }
        public int UniversityClassId { get; set; }
        public UniversityClass UniversityClass { get; set; }
    }
}
