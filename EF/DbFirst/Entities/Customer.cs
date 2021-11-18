using System;
using System.Collections.Generic;

#nullable disable

namespace DbFirst.Entities
{
    public partial class Customer
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
