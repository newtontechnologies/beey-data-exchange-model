namespace Beey.DataExchangeModel.Common.Orders
{
    public record LicenseFileDto(
        bool? IsActive,
        string? Product,
        string? LicenseFileBase64,
        DateTimeOffset? LicenseGeneratedAt,
        DateTimeOffset? LicenseDeactivatedAt
    );
}
