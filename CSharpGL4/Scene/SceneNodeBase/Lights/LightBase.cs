using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class LightBase : IShadowMapping
    {
        /// <summary>
        /// 
        /// </summary>
        public vec3 Color { get; set; }

        #region IShadowMapping 成员


        private bool enableShadowMapping = true;

        /// <summary>
        /// 
        /// </summary>
        public bool EnableShadowMapping
        {
            get { return enableShadowMapping; }
            set { enableShadowMapping = value; }
        }

        public abstract void CastShadow(RenderEventArgs arg);

        #endregion
    }
}
