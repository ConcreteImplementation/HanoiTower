using System;
using Xunit;

namespace TestHanoiTower
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            for(int i = 1; i < 20; i++)
            {
                TowerTest tower = new TowerTest(i);
                tower.Solve();

                Assert.True(tower.IsSolved());
            }

        }
    }
}
