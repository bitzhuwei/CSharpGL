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
            BoundingBoxRenderer boxRenderer = BoundingBoxRenderer.Create(model.ModelSize);
            boxRenderer.SwitchList.Add(new LineWidthSwitch(lineWidth: 1.0f));
            //boxRenderer.CopyModelSpaceStateFrom(model);
            boxRenderer.ModelSize = model.ModelSize;

            return boxRenderer;
        }

        /// <summary>
        /// Gets a <see cref="BoundingBoxRenderer"/> that wraps specified <paramref name="models"/>.
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public static BoundingBoxRenderer GetBoundingBoxRenderer(this IEnumerable<IModelSpace> models)
        {
            return GetBoundingBoxRenderer(models.ToArray());
        }

        /// <summary>
        /// Gets a <see cref="BoundingBoxRenderer"/> that wraps specified <paramref name="models"/>.
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public static BoundingBoxRenderer GetBoundingBoxRenderer(this IModelSpace[] models)
        {
            if (models == null) { throw new System.ArgumentNullException(); }

            vec3 max = new vec3();
            vec3 min = new vec3();
            {
                bool initialized = false;
                foreach (IModelSpace model in models)
                {
                    if (!initialized)
                    {
                        model.GetMaxMinPosition(out max, out min);
                        initialized = true;
                    }
                    else
                    {
                        vec3 tmpMax, tmpMin;
                        model.GetMaxMinPosition(out tmpMax, out tmpMin);
                        tmpMax.UpdateMax(ref max);
                        tmpMin.UpdateMin(ref min);
                    }
                }
            }

            vec3 lengths = (max - min);
            vec3 worldPosition = max / 2.0f + min / 2.0f;
            BoundingBoxRenderer boxRenderer = BoundingBoxRenderer.Create(lengths);
            boxRenderer.SwitchList.Add(new LineWidthSwitch(lineWidth: 1.0f));
            boxRenderer.WorldPosition = worldPosition;

            return boxRenderer;
        }

        ///// <summary>
        ///// Gets a <see cref="BoundingBoxRenderer"/> that wraps specified <paramref name="rectangles"/>.
        ///// </summary>
        ///// <param name="rectangles"></param>
        ///// <returns></returns>
        //public static BoundingBoxRenderer GetBoundingBoxRenderer(this  IEnumerable<IBoundingBox> rectangles)
        //{
        //    IBoundingBox rect = null;
        //    bool initialized = false;
        //    foreach (IBoundingBox item in rectangles)
        //    {
        //        if (!initialized)
        //        {
        //            rect = item;
        //            initialized = true;
        //        }
        //        else
        //        {
        //            rect = rect.Union(item);
        //        }
        //    }

        //    if (!initialized)
        //    {
        //        rect = new BoundingBox();
        //    }

        //    BoundingBoxRenderer boxRenderer = GetBoundingBoxRenderer(rect);

        //    return boxRenderer;
        //}

        ///// <summary>
        ///// Gets a <see cref="BoundingBoxRenderer"/> that wraps specified <paramref name="rectangles"/>.
        ///// </summary>
        ///// <param name="rectangles"></param>
        ///// <returns></returns>
        //public static BoundingBoxRenderer GetBoundingBoxRenderer(this  IBoundingBox[] rectangles)
        //{
        //    IBoundingBox rect;
        //    if (rectangles.Length > 0)
        //    {
        //        rect = rectangles[0];
        //        for (int i = 1; i < rectangles.Length; i++)
        //        {
        //            rect = rect.Union(rectangles[i]);
        //        }
        //    }
        //    else
        //    {
        //        rect = new BoundingBox();
        //    }

        //    BoundingBoxRenderer boxRenderer = GetBoundingBoxRenderer(rect);

        //    return boxRenderer;
        //}

        ///// <summary>
        ///// Gets a <see cref="BoundingBoxRenderer"/> that wraps specified <paramref name="rectangle"/>.
        ///// </summary>
        ///// <param name="rectangle"></param>
        ///// <returns></returns>
        //public static BoundingBoxRenderer GetBoundingBoxRenderer(this IBoundingBox rectangle)
        //{
        //    vec3 lengths = rectangle.MaxPosition - rectangle.MinPosition;
        //    vec3 originalWorldPosition = rectangle.MaxPosition / 2 + rectangle.MinPosition / 2;
        //    BoundingBoxRenderer boxRenderer = BoundingBoxRenderer.Create(lengths, originalWorldPosition);
        //    const float lineWidth = 1.0f;
        //    boxRenderer.SwitchList.Add(new LineWidthSwitch(lineWidth));

        //    return boxRenderer;
        //}
    }
}