using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;

namespace HanoiTower
{
	public class Tower
	{
		Stack<int>[] pins;
		int nbDisks;

		int from;
		int to;
		int move;

        IGetPins getPins;


        public Tower(int nbDisk)
		{
			if (nbDisk < 1)
				throw new ArgumentOutOfRangeException("Tower must contain at least one disk");

			this.nbDisks = nbDisk;

			from = 0;
			to = 0;
			move = 0;

            getPins = PinsAlgorithmBuilder.GetAlgorithm(nbDisk);


            pins = new Stack<int>[]
			{
				new Stack<int>(),
				new Stack<int>(),
				new Stack<int>()
			};
			while (nbDisk > 0)
				pins[0].Push(nbDisk--);

		}



		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();

			sb.Append($"Move #{move,-10}From: {from,-5}To: {to}\n");

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

			int maxNumberOfMove = (int) Math.Pow(2, nbDisks);
			move = 1;

			while (move < maxNumberOfMove)
			{
				from = getPins.GetFromPin(move);
				to = getPins.GetToPin(move, from);

				pins[to].Push(pins[from].Pop());

				Hook();

				move++;
			}
		}

		protected virtual void Hook()
		{ ; }




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
