using School.Enums;
using System;

namespace School.Models
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public Subject Subject { get; set; }
        public int Salary { get; set; }
        public string Address { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
