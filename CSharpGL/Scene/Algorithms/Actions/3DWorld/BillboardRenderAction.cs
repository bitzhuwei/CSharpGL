using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// Render sorted billboards.
    /// </summary>
    public class BillboardRenderAction : ActionBase
    {
        private ICamera camera;
        private BillboardSortAction sortAction;

        private readonly DepthMaskSwitch depthMask = new DepthMaskSwitch(false);

        /// <summary>
        /// Render sorted billboards.
        /// </summary>
        /// <param name="camera"></param>
        /// <param name="sortAction"></param>
        public BillboardRenderAction(ICamera camera, BillboardSortAction sortAction)
        {
            this.camera = camera;
            this.sortAction = sortAction;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        public override void Act(ActionParams param)
        {
            var depthMask = this.depthMask;
            depthMask.On();
            var arg = new RenderEventArgs(param, this.camera);
            foreach (var item in this.sortAction.BillboardList)
            {
                item.RenderBeforeChildren(arg);
            }
            depthMask.Off();
        }
    }
}