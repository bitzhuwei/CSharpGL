using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GridViewer
{
    public abstract class AbstractTreeNode : TreeNode
    {

        public abstract void Selected(object sender, EventArgs e);

    }
}
