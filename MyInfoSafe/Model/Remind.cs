namespace MyInfoSafe.Model
{
    public class Remind
    {
        public int Id { get; set; }
        public string EmailAccount { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string Smtp { get; set; }
        public int Port { get; set; }
        public string ToAddress { get; set; }
        public int Count { get; set; }
        
    }
}
