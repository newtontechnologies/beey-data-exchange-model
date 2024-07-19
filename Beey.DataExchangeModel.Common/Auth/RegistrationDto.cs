using System.Text.Json.Nodes; 
using Beey.DataExchangeModel.Common.Attributes;

namespace Beey.DataExchangeModel.Auth;

public class RegistrationDto
{
    [EmailAddressCustom]
    public string Email { get; set; }
    public string Password { get; set; }
    public string Language { get; set; }
    public JsonObject? Settings { get; set; }
}
