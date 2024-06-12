using Beey.DataExchangeModel.Auth;
using Beey.DataExchangeModel.Orders;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace Beey.DataExchangeModel.Users;

public class UserDetail
{
    public string Email { get; set; }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public UserRole UserRole { get; set; }
    public int Credit { get; set; }
    public PaymentInfoView PaymentInfo { get; set; }
    public List<CreditChangeHistoryEntryView> CreditChangeHistory { get; set; }
    public List<OrderInfoView> OrderHistory { get; set; }
    public List<ProjectView> Projects { get; set; }
    public List<MetadataView> Metadata { get; set; }

    public class PaymentInfoView
    {
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string TaxIdentificationNumber { get; set; }
        public string CompanyIdentificationNumber { get; set; }
        public string Address { get; set; }
        public string AddressComplement { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string StateOrRegion { get; set; }
    }
    public class CreditChangeHistoryEntryView
    {
        public int Credit { get; set; }
        public int TeamId { get; set; }
        public int InitiatorId { get; set; }
        public int? OrderInfoId { get; set; }
    }
    public class ProjectView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset Updated { get; set; }
        public DateTimeOffset? Start { get; set; }
        public TimeSpan Length { get; set; }
        public int ShareCount { get; set; }
        public JsonArray Tags { get; set; }
    }
    public class OrderInfoView
    {
        public int Id { get; set; }
        public ulong OrderNumber { get; set; }
        public uint Credit { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public uint Quantity { get; set; }
        public string ProductName { get; set; }

        public string Language { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public PaymentStatus PaymentStatus { get; set; } = PaymentStatus.None;
    }

    public class MetadataView
    {
        public string Key { get; set; }
        public JsonNode? Value { get; set; }
    }
}
