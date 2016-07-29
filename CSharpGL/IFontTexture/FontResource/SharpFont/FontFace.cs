using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace SharpFont
{
    /// <summary>
    /// Represents a single font face, maintaining all font data in memory.
    /// </summary>
    sealed class FontFace
    {
        readonly SharpFontRenderer renderer = new SharpFontRenderer();
        readonly Interpreter interpreter;
        readonly BaseGlyph[] glyphs;
        readonly MetricsEntry[] hmetrics;
        readonly MetricsEntry[] vmetrics;
        readonly CharacterMap charMap;
        readonly KerningTable kernTable;
        readonly MetricsEntry verticalSynthesized;
        readonly int[] controlValueTable;
        readonly byte[] prepProgram;
        readonly int cellAscent;
        readonly int cellDescent;
        readonly int lineHeight;
        readonly int xHeight;
        readonly int capHeight;
        readonly int underlineSize;
        readonly int underlinePosition;
        readonly int strikeoutSize;
        readonly int strikeoutPosition;
        readonly int unitsPerEm;
        readonly bool integerPpems;

        static int currentId;
        internal int Id;    // unique ID for cache lookups

        /// <summary>
        /// Indicates whether the font's glyphs share a fixed width.
        /// </summary>
        public readonly bool IsFixedWidth;

        /// <summary>
        /// The visual weight of the font.
        /// </summary>
        public readonly FontWeight Weight;

        /// <summary>
        /// The visual stretching appearance of the font's glyphs.
        /// </summary>
        public readonly FontStretch Stretch;

        /// <summary>
        /// The font's style.
        /// </summary>
        public readonly FontStyle Style;

        /// <summary>
        /// The name of the family to which the font belongs (e.g. "Arial").
        /// </summary>
        public readonly string Family;

        /// <summary>
        /// The subname within the family (e.g. "Regular").
        /// </summary>
        public readonly string Subfamily;

        /// <summary>
        /// The full human-friendly name of the font (e.g. "Arial Regular").
        /// </summary>
        public readonly string FullName;

        /// <summary>
        /// A unique identifier for the font (this is self assigned by the font designer so it may not actually be unique).
        /// </summary>
        public readonly string UniqueID;

        /// <summary>
        /// The font's version string.
        /// </summary>
        public readonly string Version;

        /// <summary>
        /// An optional description string for the font.
        /// </summary>
        public readonly string Description;

        /// <summary>
        /// Initializes a new instance of the <see cref="FontFace"/> class.
        /// </summary>
        /// <param name="stream">A stream pointing to the font file.</param>
        /// <remarks>
        /// All relevant font data is loaded into memory and retained by the FontFace object.
        /// Once the constructor finishes you are free to close the stream.
        /// </remarks>
        public FontFace(Stream stream)
        {
            if (stream == null) { throw new ArgumentNullException("stream", "Empty stream for FontFace!"); }

            // read the face header and table records
            using (var reader = new DataReader(stream))
            {
                var tables = SfntTables.ReadFaceHeader(reader);

                // read head and maxp tables for font metadata and limits
                FaceHeader head;
                SfntTables.ReadHead(reader, tables, out head);
                SfntTables.ReadMaxp(reader, tables, ref head);
                unitsPerEm = head.UnitsPerEm;
                integerPpems = (head.Flags & HeadFlags.IntegerPpem) != 0;

                // horizontal metrics header and data
                SfntTables.SeekToTable(reader, tables, FourCC.Hhea, required: true);
                var hMetricsHeader = SfntTables.ReadMetricsHeader(reader);
                SfntTables.SeekToTable(reader, tables, FourCC.Hmtx, required: true);
                hmetrics = SfntTables.ReadMetricsTable(reader, head.GlyphCount, hMetricsHeader.MetricCount);

                // font might optionally have vertical metrics
                if (SfntTables.SeekToTable(reader, tables, FourCC.Vhea))
                {
                    var vMetricsHeader = SfntTables.ReadMetricsHeader(reader);

                    SfntTables.SeekToTable(reader, tables, FourCC.Vmtx, required: true);
                    vmetrics = SfntTables.ReadMetricsTable(reader, head.GlyphCount, vMetricsHeader.MetricCount);
                }

                // OS/2 table has even more metrics
                var os2Data = SfntTables.ReadOS2(reader, tables);
                xHeight = os2Data.XHeight;
                capHeight = os2Data.CapHeight;
                Weight = os2Data.Weight;
                Stretch = os2Data.Stretch;
                Style = os2Data.Style;

                // optional PostScript table has random junk in it
                SfntTables.ReadPost(reader, tables, ref head);
                IsFixedWidth = head.IsFixedPitch;

                // read character-to-glyph mapping tables and kerning table
                charMap = CharacterMap.ReadCmap(reader, tables);
                kernTable = KerningTable.ReadKern(reader, tables);

                // name data
                var names = SfntTables.ReadNames(reader, tables);
                Family = names.TypographicFamilyName ?? names.FamilyName;
                Subfamily = names.TypographicSubfamilyName ?? names.SubfamilyName;
                FullName = names.FullName;
                UniqueID = names.UniqueID;
                Version = names.Version;
                Description = names.Description;

                // load glyphs if we have them
                if (SfntTables.SeekToTable(reader, tables, FourCC.Glyf))
                {
                    unsafe
                    {
                        // read in the loca table, which tells us the byte offset of each glyph
                        var loca = stackalloc uint[head.GlyphCount];
                        SfntTables.ReadLoca(reader, tables, head.IndexFormat, loca, head.GlyphCount);

                        // we need to know the length of the glyf table because of some weirdness in the loca table:
                        // if a glyph is "missing" (like a space character), then its loca[n] entry is equal to loca[n+1]
                        // if the last glyph in the set is missing, then loca[n] == glyf table length
                        SfntTables.SeekToTable(reader, tables, FourCC.Glyf);
                        var glyfOffset = reader.Position;
                        var glyfLength = tables[SfntTables.FindTable(tables, FourCC.Glyf)].Length;

                        // read in all glyphs
                        glyphs = new BaseGlyph[head.GlyphCount];
                        for (int i = 0; i < glyphs.Length; i++)
                            SfntTables.ReadGlyph(reader, i, 0, glyphs, glyfOffset, glyfLength, loca);
                    }
                }

                // embedded bitmaps
                SbitTable.Read(reader, tables);

                // metrics calculations: if the UseTypographicMetrics flag is set, then
                // we should use the sTypo*** data for line height calculation
                if (os2Data.UseTypographicMetrics)
                {
                    // include the line gap in the ascent so that
                    // white space is distributed above the line
                    cellAscent = os2Data.TypographicAscender + os2Data.TypographicLineGap;
                    cellDescent = -os2Data.TypographicDescender;
                    lineHeight = os2Data.TypographicAscender + os2Data.TypographicLineGap - os2Data.TypographicDescender;
                }
                else
                {
                    // otherwise, we need to guess at whether hhea data or os/2 data has better line spacing
                    // this is the recommended procedure based on the OS/2 spec extra notes
                    cellAscent = os2Data.WinAscent;
                    cellDescent = Math.Abs(os2Data.WinDescent);
                    lineHeight = Math.Max(
                        Math.Max(0, hMetricsHeader.LineGap) + hMetricsHeader.Ascender + Math.Abs(hMetricsHeader.Descender),
                        cellAscent + cellDescent
                    );
                }

                // give sane defaults for underline and strikeout data if missing
                underlineSize = head.UnderlineThickness != 0 ?
                    head.UnderlineThickness : (head.UnitsPerEm + 7) / 14;
                underlinePosition = head.UnderlinePosition != 0 ?
                    head.UnderlinePosition : -((head.UnitsPerEm + 5) / 10);
                strikeoutSize = os2Data.StrikeoutSize != 0 ?
                    os2Data.StrikeoutSize : underlineSize;
                strikeoutPosition = os2Data.StrikeoutPosition != 0 ?
                    os2Data.StrikeoutPosition : head.UnitsPerEm / 3;

                // create some vertical metrics in case we haven't loaded any
                verticalSynthesized = new MetricsEntry
                {
                    FrontSideBearing = os2Data.TypographicAscender,
                    Advance = os2Data.TypographicAscender - os2Data.TypographicDescender
                };

                // read in global font program data
                controlValueTable = SfntTables.ReadCvt(reader, tables);
                prepProgram = SfntTables.ReadProgram(reader, tables, FourCC.Prep);
                interpreter = new Interpreter(
                    head.MaxStackSize,
                    head.MaxStorageLocations,
                    head.MaxFunctionDefs,
                    head.MaxInstructionDefs,
                    head.MaxTwilightPoints
                );

                // the fpgm table optionally contains a program to run at initialization time
                var fpgm = SfntTables.ReadProgram(reader, tables, FourCC.Fpgm);
                if (fpgm != null)
                    interpreter.InitializeFunctionDefs(fpgm);
            }

            Id = Interlocked.Increment(ref currentId);
        }

        /// <summary>
        /// Computes a pixel size given a point size and screen DPI.
        /// </summary>
        /// <param name="pointSize">The font point size.</param>
        /// <param name="dpi">The DPI of the screen.</param>
        /// <returns>The pixel size at the given resolution.</returns>
        //public static float ComputePixelSize (float pointSize, int dpi) => pointSize * dpi / 72;
        public static float ComputePixelSize(float pointSize, int dpi)
        {
            return pointSize * dpi / 72;
        }

        /// <summary>
        /// Gets metrics for the font as a whole at a particular pixel size.
        /// </summary>
        /// <param name="pixelSize">The size of the font, in pixels.</param>
        /// <returns>The font's face metrics.</returns>
        public FaceMetrics GetFaceMetrics(int pixelSize)
        {
            var scale = ComputeScale(pixelSize);
            return new FaceMetrics(
                cellAscent * scale,
                cellDescent * scale,
                lineHeight * scale,
                xHeight * scale,
                capHeight * scale,
                underlineSize * scale,
                underlinePosition * scale,
                strikeoutSize * scale,
                strikeoutPosition * scale
            );
        }

        /// <summary>
        /// Gets glyph data for a specific character.
        /// </summary>
        /// <param name="codePoint">The Unicode codepoint for which to retrieve glyph data.</param>
        /// <param name="pixelSize">The desired size of the font, in pixels.</param>
        /// <returns>The glyph data if the font supports the given character; otherwise, <c>null</c>.</returns>
        public Glyph GetGlyph(CodePoint codePoint, int pixelSize)
        {
            var glyphIndex = charMap.Lookup(codePoint);
            if (glyphIndex < 0)
                return null;

            // set up the control value table
            var scale = ComputeScale(pixelSize);
            interpreter.SetControlValueTable(controlValueTable, scale, pixelSize, prepProgram);

            // get metrics
            var glyph = glyphs[glyphIndex];
            var horizontal = hmetrics[glyphIndex];
            //var vtemp = vmetrics?[glyphIndex];
            //if (vtemp == null) {
            //    var synth = verticalSynthesized;
            //    synth.FrontSideBearing -= glyph.MaxY;
            //    vtemp = synth;
            //}
            MetricsEntry vtemp;
            if (vmetrics == null)
            {
                var synth = verticalSynthesized;
                synth.FrontSideBearing -= glyph.MaxY;
                vtemp = synth;
            }
            else
            {
                vtemp = vmetrics[glyphIndex];
            }
            //var vertical = vtemp.GetValueOrDefault();
            var vertical = vtemp;

            // build and transform the glyph
            var points = new List<PointF>(32);
            var contours = new List<int>(32);
            var transform = Matrix3x2.CreateScale(scale);
            Geometry.ComposeGlyphs(glyphIndex, 0, ref transform, points, contours, glyphs);

            // add phantom points; these are used to define the extents of the glyph,
            // and can be modified by hinting instructions
            var pp1 = new Point((glyph.MinX - horizontal.FrontSideBearing), 0);
            var pp2 = new Point(pp1.X + horizontal.Advance, 0);
            var pp3 = new Point(0, (glyph.MaxY + vertical.FrontSideBearing));
            var pp4 = new Point(0, pp3.Y - vertical.Advance);
            points.Add(pp1 * scale);
            points.Add(pp2 * scale);
            points.Add(pp3 * scale);
            points.Add(pp4 * scale);

            // hint the glyph's points
            var pointArray = points.ToArray();
            var contourArray = contours.ToArray();
            interpreter.HintGlyph(pointArray, contourArray, glyphs[glyphIndex].Instructions);

            return new Glyph(renderer, pointArray, contourArray, horizontal.Advance * scale);
        }

        /// <summary>
        /// Gets kerning information for a pair of characters.
        /// </summary>
        /// <param name="left">The left character.</param>
        /// <param name="right">The right character.</param>
        /// <param name="pixelSize">The size of the font, in pixels.</param>
        /// <returns>The amount of kerning to apply, if any.</returns>
        public float GetKerning(CodePoint left, CodePoint right, int pixelSize)
        {
            if (kernTable == null)
                return 0.0f;

            var leftIndex = charMap.Lookup(left);
            var rightIndex = charMap.Lookup(right);
            if (leftIndex < 0 || rightIndex < 0)
                return 0.0f;

            var kern = kernTable.Lookup(leftIndex, rightIndex);
            return kern * ComputeScale(pixelSize);
        }

        /// <summary>
        /// Returns a string representation of the font.
        /// </summary>
        /// <returns>The full name of the font.</returns>
        public override string ToString()
        {
            return FullName;
        }

        float ComputeScale(int pixelSize)
        {
            //if (integerPpems)
            //pixelSize = (float)Math.Round(pixelSize);
            return (float)pixelSize / (float)unitsPerEm;
        }
    }

    /// <summary>
    /// Represents a single glyph of a font.
    /// </summary>
    sealed class Glyph
    {
        readonly SharpFontRenderer renderer;
        readonly PointF[] points;
        readonly int[] contours;

        /// <summary>
        /// The width of the glyph.
        /// </summary>
        public readonly float Width;

        /// <summary>
        /// The height of the glyph.
        /// </summary>
        public readonly float Height;

        /// <summary>
        /// The integer width of the glyph, as it will be rendered.
        /// </summary>
        public readonly int RenderWidth;

        /// <summary>
        /// The integer height of the glyph, as it will be rendered.
        /// </summary>
        public readonly int RenderHeight;

        /// <summary>
        /// The metrics to use when the glyph is laid out horizontally.
        /// </summary>
        public readonly GlyphMetrics HorizontalMetrics;

        ///// <summary>
        ///// The metrics to use when the glyph is laid out vertically.
        ///// </summary>
        //public readonly GlyphMetrics VerticalMetrics;

        internal Glyph(SharpFontRenderer renderer, PointF[] points, int[] contours, float linearHorizontalAdvance)
        {
            this.renderer = renderer;
            this.points = points;
            this.contours = contours;

            // find the bounding box
            var min = new Vector2(float.MaxValue, float.MaxValue);
            var max = new Vector2(float.MinValue, float.MinValue);
            var pointCount = points.Length - 4;
            for (int i = 0; i < pointCount; i++)
            {
                min = Vector2.Min(min, points[i].P);
                max = Vector2.Max(max, points[i].P);
            }

            // save the "pure" size of the glyph, in fractional pixels
            var size = max - min;
            Width = size.x;
            Height = size.y;

            // find the "render" size of the glyph, in whole pixels
            var shiftX = (int)Math.Floor(min.x);
            var shiftY = (int)Math.Floor(min.y);
            RenderWidth = (int)Math.Ceiling(max.x) - shiftX;
            RenderHeight = (int)Math.Ceiling(max.y) - shiftY;

            // translate the points so that 0,0 is at the bottom left corner
            var offset = new Vector2(-shiftX, -shiftY);
            for (int i = 0; i < pointCount; i++)
                points[i] = points[i].Offset(offset);

            HorizontalMetrics = new GlyphMetrics(new Vector2(min.x, max.y), points[pointCount + 1].P.x - points[pointCount].P.x, linearHorizontalAdvance);

            // TODO: vertical metrics
        }

        /// <summary>
        /// Renders the glyph to the given surface.
        /// </summary>
        /// <param name="surface">The target surface.</param>
        /// <remarks>
        /// If the surface is not large enough, the glyph will be clipped to fit.
        /// </remarks>
        public void RenderTo(Surface surface)
        {
            // check for an empty outline, which obviously results in an empty render
            if (points.Length <= 0 || contours.Length <= 0)
                return;

            // clip against the bounds of the target surface
            var width = Math.Min(RenderWidth, surface.Width);
            var height = Math.Min(RenderHeight, surface.Height);
            if (width <= 0 || height <= 0)
                return;

            // walk each contour of the outline and render it
            var firstIndex = 0;
            renderer.Start(width, height);
            for (int i = 0; i < contours.Length; i++)
            {
                // decompose the contour into drawing commands
                var lastIndex = contours[i];
                Geometry.DecomposeContour(renderer, firstIndex, lastIndex, points);

                // next contour starts where this one left off
                firstIndex = lastIndex + 1;
            }

            // blit the result to the target surface
            renderer.BlitTo(surface);
        }
    }
}
