using IStor.DAL.Shared.Attributes;

namespace IStorage.DAL.Model
{
    public class Money : IDto
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Currency { get; set; }
        public string Amount { get; set; }
        public string Type { get; set; }
        public string Details { get; set; }
    }
}
