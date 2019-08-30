using NelnetProgrammingExercise.Models;
using System;
using System.Linq;
using System.Collections.Generic;

namespace NelnetProgrammingExercise
{
    class Program
    {
        private static PersonModel[] People;
        private static PetModel[] Pets;

        #region Initialization

        private static void SetupObjects()
        {
            // REQUIREMENT 3,4: OVERRIDES (TESTING) 
            List<iThinkThisIsGross> GrossStuff = new List<iThinkThisIsGross>();

            iThinkThisIsGross TempItem = new NotAGoodFit();
            TempItem.NotLikeThis(PetSize.Medium);
            GrossStuff.Add(TempItem);

            TempItem = new NotClassy();
            TempItem.NotLikeThis(PetClassification.Arachnid);
            GrossStuff.Add(TempItem);

            TempItem = new NotMyType();
            TempItem.NotLikeThis(PetType.Goldfish);
            GrossStuff.Add(TempItem);

            People = new PersonModel[]
            {
                new PersonModel()
                {
                    Name = "Dalinar",
                    PreferredClassification = PetClassification.Mammal,
                    PreferredType = PetType.Snake,
                    PreferredSize = PetSize.Medium,
                    Restrictions = GrossStuff
                },
                new PersonModel()
                {
                    Name = "Kaladin",
                    PreferredClassification = PetClassification.Bird,
                    PreferredType = PetType.Goldfish,
                    PreferredSize = PetSize.ExtraSmall,
                    Restrictions = GrossStuff
                }
            };

            Pets = new PetModel[]
            {
                new PetModel()
                {
                    Name = "Garfield",
                    Classification = PetClassification.Mammal,
                    Type = PetType.Cat,
                    Weight = 20.0
                },
                new PetModel()
                {
                    Name = "Odie",
                    Classification = PetClassification.Mammal,
                    Type = PetType.Dog,
                    Weight = 15.0
                },
                new PetModel()
                {
                    Name = "Peter Parker",
                    Classification = PetClassification.Arachnid,
                    Type = PetType.Spider,
                    Weight = .5
                },
                new PetModel()
                {
                    Name = "Kaa",
                    Classification = PetClassification.Reptile,
                    Type = PetType.Snake,
                    Weight = 25.0
                },
                new PetModel()
                {
                    Name = "Nemo",
                    Classification = PetClassification.Fish,
                    Type = PetType.Goldfish,
                    Weight = .5
                },
                new PetModel()
                {
                    Name = "Alpha",
                    Classification = PetClassification.Fish,
                    Type = PetType.Betta,
                    Weight = .1
                },
                new PetModel()
                {
                    Name = "Splinter",
                    Classification = PetClassification.Mammal,
                    Type = PetType.Rat,
                    Weight = .5
                },
                new PetModel()
                {
                    Name = "Coco",
                    Classification = PetClassification.Bird,
                    Type = PetType.Parrot,
                    Weight = 6.0
                },
                new PetModel()
                {
                    Name = "Tweety",
                    Classification = PetClassification.Bird,
                    Type = PetType.Canary,
                    Weight = .05
                }
            };
        }

        #endregion

        /**
         * I had a decision to make here...
         * The original implementation said good/bad pet.  Hierarchy kind of blew up that implementation.
         * Why?  Because there isn't a "good" or "bad" anymore, simply a best (or none at all...or more than one best).
         * So, instead of saying good or bad I return [0...inf] results
         * 
         * @param Person -- The person to check
         * 
         * @return List -- The pets [0...inf] that best fit the criteria of the human for unconditional lovin'
         */
        private static List<PetModel> BestPet(PersonModel Person)
        {
            // Shallow copy into a list
            List<PetModel> TempPets = Pets.ToList();

            // First let's deal with the pesky exception/override cases
            foreach(iThinkThisIsGross i in Person.Restrictions)
            {
                if (i is NotClassy)
                    TempPets = TempPets.Where(x => x.Classification != ((NotClassy)i).PetClassification).ToList();
                if (i is NotMyType)
                    TempPets = TempPets.Where(x => x.Type != ((NotMyType)i).PetType).ToList();
                if (i is NotAGoodFit)
                    TempPets = TempPets.Where(x => !SharedFunctions.StepOnScale(x.Weight, ((NotAGoodFit)i).PetSize)).ToList();
            }

            // REQUIREMENT 5: HIERARCHY -- Type first, classification second, weight third...otherwise get the first good pet
            if (TempPets.Where(x => x.Type == Person.PreferredType).Any())
            {
                TempPets = TempPets.Where(x => x.Type == Person.PreferredType).ToList();
            }

            if (TempPets.Where(x => x.Classification == Person.PreferredClassification).Any())
            {
                TempPets = TempPets.Where(x => x.Classification == Person.PreferredClassification).ToList();
            }

            if (TempPets.Where(x => SharedFunctions.StepOnScale(x.Weight, Person.PreferredSize)).Any())
            {
                TempPets = TempPets.Where(x => SharedFunctions.StepOnScale(x.Weight, Person.PreferredSize)).ToList();
            }

            // since I did this all in lists other than optimizing the lambda...I can safetly return the result without nulls
            return TempPets;
        }

        static void Main(string[] args)
        {
            // Set up like we did prior
            SetupObjects();

            // Run through each person in the test cases
            foreach(PersonModel person in People) {
                // Find out the matches (if any)
                List<PetModel> bestFriends = BestPet(person);

                // Communicate results
                if (bestFriends.Count() == 0)
                    Console.WriteLine($"404 Pet Not Found for {person.Name}.");
                else
                {
                    foreach (PetModel pet in bestFriends)
                    {
                        Console.WriteLine($"{pet.Name} would be a good pet for {person.Name}.");
                    }
                }

                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}
