using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL {
    /// <summary>
    /// 
    /// </summary>
    public unsafe partial class HighlightGeometryNode : ModernNode, IRenderable {
        private vec3 vertex0;

        public vec3 Vertex0 {
            get { return vertex0; }
            set {
                var array = (vec3*)this.positionBuffer.MapBuffer(MapBufferAccess.ReadWrite);
                array[0] = value;
                this.positionBuffer.UnmapBuffer();
                this.vertex0 = value;
            }
        }
        private vec3 vertex1;

        public vec3 Vertex1 {
            get { return vertex1; }
            set {
                var array = (vec3*)this.positionBuffer.MapBuffer(MapBufferAccess.ReadWrite);
                array[1] = value;
                this.positionBuffer.UnmapBuffer();
                this.vertex1 = value;
            }
        }
        private vec3 vertex2;

        public vec3 Vertex2 {
            get { return vertex2; }
            set {
                var array = (vec3*)this.positionBuffer.MapBuffer(MapBufferAccess.ReadWrite);
                array[2] = value;
                this.positionBuffer.UnmapBuffer();
                this.vertex2 = value;
            }
        }

        private vec3 vertex3;

        public vec3 Vertex3 {
            get { return vertex3; }
            set {
                var array = (vec3*)this.positionBuffer.MapBuffer(MapBufferAccess.ReadWrite);
                array[3] = value;
                this.positionBuffer.UnmapBuffer();
                this.vertex3 = value;
            }
        }

        private vec3 color0;

        public vec3 Color0 {
            get { return color0; }
            set {
                var array = (vec3*)this.colorBuffer.MapBuffer(MapBufferAccess.ReadWrite);
                array[0] = value;
                this.colorBuffer.UnmapBuffer();
                color0 = value;
            }
        }
        private vec3 color1;

        public vec3 Color1 {
            get { return color1; }
            set {
                var array = (vec3*)this.colorBuffer.MapBuffer(MapBufferAccess.ReadWrite);
                array[1] = value;
                this.colorBuffer.UnmapBuffer();
                color1 = value;
            }
        }
        private vec3 color2;

        public vec3 Color2 {
            get { return color2; }
            set {
                var array = (vec3*)this.colorBuffer.MapBuffer(MapBufferAccess.ReadWrite);
                array[2] = value;
                this.colorBuffer.UnmapBuffer();
                color2 = value;
            }
        }
        private vec3 color3;

        public vec3 Color3 {
            get { return color3; }
            set {
                var array = (vec3*)this.colorBuffer.MapBuffer(MapBufferAccess.ReadWrite);
                array[3] = value;
                this.colorBuffer.UnmapBuffer();
                color3 = value;
            }
        }

        private DrawMode currentMode = DrawMode.LineLoop;

        public DrawMode CurrentMode {
            get { return currentMode; }
            set {
                this.drawCommand.Mode = value;
                currentMode = value;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public PolygonMode PolygonMode {
            get { return this.polygonMode.mode; }
            set { this.polygonMode.mode = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public float LineWidth {
            get { return this.lineWidth.lineWidth; }
            set { this.lineWidth.lineWidth = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public float PointSize {
            get { return this.pointSize.pointSize; }
            set { this.pointSize.pointSize = value; }
        }


        public static HighlightGeometryNode Create() {
            var model = new HighlightGeometryModel();
            var program = GLProgram.Create(vertexCode, fragmentCode); System.Diagnostics.Debug.Assert(program != null);
            var map = new AttributeMap();
            map.Add("inPosition", HighlightGeometryModel.strPosition);
            map.Add("inColor", HighlightGeometryModel.strColor);
            var polygonOffset = new PolygonOffsetFillSwitch();
            var polygonMode = new PolygonModeSwitch(PolygonMode.Line);
            var lineWidth = new LineWidthSwitch(5.0f);
            var pointSize = new PointSizeSwitch(5.0f);
            var builder = new RenderMethodBuilder(program, map, polygonOffset, polygonMode, lineWidth, pointSize);

            var node = new HighlightGeometryNode(model, builder);
            node.polygonOffset = polygonOffset;
            node.polygonMode = polygonMode;
            node.lineWidth = lineWidth;
            node.pointSize = pointSize;

            node.Initialize();

            return node;
        }

        private HighlightGeometryNode(IBufferSource model, params RenderMethodBuilder[] builders)
            : base(model, builders) {
        }

        protected override void DoInitialize() {
            base.DoInitialize();
            {
                this.positionBuffer = this.RenderUnit.Methods[0].VertexArrayObjects[0].VertexAttributes[0].buffer;
                this.colorBuffer = this.RenderUnit.Methods[0].VertexArrayObjects[0].VertexAttributes[1].buffer;
                this.drawCommand = this.RenderUnit.Methods[0].VertexArrayObjects[0].DrawCommand as DrawArraysCmd;
            }
        }

        private VertexBuffer positionBuffer;
        private VertexBuffer colorBuffer;
        private DrawArraysCmd drawCommand;

        private GLSwitch polygonOffset;
        private PolygonModeSwitch polygonMode;
        private LineWidthSwitch lineWidth;
        private PointSizeSwitch pointSize;


        #region IBlinnPhong 成员

        private ThreeFlags enableRendering = ThreeFlags.BeforeChildren | ThreeFlags.Children;
        public ThreeFlags EnableRendering { get { return this.enableRendering; } set { this.enableRendering = value; } }

        public void RenderBeforeChildren(RenderEventArgs arg) {
            ICamera camera = arg.Camera;
            mat4 projection = camera.GetProjectionMatrix();
            mat4 view = camera.GetViewMatrix();
            mat4 model = this.GetModelMatrix();

            RenderMethod method = this.RenderUnit.Methods[0];
            GLProgram program = method.Program;
            program.SetUniform("mvpMat", projection * view * model);

            method.Render();
        }

        public void RenderAfterChildren(RenderEventArgs arg) {
        }

        #endregion
    }
}
