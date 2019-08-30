using System;
using System.Collections.Generic;
using System.Text;

namespace NelnetProgrammingExercise.Models
{
    /**
     * In general, if a function is going to be used multiple times (as it is in a couple classes here), I 
     * like to create a static library to reference whenever necessary.
     */
    public static class SharedFunctions
    {
        /**
         * @param WeightCheck -- The weight of the pet in question
         * @param PetSize -- The general description of size range (weight) a person wants
         * 
         * @return bool -- Is the weight within the range specified in the BRD??
         */
        public static bool StepOnScale(double WeightCheck, PetSize DesiredSize)
        {
            // REQUIREMENT 2: WEIGHT JUDGEMENT 
            bool res = false;
            switch (DesiredSize)
            {
                case PetSize.ExtraLarge:
                    res = WeightCheck > 30.0 ? true : false;
                    break;
                case PetSize.Large:
                    res = WeightCheck > 15.0 && WeightCheck <= 30.0 ? true : false;
                    break;
                case PetSize.Medium:
                    res = WeightCheck > 5.0 && WeightCheck <= 15.0 ? true : false;
                    break;
                case PetSize.Small:
                    res = WeightCheck > 1.0 && WeightCheck <= 5.0 ? true : false;
                    break;
                case PetSize.ExtraSmall:
                    res = WeightCheck > 0 && WeightCheck <= 1.0 ? true : false;
                    break;
                default:
                    break;
            }

            return res;
        }
    }
}
