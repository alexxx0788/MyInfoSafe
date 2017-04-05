using IStor.DAL.Shared.Attributes;

namespace IStorage.DAL.Model
{
    public class Users : IDto
    {
        [PrimaryKey]
        public int Id { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }
    }
}
