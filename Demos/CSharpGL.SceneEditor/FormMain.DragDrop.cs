using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpGL.SceneEditor
{
    public partial class FormMain
    {

        private void treeView1_DragEnter(object sender, DragEventArgs e)
        {
            // 拖动效果设成移动
            e.Effect = DragDropEffects.Move;
        }

        private void treeView1_ItemDrag(object sender, ItemDragEventArgs e)
        {
            this.DoDragDrop(e.Item, DragDropEffects.Move);
        }

        private void treeView1_DragDrop(object sender, DragEventArgs e)
        {
            //判断拖动的是否为TreeNode类型，不是的话不予处理
            if (e.Data.GetDataPresent("System.Windows.Forms.TreeNode", false))
            {
                var treeView = sender as TreeView;
 
                // 获取当前光标所处的坐标
                // 定义一个位置点的变量，保存当前光标所处的坐标点
                Point point = treeView.PointToClient(new Point(e.X, e.Y));
                // 拖放的目标节点
                TreeNode targetTreeNode;
                // 根据坐标点取得处于坐标点位置的节点
                targetTreeNode = treeView.GetNodeAt(point);
                // 定义一个中间变量
                TreeNode treeNode;
                // 获取被拖动的节点
                treeNode = (TreeNode)e.Data.GetData("System.Windows.Forms.TreeNode");
                // 判断拖动的节点与目标节点是否是同一个,同一个不予处理
                if (treeNode != targetTreeNode)
                {
                    if (targetTreeNode != null)
                    {
                        // 往目标节点中加入被拖动节点的一份克隆
                        targetTreeNode.Nodes.Add((TreeNode)treeNode.Clone());
                        // 将被拖动的节点移除
                        treeNode.Remove();
                        targetTreeNode.ExpandAll();
                    }
                    else
                    {
                        treeView.Nodes.Add((TreeNode)treeNode.Clone());
                        // 将被拖动的节点移除
                        treeNode.Remove();
                        treeView.ExpandAll();
                    }
                }
            }
        }
    }
}
