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
    internal unsafe partial class aiSceneLegacy_ : demoCode {

        static GLfloat[] LightAmbient = { 0.5f, 0.5f, 0.5f, 1.0f };
        static GLfloat[] LightDiffuse = { 1.0f, 1.0f, 1.0f, 1.0f };
        static GLfloat[] LightPosition = { 0.0f, 0.0f, 15.0f, 1.0f };
        // the global Assimp scene object
        Import3D.aiScene g_scene;
        GLuint scene_list = 0;
        Import3D.vec3 scene_min, scene_max, scene_center;
        Dictionary<string, uint> textureIdMap = new();// map image filenames to textureId
        GLuint[] textureIds;                         // pointer to texture Array
        static string modelpath = "media/obj-spider/spider.obj.txt";
        GLfloat xrot;
        GLfloat yrot;
        GLfloat zrot;

        public aiSceneLegacy_(FormInstance mainForm, WindowsGLCanvas canvas) : base(mainForm, canvas) { }

        public override void display(GL gl) {
            gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT); // Clear The Screen And The Depth Buffer

            gl.glLoadIdentity();               // Reset MV Matrix

            gl.glTranslatef(0.0f, -10.0f, -40.0f); // Move 40 Units And Into The Screen
            gl.glRotatef(xrot, 1.0f, 0.0f, 0.0f);
            gl.glRotatef(yrot, 0.0f, 1.0f, 0.0f);
            gl.glRotatef(zrot, 0.0f, 0.0f, 1.0f);

            recursive_render(gl, g_scene, g_scene.mRootNode, 0.5f);

            yrot += 0.2f;

        }

        void apply_material(GL gl, aiMaterial material) {

            //float[] c = new float[4];

            GLenum fill_mode;
            aiReturn ret1, ret2;
            Import3D.vec4 diffuse;/*aiColor4D*/
            Import3D.vec4 specular;/*aiColor4D*/
            Import3D.vec4 ambient;/*aiColor4D*/
            Import3D.vec4 emission;/*aiColor4D*/
            float shininess, strength;
            int two_sided;
            int wireframe;
            int max;   // changed: to unsigned

            int texIndex = 0;
            string texPath;   //contains filename of texture

            if (aiReturn.aiReturn_SUCCESS == material.GetTexture((int)aiTextureType.aiTextureType_DIFFUSE, texIndex, out texPath)) {
                //bind texture
                uint texId = textureIdMap[texPath];
                gl.glBindTexture(GL.GL_TEXTURE_2D, texId);
            }

            if (aiReturn.aiReturn_SUCCESS != material.aiGetMaterialColor("$clr.diffuse", 0, 0, &diffuse)) {
                diffuse = new Import3D.vec4(0.8f, 0.8f, 0.8f, 1.0f);
            }
            gl.glMaterialfv(GL.GL_FRONT_AND_BACK, GL.GL_DIFFUSE, (float*)(&diffuse));

            if (aiReturn.aiReturn_SUCCESS != material.aiGetMaterialColor("$clr.specular", 0, 0, &specular)) {
                specular = new Import3D.vec4(0.0f, 0.0f, 0.0f, 1.0f);
            }
            gl.glMaterialfv(GL.GL_FRONT_AND_BACK, GL.GL_SPECULAR, (float*)(&specular));

            if (aiReturn.aiReturn_SUCCESS != material.aiGetMaterialColor("$clr.ambient", 0, 0, &ambient)) {
                ambient = new Import3D.vec4(0.2f, 0.2f, 0.2f, 1.0f);
            }
            gl.glMaterialfv(GL.GL_FRONT_AND_BACK, GL.GL_AMBIENT, (float*)(&ambient));

            if (aiReturn.aiReturn_SUCCESS != material.aiGetMaterialColor(/*AI_MATKEY_COLOR_EMISSIVE*/"$clr.emissive", 0, 0, &emission)) {
                emission = new Import3D.vec4(0.0f, 0.0f, 0.0f, 1.0f);
            }
            gl.glMaterialfv(GL.GL_FRONT_AND_BACK, GL.GL_EMISSION, (float*)(&emission));

            max = 1;
            ret1 = material.aiGetMaterialFloatArray(/*AI_MATKEY_SHININESS*/"$mat.shininess", 0, 0, &shininess, &max);
            max = 1;
            ret2 = material.aiGetMaterialFloatArray(/*AI_MATKEY_SHININESS_STRENGTH*/"$mat.shinpercent", 0, 0, &strength, &max);
            if ((ret1 == aiReturn.aiReturn_SUCCESS) && (ret2 == aiReturn.aiReturn_SUCCESS))
                gl.glMaterialf(GL.GL_FRONT_AND_BACK, GL.GL_SHININESS, shininess * strength);
            else {
                gl.glMaterialf(GL.GL_FRONT_AND_BACK, GL.GL_SHININESS, 0.0f);
                //set_float4(c, 0.0f, 0.0f, 0.0f, 0.0f);
                var zero = new Import3D.vec4(0);
                gl.glMaterialfv(GL.GL_FRONT_AND_BACK, GL.GL_SPECULAR, (float*)(&zero));
            }

            max = 1;
            if (aiReturn.aiReturn_SUCCESS == material.aiGetMaterialIntegerArray(/*AI_MATKEY_ENABLE_WIREFRAME*/"$mat.wireframe", 0, 0, &wireframe, &max))
                fill_mode = wireframe != 0 ? GL.GL_LINE : GL.GL_FILL;
            else
                fill_mode = GL.GL_FILL;
            gl.glPolygonMode(GL.GL_FRONT_AND_BACK, fill_mode);

            max = 1;
            if ((aiReturn.aiReturn_SUCCESS == material.aiGetMaterialIntegerArray(/*AI_MATKEY_TWOSIDED*/"$mat.twosided", 0, 0, &two_sided, &max)) && two_sided != 0)
                gl.glEnable(GL.GL_CULL_FACE);
            else
                gl.glDisable(GL.GL_CULL_FACE);
        }


        void recursive_render(GL gl, aiScene scene, aiNode node, float scale) {
            int i;
            int n = 0, t;
            Import3D.mat4 m = node.mTransformation;
            CSharpGL.mat4* appear = (CSharpGL.mat4*)&m;

            CSharpGL.mat4 m2 = new CSharpGL.mat4(scale);
            *appear = *appear * m2;

            // update transform
            //m.Transpose();
            gl.glPushMatrix();
            gl.glMultMatrixf(m.values);

            // draw all meshes assigned to this node
            for (; n < node.mNumMeshes; ++n) {
                aiMesh mesh = scene.mMeshes[node.mMeshes[n]];

                apply_material(gl, scene.mMaterials[mesh.mMaterialIndex]);

                if (mesh.mNormals == null) {
                    gl.glDisable(GL.GL_LIGHTING);
                }
                else {
                    gl.glEnable(GL.GL_LIGHTING);
                }

                if (mesh.mColors[0] != null) {
                    gl.glEnable(GL.GL_COLOR_MATERIAL);
                }
                else {
                    gl.glDisable(GL.GL_COLOR_MATERIAL);
                }

                for (t = 0; t < mesh.mNumFaces; ++t) {
                    aiFace face = mesh.mFaces[t];
                    GLenum face_mode;

                    switch (face.mNumIndices) {
                    case 1: face_mode = GL.GL_POINTS; break;
                    case 2: face_mode = GL.GL_LINES; break;
                    case 3: face_mode = GL.GL_TRIANGLES; break;
                    default: face_mode = GL.GL_POLYGON; break;
                    }

                    gl.glBegin(face_mode);

                    for (i = 0; i < face.mNumIndices; i++)     // go through all vertices in face
                    {
                        int vertexIndex = face.mIndices[i];    // get group index for current index
                        if (mesh.mColors[0] != null) {
                            var color = mesh.mColors[0][vertexIndex];
                            gl.glColor4fv((float*)&color);
                        }
                        if (mesh.mNormals != null) {
                            if (mesh.HasTextureCoords(0))      //HasTextureCoords(texture_coordinates_set)
                            {
                                gl.glTexCoord2f(mesh.mTextureCoords[0][vertexIndex].x, 1 - mesh.mTextureCoords[0][vertexIndex].y); //mTextureCoords[channel][vertex]
                            }
                        }
                        {
                            var normal = mesh.mNormals[vertexIndex];
                            gl.glNormal3fv((float*)&normal);
                        }
                        {
                            var vertex = mesh.mVertices[vertexIndex];
                            gl.glVertex3fv((float*)&vertex);
                        }
                    }
                    gl.glEnd();
                }
            }

            // draw all children
            for (n = 0; n < node.mNumChildren; ++n) {
                recursive_render(gl, scene, node.mChildren[n], scale);
            }

            gl.glPopMatrix();
        }

    }
}
