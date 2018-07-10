using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Graphics;
using Microsoft.Xna.Framework.Content.Pipeline.Processors;

namespace TextToFontExtension
{
    [ContentProcessor(DisplayName = "Characters to Font Processor")]
    public class CharactersToFontProcessor : ContentProcessor<IEnumerable<char>, SpriteFontContent>
    {
        private readonly FontDescriptionProcessor _baseProcessor;

        [DefaultValue(true)]
        public virtual bool PremultiplyAlpha { get; set; }

        [DefaultValue(typeof(TextureProcessorOutputFormat), "Compressed")]
        public virtual TextureProcessorOutputFormat TextureFormat { get; set; }

        [DefaultValue(typeof(string), "Arial")]
        public virtual string FontName { get; set; }

        [DefaultValue(12)]
        public virtual int Size { get; set; }

        [DefaultValue(0f)]
        public virtual float Spacing { get; set; }

        [DefaultValue(true)]
        public virtual bool UseKerning { get; set; }

        [DefaultValue(typeof(FontDescriptionStyle), "Regular")]
        public virtual FontDescriptionStyle Style { get; set; }

        [DefaultValue(false)]
        public virtual bool UseDefaultCharacter { get; set; }

        [DefaultValue(typeof(char), "?")]
        public virtual char DefaultCharacter { get; set; }

        public CharactersToFontProcessor()
        {
            _baseProcessor = new FontDescriptionProcessor();
        }

        public override SpriteFontContent Process(IEnumerable<char> input, ContentProcessorContext context)
        {
            var fd = new FontDescription(FontName, Size, Spacing, Style, UseKerning);
            fd.DefaultCharacter = UseDefaultCharacter ? (char?) DefaultCharacter : null;
            foreach (var c in input)
                fd.Characters.Add(c);

            _baseProcessor.PremultiplyAlpha = PremultiplyAlpha;
            _baseProcessor.TextureFormat = TextureFormat;

            return _baseProcessor.Process(fd, context);
        }
    }
}
