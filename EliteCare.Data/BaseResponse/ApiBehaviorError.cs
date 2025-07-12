using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteCare.Service.BaseResponse
{
    internal class ApiBehaviorError : ApiResponse
    {
        public List<string>? Details { get; set; }


        public ApiBehaviorError(int Scode, List<string>? _details, string? msg = null) : base(Scode, msg)
        {
            Details = _details;
        }
    }
}
