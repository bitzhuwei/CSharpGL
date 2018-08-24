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
    public class BillboardSortAction : ActionBase
    {
        private List<float> depthList = new List<float>();
        private List<TextBillboardNode> billboardList = new List<TextBillboardNode>();

        private SceneNodeBase rootNode;
        private ICamera camera;

        /// <summary>
        /// Sorted billboard list.
        /// </summary>
        public List<TextBillboardNode> BillboardList
        {
            get { return billboardList; }
        }

        /// <summary>
        /// How <see cref="billboardList"/> stores nodes?(from far nodes to near nodes?)
        /// </summary>
        public bool Far2Near { get; set; }

        /// <summary>
        /// Sort billboards in depth order.
        /// </summary>
        /// <param name="rootNode"></param>
        /// <param name="camera"></param>
        public BillboardSortAction(SceneNodeBase rootNode, ICamera camera)
        {
            this.Far2Near = true;

            this.rootNode = rootNode;
            this.camera = camera;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        public override void Act(ActionParams param)
        {
            this.depthList.Clear();
            this.billboardList.Clear();

            mat4 viewMat = this.camera.GetViewMatrix();
            this.Sort(this.rootNode, viewMat);

            if (!this.Far2Near)
            {
                this.depthList.Reverse();
                this.billboardList.Reverse();
            }
        }

        private void Sort(SceneNodeBase sceneElement, mat4 viewMat)
        {
            if (sceneElement != null)
            {
                var billboard = sceneElement as TextBillboardNode;
                if (billboard != null)
                {
                    Insert(billboard, viewMat);
                }

                foreach (var item in sceneElement.Children)
                {
                    this.Sort(item, viewMat);
                }
            }
        }

        /// <summary>
        /// binary insertion sort.
        /// </summary>
        /// <param name="billboard"></param>
        /// <param name="viewMat"></param>
        private void Insert(TextBillboardNode billboard, mat4 viewMat)
        {
            vec3 viewPosition = billboard.GetAbsoluteViewPosition(viewMat);
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