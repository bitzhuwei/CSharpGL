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
    public partial class ScientificCanvas : GLCanvas
    {

        public Scene Scene { get; private set; }
        private SatelliteManipulater cameraManipulater;

        public ScientificCanvas()
        {
            if (!this.designMode)
            {
                this.Load += ScientificCanvas_Load;
            }
        }

    }
}
