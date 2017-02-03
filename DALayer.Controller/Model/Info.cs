using IStor.DAL.Model.Attributes;

namespace IStor.DAL.Model.Dto
{
    public class Info
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Service { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Details { get; set; }
    }
}
