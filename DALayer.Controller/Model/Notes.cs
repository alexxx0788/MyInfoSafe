using IStor.DAL.Shared.Attributes;

namespace IStorage.DAL.Model
{
    public class Notes :IDto
    {
        [PrimaryKey]
        public int Id { get; set; }
        
        public string Title { get; set; }
        
        public string Text { get; set; }
    }
}
