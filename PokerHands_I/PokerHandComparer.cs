using System.Collections.Generic;

namespace PokerHands_I
{
    internal class PokerHandComparer : Comparer<PokerHand>
    {
        public override int Compare(PokerHand x, PokerHand y)
        {
            if (x.Type != y.Type)
            {
                return x.Type - y.Type;
            }

            return x.MaxCardNum - y.MaxCardNum;
        }
    }
}