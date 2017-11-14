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

        public short MaxCardNum { get; set; }

        public ResultType Type { get; set; }

        private void Dealt()
        {
            var pokerHandlers = GetPokerHandlers();

            foreach (var pokerHandler in pokerHandlers)
            {
                if (pokerHandler.IsMatch())
                {
                    pokerHandler.SetResult();
                    return;
                }
            }
        }

        private List<IPokerHandler> GetPokerHandlers()
        {
            var pokerHandlers = new List<IPokerHandler>
            {
                new FlushHandler(this),
                new FullHouseHandler(this),
                new StraightHandler(this)
            };
            return pokerHandlers;
        }
    }

    internal class FullHouseHandler : IPokerHandler
    {
        private readonly PokerHand _pokerHand;

        public FullHouseHandler(PokerHand pokerHand)
        {
            _pokerHand = pokerHand;
        }

        public bool IsMatch()
        {
            var cardsGroupByValue = _pokerHand._cards.GroupBy(c => c.Value);
            var hasThreeCardSameValue = cardsGroupByValue.Any(x => x.Count() == 3);
            var hasTwoCardSameValue = cardsGroupByValue.Any(x => x.Count() == 2);
            return hasTwoCardSameValue && hasThreeCardSameValue;
        }

        public void SetResult()
        {
            _pokerHand.Type = ResultType.FullHouse;
            _pokerHand.MaxCardNum = _pokerHand._cards.GroupBy(c => c.Value).First(x => x.Count() == 3).Key;
        }
    }
}