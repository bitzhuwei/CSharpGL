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
            if (e.Data.GetDataPresent(typeof(TreeNode)))
            {
                var treeView = sender as TreeView;
 
                // 获取当前光标所处的坐标
                // 定义一个位置点的变量，保存当前光标所处的坐标点
                Point point = treeView.PointToClient(new Point(e.X, e.Y));
                // 根据坐标点取得目标节点
                TreeNode targetNode = treeView.GetNodeAt(point);
                // 获取被拖动的节点
                var dragedNode = (TreeNode)e.Data.GetData(typeof(TreeNode));
                // 判断拖动的节点与目标节点是否是同一个,同一个不予处理
                if (dragedNode != targetNode)
                {
                    if (targetNode != null)
                    {
                        // 将被拖动的节点移除
                        dragedNode.Remove();
                        var dragedObj = dragedNode.Tag as SceneObject;
                        if (dragedObj.Parent != null)
                        { dragedObj.Parent.Children.Remove(dragedObj); }
                        else
                        { this.scene.ObjectList.Remove(dragedObj); }
                        //treeNodeObj.Parent = null;
                        // 往目标节点中加入被拖动节点的一份克隆
                        targetNode.Nodes.Add(dragedNode);
                        var targetObj = targetNode.Tag as SceneObject;
                        targetObj.Children.Add(dragedObj);
                        targetNode.ExpandAll();
                    }
                    else
                    {
                        dragedNode.Remove();
                        var dragedObj = dragedNode.Tag as SceneObject;
                        if (dragedObj.Parent != null)
                        { dragedObj.Parent.Children.Remove(dragedObj); }
                        else
                        { this.scene.ObjectList.Remove(dragedObj); }
                        treeView.Nodes.Add(dragedNode);
                        this.scene.ObjectList.Add(dragedObj);
                        // 将被拖动的节点移除
                        treeView.ExpandAll();
                    }
                }
            }
        }
    }
}
