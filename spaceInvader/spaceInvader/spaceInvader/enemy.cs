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
            destroy = false;
            countToStep = 0;
        }
        public void movment(int speed2)
        {
            countToStep += 1;
            if (speed2 <= 50)
            {
                if (countToStep >= 32)
                {
                    if (direction == 1)
                    {
                        x += 10;
                    }
                    else
                    {
                        x -= 10;
                    }
                    countToStep = 0;
                }
            }

            if (speed2 <= 25)
            {
                if (countToStep >= 16)
                {
                    if (direction == 1)
                    {
                        x += 10;
                    }
                    else
                    {
                        x -= 10;
                    }
                    countToStep = 0;
                }
            }
            if (speed2 <= 5)
            {
                if (countToStep >= 9)
                {
                    if (direction == 1)
                    {
                        x += 10;
                    }
                    else
                    {
                        x -= 10;
                    }
                    countToStep = 0;
                }
            }
            if (speed2 <= 2)
            {
                if (countToStep >= 1)
                {
                    if (direction == 1)
                    {
                        x += 10;
                    }
                    else
                    {
                        x -= 10;
                    }
                    countToStep = 0;
                }
            }
        }
    }
}
