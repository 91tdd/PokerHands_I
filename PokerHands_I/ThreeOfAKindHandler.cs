using System.Collections.Generic;
using System.Linq;

namespace PokerHands_I
{
    internal class ThreeOfAKindHandler : IPokerHandler
    {
        private readonly PokerHand _pokerHand;
        private IEnumerable<IGrouping<short, Card>> _cardsGroupByValue;

        public ThreeOfAKindHandler(PokerHand pokerHand)
        {
            _pokerHand = pokerHand;
            _cardsGroupByValue = _pokerHand._cards.GroupBy(x => x.Value);
        }

        public bool IsMatch()
        {
            return _cardsGroupByValue.Any(x => x.Count() == 3) && _cardsGroupByValue.Count() == 3;
        }

        public void SetResult()
        {
            _pokerHand.Type = ResultType.ThreeOfAKind;
            _pokerHand.MaxCardNum = _cardsGroupByValue.First(x => x.Count() == 3).Key;
        }
    }
}