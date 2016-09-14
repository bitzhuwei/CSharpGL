using System.Collections.Generic;
using System.Drawing;

namespace CSharpGL.Demos
{
    /// <summary>
    /// demostrates how to perform conditional rendering.
    /// </summary>
    internal class ConditionalRenderer : RendererBase
    {
        private const int xside = 5, yside = 5, zside = 5;
        private const int pointCount = 10000;
        private static readonly vec3 unitLengths = new vec3(1, 1, 1);
        private const float scaleFactor = 1.1f;

        private List<Tuple<BoundingBoxRenderer, RendererBase, Query>> coupleList = new List<Tuple<BoundingBoxRenderer, RendererBase, Query>>();
        private DepthMaskSwitch depthMaskSwitch = new DepthMaskSwitch(false);
        private ColorMaskSwitch colorMaskSwitch = new ColorMaskSwitch(false, false, false, false);

        private bool enableConditionalRendering = true;

        public bool EnableConditionalRendering
        {
            get { return enableConditionalRendering; }
            set { enableConditionalRendering = value; }
        }

        public static ConditionalRenderer Create()
        {
            var result = new ConditionalRenderer();

            for (int x = 0; x < xside; x++)
            {
                for (int y = 0; y < yside; y++)
                {
                    for (int z = 0; z < zside; z++)
                    {
                        var model = new RandomPointsModel(unitLengths, pointCount);
                        RandomPointsRenderer renderer = RandomPointsRenderer.Create(model);
                        renderer.PointColor = Color.FromArgb(
                            (int)((float)(x + 1) / (float)xside * 255),
                            (int)((float)(y + 1) / (float)yside * 255),
                            (int)((float)(z + 1) / (float)zside * 255));
                        renderer.WorldPosition = new vec3(
                            (float)x / (float)(xside - 1) - 0.5f,
                            (float)y / (float)(yside - 1) - 0.5f,
                            (float)z / (float)(zside - 1) - 0.5f)
                            * new vec3(xside, yside, zside)
                            * unitLengths
                            * scaleFactor;// move a little longer.
                        BoundingBoxRenderer boxRenderer = renderer.GetBoundingBoxRenderer();
                        boxRenderer.SwitchList.Find(glSwitch => glSwitch is PolygonModeSwitch).InUse = false;
                        var query = new Query();
                        result.coupleList.Add(new Tuple<BoundingBoxRenderer, RendererBase, Query>(boxRenderer, renderer, query));
                    }
                }
            }

            result.Lengths = new vec3(xside + 1, yside + 1, zside + 1) * unitLengths * scaleFactor;

            return result;
        }

        private ConditionalRenderer()
        { }

        protected override void DoInitialize()
        {
            foreach (var item in this.coupleList)
            {
                item.Item1.Initialize();
                item.Item2.Initialize();
                item.Item3.Initialize();
            }
        }

        protected override void DoRender(RenderEventArgs arg)
        {
            if (this.EnableConditionalRendering)
            {
                this.depthMaskSwitch.On();
                this.colorMaskSwitch.On();
                foreach (var item in this.coupleList)
                {
                    item.Item3.BeginQuery(QueryTarget.AnySamplesPassed);
                    item.Item1.Render(arg);
                    item.Item3.EndQuery(QueryTarget.AnySamplesPassed);
                }
                this.colorMaskSwitch.Off();
                this.depthMaskSwitch.Off();
                foreach (var item in this.coupleList)
                {
                    item.Item3.BeginConditionalRender(ConditionalRenderMode.QueryByRegionWait);
                    item.Item2.Render(arg);
                    item.Item3.EndConditionalRender();
                }
            }
            else
            {
                foreach (var item in this.coupleList)
                {
                    item.Item1.Render(arg);
                    item.Item2.Render(arg);
                }
            }
        }
    }
}