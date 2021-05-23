using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using HanoiTower;

namespace TestHanoiTower
{
    class TowerTest : Tower
    {
        public TowerTest(int nbDisks)
            :base(nbDisks)
        { ; }


        protected override void Hook()
        {
            Assert.True(Verify());
        }


       


    }
}
