using System;
using System.Numerics;
using System.Runtime.InteropServices;

namespace SharpFont
{
    /// <summary>
    /// Contains various metrics that apply to a font face as a whole, scaled for a particular size.
    /// </summary>
    sealed class FaceMetrics
    {
        /// <summary>
        /// The distance from the baseline up to the top of the em box.
        /// </summary>
        public readonly float CellAscent;

        /// <summary>
        /// The distance from the baseline down to the bottom of the em box.
        /// </summary>
        public readonly float CellDescent;

        /// <summary>
        /// The baseline-to-baseline distance.
        /// </summary>
        public readonly float LineHeight;

        /// <summary>
        /// The average height of "lowercase" characters.
        /// </summary>
        public readonly float XHeight;

        /// <summary>
        /// The average height of "uppercase" characters.
        /// </summary>
        public readonly float CapHeight;

        /// <summary>
        /// The thickness of an underline marker.
        /// </summary>
        public readonly float UnderlineSize;

        /// <summary>
        /// The distance from the baseline at which to place the underline marker.
        /// </summary>
        public readonly float UnderlinePosition;

        /// <summary>
        /// The thickness of a strikeout marker.
        /// </summary>
        public readonly float StrikeoutSize;

        /// <summary>
        /// The distance from the baseline at which to place the strikeout marker.
        /// </summary>
        public readonly float StrikeoutPosition;

        /// <summary>
        /// Initializes a new instance of the <see cref="FaceMetrics"/> class.
        /// </summary>
        /// <param name="cellAscent">The cell ascent.</param>
        /// <param name="cellDescent">The cell descent.</param>
        /// <param name="lineHeight">The line height.</param>
        /// <param name="xHeight">The average height of "lowercase" characters.</param>
        /// <param name="capHeight">The average height of "uppercase" characters.</param>
        /// <param name="underlineSize">The underline size.</param>
        /// <param name="underlinePosition">The underline position.</param>
        /// <param name="strikeoutSize">The strikeout size.</param>
        /// <param name="strikeoutPosition">The strikeout position.</param>
        public FaceMetrics(
            float cellAscent, float cellDescent, float lineHeight, float xHeight,
            float capHeight, float underlineSize, float underlinePosition,
            float strikeoutSize, float strikeoutPosition
        )
        {
            CellAscent = cellAscent;
            CellDescent = cellDescent;
            LineHeight = lineHeight;
            XHeight = xHeight;
            CapHeight = capHeight;
            UnderlineSize = underlineSize;
            UnderlinePosition = underlinePosition;
            StrikeoutSize = strikeoutSize;
            StrikeoutPosition = strikeoutPosition;
        }
    }

    /// <summary>
    /// Contains metrics for a single glyph.
    /// </summary>
    struct GlyphMetrics
    {
        /// <summary>
        /// The leading bearings; this is the offset from the pen at which to position the glyph.
        /// </summary>
        public readonly Vector2 Bearing;

        /// <summary>
        /// The glyph advance; this is the distance to advance the pen after positioning the glyph.
        /// </summary>
        public readonly float Advance;

        /// <summary>
        /// The linear advance; this is the original advance distance unaffected by hinting.
        /// Use this if you want a guaranteed smooth transition of advances across various pixel sizes.
        /// </summary>
        public readonly float LinearAdvance;

        /// <summary>
        /// Initializes a new instance of the <see cref="GlyphMetrics"/> struct.
        /// </summary>
        /// <param name="bearing">The bearings.</param>
        /// <param name="advance">The advance distance.</param>
        /// <param name="linearAdvance">The linear unhinted advance distance.</param>
        public GlyphMetrics(Vector2 bearing, float advance, float linearAdvance)
        {
            Bearing = bearing;
            Advance = advance;
            LinearAdvance = linearAdvance;
        }
    }

    /// <summary>
    /// Represents an image surface in memory.
    /// </summary>
    struct Surface : IDisposable
    {
        /// <summary>
        /// A pointer to the image data.
        /// </summary>
        public IntPtr Bits { get; set; }

        /// <summary>
        /// The width of the image, in pixels.
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// The height of the image, in pixels.
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// The width of a row of pixels, in bytes.
        /// </summary>
        public int Pitch { get; set; }

        public void Dispose()
        {
            Marshal.FreeHGlobal(this.Bits);
        }
    }

    /// <summary>
    /// Represents a single Unicode codepoint.
    /// </summary>
    struct CodePoint : IComparable<CodePoint>, IEquatable<CodePoint>
    {
        readonly int value;

        /// <summary>
        /// Initializes a new instance of the <see cref="CodePoint"/> struct.
        /// </summary>
        /// <param name="codePoint">The 32-bit value of the codepoint.</param>
        public CodePoint(int codePoint)
        {
            value = codePoint;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CodePoint"/> struct.
        /// </summary>
        /// <param name="character">The 16-bit value of the codepoint.</param>
        public CodePoint(char character)
        {
            value = character;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CodePoint"/> struct.
        /// </summary>
        /// <param name="highSurrogate">The first member of a surrogate pair representing the codepoint.</param>
        /// <param name="lowSurrogate">The second member of a surrogate pair representing the codepoint.</param>
        public CodePoint(char highSurrogate, char lowSurrogate)
        {
            value = char.ConvertToUtf32(highSurrogate, lowSurrogate);
        }

        /// <summary>
        /// Compares this instance to the specified value.
        /// </summary>
        /// <param name="other">The value to compare.</param>
        /// <returns>A signed number indicating the relative values of this instance and <paramref name="other"/>.</returns>
        //public int CompareTo (CodePoint other) => value.CompareTo(other.value);
        public int CompareTo(CodePoint other)
        {
            return value.CompareTo(other.value);
        }

        /// <summary>
        /// Returns a value indicating whether this instance is equal to the specified object.
        /// </summary>
        /// <param name="other">The object to compare.</param>
        /// <returns><c>true</c> if this instance equals <paramref name="other"/>; otherwise, <c>false</c>.</returns>
        //public bool Equals (CodePoint other) => value.Equals(other.value);
        public bool Equals(CodePoint other)
        {
            return value.Equals(other.value);
        }

        /// <summary>
        /// Returns a value indicating whether this instance is equal to the specified object.
        /// </summary>
        /// <param name="obj">The object to compare.</param>
        /// <returns><c>true</c> if this instance equals <paramref name="obj"/>; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
        {
            var codepoint = obj as CodePoint?;
            if (codepoint == null)
                return false;

            return Equals(codepoint);
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>The instance's hashcode.</returns>
        //public override int GetHashCode () => value.GetHashCode();
        public override int GetHashCode()
        {
            return value.GetHashCode();
        }

        /// <summary>
        /// Converts the value to its equivalent string representation.
        /// </summary>
        /// <returns></returns>
        //public override string ToString () => $"{value} ({(char)value})";
        public override string ToString()
        {
            return string.Format("{0} ({1})", this.value, (char)this.value);
        }

        /// <summary>
        /// Implements the equality operator.
        /// </summary>
        /// <param name="left">The left hand side of the operator.</param>
        /// <param name="right">The right hand side of the operator.</param>
        /// <returns>The result of the operator.</returns>
        //public static bool operator ==(CodePoint left, CodePoint right) => left.Equals(right);
        public static bool operator ==(CodePoint left, CodePoint right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Implements the inequality operator.
        /// </summary>
        /// <param name="left">The left hand side of the operator.</param>
        /// <param name="right">The right hand side of the operator.</param>
        /// <returns>The result of the operator.</returns>
        //public static bool operator !=(CodePoint left, CodePoint right) => !left.Equals(right);
        public static bool operator !=(CodePoint left, CodePoint right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Implements the less-than operator.
        /// </summary>
        /// <param name="left">The left hand side of the operator.</param>
        /// <param name="right">The right hand side of the operator.</param>
        /// <returns>The result of the operator.</returns>
        //public static bool operator <(CodePoint left, CodePoint right) => left.value < right.value;
        public static bool operator <(CodePoint left, CodePoint right)
        {
            return left.value < right.value;
        }

        /// <summary>
        /// Implements the greater-than operator.
        /// </summary>
        /// <param name="left">The left hand side of the operator.</param>
        /// <param name="right">The right hand side of the operator.</param>
        /// <returns>The result of the operator.</returns>
        //public static bool operator >(CodePoint left, CodePoint right) => left.value > right.value;
        public static bool operator >(CodePoint left, CodePoint right)
        {
            return left.value > right.value;
        }

        /// <summary>
        /// Implements the less-than-or-equal-to operator.
        /// </summary>
        /// <param name="left">The left hand side of the operator.</param>
        /// <param name="right">The right hand side of the operator.</param>
        /// <returns>The result of the operator.</returns>
        //public static bool operator <=(CodePoint left, CodePoint right) => left.value <= right.value;
        public static bool operator <=(CodePoint left, CodePoint right)
        {
            return left.value <= right.value;
        }

        /// <summary>
        /// Implements the greater-than-or-equal-to operator.
        /// </summary>
        /// <param name="left">The left hand side of the operator.</param>
        /// <param name="right">The right hand side of the operator.</param>
        /// <returns>The result of the operator.</returns>
        //public static bool operator >=(CodePoint left, CodePoint right) => left.value >= right.value;
        public static bool operator >=(CodePoint left, CodePoint right)
        {
            return left.value >= right.value;
        }

        /// <summary>
        /// Implements an explicit conversion from integer to <see cref="CodePoint"/>.
        /// </summary>
        /// <param name="codePoint">The codepoint value.</param>
        //public static explicit operator CodePoint (int codePoint) => new CodePoint(codePoint);
        public static explicit operator CodePoint(int codePoint)
        {
            return new CodePoint(codePoint);
        }

        /// <summary>
        /// Implements an implicit conversion from character to <see cref="CodePoint"/>.
        /// </summary>
        /// <param name="character">The character value.</param>
        //public static implicit operator CodePoint (char character) => new CodePoint(character);
        public static implicit operator CodePoint(char character)
        {
            return new CodePoint(character);
        }

        /// <summary>
        /// Implements an explicit conversion from <see cref="CodePoint"/> to character.
        /// </summary>
        /// <param name="codePoint">The codepoint value.</param>
        //public static explicit operator char (CodePoint codePoint) => (char)codePoint.value;
        public static explicit operator char(CodePoint codePoint)
        {
            return (char)codePoint.value;
        }
    }

    /// <summary>
    /// Specifies various font weights.
    /// </summary>
    enum FontWeight
    {
        /// <summary>
        /// The weight is unknown or unspecified.
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// Very thin.
        /// </summary>
        Thin = 100,

        /// <summary>
        /// Extra light.
        /// </summary>
        ExtraLight = 200,

        /// <summary>
        /// Light.
        /// </summary>
        Light = 300,

        /// <summary>
        /// Normal.
        /// </summary>
        Normal = 400,

        /// <summary>
        /// Medium.
        /// </summary>
        Medium = 500,

        /// <summary>
        /// Somewhat bold.
        /// </summary>
        SemiBold = 600,

        /// <summary>
        /// Bold.
        /// </summary>
        Bold = 700,

        /// <summary>
        /// Extra bold.
        /// </summary>
        ExtraBold = 800,

        /// <summary>
        /// Extremely bold.
        /// </summary>
        Black = 900
    }

    /// <summary>
    /// Specifies the font stretching level.
    /// </summary>
    enum FontStretch
    {
        /// <summary>
        /// The stretch is unknown or unspecified.
        /// </summary>
        Unknown,

        /// <summary>
        /// Ultra condensed.
        /// </summary>
        UltraCondensed,

        /// <summary>
        /// Extra condensed.
        /// </summary>
        ExtraCondensed,

        /// <summary>
        /// Condensed.
        /// </summary>
        Condensed,

        /// <summary>
        /// Somewhat condensed.
        /// </summary>
        SemiCondensed,

        /// <summary>
        /// Normal.
        /// </summary>
        Normal,

        /// <summary>
        /// Somewhat expanded.
        /// </summary>
        SemiExpanded,

        /// <summary>
        /// Expanded.
        /// </summary>
        Expanded,

        /// <summary>
        /// Extra expanded.
        /// </summary>
        ExtraExpanded,

        /// <summary>
        /// Ultra expanded.
        /// </summary>
        UltraExpanded
    }

    /// <summary>
    /// Specifies various font styles.
    /// </summary>
    enum FontStyle
    {
        /// <summary>
        /// No particular styles applied.
        /// </summary>
        Regular,

        /// <summary>
        /// The font is emboldened.
        /// </summary>
        Bold,

        /// <summary>
        /// The font is stylistically italic.
        /// </summary>
        Italic,

        /// <summary>
        /// The font is algorithmically italic / angled.
        /// </summary>
        Oblique
    }
}
