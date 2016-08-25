using CSharpGL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace GridViewer
{
    /// <summary>
    /// 
    /// </summary>
    class LabelTargetScript : Script
    {
        /// <summary>
        /// scale model and its children models recursively.
        /// </summary>
        [Description("scale model and its children models recursively.")]
        public string Desc { get { return "scale model and its children models recursively."; } }

        private IModelTransform target;
        private ILabelPosition labelPosition;
        private IModelTransform self;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="labelPosition"></param>
        public LabelTargetScript(ILabelPosition labelPosition)
        {
            // TODO: Complete member initialization
            this.labelPosition = labelPosition;
            this.target = labelPosition as IModelTransform;
        }

        protected override void DoUpdate(double elapsedTime)
        {
            if (this.self == null)
            {
                this.self = this.BindingObject.Renderer as IModelTransform;
            }

            //this.self.ModelMatrix = glm.translate(mat4.identity(), new vec3());
            if (this.target != null)
            {
                vec4 position = this.target.ModelMatrix * new vec4(this.labelPosition.Position, 1.0f);
                this.self.ModelMatrix = glm.translate(mat4.identity(), new vec3(position));
            }
            else
            {
                vec3 position = this.labelPosition.Position;
                this.self.ModelMatrix = glm.translate(mat4.identity(), position);
            }
        }
    }
}
