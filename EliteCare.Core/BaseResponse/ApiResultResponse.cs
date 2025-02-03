using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EliteCare.Core.BaseResponse
{
    public class ApiResultResponse<T> : ApiResponse
    {
        public T? Data { get; set; }
        public ApiResultResponse(int Scode, T? _data, string? msg = null) : base(Scode, msg)
        {
            Data = _data;
        }
    }
}
