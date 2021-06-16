using System;
using System.Collections.Generic;
using System.Text;

namespace HanoiTower
{
    class TowerVerify : TowerDescribe
    {
        public TowerVerify(int nbDisks, int wait)
            : base(nbDisks, wait)
        { ; }


        protected override void Hook()
        {
            base.Hook();

            if (Verify() == false)
                throw new InvalidOperationException("Disk out of order");
        }

    }
}
