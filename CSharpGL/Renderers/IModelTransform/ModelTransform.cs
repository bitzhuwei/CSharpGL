using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// 
    /// </summary>
    public class ModelTransform : IModelTransform
    {
        /// <summary>
        /// 
        /// </summary>
        public mat4 ModelMatrix { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ModelTransform()
        {
            this.ModelMatrix = mat4.identity();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="translate"></param>
        public void Translate(vec3 translate)
        {
            this.ModelMatrix = glm.translate(this.ModelMatrix, translate);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public void Translate(float x, float y, float z)
        {
            this.Translate(new vec3(x, y, z));
        }
    }
}
