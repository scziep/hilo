using System;
using System.Collections.Generic;


namespace Unit02.Game
{
    /// <summary>
    /// A person who directs the game. 
    ///
    /// The responsibility of a Director is to control the sequence of play.
    /// </summary>
    public class Director
    {
        List<Card> cards = new List<Card>();
        bool _isPlaying = true;
        int win = 100;
        int loss= 75;
        int _totalScore = 300;

        int currentCard;
        int nextCard;

        /// <summary>
        /// Constructs a new Director.
        /// </summary>
        public Director()
        {
            for (int i = 0; i < 1; i++)
            {
                Card card = new Card();
                cards.Add(card);
            }
        }

        /// <summary>
        /// Starts the game.
        /// </summary>
        public void StartGame()
        {
            foreach (Card card in cards)
            {
                card.newCard();
                currentCard = card.cardValue;
            }
            while (_isPlaying)
            {
                mainGame();
                gameCheck();
            }
        }

        /// <summary>
        /// Asks the user if they want to roll. As well as displays the new card and the points given based on their decision
        /// </summary>
        public void mainGame(){
            Console.WriteLine($"The card is {currentCard}");
            if (!_isPlaying)
            {
                return;
            }

            foreach (Card card in cards){
                card.newCard();
                nextCard = card.cardValue;
            }
            Console.Write("Higher or Lower: [h/l]  ");
            string cardGuess = Console.ReadLine();
            Console.WriteLine($"The next card was:{nextCard}");
            if (cardGuess.Equals("h") && currentCard < nextCard){
                _totalScore += win;
            }
            else if(cardGuess.Equals("l") && currentCard > nextCard){
                _totalScore += win;
            }
            else if(cardGuess.Equals("h") && currentCard > nextCard){
                _totalScore -= loss;
                if (_totalScore < 0){
                    _totalScore = 0;
                }
            }
            else if(cardGuess.Equals("l") && currentCard < nextCard){
                _totalScore -= loss;
                if (_totalScore < 0){
                    _totalScore = 0;
                }
            }

        }

        /// Decides if they player has enough points to continue/wants to continue
        public void gameCheck(){
            Console.WriteLine($"Your score is: {_totalScore}");
            if (_totalScore == 0){
                _isPlaying = false;
            }
            if (!_isPlaying)
            {
                return;
            }

            currentCard = nextCard;
            Console.Write("Keep Playing? [y/n] ");
            string rollDice = Console.ReadLine();
            _isPlaying = (rollDice == "y");
        }
    }
}