using System;
using System.Collections.Generic;
using System.Text;

namespace HanoiTower
{
    public class Tower
    {
        Stack<int>[] pins;
        int nbDisk;

        int from;
        int to;
        int nbMove;

        Func<int> GetFromPin;
        Func<int> GetToPin;

        public Tower(int nbDisk)
        {
            if (nbDisk < 1)
                throw new ArgumentOutOfRangeException("Tower must contain at least one disk");

            this.nbDisk = nbDisk;

            from = 0;
            to = 0;
            nbMove = 0;


            if (IsEven(nbDisk))
            {
                GetFromPin = GetFromPinForEven;
                GetToPin = GetToPinForEven ;
            }
            else
            {
                GetFromPin = GetFromPinForOdd;
                GetToPin = GetToPinForOdd;
            }


            pins = new Stack<int>[]
            {
                new Stack<int>(),
                new Stack<int>(),
                new Stack<int>()
            };
            while (nbDisk > 0)
            {
                pins[0].Push(nbDisk--);
            }
        }

        bool IsEven(int x) => x % 2 == 0;



        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"Move #{nbMove,-10}From: {from,-5}To: {to}\n");

            for (int i = 0; i < pins.Length; i++)
            {
                sb.Append($"Pin # {i}\n\t|-");

                Stack<int> tempPin = new Stack<int>(pins[i]);

                foreach (int x in tempPin)
                {
                    sb.Append($" {x} - ");
                }
                sb.Append("\n");
            }
            return sb.ToString();
        }






        public void Solve()
        {
            if (IsSolved())
                throw new InvalidOperationException("Tower already solved");

            int maxNumberOfMove = (int) Math.Pow(2, nbDisk);
            nbMove = 1;

            while (nbMove < maxNumberOfMove)
            {
                from = GetFromPin();
                to = GetToPin();

                pins[to].Push(pins[from].Pop());

                Hook();

                nbMove++;
            }
        }

        protected virtual void Hook()
        { ; }




        int GetToPinForOdd()
        {
            switch (nbMove % 3)
            {
                case 0:
                    return from ^ 3;
                case 1:
                    return from ^ 2;
                default: // case 2
                    return from ^ 1;
            }
        }
        int GetToPinForEven()
        {
            switch (nbMove % 3)
            {
                case 0:
                    return from ^ 3;
                case 1:
                    return from ^ 1;
                default: // case 2
                    return from ^ 2;
            }
        }



        int GetFromPinForOdd()
        {
            switch (nbMove % 6)
            {
                case 1:
                    return 0;
                case 2:
                    return IsDivider () ? 0 : 1;
                case 3:
                    return 2;
                case 4:
                    return IsDivider() ? 2 : 0;
                case 5:
                    return 1;
                default: // Case 0
                    return IsDivider() ? 1 : 2;
            }
        }
        int GetFromPinForEven()
        {
            switch (nbMove % 6)
            {
                case 1:
                    return 0;
                case 2:
                    return IsDivider() ? 0 : 2;
                case 3:
                    return 1;
                case 4:
                    return IsDivider() ? 1 : 0;
                case 5:
                    return 2;
                default: // Case 0
                    return IsDivider() ? 2 : 1;
            }
        }



        bool IsDivider()
        {
            int mod = 4;
            while (nbMove % mod == 0)
                mod *= 4;

            if (nbMove % mod == mod / 2)
                return true;
            return false;
        }




        

        public bool IsSolved() => pins[0].Count == 0 && pins[1].Count == 0;
        public bool Verify()
        {
            foreach (Stack<int> pin in pins)
            {
                int prevDisk = 0;
                foreach (int disk in pin)
                {
                    if (prevDisk > disk)
                        return false;

                    prevDisk = disk;
                }
            }

            return true;
        }


    }
}
