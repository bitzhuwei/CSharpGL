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
    public partial class PropertyTreeNode : AbstractTreeNode
    {
        private ScientificModelScriptComponent scriptComponent;
        public PropertyTreeNode(ScientificModelScriptComponent scriptComponent)
        {
            this.scriptComponent = scriptComponent;
        }

        public override void Selected(object sender, TreeViewEventArgs e)
        {
            this.scriptComponent.Show();
        }
    }
}
