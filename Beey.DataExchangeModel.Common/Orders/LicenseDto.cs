namespace Beey.DataExchangeModel.Common.Orders
{
    public record LicenseDto(
        string Name,
        DateTimeOffset TermStartDate,
        DateTimeOffset TermEndDate,
        string Email,
        int TeamId,
        string? Description,
        bool IsActive,
        int Quantity,
        string? ComponentsJson,
        string? LicenseFileBase64,
        DateTimeOffset? LicenseGeneratedAt,
        int? SubscriptionId,
        string? SubscriptionKey
    );

}
