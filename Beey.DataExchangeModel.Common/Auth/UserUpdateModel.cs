using Beey.DataExchangeModel.Tools;
using System;
using System.Text.Json.Nodes;

namespace Beey.DataExchangeModel.Auth;

public class UserUpdateModel
{
    public int Id { get; set; }
    [Obsolete("For backwards compatibility only. Is part of teams now.")]
    public Undefinable<int> CreditMinutes { get; set; }
    public Undefinable<string> Email { get; set; }
    public Undefinable<string> Language { get; set; }
    public Undefinable<JsonObject> Settings { get; set; }
    public Undefinable<UserRole> UserRole { get; set; }
    public Undefinable<string> Password { get; set; }
}
