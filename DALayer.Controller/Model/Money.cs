using IStor.DAL.Model.Attributes;

namespace IStor.DAL.Model.Dto
{
    public class Money
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Currency { get; set; }
        public string Amount { get; set; }
        public string Type { get; set; }
        
        public string Details { get; set; }
    }
}
