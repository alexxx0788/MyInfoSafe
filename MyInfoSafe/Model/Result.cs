namespace MyInfoSafe.Model
{
    public class Result
    {
        public Result()
        {
            mCode = 1;
            mMessage = "success";
        }
        public Result(int pCode, string pMessage)
        {
            mCode = pCode;
            mMessage = pMessage;
        }

        public int mCode { get; set; }
        public string mMessage { get; set; }
    }
}
