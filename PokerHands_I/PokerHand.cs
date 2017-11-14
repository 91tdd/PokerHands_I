using System;
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
                .Select(x =>
                new Card
                {
                    Suit = x.Substring(x.Length - 1, 1),
                    Value = Convert.ToInt16(x.Substring(0, x.Length - 1))
                });

            this.Dealt();
        }

        private void Dealt()
        {
            this.Type = ResultType.Flush;
            this.MaxCardNum = _cards.Max(c => c.Value);
        }

        public ResultType Type { get; set; }
        public int MaxCardNum { get; set; }
    }

    public class Card
    {
        public string Suit { get; set; }
        public Int16 Value { get; set; }
    }
}