using System.Numerics;

namespace HanoiTower
{
    class TwoAdicAlgorithm : IDividerAlgorithm
    {
        public bool IsDivider(int move)
            => Numbers.IsEven(BitOperations.TrailingZeroCount(move)) ? false : true;
    }
}
