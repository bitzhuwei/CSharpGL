using System.Windows.Forms;

namespace GridViewer
{
    public abstract class AbstractTreeNode : TreeNode
    {
        public abstract void Selected(object sender, TreeViewEventArgs e);
    }
}