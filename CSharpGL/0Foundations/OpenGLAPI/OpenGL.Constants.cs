using System;
using System.Diagnostics;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace CSharpGL
{
    public static partial class OpenGL
    {

        #region The OpenGL constant definitions.

        // OpenGL Version Identifier
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_VERSION_1_1 = 1;

        // AccumOp
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_ACCUM = 0x0100;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_LOAD = 0x0101;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_RETURN = 0x0102;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_MULT = 0x0103;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_ADD = 0x0104;

        // Alpha functions
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_NEVER = 0x0200;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_LESS = 0x0201;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_EQUAL = 0x0202;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_LEQUAL = 0x0203;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_GREATER = 0x0204;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_NOTEQUAL = 0x0205;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_GEQUAL = 0x0206;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_ALWAYS = 0x0207;

        //  AttribMask
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_CURRENT_BIT = 0x00000001;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_POINT_BIT = 0x00000002;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_LINE_BIT = 0x00000004;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_POLYGON_BIT = 0x00000008;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_POLYGON_STIPPLE_BIT = 0x00000010;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_PIXEL_MODE_BIT = 0x00000020;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_LIGHTING_BIT = 0x00000040;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_FOG_BIT = 0x00000080;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_DEPTH_BUFFER_BIT = 0x00000100;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_ACCUM_BUFFER_BIT = 0x00000200;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_STENCIL_BUFFER_BIT = 0x00000400;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_VIEWPORT_BIT = 0x00000800;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_TRANSFORM_BIT = 0x00001000;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_ENABLE_BIT = 0x00002000;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_COLOR_BUFFER_BIT = 0x00004000;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_COVERAGE_BUFFER_BIT_NV = 0x00008000;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_HINT_BIT = 0x00008000;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_EVAL_BIT = 0x00010000;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_LIST_BIT = 0x00020000;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_TEXTURE_BIT = 0x00040000;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_SCISSOR_BIT = 0x00080000;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_ALL_ATTRIB_BITS = 0x000fffff;

        //  BeginMode
        /// <summary>
        /// Treats each vertex as a single point. Vertex n defines point n. N points are drawn.
        /// </summary>
        public const uint GL_POINTS = 0x0000;
        /// <summary>
        /// Treats each pair of vertices as an independent line segment. Vertices 2n - 1 and 2n define line n. N/2 lines are drawn.
        /// </summary>
        public const uint GL_LINES = 0x0001;
        /// <summary>
        /// Draws a connected group of line segments from the first vertex to the last, then back to the first. Vertices n and n + 1 define line n. The last line, however, is defined by vertices N and 1. N lines are drawn.
        /// </summary>
        public const uint GL_LINE_LOOP = 0x0002;
        /// <summary>
        /// Draws a connected group of line segments from the first vertex to the last. Vertices n and n+1 define line n. N - 1 lines are drawn.
        /// </summary>
        public const uint GL_LINE_STRIP = 0x0003;
        /// <summary>
        /// Treats each triplet of vertices as an independent triangle. Vertices 3n - 2, 3n - 1, and 3n define triangle n. N/3 triangles are drawn.
        /// </summary>
        public const uint GL_TRIANGLES = 0x0004;
        /// <summary>
        /// Draws a connected group of triangles. One triangle is defined for each vertex presented after the first two vertices. For odd n, vertices n, n + 1, and n + 2 define triangle n. For even n, vertices n + 1, n, and n + 2 define triangle n. N - 2 triangles are drawn.
        /// </summary>
        public const uint GL_TRIANGLE_STRIP = 0x0005;
        /// <summary>
        /// Draws a connected group of triangles. one triangle is defined for each vertex presented after the first two vertices. Vertices 1, n + 1, n + 2 define triangle n. N - 2 triangles are drawn.
        /// </summary>
        public const uint GL_TRIANGLE_FAN = 0x0006;
        /// <summary>
        /// Treats each group of four vertices as an independent quadrilateral. Vertices 4n - 3, 4n - 2, 4n - 1, and 4n define quadrilateral n. N/4 quadrilaterals are drawn.
        /// </summary>
        public const uint GL_QUADS = 0x0007;
        /// <summary>
        /// Draws a connected group of quadrilaterals. One quadrilateral is defined for each pair of vertices presented after the first pair. Vertices 2n - 1, 2n, 2n + 2, and 2n + 1 define quadrilateral n. N/2 - 1 quadrilaterals are drawn. Note that the order in which vertices are used to construct a quadrilateral from strip data is different from that used with independent data.
        /// </summary>
        public const uint GL_QUAD_STRIP = 0x0008;
        /// <summary>
        /// Draws a single, convex polygon. Vertices 1 through N define this polygon.
        /// </summary>
        public const uint GL_POLYGON = 0x0009;

        //  BlendingFactorDest
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_ZERO = 0;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_ONE = 1;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_SRC_COLOR = 0x0300;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_ONE_MINUS_SRC_COLOR = 0x0301;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_SRC_ALPHA = 0x0302;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_ONE_MINUS_SRC_ALPHA = 0x0303;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_DST_ALPHA = 0x0304;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_ONE_MINUS_DST_ALPHA = 0x0305;

        //  BlendingFactorSrc
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_DST_COLOR = 0x0306;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_ONE_MINUS_DST_COLOR = 0x0307;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_SRC_ALPHA_SATURATE = 0x0308;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_CONSTANT_COLOR = 0x8001;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_ONE_MINUS_CONSTANT_COLOR = 0x8002;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_CONSTANT_ALPHA = 0x8003;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_ONE_MINUS_CONSTANT_ALPHA = 0x8004;

        //   Boolean
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_TRUE = 1;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_FALSE = 0;

        //   ClipPlaneName
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_CLIP_PLANE0 = 0x3000;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_CLIP_PLANE1 = 0x3001;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_CLIP_PLANE2 = 0x3002;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_CLIP_PLANE3 = 0x3003;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_CLIP_PLANE4 = 0x3004;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_CLIP_PLANE5 = 0x3005;

        //   DataType
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_BYTE = 0x1400;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_UNSIGNED_BYTE = 0x1401;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_SHORT = 0x1402;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_UNSIGNED_SHORT = 0x1403;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_INT = 0x1404;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_UNSIGNED_INT = 0x1405;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_FLOAT = 0x1406;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_2_BYTES = 0x1407;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_3_BYTES = 0x1408;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_4_BYTES = 0x1409;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_DOUBLE = 0x140A;

        ////   DrawBufferMode
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_NONE = 0;
        /// <summary>
        /// 
        /// </summary>
        public const uint gl_front_left = 0x0400;
        /// <summary>
        /// 
        /// </summary>
        public const uint gl_front_right = 0x0401;
        /// <summary>
        /// 
        /// </summary>
        public const uint gl_back_left = 0x0402;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_BACK_RIGHT = 0x0403;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_FRONT = 0x0404;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_BACK = 0x0405;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_LEFT = 0x0406;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_RIGHT = 0x0407;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_FRONT_AND_BACK = 0x0408;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_AUX0 = 0x0409;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_AUX1 = 0x040A;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_AUX2 = 0x040B;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_AUX3 = 0x040C;

        //   ErrorCode
        /// <summary>
        /// 
        /// </summary>
        internal const uint GL_NO_ERROR = 0;
        /// <summary>
        /// 
        /// </summary>
        internal const uint GL_INVALID_ENUM = 0x0500;
        /// <summary>
        /// 
        /// </summary>
        internal const uint GL_INVALID_VALUE = 0x0501;
        /// <summary>
        /// 
        /// </summary>
        internal const uint GL_INVALID_OPERATION = 0x0502;
        /// <summary>
        /// 
        /// </summary>
        internal const uint GL_STACK_OVERFLOW = 0x0503;
        /// <summary>
        /// 
        /// </summary>
        internal const uint GL_STACK_UNDERFLOW = 0x0504;
        /// <summary>
        /// 
        /// </summary>
        internal const uint GL_OUT_OF_MEMORY = 0x0505;

        //   FeedBackMode
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_2D = 0x0600;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_3D = 0x0601;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_4D_COLOR = 0x0602;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_3D_COLOR_TEXTURE = 0x0603;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_4D_COLOR_TEXTURE = 0x0604;

        //   FeedBackToken
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_PASS_THROUGH_TOKEN = 0x0700;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_POINT_TOKEN = 0x0701;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_LINE_TOKEN = 0x0702;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_POLYGON_TOKEN = 0x0703;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_BITMAP_TOKEN = 0x0704;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_DRAW_PIXEL_TOKEN = 0x0705;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_COPY_PIXEL_TOKEN = 0x0706;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_LINE_RESET_TOKEN = 0x0707;

        //   FogMode
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_EXP = 0x0800;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_EXP2 = 0x0801;

        //   FrontFaceDirection
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_CW = 0x0900;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_CCW = 0x0901;

        //    GetMapTarget 
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_COEFF = 0x0A00;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_ORDER = 0x0A01;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_DOMAIN = 0x0A02;

        //   GetTarget
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_CURRENT_COLOR = 0x0B00;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_CURRENT_INDEX = 0x0B01;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_CURRENT_NORMAL = 0x0B02;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_CURRENT_TEXTURE_COORDS = 0x0B03;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_CURRENT_RASTER_COLOR = 0x0B04;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_CURRENT_RASTER_INDEX = 0x0B05;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_CURRENT_RASTER_TEXTURE_COORDS = 0x0B06;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_CURRENT_RASTER_POSITION = 0x0B07;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_CURRENT_RASTER_POSITION_VALID = 0x0B08;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_CURRENT_RASTER_DISTANCE = 0x0B09;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_POINT_SMOOTH = 0x0B10;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_POINT_SIZE = 0x0B11;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_POINT_SIZE_RANGE = 0x0B12;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_POINT_SIZE_GRANULARITY = 0x0B13;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_LINE_SMOOTH = 0x0B20;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_LINE_WIDTH = 0x0B21;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_LINE_WIDTH_RANGE = 0x0B22;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_LINE_WIDTH_GRANULARITY = 0x0B23;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_LINE_STIPPLE = 0x0B24;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_LINE_STIPPLE_PATTERN = 0x0B25;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_LINE_STIPPLE_REPEAT = 0x0B26;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_LIST_MODE = 0x0B30;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_MAX_LIST_NESTING = 0x0B31;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_LIST_BASE = 0x0B32;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_LIST_INDEX = 0x0B33;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_POLYGON_MODE = 0x0B40;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_POLYGON_SMOOTH = 0x0B41;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_POLYGON_STIPPLE = 0x0B42;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_EDGE_FLAG = 0x0B43;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_CULL_FACE = 0x0B44;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_CULL_FACE_MODE = 0x0B45;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_FRONT_FACE = 0x0B46;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_LIGHTING = 0x0B50;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_LIGHT_MODEL_LOCAL_VIEWER = 0x0B51;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_LIGHT_MODEL_TWO_SIDE = 0x0B52;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_LIGHT_MODEL_AMBIENT = 0x0B53;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_SHADE_MODEL = 0x0B54;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_COLOR_MATERIAL_FACE = 0x0B55;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_COLOR_MATERIAL_PARAMETER = 0x0B56;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_COLOR_MATERIAL = 0x0B57;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_FOG = 0x0B60;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_FOG_INDEX = 0x0B61;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_FOG_DENSITY = 0x0B62;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_FOG_START = 0x0B63;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_FOG_END = 0x0B64;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_FOG_MODE = 0x0B65;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_FOG_COLOR = 0x0B66;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_DEPTH_RANGE = 0x0B70;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_DEPTH_TEST = 0x0B71;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_DEPTH_WRITEMASK = 0x0B72;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_DEPTH_CLEAR_VALUE = 0x0B73;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_DEPTH_FUNC = 0x0B74;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_ACCUM_CLEAR_VALUE = 0x0B80;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_STENCIL_TEST = 0x0B90;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_STENCIL_CLEAR_VALUE = 0x0B91;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_STENCIL_FUNC = 0x0B92;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_STENCIL_VALUE_MASK = 0x0B93;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_STENCIL_FAIL = 0x0B94;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_STENCIL_PASS_DEPTH_FAIL = 0x0B95;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_STENCIL_PASS_DEPTH_PASS = 0x0B96;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_STENCIL_REF = 0x0B97;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_STENCIL_WRITEMASK = 0x0B98;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_MATRIX_MODE = 0x0BA0;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_NORMALIZE = 0x0BA1;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_VIEWPORT = 0x0BA2;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_MODELVIEW_STACK_DEPTH = 0x0BA3;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_PROJECTION_STACK_DEPTH = 0x0BA4;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_TEXTURE_STACK_DEPTH = 0x0BA5;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_MODELVIEW_MATRIX = 0x0BA6;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_PROJECTION_MATRIX = 0x0BA7;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_TEXTURE_MATRIX = 0x0BA8;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_ATTRIB_STACK_DEPTH = 0x0BB0;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_CLIENT_ATTRIB_STACK_DEPTH = 0x0BB1;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_ALPHA_TEST = 0x0BC0;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_ALPHA_TEST_FUNC = 0x0BC1;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_ALPHA_TEST_REF = 0x0BC2;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_DITHER = 0x0BD0;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_BLEND_DST = 0x0BE0;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_BLEND_SRC = 0x0BE1;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_BLEND = 0x0BE2;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_LOGIC_OP_MODE = 0x0BF0;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_INDEX_LOGIC_OP = 0x0BF1;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_COLOR_LOGIC_OP = 0x0BF2;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_AUX_BUFFERS = 0x0C00;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_DRAW_BUFFER = 0x0C01;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_READ_BUFFER = 0x0C02;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_SCISSOR_BOX = 0x0C10;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_SCISSOR_TEST = 0x0C11;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_INDEX_CLEAR_VALUE = 0x0C20;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_INDEX_WRITEMASK = 0x0C21;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_COLOR_CLEAR_VALUE = 0x0C22;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_COLOR_WRITEMASK = 0x0C23;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_INDEX_MODE = 0x0C30;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_RGBA_MODE = 0x0C31;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_DOUBLEBUFFER = 0x0C32;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_STEREO = 0x0C33;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_RENDER_MODE = 0x0C40;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_PERSPECTIVE_CORRECTION_HINT = 0x0C50;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_POINT_SMOOTH_HINT = 0x0C51;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_LINE_SMOOTH_HINT = 0x0C52;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_POLYGON_SMOOTH_HINT = 0x0C53;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_FOG_HINT = 0x0C54;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_TEXTURE_GEN_S = 0x0C60;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_TEXTURE_GEN_T = 0x0C61;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_TEXTURE_GEN_R = 0x0C62;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_TEXTURE_GEN_Q = 0x0C63;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_PIXEL_MAP_I_TO_I = 0x0C70;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_PIXEL_MAP_S_TO_S = 0x0C71;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_PIXEL_MAP_I_TO_R = 0x0C72;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_PIXEL_MAP_I_TO_G = 0x0C73;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_PIXEL_MAP_I_TO_B = 0x0C74;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_PIXEL_MAP_I_TO_A = 0x0C75;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_PIXEL_MAP_R_TO_R = 0x0C76;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_PIXEL_MAP_G_TO_G = 0x0C77;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_PIXEL_MAP_B_TO_B = 0x0C78;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_PIXEL_MAP_A_TO_A = 0x0C79;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_PIXEL_MAP_I_TO_I_SIZE = 0x0CB0;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_PIXEL_MAP_S_TO_S_SIZE = 0x0CB1;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_PIXEL_MAP_I_TO_R_SIZE = 0x0CB2;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_PIXEL_MAP_I_TO_G_SIZE = 0x0CB3;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_PIXEL_MAP_I_TO_B_SIZE = 0x0CB4;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_PIXEL_MAP_I_TO_A_SIZE = 0x0CB5;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_PIXEL_MAP_R_TO_R_SIZE = 0x0CB6;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_PIXEL_MAP_G_TO_G_SIZE = 0x0CB7;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_PIXEL_MAP_B_TO_B_SIZE = 0x0CB8;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_PIXEL_MAP_A_TO_A_SIZE = 0x0CB9;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_UNPACK_SWAP_BYTES = 0x0CF0;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_UNPACK_LSB_FIRST = 0x0CF1;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_UNPACK_ROW_LENGTH = 0x0CF2;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_UNPACK_SKIP_ROWS = 0x0CF3;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_UNPACK_SKIP_PIXELS = 0x0CF4;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_UNPACK_ALIGNMENT = 0x0CF5;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_PACK_SWAP_BYTES = 0x0D00;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_PACK_LSB_FIRST = 0x0D01;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_PACK_ROW_LENGTH = 0x0D02;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_PACK_SKIP_ROWS = 0x0D03;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_PACK_SKIP_PIXELS = 0x0D04;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_PACK_ALIGNMENT = 0x0D05;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_MAP_COLOR = 0x0D10;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_MAP_STENCIL = 0x0D11;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_INDEX_SHIFT = 0x0D12;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_INDEX_OFFSET = 0x0D13;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_RED_SCALE = 0x0D14;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_RED_BIAS = 0x0D15;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_ZOOM_X = 0x0D16;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_ZOOM_Y = 0x0D17;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_GREEN_SCALE = 0x0D18;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_GREEN_BIAS = 0x0D19;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_BLUE_SCALE = 0x0D1A;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_BLUE_BIAS = 0x0D1B;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_ALPHA_SCALE = 0x0D1C;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_ALPHA_BIAS = 0x0D1D;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_DEPTH_SCALE = 0x0D1E;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_DEPTH_BIAS = 0x0D1F;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_MAX_EVAL_ORDER = 0x0D30;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_MAX_LIGHTS = 0x0D31;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_MAX_CLIP_PLANES = 0x0D32;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_MAX_TEXTURE_SIZE = 0x0D33;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_MAX_PIXEL_MAP_TABLE = 0x0D34;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_MAX_ATTRIB_STACK_DEPTH = 0x0D35;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_MAX_MODELVIEW_STACK_DEPTH = 0x0D36;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_MAX_NAME_STACK_DEPTH = 0x0D37;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_MAX_PROJECTION_STACK_DEPTH = 0x0D38;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_MAX_TEXTURE_STACK_DEPTH = 0x0D39;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_MAX_VIEWPORT_DIMS = 0x0D3A;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_MAX_CLIENT_ATTRIB_STACK_DEPTH = 0x0D3B;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_SUBPIXEL_BITS = 0x0D50;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_INDEX_BITS = 0x0D51;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_RED_BITS = 0x0D52;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_GREEN_BITS = 0x0D53;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_BLUE_BITS = 0x0D54;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_ALPHA_BITS = 0x0D55;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_DEPTH_BITS = 0x0D56;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_STENCIL_BITS = 0x0D57;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_ACCUM_RED_BITS = 0x0D58;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_ACCUM_GREEN_BITS = 0x0D59;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_ACCUM_BLUE_BITS = 0x0D5A;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_ACCUM_ALPHA_BITS = 0x0D5B;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_NAME_STACK_DEPTH = 0x0D70;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_AUTO_NORMAL = 0x0D80;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_MAP1_COLOR_4 = 0x0D90;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_MAP1_INDEX = 0x0D91;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_MAP1_NORMAL = 0x0D92;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_MAP1_TEXTURE_COORD_1 = 0x0D93;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_MAP1_TEXTURE_COORD_2 = 0x0D94;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_MAP1_TEXTURE_COORD_3 = 0x0D95;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_MAP1_TEXTURE_COORD_4 = 0x0D96;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_MAP1_VERTEX_3 = 0x0D97;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_MAP1_VERTEX_4 = 0x0D98;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_MAP2_COLOR_4 = 0x0DB0;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_MAP2_INDEX = 0x0DB1;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_MAP2_NORMAL = 0x0DB2;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_MAP2_TEXTURE_COORD_1 = 0x0DB3;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_MAP2_TEXTURE_COORD_2 = 0x0DB4;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_MAP2_TEXTURE_COORD_3 = 0x0DB5;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_MAP2_TEXTURE_COORD_4 = 0x0DB6;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_MAP2_VERTEX_3 = 0x0DB7;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_MAP2_VERTEX_4 = 0x0DB8;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_MAP1_GRID_DOMAIN = 0x0DD0;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_MAP1_GRID_SEGMENTS = 0x0DD1;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_MAP2_GRID_DOMAIN = 0x0DD2;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_MAP2_GRID_SEGMENTS = 0x0DD3;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_TEXTURE_1D = 0x0DE0;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_TEXTURE_2D = 0x0DE1;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_FEEDBACK_BUFFER_POINTER = 0x0DF0;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_FEEDBACK_BUFFER_SIZE = 0x0DF1;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_FEEDBACK_BUFFER_TYPE = 0x0DF2;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_SELECTION_BUFFER_POINTER = 0x0DF3;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_SELECTION_BUFFER_SIZE = 0x0DF4;

        //   GetTextureParameter
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_TEXTURE_WIDTH = 0x1000;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_TEXTURE_HEIGHT = 0x1001;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_TEXTURE_INTERNAL_FORMAT = 0x1003;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_TEXTURE_BORDER_COLOR = 0x1004;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_TEXTURE_BORDER = 0x1005;

        //   HintMode
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_DONT_CARE = 0x1100;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_FASTEST = 0x1101;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_NICEST = 0x1102;

        //   LightName
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_LIGHT0 = 0x4000;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_LIGHT1 = 0x4001;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_LIGHT2 = 0x4002;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_LIGHT3 = 0x4003;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_LIGHT4 = 0x4004;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_LIGHT5 = 0x4005;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_LIGHT6 = 0x4006;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_LIGHT7 = 0x4007;

        //   LightParameter
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_AMBIENT = 0x1200;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_DIFFUSE = 0x1201;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_SPECULAR = 0x1202;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_POSITION = 0x1203;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_SPOT_DIRECTION = 0x1204;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_SPOT_EXPONENT = 0x1205;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_SPOT_CUTOFF = 0x1206;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_CONSTANT_ATTENUATION = 0x1207;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_LINEAR_ATTENUATION = 0x1208;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_QUADRATIC_ATTENUATION = 0x1209;

        //   ListMode
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_COMPILE = 0x1300;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_COMPILE_AND_EXECUTE = 0x1301;

        //   LogicOp
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_CLEAR = 0x1500;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_AND = 0x1501;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_AND_REVERSE = 0x1502;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_COPY = 0x1503;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_AND_INVERTED = 0x1504;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_NOOP = 0x1505;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_XOR = 0x1506;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_OR = 0x1507;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_NOR = 0x1508;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_EQUIV = 0x1509;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_INVERT = 0x150A;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_OR_REVERSE = 0x150B;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_COPY_INVERTED = 0x150C;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_OR_INVERTED = 0x150D;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_NAND = 0x150E;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_SET = 0x150F;

        //   MaterialParameter
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_EMISSION = 0x1600;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_SHININESS = 0x1601;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_AMBIENT_AND_DIFFUSE = 0x1602;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_COLOR_INDEXES = 0x1603;

        //   MatrixMode
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_MODELVIEW = 0x1700;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_PROJECTION = 0x1701;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_TEXTURE = 0x1702;

        //   PixelCopyType
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_COLOR = 0x1800;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_DEPTH = 0x1801;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_STENCIL = 0x1802;

        //   PixelFormat
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_COLOR_INDEX = 0x1900;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_STENCIL_INDEX = 0x1901;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_DEPTH_COMPONENT = 0x1902;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_RED = 0x1903;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_GREEN = 0x1904;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_BLUE = 0x1905;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_ALPHA = 0x1906;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_RGB = 0x1907;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_RGBA = 0x1908;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_LUMINANCE = 0x1909;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_LUMINANCE_ALPHA = 0x190A;

        //   PixelType
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_BITMAP = 0x1A00;

        //   PolygonMode
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_POINT = 0x1B00;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_LINE = 0x1B01;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_FILL = 0x1B02;

        //   RenderingMode 
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_RENDER = 0x1C00;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_FEEDBACK = 0x1C01;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_SELECT = 0x1C02;

        //   ShadingModel
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_FLAT = 0x1D00;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_SMOOTH = 0x1D01;

        //   StencilOp	
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_KEEP = 0x1E00;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_REPLACE = 0x1E01;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_INCR = 0x1E02;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_DECR = 0x1E03;

        //   StringName
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_VENDOR = 0x1F00;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_RENDERER = 0x1F01;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_VERSION = 0x1F02;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_EXTENSIONS = 0x1F03;

        //   TextureCoordName
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_S = 0x2000;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_T = 0x2001;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_R = 0x2002;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_Q = 0x2003;

        //   TextureEnvMode
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_MODULATE = 0x2100;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_DECAL = 0x2101;

        //   TextureEnvParameter
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_TEXTURE_ENV_MODE = 0x2200;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_TEXTURE_ENV_COLOR = 0x2201;

        //   TextureEnvTarget
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_TEXTURE_ENV = 0x2300;

        //   TextureGenMode 
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_EYE_LINEAR = 0x2400;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_OBJECT_LINEAR = 0x2401;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_SPHERE_MAP = 0x2402;

        //   TextureGenParameter
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_TEXTURE_GEN_MODE = 0x2500;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_OBJECT_PLANE = 0x2501;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_EYE_PLANE = 0x2502;

        //   TextureMagFilter
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_NEAREST = 0x2600;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_LINEAR = 0x2601;

        //   TextureMinFilter 
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_NEAREST_MIPMAP_NEAREST = 0x2700;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_LINEAR_MIPMAP_NEAREST = 0x2701;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_NEAREST_MIPMAP_LINEAR = 0x2702;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_LINEAR_MIPMAP_LINEAR = 0x2703;

        //   TextureParameterName
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_TEXTURE_MAG_FILTER = 0x2800;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_TEXTURE_MIN_FILTER = 0x2801;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_TEXTURE_WRAP_S = 0x2802;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_TEXTURE_WRAP_T = 0x2803;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_GENERATE_MIPMAP = 0x8191;

        //   TextureWrapMode
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_CLAMP = 0x2900;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_REPEAT = 0x2901;

        //   ClientAttribMask
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_CLIENT_PIXEL_STORE_BIT = 0x00000001;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_CLIENT_VERTEX_ARRAY_BIT = 0x00000002;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_CLIENT_ALL_ATTRIB_BITS = 0xffffffff;

        //   Polygon Offset
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_POLYGON_OFFSET_FACTOR = 0x8038;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_POLYGON_OFFSET_UNITS = 0x2A00;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_POLYGON_OFFSET_POINT = 0x2A01;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_POLYGON_OFFSET_LINE = 0x2A02;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_POLYGON_OFFSET_FILL = 0x8037;

        //   Texture 
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_ALPHA4 = 0x803B;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_ALPHA8 = 0x803C;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_ALPHA12 = 0x803D;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_ALPHA16 = 0x803E;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_LUMINANCE4 = 0x803F;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_LUMINANCE8 = 0x8040;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_LUMINANCE12 = 0x8041;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_LUMINANCE16 = 0x8042;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_LUMINANCE4_ALPHA4 = 0x8043;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_LUMINANCE6_ALPHA2 = 0x8044;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_LUMINANCE8_ALPHA8 = 0x8045;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_LUMINANCE12_ALPHA4 = 0x8046;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_LUMINANCE12_ALPHA12 = 0x8047;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_LUMINANCE16_ALPHA16 = 0x8048;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_INTENSITY = 0x8049;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_INTENSITY4 = 0x804A;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_INTENSITY8 = 0x804B;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_INTENSITY12 = 0x804C;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_INTENSITY16 = 0x804D;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_R3_G3_B2 = 0x2A10;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_RGB4 = 0x804F;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_RGB5 = 0x8050;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_RGB8 = 0x8051;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_RGB10 = 0x8052;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_RGB12 = 0x8053;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_RGB16 = 0x8054;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_RGBA2 = 0x8055;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_RGBA4 = 0x8056;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_RGB5_A1 = 0x8057;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_RGBA8 = 0x8058;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_RGB10_A2 = 0x8059;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_RGBA12 = 0x805A;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_RGBA16 = 0x805B;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_TEXTURE_RED_SIZE = 0x805C;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_TEXTURE_GREEN_SIZE = 0x805D;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_TEXTURE_BLUE_SIZE = 0x805E;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_TEXTURE_ALPHA_SIZE = 0x805F;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_TEXTURE_LUMINANCE_SIZE = 0x8060;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_TEXTURE_INTENSITY_SIZE = 0x8061;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_PROXY_TEXTURE_1D = 0x8063;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_PROXY_TEXTURE_2D = 0x8064;

        //   Texture object
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_TEXTURE_PRIORITY = 0x8066;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_TEXTURE_RESIDENT = 0x8067;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_TEXTURE_BINDING_1D = 0x8068;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_TEXTURE_BINDING_2D = 0x8069;

        //   Vertex array
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_VERTEX_ARRAY = 0x8074;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_NORMAL_ARRAY = 0x8075;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_COLOR_ARRAY = 0x8076;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_INDEX_ARRAY = 0x8077;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_TEXTURE_COORD_ARRAY = 0x8078;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_EDGE_FLAG_ARRAY = 0x8079;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_VERTEX_ARRAY_SIZE = 0x807A;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_VERTEX_ARRAY_TYPE = 0x807B;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_VERTEX_ARRAY_STRIDE = 0x807C;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_NORMAL_ARRAY_TYPE = 0x807E;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_NORMAL_ARRAY_STRIDE = 0x807F;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_COLOR_ARRAY_SIZE = 0x8081;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_COLOR_ARRAY_TYPE = 0x8082;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_COLOR_ARRAY_STRIDE = 0x8083;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_INDEX_ARRAY_TYPE = 0x8085;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_INDEX_ARRAY_STRIDE = 0x8086;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_TEXTURE_COORD_ARRAY_SIZE = 0x8088;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_TEXTURE_COORD_ARRAY_TYPE = 0x8089;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_TEXTURE_COORD_ARRAY_STRIDE = 0x808A;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_EDGE_FLAG_ARRAY_STRIDE = 0x808C;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_VERTEX_ARRAY_POINTER = 0x808E;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_NORMAL_ARRAY_POINTER = 0x808F;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_COLOR_ARRAY_POINTER = 0x8090;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_INDEX_ARRAY_POINTER = 0x8091;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_TEXTURE_COORD_ARRAY_POINTER = 0x8092;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_EDGE_FLAG_ARRAY_POINTER = 0x8093;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_V2F = 0x2A20;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_V3F = 0x2A21;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_C4UB_V2F = 0x2A22;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_C4UB_V3F = 0x2A23;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_C3F_V3F = 0x2A24;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_N3F_V3F = 0x2A25;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_C4F_N3F_V3F = 0x2A26;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_T2F_V3F = 0x2A27;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_T4F_V4F = 0x2A28;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_T2F_C4UB_V3F = 0x2A29;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_T2F_C3F_V3F = 0x2A2A;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_T2F_N3F_V3F = 0x2A2B;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_T2F_C4F_N3F_V3F = 0x2A2C;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_T4F_C4F_N3F_V4F = 0x2A2D;

        //   Extensions
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_EXT_vertex_array = 1;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_EXT_bgra = 1;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_EXT_paletted_texture = 1;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_WIN_swap_hint = 1;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_WIN_draw_range_elements = 1;

        /// <summary>
        /// 
        /// </summary>
        public const uint GL_VERTEX_ARRAY_COUNT = 0x807D;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_NORMAL_ARRAY_COUNT = 0x8080;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_COLOR_ARRAY_COUNT = 0x8084;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_INDEX_ARRAY_COUNT = 0x8087;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_TEXTURE_COORD_ARRAY_COUNT = 0x808B;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_EDGE_FLAG_ARRAY_COUNT = 0x808D;

        //   EXT_paletted_texture
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_COLOR_TABLE_FORMAT = 0x80D8;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_COLOR_TABLE_WIDTH = 0x80D9;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_COLOR_TABLE_RED_SIZE = 0x80DA;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_COLOR_TABLE_GREEN_SIZE = 0x80DB;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_COLOR_TABLE_BLUE_SIZE = 0x80DC;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_COLOR_TABLE_ALPHA_SIZE = 0x80DD;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_COLOR_TABLE_LUMINANCE_SIZE = 0x80DE;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_COLOR_TABLE_INTENSITY_SIZE = 0x80DF;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_COLOR_INDEX1 = 0x80E2;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_COLOR_INDEX2 = 0x80E3;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_COLOR_INDEX4 = 0x80E4;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_COLOR_INDEX8 = 0x80E5;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_COLOR_INDEX12 = 0x80E6;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_COLOR_INDEX16 = 0x80E7;

        //   WIN_draw_range_elements
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_MAX_ELEMENTS_VERTICES_WIN = 0x80E8;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_MAX_ELEMENTS_INDICES_WIN = 0x80E9;

        //   WIN_phong_shading
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_PHONG_WIN = 0x80EA;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_PHONG_HINT_WIN = 0x80EB;


        //   WIN_specular_fog 
        /// <summary>
        /// 
        /// </summary>
        public static uint FOG_SPECULAR_TEXTURE_WIN = 0x80EC;

        #endregion

    }
}
