using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShepherdCoAPI.Shared.Attributes;

namespace ShepherdCoAPI.Model
{
    public class User
    {
        [SearchBy]
        public int UserId { get; set; }
        [Insert][Update]

        public string Login { get; set; }
        [Insert][Update]

        public double Balance { get; set; }

    }
}
