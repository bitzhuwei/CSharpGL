using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    public partial class TextBillboardNode
    {
        private float _width;// TODO: make this an int type!
        /// <summary>
        /// Billboard's width(in pixels).
        /// </summary>
        public int Width
        {
            get { return (int)_width; }
            set
            {
                if (_width != value)
                {
                    _width = value;

                    ModernRenderUnit unit = this.RenderUnit;
                    if (unit == null) { return; }
                    RenderMethod method = unit.Methods[0];
                    if (method == null) { return; }
                    ShaderProgram program = method.Program;
                    if (program == null) { return; }

                    program.SetUniform(width, _width);
                }
            }
        }

        private float _height;
        /// <summary>
        /// Billboard's height(in pixels).
        /// </summary>
        public int Height
        {
            get { return (int)_height; }
            set
            {
                if (_height != value)
                {
                    _height = value;

                    ModernRenderUnit unit = this.RenderUnit;
                    if (unit == null) { return; }
                    RenderMethod method = unit.Methods[0];
                    if (method == null) { return; }
                    ShaderProgram program = method.Program;
                    if (program == null) { return; }

                    program.SetUniform(height, _height);
                }
            }
        }
    }
}
