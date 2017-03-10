namespace CSharpGL
{
    /// <summary>
    /// 高亮显示指定的图元。
    /// </summary>
    public partial class HighlightRenderer : Renderer
    {
        /// <summary>
        ///
        /// </summary>
        protected string positionNameInIBufferable;

        internal VertexBuffer positionBuffer;

        /// <summary>
        /// 高亮显示指定的图元。
        /// </summary>
        /// <param name="model">一种渲染方式</param>
        /// <param name="positionNameInIBufferable">描述顶点位置信息的buffer的名字</param>
        ///<param name="switches"></param>
        public HighlightRenderer(IBufferable model,
            string positionNameInIBufferable,
            params GLState[] switches)
            : base(model, HighlightShaderHelper.GetHighlightShaderProgramProvider(),
                new AttributeMap("in_Position", positionNameInIBufferable),
                switches)
        {
            this.positionNameInIBufferable = positionNameInIBufferable;
            this.UniformVariables.Add(new UniformVec4("highlightColor", new vec4(1, 1, 1, 1)));
            this.UniformVariables.Add(this.uniformMVP);
            this.StateList.Add(new PolygonModeState(PolygonMode.Line));
            this.StateList.Add(new LineWidthState(10.0f));
            this.StateList.Add(new PointSizeState(20.0f));
            this.StateList.Add(new PolygonOffsetFillState());
            this.StateList.Add(new PolygonOffsetPointState());
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var indexBuffer = this.indexBuffer as OneIndexBuffer;
            return string.Format("{0} highlighting: {1} vertexes.", base.ToString(), indexBuffer.ElementCount);
        }
    }
}