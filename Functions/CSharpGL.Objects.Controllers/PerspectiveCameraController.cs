using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSharpGL.Objects.Cameras;

namespace CSharpGL.Objects.Controllers
{
    public partial class PerspectiveCameraController : UserControl
    {
        public PerspectiveCameraController(IPerspectiveViewCamera camera)
        {
            InitializeComponent();

            this.camera = camera;
        }

        public IPerspectiveViewCamera camera { get; private set; }
    }
}
