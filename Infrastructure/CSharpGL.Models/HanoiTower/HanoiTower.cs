using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    public class HanoiTower
    {

        public static ObjItem[] GetDataSource()
        {
            var list = new List<ObjItem>();
            {
                var prismoid = new PrismoidModel(6.5f, 6.5f, 7, 7, 0.5f);
                list.Add(new ObjItem(prismoid, new vec3(0, 0.5f, 0), new vec3(0.7f, 0.7f, 0.7f)));
            }
            {
                float radius = 2;
                list.Add(new ObjItem(new CylinderModel(0.25f, 6, 30),
                    new vec3(
                        (float)(Math.Cos(0) * radius),
                        3.5f,
                        (float)(Math.Cos(0) * radius)),
                    new vec3(1, 0, 0)));
                list.Add(new ObjItem(new CylinderModel(0.25f, 6, 30),
                    new vec3(
                        (float)(Math.Cos(Math.PI * 2 / 3.0) * radius),
                        3.5f,
                        (float)(Math.Cos(Math.PI * 2 / 3.0) * radius)),
                    new vec3(0, 1, 0)));
                list.Add(new ObjItem(new CylinderModel(0.25f, 6, 30),
                    new vec3(
                        (float)(Math.Cos(Math.PI * 2 * 2.0 / 3.0) * radius),
                        3.5f,
                        (float)(Math.Cos(Math.PI * 2 * 2.0 / 3.0) * radius)),
                    new vec3(0, 0, 1)));
            }
            {

            }

            return list.ToArray();
        }

    }

    public class ObjItem
    {
        public readonly IObjFormat model;
        public readonly vec3 position;
        public readonly vec3 color;

        public ObjItem(IObjFormat model, vec3 position, vec3 color)
        {
            this.model = model;
            this.position = position;
            this.color = color;
        }
    }
}
