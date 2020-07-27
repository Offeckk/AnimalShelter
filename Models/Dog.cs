using System;
using System.Collections.Generic;

namespace AnimalShelter.Models
{
    public partial class Dog
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Breed { get; set; }
        public byte Cleansed { get; set; }
        public int? CentreId { get; set; }

        public virtual Centre Centre { get; set; }
    }
}
