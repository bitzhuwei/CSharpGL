using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T">data type.</typeparam>
    public abstract class TexImageDataProvider<T> : IEnumerable<T>
    {
        #region IEnumerable<T> 成员

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public abstract IEnumerator<T> GetEnumerator();

        #endregion

        #region IEnumerable 成员

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        #endregion
    }
}
