using System;


namespace CSharpGL.FileParser._3DSParser
{
    public class ThreeDSMaterial
    {
        // Set Default values
        public float[] Ambient = new float[] { 0.5f, 0.5f, 0.5f };
        public float[] Diffuse = new float[] { 0.5f, 0.5f, 0.5f };
        public float[] Specular = new float[] { 0.5f, 0.5f, 0.5f };
        public int Shininess = 50;

        int textureid = -1;
        public int TextureId
        {
            get
            {
                return textureid;
            }
        }

        //public void BindTexture ( int width, int height, byte [,,] data )
        public void BindTexture(int width, int height, IntPtr data)
        {
            /*Gl.glEnable( Gl.GL_TEXTURE_2D );
			
            int[] textures = new int [1];
            Gl.glGenTextures(1, textures);
            textureid = textures[0];
            //Console.WriteLine ( "GL Texture number: {0}", textures [0] );
            Gl.glBindTexture( Gl.GL_TEXTURE_2D, textureid ); 

            // repeat texture if neccessary
            //Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_WRAP_S, Gl.GL_CLAMP); 
            //Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_WRAP_T, Gl.GL_CLAMP);
            //Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_WRAP_T, Gl.GL_REPEAT);
			
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MAG_FILTER, Gl.GL_LINEAR); 
            //Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MAG_FILTER, Gl.GL_NEAREST); 
            //Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MIN_FILTER, Gl.GL_NEAREST); 
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MIN_FILTER, Gl.GL_LINEAR_MIPMAP_NEAREST); 

            Gl.glTexEnvf(Gl.GL_TEXTURE_ENV, Gl.GL_TEXTURE_ENV_MODE, Gl.GL_REPLACE); 
			
            // Finally we define the 2d texture
            //Gl.glTexImage2D(Gl.GL_TEXTURE_2D, 0, Gl.GL_RGBA, width, height, 0, Gl.GL_RGBA, Gl.GL_UNSIGNED_BYTE, data);
            //Gl.glTexImage2D(Gl.GL_TEXTURE_2D, 0, Gl.GL_RGBA8, width, height, 0, Gl.GL_BGRA_EXT, Gl.GL_UNSIGNED_BYTE, data );
            Gl.glTexImage2D(Gl.GL_TEXTURE_2D, 0, Gl.GL_RGBA8, width, height, 0, Gl.GL_BGRA_EXT, Gl.GL_UNSIGNED_BYTE, data );
			
            // And create 2d mipmaps for the minifying function
            Glu.gluBuild2DMipmaps( Gl.GL_TEXTURE_2D, 4, width, height, Gl.GL_BGRA_EXT, Gl.GL_UNSIGNED_BYTE, data );

            Gl.glDisable( Gl.GL_TEXTURE_2D );
             * */

        }
    }
}
