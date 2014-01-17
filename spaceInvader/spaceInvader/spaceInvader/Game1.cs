using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace spaceInvader
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        Player player = new Player();
        List<bullet> bullets = new List<bullet>();
        List<enemy> enemies = new List<enemy>();
        List<ufo> ufos = new List<ufo>();
        protected override void Initialize()
        {
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 5; y++)
                {
                    enemies.Add(new enemy(x * 50, y * 40 + 32));
                }
            }
            base.Initialize();

        }

        Texture2D spritesheet;
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            spritesheet = Content.Load<Texture2D>("spritesheet");
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        public bool collision(ref Rectangle object1, ref Rectangle object2)
        {
            if (object1.Y >= object2.Y + object2.Height)
                return false;
            if (object1.X >= object2.X + object2.Width)
                return false;
            if (object1.Y + object1.Height <= object2.Y)
                return false;
            if (object1.X + object1.Width <= object2.X)
                return false;
            return true;
        }

        int amountOfAliens = 50;

        public int ufoTimer = 0;

        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here
            Rectangle bulletC;
            Rectangle enemyC;
            Rectangle ufoC;
            player.input(bullets);
            base.Update(gameTime);
            foreach (enemy e in enemies)
            {
                e.movment(amountOfAliens);
                if (e.x > 800)
                {
                    foreach (enemy e2 in enemies)
                    {
                        e2.y += 32;
                        e2.x -= 42;
                        e2.direction = 2;
                    }
                }
                if (e.x < 0)
                {
                    foreach (enemy e2 in enemies)
                    {
                        e2.y += 32;
                        e2.x += 42;
                        e2.direction = 1;
                    }
                }
                enemyC = new Rectangle(e.x, e.y, 32, 32);
                foreach (bullet b in bullets)
                {
                    bulletC = new Rectangle(b.x, b.y, 6, 6);
                    if (collision(ref bulletC, ref enemyC))
                    {
                        b.destroy = true;
                        e.destroy = true;
                        amountOfAliens -= 1;
                    }
                }
            }
            foreach (bullet b in bullets)
            {
                b.movement();
            }
            foreach (ufo u in ufos)
            {
                u.movement();
            }
            for (int i = 0; i < bullets.Count; i++)
            {
                if (bullets[i].destroy)
                {
                    bullets.RemoveAt(i);
                }
            }
            for (int i = 0; i < enemies.Count; i++)
            {
                if (enemies[i].destroy)
                {
                    enemies.RemoveAt(i);
                }
            }
            for (int i = 0; i < ufos.Count; i++)
            {
                if (ufos[i].destroy)
                {
                    ufos.RemoveAt(i);
                }
            }

            foreach (ufo u in ufos)
            {
                ufoC = new Rectangle(u.x, u.y, 32, 32);
                foreach (bullet b in bullets)
                {
                    bulletC = new Rectangle(b.x, b.y, 6, 6);
                    if (collision(ref bulletC, ref ufoC))
                    {
                        b.destroy = true;
                        u.destroy = true;
                    }
                }
            }   

            ufoTimer += 1;
            if (ufoTimer == 96)
            {
                ufos.Add(new ufo());
                ufoTimer = 0;
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();
            player.drawSprite(spriteBatch, spritesheet);
            foreach (bullet b in bullets) { b.drawSprite(spriteBatch, spritesheet); }
            foreach (enemy e in enemies) { e.drawSprite(spriteBatch, spritesheet); }
            foreach (ufo u in ufos) { u.drawSprite(spriteBatch, spritesheet); }
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
