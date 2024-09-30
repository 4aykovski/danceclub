namespace danceclub.Models
{
    public class GroupStudent
    {
        public int StudentId { get; set; }
        public int GroupId { get; set; }
        public Groups Groups { get; set; }
        public Students   Students { get; set; }
    }
}
