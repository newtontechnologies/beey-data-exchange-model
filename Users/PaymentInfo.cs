using Beey.DataExchangeModel.Auth;
using Beey.DataExchangeModel.Serialization;
using System.Collections.Generic;
using System.Text.RegularExpressions;

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
        public string TaxIdentificationNumber { get; set; }//DIČ
        public string CompanyIdentificationNumber { get; set; }//IČ
        //public string VATIdentificationNumber { get; set; } //in USA TAX and VAT ids are different


        public string Address { get; set; }
        public string AddressComplement { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string StateOrRegion { get; set; }


        static readonly Regex emailRegex = new Regex(@"([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})", RegexOptions.Compiled);
        public string Validate()
        {
            var errors = new List<string>();
            ValidateRequiredFields(errors);
            ValidateOptionalFields(errors);

            if (errors.Count == 0)
                return null;
            else
                return string.Join("; ", errors);
        }

        private void ValidateRequiredFields(List<string> errors)
        {
            if (string.IsNullOrWhiteSpace(FirstName) || string.IsNullOrWhiteSpace(LastName))
                errors.Add($"Name is empty");

            if (string.IsNullOrWhiteSpace(Country))
                errors.Add($"{nameof(Country)} is empty");

            if (string.IsNullOrWhiteSpace(Email))
                errors.Add($"{nameof(Email)} is empty");
            else if (!emailRegex.IsMatch(Email))
                errors.Add($"{nameof(Email)} is not valid");

            if (string.IsNullOrWhiteSpace(Address))
                errors.Add($"{nameof(Address)} is empty");

            if (string.IsNullOrWhiteSpace(City))
                errors.Add($"{nameof(City)} is empty");

            if (string.IsNullOrWhiteSpace(PostalCode))
                errors.Add($"{nameof(PostalCode)} is empty");
        }

        private void ValidateOptionalFields(List<string> errors)
        {
            // TODO: Add validation for optional fields if any.
        }
    }
}
