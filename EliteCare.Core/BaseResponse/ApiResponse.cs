using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteCare.Core.BaseResponse
{
    public class ApiResponse
    {
        public int statusCode { get; set; }
        public string message { get; set; }


        public ApiResponse(int Scode, String? msg = null)
        {
            statusCode = Scode;
            message = msg ?? GetmasgForScode(Scode);

        }

        private string? GetmasgForScode(int scode)
        {
            return statusCode switch
            {
                200 => "Successful Operation",
                400 => "BadRequest",
                401 => "UnAuthrize",
                404 => "notfound",
                500 => "server Error",
                _ => null

            };
        }
    }
}
