using DALayer.Controller.Model.Attributes;

namespace DALayer.Controller.Model.Dto
{
    public class Money
    {
        public int Id { get; set; }
        public string Currency { get; set; }
        public string Amount { get; set; }
        public string Type { get; set; }
        
        public string Details { get; set; }
    }
}
