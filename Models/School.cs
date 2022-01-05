using System.Collections.Generic;

namespace ProjectAPI.Models
{
    public class School
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<Student> Students { get; private set; } = new List<Student>();
    }
}