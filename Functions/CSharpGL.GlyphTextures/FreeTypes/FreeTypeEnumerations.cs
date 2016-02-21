using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.GlyphTextures.FreeTypes
{
    public enum FT_LOAD_TYPES
    {
        FT_LOAD_DEFAULT = 0x0,
        FT_LOAD_NO_SCALE = 1 << 0,
        FT_LOAD_NO_HINTING = 1 << 1,
        FT_LOAD_RENDER = 1 << 2,
        FT_LOAD_NO_BITMAP = 1 << 3,
        FT_LOAD_VERTICAL_LAYOUT = 1 << 4,
        FT_LOAD_FORCE_AUTOHINT = 1 << 5,
        FT_LOAD_CROP_BITMAP = 1 << 6,
        FT_LOAD_PEDANTIC = 1 << 7,
        FT_LOAD_IGNORE_GLOBAL_ADVANCE_WIDTH = 1 << 9,
        FT_LOAD_NO_RECURSE = 1 << 10,
        FT_LOAD_IGNORE_TRANSFORM = 1 << 11,
        FT_LOAD_MONOCHROME = 1 << 12,
        FT_LOAD_LINEAR_DESIGN = 1 << 13,
        FT_LOAD_NO_AUTOHINT = 1 << 15,
        /* Bits 16..19 are used by `FT_LOAD_TARGET_' */
        FT_LOAD_COLOR = 1 << 20,

        /* */

        /* used internally only by certain font drivers! */
        FT_LOAD_ADVANCE_ONLY = 1 << 8,
        FT_LOAD_SBITS_ONLY = 1 << 14,
    }

    public enum FT_RENDER_MODES
    {
        FT_RENDER_MODE_NORMAL = 0,
        FT_RENDER_MODE_LIGHT = 1
    }
}
