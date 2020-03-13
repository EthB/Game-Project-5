using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace MonoGameWindowsStarter
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Player player;
        Wall[,] walls;
        

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            player = new Player(this);
            walls = new Wall[64,64];
            walls[0, 0] = new Wall(this);
            // TODO: use this.Content to load your game content here
            player.LoadContent(Content);
            //load wallmap into walls list
            foreach(Wall w in walls)
            {
                if (w != null)
                {
                    w.LoadContent(Content);
                }
            }
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
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
            var keyboard = Keyboard.GetState();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            player.Update(gameTime);
            foreach(Wall w in walls)
            {
                if (w != null)
                {
                    w.Update(gameTime);
                    if (w.bounds.Intersects(player.bounds))
                    {
                        if (keyboard.IsKeyDown(Keys.Up))
                        {
                            player.up = false;
                            player.bounds.Y += 1;
                        }
                        else { player.up = true; }
                        if (keyboard.IsKeyDown(Keys.Down))
                        {
                            player.down = false;
                            player.bounds.Y -= 1;
                        }
                        else { player.down = true; }
                        if (keyboard.IsKeyDown(Keys.Left))
                        {
                            player.left = false;
                            player.bounds.X += 1;
                        }
                        else { player.left = true; }
                        if (keyboard.IsKeyDown(Keys.Right))
                        {
                            player.right = false;
                            player.bounds.X -= 1;
                        }
                        else { player.right = true; }
                    }
                    else { player.up = true;
                        player.down = true;
                        player.left = true;
                        player.right = true;
                    }
                }

            }


            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            // TODO: Add your drawing code here
            player.Draw(spriteBatch);
            foreach(Wall w in walls)
            {
                if (w != null)
                {
                    w.Draw(spriteBatch);
                }
            }
            base.Draw(gameTime);

            spriteBatch.End();
        }
    }
}
