using System;
using System.Collections.Generic;

namespace PizzaPlace.Models
{
    public partial class PersonType
    {
        public PersonType()
        {
            Person = new HashSet<Person>();
        }

        public Guid IdPersonType { get; set; }
        public string TypeOfPerson { get; set; }

        public virtual ICollection<Person> Person { get; set; }
    }
}
