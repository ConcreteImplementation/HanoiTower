using System;
using System.Text;
using System.IO;
using System.Diagnostics;



namespace HanoiTower
{
    class Program
    {
        static void Main(string[] args)
        {
            int disks = 7;
            int wait = 500;
            TowerDescribe tower = new TowerVerify(disks, wait);
            tower.Solve();

            //TicksCount();
        }


        static void TicksCount()
        {
            Stopwatch chronometre = new Stopwatch();
            long tick = 0;
            
            StringBuilder csv = new StringBuilder("NbDisks,Ticks\n");

            for (int disks = 1; disks <= 30; disks++)
            {
                Console.Write($"Solving {disks,-4} disks");

                Tower tower = new Tower(disks);

                chronometre.Restart();
                tower.Solve();
                chronometre.Stop();

                tick = chronometre.ElapsedTicks;

                csv.Append($"{disks},{tick}\n");

                Console.WriteLine($"\t{tick,-10}");
            }

            
            StreamWriter csvFile = new StreamWriter($"TickCount-{DateTime.Now.ToString("dd-MM-yyyy--hh-mm-ss")}.csv");
            csvFile.Write(csv.ToString());
            csvFile.Close();
        }




    }
}
