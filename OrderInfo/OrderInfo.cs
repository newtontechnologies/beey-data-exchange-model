using Beey.DataExchangeModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beey.DataExchangeModel.Orders
{
    public enum PaymentStatus { None, Failed, Successful }

    public class OrderInfo : EntityBase
    {
        public OrderInfo() { }
        public OrderInfo(int userId, ulong orderNumber, uint credit, decimal amount, string currency)
        {
            UserId = userId;
            OrderNumber = orderNumber;
            Credit = credit;
            Amount = amount;
            Currency = currency;
        }

        public int UserId { get; set; }
        public ulong OrderNumber { get; set; }
        public uint Credit { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }

        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public PaymentStatus PaymentStatus { get; set; } = PaymentStatus.None;
        public string PaymentPrCode { get; set; }
        public string PaymentSrCode { get; set; }
        public string PaymentResultText { get; set; }
        public bool InfoMailSent { get; set; }
        public bool ResultMailSent { get; set; }
        public bool CreditAdded { get; set; }
    }
}
