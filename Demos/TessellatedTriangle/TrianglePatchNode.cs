﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace TessellatedTriangle
{
    /// <summary>
    /// Renders a cube every time the action list works.
    /// </summary>
    partial class TrianglePatchNode : ModernNode, IRenderable
    {
        public static TrianglePatchNode Create()
        {
            // model provides vertex buffer and index buffer(within an IDrawCommand).
            var model = new TrianglePatchModel();
            // vertex shader and fragment shader.
            var vs = new VertexShader(vertexCode);
            var tc = new TessControlShader(tessellationControlCode);
            var te = new TessEvaluationShader(tessellationEvaluationCode);
            var fs = new FragmentShader(fragmentCode);
            var array = new ShaderArray(vs, tc, te, fs);
            // which vertex buffer maps to which attribute in shader.
            var map = new AttributeMap();
            // help to build a render method.
            var builder = new RenderMethodBuilder(array, map, new PolygonModeSwitch(PolygonMode.Line));
            // create node.
            var node = new TrianglePatchNode(model, builder);
            // initialize node.
            node.Initialize();

            return node;
        }

        private TrianglePatchNode(IBufferSource model, params RenderMethodBuilder[] builders)
            : base(model, builders)
        {
        }

        #region IRenderable 成员

        // render this before render children. Call RenderBeforeChildren();
        // render children.
        // not Call RenderAfterChildren();
        private ThreeFlags enableRendering = ThreeFlags.BeforeChildren | ThreeFlags.Children;
        public ThreeFlags EnableRendering
        {
            get { return enableRendering; }
            set { enableRendering = value; }
        }

        public void RenderBeforeChildren(RenderEventArgs arg)
        {
            // gets mvpMatrix.
            //ICamera camera = arg.Camera;
            //mat4 projectionMat = camera.GetProjectionMatrix();
            //mat4 viewMat = camera.GetViewMatrix();
            //mat4 modelMat = this.GetModelMatrix();
            //mat4 mvpMatrix = projectionMat * viewMat * modelMat;
            // a render uint wraps everything(model data, shaders, glswitches, etc.) for rendering.
            ModernRenderUnit unit = this.RenderUnit;
            // gets render method.
            // There could be more than 1 method(vertex shader + fragment shader) to render the same model data. Thus we need an method array.
            RenderMethod method = unit.Methods[0];
            //// shader program wraps vertex shader and fragment shader.
            //ShaderProgram program = method.Program;
            ////set value for 'uniform mat4 mvpMatrix'; in shader.
            //program.SetUniform("mvpMatrix", mvpMatrix);
            // render the cube model via OpenGL.
            method.Render();
        }

        public void RenderAfterChildren(RenderEventArgs arg)
        {
        }

        #endregion
    }
}
