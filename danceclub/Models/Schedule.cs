namespace danceclub.Models
{
    public class Schedule
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public DateTime Duration { get; set; }
        public int TeacherId { get; set; }
        public int DanceTypeId { get; set; }
        public Teacher Teacher { get; set; }
        public DanceType DanceType { get; set; }
        public ICollection<StudentSchedule> StudentSchedules { get; set; }
    }
}
