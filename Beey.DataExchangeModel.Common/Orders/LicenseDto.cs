namespace Beey.DataExchangeModel.Common.Orders
{
    public record LicenseDto(
        string? Name,
        DateTimeOffset TermStartDate,
        DateTimeOffset TermEndDate,
        string Email,
        int TeamId,
        string? Description,
        bool IsActive,
        uint Quantity,
        string PlanKey,
        string? Interval,
        long IntervalCount,
        string? SubscriptionKey,
        string? SubscriptionItemKey,
        int? SubscriptionId,
        string? ComponentsJson
    );

}
