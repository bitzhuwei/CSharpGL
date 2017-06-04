using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    /// <summary>
    /// 
    /// </summary>
    public partial class GameObject : ITreeNode<GameObject>
    {
        /// <summary>
        /// 
        /// </summary>
        public readonly TransformComponent transform;

        /// <summary>
        /// 
        /// </summary>
        public readonly MeshComponent mesh;

        /// <summary>
        /// 
        /// </summary>
        public readonly RendererComponent renderer;

        /// <summary>
        /// 
        /// </summary>
        public GameObject()
        {
            this.transform = new TransformComponent(this);
            this.mesh = new MeshComponent(this);
            this.renderer = new RendererComponent(this);

            this.Children = new TreeNodeChildren<GameObject>(this);
        }

        #region ITreeNode<GameObject> 成员

        /// <summary>
        /// 
        /// </summary>
        public ITreeNode<GameObject> Parent { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public TreeNodeChildren<GameObject> Children { get; private set; }

        #endregion

    }
}
