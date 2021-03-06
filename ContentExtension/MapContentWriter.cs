﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Graphics;
using Microsoft.Xna.Framework.Content.Pipeline.Processors;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Compiler;

using TInput = System.String;
using TOutput = System.String;

namespace ContentExtension
{
    [ContentTypeWriter]
    public class MapContentWriter : ContentTypeWriter<MapContent>
    {
        protected override void Write(ContentWriter output, MapContent value)
        {
            //output.Write(value); 
            //Console.WriteLine("Testing here too");
            output.Write(value.source);
            //Console.WriteLine("And here as well");

        }

        //public override string GetRuntimeType(TargetPlatform targetPlatform)
        //{
        //    return typeof(MapContent).AssemblyQualifiedName;
        //}

        public override string GetRuntimeReader(TargetPlatform targetPlatform)
        {
            return "MonoGameWindowsStarter.MapReader, MonoGameWindowsStarter";
        }
    }
}