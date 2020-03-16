using System;
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
            var temp = input.ReadString();
            return temp;
        }
    }
}
