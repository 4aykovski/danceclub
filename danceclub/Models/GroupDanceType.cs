namespace danceclub.Models
{
    public class GroupDanceType
    {
        public int DanceTypeId { get; set; }
        public int GroupId { get; set; }
        public DanceType DanceType { get; set; }
        public Groups Group { get; set; }
    }
}
