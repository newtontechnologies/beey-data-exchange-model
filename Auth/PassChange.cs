using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeeyApi.POCO.Auth
{
    public partial class PassChange
    {
        public string Password { get; set; }
        public string NewPassword { get; set; }
    }
}
