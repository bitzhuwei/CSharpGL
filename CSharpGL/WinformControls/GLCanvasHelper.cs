
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;


namespace CSharpGL
{
    static class GLCanvasHelper
    {
        //static PyramidVAOElement pyramidVAOElement = new PyramidVAOElement();
        //static GLCanvasHelper()
        //{
        //    pyramidVAOElement.Initialize();
        //}

        //public static void DrawWithElement()
        //{
        //    pyramidVAOElement.Render(new RenderEventArgs(RenderModes.Render, this.camera));
        //}
        static readonly mat4 viewMatrix = glm.lookAt(new vec3(0, 0, 2), new vec3(0, 0, 0), new vec3(0, 1, 0));
        public static void ResizeGL(double width, double height)
        {
            //  Set the projection matrix.
            OpenGL.MatrixMode(OpenGL.GL_PROJECTION);

            //  Load the identity.
            OpenGL.LoadIdentity();
            ////  Create a perspective transformation.
            //OpenGL.gluPerspective(60.0f, width / height, 0.01, 100.0);
            mat4 projectionMatrix = glm.perspective(glm.radians(60.0f), (float)(width / height), 0.01f, 100.0f);
            OpenGL.MultMatrixf((projectionMatrix * viewMatrix).to_array());

            ////  Use the 'look at' helper function to position and aim the camera.
            //OpenGL.gluLookAt(-2, 2, -2, 0, 0, 0, 0, 1, 0);

            //  Set the modelview matrix.
            OpenGL.MatrixMode(OpenGL.GL_MODELVIEW);
        }

        static readonly List<vec3> secondPosition = new List<vec3>();
        static readonly List<vec3> secondColor = new List<vec3>();
        static readonly LineWidthSwitch secondLineWidthSwitch = new LineWidthSwitch(1);
        static readonly List<vec3> minutePosition = new List<vec3>();
        static readonly List<vec3> minuteColor = new List<vec3>();
        static readonly LineWidthSwitch minuteLineWidthSwitch = new LineWidthSwitch(3);
        static readonly List<vec3> hourPosition = new List<vec3>();
        static readonly List<vec3> hourColor = new List<vec3>();
        static readonly LineWidthSwitch hourLineWidthSwitch = new LineWidthSwitch(5);
        static GLCanvasHelper()
        {
            // second
            secondColor.Add(new vec3(1.0f, 0.0f, 0.0f));
            secondPosition.Add(new vec3(0.0f, 0.0f, 0.0f));
            secondColor.Add(new vec3(1.0f, 0.0f, 0.0f));
            secondPosition.Add(new vec3(0.0f, 1.0f, 0.0f) * 1.0f);
            // minite
            minuteColor.Add(new vec3(0.0f, 1.0f, 0.0f));
            minutePosition.Add(new vec3(0.0f, 0.0f, 0.0f));
            minuteColor.Add(new vec3(0.0f, 1.0f, 0.0f));
            minutePosition.Add(new vec3(0.0f, 1.0f, 0.0f) * 0.8f);
            // hour
            hourColor.Add(new vec3(0.0f, 0.0f, 1.0f));
            hourPosition.Add(new vec3(0.0f, 0.0f, 0.0f));
            hourColor.Add(new vec3(0.0f, 0.0f, 1.0f));
            hourPosition.Add(new vec3(0.0f, 1.0f, 0.0f) * 0.5f);
        }

        public static void DrawClock()
        {
            DateTime now = DateTime.Now;

            OpenGL.LoadIdentity();
            float secondAngle = ((float)now.Second) / 60.0f * 360.0f;
            OpenGL.Rotatef(secondAngle, 0.0f, 0.0f, -1.0f);
            secondLineWidthSwitch.On();
            OpenGL.Begin(OpenGL.GL_LINES);
            for (int i = 0; i < secondPosition.Count; i++)
            {
                vec3 color = secondColor[i];
                OpenGL.Color3f(color.x, color.y, color.z);
                vec3 position = secondPosition[i];
                OpenGL.Vertex3f(position.x, position.y, position.z);
            }
            OpenGL.End();
            secondLineWidthSwitch.Off();

            OpenGL.LoadIdentity();
            float minuteAngle = ((float)(now.Minute * 60 + now.Second)) / (60.0f * 60.0f) * 360.0f;
            OpenGL.Rotatef(minuteAngle, 0.0f, 0.0f, -1.0f);
            minuteLineWidthSwitch.On();
            OpenGL.Begin(OpenGL.GL_LINES);
            for (int i = 0; i < minutePosition.Count; i++)
            {
                vec3 color = minuteColor[i];
                OpenGL.Color3f(color.x, color.y, color.z);
                vec3 position = minutePosition[i];
                OpenGL.Vertex3f(position.x, position.y, position.z);
            }
            OpenGL.End();
            minuteLineWidthSwitch.Off();

            OpenGL.LoadIdentity();
            float hourAngle = ((float)((now.Hour * 60 + now.Minute) * 60 + now.Second)) / (24.0f * 60.0f * 60.0f) * 360.0f;
            OpenGL.Rotatef(hourAngle, 0.0f, 0.0f, -1.0f);
            hourLineWidthSwitch.On();
            OpenGL.Begin(OpenGL.GL_LINES);
            for (int i = 0; i < hourPosition.Count; i++)
            {
                vec3 color = hourColor[i];
                OpenGL.Color3f(color.x, color.y, color.z);
                vec3 position = hourPosition[i];
                OpenGL.Vertex3f(position.x, position.y, position.z);
            }
            OpenGL.End();
            hourLineWidthSwitch.Off();

        }

    }
}
