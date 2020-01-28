#pragma warning disable nullable
#pragma warning disable 8618
namespace Beey.DataExchangeModel
{
    public partial class UploadConfig
    {
        public UploadConfig(bool transcribe, bool saveMedia, bool saveTrsx, string Language, bool WithPPC)
        {
            Transcribe = transcribe;
            SaveMedia = saveMedia;
            SaveTrsx = saveTrsx;
            this.Language = Language;
            this.WithPPC = WithPPC;
        }

        public bool Transcribe { set; get; }
        public bool SaveTrsx { set; get; }
        public string Language { get; }
        public bool WithPPC { get; }
        public bool SaveMedia { set; get; }

        public int UserID { set; get; }
    }
}
