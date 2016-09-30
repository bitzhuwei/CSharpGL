using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;

namespace CSharpGL.Demos
{
    internal class DemoRendererFactory
    {
        public static RendererTransporter Create(Type rendererType)
        {
            RendererTransporter result = null;
            if (rendererType == typeof(AnalyzedPointSpriteRenderer))
            {
                RendererBase renderer = AnalyzedPointSpriteRenderer.Create(particleCount: 10000);
                string tip = GetDefaultTip();
                result = new RendererTransporter(renderer, tip, Color.Black);
            }
            else if (rendererType == typeof(BufferBlockRenderer))
            {
                RendererBase renderer = BufferBlockRenderer.Create();
                string tip = GetDefaultTip();
                result = new RendererTransporter(renderer, tip, Color.Black);
            }
            else if (rendererType == typeof(ConditionalRenderer))
            {
                RendererBase renderer = ConditionalRenderer.Create();
                string tip = GetDefaultTip();
                result = new RendererTransporter(renderer, tip, Color.Black);
            }
            else if (rendererType == typeof(EmitNormalLineRenderer))
            {
                var model = new Teapot();
                RendererBase renderer = EmitNormalLineRenderer.Create(model, Teapot.strPosition, Teapot.strNormal, model.Lengths);
                string tip = GetDefaultTip();
                result = new RendererTransporter(renderer, tip, Color.Black);
            }
            else if (rendererType == typeof(ImageProcessingRenderer))
            {
                RendererBase renderer = new ImageProcessingRenderer();
                string tip = GetDefaultTip();
                result = new RendererTransporter(renderer, tip, Color.Black);
            }
            else if (rendererType == typeof(KleinBottleRenderer))
            {
                RendererBase renderer = KleinBottleRenderer.Create(new KleinBottleModel());
                string tip = GetDefaultTip();
                result = new RendererTransporter(renderer, tip, Color.Black);
            }
            else if (rendererType == typeof(OrderDependentTransparencyRenderer))
            {
                var model = new Teapot();
                RendererBase renderer = OrderDependentTransparencyRenderer.Create(model, model.Lengths, Teapot.strPosition, Teapot.strColor);
                string tip = GetDefaultTip();
                result = new RendererTransporter(renderer, tip, Color.Black);
            }
            else if (rendererType == typeof(OrderIndependentTransparencyRenderer))
            {
                var model = new Teapot();
                RendererBase renderer = new OrderIndependentTransparencyRenderer(model, model.Lengths, Teapot.strPosition, Teapot.strColor);
                string tip = GetDefaultTip();
                result = new RendererTransporter(renderer, tip, Color.Black);
            }
            else if (rendererType == typeof(ParticleSimulatorRenderer))
            {
                RendererBase renderer = new ParticleSimulatorRenderer();
                string tip = GetDefaultTip();
                result = new RendererTransporter(renderer, tip, Color.Black);
            }
            else if (rendererType == typeof(PointCloudRenderer))
            {
                var list = new List<vec3>();

                using (var reader = new StreamReader(@"Resources\data\19PointCloud.txt"))
                {
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        string[] parts = line.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        float x = float.Parse(parts[0]);
                        float y = float.Parse(parts[1]);
                        float z = float.Parse(parts[2]);
                        list.Add(new vec3(x, y, z));
                    }
                }
                RendererBase renderer = PointCloudRenderer.Create(new PointCloudModel(list));
                string tip = GetDefaultTip();
                result = new RendererTransporter(renderer, tip, Color.Black);
            }
            else if (rendererType == typeof(PointSpriteRenderer))
            {
                const int particleCount = 10000;
                RendererBase renderer = PointSpriteRenderer.Create(particleCount);
                string tip = GetDefaultTip();
                result = new RendererTransporter(renderer, tip, Color.Black);
            }
            else if (rendererType == typeof(RaycastVolumeRenderer))
            {
                RendererBase renderer = new RaycastVolumeRenderer();
                string tip = GetDefaultTip();
                result = new RendererTransporter(renderer, tip, Color.Black);
            }
            else if (rendererType == typeof(RayTracingRenderer))
            {
                RendererBase renderer = RayTracingRenderer.Create();
                string tip = GetDefaultTip();
                result = new RendererTransporter(renderer, tip, Color.Black);
            }
            else if (rendererType == typeof(ShaderToyRenderer))
            {
                RendererBase renderer = ShaderToyRenderer.Create();
                string tip = GetDefaultTip();
                result = new RendererTransporter(renderer, tip, Color.Black);
            }
            else if (rendererType == typeof(SimpleComputeRenderer))
            {
                RendererBase renderer = SimpleComputeRenderer.Create();
                string tip = GetDefaultTip();
                result = new RendererTransporter(renderer, tip, Color.Black);
            }
            else if (rendererType == typeof(SimplexNoiseRenderer))
            {
                RendererBase renderer = SimplexNoiseRenderer.Create();
                string tip = GetDefaultTip();
                result = new RendererTransporter(renderer, tip, Color.Black);
            }
            else if (rendererType == typeof(UniformArrayRenderer))
            {
                RendererBase renderer = UniformArrayRenderer.Create();
                string tip = GetDefaultTip();
                result = new RendererTransporter(renderer, tip, Color.Black);
            }
            else if (rendererType == typeof(UniformBlockRenderer))
            {
                RendererBase renderer = UniformBlockRenderer.Create();
                string tip = GetDefaultTip();
                result = new RendererTransporter(renderer, tip, Color.Black);
            }
            else if (rendererType == typeof(WaterRenderer))
            {
                RendererBase renderer = WaterRenderer.Create(waterPlaneLength: 4);
                string tip = GetDefaultTip();
                result = new RendererTransporter(renderer, tip, Color.Black);
            }
            else if (rendererType == typeof(ZeroAttributeRenderer))
            {
                RendererBase renderer = ZeroAttributeRenderer.Create();
                string tip = GetDefaultTip();
                result = new RendererTransporter(renderer, tip, Color.Black);
            }

            return result;
        }

        private static string GetDefaultTip()
        {
            var builder = new StringBuilder();
            builder.AppendLine("1: Scene's property grid.");
            builder.AppendLine("2: Canvas' property grid.");

            return builder.ToString();
        }
    }
}