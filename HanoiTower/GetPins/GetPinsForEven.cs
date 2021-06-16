namespace HanoiTower
{
    class GetPinsForEven : IGetPins
    {
        IDividerAlgorithm algorithm;



        public GetPinsForEven(IDividerAlgorithm algorithm)
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
                    return algorithm.IsDivider(move) ? 0 : 2;
                case 3:
                    return 1;
                case 4:
                    return algorithm.IsDivider(move) ? 1 : 0;
                case 5:
                    return 2;
                default: // Case 0
                    return algorithm.IsDivider(move) ? 2 : 1;
            }
        }
        public int GetToPin(int move, int from)
        {
            switch (move % 3)
            {
                case 0:
                    return from ^ 3;
                case 1:
                    return from ^ 1;
                default: // case 2
                    return from ^ 2;
            }
        }



    }
}
