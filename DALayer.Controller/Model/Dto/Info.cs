namespace DALayer.Controller.Model.Dto
{
    public class Info
    {
        public int Id { get; set; }
        [Insertable]
        public string Service { get; set; }
        [Insertable]
        public string Login { get; set; }
        [Insertable]
        public string Password { get; set; }
        [Insertable]
        public string Details { get; set; }
    }
}
