using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace spaceInvader
{
    class bullet : objects
    {
        public bullet(int x2, int y2)
        {
            setCoords(x2, y2);
            setSize(6,6);
            setSpriteCoords(1, 27);
        }

        public void movement()
        {
            y -= 11;
        }
    }
}
