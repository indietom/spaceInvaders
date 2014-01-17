using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace spaceInvader
{
    class ufo : objects
    {
        Random random = new Random();
        public int direction;

        public ufo()
        {
            setSize(32,32);
            setSpriteCoords(1,1);
            direction = random.Next(1, 3);
            destroy = false;
            if (direction == 1)
            {
                setCoords(-32, 5);
            }
            else
            {
                setCoords(832, 5);
            }
        }

        public void movement()
        {
            if (direction == 1)
            {
                x += 2;
            }
            else
            {
                x -= 2;
            }
        }
    }
}
