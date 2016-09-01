using CSharpGL;
using System.Windows.Forms;

namespace GridViewer
{
    public partial class SceneObjectTreeNode : AbstractTreeNode
    {
        private SceneObject sceneObject;

        public SceneObjectTreeNode(SceneObject sceneObject)
        {
            this.sceneObject = sceneObject;
        }

        public override void Selected(object sender, TreeViewEventArgs e)
        {
        }
    }
}