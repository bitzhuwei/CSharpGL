using CSharpGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridViewer
{
    /// <summary>
    /// renders well pipeline.
    /// </summary>
    public class WellPipilineRenderer : Renderer, IModelTransform
    {
        /// <summary>
        /// IModelTransform.ModelMatrix
        /// </summary>
        public mat4 ModelMatrix { get; set; }

        private UpdatingRecord wellPipelineColorRecord = new UpdatingRecord();
        private Color wellPipelineColor;
        public Color WellPipelineColor
        {
            get { return wellPipelineColor; }
            set
            {
                wellPipelineColor = value;
                wellPipelineColorRecord.Mark();
            }
        }

        public static WellPipilineRenderer Create(WellPipelineModel model)
        {
            var shaderCodes = new ShaderCode[2];
            shaderCodes[0] = new ShaderCode(File.ReadAllText(@"shaders\wellPipeline.vert"), ShaderType.VertexShader);
            shaderCodes[1] = new ShaderCode(File.ReadAllText(@"shaders\wellPipeline.frag"), ShaderType.FragmentShader);
            var map = new PropertyNameMap();
            map.Add("in_Position", WellPipelineModel.strPosition);
            var renderer = new WellPipilineRenderer(model, shaderCodes, map);
            return renderer;
        }

        private WellPipilineRenderer(WellPipelineModel model, ShaderCode[] shaderCodes,
            PropertyNameMap propertyNameMap, params GLSwitch[] switches)
            : base(model, shaderCodes, propertyNameMap, switches)
        {
            this.ModelMatrix = mat4.identity();
        }


        protected override void DoRender(RenderEventArg arg)
        {
            if (wellPipelineColorRecord.IsMarked())
            {
                this.SetUniform("wellPipelineColor", this.wellPipelineColor.ToVec4());
                wellPipelineColorRecord.CancelMark();
            }

            mat4 mvp = arg.Camera.GetProjectionMat4() * arg.Camera.GetViewMat4() * this.ModelMatrix;
            this.SetUniform("mvp", mvp);

            base.DoRender(arg);
        }
    }
}
