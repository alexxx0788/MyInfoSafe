using System.Data.Entity;
using System.Data.SqlServerCe;
using DALayer.API.Dto;

namespace DALayer.API.DbConfiguration
{
    public class InfoSafeContext : DbContext
    {
        public InfoSafeContext(SqlCeConnection conn) : base(conn, true) { }
        public DbSet<BankDto> Banks { get; set; }
        public DbSet<InfoDto> InfoItems { get; set; }
        public DbSet<UserDto> Users { get; set; }
        public DbSet<RemindDto> Reminds { get; set; }
    }
}
