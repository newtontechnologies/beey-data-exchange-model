using BeeyApi.POCO.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeeyApi.POCO.Projects
{
    /// <summary>
    /// Each transcription have to be logged here
    /// Will be used for computing total transcription time
    /// length and settings have to be duplicated .. projects can be deleted
    /// </summary>
    public partial class TranscriptionLogItem : EntityBase
    {
        public User User { get; set; }
        public string Filename { get; set; }
        public Project Project { get; set; }

        public TimeSpan Length { get; set; }

        public string TranscriptionSettings { get; set; }

    }
}
