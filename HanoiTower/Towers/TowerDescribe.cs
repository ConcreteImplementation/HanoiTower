using System;

using System.Threading;

namespace HanoiTower
{
    class TowerDescribe : Tower
    {
        int wait;
        public TowerDescribe(int nbDisks, int wait)
            :base(nbDisks)
        { 
            this.wait = wait; 
        }


        protected override void Hook()
        {
            Console.Clear();
            Console.WriteLine(this);

            if (Console.KeyAvailable)
            {
                Console.ReadKey(false);
                Console.WriteLine("P A U S E D ");
                Console.ReadKey(false);
            }

            Thread.Sleep(wait);
        }

    }
}
