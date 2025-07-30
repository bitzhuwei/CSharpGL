
using CSharpGL;
using System.Xml.Linq;

namespace demos.glSuperBible7code {
    public abstract unsafe class _glSuperBible7code {
        protected readonly Form mainForm;

        public void StopAtError(GL gl) {
            uint error = gl.glGetError(); if (error != 0) { Console.WriteLine("error"); }

        }
        public _glSuperBible7code(Form mainForm, int width, int height, CSharpGL.GL gl) {
            this.mainForm = mainForm;
            //this.init(gl);
            //this.reshape(gl, width, height);
        }

        public abstract void init(CSharpGL.GL gl);
        public abstract void display(CSharpGL.GL gl);
        public abstract void reshape(CSharpGL.GL gl, int width, int height);
        public abstract void mouse(MouseButtons button, MouseState state, int x, int y);
        public abstract void keyboard(CSharpGL.GL gl, Keys key, int x, int y);

        public abstract Keys[] ValidKeys { get; }
        public abstract MouseButtons[] ValidButtons { get; }
    }

    public enum MouseState { Down, Up, Move };
}