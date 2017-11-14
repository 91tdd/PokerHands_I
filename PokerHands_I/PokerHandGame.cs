using System.Collections.Generic;

namespace PokerHands_I
{
    public class PokerHandGame
    {
        private readonly string _firstPlayer;
        private readonly string _secondPlayer;

        private readonly Dictionary<int, string> _valueOutputLookup = new Dictionary<int, string>
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

        private readonly Dictionary<ResultType, string> _typeOutputLookup = new Dictionary<ResultType, string>
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

            Output = IsTie(compareResult) ? "Tie" : GetOutput(compareResult, firstPlayerPokerHand, secondPlayerPokerHand);
        }

        private string GetOutput(int compareResult, PokerHand firstPlayerPokerHand, PokerHand secondPlayerPokerHand)
        {
            var winnerName = WinnerName(compareResult);
            var winnerType = WinnerType(firstPlayerPokerHand, secondPlayerPokerHand, compareResult);
            var winnerValue = WinnerValue(firstPlayerPokerHand, secondPlayerPokerHand, compareResult);
            return $"{winnerName} Win. -with {winnerType}: {winnerValue}";
        }

        private string WinnerType(PokerHand firstPlayerPokerHand, PokerHand secondPlayerPokerHand, int result)
        {
            var winnerType = result > 0 ? firstPlayerPokerHand.Type : secondPlayerPokerHand.Type;
            return _typeOutputLookup[winnerType];
        }

        private string WinnerValue(PokerHand firstPlayerPokerHand, PokerHand secondPlayerPokerHand, int result)
        {
            var winnerValue = result > 0 ? firstPlayerPokerHand.MaxCardNum : secondPlayerPokerHand.MaxCardNum;
            return _valueOutputLookup[winnerValue];
        }

        private string WinnerName(int result)
        {
            return result > 0 ? _firstPlayer : _secondPlayer;
        }

        private static bool IsTie(int compareResult)
        {
            return compareResult == 0;
        }
    }
}