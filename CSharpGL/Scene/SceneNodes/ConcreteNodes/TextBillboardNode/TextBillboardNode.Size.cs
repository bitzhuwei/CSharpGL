using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    public partial class TextBillboardNode
    {
        /// <summary>
        /// height / width.
        /// </summary>
        private float heightByWidth;
        /// <summary>
        /// width / height.
        /// </summary>
        private float widthByHeight;

        private int _width;
        /// <summary>
        /// Billboard's width(in pixels).
        /// </summary>
        public int Width
        {
            get { return this._width; }
            set
            {
                if (this._width != value)
                {
                    this._width = value;

                    if (value != 0.0f)
                    {
                        this._height = (int)(value * this.heightByWidth);
                    }

                    ModernRenderUnit unit = this.RenderUnit;
                    if (unit == null) { return; }
                    RenderMethod method = unit.Methods[0];
                    if (method == null) { return; }
                    ShaderProgram program = method.Program;
                    if (program == null) { return; }

                    program.SetUniform(width, this._width);
                    program.SetUniform(height, this._height);
                }
            }
        }

        private int _height;
        /// <summary>
        /// Billboard's height(in pixels).
        /// </summary>
        public int Height
        {
            get { return this._height; }
            set
            {
                if (this._height != value)
                {
                    this._height = value;

                    if (value != 0.0f)
                    {
                        this._width = (int)(value * this.widthByHeight);
                    }

                    ModernRenderUnit unit = this.RenderUnit;
                    if (unit == null) { return; }
                    RenderMethod method = unit.Methods[0];
                    if (method == null) { return; }
                    ShaderProgram program = method.Program;
                    if (program == null) { return; }

                    program.SetUniform(width, this._width);
                    program.SetUniform(height, this._height);
                }
            }
        }
    }
}
