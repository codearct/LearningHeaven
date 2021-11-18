using System;
using System.Collections.Generic;

#nullable disable

namespace DbFirst.Entities
{
    public partial class Movie
    {
        public Movie()
        {
            MoviePerformers = new HashSet<MoviePerformer>();
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public int? GenreId { get; set; }
        public int? DirectorId { get; set; }
        public int? Price { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public bool IsActive { get; set; }
        public string Trial782 { get; set; }

        public virtual Director Director { get; set; }
        public virtual Genre Genre { get; set; }
        public virtual ICollection<MoviePerformer> MoviePerformers { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
