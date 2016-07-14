using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridViewer
{
    public class WorldRenderer : Renderer
    {
        public WorldRenderer(CatesianGrid catesianGrid, ShaderCode[] shaderCodes,
            PropertyNameMap propertyNameMap, params GLSwitch[] switches)
            : base(catesianGrid, shaderCodes, propertyNameMap, switches)
        {
        }

        protected UpdatingRecord worldPositionRecord = new UpdatingRecord();
        private vec3 worldPosition;
        public vec3 WorldPosition
        {
            get { return worldPosition; }
            set
            {
                //worldPositionRecord.Set(ref worldPosition, value);
                if (worldPosition != value)
                {
                    worldPosition = value;
                    worldPositionRecord.Mark();
                }
            }
        }
    }
}
