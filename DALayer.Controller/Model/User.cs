namespace IStor.DAL.Model.Dto
{
    public class User
    {
        public int Id { get; set; }
        
        public string Login { get; set; }
        
        public string Password { get; set; }
        
        public int Version { get; set; }
    }
}
