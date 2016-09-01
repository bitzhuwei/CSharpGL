using CSharpGL;

namespace GridViewer
{
    public partial class ScientificCanvas
    {
        /// <summary>
        /// OpoenGL UI: color palette.
        /// </summary>
        public UIColorPaletteRenderer ColorPalette { get; private set; }

        /// <summary>
        /// OpenGL UI: axis.
        /// </summary>
        public UIAxis Axis { get; private set; }
    }
}