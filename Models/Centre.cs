using System;
using System.Collections.Generic;

namespace AnimalShelter.Models
{
    public partial class Centre
    {
        public Centre()
        {
            Cats = new HashSet<Cat>();
            Dogs = new HashSet<Dog>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }

        public virtual ICollection<Cat> Cats { get; set; }
        public virtual ICollection<Dog> Dogs{ get; set; }
    }
}
