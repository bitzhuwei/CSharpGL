using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.FileParser._3DSParser.Chunks
{
    public static class ChunkBaseHelper
    {

        private static readonly Dictionary<Type, ushort> chunkTypeDict = new Dictionary<Type, ushort>();
        private static readonly Dictionary<ushort, Type> chunkIDDict = new Dictionary<ushort, Type>();

        /// <summary>
        /// 开发者必须了解的东西。
        /// </summary>
        static ChunkBaseHelper()
        {
            chunkTypeDict.Add(typeof(MainChunk), 0x4D4D);
            {
                chunkTypeDict.Add(typeof(VersionChunk), 0x0002);
                chunkTypeDict.Add(typeof(_3DEditorChunk), 0x3D3D);
                {
                    chunkTypeDict.Add(typeof(ObjectBlockChunk), 0x4000);
                    {
                        chunkTypeDict.Add(typeof(TriangularMeshChunk), 0x4100);
                        {
                            chunkTypeDict.Add(typeof(VerticesListChunk), 0x4110);
                            chunkTypeDict.Add(typeof(FacesDescriptionChunk), 0x4120);
                            {
                                chunkTypeDict.Add(typeof(FacesMaterialChunk), 0x4130);
                                chunkTypeDict.Add(typeof(SmoothingGroupListChunk), 0x4150);
                            }
                            chunkTypeDict.Add(typeof(MappingCoordinatesListChunk), 0x4140);
                            chunkTypeDict.Add(typeof(LocalCoordinatesSystemChunk), 0x4160);
                        }
                        chunkTypeDict.Add(typeof(LightChunk), 0x4600);
                        {
                            chunkTypeDict.Add(typeof(SpotlightChunk), 0x4610);
                        }
                        chunkTypeDict.Add(typeof(CameraChunk), 0x4700);
                    }
                    chunkTypeDict.Add(typeof(EditorMaterialChunk), 0xAFFF);
                    {
                        chunkTypeDict.Add(typeof(MaterialNameChunk), 0xA000);
                        chunkTypeDict.Add(typeof(AmbientColorChunk), 0xA010);
                        chunkTypeDict.Add(typeof(DiffuseColorChunk), 0xA020);
                        chunkTypeDict.Add(typeof(SpecularColorChunk), 0xA030);
                        chunkTypeDict.Add(typeof(TextureMapChunk), 0xA200);
                        chunkTypeDict.Add(typeof(BumpMapChunk), 0xA230);
                        chunkTypeDict.Add(typeof(ReflectionMapChunk), 0xA220);
                        {
                            chunkTypeDict.Add(typeof(MappingFilenameChunk), 0xA300);
                            chunkTypeDict.Add(typeof(MappingParametersChunk), 0xA351);
                        }
                    }
                }
                chunkTypeDict.Add(typeof(KeyframeChunk), 0xB000);
                {
                    chunkTypeDict.Add(typeof(MeshInformationBlockChunk), 0xB002);
                    chunkTypeDict.Add(typeof(SpotLightInformationBlockChunk), 0xB007);
                    chunkTypeDict.Add(typeof(FramesChunk), 0xB008);
                    {
                        chunkTypeDict.Add(typeof(ObjectNameChunk), 0xB010);
                        chunkTypeDict.Add(typeof(ObjectPivotPointChunk), 0xB013);
                        chunkTypeDict.Add(typeof(PositionTrackChunk), 0xB020);
                        chunkTypeDict.Add(typeof(RotationTrackChunk), 0xB021);
                        chunkTypeDict.Add(typeof(ScaleTrackChunk), 0xB022);
                        chunkTypeDict.Add(typeof(HierarchyPositionChunk), 0xB030);
                    }
                }
            }

            chunkIDDict.Add(0x4D4D, typeof(MainChunk));
            {
                chunkIDDict.Add(0x0002, typeof(VersionChunk));
                chunkIDDict.Add(0x3D3D, typeof(_3DEditorChunk));
                {
                    chunkIDDict.Add(0x4000, typeof(ObjectBlockChunk));
                    {
                        chunkIDDict.Add(0x4100, typeof(TriangularMeshChunk));
                        {
                            chunkIDDict.Add(0x4110, typeof(VerticesListChunk));
                            chunkIDDict.Add(0x4120, typeof(FacesDescriptionChunk));
                            {
                                chunkIDDict.Add(0x4130, typeof(FacesMaterialChunk));
                                chunkIDDict.Add(0x4150, typeof(SmoothingGroupListChunk));
                            }
                            chunkIDDict.Add(0x4140, typeof(MappingCoordinatesListChunk));
                            chunkIDDict.Add(0x4160, typeof(LocalCoordinatesSystemChunk));
                        }
                        chunkIDDict.Add(0x4600, typeof(LightChunk));
                        {
                            chunkIDDict.Add(0x4610, typeof(SpotlightChunk));
                        }
                        chunkIDDict.Add(0x4700, typeof(CameraChunk));
                    }
                    chunkIDDict.Add(0xAFFF, typeof(EditorMaterialChunk));
                    {
                        chunkIDDict.Add(0xA000, typeof(MaterialNameChunk));
                        chunkIDDict.Add(0xA010, typeof(AmbientColorChunk));
                        chunkIDDict.Add(0xA020, typeof(DiffuseColorChunk));
                        chunkIDDict.Add(0xA030, typeof(SpecularColorChunk));
                        chunkIDDict.Add(0xA200, typeof(TextureMapChunk));
                        chunkIDDict.Add(0xA230, typeof(BumpMapChunk));
                        chunkIDDict.Add(0xA220, typeof(ReflectionMapChunk));
                        {
                            chunkIDDict.Add(0xA300, typeof(MappingFilenameChunk));
                            chunkIDDict.Add(0xA351, typeof(MappingParametersChunk));
                        }
                    }
                }
                chunkIDDict.Add(0xB000, typeof(KeyframeChunk));
                {
                    chunkIDDict.Add(0xB002, typeof(MeshInformationBlockChunk));
                    chunkIDDict.Add(0xB007, typeof(SpotLightInformationBlockChunk));
                    chunkIDDict.Add(0xB008, typeof(FramesChunk));
                    {
                        chunkIDDict.Add(0xB010, typeof(ObjectNameChunk));
                        chunkIDDict.Add(0xB013, typeof(ObjectPivotPointChunk));
                        chunkIDDict.Add(0xB020, typeof(PositionTrackChunk));
                        chunkIDDict.Add(0xB021, typeof(RotationTrackChunk));
                        chunkIDDict.Add(0xB022, typeof(ScaleTrackChunk));
                        chunkIDDict.Add(0xB030, typeof(HierarchyPositionChunk));
                    }
                }
            }

        }

        public static ushort GetID(this ChunkBase chunk)
        {
            Type type = chunk.GetType();
            ushort value;
            if (type == typeof(UndefinedChunk))
            {
                value = (chunk as UndefinedChunk).ID;
            }
            else
            {
                value = chunkTypeDict[type];//如果此处不存在此type的key，说明static构造函数需要添加此类型的字典信息。
            }

            return value;
        }

        public static ChunkBase ReadChunk(this BinaryReader reader)
        {
            // 2 byte ID
            ushort id = reader.ReadUInt16();
            // 4 byte length
            uint length = reader.ReadUInt32();
            // 2 + 4 = 6
            int bytesRead = 6;

            Type type;
            if (chunkIDDict.TryGetValue(id, out type))
            {
                object obj = Activator.CreateInstance(type);
                ChunkBase result = obj as ChunkBase;
                //result.ID = id;//不再需要记录ID，此对象的类型就指明了它的ID。
                result.Length = length;
                result.BytesRead = bytesRead;
                return result;
            }
            else
            {
                return new UndefinedChunk() { ID = id, Length = length, BytesRead = bytesRead, };
            }
        }

        //public static T ReadChunk<T>(this BinaryReader reader) where T : ChunkBase, new()
        //{
        //    // 2 byte ID
        //    var ID = reader.ReadUInt16();
        //    if (ID != chunkTypeDict[typeof(T)])
        //    { throw new Exception(string.Format("chunk type not match!")); }

        //    // 4 byte length
        //    var Length = reader.ReadUInt32();

        //    // 2 + 4 = 6
        //    var BytesRead = 6;

        //    T result = new T() { ID = ID, Length = Length, BytesRead = BytesRead, };

        //    return result;
        //}
    }
}
