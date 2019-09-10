using Beey.DataExchangeModel.Serialization;
using System;

#pragma warning disable nullable
#pragma warning disable 8618
namespace Beey.DataExchangeModel.Files
{
    public partial class FileWrapper : EntityBase
    {
        [Obsolete("do not use directly use filewrapper.CreateX")]
        public FileWrapper()
        {

        }

        [JsonIgnoreWebDeserialize]
        public string Name { get; set; }
        [JsonIgnoreWebDeserialize]
        public long Size { get; set; }
    }
}
