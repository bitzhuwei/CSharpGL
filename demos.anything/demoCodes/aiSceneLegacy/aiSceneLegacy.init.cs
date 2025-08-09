using Assimp.Unmanaged;
using Assimp;
using CSharpGL;
using demos.anything;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Import3D;
using System.Windows.Forms.Design;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.IO;
using System.Diagnostics;
using static System.Net.WebRequestMethods;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.ConstrainedExecution;
using System.Drawing.Design;
using System.Numerics;

namespace aiSceneLegacy {
    unsafe partial class aiSceneLegacy_ {

        public override void init(GL gl) {

            Import3DFromFile(modelpath);

            LoadGLTextures(gl, g_scene);

            gl.glEnable(GL.GL_TEXTURE_2D);
            gl.glShadeModel(GL.GL_SMOOTH);         // Enables Smooth Shading
            //gl.glClearColor(1.0f, 1.0f, 1.0f, 0.0f);
            gl.glClearDepth(1.0f);             // Depth Buffer Setup
            gl.glEnable(GL.GL_DEPTH_TEST);        // Enables Depth Testing
            gl.glDepthFunc(GL.GL_LEQUAL);         // The Type Of Depth Test To Do
            gl.glHint(GL.GL_PERSPECTIVE_CORRECTION_HINT, GL.GL_NICEST);  // Really Nice Perspective Calculation


            gl.glEnable(GL.GL_LIGHTING);
            gl.glEnable(GL.GL_LIGHT0);    // Uses default lighting parameters
            gl.glLightModeli(GL.GL_LIGHT_MODEL_TWO_SIDE, (int)GL.GL_TRUE);
            gl.glEnable(GL.GL_NORMALIZE);

            gl.glLightfv(GL.GL_LIGHT1, GL.GL_AMBIENT, LightAmbient);
            gl.glLightfv(GL.GL_LIGHT1, GL.GL_DIFFUSE, LightDiffuse);
            gl.glLightfv(GL.GL_LIGHT1, GL.GL_POSITION, LightPosition);
            gl.glEnable(GL.GL_LIGHT1);

        }

        private bool Import3DFromFile(string filename) {
            //g_scene = importer.ReadFile(filename, aiProcessPreset_TargetRealtime_Quality);
            var model = Import3D.Obj.ObjFileParser.Parse(filename, modelName: filename);
            var scene = new Import3D.aiScene(name: filename);
            Import3D.Obj.ObjSceneBuilder.BuildScene(model, scene);
            g_scene = scene;

            // We're done. Everything will be cleaned up by the importer destructor
            return true;
        }
        bool LoadGLTextures(GL gl, aiScene scene) {
            if (scene.HasTextures()) { return true; }

            /* getTexture Filenames and Numb of Textures */
            for (var m = 0; m < scene.mNumMaterials; m++) {
                int texIndex = 0;
                aiReturn texFound = aiReturn.aiReturn_SUCCESS;

                string path = "";  // filename

                while (texFound == aiReturn.aiReturn_SUCCESS) {
                    texFound = scene.mMaterials[m].GetTexture((int)aiTextureType.aiTextureType_DIFFUSE, texIndex, out path);
                    if (texFound == aiReturn.aiReturn_SUCCESS) {
                        //textureIdMap[path.data] = null; //fill map with textures, pointers still NULL yet
                        textureIdMap.Add(path, 0);
                        texIndex++;
                    }
                }
            }

            var numTextures = textureIdMap.Count;

            /* create and fill array with GL texture ids */
            textureIds = new GLuint[numTextures];
            fixed (GLuint* p = textureIds) {
                gl.glGenTextures(numTextures, p); /* Texture name generation */
            }

            var fileInfo = new FileInfo(modelpath);
            var basepath = fileInfo.DirectoryName; Debug.Assert(basepath != null);
            /* get iterator */
            var index = 0;
            foreach (var pair in textureIdMap) {
                var filename = pair.Key;
                textureIdMap[filename] = textureIds[index];

                var fileloc = Path.Combine(basepath, filename); /* Loading of image */
                int x, y, n;
                //byte* data = stbi_load(fileloc.c_str(), &x, &y, &n, STBI_rgb_alpha);
                var bitmap = new Bitmap(fileloc);
                var winGLBitmap = new WinGLBitmap(bitmap, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

                //if (null != data) {
                // Binding of texture name
                gl.glBindTexture(GL.GL_TEXTURE_2D, textureIds[index]);
                // redefine standard texture values
                // We will use linear interpolation for magnification filter
                gl.glTexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_MAG_FILTER, (int)GL.GL_LINEAR);
                // We will use linear interpolation for minifying filter
                gl.glTexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_MIN_FILTER, (int)GL.GL_LINEAR);
                // Texture specification
                gl.glTexImage2D(GL.GL_TEXTURE_2D, 0, (int)GL.GL_RGBA,
                    winGLBitmap.Width, winGLBitmap.Height,
                    0, GL.GL_RGBA, GL.GL_UNSIGNED_BYTE, winGLBitmap.Scan0);// Texture specification.

                // we also want to be able to deal with odd texture dimensions
                gl.glPixelStorei(GL.GL_UNPACK_ALIGNMENT, 1);
                gl.glPixelStorei(GL.GL_UNPACK_ROW_LENGTH, 0);
                gl.glPixelStorei(GL.GL_UNPACK_SKIP_PIXELS, 0);
                gl.glPixelStorei(GL.GL_UNPACK_SKIP_ROWS, 0);
                //stbi_image_free(data);
                winGLBitmap.Dispose();
                //}
                //else {
                //    /* Error occurred */
                //    //const std::string message = "Couldn't load Image: " + fileloc;
                //    //std::wstring targetMessage;
                //    //wchar_t* tmp = new wchar_t[message.size() + 1];
                //    //memset(tmp, L'\0', sizeof(wchar_t) * (message.size() + 1));
                //    //utf8::utf8to16(message.c_str(), message.c_str() + message.size(), tmp);
                //    //targetMessage = tmp;
                //    //delete[] tmp;
                //    //MessageBox(null, targetMessage.c_str(), TEXT("ERROR"), MB_OK | MB_ICONEXCLAMATION);
                //    MessageBox.Show("failed to load image.");
                //}
                index++;
            }

            return true;
        }
    }
}
