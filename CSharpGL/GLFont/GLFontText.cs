using System.Drawing;

namespace CSharpGL
{
    /// <summary>
    /// Class to hide GLFontTextNodeList and related classes from 
    /// user whilst allowing a textNodeList to be passed around.
    /// </summary>
	public class GLFontText
    {
        internal GLFontTextNodeList textNodeList;
        internal SizeF maxSize;
        internal GLFontAlignment alignment;
		public GLFontVertexBuffer[] VertexBuffers;
    }
}
