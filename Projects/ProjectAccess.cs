using Backend.Serialization;
using BeeyApi.POCO.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#pragma warning disable nullable
namespace BeeyApi.POCO.Projects
{
    public partial class ProjectAccess : EntityBase
    {
        [JsonIgnoreWebDeserialize]
        public int UserId { get; set; }
        [JsonIgnoreWebDeserialize]
        public User User { get; set; }
        [JsonIgnoreWebDeserialize]
        public int ProjectId { get; set; }
        [JsonIgnoreWebDeserialize]
        public Project Project { get; set; }

        public string CustomPath { get; set; }

    }
}
