using System;
using System.Collections.Generic;

namespace CSharpGL
{
    internal class ClockCircleNode : SceneNodeBase, IRenderable
    {
        private readonly List<vec3> circlePosition = new List<vec3>();
        private readonly List<vec3> circleColor = new List<vec3>();
        private readonly LineWidthState circleLineWidthState = new LineWidthState(8);

        public ClockCircleNode()
        {
            this.Scale = new vec3(1, 1, 1);
            this.ModelSize = new vec3(2, 2, 2);
        }

        protected override void DoInitialize()
        {
            int circleParts = 60;
            for (int i = 0; i < circleParts; i++)
            {
                var position = new vec3(
                    (float)Math.Cos((double)i / (double)circleParts * Math.PI * 2),
                    (float)Math.Sin((double)i / (double)circleParts * Math.PI * 2),
                    0);
                circlePosition.Add(position);
                circleColor.Add(new vec3(1, 1, 1));
            }
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

            circleLineWidthState.On();
            GL.Instance.Begin((uint)DrawMode.LineLoop);
            for (int i = 0; i < circlePosition.Count; i++)
            {
                vec3 color = circleColor[i];
                GL.Instance.Color3f(color.x, color.y, color.z);
                vec3 position = circlePosition[i];
                GL.Instance.Vertex3f(position.x, position.y, position.z);
            }
            GL.Instance.End();

            circleLineWidthState.Off();

            this.PopModelMatrix();
            this.PopProjectionViewMatrix();
        }

    }
}