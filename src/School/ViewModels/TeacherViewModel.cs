using School.Enums;

namespace School.ViewModels
{
    public class TeacherViewModel
    {
        public int TeacherId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public Subject Subject { get; set; }
    }
}
