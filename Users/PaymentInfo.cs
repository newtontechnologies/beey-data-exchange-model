using Beey.DataExchangeModel.Auth;
using Beey.DataExchangeModel.Serialization;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Beey.DataExchangeModel.Users
{
    public class PaymentInfo : EntityBase
    {
        [JsonIgnoreWebDeserialize]
        public int UserId { get; set; }

        [JsonIgnoreWeb]
        public User User { get; set; }

        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Company { get; set; }
        /// <summary>
        /// DIČ
        /// </summary>
        public string TaxIdentificationNumber { get; set; }
        /// <summary>
        /// IČO
        /// </summary>
        public string CompanyIdentificationNumber { get; set; }
        //public string VATIdentificationNumber { get; set; } //in USA TAX and VAT ids are different


        public string Address { get; set; }
        public string AddressComplement { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string StateOrRegion { get; set; }

        public bool ReverseCharge { get; set; }
    }
}
