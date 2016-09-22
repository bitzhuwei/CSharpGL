using System;
using System.IO;
namespace CSharpGL.Demos
{
    // this demo failed to work.
    // translated from (https://github.com/McNopper/OpenGL/blob/db83062dc673750dd1720c5d581aa3c89460a94b/GLUS/src/glus_matrix.c)
    /// <summary>
    /// Raycast Volume Rendering Demo.
    /// </summary>
    //[DemoRenderer]
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

        public static RayTracingRenderer Create()
        {
            var shaderCodes = new ShaderCode[2];
            shaderCodes[0] = new ShaderCode(File.ReadAllText(@"shaders\RayTracingRenderer\fullscreen.vert.glsl"), ShaderType.VertexShader);
            shaderCodes[1] = new ShaderCode(File.ReadAllText(@"shaders\RayTracingRenderer\texture.frag.glsl"), ShaderType.FragmentShader);
            var map = new AttributeNameMap();
            IBufferable model = new ZeroAttributeModel(DrawMode.TriangleStrip, 0, 4);
            var renderer = new RayTracingRenderer(model, shaderCodes, map);

            return renderer;
        }

        internal struct Material
        {
            public vec4 emissiveColor;//= new float[4];
            public vec4 diffuseColor;//= new float[4];
            public vec4 specularColor;// = new float[4];
            public float shininess;
            public float alpha;
            public float reflectivity;
            public float padding;

            public Material(float[] emissiveColor, float[] diffuseColor, float[] specularColor,
                float shininess, float alpha, float reflectivity, float padding)
            {
                this.emissiveColor = new vec4(emissiveColor[0], emissiveColor[1], emissiveColor[2], emissiveColor[3]);
                this.diffuseColor = new vec4(diffuseColor[0], diffuseColor[1], diffuseColor[2], diffuseColor[3]);
                this.specularColor = new vec4(specularColor[0], specularColor[1], specularColor[2], specularColor[3]);
                this.shininess = shininess;
                this.alpha = alpha; this.reflectivity = reflectivity;
                this.padding = padding;
            }
        }

        internal struct Sphere
        {
            public vec4 center;//= new float[4];
            public float radius;
            public vec3 padding;//= new float[3];
            public Material material;

            public Sphere(float[] center, float radius, float[] padding, Material material)
            {
                this.center = new vec4(center[0], center[1], center[2], center[3]);
                this.radius = radius;
                this.padding = new vec3(padding[0], padding[1], padding[2]);
                this.material = material;
            }
        }

        internal struct PointLight
        {
            public vec4 position;//[4];

            public vec4 color;//[4];

            public PointLight(float[] position, float[] color)
            {
                this.position = new vec4(position[0], position[1], position[2], position[3]);
                this.color = new vec4(color[0], color[1], color[2], color[3]);
            }
        }

        private RayTracingRenderer(IBufferable model, ShaderCode[] shaderCodes,
            AttributeNameMap attributeNameMap, params GLSwitch[] switches)
            : base(model, shaderCodes, attributeNameMap, switches)
        {
        }
    }

    public static class FloatBufferHelper
    {
        public static bool glusRaytracePerspectivef(this float[] directionBuffer, byte padding, float fovy, int width, int height)
        {
            int i, k;

            float aspect;

            float yExtend;
            float xExtend;

            float xStep;
            float yStep;

            if (directionBuffer == null || width <= 0 || height <= 0)
            {
                return false;
            }

            aspect = (float)width / (float)height;

            yExtend = (float)Math.Tan((fovy * 0.5f) * Math.PI / 180.0f);
            xExtend = yExtend * aspect;

            xStep = xExtend / ((float)(width) * 0.5f);
            yStep = yExtend / ((float)(height) * 0.5f);

            for (i = 0; i < width * height; i++)
            {
                directionBuffer[i * (3 + padding) + 0] = -xExtend + xStep * 0.5f + xStep * (float)(i % width);
                directionBuffer[i * (3 + padding) + 1] = -yExtend + yStep * 0.5f + yStep * (float)(i / width);
                directionBuffer[i * (3 + padding) + 2] = -1.0f;

                for (k = 0; k < padding; k++)
                {
                    directionBuffer[i * (3 + padding) + 3 + k] = 0.0f;
                }

                float x = directionBuffer[i * (3 + padding) + 0];
                float y = directionBuffer[i * (3 + padding) + 1];
                float z = directionBuffer[i * (3 + padding) + 2];
                vec3 normalized = (new vec3(x, y, z)).normalize();
                directionBuffer[i * (3 + padding) + 0] = normalized.x;
                directionBuffer[i * (3 + padding) + 1] = normalized.y;
                directionBuffer[i * (3 + padding) + 2] = normalized.z;
            }

            return true;
        }

        public static unsafe void glusRaytraceLookAtf(this float[] positionBuffer, float[] directionBuffer, float[] originDirectionBuffer, byte padding, int width, int height, float eyeX, float eyeY, float eyeZ, float centerX, float centerY, float centerZ, float upX, float upY, float upZ)
        {
            //float forward[3], side[3], up[3];
            //float rotation[9];
            vec3 forward, side, up;
            float[] rotation;
            int i, k;

            forward = new vec3(centerX - eyeX, centerY - eyeY, centerZ - eyeZ);
            forward = forward.normalize();

            up = new vec3(upX, upY, upZ);

            side = forward.cross(up);
            side = side.normalize();

            up = side.cross(forward);

            mat3 matrix = new mat3(side, up, -forward);
            rotation = matrix.ToArray();

            for (i = 0; i < width * height; i++)
            {
                positionBuffer[i * 4 + 0] = eyeX;
                positionBuffer[i * 4 + 1] = eyeY;
                positionBuffer[i * 4 + 2] = eyeZ;
                positionBuffer[i * 4 + 3] = 1.0f;

                //glusMatrix3x3MultiplyVector3f(&directionBuffer[i * (3 + padding)], rotation, &originDirectionBuffer[i * (3 + padding)]);
                float[] result = new float[3];
                result[0] = directionBuffer[i * (3 + padding) + 0];
                result[1] = directionBuffer[i * (3 + padding) + 1];
                result[2] = directionBuffer[i * (3 + padding) + 2];
                float[] vector = new float[3];
                vector[0] = originDirectionBuffer[i * (3 + padding) + 0];
                vector[1] = originDirectionBuffer[i * (3 + padding) + 1];
                vector[2] = originDirectionBuffer[i * (3 + padding) + 2];
                glusMatrix3x3MultiplyVector3f(result, rotation, vector);
                directionBuffer[i * (3 + padding) + 0] = result[0];
                directionBuffer[i * (3 + padding) + 1] = result[1];
                directionBuffer[i * (3 + padding) + 2] = result[2];

                for (k = 0; k < padding; k++)
                {
                    directionBuffer[i * (3 + padding) + 3 + k] = originDirectionBuffer[i * (3 + padding) + 3 + k];
                }
            }
        }

        public static void glusMatrix3x3MultiplyVector3f(this float[] result, float[] matrix, float[] vector)
        {
            int i;

            float[] temp = new float[3];

            for (i = 0; i < 3; i++)
            {
                temp[i] = matrix[i] * vector[0] + matrix[3 + i] * vector[1] + matrix[6 + i] * vector[2];
            }

            for (i = 0; i < 3; i++)
            {
                result[i] = temp[i];
            }
        }

    }
}