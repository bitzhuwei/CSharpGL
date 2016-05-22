using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpGL
{
    /// <summary>
    /// 实现在OpenGL窗口中的UI布局
    /// </summary>
    public class OrthoParams
    {
        public float Left { get; set; }
        public float Right { get; set; }
        public float Bottom { get; set; }
        public float Top { get; set; }
        public float Near { get; set; }
        public float Far { get; set; }

        public mat4 GetOrthoProjection()
        {
            return glm.ortho(Left, Right, Bottom, Top, Near, Far);
        }

        public override string ToString()
        {
            return string.Format("glm.ortho({0}, {1}, {2}, {3}, {4}, {5});",
                Left, Right, Bottom, Top, Near, Far);
        }
    }
}
