using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Graphics;
using TInput = System.String;
using TOutput = System.String;

namespace TextToFontExtension
{
    [ContentImporter(".txt", DisplayName = "Character Importer", DefaultProcessor = "CharacterToFontProcessor")]
    public class CharacterImporter : ContentImporter<IEnumerable<char>>
    {
        public override IEnumerable<char> Import(string filename, ContentImporterContext context)
        {
            var text = File.ReadAllText(filename);
            return text.Distinct();
        }
    }
}
