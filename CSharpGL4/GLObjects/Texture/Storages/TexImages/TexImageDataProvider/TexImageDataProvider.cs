using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// 
    /// </summary>
    public class TexImageDataProvider : IEnumerable<LeveledData>
    {
        #region IEnumerable<LeveledData> 成员

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerator<LeveledData> GetEnumerator()
        {
            yield return new LeveledData();
        }

        #endregion

        #region IEnumerable 成员

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        #endregion
    }
}
