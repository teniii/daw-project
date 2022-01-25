using System.Collections.Generic;
using System;

namespace ProjectAPI.Models
{
    public class Movie
    {
        public int id { get; set; }
        public string title { get; set; }

        public DateTime release_date { get; set; }

        public List<User> Users { get; private set; } = new List<User>();

        public List<Participant> Participants { get; private set; } = new List<Participant>();
    }
}