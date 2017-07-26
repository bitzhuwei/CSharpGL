using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// 
    /// </summary>
    public class LeveledDataProvider : TexImageDataProvider<LeveledData>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override IEnumerator<LeveledData> GetEnumerator()
        {
            yield return new LeveledData(0);
        }
    }
}
