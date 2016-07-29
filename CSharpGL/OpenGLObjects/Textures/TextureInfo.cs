using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// generated texture's information.
    /// </summary>
    public class TextureInfo
    {
        /// <summary>
        /// texture's id.
        /// </summary>
        public uint Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("id: {0}", this.Id);
        }
    }
}
