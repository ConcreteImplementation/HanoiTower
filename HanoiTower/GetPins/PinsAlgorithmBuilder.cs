namespace HanoiTower
{
    class PinsAlgorithmBuilder
    {
        public static IGetPins GetAlgorithm(int nbDisks)
        {
            IDividerAlgorithm algorithm = null;
            if (nbDisks < 23) // TwoAdicAlgorithm faster at 23+ disks
                algorithm = new ModuloAlgorithm();
            else
                algorithm = new TwoAdicAlgorithm();

            IGetPins getPins = null;
            if (Numbers.IsEven(nbDisks))
                getPins = new GetPinsForEven(algorithm);
            else
                getPins = new GetPinsForOdd(algorithm);


            return getPins;
        }
    }
}
