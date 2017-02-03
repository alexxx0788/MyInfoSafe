﻿using System;
using System.Globalization;
using Utility.Attributes;

namespace Utility.Model
{
    public class User
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        [NotSerialized]
        public string TechnicalDetails { get; set; }
    }
}
