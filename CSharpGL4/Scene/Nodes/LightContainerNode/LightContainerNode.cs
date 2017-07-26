using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// contains some lights that affects the children node.
    /// </summary>
    public class LightContainerNode : SceneNodeBase, ILocalLightContainer, IRenderable
    {
        /// <summary>
        /// contains some nodes in its children.
        /// </summary>
        /// <param name="localLights">lights that affects the children node.</param>
        public LightContainerNode(params LightBase[] localLights)
        {
            this.lightList.AddRange(localLights);
        }

        #region ILocalLightContainer 成员

        private List<LightBase> lightList = new List<LightBase>();
        /// <summary>
        /// 
        /// </summary>
        public List<LightBase> LightList { get { return this.lightList; } }

        #endregion

        #region IRenderable 成员

        private ThreeFlags enableRendering = ThreeFlags.BeforeChildren | ThreeFlags.Children | ThreeFlags.AfterChildren;

        /// <summary>
        /// 
        /// </summary>
        public ThreeFlags EnableRendering
        {
            get { return enableRendering; }
            set { enableRendering = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arg"></param>
        public void RenderBeforeChildren(RenderEventArgs arg)
        {
            // prepare lights for children.
            arg.CurrentLights.Push(this.lightList);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arg"></param>
        public void RenderAfterChildren(RenderEventArgs arg)
        {
            // reset stack.
            arg.CurrentLights.Pop();
        }

        #endregion
    }
}
