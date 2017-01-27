using DALayer.Controller.Model.Attributes;

namespace DALayer.Controller.Model.Dto
{
    public class Info
    {
        [Selecteble][Removable]
        public int Id { get; set; }
        [Changeable][Searchable]  
        public string Service { get; set; }
        [Changeable]
        public string Login { get; set; }
        [Changeable]
        public string Password { get; set; }
        [Changeable]
        public string Details { get; set; }
    }
}
