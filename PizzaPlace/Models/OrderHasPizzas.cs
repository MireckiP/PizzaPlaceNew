using System;
using System.Collections.Generic;

namespace PizzaPlace.Models
{
    public partial class OrderHasPizzas
    {
        public Guid PizzaIdPizza { get; set; }
        public Guid OrderIdOrder { get; set; }
        public byte? AmountPizzas { get; set; }

        public virtual PizzaOrder OrderIdOrderNavigation { get; set; }
        public virtual Pizza PizzaIdPizzaNavigation { get; set; }
    }
}
