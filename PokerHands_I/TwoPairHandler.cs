using System.Collections.Generic;
using System.Linq;

namespace PokerHands_I
{
    internal class TwoPairHandler : IPokerHandler
    {
        private readonly PokerHand _pokerHand;
        private IEnumerable<IGrouping<short, Card>> _cardsGroupByValue;

        public TwoPairHandler(PokerHand pokerHand)
        {
            _pokerHand = pokerHand;
            _cardsGroupByValue = _pokerHand._cards.GroupBy(x => x.Value);
        }

        public bool IsMatch()
        {
            return _cardsGroupByValue.Count(x => x.Count() == 2) == 2;
        }

        public void SetResult()
        {
            _pokerHand.Type = ResultType.TwoPair;
            _pokerHand.MaxCardNum = _cardsGroupByValue.Where(x => x.Count() == 2).Max(x => x.Key);
        }
    }
}