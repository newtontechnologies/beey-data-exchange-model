using Beey.DataExchangeModel.Tools;
using Newtonsoft.Json.Linq;
using System;

namespace Beey.DataExchangeModel.Auth
{
    public class UserEditModel
    {
        [Obsolete("For backwards compatibility only. Is part of workspaces now.")]
        public Undefinable<int> CreditMinutes { get; set; }
        public Undefinable<string> Email { get; set; }
        public Undefinable<int> Id { get; set; }
        public Undefinable<string> Language { get; set; }
        public Undefinable<JObject> Settings { get; set; }
        public Undefinable<UserRole> UserRole { get; set; }
        public Undefinable<string> Password { get; set; }
        public Undefinable<int> WorkspaceId { get; set; }
    }
}
