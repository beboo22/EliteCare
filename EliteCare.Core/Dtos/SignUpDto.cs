using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteCare.Core.Dtos
{
    public class SignUpDto
    {
        [EmailAddress]
        public string Email { get; set; }
        public string UserName { get; set; }


        public string Password { get; set; }
        [Compare(nameof(Password))]
        public string ConfimePassword { get; set; }

    }
}
