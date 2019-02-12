using Glasgow123.MobileAppService.Models;
using Glasgow123.MobileAppService.Models.Relationships;
using Glasgow123.MobileAppService.Models.Repositories;
using Glasgow123.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Glasgow123.MobileAppService.Engine
{
    public class MockDataGenerator
    {
        public static void AddData(IModelRepository<Feedback> feedbackRepository, SQLItemContext dbContext)
        {
            // Create students
            var students = new List<Person>
            {
                new Person { Name = "Abraham", Surname="Lincoln", Email = "hello@glasgow.co.uk", Password="Test123", IsTeacher=false },
                new Person { Name = "Helen", Surname="Keller", Email = "hello2@glasgow.co.uk", Password="Test123", IsTeacher=false },
                new Person { Name = "David", Surname="Beckham", Email = "hello3@glasgow.co.uk", Password="Test123", IsTeacher=false },
                new Person { Name = "Maria", Surname="Sharapova", Email = "hello4@glasgow.co.uk", Password="Test123", IsTeacher=false },
                new Person { Name = "Pablo", Surname="Picasso", Email = "hello5@glasgow.co.uk", Password="Test123", IsTeacher=false },
                new Person { Name = "Mariah", Surname="Carey", Email = "hello6@glasgow.co.uk", Password="Test123", IsTeacher=false },
            };

            // Create Lecturers
            var lecturer = new Person { Name = "Alan", Surname = "Parson", Email = "alan@glasgow.co.uk", Password = "Test123", IsTeacher = true };

            // Create classes

            var classes = new List<UniversityClass>
            {
                new UniversityClass { Title = "Youth, Policy and Welfare: Cross-Cultural Perspectives", Description="Semester 1", Lecturer=lecturer },
                new UniversityClass { Title = "Social & Public Policy 1A", Description="Semester 1", Lecturer=lecturer },
                new UniversityClass { Title = "Social and Public Policy 2B: Policy, Politics and Power", Description="Semester 1", Lecturer=lecturer },
                new UniversityClass { Title = "Health Policy", Description="Semester 2", Lecturer=lecturer },
                new UniversityClass { Title = "Social and Public Policy 1B: Understanding Glasgow in a Globalised World", Description="Semester 2", Lecturer=lecturer },
                new UniversityClass { Title = "Utopias: Welfare Theory and Social Policies for a \"Good Society\" ", Description="Semester 2", Lecturer=lecturer },
            };

            // Create Relationship Student-Classes

            var studentClasses = new List<PersonClass>
            {
                new PersonClass { Person = students[0], UniversityClass = classes[0] },
                new PersonClass { Person = students[1], UniversityClass = classes[0] },
                new PersonClass { Person = students[2], UniversityClass = classes[1] },
                new PersonClass { Person = students[3], UniversityClass = classes[1] },
                new PersonClass { Person = students[1], UniversityClass = classes[2] },
                new PersonClass { Person = students[3], UniversityClass = classes[3] },
                new PersonClass { Person = students[4], UniversityClass = classes[4] },
                new PersonClass { Person = students[5], UniversityClass = classes[5] },
            };

            // Create Feedback
            
            var feedbackList = new List<Feedback>
            {
                new Feedback { Author = students[0], Date = new DateTime(2019, 01, 20), ToPerson = lecturer, UniversityClass = classes[0], Comment = "A little boring for my taste.", Score=3 },
                new Feedback { Author = lecturer, Date = new DateTime(2019, 01, 20), ToPerson = students[0], UniversityClass = classes[0], Comment = "You weren't paying attention!", Score=3 },
                new Feedback { Author = students[1], Date = new DateTime(2019, 01, 20), ToPerson = students[0], UniversityClass = classes[0], Comment = "He talks to much!", Score=3 }
            };

            // Store that

            dbContext.AddRange(studentClasses);
            dbContext.AddRange(feedbackList);
            dbContext.SaveChanges();
        }
    }
}
