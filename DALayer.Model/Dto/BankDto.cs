using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DALayer.API.Dto
{
    [Table("bank")]
    public class BankDto 
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("bank")]
        public string BankName { get; set; }
        [Column("summ")]
        public decimal Summ { get; set; }
        [Column("sDate")]
        public DateTime StartDate { get; set; }
        [Column("fDate")]
        public DateTime EndDate { get; set; }
        [Column("month")]
        public int Month { get; set; }
        [Column("persent")]
        public double Persent { get; set; }
        [Column("type")]
        public int Type { get; set; }
        [Column("commentaries")]
        public string Comment { get; set; }
    }
}
