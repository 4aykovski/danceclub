namespace danceclub.Models
{
    public class StudentSchedule
    {
        public int StudentId { get; set; }
        public int ScheduleId { get; set; }
        public Students Students { get; set; }
        public Schedule Schedules { get; set; }
    }
}
