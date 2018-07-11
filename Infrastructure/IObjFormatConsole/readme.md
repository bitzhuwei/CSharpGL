# `IObjFormat` and obj files.
`IObjFormat` -> *.obj(v+f) -> `ObjVNF` -> *.obj(v+vn+f).
```
void Main()
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
```
