namespace danceclub.Models
{
    public class DanceType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<GroupDanceType> GroupDanceTypes { get; set; }
        public ICollection<Schedule> Schedule { get; set; }
    }
}
