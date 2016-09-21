using System.IO;
namespace CSharpGL.Demos
{
    /// <summary>
    /// Raycast Volume Rendering Demo.
    /// </summary>
    [DemoRenderer]
    partial class RayTracingRenderer : Renderer
    {
        private const int WIDTH = 640;
        private const int HEIGHT = 480;
        private const int DIRECTION_BUFFER_PADDING = 1;
        private const float PADDING_VALUE = -321.123f;

        /// <summary>
        /// Every ray can have two sub rays (reflect and refract). This can be organized as a tree, with  breadth-first indexing.So, a tree with a depth has 2^depth-1 nodes. In this case we have a MAX_DEPTH of 5
        /// </summary>
        private const int NUM_STACK_NODES = (2 * 2 * 2 * 2 * 2 - 1);

        /// <summary>
        /// As no recursion is possible in GLSL, the following is done:
        /// As the number of rays (= nodes) is known, all rays plus sub rays are executed. All needed values are stored in a stack node.
        /// After this is done, the tree is traversed again from the leaf node to the root. Now the color of node can be calculated by the using the sub nodes. Finally, in the root node the final color is stored.
        /// </summary>
        private const int STACK_NODE_FLOATS = (4 + (3 + 1) + 4 + 4 + (3 + 1) + 4 + 1 + 1 + 1 + 1);

        private const int NUM_SPHERES = 6;

        private const int NUM_LIGHTS = 1;

        private const uint g_localSize = 16;

        private static float[] g_directionBuffer = new float[WIDTH * HEIGHT * (3 + DIRECTION_BUFFER_PADDING)];

        private static float[] g_positionBuffer = new float[WIDTH * HEIGHT * 4];

        private static float[] g_stackBuffer = new float[WIDTH * HEIGHT * STACK_NODE_FLOATS * NUM_STACK_NODES];

        private Sphere[] g_sphereBuffer = new Sphere[NUM_SPHERES]
        {
		// Ground sphere
		new Sphere(new float[]{ 0.0f, -10001.0f, -20.0f, 1.0f }, 10000.0f,new float[] {PADDING_VALUE, PADDING_VALUE, PADDING_VALUE},new Material (new float[] { 0.0f, 0.0f, 0.0f, 1.0f }, new float[]{ 0.4f, 0.4f, 0.4f, 1.0f }, new float[]{ 0.0f, 0.0f, 0.0f, 1.0f }, 0.0f, 1.0f, 0.0f, PADDING_VALUE ) ),
		// Transparent sphere
		new Sphere(new float[] { 0.0f, 0.0f, -10.0f, 1.0f }, 1.0f, new float[]{PADDING_VALUE, PADDING_VALUE, PADDING_VALUE}, new Material (new float[]{ 0.0f, 0.0f, 0.0f, 1.0f }, new float[]{ 0.8f, 0.8f, 0.8f, 1.0f }, new float[]{ 0.8f, 0.8f, 0.8f, 1.0f }, 20.0f, 0.2f, 1.0f, PADDING_VALUE) ),
		// Reflective sphere
		new Sphere(new float[] { 1.0f, -0.75f, -7.0f, 1.0f }, 0.25f, new float[]{PADDING_VALUE, PADDING_VALUE, PADDING_VALUE},new Material (new float[]{ 0.0f, 0.0f, 0.0f, 1.0f }, new float[]{ 0.8f, 0.8f, 0.8f, 1.0f }, new float[]{ 0.8f, 0.8f, 0.8f, 1.0f }, 20.0f, 1.0f, 0.8f, PADDING_VALUE) ),
		// Blue sphere
		new Sphere(new float[] { 2.0f, 1.0f, -16.0f, 1.0f }, 2.0f,new float[] {PADDING_VALUE, PADDING_VALUE, PADDING_VALUE},new Material (new float[] { 0.0f, 0.0f, 0.0f, 1.0f }, new float[]{ 0.0f, 0.0f, 0.8f, 1.0f }, new float[]{ 0.8f, 0.8f, 0.8f, 1.0f }, 20.0f, 1.0f, 0.2f, PADDING_VALUE ) ),
		// Green sphere
		new Sphere(new float[] { -2.0f, 0.25f, -6.0f, 1.0f }, 1.25f, new float[]{PADDING_VALUE, PADDING_VALUE, PADDING_VALUE},new Material (new float[]{ 0.0f, 0.0f, 0.0f, 1.0f },new float[] { 0.0f, 0.8f, 0.0f, 1.0f }, new float[]{ 0.8f, 0.8f, 0.8f, 1.0f }, 20.0f, 1.0f, 0.2f, PADDING_VALUE ) ),
		// Red sphere
		new Sphere(new float[] { 3.0f, 0.0f, -8.0f, 1.0f }, 1.0f, new float[]{PADDING_VALUE, PADDING_VALUE, PADDING_VALUE}, new Material (new float[]{ 0.0f, 0.0f, 0.0f, 1.0f },new float[] { 0.8f, 0.0f, 0.0f, 1.0f }, new float[]{ 0.8f, 0.8f, 0.8f, 1.0f }, 20.0f, 1.0f, 0.2f, PADDING_VALUE ) ),
        };

        private PointLight[] g_lightBuffer = new PointLight[NUM_LIGHTS]
        {
		    new PointLight(new float[]{0.0f, 5.0f, -5.0f, 1.0f}, new float[]{ 1.0f, 1.0f, 1.0f, 1.0f }),
        };
        private RayTracingComputeRenderer computeRenderer;

        public static RayTracingRenderer Create()
        {
            var shaderCodes = new ShaderCode[2];
            shaderCodes[0] = new ShaderCode(File.ReadAllText(@"shaders\RayTracingRenderer\fullscreen.vert.glsl"), ShaderType.VertexShader);
            shaderCodes[1] = new ShaderCode(File.ReadAllText(@"shaders\RayTracingRenderer\texture.frag.glsl"), ShaderType.FragmentShader);
            var map = new AttributeNameMap();
            IBufferable model = null;
            var renderer = new RayTracingRenderer(model, shaderCodes, map);
            throw new System.NotImplementedException();
        }

        internal struct Material
        {
            public float[] emissiveColor;//= new float[4];
            public float[] diffuseColor;//= new float[4];
            public float[] specularColor;// = new float[4];
            public float shininess;
            public float alpha;
            public float reflectivity;
            public float padding;

            public Material(float[] emissiveColor, float[] diffuseColor, float[] specularColor,
                float shininess, float alpha, float reflectivity, float padding)
            {
                this.emissiveColor = emissiveColor; this.diffuseColor = diffuseColor;
                this.specularColor = specularColor; this.shininess = shininess;
                this.alpha = alpha; this.reflectivity = reflectivity;
                this.padding = padding;
            }
        }

        internal struct Sphere
        {
            public float[] center;//= new float[4];
            public float radius;
            public float[] padding;//= new float[3];
            public Material material;

            public Sphere(float[] center, float radius, float[] padding, Material material)
            {
                this.center = center;
                this.radius = radius;
                this.padding = padding;
                this.material = material;
            }
        }

        internal struct PointLight
        {
            public float[] position;//[4];

            public float[] color;//[4];

            public PointLight(float[] position, float[] color)
            {
                this.position = position;
                this.color = color;
            }
        }

        private RayTracingRenderer(IBufferable model, ShaderCode[] shaderCodes,
            AttributeNameMap attributeNameMap, params GLSwitch[] switches)
            : base(model, shaderCodes, attributeNameMap, switches)
        {
            this.computeRenderer = RayTracingComputeRenderer.Create();
        }
    }
}