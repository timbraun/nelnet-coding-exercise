using System;
using System.Collections.Generic;
using System.Text;

namespace NelnetProgrammingExercise.Models
{
    public class PersonModel
    {
        public string Name { get; set; }
        public IEnumerable<PetClassification> PreferredClassifications { get; set; }
        public IEnumerable<PetType> PreferredTypes { get; set; }
    }
}
