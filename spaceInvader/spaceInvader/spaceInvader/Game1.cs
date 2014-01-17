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
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 5; y++)
                {
                    enemies.Add(new enemy(x * 32, y * 32));
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

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here
            player.input(bullets);
            base.Update(gameTime);
            foreach (enemy e in enemies)
            {
                e.movment(enemies.Count);
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
            }
            foreach (bullet b in bullets)
            {
                b.movement();
            }
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();
            player.drawSprite(spriteBatch, spritesheet);
            foreach (bullet b in bullets) { b.drawSprite(spriteBatch, spritesheet); }
            foreach (enemy e in enemies) { e.drawSprite(spriteBatch, spritesheet); }
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
