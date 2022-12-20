using Beey.DataExchangeModel.Common.Users;
using Beey.DataExchangeModel.Tools;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace Beey.DataExchangeModel.Auth;

public class UserAddModel
{
    [Required]
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
    public List<UserMetadataAddModel>? Metadata { get; set; }

}
