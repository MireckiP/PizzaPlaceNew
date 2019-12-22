using System;
using System.Collections.Generic;

namespace PizzaPlace.Models
{
    public partial class Ingredient
    {
        public Ingredient()
        {
            PizzaHasIngredient = new HashSet<PizzaHasIngredient>();
        }

        public Guid IdIngredient { get; set; }
        public string IngredientName { get; set; }
        public decimal IngredientPrice { get; set; }

        public virtual ICollection<PizzaHasIngredient> PizzaHasIngredient { get; set; }
    }
}
