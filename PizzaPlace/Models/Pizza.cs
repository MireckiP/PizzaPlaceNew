using System;
using System.Collections.Generic;

namespace PizzaPlace.Models
{
    public partial class Pizza
    {
        public Pizza()
        {
            OrderHasPizzas = new HashSet<OrderHasPizzas>();
            PizzaHasIngredient = new HashSet<PizzaHasIngredient>();
        }

        public Guid IdPizza { get; set; }
        public string PizzaName { get; set; }
        public decimal PizzaPrice { get; set; }

        public virtual ICollection<OrderHasPizzas> OrderHasPizzas { get; set; }
        public virtual ICollection<PizzaHasIngredient> PizzaHasIngredient { get; set; }
    }
}
