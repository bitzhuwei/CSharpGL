using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// contains some lights that affects the children node.
    /// </summary>
    public class LightsRenderer : SceneNodeBase, ILocalLightContainer, IShadowMapping
    {
        /// <summary>
        /// contains some renderers in its children.
        /// </summary>
        /// <param name="localLights">lights that affects the children node.</param>
        public LightsRenderer(params LightBase[] localLights)
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

        #region IShadowMapping 成员

        private bool enableShadowMapping = true;
        /// <summary>
        /// 
        /// </summary>
        public bool EnableShadowMapping { get { return enableShadowMapping; } set { enableShadowMapping = value; } }

        private int currentIndex = 0;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="arg"></param>
        public void CastShadow(ShdowMappingEventArgs arg)
        {

            throw new NotImplementedException();
        }

        private bool again = false;
        /// <summary>
        /// 
        /// </summary>
        public bool Again
        {
            get { return this.again; }
        }

        #endregion
    }
}
