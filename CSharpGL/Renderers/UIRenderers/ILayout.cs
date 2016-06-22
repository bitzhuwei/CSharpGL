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
    public interface ILayout : ITreeNode<UIRenderer>
    {

        /// <summary>
        /// the edges of the <see cref="GLCanvas"/> to which a UI’s rect is bound and determines how it is resized with its parent.
        /// <para>something like AnchorStyles.Left | AnchorStyles.Bottom.</para>
        /// </summary>
        System.Windows.Forms.AnchorStyles Anchor { get; set; }

        /// <summary>
        /// Gets or sets the space between viewport and SimpleRect.
        /// </summary>
        System.Windows.Forms.Padding Margin { get; set; }

        /// <summary>
        /// 相对于<see cref="Container"/>左下角的位置(Left Down location)
        /// </summary>
        System.Drawing.Point Location { get; set; }

        /// <summary>
        /// Stores width when <see cref="OpenGLUIRect.Anchor"/>.Left &amp; <see cref="OpenGLUIRect.Anchor"/>.Right is <see cref="OpenGLUIRect.Anchor"/>.None.
        /// <para> and height when <see cref="OpenGLUIRect.Anchor"/>.Top &amp; <see cref="OpenGLUIRect.Anchor"/>.Bottom is <see cref="OpenGLUIRect.Anchor"/>.None.</para>
        /// </summary>
        System.Drawing.Size Size { get; set; }

        System.Drawing.Size ParentLastSize { get; set; }

        int zNear { get; set; }

        int zFar { get; set; }

    }
}
