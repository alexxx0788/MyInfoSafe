using System.ComponentModel.DataAnnotations.Schema;

namespace DALayer.API.Dto
{
    [Table("users")]
    public class UserDto
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("login")]
        public string Login { get; set; }

        [Column("password")]
        public string Password { get; set; }

        [Column("version")]
        public int Version { get; set; }
    }
}
