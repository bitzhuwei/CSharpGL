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
    public class BillboardRenderAction : DependentActionBase
    {
        private BillboardSortAction sortAction;
        /// <summary>
        /// Render sorted billboards.
        /// </summary>
        /// <param name="scene"></param>
        /// <param name="sortAction"></param>
        public BillboardRenderAction(Scene scene, BillboardSortAction sortAction)
            : base(scene)
        {
            this.sortAction = sortAction;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        public override void Act(ActionParams param)
        {
            var arg = new RenderEventArgs(this.Scene, param.Canvas, this.Scene.Camera);
            foreach (var item in this.sortAction.BillboardList)
            {
                item.RenderBeforeChildren(arg);
            }
        }
    }
}