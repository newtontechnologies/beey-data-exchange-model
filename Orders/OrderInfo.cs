using Beey.DataExchangeModel;
using Beey.DataExchangeModel.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beey.DataExchangeModel.Orders
{
    public enum PaymentStatus { None, Failed, Successful }

    public class OrderInfo : EntityBase
    {
        public OrderInfo() { }
        public OrderInfo(int userId, ulong orderNumber, uint credit, decimal amount, string currency, CultureInfo culture, PaymentInfo paymentInfo)
        {
            UserId = userId;
            OrderNumber = orderNumber;
            Credit = credit;
            Amount = amount;
            Currency = currency;
            Culture = culture;

            Email = paymentInfo.Email;
            PhoneNumber = paymentInfo.PhoneNumber;

            FirstName = paymentInfo.FirstName;
            LastName = paymentInfo.LastName;

            Company = paymentInfo.Company;
            TaxIdentificationNumber = paymentInfo.TaxIdentificationNumber;
            CompanyIdentificationNumber = paymentInfo.CompanyIdentificationNumber;

            Address = paymentInfo.Address;
            AddressComplement = paymentInfo.AddressComplement;
            PostalCode = paymentInfo.PostalCode;
            City = paymentInfo.City;
            Country = paymentInfo.Country;
            CountryCode = paymentInfo.CountryCode;
            StateOrRegion = paymentInfo.StateOrRegion;

            ReverseCharge = paymentInfo.ReverseCharge;
        }

        public int UserId { get; set; }
        public ulong OrderNumber { get; set; }
        public uint Credit { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public string Language { get; set; }
        [NotMapped]
        public CultureInfo Culture { get => new CultureInfo(Language); set => Language = value.Name; }

        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public PaymentStatus PaymentStatus { get; set; } = PaymentStatus.None;
        public string PaymentPrCode { get; set; }
        public string PaymentSrCode { get; set; }
        public string PaymentResultText { get; set; }
        public bool InfoMailSent { get; set; }
        public bool ResultMailSent { get; set; }
        public bool CreditAdded { get; set; }
        public bool InvoiceMailSent { get; set; }

        // Copy of properties from PaymentInfo to save actual data for order.
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Company { get; set; }
        public string TaxIdentificationNumber { get; set; }//DIČ
        public string CompanyIdentificationNumber { get; set; }//IČ

        public string Address { get; set; }
        public string AddressComplement { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string CountryCode { get; set; }
        public string StateOrRegion { get; set; }
        public bool ReverseCharge { get; set; }
    }
}
