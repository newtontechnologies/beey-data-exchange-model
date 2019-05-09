namespace BeeyApi.POCO.Transcriptions
{
    public enum DiarEventType
    {
        /// <summary>
        /// Preview ASR
        /// </summary>
        P,
        /// <summary>
        /// fix ASR
        /// </summary>
        F,
        /// <summary>
        /// diarization
        /// </summary>
        D,
        /// <summary>
        /// first message from diar system with information
        /// </summary>
        info,
        /// <summary>
        /// request something from diar server
        /// </summary>
        demand,
    }
}

