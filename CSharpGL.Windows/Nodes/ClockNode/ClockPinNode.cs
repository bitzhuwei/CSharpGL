using System;
using System.Collections.Generic;

namespace CSharpGL
{
    public class ClockPinNode : SceneNodeBase, IRenderable
    {
        private readonly List<vec3> secondPosition = new List<vec3>();
        private readonly List<vec3> secondColor = new List<vec3>();
        private readonly LineWidthSwitch secondLineWidthState = new LineWidthSwitch(1);
        private readonly List<vec3> minutePosition = new List<vec3>();
        private readonly List<vec3> minuteColor = new List<vec3>();
        private readonly LineWidthSwitch minuteLineWidthState = new LineWidthSwitch(3);
        private readonly List<vec3> hourPosition = new List<vec3>();
        private readonly List<vec3> hourColor = new List<vec3>();
        private readonly LineWidthSwitch hourLineWidthState = new LineWidthSwitch(8);

        public ClockPinNode()
        {
            this.Scale = new vec3(1, 1, 1);
            this.RotationAxis = new vec3(0, 0, -1);
            this.ModelSize = new vec3(2, 2, 2);
        }

        protected override void DoInitialize()
        {
            // second
            secondColor.Add(new vec3(1.0f, 0.0f, 0.0f));
            secondPosition.Add(new vec3(0.0f, 0.0f, 0.0f));
            secondColor.Add(new vec3(1.0f, 0.0f, 0.0f));
            secondPosition.Add(new vec3(0.0f, 1.0f, 0.0f) * 0.85f);
            // minite
            minuteColor.Add(new vec3(0.0f, 1.0f, 0.0f));
            minutePosition.Add(new vec3(0.0f, 0.0f, 0.0f));
            minuteColor.Add(new vec3(0.0f, 1.0f, 0.0f));
            minutePosition.Add(new vec3(0.0f, 1.0f, 0.0f) * 0.7f);
            // hour
            hourColor.Add(new vec3(0.0f, 0.0f, 1.0f));
            hourPosition.Add(new vec3(0.0f, 0.0f, 0.0f));
            hourColor.Add(new vec3(0.0f, 0.0f, 1.0f));
            hourPosition.Add(new vec3(0.0f, 1.0f, 0.0f) * 0.5f);
        }

        #region IRendererable 成员

        private ThreeFlags enableRendering = ThreeFlags.BeforeChildren | ThreeFlags.Children;
        public ThreeFlags EnableRendering
        {
            get { return this.enableRendering; }
            set { this.enableRendering = value; }
        }

        /// <summary>
        /// Render something.
        /// </summary>
        /// <param name="arg"></param>
        public void RenderBeforeChildren(RenderEventArgs arg)
        {
            if (!this.IsInitialized) { Initialize(); }

            DoRender(arg);
        }

        public void RenderAfterChildren(RenderEventArgs arg)
        {
        }

        #endregion

        /// <summary>
        /// Render something.
        /// </summary>
        /// <param name="arg"></param>
        protected void DoRender(RenderEventArgs arg)
        {
            //this.LegacyMVP(arg);
            this.PushProjectionViewMatrix(arg);
            this.PushModelMatrix();

            DateTime now = DateTime.Now;
            const float speed = 1.0f;

            {
                float secondAngle = ((float)now.Second) / 60.0f * 360.0f * speed;
                this.RotationAngle = secondAngle;
                GL.Instance.LoadIdentity();
                this.LegacyTransform();

                secondLineWidthState.On();
                GL.Instance.Begin(GL.GL_LINES);
                for (int i = 0; i < secondPosition.Count; i++)
                {
                    vec3 color = secondColor[i];
                    GL.Instance.Color3f(color.x, color.y, color.z);
                    vec3 position = secondPosition[i];
                    GL.Instance.Vertex3f(position.x, position.y, position.z);
                }
                GL.Instance.End();
                secondLineWidthState.Off();
            }
            {
                float minuteAngle = ((float)(now.Minute * 60 + now.Second)) / (60.0f * 60.0f) * 360.0f * speed;
                this.RotationAngle = minuteAngle;
                GL.Instance.LoadIdentity();
                this.LegacyTransform();

                minuteLineWidthState.On();
                GL.Instance.Begin(GL.GL_LINES);
                for (int i = 0; i < minutePosition.Count; i++)
                {
                    vec3 color = minuteColor[i];
                    GL.Instance.Color3f(color.x, color.y, color.z);
                    vec3 position = minutePosition[i];
                    GL.Instance.Vertex3f(position.x, position.y, position.z);
                }
                GL.Instance.End();
                minuteLineWidthState.Off();
            }
            {
                float hourAngle = ((float)((now.Hour * 60 + now.Minute) * 60 + now.Second)) / (12.0f * 60.0f * 60.0f) * 360.0f * speed;
                this.RotationAngle = hourAngle;
                GL.Instance.LoadIdentity();
                this.LegacyTransform();

                hourLineWidthState.On();
                GL.Instance.Begin(GL.GL_LINES);
                for (int i = 0; i < hourPosition.Count; i++)
                {
                    vec3 color = hourColor[i];
                    GL.Instance.Color3f(color.x, color.y, color.z);
                    vec3 position = hourPosition[i];
                    GL.Instance.Vertex3f(position.x, position.y, position.z);
                }
                GL.Instance.End();
                hourLineWidthState.Off();
            }

            this.PopModelMatrix();
            this.PopProjectionViewMatrix();
        }

    }
}