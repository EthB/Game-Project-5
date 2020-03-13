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
    class Wall
    {

        public Rectangle bounds;
        Texture2D texture;
        Game1 game;

        public Wall(Game1 game)
        {
            bounds = new Rectangle(120, 120, 64, 64);
            this.game = game;
        }

        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("wall");
        }

        public void Update(GameTime gameTime)
        {
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, bounds, Color.White);
        }
    }
}
