using System;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace Beey.DataExchangeModel.Auth;

public class UserViewModel
{
    public bool CommercialCommunicationConsent { get; set; }
    public DateTimeOffset? Created { get; set; }
    public int CreditMinutes { get; set; }
    public bool DataProtectionConsent { get; set; }
    public bool DidPay { get; set; }
    public string? Email { get; set; }
    public int Id { get; set; }
    public string? Language { get; set; }
    public JsonObject? Settings { get; set; }
    public decimal TranscribedMinutes { get; set; }
    public decimal UserTranscribedMinutes { get; set; }
    public DateTimeOffset? Updated { get; set; }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public UserRole UserRole { get; set; }
    public int TeamId { get; set; }
    public bool IsTeamOwner { get; set; }
}
