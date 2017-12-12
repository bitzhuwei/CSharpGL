using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace CSharpGL
{
    public partial class WinGLCanvas
    {
        private ContextGenerationParams parameters = new ContextGenerationParams();
        ///// <summary>
        ///// 
        ///// </summary>
        //[Category(strWinGLCanvas)]
        //[Description("Paramters of creating render context. Any setup after InitializeComponent() is invalid.")]
        //public ContextGenerationParams Parameters { get { return this.parameters; } }

        [Category(strWinGLCanvas)]
        public bool UpdateContextVersion
        {
            get { return this.parameters.UpdateContextVersion; }
            set { this.parameters.UpdateContextVersion = value; }
        }

        [Category(strWinGLCanvas)]
        public byte AccumBits
        {
            get { return this.parameters.AccumBits; }
            set { this.parameters.AccumBits = value; }
        }

        [Category(strWinGLCanvas)]
        public byte AccumRedBits
        {
            get { return this.parameters.AccumRedBits; }
            set { this.parameters.AccumRedBits = value; }
        }

        [Category(strWinGLCanvas)]
        public byte AccumGreenBits
        {
            get { return this.parameters.AccumGreenBits; }
            set { this.parameters.AccumGreenBits = value; }
        }

        [Category(strWinGLCanvas)]
        public byte AccumBlueBits
        {
            get { return this.parameters.AccumBlueBits; }
            set { this.parameters.AccumBlueBits = value; }
        }

        [Category(strWinGLCanvas)]
        public byte AccumAlphaBits
        {
            get { return this.parameters.AccumAlphaBits; }
            set { this.parameters.AccumAlphaBits = value; }
        }

        [Category(strWinGLCanvas)]
        public byte StencilBits
        {
            get { return this.parameters.StencilBits; }
            set { this.parameters.StencilBits = value; }
        }

    }
}