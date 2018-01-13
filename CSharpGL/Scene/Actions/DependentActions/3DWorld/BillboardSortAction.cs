using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// Sort billboards in depth order.
    /// </summary>
    public class BillboardSortAction : DependentActionBase
    {
        private List<float> depthList = new List<float>();
        private List<TextBillboardNode> billboardList = new List<TextBillboardNode>();

        /// <summary>
        /// Sorted billboard list.
        /// </summary>
        public List<TextBillboardNode> BillboardList
        {
            get { return billboardList; }
        }

        /// <summary>
        /// Sort billboards in depth order.
        /// </summary>
        /// <param name="scene"></param>
        public BillboardSortAction(Scene scene) : base(scene) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        public override void Act(ActionParams param)
        {
            this.depthList.Clear();
            this.billboardList.Clear();

            mat4 viewMatrix = this.Scene.Camera.GetViewMatrix();
            this.Sort(this.Scene.RootElement, viewMatrix);
        }

        private void Sort(SceneNodeBase sceneElement, mat4 viewMatrix)
        {
            if (sceneElement != null)
            {
                var billboard = sceneElement as TextBillboardNode;
                if (billboard != null)
                {
                    Insert(billboard, viewMatrix);
                }

                foreach (var item in sceneElement.Children)
                {
                    this.Sort(item, viewMatrix);
                }
            }
        }

        /// <summary>
        /// binary insertion sort.
        /// </summary>
        /// <param name="billboard"></param>
        /// <param name="viewMatrix"></param>
        private void Insert(TextBillboardNode billboard, mat4 viewMatrix)
        {
            vec3 viewPosition = billboard.GetAbsoluteViewPosition(viewMatrix);
            int left = 0, right = this.depthList.Count - 1;
            while (left <= right)
            {
                int middle = (left + right) / 2;
                float value = this.depthList[middle];
                if (value < viewPosition.z)
                {
                    left = middle + 1;
                }
                else if (value == viewPosition.z)
                {
                    left = middle;
                    break;
                }
                else //(viewPosition.z < value)
                {
                    right = middle - 1;
                }
            }

            this.depthList.Insert(left, viewPosition.z);
            this.billboardList.Insert(left, billboard);
        }

    }
}