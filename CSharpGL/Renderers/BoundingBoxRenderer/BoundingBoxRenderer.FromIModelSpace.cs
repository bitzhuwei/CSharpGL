using System.Collections.Generic;
using System.Linq;

namespace CSharpGL
{
    /// <summary>
    ///
    /// </summary>
    public static class BoundingBoxRendererHelper
    {

        /// <summary>
        /// Gets a <see cref="BoundingBoxRenderer"/> that wraps specified <paramref name="model"/>.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static BoundingBoxRenderer GetBoundingBoxRenderer(this IModelSpace model)
        {
            BoundingBoxRenderer boxRenderer = BoundingBoxRenderer.Create(
                model.Lengths);
            const float lineWidth = 1.0f;
            boxRenderer.SwitchList.Add(new LineWidthSwitch(lineWidth));
            boxRenderer.CopyModelSpaceStateFrom(model);

            return boxRenderer;
        }

        /// <summary>
        /// Gets a <see cref="BoundingBoxRenderer"/> that wraps specified <paramref name="models"/>.
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public static BoundingBoxRenderer GetBoundingBoxRenderer(this IModelSpace[] models)
        {
            var rectangles = from item in models select item.GetBoundingBox() as IBoundingBox;

            return GetBoundingBoxRenderer(rectangles);
        }

        /// <summary>
        /// Gets a <see cref="BoundingBoxRenderer"/> that wraps specified <paramref name="rectangles"/>.
        /// </summary>
        /// <param name="rectangles"></param>
        /// <returns></returns>
        public static BoundingBoxRenderer GetBoundingBoxRenderer(this  IEnumerable<IBoundingBox> rectangles)
        {
            IBoundingBox rect = null;
            bool initialized = false;
            foreach (var item in rectangles)
            {
                if (!initialized)
                {
                    rect = item;
                    initialized = true;
                }
                else
                {
                    rect = rect.Union(item);
                }
            }

            if (!initialized)
            {
                rect = new BoundingBox();
            }

            BoundingBoxRenderer boxRenderer = GetBoundingBoxRenderer(rect);

            return boxRenderer;
        }

        /// <summary>
        /// Gets a <see cref="BoundingBoxRenderer"/> that wraps specified <paramref name="rectangles"/>.
        /// </summary>
        /// <param name="rectangles"></param>
        /// <returns></returns>
        public static BoundingBoxRenderer GetBoundingBoxRenderer(this  IBoundingBox[] rectangles)
        {
            IBoundingBox rect;
            if (rectangles.Length > 0)
            {
                rect = rectangles[0];
                for (int i = 1; i < rectangles.Length; i++)
                {
                    rect = rect.Union(rectangles[i]);
                }
            }
            else
            {
                rect = new BoundingBox();
            }

            BoundingBoxRenderer boxRenderer = GetBoundingBoxRenderer(rect);

            return boxRenderer;
        }

        /// <summary>
        /// Gets a <see cref="BoundingBoxRenderer"/> that wraps specified <paramref name="rectangle"/>.
        /// </summary>
        /// <param name="rectangle"></param>
        /// <returns></returns>
        public static BoundingBoxRenderer GetBoundingBoxRenderer(this IBoundingBox rectangle)
        {
            vec3 lengths = rectangle.MaxPosition - rectangle.MinPosition;
            vec3 originalWorldPosition = rectangle.MaxPosition / 2 + rectangle.MinPosition / 2;
            BoundingBoxRenderer boxRenderer = BoundingBoxRenderer.Create(lengths, originalWorldPosition);
            const float lineWidth = 1.0f;
            boxRenderer.SwitchList.Add(new LineWidthSwitch(lineWidth));

            return boxRenderer;
        }
    }
}