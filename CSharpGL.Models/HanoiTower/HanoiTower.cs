using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL {
    public unsafe class HanoiTower {

        public static ObjItem[] GetDataSource() {
            var list = new List<ObjItem>();
            float floating = 4;
            {
                var prismoid = new PrismoidModel(32f, 32f, 35f, 35f, 1f);
                list.Add(new ObjItem(prismoid, new vec3(0, 0.5f + floating, 0), new vec3(0.7f, 0.7f, 0.7f)));
            }
            float radius = 10;
            {
                list.Add(new ObjItem(new CylinderModel(0.45f, 8, 30),
                    new vec3(
                        (float)(Math.Cos(0) * radius),
                        4 + 0.5f + floating,
                        (float)(Math.Sin(0) * radius)),
                    new vec3(1, 0, 0)));
                list.Add(new ObjItem(new CylinderModel(0.45f, 8, 30),
                    new vec3(
                        (float)(Math.Cos(Math.PI * 2 / 3.0) * radius),
                        4 + 0.5f + floating,
                        (float)(Math.Sin(Math.PI * 2 / 3.0) * radius)),
                    new vec3(0, 1, 0)));
                list.Add(new ObjItem(new CylinderModel(0.45f, 8, 30),
                    new vec3(
                        (float)(Math.Cos(Math.PI * 2 * 2.0 / 3.0) * radius),
                        4 + 0.5f + floating,
                        (float)(Math.Sin(Math.PI * 2 * 2.0 / 3.0) * radius)),
                    new vec3(0, 0, 1)));
            }
            {
                var random = new Random();
                for (int i = 0; i < 10; i++) {
                    list.Add(new ObjItem(new DiskModel(3f - i * 0.2f, 0.8f, 0.2f, 30, 15),
                        new vec3(
                            (float)(Math.Cos(0) * radius),
                            0.8f + i * 0.55f + 0.5f + floating,
                            (float)(Math.Sin(0) * radius)),
                        //new vec3(1, 1, 1)));
                        new vec3(
                            (float)random.NextDouble() / 2.0f + 0.5f,
                            (float)random.NextDouble() / 2.0f + 0.5f,
                            (float)random.NextDouble() / 2.0f + 0.5f)));
                }
            }

            return list.ToArray();
        }

    }

    public unsafe class ObjItem {
        public readonly IObjFormat model;
        public readonly vec3 position;
        public readonly vec3 color;

        public ObjItem(IObjFormat model, vec3 position, vec3 color) {
            this.model = model;
            this.position = position;
            this.color = color;
        }
    }
}
