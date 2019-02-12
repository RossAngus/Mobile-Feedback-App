using Glasgow123.MobileAppService.Models.Relationships;
using System;
using System.Collections.Generic;

namespace Glasgow123.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsTeacher { get; set; }
        public ICollection<UniversityClass> Teaches { get; set; } // Lecturer One-to-many relationship
        public ICollection<PersonClass> PersonClasses { get; set; } // Students Many-to-many relationship
        public ICollection<Feedback> FeedbackGiven { get; set; }
        public ICollection<Feedback> FeedbackReceived { get; set; }
    }
}