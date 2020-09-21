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

    public class OrderInfo : EntityBase
    {
        public OrderInfo() { }
        public OrderInfo(int userId, ulong orderNumber, uint credit, decimal amount, string currency, CultureInfo language)
        {
            UserId = userId;
            OrderNumber = orderNumber;
            Credit = credit;
            Amount = amount;
            Currency = currency;
            Language = language;
        }

        public int UserId { get; set; }
        public ulong OrderNumber { get; set; }
        public uint Credit { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        [Column("Language")]
        public string _language { get; set; }
        [NotMapped]
        public CultureInfo Language { get => new CultureInfo(_language); set => _language = value.Name; }

        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public PaymentStatus PaymentStatus { get; set; } = PaymentStatus.None;
        public string PaymentPrCode { get; set; }
        public string PaymentSrCode { get; set; }
        public string PaymentResultText { get; set; }
        public bool InfoMailSent { get; set; }
        public bool ResultMailSent { get; set; }
        public bool CreditAdded { get; set; }
        public bool InvoiceMailSent { get; set; }
    }
}
