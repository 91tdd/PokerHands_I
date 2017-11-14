using System.Collections.Generic;
using System.Linq;

namespace PokerHands_I
{
    internal class FourOfAKindHandler : IPokerHandler
    {
        private readonly PokerHand _pokerHand;
        private IEnumerable<IGrouping<short, Card>> _cardsGroupByValue;

        public FourOfAKindHandler(PokerHand pokerHand)
        {
            _pokerHand = pokerHand;
            _cardsGroupByValue = _pokerHand._cards.GroupBy(x => x.Value);
        }

        public bool IsMatch()
        {
            return _cardsGroupByValue.Any(x => x.Count() == 4);
        }

        public void SetResult()
        {
            _pokerHand.Type = ResultType.FourOfAKind;
            _pokerHand.MaxCardNum = _cardsGroupByValue.First(x => x.Count() == 4).Key;
        }
    }
}