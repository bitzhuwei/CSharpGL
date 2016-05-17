using System;
using System.Collections.Generic;
using System.IO;

namespace SharpFont
{
    /// <summary>
    /// Maintains a collection of fonts.
    /// </summary>
    public sealed class FontCollection
    {
        static FontCollection systemFonts;
        readonly Dictionary<string, List<Metadata>> fontTable = new Dictionary<string, List<Metadata>>();

        /// <summary>
        /// The system font collection.
        /// </summary>
        public static FontCollection SystemFonts
        {
            get
            {
                if (systemFonts == null)
                    systemFonts = LoadSystemFonts();
                return systemFonts;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FontCollection"/> class.
        /// </summary>
        public FontCollection()
        {
        }

        /// <summary>
        /// Adds a font to the collection.
        /// </summary>
        /// <param name="stream">A stream pointing to the font file.</param>
        public void AddFontFile(Stream stream)
        {
            var metadata = LoadMetadata(stream);
            metadata.Stream = stream;
            AddFile(metadata, throwOnError: true);
        }

        /// <summary>
        /// Adds a font to the collection.
        /// </summary>
        /// <param name="fileName">The path to the font file.</param>
        //public void AddFontFile (string fileName) => AddFontFile(fileName, throwOnError: true);
        public void AddFontFile(string fileName)
        {
            AddFontFile(fileName, throwOnError: true);
        }

        /// <summary>
        /// Finds a font in the collection that matches the given parameters.
        /// </summary>
        /// <param name="family">The font family name.</param>
        /// <param name="weight">The font weight.</param>
        /// <param name="stretch">The font stretch setting.</param>
        /// <param name="style">The font style.</param>
        /// <returns>The loaded font if it exists in the collection; otherwise, <c>null</c>.</returns>
        public FontFace Load(string family, FontWeight weight = FontWeight.Normal, FontStretch stretch = FontStretch.Normal, FontStyle style = FontStyle.Regular)
        {
            List<Metadata> sublist;
            if (!fontTable.TryGetValue(family.ToLowerInvariant(), out sublist))
                return null;

            foreach (var file in sublist)
            {
                if (file.Weight == weight && file.Stretch == stretch && file.Style == style)
                {
                    if (file.Stream != null)
                        return new FontFace(file.Stream);
                    else
                    {
                        using (var stream = File.OpenRead(file.FileName))
                            return new FontFace(stream);
                    }
                }
            }

            return null;
        }

        void AddFontFile(string fileName, bool throwOnError)
        {
            using (var stream = File.OpenRead(fileName))
            {
                var metadata = LoadMetadata(stream);
                metadata.FileName = fileName;
                AddFile(metadata, throwOnError);
            }
        }

        void AddFile(Metadata metadata, bool throwOnError)
        {
            // specifically ignore fonts with no family name
            if (string.IsNullOrEmpty(metadata.Family))
            {
                if (throwOnError)
                    throw new InvalidFontException("Font does not contain any name metadata.");
                else
                    return;
            }

            List<Metadata> sublist;
            var key = metadata.Family.ToLowerInvariant();
            if (fontTable.TryGetValue(key, out sublist))
                sublist.Add(metadata);
            else
                fontTable.Add(key, new List<Metadata> { metadata });
        }

        static FontCollection LoadSystemFonts()
        {
            // TODO: currently only supports Windows
            var collection = new FontCollection();
            foreach (var file in Directory.EnumerateFiles(Environment.GetFolderPath(Environment.SpecialFolder.Fonts)))
            {
                if (SupportedExtensions.Contains(Path.GetExtension(file).ToLowerInvariant()))
                    collection.AddFontFile(file, throwOnError: false);
            }

            return collection;
        }

        static Metadata LoadMetadata(Stream stream)
        {
            using (var reader = new DataReader(stream))
            {
                var tables = SfntTables.ReadFaceHeader(reader);
                var names = SfntTables.ReadNames(reader, tables);
                var os2Data = SfntTables.ReadOS2(reader, tables);

                return new Metadata
                {
                    Family = names.TypographicFamilyName ?? names.FamilyName,
                    Weight = os2Data.Weight,
                    Stretch = os2Data.Stretch,
                    Style = os2Data.Style
                };
            }
        }

        class Metadata
        {
            public string Family;
            public FontWeight Weight;
            public FontStretch Stretch;
            public FontStyle Style;
            public Stream Stream;
            public string FileName;
        }

        static readonly HashSet<string> SupportedExtensions = new HashSet<string> {
            ".ttf", ".otf"
        };
    }
}
