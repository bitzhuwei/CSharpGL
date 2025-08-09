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

            if (aiReturn.aiReturn_SUCCESS != aiGetMaterialColor(material, /*AI_MATKEY_COLOR_DIFFUSE*/"$clr.diffuse", 0, 0, &diffuse)) {
                diffuse = new Import3D.vec4(0.8f, 0.8f, 0.8f, 1.0f);
            }
            gl.glMaterialfv(GL.GL_FRONT_AND_BACK, GL.GL_DIFFUSE, (float*)(&diffuse));

            if (aiReturn.aiReturn_SUCCESS != aiGetMaterialColor(material, /*AI_MATKEY_COLOR_SPECULAR*/"$clr.specular", 0, 0, &specular)) {
                specular = new Import3D.vec4(0.0f, 0.0f, 0.0f, 1.0f);
            }
            gl.glMaterialfv(GL.GL_FRONT_AND_BACK, GL.GL_SPECULAR, (float*)(&specular));

            if (aiReturn.aiReturn_SUCCESS != aiGetMaterialColor(material, /*AI_MATKEY_COLOR_AMBIENT*/"$clr.ambient", 0, 0, &ambient)) {
                ambient = new Import3D.vec4(0.2f, 0.2f, 0.2f, 1.0f);
            }
            gl.glMaterialfv(GL.GL_FRONT_AND_BACK, GL.GL_AMBIENT, (float*)(&ambient));

            if (aiReturn.aiReturn_SUCCESS != aiGetMaterialColor(material, /*AI_MATKEY_COLOR_EMISSIVE*/"$clr.emissive", 0, 0, &emission)) {
                emission = new Import3D.vec4(0.0f, 0.0f, 0.0f, 1.0f);
            }
            gl.glMaterialfv(GL.GL_FRONT_AND_BACK, GL.GL_EMISSION, (float*)(&emission));

            max = 1;
            ret1 = aiGetMaterialFloatArray(material, /*AI_MATKEY_SHININESS*/"$mat.shininess", 0, 0, &shininess, &max);
            max = 1;
            ret2 = aiGetMaterialFloatArray(material, /*AI_MATKEY_SHININESS_STRENGTH*/"$mat.shinpercent", 0, 0, &strength, &max);
            if ((ret1 == aiReturn.aiReturn_SUCCESS) && (ret2 == aiReturn.aiReturn_SUCCESS))
                gl.glMaterialf(GL.GL_FRONT_AND_BACK, GL.GL_SHININESS, shininess * strength);
            else {
                gl.glMaterialf(GL.GL_FRONT_AND_BACK, GL.GL_SHININESS, 0.0f);
                //set_float4(c, 0.0f, 0.0f, 0.0f, 0.0f);
                var zero = new Import3D.vec4(0);
                gl.glMaterialfv(GL.GL_FRONT_AND_BACK, GL.GL_SPECULAR, (float*)(&zero));
            }

            max = 1;
            if (aiReturn.aiReturn_SUCCESS == aiGetMaterialIntegerArray(material, /*AI_MATKEY_ENABLE_WIREFRAME*/"$mat.wireframe", 0, 0, &wireframe, &max))
                fill_mode = wireframe != 0 ? GL.GL_LINE : GL.GL_FILL;
            else
                fill_mode = GL.GL_FILL;
            gl.glPolygonMode(GL.GL_FRONT_AND_BACK, fill_mode);

            max = 1;
            if ((aiReturn.aiReturn_SUCCESS == aiGetMaterialIntegerArray(material, /*AI_MATKEY_TWOSIDED*/"$mat.twosided", 0, 0, &two_sided, &max)) && two_sided != 0)
                gl.glEnable(GL.GL_CULL_FACE);
            else
                gl.glDisable(GL.GL_CULL_FACE);
        }

        // Get an array if integers from the material
        private aiReturn aiGetMaterialIntegerArray(aiMaterial material, string pKey, int type, int index, int* pOut, int* pMax) {
            Debug.Assert(pOut != null);
            Debug.Assert(material != null);

            aiMaterialProperty? prop;
            aiGetMaterialProperty(material, pKey, type, index, out prop);
            if (prop == null) {
                return aiReturn.aiReturn_FAILURE;
            }

            // data is given in ints, simply copy it
            int iWrite = 0;
            if (aiPropertyTypeInfo.aiPTI_Integer == prop.mType || aiPropertyTypeInfo.aiPTI_Buffer == prop.mType) {
                iWrite = Math.Max((prop.mDataLength / sizeof(Int32)), 1);
                if (pMax != null) {
                    iWrite = Math.Min(*pMax, iWrite);
                }
                if (1 == prop.mDataLength) {
                    // bool type, 1 byte
                    *pOut = (int)*prop.mData;
                }
                else {
                    for (var a = 0; a < iWrite; ++a) {
                        pOut[a] = (int)(prop.mData)[a];
                    }
                }
                if (pMax != null) {
                    *pMax = iWrite;
                }
            }
            // data is given in floats convert to int
            else if (aiPropertyTypeInfo.aiPTI_Float == prop.mType) {
                iWrite = prop.mDataLength / sizeof(float);
                if (pMax != null) {
                    iWrite = Math.Min(*pMax, iWrite);
                    ;
                }
                for (var a = 0; a < iWrite; ++a) {
                    pOut[a] = (int)((prop.mData)[a]);
                }
                if (pMax != null) {
                    *pMax = iWrite;
                }
            }
            // it is a string ... no way to read something out of this
            else {
                if (pMax != null) {
                    iWrite = *pMax;
                }
                // strings are zero-terminated with a 32 bit length prefix, so this is safe
                var cur = prop.mData + 4;
                Debug.Assert(prop.mDataLength >= 5);
                Debug.Assert(prop.mData[prop.mDataLength - 1] == 0);
                for (var a = 0; ; ++a) {
                    pOut[a] = strtol10(cur, &cur);
                    if (a == iWrite - 1) {
                        break;
                    }
                    if (!(*cur == ' ' || *cur == '\t')) {
                        Import3D.Log.WriteLine("Material property key is a string; failed to parse an integer array out of it.");
                        return aiReturn.aiReturn_FAILURE;
                    }
                }

                if (pMax != null) {
                    *pMax = iWrite;
                }
            }
            return aiReturn.aiReturn_SUCCESS;

        }
        // ------------------------------------------------------------------------------------
        // signed variant of strtoul10
        // ------------------------------------------------------------------------------------
        static int strtol10(byte* inValue, byte** outValue = null) {
            bool inv = (*inValue == '-');
            if (inv || *inValue == '+') {
                ++inValue;
            }

            int value = (int)strtoul10(inValue, outValue);
            if (inv) {
                if (value < int.MaxValue && value > int.MinValue) {
                    value = -value;
                }
                else {
                    Import3D.Log.WriteLine("Converting the string inValue into an inverted value resulted in overflow.");
                }
            }
            return value;
        }
        // ------------------------------------------------------------------------------------
        // Convert a string in decimal format to a number
        // ------------------------------------------------------------------------------------
        static uint strtoul10(byte* inValue, byte** outValue = null) {
            uint value = 0;

            for (; ; ) {
                if (*inValue < '0' || *inValue > '9') {
                    break;
                }

                value = (uint)((value * 10) + (*inValue - '0'));
                ++inValue;
            }
            if (outValue != null) {
                *outValue = inValue;
            }
            return value;
        }

        private aiReturn aiGetMaterialColor(aiMaterial material, string key, int type, int index, Import3D.vec4* pOut) {
            int iMax = 4;
            aiReturn eRet = aiGetMaterialFloatArray(material, key, type, index, (float*)pOut, &iMax);

            // if no alpha channel is defined: set it to 1.0
            if (3 == iMax) {
                pOut->w = 1.0f;
            }

            return eRet;

        }

        private aiReturn aiGetMaterialFloatArray(aiMaterial material, string key, int type, int index, float* pOut, int* pMax) {
            Debug.Assert(material != null);
            Debug.Assert(pOut != null);

            aiMaterialProperty? prop;
            aiGetMaterialProperty(material, key, type, index, out prop);
            if (null == prop) {
                return aiReturn.aiReturn_FAILURE;
            }

            // data is given in floats, convert to ai_real
            int iWrite = 0;
            if (aiPropertyTypeInfo.aiPTI_Float == prop.mType || aiPropertyTypeInfo.aiPTI_Buffer == prop.mType) {
                iWrite = prop.mDataLength / sizeof(float);
                if (pMax != null) {
                    iWrite = Math.Min(*pMax, iWrite);
                    ;
                }

                for (var a = 0; a < iWrite; ++a) {
                    pOut[a] = (prop.mData)[a];
                }

                if (pMax != null) {
                    *pMax = iWrite;
                }
            }
            // data is given in doubles, convert to float
            else if (aiPropertyTypeInfo.aiPTI_Double == prop.mType) {
                iWrite = prop.mDataLength / sizeof(double);
                if (pMax != null) {
                    iWrite = Math.Min(*pMax, iWrite);
                    ;
                }
                for (var a = 0; a < iWrite; ++a) {
                    pOut[a] = (prop.mData)[a];
                }
                if (pMax != null) {
                    *pMax = iWrite;
                }
            }
            // data is given in ints, convert to float
            else if (aiPropertyTypeInfo.aiPTI_Integer == prop.mType) {
                iWrite = prop.mDataLength / sizeof(Int32);
                if (pMax != null) {
                    iWrite = Math.Min(*pMax, iWrite);
                    ;
                }
                for (var a = 0; a < iWrite; ++a) {
                    pOut[a] = (prop.mData)[a];
                }
                if (pMax != null) {
                    *pMax = iWrite;
                }
            }
            // a string ... read floats separated by spaces
            else {
                if (pMax != null) {
                    iWrite = *pMax;
                }
                // strings are zero-terminated with a 32 bit length prefix, so this is safe
                var cur = prop.mData + 4;
                Debug.Assert(prop.mDataLength >= 5);
                Debug.Assert(prop.mData[prop.mDataLength - 1] == 0);
                for (var a = 0; ; ++a) {
                    cur = fast_atoreal_move(cur, pOut[a]);
                    if (a == iWrite - 1) {
                        break;
                    }
                    if (!(*cur == ' ' || *cur == '\t')) {
                        Import3D.Log.WriteLine($"Material property {key} is a string; failed to parse a float array out of it.");
                        return aiReturn.aiReturn_FAILURE;
                    }
                }

                if (pMax != null) {
                    *pMax = iWrite;
                }
            }
            return aiReturn.aiReturn_SUCCESS;

        }

        private static byte* fast_atoreal_move(byte* cur, float outValue, bool check_comma = true) {
            float f = 0;

            bool inv = (*cur == '-');
            if (inv || *cur == '+') {
                ++cur;
            }

            if ((cur[0] == 'N' || cur[0] == 'n') && ASSIMP_strincmp(cur, "nan", 3) == 0) {
                outValue = float.NaN;
                cur += 3;
                return cur;
            }

            if ((cur[0] == 'I' || cur[0] == 'i') && ASSIMP_strincmp(cur, "inf", 3) == 0) {
                outValue = float.PositiveInfinity;// std::numeric_limits<float>::infinity();
                if (inv) {
                    outValue = -outValue;
                }
                cur += 3;
                if ((cur[0] == 'I' || cur[0] == 'i') && ASSIMP_strincmp(cur, "inity", 5) == 0) {
                    cur += 5;
                }
                return cur;
            }

            if (!(cur[0] >= '0' && cur[0] <= '9') &&
                    !((cur[0] == '.' || (check_comma && cur[0] == ',')) && cur[1] >= '0' && cur[1] <= '9')) {
                // The string is known to be bad, so don't risk printing the whole thing.
                throw new Exception($"Cannot parse string  as a real number: does not start with digit or decimal point followed by digit.");
            }

            if (*cur != '.' && (!check_comma || cur[0] != ',')) {
                f = strtoul10_64(cur, &cur);
            }

            if ((*cur == '.' || (check_comma && cur[0] == ',')) && cur[1] >= '0' && cur[1] <= '9') {
                ++cur;

                // NOTE: The original implementation is highly inaccurate here. The precision of a single
                // IEEE 754 float is not high enough, everything behind the 6th digit tends to be more
                // inaccurate than it would need to be. Casting to double seems to solve the problem.
                // strtol_64 is used to prevent integer overflow.

                // Another fix: this tends to become 0 for long numbers if we don't limit the maximum
                // number of digits to be read. AI_FAST_ATOF_RELAVANT_DECIMALS can be a value between
                // 1 and 15.
                int diff = /*AI_FAST_ATOF_RELAVANT_DECIMALS*/15;
                double pl = strtoul10_64(cur, &cur, &diff);

                pl *= fast_atof_table[diff];
                f += (float)pl;
            }
            // For backwards compatibility: eat trailing dots, but not trailing commas.
            else if (*cur == '.') {
                ++cur;
            }

            // A major 'E' must be allowed. Necessary for proper reading of some DXF files.
            // Thanks to Zhao Lei to point out that this if() must be outside the if (*c == '.' ..)
            if (*cur == 'e' || *cur == 'E') {
                ++cur;
                bool einv = (*cur == '-');
                if (einv || *cur == '+') {
                    ++cur;
                }

                // The reason float constants are used here is that we've seen cases where compilers
                // would perform such casts on compile-time constants at runtime, which would be
                // bad considering how frequently fast_atoreal_move<float> is called in Assimp.
                float exp = strtoul10_64(cur, &cur);
                if (einv) {
                    exp = -exp;
                }
                f *= (float)Math.Pow(10.0f, exp);
            }

            if (inv) {
                f = -f;
            }
            outValue = f;
            return cur;

        }
        // we write [16] here instead of [] to work around a swig bug
        static double[] fast_atof_table = new double[16] {
        0.0,
        0.1,
        0.01,
        0.001,
        0.0001,
        0.00001,
        0.000001,
        0.0000001,
        0.00000001,
        0.000000001,
        0.0000000001,
        0.00000000001,
        0.000000000001,
        0.0000000000001,
        0.00000000000001,
        0.000000000000001
        };

        // ------------------------------------------------------------------------------------
        // Special version of the function, providing higher accuracy and safety
        // It is mainly used by fast_atof to prevent ugly and unwanted integer overflows.
        // ------------------------------------------------------------------------------------
        static UInt64 strtoul10_64(byte* inValue, byte** outValue = null, int* max_inout = null) {
            int cur = 0;
            UInt64 value = 0;

            if (*inValue < '0' || *inValue > '9') {
                // The string is known to be bad, so don't risk printing the whole thing.
                throw new Exception("The string cannot be converted into a value.");
            }

            for (; ; ) {
                if (*inValue < '0' || *inValue > '9') {
                    break;
                }

                UInt64 new_value = (value * (UInt64)10) + ((UInt64)(*inValue - '0'));

                // numeric overflow, we rely on you
                if (new_value < value) {
                    Import3D.Log.WriteLine("Converting the string into a value resulted inValue overflow.");
                    return 0;
                }

                value = new_value;

                ++inValue;
                ++cur;

                if (max_inout != null && *max_inout == cur) {
                    if (outValue != null) { /* skip to end */
                        while (*inValue >= '0' && *inValue <= '9') {
                            ++inValue;
                        }
                        *outValue = inValue;
                    }

                    return value;
                }
            }
            if (outValue != null) {
                *outValue = inValue;
            }

            if (max_inout != null) {
                *max_inout = cur;
            }

            return value;

        }

        static int ASSIMP_strincmp(byte* s1, string s2, int n) {
            Debug.Assert(null != s1);
            Debug.Assert(null != s2);
            if (n == 0) {
                return 0;
            }

            char c1, c2; int c2Index = 0;
            int p = 0;
            do {
                if (p++ >= n) return 0;
                c1 = char.ToLower((char)*(s1++));
                c2 = char.ToLower(s2[c2Index++]);
            } while (c1 != 0 && (c1 == c2));

            return c1 - c2;
        }
        // -------------------------------------------------------------------------------
        /** @brief Helper function to do platform independent string comparison.
         *
         *  This is required since strincmp() is not consistently available on
         *  all platforms. Some platforms use the '_' prefix, others don't even
         *  have such a function.
         *
         *  @param s1 First input string
         *  @param s2 Second input string
         *  @param n Maximum number of characters to compare
         *  @return 0 if the given strings are identical
         */
        static int ASSIMP_strincmp(byte* s1, byte* s2, int n) {
            Debug.Assert(null != s1);
            Debug.Assert(null != s2);
            if (n == 0) {
                return 0;
            }

            char c1, c2;
            int p = 0;
            do {
                if (p++ >= n) return 0;
                c1 = char.ToLower((char)*(s1++));
                c2 = char.ToLower((char)*(s2++));
            } while (c1 != 0 && (c1 == c2));

            return c1 - c2;
        }

        // ------------------------------------------------------------------------------------------------
        // Get a specific property from a material
        static aiReturn aiGetMaterialProperty(aiMaterial pMat,
                string key,
                int type,
                int index,
                out aiMaterialProperty? pPropOut) {
            Debug.Assert(pMat != null);
            Debug.Assert(key != null);
            //Debug.Assert(pPropOut != null);

            /*  Just search for a property with exactly this name ..
             *  could be improved by hashing, but it's possibly
             *  no worth the effort (we're bound to C structures,
             *  thus std::map or derivates are not applicable. */
            for (var i = 0; i < pMat.mNumProperties; ++i) {
                var prop = pMat.mProperties[i];

                if (prop != null /* just for safety ... */
                 && prop.mKey.StartsWith(key)
                 && (int.MaxValue == type || prop.mSemantic == type) /* INT_MAX is a wild-card, but this is undocumented :-) */
                        && (int.MaxValue == index || prop.mIndex == index)) {
                    pPropOut = pMat.mProperties[i];
                    return aiReturn.aiReturn_SUCCESS;
                }
            }
            pPropOut = null;
            return aiReturn.aiReturn_FAILURE;
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
