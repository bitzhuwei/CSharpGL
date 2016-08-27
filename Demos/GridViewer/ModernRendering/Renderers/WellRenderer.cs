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
    public class WellRenderer : Renderer, ILabelPosition
    {

        private UpdatingRecord wellPipelineColorRecord = new UpdatingRecord();
        private Color wellColor = Color.White;// maps to white color in shader.
        public Color WellColor
        {
            get { return wellColor; }
            set
            {
                wellColor = value;
                wellPipelineColorRecord.Mark();
            }
        }

        public static WellRenderer Create(WellModel model)
        {
            var shaderCodes = new ShaderCode[2];
            shaderCodes[0] = new ShaderCode(File.ReadAllText(@"shaders\Well.vert"), ShaderType.VertexShader);
            shaderCodes[1] = new ShaderCode(File.ReadAllText(@"shaders\Well.frag"), ShaderType.FragmentShader);
            var map = new PropertyNameMap();
            map.Add("in_Position", WellModel.strPosition);
            map.Add("in_Brightness", WellModel.strBrightness);
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
        }

        protected override void DoInitialize()
        {
            base.DoInitialize();

            var model = this.bufferable as WellModel;
            this.WorldPosition = model.WorldPosition;
            this.Lengths = model.Lengths;
            this.firstNode = model.FirstNode;
        }

        protected override void DoRender(RenderEventArgs arg)
        {
            if (wellPipelineColorRecord.IsMarked())
            {
                this.SetUniform("wellColor", this.wellColor.ToVec4());
                wellPipelineColorRecord.CancelMark();
            }

            mat4 mvp = arg.Camera.GetProjectionMat4() * arg.Camera.GetViewMatrix() * this.GetMatrix();
            this.SetUniform("mvp", mvp);

            base.DoRender(arg);
        }

        public event EventHandler ModelTransformUpdated;
        private void DoModelTranslateUpdated()
        {
            EventHandler ModelTransformUpdated = this.ModelTransformUpdated;
            if (ModelTransformUpdated != null)
            {
                ModelTransformUpdated(this, new EventArgs());
            }
        }
        /// <summary>
        /// Position in world space.
        /// </summary>
        public override vec3 WorldPosition
        {
            get
            {
                return base.WorldPosition;
            }
            set
            {
                if (base.WorldPosition != value)
                {
                    base.WorldPosition = value;
                    DoModelTranslateUpdated();
                }
            }
        }


        private vec3 firstNode;
        vec3 ILabelPosition.Position { get { return firstNode; } }

    }
}
