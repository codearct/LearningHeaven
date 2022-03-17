using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Services
{
    public interface IValidationService
    {
        public bool IsAdmin(Guid UserId);

        public bool HasPermissionToChange(Guid UserId);

        public bool HasPermission(Guid UserId);
    }
}