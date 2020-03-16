using System;
using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content.Pipeline;

using TInput = System.String;
using TOutput = System.String;

namespace ContentExtension
{
    /// <summary>
    /// This class will be instantiated by the XNA Framework Content Pipeline
    /// to import a file from disk into the specified type, TImport.
    ///
    /// This should be part of a Content Pipeline Extension Library project.
    ///
    /// TODO: change the ContentImporter attribute to specify the correct file
    /// extension, display name, and default processor for this importer.
    /// </summary>

    [ContentImporter(".mpp", DisplayName = "Map Importer", DefaultProcessor = "MapProcessor")]
    public class MapImporter : ContentImporter<string>
    {

        public override string Import(string filename, ContentImporterContext context)
        {
            //Console.WriteLine("HELLO");

            string str = File.ReadAllText(filename);

            return str;
            
            //string output;

            //return "000111000";
            //using (var streamReader = new StreamReader(filename))
            //{
            //    var deserializer = new XmlSerializer(typeof(String));
            //    return (String)deserializer.Deserialize(streamReader);
            //}
            //using (var streamReader = new StreamReader(filename))
            //{
            //    output = streamReader.ReadToEnd();
            //}
            //Console.WriteLine("HELLO AGAIN");
            //return output;
        }
    }
}
