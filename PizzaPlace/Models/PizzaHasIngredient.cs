using System;
using System.Collections.Generic;

namespace PizzaPlace.Models
{
    public partial class PizzaHasIngredient
    {
        public Guid PizzaIdPizza { get; set; }
        public Guid IngredientIdIngredient { get; set; }
        public byte? Amount { get; set; }

        public virtual Ingredient IngredientIdIngredientNavigation { get; set; }
        public virtual Pizza PizzaIdPizzaNavigation { get; set; }
    }
}
