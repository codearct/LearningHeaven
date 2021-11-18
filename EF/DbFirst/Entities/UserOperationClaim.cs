using System;
using System.Collections.Generic;

#nullable disable

namespace DbFirst.Entities
{
    public partial class UserOperationClaim
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }
    }
}
