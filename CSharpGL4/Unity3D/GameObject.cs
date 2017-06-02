using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Unity3D
{
    public class GameObject : ITreeNode<GameObject>
    {
        public GameObject()
        {
            this.Children = new TreeNodeChildren<GameObject>(this);
        }

        #region ITreeNode<GameObject> 成员

        public ITreeNode<GameObject> Parent { get; set; }

        public TreeNodeChildren<GameObject> Children { get; private set; }

        #endregion
    }
}
