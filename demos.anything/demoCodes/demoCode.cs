
using CSharpGL;
using CSharpGL.Windows;
using demos.anything;
using System.Xml.Linq;

namespace demos.anything {
    public abstract unsafe class demoCode {
        protected readonly FormInstance mainForm;
        protected readonly WindowsGLCanvas canvas;


        public demoCode(FormInstance mainForm, WindowsGLCanvas canvas) {
            this.mainForm = mainForm;
            this.canvas = canvas;
            //this.init(gl);
            //this.reshape(gl, width, height);
        }

        public abstract void init(CSharpGL.GL gl);
        public abstract void display(CSharpGL.GL gl);
        public abstract void reshape(GL gl, int width, int height);
    }

}