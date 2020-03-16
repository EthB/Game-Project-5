using System;
using System.IO;
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
        public Tile[,] walls;

        public Map(string input)
        {
            char[,] output = new char[15, 25];
            string[] str = input.Split('\n');
            for (int i = 0; i < 15; i++)
            {
                char[] b = new char[str[i].Length];
                using (StringReader sr = new StringReader(str[i]))
                {
                    sr.Read(b, 0, 25);

                }
                for (int j = 0; j < 25; j++)
                {

                    //output[i, j] = Convert.ToBoolean(int.Parse(b[j].ToString()));
                    output[i, j] = b[j];
                    //Console.WriteLine("TEST");
                    Console.Write(output[i, j]);


                }
                //Console.WriteLine(b.Length);

            }


            walls = new Tile[15, 25];
            for(int i =0; i<15; i++)
            {
                for(int j=0; j<25; j++)
                {
                    if (output[i,j].Equals('1'))
                    {
                        walls[i, j] = new Wall(i, j);
                    }
                    else if (output[i, j].Equals('2'))
                    {
                        walls[i, j] = new Goal(i, j);
                    }
                }
            }
        }

        public void LoadContent(ContentManager content)
        {
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 25; j++)
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
            
        }

        

            


        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 25; j++)
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
