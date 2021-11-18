using System;
using System.Collections.Generic;

#nullable disable

namespace DbFirst.Entities
{
    public partial class Order
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? MovieId { get; set; }
        public int? MoviePrice { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public string Trial782 { get; set; }

        public virtual Movie Movie { get; set; }
        public virtual User User { get; set; }
    }
}
