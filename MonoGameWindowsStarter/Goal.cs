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
    class Goal : Tile
    {
        Rectangle bounds;
        string type;
        Texture2D texture;

        public Rectangle Bounds => bounds;
        public string Type => type;
        public Goal(int i, int j)
        {
            bounds = new Rectangle(j * 32, i * 32, 32, 32);
            type = "goal";
        }

        public  void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("wall1");
        }

        public  void Update(GameTime gameTime)
        {

        }

        public  void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, bounds, Color.Red);
        }
    }
}
