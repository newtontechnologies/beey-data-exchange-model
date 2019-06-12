using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#pragma warning disable nullable
namespace Beey.DataExchangeModel.Auth
{
    public partial class LoginData
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
