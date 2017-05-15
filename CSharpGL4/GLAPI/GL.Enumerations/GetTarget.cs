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
        CurrentColor = GL.GL_CURRENT_COLOR,

        /// <summary>
        ///
        /// </summary>
        CurrentIndex = GL.GL_CURRENT_INDEX,

        /// <summary>
        ///
        /// </summary>
        CurrentNormal = GL.GL_CURRENT_NORMAL,

        /// <summary>
        ///
        /// </summary>
        CurrentTextureCoords = GL.GL_CURRENT_TEXTURE_COORDS,

        /// <summary>
        ///
        /// </summary>
        CurrentRasterColor = GL.GL_CURRENT_RASTER_COLOR,

        /// <summary>
        ///
        /// </summary>
        CurrentRasterIndex = GL.GL_CURRENT_RASTER_INDEX,

        /// <summary>
        ///
        /// </summary>
        CurrentRasterTextureCoords = GL.GL_CURRENT_RASTER_TEXTURE_COORDS,

        /// <summary>
        ///
        /// </summary>
        CurrentRasterPosition = GL.GL_CURRENT_RASTER_POSITION,

        /// <summary>
        ///
        /// </summary>
        CurrentRasterPositionValid = GL.GL_CURRENT_RASTER_POSITION_VALID,

        /// <summary>
        ///
        /// </summary>
        CurrentRasterDistance = GL.GL_CURRENT_RASTER_DISTANCE,

        /// <summary>
        ///
        /// </summary>
        PointSmooth = GL.GL_POINT_SMOOTH,

        /// <summary>
        ///
        /// </summary>
        PointSize = GL.GL_POINT_SIZE,

        /// <summary>
        ///
        /// </summary>
        PointSizeRange = GL.GL_POINT_SIZE_RANGE,

        /// <summary>
        ///
        /// </summary>
        PointSizeGranularity = GL.GL_POINT_SIZE_GRANULARITY,

        /// <summary>
        ///
        /// </summary>
        LineSmooth = GL.GL_LINE_SMOOTH,

        /// <summary>
        ///
        /// </summary>
        LineWidth = GL.GL_LINE_WIDTH,

        /// <summary>
        ///
        /// </summary>
        LineWidthRange = GL.GL_LINE_WIDTH_RANGE,

        /// <summary>
        ///
        /// </summary>
        LineWidthGranularity = GL.GL_LINE_WIDTH_GRANULARITY,

        /// <summary>
        ///
        /// </summary>
        LineStipple = GL.GL_LINE_STIPPLE,

        /// <summary>
        ///
        /// </summary>
        LineStipplePattern = GL.GL_LINE_STIPPLE_PATTERN,

        /// <summary>
        ///
        /// </summary>
        LineStippleRepeat = GL.GL_LINE_STIPPLE_REPEAT,

        /// <summary>
        ///
        /// </summary>
        ListMode = GL.GL_LIST_MODE,

        /// <summary>
        ///
        /// </summary>
        MaxListNesting = GL.GL_MAX_LIST_NESTING,

        /// <summary>
        ///
        /// </summary>
        ListBase = GL.GL_LIST_BASE,

        /// <summary>
        ///
        /// </summary>
        ListIndex = GL.GL_LIST_INDEX,

        /// <summary>
        ///
        /// </summary>
        PolygonMode = GL.GL_POLYGON_MODE,

        /// <summary>
        ///
        /// </summary>
        PolygonSmooth = GL.GL_POLYGON_SMOOTH,

        /// <summary>
        ///
        /// </summary>
        PolygonStipple = GL.GL_POLYGON_STIPPLE,

        /// <summary>
        ///
        /// </summary>
        EdgeFlag = GL.GL_EDGE_FLAG,

        /// <summary>
        ///
        /// </summary>
        CullFace = GL.GL_CULL_FACE,

        /// <summary>
        ///
        /// </summary>
        CullFaceMode = GL.GL_CULL_FACE_MODE,

        /// <summary>
        ///
        /// </summary>
        FrontFace = GL.GL_FRONT_FACE,

        /// <summary>
        ///
        /// </summary>
        Lighting = GL.GL_LIGHTING,

        /// <summary>
        ///
        /// </summary>
        LightModelLocalViewer = GL.GL_LIGHT_MODEL_LOCAL_VIEWER,

        /// <summary>
        ///
        /// </summary>
        LightModelTwoSide = GL.GL_LIGHT_MODEL_TWO_SIDE,

        /// <summary>
        ///
        /// </summary>
        LightModelAmbient = GL.GL_LIGHT_MODEL_AMBIENT,

        /// <summary>
        ///
        /// </summary>
        ShadeModel = GL.GL_SHADE_MODEL,

        /// <summary>
        ///
        /// </summary>
        ColorMaterialFace = GL.GL_COLOR_MATERIAL_FACE,

        /// <summary>
        ///
        /// </summary>
        ColorMaterialParameter = GL.GL_COLOR_MATERIAL_PARAMETER,

        /// <summary>
        ///
        /// </summary>
        ColorMaterial = GL.GL_COLOR_MATERIAL,

        /// <summary>
        ///
        /// </summary>
        Fog = GL.GL_FOG,

        /// <summary>
        ///
        /// </summary>
        FogIndex = GL.GL_FOG_INDEX,

        /// <summary>
        ///
        /// </summary>
        FogDensity = GL.GL_FOG_DENSITY,

        /// <summary>
        ///
        /// </summary>
        FogStart = GL.GL_FOG_START,

        /// <summary>
        ///
        /// </summary>
        FogEnd = GL.GL_FOG_END,

        /// <summary>
        ///
        /// </summary>
        FogMode = GL.GL_FOG_MODE,

        /// <summary>
        ///
        /// </summary>
        FogColor = GL.GL_FOG_COLOR,

        /// <summary>
        ///
        /// </summary>
        DepthRange = GL.GL_DEPTH_RANGE,

        /// <summary>
        ///
        /// </summary>
        DepthTest = GL.GL_DEPTH_TEST,

        /// <summary>
        /// Gets result of glDepthMask(bool writable);
        /// </summary>
        DepthWritemask = GL.GL_DEPTH_WRITEMASK,

        /// <summary>
        ///
        /// </summary>
        DepthClearValue = GL.GL_DEPTH_CLEAR_VALUE,

        /// <summary>
        ///
        /// </summary>
        DepthFunc = GL.GL_DEPTH_FUNC,

        /// <summary>
        ///
        /// </summary>
        AccumClearValue = GL.GL_ACCUM_CLEAR_VALUE,

        /// <summary>
        ///
        /// </summary>
        StencilTest = GL.GL_STENCIL_TEST,

        /// <summary>
        ///
        /// </summary>
        StencilClearValue = GL.GL_STENCIL_CLEAR_VALUE,

        /// <summary>
        ///
        /// </summary>
        StencilFunc = GL.GL_STENCIL_FUNC,

        /// <summary>
        ///
        /// </summary>
        StencilValueMask = GL.GL_STENCIL_VALUE_MASK,

        /// <summary>
        ///
        /// </summary>
        StencilFail = GL.GL_STENCIL_FAIL,

        /// <summary>
        ///
        /// </summary>
        StencilPassDepthFail = GL.GL_STENCIL_PASS_DEPTH_FAIL,

        /// <summary>
        ///
        /// </summary>
        StencilPassDepthPass = GL.GL_STENCIL_PASS_DEPTH_PASS,

        /// <summary>
        ///
        /// </summary>
        StencilRef = GL.GL_STENCIL_REF,

        /// <summary>
        ///
        /// </summary>
        StencilWritemask = GL.GL_STENCIL_WRITEMASK,

        /// <summary>
        ///
        /// </summary>
        StencilBackWritemask = GL.GL_STENCIL_BACK_WRITEMASK,

        /// <summary>
        ///
        /// </summary>
        MatrixMode = GL.GL_MATRIX_MODE,

        /// <summary>
        ///
        /// </summary>
        Normalize = GL.GL_NORMALIZE,

        /// <summary>
        ///
        /// </summary>
        Viewport = GL.GL_VIEWPORT,

        /// <summary>
        ///
        /// </summary>
        ModelviewStackDepth = GL.GL_MODELVIEW_STACK_DEPTH,

        /// <summary>
        ///
        /// </summary>
        ProjectionStackDepth = GL.GL_PROJECTION_STACK_DEPTH,

        /// <summary>
        ///
        /// </summary>
        TextureStackDepth = GL.GL_TEXTURE_STACK_DEPTH,

        /// <summary>
        ///
        /// </summary>
        ModelviewMatix = GL.GL_MODELVIEW_MATRIX,

        /// <summary>
        ///
        /// </summary>
        ProjectionMatrix = GL.GL_PROJECTION_MATRIX,

        /// <summary>
        ///
        /// </summary>
        TextureMatrix = GL.GL_TEXTURE_MATRIX,

        /// <summary>
        ///
        /// </summary>
        AttribStackDepth = GL.GL_ATTRIB_STACK_DEPTH,

        /// <summary>
        ///
        /// </summary>
        ClientAttribStackDepth = GL.GL_CLIENT_ATTRIB_STACK_DEPTH,

        /// <summary>
        ///
        /// </summary>
        AlphaTest = GL.GL_ALPHA_TEST,

        /// <summary>
        ///
        /// </summary>
        AlphaTestFunc = GL.GL_ALPHA_TEST_FUNC,

        /// <summary>
        ///
        /// </summary>
        AlphaTestRef = GL.GL_ALPHA_TEST_REF,

        /// <summary>
        ///
        /// </summary>
        Dither = GL.GL_DITHER,

        /// <summary>
        ///
        /// </summary>
        BlendDst = GL.GL_BLEND_DST,

        /// <summary>
        ///
        /// </summary>
        BlendSrc = GL.GL_BLEND_SRC,

        /// <summary>
        ///
        /// </summary>
        Blend = GL.GL_BLEND,

        /// <summary>
        ///
        /// </summary>
        LogicOpMode = GL.GL_LOGIC_OP_MODE,

        /// <summary>
        ///
        /// </summary>
        IndexLogicOp = GL.GL_INDEX_LOGIC_OP,

        /// <summary>
        ///
        /// </summary>
        ColorLogicOp = GL.GL_COLOR_LOGIC_OP,

        /// <summary>
        ///
        /// </summary>
        AuxBuffers = GL.GL_AUX_BUFFERS,

        /// <summary>
        ///
        /// </summary>
        DrawBuffer = GL.GL_DRAW_BUFFER,

        /// <summary>
        ///
        /// </summary>
        ReadBuffer = GL.GL_READ_BUFFER,

        /// <summary>
        ///
        /// </summary>
        ScissorBox = GL.GL_SCISSOR_BOX,

        /// <summary>
        ///
        /// </summary>
        ScissorTest = GL.GL_SCISSOR_TEST,

        /// <summary>
        ///
        /// </summary>
        IndexClearValue = GL.GL_INDEX_CLEAR_VALUE,

        /// <summary>
        ///
        /// </summary>
        IndexWritemask = GL.GL_INDEX_WRITEMASK,

        /// <summary>
        ///
        /// </summary>
        ColorClearValue = GL.GL_COLOR_CLEAR_VALUE,

        /// <summary>
        ///
        /// </summary>
        ColorWritemask = GL.GL_COLOR_WRITEMASK,

        /// <summary>
        ///
        /// </summary>
        IndexMode = GL.GL_INDEX_MODE,

        /// <summary>
        ///
        /// </summary>
        RgbaMode = GL.GL_RGBA_MODE,

        /// <summary>
        ///
        /// </summary>
        DoubleBuffer = GL.GL_DOUBLEBUFFER,

        /// <summary>
        ///
        /// </summary>
        Stereo = GL.GL_STEREO,

        /// <summary>
        ///
        /// </summary>
        RenderMode = GL.GL_RENDER_MODE,

        /// <summary>
        ///
        /// </summary>
        PerspectiveCorrectionHint = GL.GL_PERSPECTIVE_CORRECTION_HINT,

        /// <summary>
        ///
        /// </summary>
        PointSmoothHint = GL.GL_POINT_SMOOTH_HINT,

        /// <summary>
        ///
        /// </summary>
        LineSmoothHint = GL.GL_LINE_SMOOTH_HINT,

        /// <summary>
        ///
        /// </summary>
        PolygonSmoothHint = GL.GL_POLYGON_SMOOTH_HINT,

        /// <summary>
        ///
        /// </summary>
        FogHint = GL.GL_FOG_HINT,

        /// <summary>
        ///
        /// </summary>
        TextureGenS = GL.GL_TEXTURE_GEN_S,

        /// <summary>
        ///
        /// </summary>
        TextureGenT = GL.GL_TEXTURE_GEN_T,

        /// <summary>
        ///
        /// </summary>
        TextureGenR = GL.GL_TEXTURE_GEN_R,

        /// <summary>
        ///
        /// </summary>
        TextureGenQ = GL.GL_TEXTURE_GEN_Q,

        /// <summary>
        ///
        /// </summary>
        PixelMapItoI = GL.GL_PIXEL_MAP_I_TO_I,

        /// <summary>
        ///
        /// </summary>
        PixelMapStoS = GL.GL_PIXEL_MAP_S_TO_S,

        /// <summary>
        ///
        /// </summary>
        PixelMapItoR = GL.GL_PIXEL_MAP_I_TO_R,

        /// <summary>
        ///
        /// </summary>
        PixelMapItoG = GL.GL_PIXEL_MAP_I_TO_G,

        /// <summary>
        ///
        /// </summary>
        PixelMapItoB = GL.GL_PIXEL_MAP_I_TO_B,

        /// <summary>
        ///
        /// </summary>
        PixelMapItoA = GL.GL_PIXEL_MAP_I_TO_A,

        /// <summary>
        ///
        /// </summary>
        PixelMapRtoR = GL.GL_PIXEL_MAP_R_TO_R,

        /// <summary>
        ///
        /// </summary>
        PixelMapGtoG = GL.GL_PIXEL_MAP_G_TO_G,

        /// <summary>
        ///
        /// </summary>
        PixelMapBtoB = GL.GL_PIXEL_MAP_B_TO_B,

        /// <summary>
        ///
        /// </summary>
        PixelMapAtoA = GL.GL_PIXEL_MAP_A_TO_A,

        /// <summary>
        ///
        /// </summary>
        PixelMapItoISize = GL.GL_PIXEL_MAP_I_TO_I_SIZE,

        /// <summary>
        ///
        /// </summary>
        PixelMapStoSSize = GL.GL_PIXEL_MAP_S_TO_S_SIZE,

        /// <summary>
        ///
        /// </summary>
        PixelMapItoRSize = GL.GL_PIXEL_MAP_I_TO_R_SIZE,

        /// <summary>
        ///
        /// </summary>
        PixelMapItoGSize = GL.GL_PIXEL_MAP_I_TO_G_SIZE,

        /// <summary>
        ///
        /// </summary>
        PixelMapItoBSize = GL.GL_PIXEL_MAP_I_TO_B_SIZE,

        /// <summary>
        ///
        /// </summary>
        PixelMapItoASize = GL.GL_PIXEL_MAP_I_TO_A_SIZE,

        /// <summary>
        ///
        /// </summary>
        PixelMapRtoRSize = GL.GL_PIXEL_MAP_R_TO_R_SIZE,

        /// <summary>
        ///
        /// </summary>
        PixelMapGtoGSize = GL.GL_PIXEL_MAP_G_TO_G_SIZE,

        /// <summary>
        ///
        /// </summary>
        PixelMapBtoBSize = GL.GL_PIXEL_MAP_B_TO_B_SIZE,

        /// <summary>
        ///
        /// </summary>
        PixelMapAtoASize = GL.GL_PIXEL_MAP_A_TO_A_SIZE,

        /// <summary>
        ///
        /// </summary>
        UnpackSwapBytes = GL.GL_UNPACK_SWAP_BYTES,

        /// <summary>
        ///
        /// </summary>
        LsbFirst = GL.GL_UNPACK_LSB_FIRST,

        /// <summary>
        ///
        /// </summary>
        UnpackRowLength = GL.GL_UNPACK_ROW_LENGTH,

        /// <summary>
        ///
        /// </summary>
        UnpackSkipRows = GL.GL_UNPACK_SKIP_ROWS,

        /// <summary>
        ///
        /// </summary>
        UnpackSkipPixels = GL.GL_UNPACK_SKIP_PIXELS,

        /// <summary>
        ///
        /// </summary>
        UnpackAlignment = GL.GL_UNPACK_ALIGNMENT,

        /// <summary>
        ///
        /// </summary>
        PackSwapBytes = GL.GL_PACK_SWAP_BYTES,

        /// <summary>
        ///
        /// </summary>
        PackLsbFirst = GL.GL_PACK_LSB_FIRST,

        /// <summary>
        ///
        /// </summary>
        PackRowLength = GL.GL_PACK_ROW_LENGTH,

        /// <summary>
        ///
        /// </summary>
        PackSkipRows = GL.GL_PACK_SKIP_ROWS,

        /// <summary>
        ///
        /// </summary>
        PackSkipPixels = GL.GL_PACK_SKIP_PIXELS,

        /// <summary>
        ///
        /// </summary>
        PackAlignment = GL.GL_PACK_ALIGNMENT,

        /// <summary>
        ///
        /// </summary>
        MapColor = GL.GL_MAP_COLOR,

        /// <summary>
        ///
        /// </summary>
        MapStencil = GL.GL_MAP_STENCIL,

        /// <summary>
        ///
        /// </summary>
        IndexShift = GL.GL_INDEX_SHIFT,

        /// <summary>
        ///
        /// </summary>
        IndexOffset = GL.GL_INDEX_OFFSET,

        /// <summary>
        ///
        /// </summary>
        RedScale = GL.GL_RED_SCALE,

        /// <summary>
        ///
        /// </summary>
        RedBias = GL.GL_RED_BIAS,

        /// <summary>
        ///
        /// </summary>
        ZoomX = GL.GL_ZOOM_X,

        /// <summary>
        ///
        /// </summary>
        ZoomY = GL.GL_ZOOM_Y,

        /// <summary>
        ///
        /// </summary>
        GreenScale = GL.GL_GREEN_SCALE,

        /// <summary>
        ///
        /// </summary>
        GreenBias = GL.GL_GREEN_BIAS,

        /// <summary>
        ///
        /// </summary>
        BlueScale = GL.GL_BLUE_SCALE,

        /// <summary>
        ///
        /// </summary>
        BlueBias = GL.GL_BLUE_BIAS,

        /// <summary>
        ///
        /// </summary>
        AlphaScale = GL.GL_ALPHA_SCALE,

        /// <summary>
        ///
        /// </summary>
        AlphaBias = GL.GL_ALPHA_BIAS,

        /// <summary>
        ///
        /// </summary>
        DepthScale = GL.GL_DEPTH_SCALE,

        /// <summary>
        ///
        /// </summary>
        DepthBias = GL.GL_DEPTH_BIAS,

        /// <summary>
        ///
        /// </summary>
        MapEvalOrder = GL.GL_MAX_EVAL_ORDER,

        /// <summary>
        ///
        /// </summary>
        MaxLights = GL.GL_MAX_LIGHTS,

        /// <summary>
        ///
        /// </summary>
        MaxClipPlanes = GL.GL_MAX_CLIP_PLANES,

        /// <summary>
        ///
        /// </summary>
        MaxTextureSize = GL.GL_MAX_TEXTURE_SIZE,

        /// <summary>
        ///
        /// </summary>
        MapPixelMapTable = GL.GL_MAX_PIXEL_MAP_TABLE,

        /// <summary>
        ///
        /// </summary>
        MaxAttribStackDepth = GL.GL_MAX_ATTRIB_STACK_DEPTH,

        /// <summary>
        ///
        /// </summary>
        MaxModelviewStackDepth = GL.GL_MAX_MODELVIEW_STACK_DEPTH,

        /// <summary>
        ///
        /// </summary>
        MaxNameStackDepth = GL.GL_MAX_NAME_STACK_DEPTH,

        /// <summary>
        ///
        /// </summary>
        MaxProjectionStackDepth = GL.GL_MAX_PROJECTION_STACK_DEPTH,

        /// <summary>
        ///
        /// </summary>
        MaxTextureStackDepth = GL.GL_MAX_TEXTURE_STACK_DEPTH,

        /// <summary>
        ///
        /// </summary>
        MaxViewportDims = GL.GL_MAX_VIEWPORT_DIMS,

        /// <summary>
        ///
        /// </summary>
        MaxClientAttribStackDepth = GL.GL_MAX_CLIENT_ATTRIB_STACK_DEPTH,

        /// <summary>
        ///
        /// </summary>
        SubpixelBits = GL.GL_SUBPIXEL_BITS,

        /// <summary>
        ///
        /// </summary>
        IndexBits = GL.GL_INDEX_BITS,

        /// <summary>
        ///
        /// </summary>
        RedBits = GL.GL_RED_BITS,

        /// <summary>
        ///
        /// </summary>
        GreenBits = GL.GL_GREEN_BITS,

        /// <summary>
        ///
        /// </summary>
        BlueBits = GL.GL_BLUE_BITS,

        /// <summary>
        ///
        /// </summary>
        AlphaBits = GL.GL_ALPHA_BITS,

        /// <summary>
        ///
        /// </summary>
        DepthBits = GL.GL_DEPTH_BITS,

        /// <summary>
        ///
        /// </summary>
        StencilBits = GL.GL_STENCIL_BITS,

        /// <summary>
        ///
        /// </summary>
        AccumRedBits = GL.GL_ACCUM_RED_BITS,

        /// <summary>
        ///
        /// </summary>
        AccumGreenBits = GL.GL_ACCUM_GREEN_BITS,

        /// <summary>
        ///
        /// </summary>
        AccumBlueBits = GL.GL_ACCUM_BLUE_BITS,

        /// <summary>
        ///
        /// </summary>
        AccumAlphaBits = GL.GL_ACCUM_ALPHA_BITS,

        /// <summary>
        ///
        /// </summary>
        NameStackDepth = GL.GL_NAME_STACK_DEPTH,

        /// <summary>
        ///
        /// </summary>
        AutoNormal = GL.GL_AUTO_NORMAL,

        /// <summary>
        ///
        /// </summary>
        Map1Color4 = GL.GL_MAP1_COLOR_4,

        /// <summary>
        ///
        /// </summary>
        Map1Index = GL.GL_MAP1_INDEX,

        /// <summary>
        ///
        /// </summary>
        Map1Normal = GL.GL_MAP1_NORMAL,

        /// <summary>
        ///
        /// </summary>
        Map1TextureCoord1 = GL.GL_MAP1_TEXTURE_COORD_1,

        /// <summary>
        ///
        /// </summary>
        Map1TextureCoord2 = GL.GL_MAP1_TEXTURE_COORD_2,

        /// <summary>
        ///
        /// </summary>
        Map1TextureCoord3 = GL.GL_MAP1_TEXTURE_COORD_3,

        /// <summary>
        ///
        /// </summary>
        Map1TextureCoord4 = GL.GL_MAP1_TEXTURE_COORD_4,

        /// <summary>
        ///
        /// </summary>
        Map1Vertex3 = GL.GL_MAP1_VERTEX_3,

        /// <summary>
        ///
        /// </summary>
        Map1Vertex4 = GL.GL_MAP1_VERTEX_4,

        /// <summary>
        ///
        /// </summary>
        Map2Color4 = GL.GL_MAP2_COLOR_4,

        /// <summary>
        ///
        /// </summary>
        Map2Index = GL.GL_MAP2_INDEX,

        /// <summary>
        ///
        /// </summary>
        Map2Normal = GL.GL_MAP2_NORMAL,

        /// <summary>
        ///
        /// </summary>
        Map2TextureCoord1 = GL.GL_MAP2_TEXTURE_COORD_1,

        /// <summary>
        ///
        /// </summary>
        Map2TextureCoord2 = GL.GL_MAP2_TEXTURE_COORD_2,

        /// <summary>
        ///
        /// </summary>
        Map2TextureCoord3 = GL.GL_MAP2_TEXTURE_COORD_3,

        /// <summary>
        ///
        /// </summary>
        Map2TextureCoord4 = GL.GL_MAP2_TEXTURE_COORD_4,

        /// <summary>
        ///
        /// </summary>
        Map2Vertex3 = GL.GL_MAP2_VERTEX_3,

        /// <summary>
        ///
        /// </summary>
        Map2Vertex4 = GL.GL_MAP2_VERTEX_4,

        /// <summary>
        ///
        /// </summary>
        Map1GridDomain = GL.GL_MAP1_GRID_DOMAIN,

        /// <summary>
        ///
        /// </summary>
        Map1GridSegments = GL.GL_MAP1_GRID_SEGMENTS,

        /// <summary>
        ///
        /// </summary>
        Map2GridDomain = GL.GL_MAP2_GRID_DOMAIN,

        /// <summary>
        ///
        /// </summary>
        Map2GridSegments = GL.GL_MAP2_GRID_SEGMENTS,

        /// <summary>
        ///
        /// </summary>
        Texture1D = GL.GL_TEXTURE_1D,

        /// <summary>
        ///
        /// </summary>
        Texture2D = GL.GL_TEXTURE_2D,

        /// <summary>
        ///
        /// </summary>
        FeedbackBufferPointer = GL.GL_FEEDBACK_BUFFER_POINTER,

        /// <summary>
        ///
        /// </summary>
        FeedbackBufferSize = GL.GL_FEEDBACK_BUFFER_SIZE,

        /// <summary>
        ///
        /// </summary>
        FeedbackBufferType = GL.GL_FEEDBACK_BUFFER_TYPE,

        /// <summary>
        ///
        /// </summary>
        SelectionBufferPointer = GL.GL_SELECTION_BUFFER_POINTER,

        /// <summary>
        ///
        /// </summary>
        SelectionBufferSize = GL.GL_SELECTION_BUFFER_SIZE,

        /// <summary>
        ///
        /// </summary>
        UniformBufferOffsetAlignment = GL.GL_UNIFORM_BUFFER_OFFSET_ALIGNMENT,
    }
}