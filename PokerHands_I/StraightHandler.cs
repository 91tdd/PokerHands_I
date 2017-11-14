using System.Collections.Generic;
using System.Linq;

namespace PokerHands_I
{
    public class StraightHandler : IPokerHandler
    {
        private PokerHand _pokerHand;

        public StraightHandler(PokerHand pokerHand)
        {
            _pokerHand = pokerHand;
        }

        public bool IsMatch()
        {
            var newCards = _pokerHand._cards.ToList();
            if (_pokerHand._cards.Any(x => x.Value == 14))
            {
                var aceCard = newCards.Find(x => x.Value == 14);
                aceCard.Value = 1;
            }

            return IsStraight(_pokerHand._cards) || IsStraight(newCards);
        }

        private bool IsStraight(IEnumerable<Card> cards)
        {
            var isAllDifferentValue = cards.GroupBy(x => x.Value).Count() == 5;
            var isDiffValueIsFour = cards.Max(c => c.Value) - cards.Min(c => c.Value) == 4;

            return isDiffValueIsFour && isAllDifferentValue;
        }

        public void SetResult()
        {
            _pokerHand.Type = ResultType.Straight;
            _pokerHand.MaxCardNum = _pokerHand._cards.Max(c => c.Value);
        }
    }
}