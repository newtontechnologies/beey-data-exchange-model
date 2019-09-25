using Beey.DataExchangeModel.Serialization;
using Beey.DataExchangeModel.Projects;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

#pragma warning disable nullable
#pragma warning disable 8618,8601,8603
namespace Beey.DataExchangeModel.Auth
{
    public partial class User : EntityBase
    {
        public string Email { get; set; }
        [NotMapped]
        public string Password
        {
#if BeeyServer
            set
            {
                _PasswordSalt = null; //resalt with new pawssword
                PasswordHashingVersion = CurrentPasswordHashingVersion; //change version to currently used
                PasswordHash = CryptohashPassword(value);
            }
#else
            get; set;
#endif
        }

        [JsonIgnoreWeb]
        public string _settings { get; set; }
        [NotMapped]
        public JObject Settings { get => _settings == null ? null : JObject.Parse(_settings); set => _settings = value?.ToString(); }

        [JsonConverter(typeof(StringEnumConverter))]
        public UserRole UserRole { get; set; }

        [JsonIgnoreWebDeserialize]
        public decimal TranscribedMinutes { get; set; }
        public int CreditMinutes { get; set; }
    }
}

