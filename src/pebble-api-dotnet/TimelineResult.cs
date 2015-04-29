namespace pebble_api_dotnet
{
    public class TimelineResult
    {
        public TimelineResult(int errorCode, string errorDescription)
        {
            this.ErrorCode = errorCode;
            this.ErrorDescription = errorDescription;

            Success = false;
            if (this.ErrorCode < 300) Success = true;
        }

        public bool Success { get; private set; }

        public int ErrorCode { get; private set; }

        public string ErrorDescription { get; private set; }
    }
}