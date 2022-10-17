using System;


namespace Unit02.Game
{
    /// <summary>
    /// A small cube with a different number of spots on each of its six sides.
    /// 
    /// The responsibility of Die is to keep track of its currently rolled value and the points its
    /// worth.
    /// </summary> 
    public class Card
    {
        public int cardValue;
        

        /// <summary>
        /// Constructs a new instance of Die.
        /// </summary>
        public void newCard(){
            Random randomGenerator = new Random();
            cardValue = randomGenerator.Next(1, 14);
        }
    }
}