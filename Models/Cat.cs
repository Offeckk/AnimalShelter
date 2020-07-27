using System;
using System.Collections.Generic;

namespace AnimalShelter.Models
{
    public class Cat
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Breed { get; set; }
        public int IntelligenceCoefficient { get; set; }
        public byte Cleansed { get; set; }
        public int? CentreId { get; set; }

        public virtual Centre Centre { get; set; }
    }
}
