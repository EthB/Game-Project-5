using System;
using System.IO;

using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGameWindowsStarter
{
    public class MapReader : ContentTypeReader<string>
    {
        protected override string Read(ContentReader input, string existingInstance)
        {
            
            string temp = input.ReadString();


            /*char[,] output = new char[15, 25];
            string[] str = temp.Split('\n');
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

            }*/


            Console.Write(temp);
            //Map map = new Map(output);
            return temp;
        }
    }
}
