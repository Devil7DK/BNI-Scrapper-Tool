namespace  Devil7.Automation.BNI.Scrapper.Utils
{
    public class ResponseEventArgs
    {
        public byte[] RawData { get; }
        public string Data { get; }

        public ResponseEventArgs(byte[] RawData, string Data)
        {
            this.RawData = RawData;
            this.Data = Data;
        }
    }
}