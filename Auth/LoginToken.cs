using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#pragma warning disable nullable
namespace BeeyApi.POCO.Auth
{
    public partial class LoginToken
    {
        public string Token { get; set; }
        public User User { get; set; }

        public string[] Claims { get; set; }
    }
}
