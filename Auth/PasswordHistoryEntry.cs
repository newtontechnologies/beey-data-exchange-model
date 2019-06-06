using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#pragma warning disable nullable
namespace BeeyApi.POCO.Auth
{
    public partial class PasswordHistoryEntry : EntityBase
    {
        [JsonIgnore]
        public byte[] PasswordSalt { get; set; }
        [JsonIgnore]
        public string PasswordHash { get; set; }

        [JsonIgnore]
        public int UserId { get; set; }
        [JsonIgnore]
        public User User { get; set; }

        [JsonIgnore]
        public int PasswordHashingVersion { get; set; }
    }
}
