﻿namespace BookstoreApplication.Models
{
    public class Award
    {
      
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int StartYear { get; set; }

        public ICollection<AwardAuthor> AwardAuthors { get; set; }
    }
}
