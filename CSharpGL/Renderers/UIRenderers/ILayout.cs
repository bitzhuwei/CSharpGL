namespace CSharpGL
{
    /// <summary>
    /// Supports layout UI element in an OpenGL canvas.
    /// 实现在OpenGL画布上的UI布局
    /// </summary>
    public interface ILayout : ITreeNode<UIRenderer>
    {
        //event EventHandler afterLayout;

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
        /// 相对于Parent左下角的位置(Left Down location)
        /// </summary>
        System.Drawing.Point Location { get; set; }

        /// <summary>
        /// Stores width when <see cref="Anchor"/>.Left &amp; <see cref="Anchor"/>.Right is <see cref="Anchor"/>.None.
        /// <para> and height when <see cref="Anchor"/>.Top &amp; <see cref="Anchor"/>.Bottom is <see cref="Anchor"/>.None.</para>
        /// </summary>
        System.Drawing.Size Size { get; set; }

        /// <summary>
        ///
        /// </summary>
        System.Drawing.Size ParentLastSize { get; set; }

        /// <summary>
        ///
        /// </summary>
        int zNear { get; set; }

        /// <summary>
        ///
        /// </summary>
        int zFar { get; set; }
    }
}