using System.ComponentModel.DataAnnotations.Schema;

namespace DALayer.API.Dto
{
    [Table("info")]
    public class InfoDto
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("service")]
        public string Service { get; set; }
        [Column("login")]
        public string Login { get; set; }
        [Column("password")]
        public string Password { get; set; }
        [Column("advanced")]
        public string Advanced { get; set; }
    }
}
