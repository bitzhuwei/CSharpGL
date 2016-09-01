using System.Windows.Forms;

namespace GridViewer
{
    public partial class PropertyTreeNode : AbstractTreeNode
    {
        private ScientificModelScript script;

        public PropertyTreeNode(ScientificModelScript script)
        {
            this.script = script;
        }

        public override void Selected(object sender, TreeViewEventArgs e)
        {
            this.script.Show();
        }
    }
}