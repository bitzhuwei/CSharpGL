using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    public static class IndexListHelper
    {
        public static List<uint> Swap4QuadStrip(this IEnumerable<uint> indexList)
        {
            if (indexList == null) { return null; }

            var result = new List<uint>(indexList);
            for (int i = 3; i < result.Count; i += 4)
            {
                uint tmp = result[i - 1];
                result[i - 1] = result[i];
                result[i] = tmp;
            }

            return result;
        }
    }
}
