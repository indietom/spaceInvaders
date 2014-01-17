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
        public bool keyFalse;

        public Player()
        {
            setCoords(400, 400);
            setSize(32, 32);
            setSpriteCoords(1, 1);
            hp = 3;
            guntype = 1;
            keyFalse = false;
        }

        public void input(List<bullet> bullets)
        {
            KeyboardState keyboard = Keyboard.GetState();
            if (keyboard.IsKeyDown(Keys.Left))
            {
                x -= 5;
            }
            if (keyboard.IsKeyDown(Keys.Right))
            {
                x += 5;
            }
            if (keyboard.IsKeyDown(Keys.X) && guntype == 1 && !keyFalse)
            {
                bullets.Add(new bullet(x + 16, y + 16));
                keyFalse = true;
            }
            if (keyFalse)
            {
                if (keyboard.IsKeyUp(Keys.X))
                {
                    keyFalse = false;
                }
            }
        }
    }
}
