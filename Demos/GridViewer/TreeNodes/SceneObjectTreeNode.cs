using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSharpGL;

namespace GridViewer
{
    public partial class SceneObjectTreeNode : TreeNode
    {
        private SceneObject sceneObject;
        public SceneObjectTreeNode(SceneObject sceneObject)
        {
            this.sceneObject = sceneObject;
        }
    }
}
