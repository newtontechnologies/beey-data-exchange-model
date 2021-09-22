using Beey.DataExchangeModel.Tools;
using Newtonsoft.Json.Linq;
using System;

namespace Beey.DataExchangeModel.Auth
{
    public class UserUpdateModel
    {
        public int Id { get; set; }
        [Obsolete("For backwards compatibility only. Is part of workspaces now.")]
        public Undefinable<int> CreditMinutes { get; set; }
        public Undefinable<string> Email { get; set; }
        public Undefinable<string> Language { get; set; }
        public Undefinable<JObject> Settings { get; set; }
        public Undefinable<UserRole> UserRole { get; set; }
        public Undefinable<string> Password { get; set; }
    }
}
