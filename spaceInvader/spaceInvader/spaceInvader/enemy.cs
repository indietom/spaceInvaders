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
        public int direction;
        public enemy(int x2, int y2)
        {
            setSize(32, 32);
            setSpriteCoords(1, 1);
            setCoords(x2, y2);
            direction = 1;
            countToStep = 0;
        }
        public void movment(int speed2)
        {
            countToStep += 1;
            if (speed2 <= 50)
            {
                if (countToStep >= 32*5)
                {
                    if (direction == 1)
                    {
                        x += 3;
                    }
                    else
                    {
                        x -= 3;
                    }
                }
            }
        }
    }
}
