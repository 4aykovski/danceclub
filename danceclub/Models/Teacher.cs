﻿namespace danceclub.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone {  get; set; }
        public string Email { get; set; }
        public ICollection<Schedule> Schedules { get; set; }
    }
}
