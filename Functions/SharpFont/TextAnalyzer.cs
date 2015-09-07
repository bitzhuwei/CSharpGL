using System;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.InteropServices;

namespace SharpFont
{
    public interface IGlyphAtlas
    {
        int Width { get; }
        int Height { get; }

        void Insert(int page, int x, int y, int width, int height, IntPtr data);
    }

    public unsafe sealed class TextAnalyzer
    {
        [ThreadStatic]
        static MemoryBuffer memoryBuffer;

        IGlyphAtlas atlas;
        BinPacker packer;
        Dictionary<CacheKey, CachedFace> cache;
        ResizableArray<BufferEntry> buffer;
        int currentPage;

        public int Dpi
        {
            get;
            set;
        }

        public TextAnalyzer(IGlyphAtlas atlas)
        {
            this.atlas = atlas;
            Dpi = 96;
            cache = new Dictionary<CacheKey, CachedFace>(CacheKey.Comparer);
            packer = new BinPacker(atlas.Width, atlas.Height);
            buffer = new ResizableArray<BufferEntry>(32);
        }

        //public void Clear () => buffer.Clear();
        public void Clear()
        {
            buffer.Clear();
        }

        //public void AppendText (string text, TextFormat format) => AppendText(text, 0, text.Length, format);
        public void AppendText(string text, TextFormat format)
        {
            AppendText(text, 0, text.Length, format);
        }

        public void AppendText(string text, int startIndex, int count, TextFormat format)
        {
            fixed (char* ptr = text)
                AppendText(ptr + startIndex, count, format);
        }

        public void AppendText(char[] text, int startIndex, int count, TextFormat format)
        {
            fixed (char* ptr = text)
                AppendText(ptr + startIndex, count, format);
        }

        public void AppendText(char* text, int count, TextFormat format)
        {
            // look up the cache entry for the given font and size
            CachedFace cachedFace;
            var font = format.Font;
            var size = FontFace.ComputePixelSize(format.Size, Dpi);
            var key = new CacheKey(font.Id, size);
            if (!cache.TryGetValue(key, out cachedFace))
                cache.Add(key, cachedFace = new CachedFace(font, size));

            // process each character in the string
            var nextBreak = BreakCategory.None;
            var previous = new CodePoint();
            char* end = text + count;
            while (text != end)
            {
                // handle surrogate pairs properly
                CodePoint codePoint;
                char c = *text++;
                if (char.IsSurrogate(c) && text != end)
                    codePoint = new CodePoint(c, *text++);
                else
                    codePoint = c;

                // ignore linefeeds directly after a carriage return
                if (c == '\n' && (char)previous == '\r')
                    continue;

                // get the glyph data
                CachedGlyph glyph;
                if (!cachedFace.Glyphs.TryGetValue(codePoint, out glyph) && !char.IsControl(c))
                {
                    var data = font.GetGlyph(codePoint, size);
                    var width = data.RenderWidth;
                    var height = data.RenderHeight;
                    if (width > atlas.Width || height > atlas.Height)
                        throw new InvalidOperationException("Glyph is larger than the size of the provided atlas.");

                    var rect = new Rect();
                    if (width > 0 && height > 0)
                    {
                        // render the glyph
                        var memSize = width * height;
                        var mem = memoryBuffer;
                        if (mem == null)
                            memoryBuffer = mem = new MemoryBuffer(memSize);

                        mem.Clear(memSize);
                        data.RenderTo(new Surface
                        {
                            Bits = mem.Pointer,
                            Width = width,
                            Height = height,
                            Pitch = width
                        });

                        // save the rasterized glyph in the user's atlas
                        rect = packer.Insert(width, height);
                        if (rect.Height == 0)
                        {
                            // didn't fit in the atlas... start a new sheet
                            currentPage++;
                            packer.Clear(atlas.Width, atlas.Height);
                            rect = packer.Insert(width, height);
                            if (rect.Height == 0)
                                throw new InvalidOperationException("Failed to insert glyph into fresh page.");
                        }
                        atlas.Insert(currentPage, rect.X, rect.Y, rect.Width, rect.Height, mem.Pointer);
                    }

                    glyph = new CachedGlyph(rect, data.HorizontalMetrics.Bearing, data.HorizontalMetrics.Advance);
                    cachedFace.Glyphs.Add(codePoint, glyph);
                }

                // check for a kerning offset
                var kerning = font.GetKerning(previous, codePoint, size);
                previous = codePoint;

                // figure out whether this character can serve as a line break point
                // TODO: more robust character class handling
                var breakCategory = BreakCategory.None;
                if (char.IsWhiteSpace(c))
                {
                    if (c == '\r' || c == '\n')
                        breakCategory = BreakCategory.Mandatory;
                    else
                        breakCategory = BreakCategory.Opportunity;
                }

                // the previous character might make us think that this one should be a break opportunity
                if (nextBreak > breakCategory)
                    breakCategory = nextBreak;
                if (c == '-')
                    nextBreak = BreakCategory.Opportunity;

                // alright, we have all the right glyph data cached and loaded
                // append relevant info to our buffer; we'll do the actual layout later
                buffer.Add(new BufferEntry
                {
                    GlyphData = glyph,
                    Kerning = kerning,
                    Break = breakCategory
                });
            }
        }

        public void PerformLayout(float x, float y, float width, float height, TextLayout layout)
        {
            layout.SetCount(buffer.Count);

            var pen = new Vector2(x, y);
            for (int i = 0; i < buffer.Count; i++)
            {
                var entry = buffer[i];
                if (entry.Break == BreakCategory.Mandatory)
                {
                    pen.X = x;
                    pen.Y += 32; // TODO: line spacing
                }

                // data can be null for control characters,
                // or for glyphs without image data
                var data = entry.GlyphData;
                if (data == null)
                    continue;

                pen.X += entry.Kerning;
                layout.AddGlyph(
                    (int)Math.Round(pen.X + data.Bearing.X),
                    (int)Math.Round(pen.Y - data.Bearing.Y),
                    data.Bounds.X,
                    data.Bounds.Y,
                    data.Bounds.Width,
                    data.Bounds.Height
                );

                pen.X += (float)Math.Round(data.AdvanceWidth);
            }
        }

        struct BufferEntry
        {
            public CachedGlyph GlyphData;
            public float Kerning;
            public BreakCategory Break;
        }

        struct CachedFace
        {
            public FaceMetrics Metrics;
            public Dictionary<CodePoint, CachedGlyph> Glyphs;

            public CachedFace(FontFace font, float size)
            {
                Metrics = font.GetFaceMetrics(size);
                Glyphs = new Dictionary<CodePoint, CachedGlyph>();
            }
        }

        class CachedGlyph
        {
            public Rect Bounds;
            public Vector2 Bearing;
            public float AdvanceWidth;

            public CachedGlyph(Rect bounds, Vector2 bearing, float advance)
            {
                Bounds = bounds;
                Bearing = bearing;
                AdvanceWidth = advance;
            }
        }

        struct CacheKey
        {
            public int Id;
            public float Size;

            public CacheKey(int id, float size)
            {
                Id = id;
                Size = size;
            }

            public static readonly IEqualityComparer<CacheKey> Comparer = new CacheKeyComparer();

            class CacheKeyComparer : IEqualityComparer<CacheKey>
            {
                //public bool Equals (CacheKey x, CacheKey y) => x.Id == y.Id && x.Size == y.Size;
                public bool Equals(CacheKey x, CacheKey y)
                {
                    return x.Id == y.Id && x.Size == y.Size;
                }
                //public int GetHashCode (CacheKey obj) => obj.Id.GetHashCode() ^ obj.Size.GetHashCode();
                public int GetHashCode(CacheKey obj)
                {
                    return obj.Id.GetHashCode() ^ obj.Size.GetHashCode();
                }
            }
        }

        class MemoryBuffer
        {
            public IntPtr Pointer;
            int size;

            public MemoryBuffer(int initialSize)
            {
                size = RoundSize(initialSize);
                Pointer = Marshal.AllocHGlobal(size);
            }

            public void Clear(int newSize)
            {
                newSize = RoundSize(newSize);
                if (newSize > size)
                {
                    Pointer = Marshal.ReAllocHGlobal(Pointer, (IntPtr)newSize);
                    size = newSize;
                }

                // clear the memory
                for (int* ptr = (int*)Pointer, end = ptr + (newSize >> 2); ptr != end; ptr++)
                    *ptr = 0;
            }

            //static int RoundSize (int size) => (size + 3) & ~3;
            static int RoundSize(int size)
            {
                return (size + 3) & ~3;
            }
        }

        enum BreakCategory
        {
            None,
            Opportunity,
            Mandatory
        }
    }
}
