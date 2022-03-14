using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shared.ResponseModels
{
    public class ServiceResponse<TData> : BaseResponse
    {
        public TData Value { get; set; }
    }
}