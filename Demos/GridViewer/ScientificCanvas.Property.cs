using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using CSharpGL;

namespace GridViewer
{
    public partial class ScientificCanvas
    {

        public UIColorPaletteRenderer uiColorPalette { get; private set; }

        public UIAxis uiAxis { get; private set; }

        public Texture CodedColorSampler
        {
            get
            {
                return this.uiColorPalette.Sampler;
            }
        }
    }
}
