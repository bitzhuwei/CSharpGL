using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Linq;
using System.Text;


namespace CSharpGL
{
    /// <summary>
    /// Rendering something using GLSL shader and VBO(VAO).
    /// </summary>
    public partial class Renderer : RendererBase, IModelSpace
    {

        /// <summary>
        /// algorithm for rendering.
        /// </summary>
        public ShaderProgram Program { get; protected set; }

        // data structure for rendering.

        /// <summary>
        /// 
        /// </summary>
        protected VertexArrayObject vertexArrayObject;
        /// <summary>
        /// 
        /// </summary>
        protected PropertyBufferPtr[] propertyBufferPtrs;
        /// <summary>
        /// 
        /// </summary>
        protected IndexBufferPtr indexBufferPtr;
        /// <summary>
        /// 
        /// </summary>
        protected GLSwitchList switchList = new GLSwitchList();

        /// <summary>
        /// model data that can be transfermed into OpenGL Buffer's pointer.
        /// </summary>
        protected IBufferable bufferable;
        /// <summary>
        /// All shader codes needed for this renderer.
        /// </summary>
        protected ShaderCode[] shaderCodes;
        /// <summary>
        /// Mapping relations between 'in' variables in vertex shader and buffers in <see cref="bufferable"/>.
        /// </summary>
        protected PropertyNameMap propertyNameMap;


        /// <summary>
        /// Rendering something using GLSL shader and VBO(VAO).
        /// </summary>
        /// <param name="bufferable">model data that can be transfermed into OpenGL Buffer's pointer.</param>
        /// <param name="shaderCodes">All shader codes needed for this renderer.</param>
        /// <param name="propertyNameMap">Mapping relations between 'in' variables in vertex shader in <see cref="shaderCodes"/> and buffers in <see cref="bufferable"/>.</param>
        ///<param name="switches">OpenGL switches.</param>
        public Renderer(IBufferable bufferable, ShaderCode[] shaderCodes,
            PropertyNameMap propertyNameMap, params GLSwitch[] switches)
        {
            //this.OriginalWorldPosition = new vec3(0, 0, 0);// this is not needed.
            this.Scale = new vec3(1, 1, 1);
            //this.RotationAngle = 0;// this is not needed.
            this.RotationAxis = new vec3(1, 0, 0);

            this.bufferable = bufferable;
            this.shaderCodes = shaderCodes;
            this.propertyNameMap = propertyNameMap;
            this.switchList.AddRange(switches);
        }

        #region IModelSpace

        /// <summary>
        /// records whether modelMatrix is updated.
        /// </summary>
        protected UpdatingRecord modelMatrixRecord = new UpdatingRecord(true);

        private vec3 worldPosition;
        /// <summary>
        /// 
        /// </summary>
        public virtual vec3 OriginalWorldPosition
        {
            get { return worldPosition; }
            set
            {
                if (worldPosition != value)
                {
                    worldPosition = value;
                    modelMatrixRecord.Mark();
                }
            }
        }

        private float rotationAngle;
        /// <summary>
        /// 
        /// </summary>
        public virtual float RotationAngle
        {
            get { return rotationAngle; }
            set
            {
                if (rotationAngle != value)
                {
                    rotationAngle = value;
                    modelMatrixRecord.Mark();
                }
            }
        }

        private vec3 rotationAxis = new vec3(0, 1, 0);
        /// <summary>
        /// 
        /// </summary>
        public virtual vec3 RotationAxis
        {
            get { return rotationAxis; }
            set
            {
                if (rotationAxis != value)
                {
                    rotationAxis = value;
                    modelMatrixRecord.Mark();
                }
            }
        }

        private vec3 scale = new vec3(1, 1, 1);
        /// <summary>
        /// 
        /// </summary>
        public virtual vec3 Scale
        {
            get { return scale; }
            set
            {
                if (scale != value)
                {
                    scale = value;
                    modelMatrixRecord.Mark();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual vec3 Lengths { get; protected set; }

        #endregion IModelSpace



    }
}
