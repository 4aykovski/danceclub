namespace danceclub.Models
{
    public class Students
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public ICollection<GroupStudent> GroupsStudents { get; set; }
        public ICollection<StudentSchedule> StudentSchedules { get; set; }
    }
}
