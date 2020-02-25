#pragma warning disable nullable
#pragma warning disable 8618
namespace Beey.DataExchangeModel
{
    public partial class RecognitionConfig
    {
        public RecognitionConfig(bool saveTrsx, string language, bool withPPC, int userId)
        {
            SaveTrsx = saveTrsx;
            Language = language;
            WithPPC = withPPC;
            UserID = userId;
        }

        public bool SaveTrsx { get; }
        public string Language { get; }
        public bool WithPPC { get; }
        public int UserID { get; }
    }
}
