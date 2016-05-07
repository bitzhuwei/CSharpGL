using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpGL.Demos
{
    public partial class Form02OrderIndependentTransparency : Form
    {

        private Camera camera;
        private SatelliteRotator rotator;
        private OrderIndependentTransparencyRenderer OITRenderer;
        private FormProperyGrid formPropertyGrid;

        public Form02OrderIndependentTransparency()
        {
            InitializeComponent();
            
        }

    }
}
