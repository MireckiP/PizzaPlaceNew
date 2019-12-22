using System;
using System.Collections.Generic;

namespace PizzaPlace.Models
{
    public partial class PizzaOrder
    {
        public PizzaOrder()
        {
            CustomerHasOrder = new HashSet<CustomerHasOrder>();
            OrderHasDeals = new HashSet<OrderHasDeals>();
            OrderHasExtras = new HashSet<OrderHasExtras>();
            OrderHasPizzas = new HashSet<OrderHasPizzas>();
        }

        public Guid IdOrder { get; set; }
        public DateTime TimeOrdered { get; set; }
        public DateTime EstimatedDelivery { get; set; }
        public DateTime TimePrepared { get; set; }
        public DateTime ActualDelivery { get; set; }
        public bool IsPaid { get; set; }
        public Guid PersonDelivering { get; set; }
        public Guid PersonSupervising { get; set; }

        public virtual Person PersonDeliveringNavigation { get; set; }
        public virtual Person PersonSupervisingNavigation { get; set; }
        public virtual ICollection<CustomerHasOrder> CustomerHasOrder { get; set; }
        public virtual ICollection<OrderHasDeals> OrderHasDeals { get; set; }
        public virtual ICollection<OrderHasExtras> OrderHasExtras { get; set; }
        public virtual ICollection<OrderHasPizzas> OrderHasPizzas { get; set; }
    }
}
