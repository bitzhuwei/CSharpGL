using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.FileParser._3DSParser
{
    public enum ThreeDSChunkType : ushort
    {
        MainChunk = 0x4D4D,
        /// <summary>
        /// this is the start of the editor config
        /// </summary>
        _3DEditorChunk = 0x3D3D,
        CVersion = 0x0002,
        /// <summary>
        /// this is the start of the keyframer config
        /// </summary>
        KeyFramerChunk = 0xB000,//todo
        /// <summary>
        /// sub defines of _3DEditorChunk
        /// </summary>
        EditorMaterial = 0xAFFF,

        MaterialName = 0xA000,
        AmbientColor = 0xA010,
        DiffuseColor = 0xA020,
        SpecularColor = 0xA030,
        C_MATSHININESS = 0xA040,
        TextureMap = 0xA200,
        MappingFilename = 0xA300,
        ObjectBlock = 0x4000,
        TriangularMesh = 0x4100,
        VerticesList = 0x4110,
        FacesDescription = 0x4120,
        FacesMaterial = 0x4130,
        /// <summary>
        /// UV
        /// </summary>
        MappingCoordinatesList = 0x4140,


    }
}
