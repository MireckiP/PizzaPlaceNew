using System;
using System.Collections.Generic;

namespace PizzaPlace.Models
{
    public partial class OrderHasExtras
    {
        public Guid OrderIdOrder { get; set; }
        public Guid ExtrasIdExtras { get; set; }
        public byte? AmountExtras { get; set; }

        public virtual Extras ExtrasIdExtrasNavigation { get; set; }
        public virtual PizzaOrder OrderIdOrderNavigation { get; set; }
    }
}
