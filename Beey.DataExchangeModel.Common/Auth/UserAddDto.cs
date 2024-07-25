using Beey.DataExchangeModel.Tools;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization; 
using Beey.DataExchangeModel.Common.Attributes;

namespace Beey.DataExchangeModel.Auth;

public class UserAddDto: BaseDto
{
    [Required]
    [EmailAddressCustom]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
    public UserRole UserRole { get; set; }
    [Obsolete("For backwards compatibility only. Is part of teams now.")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Undefinable<int> CreditMinutes { get; set; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Undefinable<string> Language { get; set; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Undefinable<int> TeamId { get; set; }
    public JsonObject? Settings { get; set; }
}
