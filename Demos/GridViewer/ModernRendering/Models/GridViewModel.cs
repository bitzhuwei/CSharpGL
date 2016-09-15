using CSharpGL;
using SimLab.GridSource;
using System.Collections.Generic;

using TracyEnergy.Simba.Data.Keywords.impl;

namespace GridViewer
{
    /// <summary>
    /// base model for gridview.
    /// </summary>
    public abstract class GridViewModel : IBufferable, IUpdateColorPalette
    {
        protected int defaultBlockPropertyIndex;

        /// <summary>
        /// assign different colors to this model.
        /// </summary>
        public List<GridBlockProperty> GridBlockProperties { get; private set; }

        /// <summary>
        /// get model's position information from DataSource.
        /// </summary>
        public CatesianGridderSource DataSource { get; private set; }

        /// <summary>
        /// minimum value for mapped color.
        /// </summary>
        public float MinColorCode { get; set; }

        /// <summary>
        /// maximum value for mapped color.
        /// </summary>
        public float MaxColorCode { get; set; }

        /// <summary>
        /// base model for gridview.
        /// </summary>
        /// <param name="dataSource"></param>
        /// <param name="gridProps"></param>
        /// <param name="minColorCode"></param>
        /// <param name="maxColorCode"></param>
        /// <param name="defaultBlockPropertyIndex"></param>
        public GridViewModel(CatesianGridderSource dataSource, List<GridBlockProperty> gridProps,
            float minColorCode, float maxColorCode, int defaultBlockPropertyIndex = 0)
        {
            this.DataSource = dataSource;
            this.GridBlockProperties = gridProps;
            this.MinColorCode = minColorCode;
            this.MaxColorCode = maxColorCode;
            this.defaultBlockPropertyIndex = defaultBlockPropertyIndex;
        }

        public abstract VertexAttributeBufferPtr GetProperty(string bufferName, string varNameInShader);

        public abstract IndexBufferPtr GetIndex();

        public abstract void UpdateColor(GridBlockProperty property);

        public abstract bool UsesZeroIndexBuffer();
    }
}