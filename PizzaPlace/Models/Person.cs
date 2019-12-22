using System;
using System.Collections.Generic;

namespace PizzaPlace.Models
{
    public partial class Person
    {
        public Person()
        {
            CustomerHasOrder = new HashSet<CustomerHasOrder>();
            PizzaOrderPersonDeliveringNavigation = new HashSet<PizzaOrder>();
            PizzaOrderPersonSupervisingNavigation = new HashSet<PizzaOrder>();
        }

        public Guid IdPerson { get; set; }
        public Guid PersonTypeIdPersonType { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public virtual PersonType PersonTypeIdPersonTypeNavigation { get; set; }
        public virtual ICollection<CustomerHasOrder> CustomerHasOrder { get; set; }
        public virtual ICollection<PizzaOrder> PizzaOrderPersonDeliveringNavigation { get; set; }
        public virtual ICollection<PizzaOrder> PizzaOrderPersonSupervisingNavigation { get; set; }
    }
}
