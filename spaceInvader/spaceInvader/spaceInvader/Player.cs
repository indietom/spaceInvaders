using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace spaceInvader
{
    class Player : objects
    {
        public int guntype;

        public Player()
        {
            setCoords(1,1);
            setSize(32, 32);
            setSpriteCoords(1, 1);
            hp = 3;
            guntype = 1;

        }

        public void input(List<bullet> bullets)
        {
            KeyboardState keyboard = Keyboard.GetState();
            if (keyboard.IsKeyDown(Keys.Left))
            {
                x = -5;
            }
            if (keyboard.IsKeyDown(Keys.Right))
            {
                x = +5;
            }
            if (keyboard.IsKeyDown(Keys.X) && guntype == 1)
            {
                bullets.Add(new bullet(x + 16, y + 16));
            }
        }
    }
}
