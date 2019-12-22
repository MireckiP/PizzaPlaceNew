using System;
using System.Collections.Generic;

namespace PizzaPlace.Models
{
    public partial class Extras
    {
        public Extras()
        {
            OrderHasExtras = new HashSet<OrderHasExtras>();
        }

        public Guid IdExtras { get; set; }
        public string ExtraName { get; set; }
        public byte ExtraAmount { get; set; }
        public decimal ExtraPrice { get; set; }

        public virtual ICollection<OrderHasExtras> OrderHasExtras { get; set; }
    }
}
