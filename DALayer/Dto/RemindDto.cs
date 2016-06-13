using System.ComponentModel.DataAnnotations.Schema;


namespace DALayer.API.Dto
{
    [Table("remind")]
    public class RemindDto
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("emailAccount")]
        public string EmailAccount { get; set; }
        [Column("emailPassword")]
        public string Password { get; set; }
        [Column("emailAddress")]
        public string Address { get; set; }
        [Column("smtpAddress")]
        public string Smtp { get; set; }
        [Column("port")]
        public int Port { get; set; }
        [Column("sendTo")]
        public string ToAddress { get; set; }
        [Column("count")]
        public int Count { get; set; }
    }
}
