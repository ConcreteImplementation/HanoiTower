namespace HanoiTower
{
    class ModuloAlgorithm : IDividerAlgorithm
    {
        public bool IsDivider(int move)
        {
            int mod = 4;
            while (move % mod == 0)
                mod *= 4;

            if (move % mod == mod / 2)
                return true;
            return false;
        }
    }
}
