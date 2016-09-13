namespace CSharpGL
{
    /// <summary>
    ///
    /// </summary>
    public enum GetTarget : uint
    {
        /// <summary>
        ///
        /// </summary>
        CurrentColor = OpenGL.GL_CURRENT_COLOR,

        /// <summary>
        ///
        /// </summary>
        CurrentIndex = OpenGL.GL_CURRENT_INDEX,

        /// <summary>
        ///
        /// </summary>
        CurrentNormal = OpenGL.GL_CURRENT_NORMAL,

        /// <summary>
        ///
        /// </summary>
        CurrentTextureCoords = OpenGL.GL_CURRENT_TEXTURE_COORDS,

        /// <summary>
        ///
        /// </summary>
        CurrentRasterColor = OpenGL.GL_CURRENT_RASTER_COLOR,

        /// <summary>
        ///
        /// </summary>
        CurrentRasterIndex = OpenGL.GL_CURRENT_RASTER_INDEX,

        /// <summary>
        ///
        /// </summary>
        CurrentRasterTextureCoords = OpenGL.GL_CURRENT_RASTER_TEXTURE_COORDS,

        /// <summary>
        ///
        /// </summary>
        CurrentRasterPosition = OpenGL.GL_CURRENT_RASTER_POSITION,

        /// <summary>
        ///
        /// </summary>
        CurrentRasterPositionValid = OpenGL.GL_CURRENT_RASTER_POSITION_VALID,

        /// <summary>
        ///
        /// </summary>
        CurrentRasterDistance = OpenGL.GL_CURRENT_RASTER_DISTANCE,

        /// <summary>
        ///
        /// </summary>
        PointSmooth = OpenGL.GL_POINT_SMOOTH,

        /// <summary>
        ///
        /// </summary>
        PointSize = OpenGL.GL_POINT_SIZE,

        /// <summary>
        ///
        /// </summary>
        PointSizeRange = OpenGL.GL_POINT_SIZE_RANGE,

        /// <summary>
        ///
        /// </summary>
        PointSizeGranularity = OpenGL.GL_POINT_SIZE_GRANULARITY,

        /// <summary>
        ///
        /// </summary>
        LineSmooth = OpenGL.GL_LINE_SMOOTH,

        /// <summary>
        ///
        /// </summary>
        LineWidth = OpenGL.GL_LINE_WIDTH,

        /// <summary>
        ///
        /// </summary>
        LineWidthRange = OpenGL.GL_LINE_WIDTH_RANGE,

        /// <summary>
        ///
        /// </summary>
        LineWidthGranularity = OpenGL.GL_LINE_WIDTH_GRANULARITY,

        /// <summary>
        ///
        /// </summary>
        LineStipple = OpenGL.GL_LINE_STIPPLE,

        /// <summary>
        ///
        /// </summary>
        LineStipplePattern = OpenGL.GL_LINE_STIPPLE_PATTERN,

        /// <summary>
        ///
        /// </summary>
        LineStippleRepeat = OpenGL.GL_LINE_STIPPLE_REPEAT,

        /// <summary>
        ///
        /// </summary>
        ListMode = OpenGL.GL_LIST_MODE,

        /// <summary>
        ///
        /// </summary>
        MaxListNesting = OpenGL.GL_MAX_LIST_NESTING,

        /// <summary>
        ///
        /// </summary>
        ListBase = OpenGL.GL_LIST_BASE,

        /// <summary>
        ///
        /// </summary>
        ListIndex = OpenGL.GL_LIST_INDEX,

        /// <summary>
        ///
        /// </summary>
        PolygonMode = OpenGL.GL_POLYGON_MODE,

        /// <summary>
        ///
        /// </summary>
        PolygonSmooth = OpenGL.GL_POLYGON_SMOOTH,

        /// <summary>
        ///
        /// </summary>
        PolygonStipple = OpenGL.GL_POLYGON_STIPPLE,

        /// <summary>
        ///
        /// </summary>
        EdgeFlag = OpenGL.GL_EDGE_FLAG,

        /// <summary>
        ///
        /// </summary>
        CullFace = OpenGL.GL_CULL_FACE,

        /// <summary>
        ///
        /// </summary>
        CullFaceMode = OpenGL.GL_CULL_FACE_MODE,

        /// <summary>
        ///
        /// </summary>
        FrontFace = OpenGL.GL_FRONT_FACE,

        /// <summary>
        ///
        /// </summary>
        Lighting = OpenGL.GL_LIGHTING,

        /// <summary>
        ///
        /// </summary>
        LightModelLocalViewer = OpenGL.GL_LIGHT_MODEL_LOCAL_VIEWER,

        /// <summary>
        ///
        /// </summary>
        LightModelTwoSide = OpenGL.GL_LIGHT_MODEL_TWO_SIDE,

        /// <summary>
        ///
        /// </summary>
        LightModelAmbient = OpenGL.GL_LIGHT_MODEL_AMBIENT,

        /// <summary>
        ///
        /// </summary>
        ShadeModel = OpenGL.GL_SHADE_MODEL,

        /// <summary>
        ///
        /// </summary>
        ColorMaterialFace = OpenGL.GL_COLOR_MATERIAL_FACE,

        /// <summary>
        ///
        /// </summary>
        ColorMaterialParameter = OpenGL.GL_COLOR_MATERIAL_PARAMETER,

        /// <summary>
        ///
        /// </summary>
        ColorMaterial = OpenGL.GL_COLOR_MATERIAL,

        /// <summary>
        ///
        /// </summary>
        Fog = OpenGL.GL_FOG,

        /// <summary>
        ///
        /// </summary>
        FogIndex = OpenGL.GL_FOG_INDEX,

        /// <summary>
        ///
        /// </summary>
        FogDensity = OpenGL.GL_FOG_DENSITY,

        /// <summary>
        ///
        /// </summary>
        FogStart = OpenGL.GL_FOG_START,

        /// <summary>
        ///
        /// </summary>
        FogEnd = OpenGL.GL_FOG_END,

        /// <summary>
        ///
        /// </summary>
        FogMode = OpenGL.GL_FOG_MODE,

        /// <summary>
        ///
        /// </summary>
        FogColor = OpenGL.GL_FOG_COLOR,

        /// <summary>
        ///
        /// </summary>
        DepthRange = OpenGL.GL_DEPTH_RANGE,

        /// <summary>
        ///
        /// </summary>
        DepthTest = OpenGL.GL_DEPTH_TEST,

        /// <summary>
        /// Gets result of glDepthMask(bool writable);
        /// </summary>
        DepthWritemask = OpenGL.GL_DEPTH_WRITEMASK,

        /// <summary>
        ///
        /// </summary>
        DepthClearValue = OpenGL.GL_DEPTH_CLEAR_VALUE,

        /// <summary>
        ///
        /// </summary>
        DepthFunc = OpenGL.GL_DEPTH_FUNC,

        /// <summary>
        ///
        /// </summary>
        AccumClearValue = OpenGL.GL_ACCUM_CLEAR_VALUE,

        /// <summary>
        ///
        /// </summary>
        StencilTest = OpenGL.GL_STENCIL_TEST,

        /// <summary>
        ///
        /// </summary>
        StencilClearValue = OpenGL.GL_STENCIL_CLEAR_VALUE,

        /// <summary>
        ///
        /// </summary>
        StencilFunc = OpenGL.GL_STENCIL_FUNC,

        /// <summary>
        ///
        /// </summary>
        StencilValueMask = OpenGL.GL_STENCIL_VALUE_MASK,

        /// <summary>
        ///
        /// </summary>
        StencilFail = OpenGL.GL_STENCIL_FAIL,

        /// <summary>
        ///
        /// </summary>
        StencilPassDepthFail = OpenGL.GL_STENCIL_PASS_DEPTH_FAIL,

        /// <summary>
        ///
        /// </summary>
        StencilPassDepthPass = OpenGL.GL_STENCIL_PASS_DEPTH_PASS,

        /// <summary>
        ///
        /// </summary>
        StencilRef = OpenGL.GL_STENCIL_REF,

        /// <summary>
        ///
        /// </summary>
        StencilWritemask = OpenGL.GL_STENCIL_WRITEMASK,

        /// <summary>
        ///
        /// </summary>
        MatrixMode = OpenGL.GL_MATRIX_MODE,

        /// <summary>
        ///
        /// </summary>
        Normalize = OpenGL.GL_NORMALIZE,

        /// <summary>
        ///
        /// </summary>
        Viewport = OpenGL.GL_VIEWPORT,

        /// <summary>
        ///
        /// </summary>
        ModelviewStackDepth = OpenGL.GL_MODELVIEW_STACK_DEPTH,

        /// <summary>
        ///
        /// </summary>
        ProjectionStackDepth = OpenGL.GL_PROJECTION_STACK_DEPTH,

        /// <summary>
        ///
        /// </summary>
        TextureStackDepth = OpenGL.GL_TEXTURE_STACK_DEPTH,

        /// <summary>
        ///
        /// </summary>
        ModelviewMatix = OpenGL.GL_MODELVIEW_MATRIX,

        /// <summary>
        ///
        /// </summary>
        ProjectionMatrix = OpenGL.GL_PROJECTION_MATRIX,

        /// <summary>
        ///
        /// </summary>
        TextureMatrix = OpenGL.GL_TEXTURE_MATRIX,

        /// <summary>
        ///
        /// </summary>
        AttribStackDepth = OpenGL.GL_ATTRIB_STACK_DEPTH,

        /// <summary>
        ///
        /// </summary>
        ClientAttribStackDepth = OpenGL.GL_CLIENT_ATTRIB_STACK_DEPTH,

        /// <summary>
        ///
        /// </summary>
        AlphaTest = OpenGL.GL_ALPHA_TEST,

        /// <summary>
        ///
        /// </summary>
        AlphaTestFunc = OpenGL.GL_ALPHA_TEST_FUNC,

        /// <summary>
        ///
        /// </summary>
        AlphaTestRef = OpenGL.GL_ALPHA_TEST_REF,

        /// <summary>
        ///
        /// </summary>
        Dither = OpenGL.GL_DITHER,

        /// <summary>
        ///
        /// </summary>
        BlendDst = OpenGL.GL_BLEND_DST,

        /// <summary>
        ///
        /// </summary>
        BlendSrc = OpenGL.GL_BLEND_SRC,

        /// <summary>
        ///
        /// </summary>
        Blend = OpenGL.GL_BLEND,

        /// <summary>
        ///
        /// </summary>
        LogicOpMode = OpenGL.GL_LOGIC_OP_MODE,

        /// <summary>
        ///
        /// </summary>
        IndexLogicOp = OpenGL.GL_INDEX_LOGIC_OP,

        /// <summary>
        ///
        /// </summary>
        ColorLogicOp = OpenGL.GL_COLOR_LOGIC_OP,

        /// <summary>
        ///
        /// </summary>
        AuxBuffers = OpenGL.GL_AUX_BUFFERS,

        /// <summary>
        ///
        /// </summary>
        DrawBuffer = OpenGL.GL_DRAW_BUFFER,

        /// <summary>
        ///
        /// </summary>
        ReadBuffer = OpenGL.GL_READ_BUFFER,

        /// <summary>
        ///
        /// </summary>
        ScissorBox = OpenGL.GL_SCISSOR_BOX,

        /// <summary>
        ///
        /// </summary>
        ScissorTest = OpenGL.GL_SCISSOR_TEST,

        /// <summary>
        ///
        /// </summary>
        IndexClearValue = OpenGL.GL_INDEX_CLEAR_VALUE,

        /// <summary>
        ///
        /// </summary>
        IndexWritemask = OpenGL.GL_INDEX_WRITEMASK,

        /// <summary>
        ///
        /// </summary>
        ColorClearValue = OpenGL.GL_COLOR_CLEAR_VALUE,

        /// <summary>
        ///
        /// </summary>
        ColorWritemask = OpenGL.GL_COLOR_WRITEMASK,

        /// <summary>
        ///
        /// </summary>
        IndexMode = OpenGL.GL_INDEX_MODE,

        /// <summary>
        ///
        /// </summary>
        RgbaMode = OpenGL.GL_RGBA_MODE,

        /// <summary>
        ///
        /// </summary>
        DoubleBuffer = OpenGL.GL_DOUBLEBUFFER,

        /// <summary>
        ///
        /// </summary>
        Stereo = OpenGL.GL_STEREO,

        /// <summary>
        ///
        /// </summary>
        RenderMode = OpenGL.GL_RENDER_MODE,

        /// <summary>
        ///
        /// </summary>
        PerspectiveCorrectionHint = OpenGL.GL_PERSPECTIVE_CORRECTION_HINT,

        /// <summary>
        ///
        /// </summary>
        PointSmoothHint = OpenGL.GL_POINT_SMOOTH_HINT,

        /// <summary>
        ///
        /// </summary>
        LineSmoothHint = OpenGL.GL_LINE_SMOOTH_HINT,

        /// <summary>
        ///
        /// </summary>
        PolygonSmoothHint = OpenGL.GL_POLYGON_SMOOTH_HINT,

        /// <summary>
        ///
        /// </summary>
        FogHint = OpenGL.GL_FOG_HINT,

        /// <summary>
        ///
        /// </summary>
        TextureGenS = OpenGL.GL_TEXTURE_GEN_S,

        /// <summary>
        ///
        /// </summary>
        TextureGenT = OpenGL.GL_TEXTURE_GEN_T,

        /// <summary>
        ///
        /// </summary>
        TextureGenR = OpenGL.GL_TEXTURE_GEN_R,

        /// <summary>
        ///
        /// </summary>
        TextureGenQ = OpenGL.GL_TEXTURE_GEN_Q,

        /// <summary>
        ///
        /// </summary>
        PixelMapItoI = OpenGL.GL_PIXEL_MAP_I_TO_I,

        /// <summary>
        ///
        /// </summary>
        PixelMapStoS = OpenGL.GL_PIXEL_MAP_S_TO_S,

        /// <summary>
        ///
        /// </summary>
        PixelMapItoR = OpenGL.GL_PIXEL_MAP_I_TO_R,

        /// <summary>
        ///
        /// </summary>
        PixelMapItoG = OpenGL.GL_PIXEL_MAP_I_TO_G,

        /// <summary>
        ///
        /// </summary>
        PixelMapItoB = OpenGL.GL_PIXEL_MAP_I_TO_B,

        /// <summary>
        ///
        /// </summary>
        PixelMapItoA = OpenGL.GL_PIXEL_MAP_I_TO_A,

        /// <summary>
        ///
        /// </summary>
        PixelMapRtoR = OpenGL.GL_PIXEL_MAP_R_TO_R,

        /// <summary>
        ///
        /// </summary>
        PixelMapGtoG = OpenGL.GL_PIXEL_MAP_G_TO_G,

        /// <summary>
        ///
        /// </summary>
        PixelMapBtoB = OpenGL.GL_PIXEL_MAP_B_TO_B,

        /// <summary>
        ///
        /// </summary>
        PixelMapAtoA = OpenGL.GL_PIXEL_MAP_A_TO_A,

        /// <summary>
        ///
        /// </summary>
        PixelMapItoISize = OpenGL.GL_PIXEL_MAP_I_TO_I_SIZE,

        /// <summary>
        ///
        /// </summary>
        PixelMapStoSSize = OpenGL.GL_PIXEL_MAP_S_TO_S_SIZE,

        /// <summary>
        ///
        /// </summary>
        PixelMapItoRSize = OpenGL.GL_PIXEL_MAP_I_TO_R_SIZE,

        /// <summary>
        ///
        /// </summary>
        PixelMapItoGSize = OpenGL.GL_PIXEL_MAP_I_TO_G_SIZE,

        /// <summary>
        ///
        /// </summary>
        PixelMapItoBSize = OpenGL.GL_PIXEL_MAP_I_TO_B_SIZE,

        /// <summary>
        ///
        /// </summary>
        PixelMapItoASize = OpenGL.GL_PIXEL_MAP_I_TO_A_SIZE,

        /// <summary>
        ///
        /// </summary>
        PixelMapRtoRSize = OpenGL.GL_PIXEL_MAP_R_TO_R_SIZE,

        /// <summary>
        ///
        /// </summary>
        PixelMapGtoGSize = OpenGL.GL_PIXEL_MAP_G_TO_G_SIZE,

        /// <summary>
        ///
        /// </summary>
        PixelMapBtoBSize = OpenGL.GL_PIXEL_MAP_B_TO_B_SIZE,

        /// <summary>
        ///
        /// </summary>
        PixelMapAtoASize = OpenGL.GL_PIXEL_MAP_A_TO_A_SIZE,

        /// <summary>
        ///
        /// </summary>
        UnpackSwapBytes = OpenGL.GL_UNPACK_SWAP_BYTES,

        /// <summary>
        ///
        /// </summary>
        LsbFirst = OpenGL.GL_UNPACK_LSB_FIRST,

        /// <summary>
        ///
        /// </summary>
        UnpackRowLength = OpenGL.GL_UNPACK_ROW_LENGTH,

        /// <summary>
        ///
        /// </summary>
        UnpackSkipRows = OpenGL.GL_UNPACK_SKIP_ROWS,

        /// <summary>
        ///
        /// </summary>
        UnpackSkipPixels = OpenGL.GL_UNPACK_SKIP_PIXELS,

        /// <summary>
        ///
        /// </summary>
        UnpackAlignment = OpenGL.GL_UNPACK_ALIGNMENT,

        /// <summary>
        ///
        /// </summary>
        PackSwapBytes = OpenGL.GL_PACK_SWAP_BYTES,

        /// <summary>
        ///
        /// </summary>
        PackLsbFirst = OpenGL.GL_PACK_LSB_FIRST,

        /// <summary>
        ///
        /// </summary>
        PackRowLength = OpenGL.GL_PACK_ROW_LENGTH,

        /// <summary>
        ///
        /// </summary>
        PackSkipRows = OpenGL.GL_PACK_SKIP_ROWS,

        /// <summary>
        ///
        /// </summary>
        PackSkipPixels = OpenGL.GL_PACK_SKIP_PIXELS,

        /// <summary>
        ///
        /// </summary>
        PackAlignment = OpenGL.GL_PACK_ALIGNMENT,

        /// <summary>
        ///
        /// </summary>
        MapColor = OpenGL.GL_MAP_COLOR,

        /// <summary>
        ///
        /// </summary>
        MapStencil = OpenGL.GL_MAP_STENCIL,

        /// <summary>
        ///
        /// </summary>
        IndexShift = OpenGL.GL_INDEX_SHIFT,

        /// <summary>
        ///
        /// </summary>
        IndexOffset = OpenGL.GL_INDEX_OFFSET,

        /// <summary>
        ///
        /// </summary>
        RedScale = OpenGL.GL_RED_SCALE,

        /// <summary>
        ///
        /// </summary>
        RedBias = OpenGL.GL_RED_BIAS,

        /// <summary>
        ///
        /// </summary>
        ZoomX = OpenGL.GL_ZOOM_X,

        /// <summary>
        ///
        /// </summary>
        ZoomY = OpenGL.GL_ZOOM_Y,

        /// <summary>
        ///
        /// </summary>
        GreenScale = OpenGL.GL_GREEN_SCALE,

        /// <summary>
        ///
        /// </summary>
        GreenBias = OpenGL.GL_GREEN_BIAS,

        /// <summary>
        ///
        /// </summary>
        BlueScale = OpenGL.GL_BLUE_SCALE,

        /// <summary>
        ///
        /// </summary>
        BlueBias = OpenGL.GL_BLUE_BIAS,

        /// <summary>
        ///
        /// </summary>
        AlphaScale = OpenGL.GL_ALPHA_SCALE,

        /// <summary>
        ///
        /// </summary>
        AlphaBias = OpenGL.GL_ALPHA_BIAS,

        /// <summary>
        ///
        /// </summary>
        DepthScale = OpenGL.GL_DEPTH_SCALE,

        /// <summary>
        ///
        /// </summary>
        DepthBias = OpenGL.GL_DEPTH_BIAS,

        /// <summary>
        ///
        /// </summary>
        MapEvalOrder = OpenGL.GL_MAX_EVAL_ORDER,

        /// <summary>
        ///
        /// </summary>
        MaxLights = OpenGL.GL_MAX_LIGHTS,

        /// <summary>
        ///
        /// </summary>
        MaxClipPlanes = OpenGL.GL_MAX_CLIP_PLANES,

        /// <summary>
        ///
        /// </summary>
        MaxTextureSize = OpenGL.GL_MAX_TEXTURE_SIZE,

        /// <summary>
        ///
        /// </summary>
        MapPixelMapTable = OpenGL.GL_MAX_PIXEL_MAP_TABLE,

        /// <summary>
        ///
        /// </summary>
        MaxAttribStackDepth = OpenGL.GL_MAX_ATTRIB_STACK_DEPTH,

        /// <summary>
        ///
        /// </summary>
        MaxModelviewStackDepth = OpenGL.GL_MAX_MODELVIEW_STACK_DEPTH,

        /// <summary>
        ///
        /// </summary>
        MaxNameStackDepth = OpenGL.GL_MAX_NAME_STACK_DEPTH,

        /// <summary>
        ///
        /// </summary>
        MaxProjectionStackDepth = OpenGL.GL_MAX_PROJECTION_STACK_DEPTH,

        /// <summary>
        ///
        /// </summary>
        MaxTextureStackDepth = OpenGL.GL_MAX_TEXTURE_STACK_DEPTH,

        /// <summary>
        ///
        /// </summary>
        MaxViewportDims = OpenGL.GL_MAX_VIEWPORT_DIMS,

        /// <summary>
        ///
        /// </summary>
        MaxClientAttribStackDepth = OpenGL.GL_MAX_CLIENT_ATTRIB_STACK_DEPTH,

        /// <summary>
        ///
        /// </summary>
        SubpixelBits = OpenGL.GL_SUBPIXEL_BITS,

        /// <summary>
        ///
        /// </summary>
        IndexBits = OpenGL.GL_INDEX_BITS,

        /// <summary>
        ///
        /// </summary>
        RedBits = OpenGL.GL_RED_BITS,

        /// <summary>
        ///
        /// </summary>
        GreenBits = OpenGL.GL_GREEN_BITS,

        /// <summary>
        ///
        /// </summary>
        BlueBits = OpenGL.GL_BLUE_BITS,

        /// <summary>
        ///
        /// </summary>
        AlphaBits = OpenGL.GL_ALPHA_BITS,

        /// <summary>
        ///
        /// </summary>
        DepthBits = OpenGL.GL_DEPTH_BITS,

        /// <summary>
        ///
        /// </summary>
        StencilBits = OpenGL.GL_STENCIL_BITS,

        /// <summary>
        ///
        /// </summary>
        AccumRedBits = OpenGL.GL_ACCUM_RED_BITS,

        /// <summary>
        ///
        /// </summary>
        AccumGreenBits = OpenGL.GL_ACCUM_GREEN_BITS,

        /// <summary>
        ///
        /// </summary>
        AccumBlueBits = OpenGL.GL_ACCUM_BLUE_BITS,

        /// <summary>
        ///
        /// </summary>
        AccumAlphaBits = OpenGL.GL_ACCUM_ALPHA_BITS,

        /// <summary>
        ///
        /// </summary>
        NameStackDepth = OpenGL.GL_NAME_STACK_DEPTH,

        /// <summary>
        ///
        /// </summary>
        AutoNormal = OpenGL.GL_AUTO_NORMAL,

        /// <summary>
        ///
        /// </summary>
        Map1Color4 = OpenGL.GL_MAP1_COLOR_4,

        /// <summary>
        ///
        /// </summary>
        Map1Index = OpenGL.GL_MAP1_INDEX,

        /// <summary>
        ///
        /// </summary>
        Map1Normal = OpenGL.GL_MAP1_NORMAL,

        /// <summary>
        ///
        /// </summary>
        Map1TextureCoord1 = OpenGL.GL_MAP1_TEXTURE_COORD_1,

        /// <summary>
        ///
        /// </summary>
        Map1TextureCoord2 = OpenGL.GL_MAP1_TEXTURE_COORD_2,

        /// <summary>
        ///
        /// </summary>
        Map1TextureCoord3 = OpenGL.GL_MAP1_TEXTURE_COORD_3,

        /// <summary>
        ///
        /// </summary>
        Map1TextureCoord4 = OpenGL.GL_MAP1_TEXTURE_COORD_4,

        /// <summary>
        ///
        /// </summary>
        Map1Vertex3 = OpenGL.GL_MAP1_VERTEX_3,

        /// <summary>
        ///
        /// </summary>
        Map1Vertex4 = OpenGL.GL_MAP1_VERTEX_4,

        /// <summary>
        ///
        /// </summary>
        Map2Color4 = OpenGL.GL_MAP2_COLOR_4,

        /// <summary>
        ///
        /// </summary>
        Map2Index = OpenGL.GL_MAP2_INDEX,

        /// <summary>
        ///
        /// </summary>
        Map2Normal = OpenGL.GL_MAP2_NORMAL,

        /// <summary>
        ///
        /// </summary>
        Map2TextureCoord1 = OpenGL.GL_MAP2_TEXTURE_COORD_1,

        /// <summary>
        ///
        /// </summary>
        Map2TextureCoord2 = OpenGL.GL_MAP2_TEXTURE_COORD_2,

        /// <summary>
        ///
        /// </summary>
        Map2TextureCoord3 = OpenGL.GL_MAP2_TEXTURE_COORD_3,

        /// <summary>
        ///
        /// </summary>
        Map2TextureCoord4 = OpenGL.GL_MAP2_TEXTURE_COORD_4,

        /// <summary>
        ///
        /// </summary>
        Map2Vertex3 = OpenGL.GL_MAP2_VERTEX_3,

        /// <summary>
        ///
        /// </summary>
        Map2Vertex4 = OpenGL.GL_MAP2_VERTEX_4,

        /// <summary>
        ///
        /// </summary>
        Map1GridDomain = OpenGL.GL_MAP1_GRID_DOMAIN,

        /// <summary>
        ///
        /// </summary>
        Map1GridSegments = OpenGL.GL_MAP1_GRID_SEGMENTS,

        /// <summary>
        ///
        /// </summary>
        Map2GridDomain = OpenGL.GL_MAP2_GRID_DOMAIN,

        /// <summary>
        ///
        /// </summary>
        Map2GridSegments = OpenGL.GL_MAP2_GRID_SEGMENTS,

        /// <summary>
        ///
        /// </summary>
        Texture1D = OpenGL.GL_TEXTURE_1D,

        /// <summary>
        ///
        /// </summary>
        Texture2D = OpenGL.GL_TEXTURE_2D,

        /// <summary>
        ///
        /// </summary>
        FeedbackBufferPointer = OpenGL.GL_FEEDBACK_BUFFER_POINTER,

        /// <summary>
        ///
        /// </summary>
        FeedbackBufferSize = OpenGL.GL_FEEDBACK_BUFFER_SIZE,

        /// <summary>
        ///
        /// </summary>
        FeedbackBufferType = OpenGL.GL_FEEDBACK_BUFFER_TYPE,

        /// <summary>
        ///
        /// </summary>
        SelectionBufferPointer = OpenGL.GL_SELECTION_BUFFER_POINTER,

        /// <summary>
        ///
        /// </summary>
        SelectionBufferSize = OpenGL.GL_SELECTION_BUFFER_SIZE,

        /// <summary>
        ///
        /// </summary>
        UniformBufferOffsetAlignment = OpenGL.GL_UNIFORM_BUFFER_OFFSET_ALIGNMENT,
    }
}