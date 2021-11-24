using Beey.DataExchangeModel.Serialization;
using Beey.DataExchangeModel.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#pragma warning disable nullable
#pragma warning disable 8618
namespace Beey.DataExchangeModel.Projects
{
    /// <summary>
    /// Each transcription have to be logged here
    /// Will be used for computing total transcription time
    /// length and settings have to be duplicated .. projects can be deleted
    /// </summary>
    public partial class TranscriptionLogItem : EntityBase
    {
        [JsonIgnoreWebDeserialize]
        public int TeamId { get; set; }
        [JsonIgnoreWebDeserialize]
        public int UserId { get; set; }
        [JsonIgnoreWebDeserialize]
        public string Filename { get; set; }
        [JsonIgnoreWebDeserialize]
        public int ProjectId { get; set; }
        [JsonIgnoreWebDeserialize]
        public string ProjectName { get; set; }
        [JsonIgnoreWebDeserialize]
        public decimal TranscribedMinutes { get; set; }
        [JsonIgnoreWebDeserialize]
        public string TranscriptionSettings { get; set; }
    }
}
