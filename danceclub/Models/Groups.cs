namespace danceclub.Models
{
    public class Groups
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<GroupDanceType> DanceTypes { get; set; }
        public ICollection<GroupStudent> GroupStudents { get; set; }

    }
}
