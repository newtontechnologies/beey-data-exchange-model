﻿using Beey.DataExchangeModel;
using Beey.DataExchangeModel.Users;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Beey.DataExchangeModel.Orders;

public enum PaymentStatus { None, Failed, Successful }

public class OrderInfoDto
{
    public OrderInfoDto() { }

    public DateTimeOffset? Created { get; set; }
    public int UserId { get; set; }
    public ulong OrderNumber { get; set; }
    public uint Credit { get; set; }
    public decimal Amount { get; set; }
    public uint Quantity { get; set; }
    public string? Currency { get; set; }
    public string ProductName { get; set; }
    public string? Language { get; set; }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public PaymentStatus PaymentStatus { get; set; } = PaymentStatus.None;
    public string? PaymentPrCode { get; set; }
    public string? PaymentSrCode { get; set; }
    public string? PaymentResultText { get; set; }

    public string? StripeCheckoutId { get; set; }
    public string? StripeInvoiceId { get; set; }
    public bool InfoMailSent { get; set; }
    public bool ResultMailSent { get; set; }
    public bool CreditAdded { get; set; }
    public bool InvoiceMailSent { get; set; }

    // Copy of properties from PaymentInfo to save actual data for order.
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    [Obsolete]
    public string? FirstName { get; set; }
    [Obsolete]
    public string? LastName { get; set; }
    [Obsolete]
    public string? Company { get; set; }

    public string? Name { get; set; }
    public string? TaxIdentificationNumber { get; set; }//DIČ
    public string? CompanyIdentificationNumber { get; set; }//IČ

    public string? Address { get; set; }
    public string? AddressComplement { get; set; }
    public string? PostalCode { get; set; }
    public string? City { get; set; }
    public string? Country { get; set; }
    public string? CountryCode { get; set; }
    public string? StateOrRegion { get; set; }
    public bool ReverseCharge { get; set; }
}
