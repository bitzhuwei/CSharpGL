using CSharpGL;
using System.ComponentModel;

namespace GridViewer
{
    /// <summary>
    /// retarget label's position to specified target.
    /// </summary>
    internal class LabelTargetScript : Script
    {
        /// <summary>
        /// retarget label's position to specified target.
        /// </summary>
        [Category("Desc")]
        [Description("retarget label's position to specified target.")]
        public string Desc { get { return "retarget label's position to specified target."; } }

        private IModelSpace target;
        private ILabelPosition labelPosition;
        private IModelSpace self;

        /// <summary>
        ///
        /// </summary>
        /// <param name="labelPosition"></param>
        public LabelTargetScript(ILabelPosition labelPosition)
        {
            // TODO: Complete member initialization
            this.labelPosition = labelPosition;
            this.target = labelPosition as IModelSpace;
        }

        protected override void DoUpdate()
        {
            if (this.self == null)
            {
                this.self = this.BindingObject.Renderer as IModelSpace;
            }

            //this.self.ModelMatrix = glm.translate(mat4.identity(), new vec3());
            if (this.target != null)
            {
                vec4 position = this.target.GetModelMatrix() * new vec4(this.labelPosition.Position, 1.0f);
                this.self.WorldPosition = new vec3(position);
            }
            else
            {
                vec3 position = this.labelPosition.Position;
                this.self.WorldPosition = position;
            }
        }
    }
}