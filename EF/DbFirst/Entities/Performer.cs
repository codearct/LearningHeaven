using System;
using System.Collections.Generic;

#nullable disable

namespace DbFirst.Entities
{
    public partial class Performer
    {
        public Performer()
        {
            MoviePerformers = new HashSet<MoviePerformer>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Trial782 { get; set; }

        public virtual ICollection<MoviePerformer> MoviePerformers { get; set; }
    }
}
