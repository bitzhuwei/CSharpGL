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
    /// renders well pipeline(several cylinders)
    /// </summary>
    public class WellRenderer : Renderer, IModelTransform
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

        public static WellRenderer Create(WellModel model)
        {
            var shaderCodes = new ShaderCode[2];
            shaderCodes[0] = new ShaderCode(File.ReadAllText(@"shaders\wellPipeline.vert"), ShaderType.VertexShader);
            shaderCodes[1] = new ShaderCode(File.ReadAllText(@"shaders\wellPipeline.frag"), ShaderType.FragmentShader);
            var map = new PropertyNameMap();
            map.Add("in_Position", WellModel.strPosition);
            var renderer = new WellRenderer(model, shaderCodes, map);
            return renderer;
        }

        /// <summary>
        /// renders well pipeline(several cylinders)
        /// </summary>
        /// <param name="model"></param>
        /// <param name="shaderCodes"></param>
        /// <param name="propertyNameMap"></param>
        /// <param name="switches"></param>
        private WellRenderer(WellModel model, ShaderCode[] shaderCodes,
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
