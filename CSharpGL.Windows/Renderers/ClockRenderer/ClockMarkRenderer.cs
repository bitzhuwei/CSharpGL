using System;
using System.Collections.Generic;

namespace CSharpGL
{
    public class ClockMarkRenderer : RendererBase, IRenderable
    {
        private readonly List<vec3> markPosition = new List<vec3>();
        private readonly List<vec3> markColor = new List<vec3>();

        public ClockMarkRenderer()
        {
            this.Scale = new vec3(1, 1, 1);
            this.ModelSize = new vec3(2, 2, 2);
        }

        protected override void DoInitialize()
        {
            int markCount = 60;
            for (int i = 0; i < markCount; i++)
            {
                var position = new vec3(
                    (float)Math.Cos((double)i / (double)markCount * Math.PI * 2),
                    (float)Math.Sin((double)i / (double)markCount * Math.PI * 2),
                    0);
                markPosition.Add(position);
                markColor.Add(new vec3(1, 1, 1));

                var position2 = new vec3(
                    (float)Math.Cos((double)i / (double)markCount * Math.PI * 2),
                    (float)Math.Sin((double)i / (double)markCount * Math.PI * 2),
                    0) * (i % 5 == 0 ? 0.8f : 0.9f);
                markPosition.Add(position2);
                markColor.Add(new vec3(1, 1, 1));
            }
        }

        #region IRendererable 成员

        private bool renderingEnabled = true;
        /// <summary>
        /// 
        /// </summary>
        public bool RenderingEnabled { get { return renderingEnabled; } set { renderingEnabled = value; } }

        /// <summary>
        /// Render something.
        /// </summary>
        /// <param name="arg"></param>
        public void Render(RenderEventArgs arg)
        {
            if (!this.IsInitialized) { Initialize(); }

            DoRender(arg);
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

            GL.Instance.Begin((uint)DrawMode.Lines);
            for (int i = 0; i < markPosition.Count; i++)
            {
                vec3 color = markColor[i];
                GL.Instance.Color3f(color.x, color.y, color.z);
                vec3 position = markPosition[i];
                GL.Instance.Vertex3f(position.x, position.y, position.z);
            }
            GL.Instance.End();

            this.PopModelMatrix();
            this.PopProjectionViewMatrix();
        }

    }
}