using System;
using System.Collections.Generic;
using System.Linq;

namespace PokerHands_I
{
    public class PokerHand
    {
        public IEnumerable<Card> _cards;

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

        public int MaxCardNum { get; set; }

        public ResultType Type { get; set; }

        private void Dealt()
        {
            var pokerHandlers = new List<IPokerHandler>
            {
                new FlushHandler(this),
                new StraightHandler(this)
            };

            foreach (var pokerHandler in pokerHandlers)
            {
                if (pokerHandler.IsMatch())
                {
                    pokerHandler.SetResult();
                    return;
                }
            }
        }
    }
}