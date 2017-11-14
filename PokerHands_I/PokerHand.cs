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
                }).OrderBy(c => c.Value);

            this.Dealt();
        }

        private void Dealt()
        {
            this.MaxCardNum = _cards.Max(c => c.Value);
            if (IsFlush())
            {
                if (IsStraight())
                {
                    this.Type = ResultType.StraightFlush;
                    return;
                }
                this.Type = ResultType.Flush;
                return;
            }

            if (IsStraight())
            {
                this.Type = ResultType.Straight;
                return;
            }
        }

        private bool IsFlush()
        {
            return _cards.All(c => c.Suit == _cards.First().Suit);
        }

        private bool IsStraight()
        {
            return _cards.Max(c => c.Value) - _cards.Min(c => c.Value) == 4;
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