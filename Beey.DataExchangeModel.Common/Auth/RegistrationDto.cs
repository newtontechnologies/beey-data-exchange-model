using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace Beey.DataExchangeModel.Auth;

public class RegistrationDto
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string Language { get; set; }
    public JsonObject? Settings { get; set; }
}
