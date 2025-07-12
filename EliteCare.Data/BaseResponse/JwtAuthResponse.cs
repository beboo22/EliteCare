using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteCare.Service.BaseResponse
{
    public class JwtAuthResponse : ApiResponse
    {
        public string Token { get; set; }
        public JwtAuthResponse(int Scode, string _data, string? msg = null) : base(Scode, msg)
        {
            Token = _data;
        }
    }
}
