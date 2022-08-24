using Beey.DataExchangeModel.Tools;
using System;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace Beey.DataExchangeModel.Auth;

public class UserUpdateModel
{
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
    public int Id { get; set; }
    [Obsolete("For backwards compatibility only. Is part of teams now.")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Undefinable<int> CreditMinutes { get; set; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Undefinable<string> Email { get; set; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Undefinable<string> Language { get; set; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Undefinable<JsonObject> Settings { get; set; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Undefinable<UserRole> UserRole { get; set; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Undefinable<string> Password { get; set; }
}
