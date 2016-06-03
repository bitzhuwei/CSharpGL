using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    public class InnerPickableRenderer : Renderer, IColorCodedPicking
    {

        private string positionNameInIBufferable;
        internal PropertyBufferPtr positionBufferPtr;
        /// <summary>
        /// uniform mat4 VMP; (in shader)
        /// </summary>
        protected UniformMat4 uniformmMVP4Picking = new UniformMat4("MVP");

        /// <summary>
        /// </summary>
        /// <param name="bufferable">一种渲染方式</param>
        /// <param name="shaderCodes">各种类型的shader代码</param>
        /// <param name="propertyNameMap">关联<see cref="PropertyBufferPtr"/>和<see cref="shaderCode"/>中的属性</param>
        /// <param name="positionNameInIBufferable">描述顶点位置信息的buffer的名字</param>
        ///<param name="switches"></param>
        internal InnerPickableRenderer(IBufferable bufferable, ShaderCode[] shaderCodes,
            PropertyNameMap propertyNameMap, string positionNameInIBufferable,
            params GLSwitch[] switches)
            : base(bufferable, shaderCodes, propertyNameMap, switches)
        {
            this.positionNameInIBufferable = positionNameInIBufferable;

            {
                var polygonModeSwitch = new PolygonModeSwitch(PolygonModes.Filled);
                this.PolygonModeSwitch = polygonModeSwitch;
                this.switchList.Add(polygonModeSwitch);
            }
            {
                float min, max;
                OpenGL.LineWidthRange(out min, out max);
                var lineWidthSwitch = new LineWidthSwitch(max);
                this.LineWidthSwitch = lineWidthSwitch;
                this.switchList.Add(lineWidthSwitch);
            }
            {
                float min, max;
                OpenGL.PointSizeRange(out min, out max);
                var pointSizeSwitch = new PointSizeSwitch(max);
                this.PointSizeSwitch = pointSizeSwitch;
                this.switchList.Add(pointSizeSwitch);
            }
        }

        protected override void DoInitialize()
        {
            // init shader program
            ShaderProgram program = PickingShaderHelper.GetPickingShaderProgram();
            var shaders = (from item in shaderCodes select item.CreateShader()).ToArray();
            program.Create(shaders);
            this.shaderProgram = program;
            foreach (var item in shaders) { item.Delete(); }

            // init property buffer objects
            var propertyBufferPtrs = new PropertyBufferPtr[propertyNameMap.Count()];
            int index = 0;
            foreach (var item in propertyNameMap)
            {
                if (index <= 0)
                {
                    if (item.nameInIBufferable == this.positionNameInIBufferable)
                    {
                        PropertyBufferPtr bufferPtr = this.bufferable.GetProperty(
                            item.nameInIBufferable, item.VarNameInShader);
                        if (bufferPtr == null) { throw new Exception(); }
                        propertyBufferPtrs[index++] = bufferPtr;
                        this.positionBufferPtr = bufferPtr;
                    }
                }
                else
                {
                    if (item.nameInIBufferable == this.positionNameInIBufferable)
                    { throw new Exception("More than 1 property named as position buffer~"); }
                }
            }

            this.propertyBufferPtrs = propertyBufferPtrs;
            this.indexBufferPtr = this.bufferable.GetIndex();
        }

        protected override void DoRender(RenderEventArgs arg)
        {
            UpdatePolygonMode(arg.PickingGeometryType);

            ShaderProgram program = this.shaderProgram;

            // 绑定shader
            program.Bind();
            program.SetUniform("pickingBaseId", (int)this.PickingBaseId);
            UniformMat4 uniformmMVP4Picking = this.uniformmMVP4Picking;
            bool mvpUpdated = uniformmMVP4Picking.Updated;
            if (mvpUpdated) { uniformmMVP4Picking.SetUniform(program); }

            PickingSwitchesOn();

            if (this.vertexArrayObject == null)
            {
                var vertexArrayObject4Picking = new VertexArrayObject(
                    this.indexBufferPtr, this.positionBufferPtr);
                vertexArrayObject4Picking.Create(arg, program);

                this.vertexArrayObject = vertexArrayObject4Picking;
            }
            //else
            {
                this.vertexArrayObject.Render(arg, program);
            }

            PickingSwitchesOff();

            if (mvpUpdated) { uniformmMVP4Picking.ResetUniform(program); }


            // 解绑shader
            program.Unbind();
        }

        protected void PickingSwitchesOff()
        {
            int count = this.switchList.Count;
            for (int i = count - 1; i >= 0; i--)
            {
                this.switchList[i].Off();
            }
        }

        protected void PickingSwitchesOn()
        {
            int count = this.switchList.Count;
            for (int i = 0; i < count; i++)
            {
                this.switchList[i].On();
            }
        }

        private void UpdatePolygonMode(GeometryType geometryType)
        {
            switch (geometryType)
            {
                case GeometryType.Point:
                    this.PolygonModeSwitch.Mode = PolygonModes.Points;
                    break;
                case GeometryType.Line:
                    this.PolygonModeSwitch.Mode = PolygonModes.Lines;
                    break;
                case GeometryType.Triangle:
                    this.PolygonModeSwitch.Mode = PolygonModes.Filled;
                    break;
                case GeometryType.Quad:
                    this.PolygonModeSwitch.Mode = PolygonModes.Filled;
                    break;
                case GeometryType.Polygon:
                    this.PolygonModeSwitch.Mode = PolygonModes.Filled;
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        public PolygonModeSwitch PolygonModeSwitch { get; private set; }

        public LineWidthSwitch LineWidthSwitch { get; private set; }

        public PointSizeSwitch PointSizeSwitch { get; private set; }

        public mat4 MVP { get; set; }

        public uint PickingBaseId { get; }

        public uint GetVertexCount()
        {
            throw new NotImplementedException();
        }

        public PickedGeometry Pick(RenderEventArgs arg, uint stageVertexId, int x, int y)
        {
            throw new NotImplementedException();
        }
    }
}
