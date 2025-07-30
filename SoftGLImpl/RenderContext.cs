
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace SoftGLImpl {
    internal unsafe partial class RenderContext {
        //internal static RenderContext? current;

        ///// <summary>
        ///// cache for <see cref="SoftGL.GetProcAddress(string)"/>
        ///// </summary>
        //internal Dictionary<string, IntPtr> name2ProcAddress = new();

        internal readonly IntPtr hRC;
        /// <summary>
        /// something like Control.Handle
        /// </summary>
        internal readonly IntPtr windowHandle;
        internal readonly int width;
        internal readonly int height;

        public RenderContext(IntPtr windowHandle, int width, int height) {
            GCHandle handle = GCHandle.Alloc(this, GCHandleType.WeakTrackResurrection);
            var hRC = GCHandle.ToIntPtr(handle);
            handle.Free();
            this.hRC = hRC;

            this.windowHandle = windowHandle;
            this.width = width;
            this.height = height;

            foreach (var target in Enum.GetValues(typeof(BindBufferTarget))) {
                this.target2CurrentBuffer.Add((GLenum)target, null);
            }

            var target2 = (GLenum)BindFramebufferTarget.Framebuffer;
            //SoftGLImpl.SoftGL.GenFramebuffers(1, name, this);
            //SoftGLImpl.SoftGL.BindFramebuffer(target2, name[0], this);
            var framebuffer = new GLFramebuffer(0);
            this.target2CurrentFramebuffer[target2] = framebuffer;
            this.target2CurrentFramebuffer[(GLenum)BindFramebufferTarget.ReadFramebuffer] = framebuffer;
            this.target2CurrentFramebuffer[(GLenum)BindFramebufferTarget.DrawFramebuffer] = framebuffer;
            this.defaultFramebuffer = framebuffer;
            var name = stackalloc GLuint[1];
            SoftGLImpl.SoftGL.GenRenderbuffers(1, name, this);// renderbuffer object for color attachment.
            SoftGLImpl.SoftGL.BindRenderbuffer(GL.GL_RENDERBUFFER, name[0], this);
            SoftGLImpl.SoftGL.RenderbufferStorage(GL.GL_RENDERBUFFER, GL.GL_RGBA, width, height, this);
            //SoftGLImpl.SoftGL.BindRenderbuffer(GL.GL_RENDERBUFFER, 0, this);
            SoftGLImpl.SoftGL.FramebufferRenderbuffer(target2, GL.GL_COLOR_ATTACHMENT0, GL.GL_RENDERBUFFER, name[0], this);
            SoftGLImpl.SoftGL.GenRenderbuffers(1, name, this);// renderbuffer object for depth attachment.
            SoftGLImpl.SoftGL.BindRenderbuffer(GL.GL_RENDERBUFFER, name[0], this);
            SoftGLImpl.SoftGL.RenderbufferStorage(GL.GL_RENDERBUFFER, GL.GL_DEPTH_COMPONENT, width, height, this);
            //SoftGLImpl.SoftGL.BindRenderbuffer(GL.GL_RENDERBUFFER, 0, this);
            SoftGLImpl.SoftGL.FramebufferRenderbuffer(target2, GL.GL_DEPTH_ATTACHMENT, GL.GL_RENDERBUFFER, name[0], this);
            var buffer = GL.GL_FRONT_LEFT;
            SoftGLImpl.SoftGL.DrawBuffers(1, &buffer, this); // GL_COLOR_ATTACHMENT0 use the same buffer in SoftGL.
            SoftGLImpl.SoftGL.CheckFramebufferStatus(target2, this);
            //SoftGLImpl.SoftGL.BindFramebuffer(target2, 0, this); // not needed.

            this.viewport = new ivec4(0, 0, width, height);

            this.maxRenderbufferSize = 1024 * 8/*65536*/;

            this.textureUnits = new TextureUnit[this.maxTextureImageUnits];

            this.currentSamplers = new GLSampler[this.maxTextureImageUnits];
        }

        private GLenum _errorCode = 0;/*GL_NO_ERROR*/
        internal GLenum ErrorCode {
            get { return this._errorCode; }
            set { if (_errorCode == 0 || value == 0) { _errorCode = value; } }
        }

        internal Dictionary<GLenum/*BindBufferTarget*/, GLBuffer?> target2CurrentBuffer = new();
        //internal Dictionary<GLuint/*BindBufferTarget*/, List<GLBuffer?>> target2Buffers = new();
        internal List<IdObject<GLBuffer>?> idGLBuffers = new();

        internal GLVertexArrayObject? currentVertexArrayObject;
        internal List<IdObject<GLVertexArrayObject>?> idVertexArrayObjects = new();

        //internal ShaderProgram? currentShaderProgram;
        //internal List<ShaderProgram?> shaderPrograms = new();

        internal Dictionary<GLenum/*BindFramebufferTarget*/, GLFramebuffer?> target2CurrentFramebuffer = new();
        internal readonly GLFramebuffer defaultFramebuffer;
        //internal Framebuffer currentFramebuffer;
        internal List<IdObject<GLFramebuffer>?> idFramebuffers = new();
        //private GLuint nextFramebufferName = 0;
        //private readonly List<GLuint> framebufferNameList = new();
        ///// <summary>
        ///// name -> render buffer object.
        ///// </summary>
        //private readonly Dictionary<GLuint, Framebuffer> nameFramebufferDict = new();
        //private readonly Framebuffer defaultFramebuffer;
        //private Framebuffer currentFramebuffer;

        internal readonly GLsizei maxRenderbufferSize = 16384;
        internal Dictionary<GLenum/*BindBufferTarget*/, GLRenderbuffer?> target2CurrentRenderbuffer = new();
        //internal Dictionary<GLenum/*BindBufferTarget*/, List<Renderbuffer?>> target2Renderbuffers = new();
        internal List<IdObject<GLRenderbuffer>?> idRenderbuffers = new();
        //private uint nextRenderbufferName = 1;
        //private readonly List<GLuint> renderbufferNameList = new();
        //private readonly Dictionary<GLuint, Renderbuffer> nameRenderbufferDict = new();
        //private Renderbuffer[] currentRenderbuffers = new Renderbuffer[1]; // [GL_RENDERBUFFER]
        //private const int maxRenderbufferSize = 1024 * 8; // TODO: maxRenderbufferSize = ?
        internal ivec4 viewport;
        internal bool bounded = false;
        internal double depthRangeNear = 0;
        internal double depthRangeFar = 1;

        internal GLuint nextShaderName = 1;
        internal Dictionary<GLuint, GLShader> name2Shader = new();

        internal uint nextShaderProgramName = 1;
        internal readonly Dictionary<GLuint, GLProgram> name2Program = new();
        internal GLProgram? currentShaderProgram = null;

        internal GLuint nextTextureName = 1;

        //internal readonly List<GLuint> textureNameList = new();
        //internal readonly Dictionary<GLuint, Texture> name2Texture = new();

        internal readonly int maxTextureSize = 1024 * 8; // TODO: maxRenderbufferSize = ?
        internal readonly int maxTextureImageUnits = 8;
        internal TextureUnit[] textureUnits;// = new TextureUnit[maxTextureImageUnits];
        internal uint currentTextureUnitIndex = 0;
        internal List<IdObject<GLTexture>?> idTextures = new();

        //internal GLuint nextSamplerName = 1;
        //internal readonly Dictionary<GLuint, Sampler> name2Sampler = new();
        internal GLSampler?[] currentSamplers;// = new Sampler[maxTextureImageUnits];
        internal uint maxCombinedTextureImageUnits = 64; // TODO: maxCombinedTextureImageUnits = ?
        internal List<IdObject<GLSampler>?> idSamplers = new();

        internal vec4 clearColor = new vec4(0, 0, 0, 0);
        internal GLfloat clearDepthf = 1;
        //internal GLdouble clearDepth = 1;
        internal int clearStencil = 0;

        internal GLenum shadeMode = 0x1D01/*GL_SMOOTH*/;
        internal HashSet<GLenum> enables = new([0x0BD0/*GL_DITHER*/, 0x809D/*GL_MULTISAMPLE*/]);
        internal GLenum depthFunc = 0x0201/*GL_LESS*/;
        /// <summary>
        /// target -> mode
        /// <para>default mode is GL_DONT_CARE‌</para>
        /// </summary>
        internal Dictionary<GLenum, GLenum> hintDict = new();

        /// <summary>
        /// glPointSize specifies the rasterized diameter of points. If point size mode is disabled (see glEnable with parameter GL_PROGRAM_POINT_SIZE), this value will be used to rasterize points. Otherwise, the value written to the shading language built-in variable gl_PointSize will be used.
        /// </summary>
        internal float pointSize = 1;

        internal float lineWidth = 1;
    }

    internal class IdObject<T> {
        /// <summary>
        /// from glGenObjects
        /// </summary>
        public readonly GLuint id;
        /// <summary>
        /// from glBindObject
        /// </summary>
        public T? obj;

        public IdObject(uint id) {
            this.id = id;
        }

        public override string ToString() => $"{id}:{obj}";
    }
}
