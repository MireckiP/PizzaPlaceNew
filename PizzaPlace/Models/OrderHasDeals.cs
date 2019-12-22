using System;
using System.Collections.Generic;

namespace PizzaPlace.Models
{
    public partial class OrderHasDeals
    {
        public Guid OrderIdOrder { get; set; }
        public Guid DealsIdDeals { get; set; }

        public virtual Deals DealsIdDealsNavigation { get; set; }
        public virtual PizzaOrder OrderIdOrderNavigation { get; set; }
    }
}
