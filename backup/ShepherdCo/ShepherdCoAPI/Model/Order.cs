using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShepherdCoAPI.Shared.Attributes;

namespace ShepherdCoAPI.Model
{
    public class Order
    {
        public int OrderId { get; set; }
        [Insert][Update]
        public Stock Stock { get; set; }
        [Insert][Update]
        public User User { get; set; }
        [Insert][Update]
        public DateTime Date { get; set; }

    }
}
