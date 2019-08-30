using System;
using System.Collections.Generic;
using System.Text;

namespace NelnetProgrammingExercise.Models
{
    /**
     * This makes it easy to add as many overrides as I'd like without having to build out multiple lists
     */
    public interface iThinkThisIsGross
    {
        void NotLikeThis(Enum NoBueno);
    }

    /**
     * Got a size dislike?  No problem.
     */
    public struct NotAGoodFit : iThinkThisIsGross
    {
        public PetSize PetSize { get; set; }

        void iThinkThisIsGross.NotLikeThis(Enum NoBueno)
        {
            this.PetSize = (PetSize)NoBueno;
        }

    }

    /**
     * Want to drop out of certain classes?  You got it.
     */
    public struct NotClassy : iThinkThisIsGross
    {
        public PetClassification PetClassification { get; set; }

        void iThinkThisIsGross.NotLikeThis(Enum NoBueno)
        {
            this.PetClassification = (PetClassification)NoBueno;
        }
    }

    /**
     * A little bit shallow on your type?  I won't judge.
     */
    public struct NotMyType : iThinkThisIsGross
    {
        public PetType PetType { get; set; }

        void iThinkThisIsGross.NotLikeThis(Enum NoBueno)
        {
            this.PetType = (PetType)NoBueno;
        }
    }
}
