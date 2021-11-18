using System;
using System.Collections.Generic;

#nullable disable

namespace DbFirst.Entities
{
    public partial class Genre
    {
        public Genre()
        {
            Movies = new HashSet<Movie>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Trial782 { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}
