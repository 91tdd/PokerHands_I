using System.Collections.Generic;

namespace PokerHands_I
{
    public class PokerHandGame
    {
        private readonly string _firstPlayer;
        private readonly string _secondPlayer;

        public PokerHandGame(string firstPlayer, string secondPlayer)
        {
            _firstPlayer = firstPlayer;
            _secondPlayer = secondPlayer;
        }

        public string Output { get; set; }

        public void Play(string firstPlayerCards, string secondPlayerCards)
        {
            var firstPlayerPokerHand = new PokerHand(firstPlayerCards);
            var secondPlayerPokerHand = new PokerHand(secondPlayerCards);
            var compareResult = new PokerHandComparer().Compare(firstPlayerPokerHand, secondPlayerPokerHand);
            if (IsTie(compareResult))
            {
                Output = "Tie";
            }
            else
            {
                var isFirstPlayerWin = compareResult > 0;
                var winnerName = isFirstPlayerWin ? _firstPlayer : _secondPlayer;
                var winnerType = isFirstPlayerWin ? firstPlayerPokerHand.Type : secondPlayerPokerHand.Type;
                var typeOutputLookup = new Dictionary<ResultType, string>
                {
                    {ResultType.HighCard, "high card"},
                    {ResultType.Straight, "straight"},
                    {ResultType.Flush, "flush"},
                    {ResultType.FourOfAKind, "four of a kind"},
                    {ResultType.FullHouse, "full house"},
                    {ResultType.Pair, "pair"},
                    {ResultType.StraightFlush, "straight flush"},
                    {ResultType.ThreeOfAKind, "three of a kind"},
                    {ResultType.TwoPair, "two pair"},
                };

                var winnerTypeOutput = typeOutputLookup[winnerType];
                var valueOutputLookup = new Dictionary<int, string>
                {
                    {1,"Ace" },
                    {2,"2" },
                    {3,"3" },
                    {4,"4" },
                    {5,"5" },
                    {6,"6" },
                    {7,"7" },
                    {8,"8" },
                    {9,"9" },
                    {10,"10" },
                    {11,"Jack" },
                    {12,"Queen" },
                    {13,"King" },
                    {14,"Ace" },
                };
                var winnerValue = isFirstPlayerWin ? firstPlayerPokerHand.MaxCardNum : secondPlayerPokerHand.MaxCardNum;
                var valueOutput = valueOutputLookup[winnerValue];
                this.Output = $"{winnerName} Win. -with {winnerTypeOutput}: {valueOutput}";
            }
        }

        private static bool IsTie(int compareResult)
        {
            return compareResult == 0;
        }
    }
}