using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GridViewer
{
    class DumpWellTreeNodeScript : DumpTreeNodeScript
    {
        public override System.Windows.Forms.TreeNode DumpTreeNode()
        {
            SceneObject obj = this.BindingObject;
            var node = new TreeNode(obj.Renderer.Name);
            node.Tag = obj;
            //var labelNode = new TreeNode(item.Item2.Name);//string.Format("{0}: {1}", item.Item2.Name, item.Item2.Text));
            //labelNode.Tag = labelObj;
            //wellNode.Nodes.Add(labelNode);
            return node;
        }
    }
}
