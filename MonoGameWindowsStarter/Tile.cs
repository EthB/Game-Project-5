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
    public interface Tile
    {
        Rectangle Bounds { get; }
        string Type { get; }


         void Update(GameTime gametime);

        void LoadContent(ContentManager content);

        void Draw(SpriteBatch spriteBatch);
        /*public virtual void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("wall1");
        }

        public virtual void Update(GameTime gameTime)
        {

        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, bounds, Color.White);
        }*/
    }
}
