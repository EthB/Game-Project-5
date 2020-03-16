using System;
using System.IO;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Graphics;

//using TInput = ContentExtension.MapContent;
//using TOutput = ContentExtension.MapContent;
using TInput = System.String;
using TOutput = System.String;

namespace ContentExtension
{
    [ContentProcessor(DisplayName = "MapProcessor")]
    public class MapProcessor : ContentProcessor<TInput, TOutput>
    {
        /// <summary>
        /// Processes the raw .tsx XML and creates a TilesetContent
        /// for use in an XNA framework game
        /// </summary>
        /// <param name="input">The XML string</param>
        /// <param name="context">The pipeline context</param>
        /// <returns>A TilesetContent instance corresponding to the tsx input</returns>
        public override TOutput Process(TInput input, ContentProcessorContext context)
        {
            return input;

            /*char[,] output = new char[15, 25];
            string[] str = input.Split('\n');



            //char[] b = new char[str.Length];

            //using (StringReader sr = new StringReader(str))
            //{
            //    // Read 13 characters from the string into the array.
            //    sr.Read(b, 0, 13);
            //    Console.WriteLine(b);

            //    // Read the rest of the string starting at the current string position.
            //    // Put in the array starting at the 6th array member.
            //    sr.Read(b, 5, str.Length - 13);
            //    Console.WriteLine(b);
            //}

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
            //Console.Write(output.ToString());
            Console.Write(input);
            return input;*/
        }
    }
}
