using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace Beey.DataExchangeModel.Auth;

public class LoginToken
{
    public string Token { get; set; }
    public UserDto User { get; set; }

    public string[] Claims { get; set; }
}
