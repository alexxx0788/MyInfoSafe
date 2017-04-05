﻿using IStor.DAL.Shared.Attributes;

namespace IStorage.DAL.Model
{
    public class Info : IDto
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Service { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Details { get; set; }
    }
}
