using System.Collections.Generic;
using System.Linq;

namespace PokerHands_I
{
    internal class FullHouseHandler : IPokerHandler
    {
        private readonly PokerHand _pokerHand;

        private IEnumerable<IGrouping<short, Card>> cardsGroupByValue;

        public FullHouseHandler(PokerHand pokerHand)
        {
            _pokerHand = pokerHand;
            cardsGroupByValue = _pokerHand._cards.GroupBy(c => c.Value);
        }

        public bool IsMatch()
        {
            var hasThreeCardSameValue = cardsGroupByValue.Any(x => x.Count() == 3);
            var hasTwoCardSameValue = cardsGroupByValue.Any(x => x.Count() == 2);
            return hasTwoCardSameValue && hasThreeCardSameValue;
        }

        public void SetResult()
        {
            _pokerHand.Type = ResultType.FullHouse;
            _pokerHand.MaxCardNum = cardsGroupByValue.First(x => x.Count() == 3).Key;
        }
    }
}