using Backend.Serialization;
using BeeyApi.POCO.Projects;
#if Backend
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
#endif
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
namespace BeeyApi.POCO.Auth
{
    public partial class User : EntityBase
    {
        public string Email { get; set; }
        [NotMapped]
        public string Password
        {
#if Backend
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
        public int? TranscribedMinutes { get; set; }
        public int CreditMinutes { get; set; }
    }
}

