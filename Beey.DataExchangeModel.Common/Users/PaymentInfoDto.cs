using ObjectGraphValidation;
using System.ComponentModel.DataAnnotations;
using Beey.DataExchangeModel.Common.Attributes;

namespace Beey.DataExchangeModel.Users;

public class PaymentInfoAddDto
{
    [EmailAddressCustom]
    [Required]
    [MaxLength(100)]
    public string? Email { get; set; } = default!;
    [PhoneCustom]
    [MaxLength(100)]
    public string? PhoneNumber { get; set; }
    [MaxLength(100)]
    public string? FirstName { get; set; } = default!;
    [MaxLength(100)]
    public string? LastName { get; set; } = default!;
    [MaxLength(100)]
    public string? Company { get; set; }
    /// <summary>
    /// DIČ
    /// </summary>
    public string? TaxIdentificationNumber { get; set; }
    /// <summary>
    /// IČO
    /// </summary>
    [MaxLength(20)]
    public string? CompanyIdentificationNumber { get; set; }

    //public string VATIdentificationNumber { get; set; } //in USA TAX and VAT ids are different
    [MaxLength(1000)]
    public string? Address { get; set; } = default!;
    [MaxLength(1000)]
    public string? AddressComplement { get; set; }
    [MaxLength(10)]
    public string? PostalCode { get; set; } = default!;
    [MaxLength(1000)]
    public string? City { get; set; } = default!;
    [Required]
    [MaxLength(1000)]
    public string? Country { get; set; } = default!;
    [Required]
    [MaxLength(5)]
    public string? CountryCode { get; set; } = default!;
    [MaxLength(1000)]
    public string? StateOrRegion { get; set; }

    public bool ReverseCharge { get; set; }
}
public class PaymentInfoDto : PaymentInfoAddDto
{
    public PaymentInfoDto()
    {
    }

    public PaymentInfoDto(int userId, string? address, string? addressComplement, string? city, string? company, string? companyIdentificationNumber, string? country, string? countryCode, DateTimeOffset? created, string? email, string? firstName, int id, string? lastName, string? phoneNumber, string? postalCode, bool reverseCharge, string? stateOrRegion, string? taxIdentificationNumber, DateTimeOffset? updated)
    {
        UserId = userId;
        Address = address;
        AddressComplement = addressComplement;
        City = city;
        Company = company;
        CompanyIdentificationNumber = companyIdentificationNumber;
        Country = country;
        CountryCode = countryCode;
        Created = created;
        Email = email;
        FirstName = firstName;
        Id = id;
        LastName = lastName;
        PhoneNumber = phoneNumber;
        PostalCode = postalCode;
        ReverseCharge = reverseCharge;
        StateOrRegion = stateOrRegion;
        TaxIdentificationNumber = taxIdentificationNumber;
        Updated = updated;
    }

    public int Id { get; set; }
    public DateTimeOffset? Created { get; set; }
    public DateTimeOffset? Updated { get; set; }
    public int UserId { get; set; }
}
