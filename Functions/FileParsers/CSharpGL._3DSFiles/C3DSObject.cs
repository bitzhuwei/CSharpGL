using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CSharpGL._3DSFiles
{
    public class C3DSObject
    {
        public bool LoadModel(string filename)
        {
            if (!File.Exists(filename)) return false;


            throw new NotImplementedException();
        }
        // List of mesh objects if there are more than 1,
        // list of materials, and counters for each.
        List<stMesh> meshList;
        List<stMaterial> materialList;
        //std::vector<stMesh> meshList;
        //std::vector<stMaterial> materialList;
        int totalMeshes;
        int totalMaterials;

    }
    // File chunk header.
    class stChunk
    {
        short id;
        uint length;
        uint bytesRead;
    };

    // Vertex position.
    class stVertex
    {
        float x, y, z;
    };

    // Triangle.
    class stFace
    {
        uint[] indices = new uint[3];
        stVertex normal;
        int matId;
    };

    // Triangle as it is in the file.
    class stFileFace
    {
        ushort[] indices = new ushort[3];
        ushort vis;
    };

    // RGB color value.
    class stColor
    {
        byte r, g, b;
        //unsigned char r, g, b;
    };

    // Texture coordinate for a vertex pos.
    class stTexCoord
    {
        float tu, tv;
    };

    // Material of a face.
    class stMaterial
    {
        //stMaterial() { name[0] = '/0'; textureName[0] = '/0'; }
        String name;
        //char name[256];
        stColor color;
        String textureName;
        //char textureName[256];
    };

    // Mesh object.  A file can have more than 1.
    class stMesh
    {
        String name;
        //char name[256];

        stFace pFaces;
        stVertex pVertices;
        stTexCoord pTexCoords;

        uint totalFaces;
        uint totalVertices;
        uint totalTexCoords;
    };
}
