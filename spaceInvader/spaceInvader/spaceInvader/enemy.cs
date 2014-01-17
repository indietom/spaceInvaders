using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace spaceInvader
{
    class enemy:objects
    {
        public int speed;
        public int countToStep;
        public enemy(int x2, int y2)
        {

        }
        public void movment(int speed2)
        {
            countToStep += 1;
            if (speed2 >= 50)
            {
                if (countToStep >= 32)
                {

                }
            }
        }
    }
}
