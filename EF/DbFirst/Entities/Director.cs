using System;
using System.Collections.Generic;

#nullable disable

namespace DbFirst.Entities
{
    public partial class Director
    {
        public Director()
        {
            Movies = new HashSet<Movie>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Trial782 { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}
