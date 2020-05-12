#pragma warning disable nullable
#pragma warning disable 8618
namespace Beey.DataExchangeModel
{
    public partial class UploadConfig
    {
        public UploadConfig()
        {
        }

        public UploadConfig(bool saveMedia, int userId)
        {          
            SaveMedia = saveMedia;
            UserID = userId;
        }

        public bool SaveMedia { get; }
        public int UserID { get; }
    }
}
