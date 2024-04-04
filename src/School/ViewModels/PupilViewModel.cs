using School.Enums;

namespace School.ViewModels
{
    public class PupilViewModel
    {
        public int PupilId { get; set; }
        public string TeacherFullName { get; set; }
        public string RoomName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Class { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
    }
}
