using CSharpGL;
using SimLab.GridSource;
using System;
using System.Collections.Generic;

using TracyEnergy.Simba.Data.Keywords.impl;

namespace GridViewer
{
    public partial class CatesianGrid : GridViewModel
    {
        public CatesianGrid(CatesianGridderSource dataSource, List<GridBlockProperty> gridProps,
            float minColorCode, float maxColorCode, int defaultBlockPropertyIndex = 0)
            : base(dataSource, gridProps, minColorCode, maxColorCode, defaultBlockPropertyIndex)
        { }

        public override PropertyBufferPtr GetProperty(string bufferName, string varNameInShader)
        {
            if (bufferName == strPosition)
            {
                if (this.propertyBufferPtr == null)
                {
                    this.propertyBufferPtr = this.GetPositionBufferPtr(varNameInShader);
                }
                return this.propertyBufferPtr;
            }
            else if (bufferName == strColor)
            {
                if (this.colorBufferPtr == null)
                {
                    this.colorBufferPtr = this.GetColorBufferPtr(varNameInShader);
                }
                return this.colorBufferPtr;
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public override IndexBufferPtr GetIndex()
        {
            if (this.indexBufferPtr == null)
            {
                this.indexBufferPtr = this.GetIndexBufferPtr();
            }

            return this.indexBufferPtr;
        }
    }
}