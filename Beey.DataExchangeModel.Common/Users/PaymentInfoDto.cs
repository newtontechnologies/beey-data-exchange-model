using Beey.DataExchangeModel.Auth;
using Beey.DataExchangeModel.Serialization;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Beey.DataExchangeModel.Users;

public class PaymentInfoAddDto
{
    public string Email { get; set; } = default!;
    public string? PhoneNumber { get; set; }
    public string? FirstName { get; set; } = default!;
    public string? LastName { get; set; } = default!;
    public string? Company { get; set; }
    /// <summary>
    /// DIČ
    /// </summary>
    public string? TaxIdentificationNumber { get; set; }
    /// <summary>
    /// IČO
    /// </summary>
    public string? CompanyIdentificationNumber { get; set; }
    //public string VATIdentificationNumber { get; set; } //in USA TAX and VAT ids are different

    public string? Address { get; set; } = default!;
    public string? AddressComplement { get; set; }
    public string? PostalCode { get; set; } = default!;
    public string? City { get; set; } = default!;
    public string Country { get; set; } = default!;
    public string CountryCode { get; set; } = default!;
    public string? StateOrRegion { get; set; }

    public bool ReverseCharge { get; set; }
}
public class PaymentInfoDto : PaymentInfoAddDto
{
    public int Id { get; set; }
    public DateTimeOffset? Created { get; set; }
    public DateTimeOffset? Updated { get; set; }
    public int UserId { get; set; }
}
