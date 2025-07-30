using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using CSharpGL;

namespace c11d00_Arcball {
    partial class FanNode : ModernNode, IRenderable {
        private VertexBuffer positionBuffer;
        private float radius;

        public static FanNode Create(float radius) {
            var program = GLProgram.Create(vertexCode, fragmentCode); Debug.Assert(program != null);
            var map = new AttributeMap();
            map.Add("inPosition", FanModel.strPosition);
            map.Add("inColor", FanModel.strColor);
            //var depthTestSwitch = new DepthTestSwitch(false);
            //var polygonModeSwitch = new PolygonModeSwitch(PolygonMode.Line);
            var builder = new RenderMethodBuilder(program, map);

            var model = new FanModel(radius);
            var node = new FanNode(model, builder);
            node.radius = radius;
            node.Initialize();

            return node;
        }

        private FanNode(IBufferSource model, params RenderMethodBuilder[] builders)
            : base(model, builders) {
        }

        protected override void DoInitialize() {
            base.DoInitialize();

            this.positionBuffer = this.RenderUnit.Methods[0].VertexArrayObjects[0].VertexAttributes[0].buffer;
        }

        #region IRenderable 成员

        private ThreeFlags enableRendering = ThreeFlags.BeforeChildren | ThreeFlags.Children;
        public ThreeFlags EnableRendering { get { return this.enableRendering; } set { this.enableRendering = value; } }

        public void RenderBeforeChildren(RenderEventArgs arg) {
            if (!this.mouseDown) { return; }

            if (this.inMouseDownPositionUpdated || this.inMouseMovePositionUpdated) {
                UpdateModel(this.InMouseDownPosition, this.InMouseMovePosition);
                this.inMouseDownPositionUpdated = false;
                this.inMouseMovePositionUpdated = false;
            }

            ICamera camera = arg.Camera;
            mat4 projection = camera.GetProjectionMatrix();
            mat4 view = camera.GetViewMatrix();
            mat4 model = this.GetModelMatrix();

            RenderMethod method = this.RenderUnit.Methods[0];
            GLProgram program = method.Program;
            // matrix.
            program.SetUniform("mvpMat", projection * view * model);
            method.Render();
        }

        private unsafe void UpdateModel(vec3 downPos, vec3 movePos) {
            var positions = (vec3*)this.positionBuffer.MapBuffer(MapBufferAccess.WriteOnly);
            int count = this.positionBuffer.count;
            // not equal parts.
            //vec3 b = movePos.normalize();
            //vec3 a = downPos.normalize();
            //var totalAngle = Math.Acos(a.dot(b));
            //{
            //    for (int i = 0; i < count - 1; i++)
            //    {
            //        var angle = totalAngle * (double)(i) / (double)(count - 1 - 1);
            //        var cos = (float)Math.Cos(angle);
            //        var sin = (float)Math.Sin(angle);
            //        positions[i + 1] = (downPos * (float)(i) / (float)(count - 1 - 1)
            //            + movePos * (float)(count - 1 - 1 - i) / (float)(count - 1 - 1)).normalize() * this.radius;
            //    }
            //}
            vec3 x = downPos.normalize();
            vec3 z = downPos.cross(movePos).normalize();
            vec3 y = z.cross(downPos).normalize();
            double totalCos = x.dot(movePos) / movePos.length();
            if (totalCos < -1) { totalCos = -1.0; }
            if (1 < totalCos) { totalCos = 1.0; }
            var totalAngle = Math.Acos(totalCos);
            {
                for (int i = 0; i < count - 1; i++) {
                    var angle = totalAngle * (double)(i) / (double)(count - 1 - 1);
                    var cos = (float)Math.Cos(angle);
                    var sin = (float)Math.Sin(angle);
                    positions[i + 1] = (x * cos + y * sin) * this.radius;
                }
            }
            this.positionBuffer.UnmapBuffer();
        }

        public void RenderAfterChildren(RenderEventArgs arg) {
        }

        #endregion

        private vec3 inMouseDownPosition;
        private bool inMouseDownPositionUpdated = false;
        public vec3 InMouseDownPosition {
            get { return inMouseDownPosition; }
            set {
                if (inMouseDownPosition != value) {
                    this.inMouseDownPosition = value;
                    this.inMouseDownPositionUpdated = true;
                }
            }
        }

        private vec3 inMouseMovePosition;
        private bool inMouseMovePositionUpdated = false;
        public vec3 InMouseMovePosition {
            get { return inMouseMovePosition; }
            set {
                if (inMouseMovePosition != value) {
                    this.inMouseMovePosition = value;
                    this.inMouseMovePositionUpdated = true;
                }
            }
        }
        private bool mouseDown = false;

        /// <summary>
        /// Indicates wheter the mouse is down or not.
        /// </summary>
        public bool IsMouseDown { get { return this.mouseDown; } }
    }
}
