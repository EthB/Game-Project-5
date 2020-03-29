using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        //Wall[,] walls;
        string mapArray;
        Map map;
        SpriteFont bigFont;
        SpriteFont timeFont;
        bool win;
        double time;

        ParticleSystem fireParticle;
        ParticleSystem collisionParticle;
        ParticleSystem rainParticle;
        Texture2D particleTexture;
        Random random = new Random();


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
            win = false;
            spriteBatch = new SpriteBatch(GraphicsDevice);
            bigFont = Content.Load<SpriteFont>("bigFont");
            timeFont = Content.Load<SpriteFont>("timeFont");
            player = new Player(this);
            mapArray = Content.Load<string>("map");
            map = new Map(mapArray);
            //map = new Map(mapArray);
            // TODO: use this.Content to load your game content here
            player.LoadContent(Content);
            //load wallmap into walls list
            //foreach(Wall w in walls)
            //{
            //    if (w != null)
            //    {
            //        w.LoadContent(Content);
            //    }
            //}
            map.LoadContent(Content);
            time = 0;

            //load particleSystem content
            particleTexture = Content.Load<Texture2D>("particle");
            fireParticle = new ParticleSystem(this.GraphicsDevice, 1000, particleTexture);

            // Set the SpawnParticle method
            fireParticle.SpawnParticle = (ref Particle particle) =>
            {
                MouseState mouse = Mouse.GetState();
                particle.Position = new Vector2(-10, -10);
                particle.Velocity = new Vector2(
                    MathHelper.Lerp(-5, 5, (float)random.NextDouble()), // X between -50 and 50
                    MathHelper.Lerp(0, -100, (float)random.NextDouble()) // Y between 0 and 100
                    );
                particle.Acceleration = 0.1f * new Vector2(0, (float)-random.NextDouble());
                particle.Color = Color.Red;
                particle.Scale = 1f;
                particle.Life = 0.3f;
            };

            // Set the UpdateParticle method
            fireParticle.UpdateParticle = (float deltaT, ref Particle particle) =>
            {
                particle.Velocity += deltaT * particle.Acceleration;
                particle.Position += deltaT * particle.Velocity;
                particle.Scale -= deltaT;
                particle.Life -= deltaT;
            };

            fireParticle.Emitter = new Vector2(100, 100);
            fireParticle.SpawnPerFrame = 4;



            collisionParticle = new ParticleSystem(this.GraphicsDevice, 1000, particleTexture);

            // Set the SpawnParticle method
            collisionParticle.SpawnParticle = (ref Particle particle) =>
            {
                MouseState mouse = Mouse.GetState();
                particle.Position = new Vector2(-10, -10);
                particle.Velocity = new Vector2(
                    MathHelper.Lerp(-5, 5, (float)random.NextDouble()), // X between -50 and 50
                    MathHelper.Lerp(0, -100, (float)random.NextDouble()) // Y between 0 and 100
                    );
                particle.Acceleration = 0.1f * new Vector2(0, (float)-random.NextDouble());
                particle.Color = Color.Red;
                particle.Scale = 1f;
                particle.Life = 0.3f;
            };

            // Set the UpdateParticle method
            collisionParticle.UpdateParticle = (float deltaT, ref Particle particle) =>
            {
                particle.Velocity += deltaT * particle.Acceleration;
                particle.Position += deltaT * particle.Velocity;
                particle.Scale -= deltaT;
                particle.Life -= deltaT;
            };

            collisionParticle.Emitter = new Vector2(100, 100);
            collisionParticle.SpawnPerFrame = 8;


            rainParticle = new ParticleSystem(this.GraphicsDevice, 1000, particleTexture);

            // Set the SpawnParticle method
            rainParticle.SpawnParticle = (ref Particle particle) =>
            {
                MouseState mouse = Mouse.GetState();
                particle.Position = new Vector2(MathHelper.Lerp(0,800, (float)random.NextDouble()), 0);
                particle.Velocity = new Vector2(
                    0,
                    MathHelper.Lerp(0, 200, (float)random.NextDouble()) // Y between 0 and 100
                    );
                particle.Acceleration = 0.1f * new Vector2(0, (float)-random.NextDouble());
                particle.Color = Color.Blue;
                particle.Scale = .4f;
                particle.Life = 5f;
            };

            // Set the UpdateParticle method
            rainParticle.UpdateParticle = (float deltaT, ref Particle particle) =>
            {
                particle.Velocity += deltaT * particle.Acceleration;
                particle.Position += deltaT * particle.Velocity;
                
                particle.Life -= deltaT;
            };

            rainParticle.Emitter = new Vector2(100, 100);
            rainParticle.SpawnPerFrame = 5;


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
            rainParticle.Update(gameTime);
            fireParticle.Update(gameTime);
            collisionParticle.Update(gameTime);
            //var keyboard = Keyboard.GetState();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (!win)
            {
                time = gameTime.TotalGameTime.TotalSeconds;
                time = Math.Truncate(time * 1000) / 1000;
            }
            // TODO: Add your update logic here
            //map.Update(gameTime, player);

            var keyboard = Keyboard.GetState();
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 25; j++)
                {
                    if (map.walls[i, j] != null)
                    {
                        //Tile tempwall = map.walls[i, j];

                        map.walls[i,j].Update(gameTime);
                        if (map.walls[i, j].Bounds.Intersects(player.bounds))
                        {

                            if (player.moving)
                            {
                                collisionParticle.SpawnPerFrame = 10;
                                collisionParticle.SpawnParticle = (ref Particle particle) =>
                                {
                                    MouseState mouse = Mouse.GetState();
                                    particle.Position = new Vector2(player.bounds.X + 8, player.bounds.Y + 8);
                                    if (player.direction == 0)
                                    {
                                        particle.Velocity = new Vector2(
                                            MathHelper.Lerp(0, 100, (float)random.NextDouble()), // X between -50 and 50
                                            MathHelper.Lerp(100, -100, (float)random.NextDouble()) // Y between 0 and 100
                                            );
                                    }
                                    else if (player.direction == 1)
                                    {
                                        particle.Velocity = new Vector2(
                                            MathHelper.Lerp(-100, 100, (float)random.NextDouble()), // X between -50 and 50
                                            MathHelper.Lerp(0, 100, (float)random.NextDouble()) // Y between 0 and 100
                                            );
                                    }
                                    else if (player.direction == 2)
                                    {
                                        particle.Velocity = new Vector2(
                                            MathHelper.Lerp(0, -100, (float)random.NextDouble()), // X between -50 and 50
                                            MathHelper.Lerp(100, -100, (float)random.NextDouble()) // Y between 0 and 100
                                            );
                                    }
                                    else if (player.direction == 3)
                                    {
                                        particle.Velocity = new Vector2(
                                            MathHelper.Lerp(-100, 100, (float)random.NextDouble()), // X between -50 and 50
                                            MathHelper.Lerp(0, -100, (float)random.NextDouble()) // Y between 0 and 100
                                            );
                                    }
                                    particle.Acceleration = 0.1f * new Vector2(0, (float)-random.NextDouble());
                                    particle.Color = Color.Gold;
                                    particle.Scale = 1f;
                                    particle.Life = 0.3f;
                                };
                            }
                            else
                            {
                                collisionParticle.SpawnParticle = (ref Particle particle) =>
                                {
                                    MouseState mouse = Mouse.GetState();
                                    particle.Position = new Vector2(-10, -10);
                                    
                                        particle.Velocity = new Vector2(
                                            MathHelper.Lerp(0, 100, (float)random.NextDouble()), // X between -50 and 50
                                            MathHelper.Lerp(100, -100, (float)random.NextDouble()) // Y between 0 and 100
                                            );
                                    
                                    particle.Acceleration = 0.1f * new Vector2(0, (float)-random.NextDouble());
                                    particle.Color = Color.Gold;
                                    particle.Scale = 1f;
                                    particle.Life = 0.3f;
                                };
                                collisionParticle.SpawnPerFrame = 0;
                            }
                            if (map.walls[i, j].Type.Equals("wall"))
                            {
                                player.moving = false;

                                if (player.direction == 0)
                                {
                                    player.bounds.X += 1;
                                }
                                else if (player.direction == 1)
                                {
                                    player.bounds.Y += 1;
                                }
                                else if (player.direction == 2)
                                {
                                    player.bounds.X -= 1;
                                }
                                else if (player.direction == 3)
                                {
                                    player.bounds.Y -= 1;
                                }
                            }
                            else if (map.walls[i, j].Type.Equals("goal"))
                            {
                                win = true;
                            }
                            else if (map.walls[i, j].Type.Equals("FirePowerup"))
                            {
                                player.speed = 10;
                                fireParticle.SpawnParticle = (ref Particle particle) =>
                                {
                                    MouseState mouse = Mouse.GetState();
                                    particle.Position = new Vector2(player.bounds.X + 8, player.bounds.Y + 8);
                                    particle.Velocity = new Vector2(
                                        MathHelper.Lerp(-5, 5, (float)random.NextDouble()), // X between -50 and 50
                                        MathHelper.Lerp(0, -100, (float)random.NextDouble()) // Y between 0 and 100
                                        );
                                    particle.Acceleration = 0.1f * new Vector2(0, (float)-random.NextDouble());
                                    particle.Color = Color.Red;
                                    particle.Scale = 1f;
                                    particle.Life = 0.3f;
                                };
                                map.walls[i, j] = null;
                            }

                            /*if (keyboard.IsKeyDown(Keys.Up))
                            {
                                player.up = false;
                                //player.bounds.Y += 1;
                            }
                            //else { player.up = true; }
                            if (keyboard.IsKeyDown(Keys.Down))
                            {
                                player.down = false;
                                //player.bounds.Y -= 1;
                            }
                            //else { player.down = true; }
                            if (keyboard.IsKeyDown(Keys.Left))
                            {
                                player.left = false;
                                //player.bounds.X += 1;
                            }
                            //else { player.left = true; }
                            if (keyboard.IsKeyDown(Keys.Right))
                            {
                                player.right = false;
                                //player.bounds.X -= 1;
                            }
                            //else { player.right = true; }*/
                        }
                        /*else
                        {
                            player.up = true;
                            player.down = true;
                            player.left = true;
                            player.right = true;
                            player.color = Color.Yellow;
                        }*/
                    }

                }
            }


            player.Update(gameTime);

            

            


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
            fireParticle.Draw();
            collisionParticle.Draw();
            rainParticle.Draw();
            player.Draw(spriteBatch);
            map.Draw(spriteBatch);
            
            if (win)
            {
                spriteBatch.DrawString(bigFont, "YOU WIN", new Vector2(300, 200), Color.White);
            }
            spriteBatch.DrawString(timeFont, "Time: " + time.ToString(), new Vector2(34, 34), Color.White) ;

            base.Draw(gameTime);

            spriteBatch.End();
        }
    }
}
