using Beey.DataExchangeModel.Serialization;
using System;
using System.IO;

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

        /// <summary>
        /// do not use for file names, can contain invalid characters
        /// </summary>
        [JsonIgnoreWebDeserialize]
        public string Name { get; set; }


        //TODO: this should be solved in some other way that will not expect that invalid GetInvalidFileNameChars does not change, and possibly prevent conflicts..
        [JsonIgnoreWebDeserialize]
        public string ValidFileName => MakeValidFileName(Name);

        static string invalidChars = System.Text.RegularExpressions.Regex.Escape(new string(Path.GetInvalidFileNameChars()));
        static string invalidRegStr = string.Format(@"([{0}]*\.+$)|([{0}]+)", invalidChars);
        private static string MakeValidFileName(string name)
        {
            return System.Text.RegularExpressions.Regex.Replace(name, invalidRegStr, "_");
        }

        [JsonIgnoreWeb]
        public long Size { get; set; }
    }
}
