using CSharpGL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridViewer
{
    /// <summary>
    ///  /|\ y
    ///   |
    ///   |
    ///   |
    ///   ---------------&gt; x
    /// (0, 0)
    /// 0    2    4    6    8    10
    /// --------------------------
    /// {    {    {    {    {    {
    /// {    {    {    {    {    {
    /// {    {    {    {    {    {
    /// {    {    {    {    {    {
    /// {    {    {    {    {    {
    /// {    {    {    {    {    {
    /// {    {    {    {    {    {
    /// --------------------------
    /// 1    3    5    7    9    11
    /// side length is 1.
    /// </summary>
    class QuadStripRenderer : Renderer
    {

        private PolygonModeSwitch polygonModeSwitch = new PolygonModeSwitch(PolygonModes.Lines);
        private LineWidthSwitch lineWidthSwitch = new LineWidthSwitch(1);

        private PolygonOffsetSwitch offsetSwitch = new PolygonOffsetLineSwitch();

        public static QuadStripRenderer Create(QuadStripModel model)
        {
            var shaderCodes = new ShaderCode[2];
            shaderCodes[0] = new ShaderCode(File.ReadAllText(@"shaders\QuadStrip.vert"), ShaderType.VertexShader);
            shaderCodes[1] = new ShaderCode(File.ReadAllText(@"shaders\QuadStrip.frag"), ShaderType.FragmentShader);
            var map = new PropertyNameMap();
            map.Add("in_Position", QuadStripModel.position);
            map.Add("in_Color", QuadStripModel.color);
            var renderer = new QuadStripRenderer(model, shaderCodes, map);
            return renderer;
        }

        private QuadStripRenderer(IBufferable bufferable, ShaderCode[] shaderCodes,
            PropertyNameMap propertyNameMap, params GLSwitch[] switches)
            : base(bufferable, shaderCodes, propertyNameMap, switches)
        { }

        protected override void DoRender(RenderEventArg arg)
        {
            this.SetUniform("renderWireframe", false);
            base.DoRender(arg);

            polygonModeSwitch.On();
            lineWidthSwitch.On();
            // offsetSwitch.On();
            this.SetUniform("renderWireframe", true);
            base.DoRender(arg);
            //offsetSwitch.Off(); 
            lineWidthSwitch.Off();
            polygonModeSwitch.Off();
        }

    }
}
