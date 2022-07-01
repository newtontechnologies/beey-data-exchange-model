using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#pragma warning disable nullable
#pragma warning disable 8618
namespace Beey.DataExchangeModel.Auth;

public partial class LoginToken
{
    public string Token { get; set; }
    public UserViewModel User { get; set; }

    public string[] Claims { get; set; }
}
