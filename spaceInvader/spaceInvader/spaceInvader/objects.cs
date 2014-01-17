﻿using System;
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
    class objects
    {
        public int x;
        public int y;
        public int imx;
        public int imy;
        public int width;
        public int height;
        public int hp;

        public bool destroy;

        public void setCoords(int x2, int y2)
        {
            x = x2;
            y = y2;
        }
        public void setSize(int w2, int h2)
        {
            width = w2;
            height = h2;
        }
        public void setSpriteCoords(int imx2, int imy2)
        {
            imx = imx2;
            imy = imy2;
        }

        public void drawSprite(SpriteBatch spriteBatch, Texture2D spritesheet)
        {
            spriteBatch.Draw(spritesheet, new Vector2(x, y), new Rectangle(imx, imy, width, height), Color.White);
        }
    }
}
