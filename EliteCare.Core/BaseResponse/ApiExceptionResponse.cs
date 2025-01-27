using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteCare.Core.BaseResponse
{
    internal class ApiExceptionResponse : ApiResponse
    {
        public string? Details { get; set; }


        public ApiExceptionResponse(int Scode, string? _details = null, string? msg = null) : base(Scode, msg)
        {
            Details = _details;
        }
    }
}
