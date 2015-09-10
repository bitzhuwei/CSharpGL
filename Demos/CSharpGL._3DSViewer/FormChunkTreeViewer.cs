using CSharpGL.FileParser._3DSParser;
using CSharpGL.FileParser._3DSParser.Chunks;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpGL._3DSViewer
{
    public partial class FormChunkTreeViewer : Form
    {
        public FormChunkTreeViewer()
        {
            InitializeComponent();
        }

        private void 打开OToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.treeView1.Nodes.Clear();
                var filename = this.openFileDialog1.FileName;
                ThreeDSParser parser = new ThreeDSParser();
                var mainChunk = parser.Parse(filename);
                var node = BuildTree(mainChunk);
                this.treeView1.Nodes.Add(node);
                this.treeView1.ExpandAll();
                this.Text = string.Format("{0} - 3ds tree viewer", filename);
            }
        }

        private TreeNode BuildTree(ChunkBase chunk)
        {
            //TreeNode node = new TreeNode(string.Format("{0}(0x{1:X})", chunk.GetType().Name, chunk.GetID()));
            TreeNode node = new TreeNode(chunk.ToString());

            foreach (var item in chunk.Childern)
            {
                var itemNode = BuildTree(item);
                node.Nodes.Add(itemNode);
            }

            return node;
        }

        private void 退出XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
