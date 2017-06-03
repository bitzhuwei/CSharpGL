using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    public class GameObject : ITreeNode<GameObject>
    {
        public GameObject()
        {
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

        private List<ComponentBase> components = new List<ComponentBase>();

        public List<ComponentBase> Components
        {
            get { return components; }
        }
    }
}
