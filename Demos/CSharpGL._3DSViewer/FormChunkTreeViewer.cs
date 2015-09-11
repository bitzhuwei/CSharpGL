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
        TreeNode fullTree;
        MainChunk chunkTree;
        TreeNode simpleTree;
        MainChunk simpleChunkTree;

        public FormChunkTreeViewer()
        {
            InitializeComponent();
        }

        private void 打开OToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var filename = this.openFileDialog1.FileName;
                ThreeDSParser parser = new ThreeDSParser();
                this.chunkTree = parser.Parse(filename);
                this.simpleChunkTree = BuildSimpleTree(this.chunkTree) as MainChunk;

                this.fullTree = BuildTreeNode(this.chunkTree);
                this.simpleTree = BuildTreeNode(this.simpleChunkTree);

                this.treeView1.Nodes.Clear();
                this.treeView1.Nodes.Add(this.fullTree);
                this.treeView1.ExpandAll();

                this.Text = string.Format("{0} - 3DS Chunk Viewer - http://bitzhuwei.cnblogs.com", filename);
                this.chkHideUndefinedChunks.Enabled = true;
            }
        }

        //private TreeNode BuildSimpleTree(ChunkBase chunk)
        //{
        //    TreeNode node = new TreeNode(chunk.ToString());
        //    node.Tag = chunk;
        //    node.ToolTipText = chunk.ToString();
        //    if (chunk.Length != chunk.BytesRead)
        //    {
        //        node.BackColor = Color.Red;
        //    }

        //    foreach (var item in chunk.Children)
        //    {
        //        if (item.GetType() != typeof(UndefinedChunk))
        //        {
        //            var itemNode = BuildSimpleTree(item);
        //            node.Nodes.Add(itemNode);
        //        }
        //    }

        //    return node;
        //}
        private ChunkBase BuildSimpleTree(ChunkBase chunk)
        {
            //TreeNode node = new TreeNode(chunk.ToString());
            var newChunk = chunk.Clone() as ChunkBase;
            newChunk.Parent = null;
            newChunk.Children = new List<ChunkBase>();

            foreach (var item in chunk.Children)
            {
                if (item.GetType() != typeof(UndefinedChunk))
                {
                    var newItem = BuildSimpleTree(item);
                    newItem.Parent = newChunk;
                    newChunk.Children.Add(newItem);
                }
            }

            return newChunk;
        }
        private TreeNode BuildTreeNode(ChunkBase chunk)
        {
            TreeNode node = new TreeNode(chunk.ToString());
            node.Tag = chunk;
            node.ToolTipText = chunk.ToString();
            if (chunk.Length != chunk.BytesRead)
            {
                node.BackColor = Color.Red;
            }

            foreach (var item in chunk.Children)
            {
                var itemNode = BuildTreeNode(item);
                node.Nodes.Add(itemNode);
            }

            return node;
        }

        private void 退出XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkHideUndefinedChunks_CheckedChanged(object sender, EventArgs e)
        {
            this.treeView1.Nodes.Clear();

            if (this.chkHideUndefinedChunks.Checked)
            {
                this.treeView1.Nodes.Add(simpleTree);
            }
            else
            {
                this.treeView1.Nodes.Add(fullTree);
            }

            this.treeView1.ExpandAll();
        }

        private void 导出文本ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //var node = this.fullTree.Tag as ITreeNode;
            if (this.treeView1.Nodes.Count > 0)
            {
                var node = this.treeView1.Nodes[0].Tag as ITreeNode;
                if (node != null)
                {
                    var text = node.DumpToText();
                    var form = new FormText();
                    form.textBox1.Text = text;
                    form.Show();
                }
            }
        }

    }
}