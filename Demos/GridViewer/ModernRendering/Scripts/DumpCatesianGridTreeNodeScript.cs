using CSharpGL;
using System.Windows.Forms;

namespace GridViewer
{
    /// <summary>
    /// Dump a TreeNode object that binds to this renderer.
    /// </summary>
    public class DumpCatesianGridTreeNodeScript : DumpTreeNodeScript
    {
        public override TreeNode DumpTreeNode()
        {
            SceneObject obj = this.BindingObject;
            var renderer = obj.Renderer as CatesianGridRenderer;
            var gridNode = new SceneObjectTreeNode(obj);
            gridNode.Text = obj.Name;
            gridNode.Tag = obj;
            gridNode.ToolTipText = renderer.Grid.GetType().Name;
            foreach (var item in obj.Scripts)
            {
                var script = item as ScientificModelScript;
                if (script != null)
                {
                    var propNode = new PropertyTreeNode(script);
                    propNode.Text = script.GridBlockProperty.Name;
                    propNode.Tag = script.GridBlockProperty;
                    gridNode.Nodes.Add(propNode);
                }
            }
            return gridNode;
        }
    }
}