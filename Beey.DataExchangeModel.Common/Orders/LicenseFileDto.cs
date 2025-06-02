namespace Beey.DataExchangeModel.Common.Orders
{
    public record LicenseFileDto(
        bool? IsActive,
        string? LicenseFileBase64,
        DateTimeOffset? LicenseGeneratedAt,
        DateTimeOffset? LicenseDeactivatedAt
    );
}
