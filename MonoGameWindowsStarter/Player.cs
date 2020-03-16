using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace MonoGameWindowsStarter
{
    public class Player
    {

        public Rectangle bounds;
        Texture2D texture;
        Game1 game;
        int speed = 5;
        public bool right;
        public bool left;
        public bool down;
        public bool up;



        public Player(Game1 game)
        {
            bounds = new Rectangle(64, 64, 64, 64);
            this.game = game;
            
        }

        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("player");
            up = true;
            down = true;
            left = true;
            right = true;
        }

        public void Update(GameTime gameTime)
        {
            var keyboard = Keyboard.GetState();

            if (keyboard.IsKeyDown(Keys.Left))
            {

                if (bounds.X > 0 && left)
                {
                    bounds.X -= speed;
                }

            }
            else if (keyboard.IsKeyDown(Keys.Right))
            {

                if (bounds.X + bounds.Width < game.GraphicsDevice.Viewport.Width && right)
                {
                    bounds.X += speed;
                }

            }
            else if (keyboard.IsKeyDown(Keys.Up) && up)
            {
                if (bounds.Y > 0)
                {
                    bounds.Y -= speed;
                }

            }
            else if (keyboard.IsKeyDown(Keys.Down) && down)
            {
                if (bounds.Y < game.GraphicsDevice.Viewport.Height - bounds.Height)
                {
                    bounds.Y += speed;
                }
            }

            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            
            spriteBatch.Draw(texture, bounds, Color.White);
        }
    }
}
