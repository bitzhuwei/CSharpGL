using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// 
    /// </summary>
    public class SceneElement : IWorldSpace, ITreeNode<SceneElement>
    {
        /// <summary>
        /// 
        /// </summary>
        public GLStateList GLState { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public VertexArrayObject VAO { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public ShaderProgram Program { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public SceneElement()
        {
            this.GLState = new GLStateList();

            // IWorldSpace
            this.Scale = new vec3(1, 1, 1);
            // TODO: this is the best initial value?
            this.RotationAxls = new vec3(0, 1, 0);
            this.Size = new vec3(1, 1, 1);

            // ITreeNode
            this.Children = new TreeNodeChildren<SceneElement>(this);
        }

        #region IWorldSpace 成员

        public vec3 Position { get; set; }

        public vec3 Scale { get; set; }

        public vec3 RotationAxls { get; set; }

        public float RotationAngle { get; set; }

        public vec3 Size { get; set; }

        #endregion


        #region ITreeNode<SceneElement> 成员

        /// <summary>
        /// 
        /// </summary>
        public SceneElement Parent { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public TreeNodeChildren<SceneElement> Children { get; private set; }

        #endregion
    }
}
