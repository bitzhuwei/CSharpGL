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
        private const float scaleFactor = 1.0f;

        private List<Tuple<SimpleRenderer, RendererBase, Query>> coupleList = new List<Tuple<SimpleRenderer, RendererBase, Query>>();
        private DepthMaskSwitch depthMaskSwitch = new DepthMaskSwitch(false);
        private ColorMaskSwitch colorMaskSwitch = new ColorMaskSwitch(false, false, false, false);

        private bool enableConditionalRendering = true;

        public bool ConditionalRendering
        {
            get { return enableConditionalRendering; }
            set { enableConditionalRendering = value; }
        }

        private bool renderBoundingBox = false;

        public bool RenderBoundingBox
        {
            get { return renderBoundingBox; }
            set { renderBoundingBox = value; }
        }

        private bool renderTargetModel = true;

        public bool RenderTargetModel
        {
            get { return renderTargetModel; }
            set { renderTargetModel = value; }
        }

        public static ConditionalRenderer Create()
        {
            var result = new ConditionalRenderer();
            {
                var wallRenderer = SimpleRenderer.Create(new Cube(new vec3(unitLengths.x * 2, unitLengths.y * 2, 0.1f) * new vec3(xside, yside, zside)));
                wallRenderer.WorldPosition = new vec3(0, 0, 6);
                var boxRenderer = SimpleRenderer.Create(new Cube(new vec3(unitLengths.x * 2, unitLengths.y * 2, 0.1f) * new vec3(xside, yside, zside)));
                boxRenderer.WorldPosition = new vec3(0, 0, 6);
                var query = new Query();
                result.coupleList.Add(new Tuple<SimpleRenderer, RendererBase, Query>(boxRenderer, wallRenderer, query));
            }
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
                        renderer.WorldPosition =
                            (new vec3(x, y, z) * unitLengths * scaleFactor)
                            - (new vec3(xside - 1, yside - 1, zside - 1) * unitLengths * scaleFactor * 0.5f);
                        var cubeRenderer = SimpleRenderer.Create(new Cube(unitLengths));
                        cubeRenderer.WorldPosition = renderer.WorldPosition;
                        var query = new Query();
                        result.coupleList.Add(new Tuple<SimpleRenderer, RendererBase, Query>(cubeRenderer, renderer, query));
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
            if (this.ConditionalRendering)
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
                var result = new int[1];
                foreach (var item in this.coupleList)
                {
                    item.Item3.BeginConditionalRender(ConditionalRenderMode.QueryByRegionWait);
                    //if (item.Item3.SampleRendered())
                    {
                        if (this.renderTargetModel) { item.Item2.Render(arg); }
                        if (this.renderBoundingBox) { item.Item1.Render(arg); }
                    }
                    item.Item3.EndConditionalRender();
                }
            }
            else
            {
                foreach (var item in this.coupleList)
                {
                    if (this.renderTargetModel) { item.Item2.Render(arg); }
                    if (this.renderBoundingBox) { item.Item1.Render(arg); }
                }
            }
        }
    }
}