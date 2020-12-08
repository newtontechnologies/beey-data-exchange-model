using Beey.DataExchangeModel;
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

    public partial class OrderInfo : EntityBase
    {
        public OrderInfo() { }

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
        public string StateOrRegion { get; set; }
    }
}
