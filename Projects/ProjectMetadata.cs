using Beey.DataExchangeModel.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Beey.DataExchangeModel.Projects
{
    public class ProjectMetadata : EntityBase
    {
        [JsonIgnoreWebDeserialize]
        public int ProjectId { get; set; }
        [JsonIgnoreWebDeserialize]
        public string Key { get; set; }
        [JsonIgnoreWebDeserialize]
        public string Value { get; set; }
    }
}
