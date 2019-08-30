using System.Collections.Generic;

namespace NelnetProgrammingExercise.Models
{
    public class PersonModel
    {
        public string Name { get; set; }
        public PetClassification PreferredClassification { get; set; }
        public PetType PreferredType { get; set; }
        public PetSize PreferredSize { get; set; } // Added in order to track size requirements of owner

        public List<iThinkThisIsGross> Restrictions; // Added to track restrictions per-person
    } 
}
