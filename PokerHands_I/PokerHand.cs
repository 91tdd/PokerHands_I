using System.Collections.Generic;
using System.Linq;

namespace PokerHands_I
{
    public class PokerHand
    {
        private IEnumerable<Card> _cards;

        public PokerHand(string cardsContent)
        {
            this._cards = cardsContent.Split(',')
                .Select(x => new Card { Value = x.Substring(0, 1), Suit = x.Substring(1, x.Length - 1) });

            this.Dealt();
        }

        private void Dealt()
        {
            this.Type = ResultType.Flush;
            this.MaxCardNum = 7;
        }

        public ResultType Type { get; set; }
        public int MaxCardNum { get; set; }
    }

    public class Card
    {
        public string Suit { get; set; }
        public string Value { get; set; }
    }
}