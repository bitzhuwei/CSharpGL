using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Demos
{
    partial class SimplexNoiseRenderer
    {
        static readonly IBufferable staticBufferable = new Sphere();
        static readonly ShaderCode[] staticShaderCodes = new ShaderCode[]
        {
            new ShaderCode(File.ReadAllText(@"13SimplexNoise\SimplexNoise.vert"), ShaderType.VertexShader),
            new ShaderCode(File.ReadAllText(@"13SimplexNoise\SimplexNoise.frag"), ShaderType.FragmentShader),
        };
        static readonly PropertyNameMap staticPropertyNameMap = new PropertyNameMap(
            new string[] { "in_Position", "in_Color", },
            new string[] { Sphere.strPosition, Sphere.strColor });

        static readonly int[] perm = new int[256] {151,160,137,91,90,15,
  131,13,201,95,96,53,194,233,7,225,140,36,103,30,69,142,8,99,37,240,21,10,23,
  190, 6,148,247,120,234,75,0,26,197,62,94,252,219,203,117,35,11,32,57,177,33,
  88,237,149,56,87,174,20,125,136,171,168, 68,175,74,165,71,134,139,48,27,166,
  77,146,158,231,83,111,229,122,60,211,133,230,220,105,92,41,55,46,245,40,244,
  102,143,54, 65,25,63,161, 1,216,80,73,209,76,132,187,208, 89,18,169,200,196,
  135,130,116,188,159,86,164,100,109,198,173,186, 3,64,52,217,226,250,124,123,
  5,202,38,147,118,126,255,82,85,212,207,206,59,227,47,16,58,17,182,189,28,42,
  223,183,170,213,119,248,152, 2,44,154,163, 70,221,153,101,155,167, 43,172,9,
  129,22,39,253, 19,98,108,110,79,113,224,232,178,185, 112,104,218,246,97,228,
  251,34,242,193,238,210,144,12,191,179,162,241, 81,51,145,235,249,14,239,107,
  49,192,214, 31,181,199,106,157,184, 84,204,176,115,121,50,45,127, 4,150,254,
  138,236,205,93,222,114,67,29,24,72,243,141,128,195,78,66,215,61,156,180};

        /* These are Ken Perlin's proposed gradients for 3D noise. I kept them for
       better consistency with the reference implementation, but there is really
       no need to pad this to 16 gradients for this particular implementation.
       If only the "proper" first 12 gradients are used, they can be extracted
       from the grad4[][] array: grad3[i][j] == grad4[i*2][j], 0<=i<=11, j=0,1,2
    */
        static readonly int[][] grad3 = new int[16][]
        {
            new int[3]{0,1,1},new int[3]{0,1,-1},new int[3]{0,-1,1},new int[3]{0,-1,-1},
            new int[3]{1,0,1},new int[3]{1,0,-1},new int[3]{-1,0,1},new int[3]{-1,0,-1},
            new int[3]{1,1,0},new int[3]{1,-1,0},new int[3]{-1,1,0},new int[3]{-1,-1,0}, // 12 cube edges
            new int[3]{1,0,-1},new int[3]{-1,0,-1},new int[3]{0,-1,1},new int[3]{0,1,1},
        }; // 4 more to make 16

        /* These are my own proposed gradients for 4D noise. They are the coordinates
           of the midpoints of each of the 32 edges of a tesseract, just like the 3D
           noise gradients are the midpoints of the 12 edges of a cube.
        */
        static readonly int[][] grad4 = new int[32][]
        {
            new int[4]{0,1,1,1}, new int[4]{0,1,1,-1}, new int[4]{0,1,-1,1}, new int[4]{0,1,-1,-1}, // 32 tesseract edges
            new int[4]{0,-1,1,1}, new int[4]{0,-1,1,-1}, new int[4]{0,-1,-1,1}, new int[4]{0,-1,-1,-1},
            new int[4]{1,0,1,1}, new int[4]{1,0,1,-1}, new int[4]{1,0,-1,1}, new int[4]{1,0,-1,-1},
            new int[4]{-1,0,1,1}, new int[4]{-1,0,1,-1}, new int[4]{-1,0,-1,1}, new int[4]{-1,0,-1,-1},
            new int[4]{1,1,0,1}, new int[4]{1,1,0,-1}, new int[4]{1,-1,0,1}, new int[4]{1,-1,0,-1},
            new int[4]{-1,1,0,1}, new int[4]{-1,1,0,-1}, new int[4]{-1,-1,0,1}, new int[4]{-1,-1,0,-1},
            new int[4]{1,1,1,0}, new int[4]{1,1,-1,0}, new int[4]{1,-1,1,0}, new int[4]{1,-1,-1,0},
            new int[4]{-1,1,1,0}, new int[4]{-1,1,-1,0}, new int[4]{-1,-1,1,0}, new int[4]{-1,-1,-1,0}
        };

        static readonly byte[][] simplex4 = new byte[][]
        {
            new byte[]{0,64,128,192},new byte[]{0,64,192,128},new byte[]{0,0,0,0},
            new byte[]{0,128,192,64},new byte[]{0,0,0,0},new byte[]{0,0,0,0},new byte[]{0,0,0,0},new byte[]{64,128,192,0},
  new byte[]{0,128,64,192},new byte[]{0,0,0,0},new byte[]{0,192,64,128},new byte[]{0,192,128,64},
  new byte[]{0,0,0,0},new byte[]{0,0,0,0},new byte[]{0,0,0,0},new byte[]{64,192,128,0},
  new byte[]{0,0,0,0},new byte[]{0,0,0,0},new byte[]{0,0,0,0},new byte[]{0,0,0,0},
  new byte[]{0,0,0,0},new byte[]{0,0,0,0},new byte[]{0,0,0,0},new byte[]{0,0,0,0},
  new byte[]{64,128,0,192},new byte[]{0,0,0,0},new byte[]{64,192,0,128},new byte[]{0,0,0,0},
  new byte[]{0,0,0,0},new byte[]{0,0,0,0},new byte[]{128,192,0,64},new byte[]{128,192,64,0},
  new byte[]{64,0,128,192},new byte[]{64,0,192,128},new byte[]{0,0,0,0},new byte[]{0,0,0,0},
  new byte[]{0,0,0,0},new byte[]{128,0,192,64},new byte[]{0,0,0,0},new byte[]{128,64,192,0},
  new byte[]{0,0,0,0},new byte[]{0,0,0,0},new byte[]{0,0,0,0},new byte[]{0,0,0,0},
  new byte[]{0,0,0,0},new byte[]{0,0,0,0},new byte[]{0,0,0,0},new byte[]{0,0,0,0},
  new byte[]{128,0,64,192},new byte[]{0,0,0,0},new byte[]{0,0,0,0},new byte[]{0,0,0,0},
  new byte[]{192,0,64,128},new byte[]{192,0,128,64},new byte[]{0,0,0,0},new byte[]{192,64,128,0},
  new byte[]{128,64,0,192},new byte[]{0,0,0,0},new byte[]{0,0,0,0},new byte[]{0,0,0,0},
  new byte[]{192,64,0,128},new byte[]{0,0,0,0},new byte[]{192,128,0,64},new byte[]{192,128,64,0}};

        void initPermTexture(uint[] texID)
        {
            OpenGL.GenTextures(1, texID);
            // Bind the texture to texture unit 0
            OpenGL.BindTexture(OpenGL.GL_TEXTURE_2D, texID[0]);
            OpenGL.TexParameteri(OpenGL.GL_TEXTURE_2D, OpenGL.GL_TEXTURE_MIN_FILTER, (int)OpenGL.GL_NEAREST);
            OpenGL.TexParameteri(OpenGL.GL_TEXTURE_2D, OpenGL.GL_TEXTURE_MAG_FILTER, (int)OpenGL.GL_NEAREST);

            var pixels = new UnmanagedArray<byte>(256 * 256 * 4);
            unsafe
            {
                var array = (byte*)pixels.Header.ToPointer();
                for (int i = 0; i < 256; i++)
                    for (int j = 0; j < 256; j++)
                    {

                        int offset = (i * 256 + j) * 4;
                        byte value = (byte)(perm[(j + perm[i]) & 0xFF]);
                        array[offset] = (byte)(grad3[value & 0x0F][0] * 64 + 64);   // Gradient x
                        array[offset + 1] = (byte)(grad3[value & 0x0F][1] * 64 + 64); // Gradient y
                        array[offset + 2] = (byte)(grad3[value & 0x0F][2] * 64 + 64); // Gradient z
                        array[offset + 3] = value;                     // Permuted index
                    }
            }

            // GLFW texture loading functions won't work here - we need GL_NEAREST lookup.
            OpenGL.TexImage2D(OpenGL.GL_TEXTURE_2D, 0, OpenGL.GL_RGBA,
                256, 256, 0, OpenGL.GL_RGBA, OpenGL.GL_UNSIGNED_BYTE, pixels.Header);
            OpenGL.BindTexture(OpenGL.GL_TEXTURE_2D, 0);
            pixels.Dispose();
        }
    }
}
