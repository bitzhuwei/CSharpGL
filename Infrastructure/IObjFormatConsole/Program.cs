using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace IObjFormatConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            {
                Console.WriteLine("prismoid");
                var prismoid = new PrismoidModel(5, 5, 6, 6, 2);
                var filename = "prismoid.obj";
                prismoid.DumpObjFile(filename, "prismoid");
                var parser = new ObjVNFParser(false);
                ObjVNFResult result = parser.Parse(filename);
                if (result.Error != null)
                {
                    Console.WriteLine("Error: {0}", result.Error);
                }
                else
                {
                    ObjVNFMesh mesh = result.Mesh;
                    var model = new ObjVNF(mesh);
                    model.DumpObjFile("vnf" + filename, "prismoid");
                }
            }
            {
                Console.WriteLine("cylinder");
                var cylinder = new CylinderModel(0.25f, 6, 17);
                var filename = "cylinder.obj";
                cylinder.DumpObjFile(filename, "cylinder");
                var parser = new ObjVNFParser(false);
                ObjVNFResult result = parser.Parse(filename);
                if (result.Error != null)
                {
                    Console.WriteLine("Error: {0}", result.Error);
                }
                else
                {
                    ObjVNFMesh mesh = result.Mesh;
                    var model = new ObjVNF(mesh);
                    model.DumpObjFile("vnf" + filename, "cylinder");
                }
            }

            {
                Console.WriteLine("annulus");
                var annulus = new AnnulusModel(0.5f + 0.4f, 0.3f, 17, 17);
                var filename = "annulus.obj";
                annulus.DumpObjFile(filename, "annulus");
                var parser = new ObjVNFParser(false);
                ObjVNFResult result = parser.Parse(filename);
                if (result.Error != null)
                {
                    Console.WriteLine("Error: {0}", result.Error);
                }
                else
                {
                    ObjVNFMesh mesh = result.Mesh;
                    var model = new ObjVNF(mesh);
                    model.DumpObjFile("vnf" + filename, "annulus");
                }
            }

            {
                Console.WriteLine("disk");
                var disk = new DiskModel(0.5f + 0.4f, 0.3f, 0.3f, 17, 17);
                var filename = "disk.obj";
                disk.DumpObjFile(filename, "disk");
                var parser = new ObjVNFParser(false);
                ObjVNFResult result = parser.Parse(filename);
                if (result.Error != null)
                {
                    Console.WriteLine("Error: {0}", result.Error);
                }
                else
                {
                    ObjVNFMesh mesh = result.Mesh;
                    var model = new ObjVNF(mesh);
                    model.DumpObjFile("vnf" + filename, "disk");
                }
            }
            {
                Console.WriteLine("hanoiTower");
                var list = HanoiTower.GetDataSource();
                uint nextIndex = 0;
                var positionList = new List<vec3>();
                var indexList = new List<uint>();
                foreach (var item in list)
                {
                    vec3[] positions = item.model.GetPositions();
                    uint[] indexes = item.model.GetIndexes();
                    for (int i = 0; i < positions.Length; i++)
                    {
                        positionList.Add(positions[i] + item.position);
                    }
                    for (int i = 0; i < indexes.Length; i++)
                    {
                        indexList.Add(indexes[i] + nextIndex);
                    }

                    nextIndex += (uint)positions.Length;
                }
                var hanoiTower = new TmpModel(positionList.ToArray(), indexList.ToArray());
                hanoiTower.DumpObjFile("HanoiTower.obj", "HanoiTower");
                var filename = "HanoiTower.obj";
                hanoiTower.DumpObjFile(filename, "hanoiTower");
                var parser = new ObjVNFParser(false);
                ObjVNFResult result = parser.Parse(filename);
                if (result.Error != null)
                {
                    Console.WriteLine("Error: {0}", result.Error);
                }
                else
                {
                    ObjVNFMesh mesh = result.Mesh;
                    var model = new ObjVNF(mesh);
                    model.DumpObjFile("vnf" + filename, "hanoiTower");
                }
            }
            Console.WriteLine("done");
        }

        class TmpModel : IObjFormat
        {
            private vec3[] positions;
            private uint[] indexes;

            public TmpModel(vec3[] positions, uint[] indexes)
            {
                this.positions = positions;
                this.indexes = indexes;
            }

            #region IObjFormat 成员

            public vec3[] GetPositions()
            {
                return this.positions;
            }

            public uint[] GetIndexes()
            {
                return this.indexes;
            }

            #endregion
        }
    }
}
