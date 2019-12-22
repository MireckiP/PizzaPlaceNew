using System;
using System.Collections.Generic;

namespace PizzaPlace.Models
{
    public partial class Deals
    {
        public Deals()
        {
            OrderHasDeals = new HashSet<OrderHasDeals>();
        }

        public Guid IdDeals { get; set; }
        public string DealName { get; set; }
        public byte Modifier { get; set; }

        public virtual ICollection<OrderHasDeals> OrderHasDeals { get; set; }
    }
}
