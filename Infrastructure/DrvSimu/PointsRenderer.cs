using CSharpGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace DrvSimu
{
    internal class PointsRenderer : PickableRenderer
    {
        public static PointsRenderer Create(int capacity)
        {
            var model = new PointsModel(capacity);
            var shaderCodes = new ShaderCode[2];
            shaderCodes[0] = new ShaderCode(File.ReadAllText(@"Points.vert"), ShaderType.VertexShader);
            shaderCodes[1] = new ShaderCode(File.ReadAllText(@"Points.frag"), ShaderType.FragmentShader);
            var map = new AttributeMap();
            map.Add("in_Position", PointsModel.strPosition);
            map.Add("in_Color", PointsModel.strColor);
            var renderer = new PointsRenderer(model, shaderCodes, map, PointsModel.strPosition);
            renderer.capacity = capacity;
            //renderer.WorldPosition = box.MaxPosition / 2 + box.MinPosition / 2;
            renderer.ModelSize = new vec3(1, 1, 1);
            renderer.Initialize();
            (renderer.indexBufferPtr as ZeroIndexBufferPtr).RenderingVertexCount = 0;
            return renderer;
        }

        private PointsRenderer(IBufferable model, ShaderCode[] shaderCodes,
            AttributeMap attributeMap, string positionNameInIBufferable,
            params GLSwitch[] switches)
            : base(model, shaderCodes, attributeMap, positionNameInIBufferable, switches)
        { }

        protected override void DoRender(RenderEventArgs arg)
        {
            mat4 projection = arg.Camera.GetProjectionMatrix();
            mat4 view = arg.Camera.GetViewMatrix();
            mat4 model = this.GetModelMatrix().Value;
            this.SetUniform("projectionMatrix", projection);
            this.SetUniform("viewMatrix", view);
            this.SetUniform("modelMatrix", model);

            base.DoRender(arg);
        }

        private int nextPointIndex = 0;
        private int capacity;
        private Color nextColor = Color.Red;

        /// <summary>
        /// Returns true if successfully set up next point's position.
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public bool SetPoint(vec3 point)
        {
            if (nextPointIndex >= this.capacity)
            { throw new Exception("Too many points!"); }

            {
                IntPtr pointer = this.PositionBufferPtr.MapBuffer(MapBufferAccess.WriteOnly);
                unsafe
                {
                    var array = (vec3*)pointer.ToPointer();
                    array[this.nextPointIndex] = point;
                }
                this.PositionBufferPtr.UnmapBuffer();
            }
            {
                BufferPtr colorBufferPtr = this.Model.GetVertexAttributeBufferPtr(PointsModel.strColor, string.Empty);
                IntPtr pointer = colorBufferPtr.MapBuffer(MapBufferAccess.WriteOnly);
                unsafe
                {
                    var array = (vec3*)pointer.ToPointer();
                    array[this.nextPointIndex] = this.nextColor.ToVec3();
                }
                colorBufferPtr.UnmapBuffer();
            }

            this.nextPointIndex++;
            (this.indexBufferPtr as ZeroIndexBufferPtr).RenderingVertexCount = this.nextPointIndex;

            return true;
        }

        public void SetColor(Color color)
        {
            this.nextColor = color;
        }
    }
}