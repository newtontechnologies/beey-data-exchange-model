using Beey.DataExchangeModel.Tools;
using System;
using System.ComponentModel.DataAnnotations;

namespace Beey.DataExchangeModel.Auth
{
    public class UserAddModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public UserRole UserRole { get; set; }
        [Obsolete("For backwards compatibility only. Is part of workspaces now.")]
        public Undefinable<int> CreditMinutes { get; set; }        
        public Undefinable<string> Language { get; set; }        
        public Undefinable<int> WorkspaceId { get; set; }
    }
}
