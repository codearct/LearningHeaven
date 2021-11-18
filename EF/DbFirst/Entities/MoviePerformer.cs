using System;
using System.Collections.Generic;

#nullable disable

namespace DbFirst.Entities
{
    public partial class MoviePerformer
    {
        public int MovieId { get; set; }
        public int PerformerId { get; set; }
        public string Trial782 { get; set; }

        public virtual Movie Movie { get; set; }
        public virtual Performer Performer { get; set; }
    }
}
