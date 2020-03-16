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
    
    public class Map
    {
        Wall[,] walls;

        public Map(Array array)
        {
            walls = new Wall[15, 25];
            for(int i =0; i<16; i++)
            {
                for(int j=0; j<26; j++)
                {
                    if ((bool)array.GetValue(i,j) == true)
                    {
                        walls[i, j] = new Wall(i, j);
                    }
                }
            }
        }

        public void LoadContent(ContentManager content)
        {
            for (int i = 0; i < 16; i++)
            {
                for (int j = 0; j < 26; j++)
                {
                    if (walls[i, j] != null)
                    {
                        walls[i, j].LoadContent(content);
                    }
                    
                }
            }
        }

        public void Update(GameTime gameTime, Player player)
        {
            var keyboard = Keyboard.GetState();
            for (int i = 0; i < 16; i++)
            {
                for (int j = 0; j < 26; j++)
                {
                    if (walls[i, j] != null)
                    {
                        Wall tempwall = walls[i, j];

                        tempwall.Update(gameTime);
                        if (tempwall.bounds.Intersects(player.bounds))
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
                        else
                        {
                            player.up = true;
                            player.down = true;
                            player.left = true;
                            player.right = true;
                        }
                    }

                }
            }
        }

        

            


        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < 16; i++)
            {
                for (int j = 0; j < 26; j++)
                {
                        if (walls[i, j] != null)
                        {
                            walls[i, j].Draw(spriteBatch);
                        }

                }
            }
        }

    }
}
