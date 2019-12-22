using System;
using System.Collections.Generic;

namespace PizzaPlace.Models
{
    public partial class CustomerHasOrder
    {
        public Guid PersonIdPerson { get; set; }
        public Guid OrderIdOrder { get; set; }

        public virtual PizzaOrder OrderIdOrderNavigation { get; set; }
        public virtual Person PersonIdPersonNavigation { get; set; }
    }
}
