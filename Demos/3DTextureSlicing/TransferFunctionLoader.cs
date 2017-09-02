using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace _3DTextureSlicing
{
    class TransferFunctionLoader
    {
        //transfer function (lookup table) colour values
        private static readonly vec4[] jet_values = new vec4[9]{	
            new vec4(0,0,0.5f,0),
            new vec4(0,0,1f,0.1f),
            new vec4(0,0.5f,1,0.3f),
            new vec4(0,1,1,0.5f),
            new vec4(0.5f,1,0.5f,0.75f),
            new vec4(1,1,0,0.8f),
            new vec4(1,0.5f,0,0.6f),
            new vec4(1,0,0,0.5f),
            new vec4(0.5f,0,0,0)
        };

        public static Texture Load()
        {

            //function to generate interpolated colours from the set of colour values (jet_values)
            //this function first calculates the amount of increments for each component and the
            //index difference. Then it linearly interpolates the adjacent values to get the 
            //interpolated result.
            vec4[] pData = new vec4[256];

            int[] indices = new int[9];

            //fill the colour values at the place where the colour should be after interpolation
            for (int i = 0; i < 9; i++)
            {
                int index = i * 28;
                pData[index][0] = jet_values[i].x;
                pData[index][1] = jet_values[i].y;
                pData[index][2] = jet_values[i].z;
                pData[index][3] = jet_values[i].w;
                indices[i] = index;
            }

            //for each adjacent pair of colours, find the difference in the rgba values and then interpolate
            for (int j = 0; j < 9 - 1; j++)
            {
                float dDataR = (pData[indices[j + 1]][0] - pData[indices[j]][0]);
                float dDataG = (pData[indices[j + 1]][1] - pData[indices[j]][1]);
                float dDataB = (pData[indices[j + 1]][2] - pData[indices[j]][2]);
                float dDataA = (pData[indices[j + 1]][3] - pData[indices[j]][3]);
                int dIndex = indices[j + 1] - indices[j];

                float dDataIncR = dDataR / (float)(dIndex);
                float dDataIncG = dDataG / (float)(dIndex);
                float dDataIncB = dDataB / (float)(dIndex);
                float dDataIncA = dDataA / (float)(dIndex);
                for (int i = indices[j] + 1; i < indices[j + 1]; i++)
                {
                    pData[i][0] = (pData[i - 1][0] + dDataIncR);
                    pData[i][1] = (pData[i - 1][1] + dDataIncG);
                    pData[i][2] = (pData[i - 1][2] + dDataIncB);
                    pData[i][3] = (pData[i - 1][3] + dDataIncA);
                }
            }

            var storage = new TexImage1D(0, GL.GL_RGBA, 256, 0, GL.GL_RGBA, GL.GL_FLOAT, new ArrayDataProvider<vec4>(pData));
            var texture = new Texture(TextureTarget.Texture1D, storage,
                new TexParameteri(TexParameter.PropertyName.TextureWrapS, (int)GL.GL_REPEAT),
                new TexParameteri(TexParameter.PropertyName.TextureMinFilter, (int)GL.GL_LINEAR),
                new TexParameteri(TexParameter.PropertyName.TextureMagFilter, (int)GL.GL_LINEAR));

            texture.Initialize();

            return texture;
        }
    }
}
