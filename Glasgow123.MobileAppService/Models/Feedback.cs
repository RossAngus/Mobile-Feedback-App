using Glasgow123.Models;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Glasgow123.Models
{
    public class Feedback
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public Person Author { get; set; }
        public DateTime Date { get; set; }
        public int ToPersonId { get; set; }
        public Person ToPerson { get; set; }
        public int UniversityClassId { get; set; }
        public UniversityClass UniversityClass { get; set; }
        public string Comment { get; set; }
        public int Score { get; set; }
    }
}
