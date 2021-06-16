namespace HanoiTower
{
    class GetPinsForOdd : IGetPins
    {
        IDividerAlgorithm algorithm;


        public GetPinsForOdd(IDividerAlgorithm algorithm)
        {
            this.algorithm = algorithm;
        }



        public int GetFromPin(int move)
        {
            switch (move % 6)
            {
                case 1:
                    return 0;
                case 2:
                    return algorithm.IsDivider(move) ? 0 : 1;
                case 3:
                    return 2;
                case 4:
                    return algorithm.IsDivider(move) ? 2 : 0;
                case 5:
                    return 1;
                default: // Case 0
                    return algorithm.IsDivider(move) ? 1 : 2;
            }
        }
        public int GetToPin(int move, int from)
        {
            switch (move % 3)
            {
                case 0:
                    return from ^ 3;
                case 1:
                    return from ^ 2;
                default: // case 2
                    return from ^ 1;
            }
        }



    }
}
