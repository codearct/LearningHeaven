using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MealOrdering.Shared.DTO;

namespace Shared.DTO
{
    public class UserLoginResponseDTO
    {
        public string ApiToken { get; set; }

        public UserDTO User { get; set; }

    }
}