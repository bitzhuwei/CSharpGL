using System;
using System.Diagnostics;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace CSharpGL
{
    public static partial class GL
    {

        #region The GLU DLL Functions (Exactly the same naming).

        /// <summary>
        /// Produce an error string from a GL or GLU error code.
        /// </summary>
        /// <param name="errCode">Specifies a GL or GLU error code.</param>
        /// <returns>The OpenGL/GLU error string.</returns>
        [DllImport(Win32.Glu32, SetLastError = true)]
        private static unsafe extern sbyte* gluErrorString(uint errCode);

        /// <summary>
        /// Return a string describing the GLU version or GLU extensions.
        /// </summary>
        /// <param name="name">Specifies a symbolic constant, one of OpenGL.VERSION, or OpenGL.EXTENSIONS.</param>
        /// <returns>The GLU string.</returns>
        [DllImport(Win32.Glu32, SetLastError = true)]
        private static unsafe extern sbyte* gluGetString(int name);
        [DllImport(Win32.Glu32, SetLastError = true)]
        private static extern void gluOrtho2D(double left, double right, double bottom, double top);

        /// <summary>
        /// This function creates a perspective matrix and multiplies it to the current
        /// matrix stack (which in most cases should be 'PROJECTION').
        /// </summary>
        /// <param name="fovy">Field of view angle (human eye = 60 Degrees).</param>
        /// <param name="aspect">Apsect Ratio (width of screen divided by height of screen).</param>
        /// <param name="zNear">Near clipping plane (normally 1).</param>
        /// <param name="zFar">Far clipping plane.</param>
        [DllImport(Win32.Glu32, SetLastError = true)]
        private static extern void gluPerspective(double fovy, double aspect, double zNear, double zFar);

        /// <summary>
        /// This function creates a 'pick matrix' normally used for selecting objects that
        /// are at a certain point on the screen.
        /// </summary>
        /// <param name="x">X Point.</param>
        /// <param name="y">Y Point.</param>
        /// <param name="width">Width of point to test (4 is normal).</param>
        /// <param name="height">Height of point to test (4 is normal).</param>
        /// <param name="viewport">The current viewport.</param>
        [DllImport(Win32.Glu32, SetLastError = true)]
        private static extern void gluPickMatrix(double x, double y, double width, double height, int[] viewport);

        /// <summary>
        /// This function transforms the projection matrix so that it looks at a certain
        /// point, from a certain point.
        /// </summary>
        /// <param name="eyex">Position of the eye.</param>
        /// <param name="eyey">Position of the eye.</param>
        /// <param name="eyez">Position of the eye.</param>
        /// <param name="centerx">Point to look at.</param>
        /// <param name="centery">Point to look at.</param>
        /// <param name="centerz">Point to look at.</param>
        /// <param name="upx">'Up' Vector X Component.</param>
        /// <param name="upy">'Up' Vector Y Component.</param>
        /// <param name="upz">'Up' Vector Z Component.</param>
        [DllImport(Win32.Glu32, SetLastError = true)]
        private static extern void gluLookAt(double eyex, double eyey, double eyez, double centerx, double centery, double centerz, double upx, double upy, double upz);

        /// <summary>
        /// This function Maps the specified object coordinates into window coordinates.
        /// </summary>
        /// <param name="objx">The object's x coord.</param>
        /// <param name="objy">The object's y coord.</param>
        /// <param name="objz">The object's z coord.</param>
        /// <param name="modelMatrix">The modelview matrix.</param>
        /// <param name="projMatrix">The projection matrix.</param>
        /// <param name="viewport">The viewport.</param>
        /// <param name="winx">The window x coord.</param>
        /// <param name="winy">The Window y coord.</param>
        /// <param name="winz">The Window z coord.</param>
        [DllImport(Win32.Glu32, SetLastError = true)]
        private static extern void gluProject(double objx, double objy, double objz, double[] modelMatrix, double[] projMatrix, int[] viewport, double[] winx, double[] winy, double[] winz);

        /// <summary>
        /// This function turns a screen Coordinate into a world coordinate.
        /// </summary>
        /// <param name="winx">Screen Coordinate.</param>
        /// <param name="winy">Screen Coordinate.</param>
        /// <param name="winz">Screen Coordinate.</param>
        /// <param name="modelMatrix">Current ModelView matrix.</param>
        /// <param name="projMatrix">Current Projection matrix.</param>
        /// <param name="viewport">Current Viewport.</param>
        /// <param name="objx">The world coordinate.</param>
        /// <param name="objy">The world coordinate.</param>
        /// <param name="objz">The world coordinate.</param>

        [DllImport(Win32.Glu32, SetLastError = true)]
        private static extern void gluUnProject(double winx, double winy, double winz, double[] modelMatrix, double[] projMatrix, int[] viewport, ref double objx, ref double objy, ref double objz);

        /// <summary>
        /// Scale an image to an arbitrary size.
        /// </summary>
        /// <param name="format">Specifies the format of the pixel data.</param>
        /// <param name="widthin">Specify the width of the source image	that is	scaled.</param>
        /// <param name="heightin">Specify the height of the source image that is scaled.</param>
        /// <param name="typein">Specifies the data type for dataIn.</param>
        /// <param name="datain">Specifies a pointer to the source image.</param>
        /// <param name="widthout">Specify the width of the destination image.</param>
        /// <param name="heightout">Specify the height of the destination image.</param>
        /// <param name="typeout">Specifies the data type for dataOut.</param>
        /// <param name="dataout">Specifies a pointer to the destination image.</param>
        [DllImport(Win32.Glu32, SetLastError = true)]
        private static extern void gluScaleImage(int format, int widthin, int heightin, int typein, int[] datain, int widthout, int heightout, int typeout, int[] dataout);

        /// <summary>
        /// Create 1-D mipmaps.
        /// </summary>
        /// <param name="target">Specifies the target texture. Must be OpenGL.TEXTURE_1D.</param>
        /// <param name="components">Specifies the number of color components in the texture. Must be 1, 2, 3, or 4.</param>
        /// <param name="width">Specifies the width of the texture image.</param>
        /// <param name="format">Specifies the format of the pixel data.</param>
        /// <param name="type">Specifies the data type for data.</param>
        /// <param name="data">Specifies a pointer to the image data in memory.</param>
        [DllImport(Win32.Glu32, SetLastError = true)]
        private static extern void gluBuild1DMipmaps(uint target, uint components, int width, uint format, uint type, IntPtr data);

        /// <summary>
        /// Create 2-D mipmaps.
        /// </summary>
        /// <param name="target">Specifies the target texture. Must be OpenGL.TEXTURE_1D.</param>
        /// <param name="components">Specifies the number of color components in the texture. Must be 1, 2, 3, or 4.</param>
        /// <param name="width">Specifies the width of the texture image.</param>
        /// <param name="height">Specifies the height of the texture image.</param>
        /// <param name="format">Specifies the format of the pixel data.</param>
        /// <param name="type">Specifies the data type for data.</param>
        /// <param name="data">Specifies a pointer to the image data in memory.</param>
        [DllImport(Win32.Glu32, SetLastError = true)]
        private static extern void gluBuild2DMipmaps(uint target, uint components, int width, int height, uint format, uint type, IntPtr data);

        /// <summary>
        /// This function creates a new OpenGL Quadric Object.
        /// </summary>
        /// <returns>The pointer to the Quadric Object.</returns>
        [DllImport(Win32.Glu32, SetLastError = true)]
        private static extern IntPtr gluNewQuadric();

        /// <summary>
        /// Call this function to delete an OpenGL Quadric object.
        /// </summary>
        /// <param name="quadric"></param>
        [DllImport(Win32.Glu32, SetLastError = true)]
        private static extern void gluDeleteQuadric(IntPtr state);

        /// <summary>
        /// This set's the Generate Normals propery of the specified Quadric object.
        /// </summary>
        /// <param name="quadricObject">The quadric object.</param>
        /// <param name="normals">The type of normals to generate.</param>
        [DllImport(Win32.Glu32, SetLastError = true)]
        private static extern void gluQuadricNormals(IntPtr quadObject, uint normals);

        /// <summary>
        /// This function sets the type of texture coordinates being generated by
        /// the specified quadric object.
        /// </summary>
        /// <param name="quadricObject">The quadric object.</param>
        /// <param name="textureCoords">The type of coordinates to generate.</param>
        [DllImport(Win32.Glu32, SetLastError = true)]
        private static extern void gluQuadricTexture(IntPtr quadObject, int textureCoords);

        /// <summary>
        /// This sets the orientation for the quadric object.
        /// </summary>
        /// <param name="quadricObject">The quadric object.</param>
        /// <param name="orientation">The orientation.</param>
        [DllImport(Win32.Glu32, SetLastError = true)]
        private static extern void gluQuadricOrientation(IntPtr quadObject, int orientation);

        /// <summary>
        /// This sets the current drawstyle for the Quadric Object.
        /// </summary>
        /// <param name="quadObject">The quadric object.</param>
        /// <param name="drawStyle">The draw style.</param>
        [DllImport(Win32.Glu32, SetLastError = true)]
        private static extern void gluQuadricDrawStyle(IntPtr quadObject, uint drawStyle);

        /// <summary>
        /// This function draws a sphere from the quadric object.
        /// </summary>
        /// <param name="qobj">The quadric object.</param>
        /// <param name="baseRadius">Radius at the base.</param>
        /// <param name="topRadius">Radius at the top.</param>
        /// <param name="height">Height of cylinder.</param>
        /// <param name="slices">Cylinder slices.</param>
        /// <param name="stacks">Cylinder stacks.</param>
        [DllImport(Win32.Glu32, SetLastError = true)]
        private static extern void gluCylinder(IntPtr qobj, double baseRadius, double topRadius, double height, int slices, int stacks);

        /// <summary>
        /// Draw a disk.
        /// </summary>
        /// <param name="qobj">Specifies the quadrics object (created with gluNewQuadric).</param>
        /// <param name="innerRadius">Specifies the	inner radius of	the disk (may be 0).</param>
        /// <param name="outerRadius">Specifies the	outer radius of	the disk.</param>
        /// <param name="slices">Specifies the	number of subdivisions around the z axis.</param>
        /// <param name="loops">Specifies the	number of concentric rings about the origin into which the disk is subdivided.</param>
        [DllImport(Win32.Glu32, SetLastError = true)]
        private static extern void gluDisk(IntPtr qobj, double innerRadius, double outerRadius, int slices, int loops);

        /// <summary>
        /// This function draws a partial disk from the quadric object.
        /// </summary>
        /// <param name="qobj">The Quadric objec.t</param>
        /// <param name="innerRadius">Radius of the inside of the disk.</param>
        /// <param name="outerRadius">Radius of the outside of the disk.</param>
        /// <param name="slices">The slices.</param>
        /// <param name="loops">The loops.</param>
        /// <param name="startAngle">Starting angle.</param>
        /// <param name="sweepAngle">Sweep angle.</param>
        [DllImport(Win32.Glu32, SetLastError = true)]
        private static extern void gluPartialDisk(IntPtr qobj, double innerRadius, double outerRadius, int slices, int loops, double startAngle, double sweepAngle);

        /// <summary>
        /// This function draws a sphere from a Quadric Object.
        /// </summary>
        /// <param name="qobj">The quadric object.</param>
        /// <param name="radius">Sphere radius.</param>
        /// <param name="slices">Slices of the sphere.</param>
        /// <param name="stacks">Stakcs of the sphere.</param>
        [DllImport(Win32.Glu32, SetLastError = true)]
        private static extern void gluSphere(IntPtr qobj, double radius, int slices, int stacks);

        /// <summary>
        /// Create a tessellation object.
        /// </summary>
        /// <returns>A new GLUtesselator poiner.</returns>
        [DllImport(Win32.Glu32, SetLastError = true)]
        private static extern IntPtr gluNewTess();

        /// <summary>
        /// Delete a tesselator object.
        /// </summary>
        /// <param name="tess">The tesselator pointer.</param>
        [DllImport(Win32.Glu32, SetLastError = true)]
        private static extern void gluDeleteTess(IntPtr tess);

        /// <summary>
        /// Delimit a polygon description.
        /// </summary>
        /// <param name="tess">Specifies the tessellation object (created with gluNewTess).</param>
        /// <param name="polygonData">Specifies a pointer to user polygon data.</param>
        [DllImport(Win32.Glu32, SetLastError = true)]
        private static extern void gluTessBeginPolygon(IntPtr tess, IntPtr polygonData);

        /// <summary>
        /// Delimit a contour description.
        /// </summary>
        /// <param name="tess">Specifies the tessellation object (created with gluNewTess).</param>
        [DllImport(Win32.Glu32, SetLastError = true)]
        private static extern void gluTessBeginContour(IntPtr tess);

        /// <summary>
        /// Specify a vertex on a polygon.
        /// </summary>
        /// <param name="tess">Specifies the tessellation object (created with gluNewTess).</param>
        /// <param name="coords">Specifies the location of the vertex.</param>
        /// <param name="data">Specifies an opaque	pointer	passed back to the program with the vertex callback (as specified by gluTessCallback).</param>
        [DllImport(Win32.Glu32, SetLastError = true)]
        private static extern void gluTessVertex(IntPtr tess, double[] coords, double[] data);

        /// <summary>
        /// Delimit a contour description.
        /// </summary>
        /// <param name="tess">Specifies the tessellation object (created with gluNewTess).</param>
        [DllImport(Win32.Glu32, SetLastError = true)]
        private static extern void gluTessEndContour(IntPtr tess);

        /// <summary>
        /// Delimit a polygon description.
        /// </summary>
        /// <param name="tess">Specifies the tessellation object (created with gluNewTess).</param>
        [DllImport(Win32.Glu32, SetLastError = true)]
        private static extern void gluTessEndPolygon(IntPtr tess);

        /// <summary>
        /// Set a tessellation object property.
        /// </summary>
        /// <param name="tess">Specifies the tessellation object (created with gluNewTess).</param>
        /// <param name="which">Specifies the property to be set.</param>
        /// <param name="value">Specifies the value of	the indicated property.</param>
        [DllImport(Win32.Glu32, SetLastError = true)]
        private static extern void gluTessProperty(IntPtr tess, int which, double value);

        /// <summary>
        /// Specify a normal for a polygon.
        /// </summary>
        /// <param name="tess">Specifies the tessellation object (created with gluNewTess).</param>
        /// <param name="x">Specifies the first component of the normal.</param>
        /// <param name="y">Specifies the second component of the normal.</param>
        /// <param name="z">Specifies the third component of the normal.</param>
        [DllImport(Win32.Glu32, SetLastError = true)]
        private static extern void gluTessNormal(IntPtr tess, double x, double y, double z);
        //		[DllImport(Win32.Glu32, SetLastError = true)] private static extern void  gluTessCallback(IntPtr tess, int which, SharpGL.Delegates.Tesselators.Begin callback);
        //		[DllImport(Win32.Glu32, SetLastError = true)] private static extern void  gluTessCallback(IntPtr tess, int which, SharpGL.Delegates.Tesselators.BeginData callback);
        //		[DllImport(Win32.Glu32, SetLastError = true)] private static extern void  gluTessCallback(IntPtr tess, int which, SharpGL.Delegates.Tesselators.Combine callback);
        //		[DllImport(Win32.Glu32, SetLastError = true)] private static extern void  gluTessCallback(IntPtr tess, int which, SharpGL.Delegates.Tesselators.CombineData callback);
        //		[DllImport(Win32.Glu32, SetLastError = true)] private static extern void  gluTessCallback(IntPtr tess, int which, SharpGL.Delegates.Tesselators.EdgeFlag callback);
        //		[DllImport(Win32.Glu32, SetLastError = true)] private static extern void  gluTessCallback(IntPtr tess, int which, SharpGL.Delegates.Tesselators.EdgeFlagData callback);
        //		[DllImport(Win32.Glu32, SetLastError = true)] private static extern void  gluTessCallback(IntPtr tess, int which, SharpGL.Delegates.Tesselators.End callback);
        //		[DllImport(Win32.Glu32, SetLastError = true)] private static extern void  gluTessCallback(IntPtr tess, int which, SharpGL.Delegates.Tesselators.EndData callback);
        //		[DllImport(Win32.Glu32, SetLastError = true)] private static extern void  gluTessCallback(IntPtr tess, int which, SharpGL.Delegates.Tesselators.Error callback);
        //		[DllImport(Win32.Glu32, SetLastError = true)] private static extern void  gluTessCallback(IntPtr tess, int which, SharpGL.Delegates.Tesselators.ErrorData callback);
        //		[DllImport(Win32.Glu32, SetLastError = true)] private static extern void  gluTessCallback(IntPtr tess, int which, SharpGL.Delegates.Tesselators.Vertex callback);
        //		[DllImport(Win32.Glu32, SetLastError = true)] private static extern void  gluTessCallback(IntPtr tess, int which, SharpGL.Delegates.Tesselators.VertexData callback);

        /// <summary>
        /// Set a tessellation object property.
        /// </summary>
        /// <param name="tess">Specifies the tessellation object (created with gluNewTess).</param>
        /// <param name="which">Specifies the property	to be set.</param>
        /// <param name="value">Specifies the value of	the indicated property.</param>
        [DllImport(Win32.Glu32, SetLastError = true)]
        private static extern void gluGetTessProperty(IntPtr tess, int which, double value);

        /// <summary>
        /// This function creates a new glu NURBS renderer object.
        /// </summary>
        /// <returns>A Pointer to the NURBS renderer.</returns>
        [DllImport(Win32.Glu32, SetLastError = true)]
        private static extern IntPtr gluNewNurbsRenderer();

        /// <summary>
        /// This function deletes the underlying glu nurbs renderer.
        /// </summary>
        /// <param name="nurbsObject">The pointer to the nurbs object.</param>
        [DllImport(Win32.Glu32, SetLastError = true)]
        private static extern void gluDeleteNurbsRenderer(IntPtr nobj);

        /// <summary>
        /// This function begins drawing a NURBS surface.
        /// </summary>
        /// <param name="nurbsObject">The NURBS object.</param>
        [DllImport(Win32.Glu32, SetLastError = true)]
        private static extern void gluBeginSurface(IntPtr nobj);

        /// <summary>
        /// This function begins drawing a NURBS curve.
        /// </summary>
        /// <param name="nurbsObject">The NURBS object.</param>
        [DllImport(Win32.Glu32, SetLastError = true)]
        private static extern void gluBeginCurve(IntPtr nobj);

        /// <summary>
        /// This function ends the drawing of a NURBS curve.
        /// </summary>
        /// <param name="nurbsObject">The nurbs object.</param>
        [DllImport(Win32.Glu32, SetLastError = true)]
        private static extern void gluEndCurve(IntPtr nobj);

        /// <summary>
        /// This function ends the drawing of a NURBS surface.
        /// </summary>
        /// <param name="nurbsObject">The nurbs object.</param>

        [DllImport(Win32.Glu32, SetLastError = true)]
        private static extern void gluEndSurface(IntPtr nobj);

        /// <summary>
        /// Delimit a NURBS trimming loop definition.
        /// </summary>
        /// <param name="nobj">Specifies the NURBS object (created with gluNewNurbsRenderer).</param>
        [DllImport(Win32.Glu32, SetLastError = true)]
        private static extern void gluBeginTrim(IntPtr nobj);

        /// <summary>
        /// Delimit a NURBS trimming loop definition.
        /// </summary>
        /// <param name="nobj">Specifies the NURBS object (created with gluNewNurbsRenderer).</param>
        [DllImport(Win32.Glu32, SetLastError = true)]
        private static extern void gluEndTrim(IntPtr nobj);

        /// <summary>
        /// Describe a piecewise linear NURBS trimming curve.
        /// </summary>
        /// <param name="nobj">Specifies the NURBS object (created with gluNewNurbsRenderer).</param>
        /// <param name="count">Specifies the number of points on the curve.</param>
        /// <param name="array">Specifies an array containing the curve points.</param>
        /// <param name="stride">Specifies the offset (a number of single-precision floating-point values) between points on the curve.</param>
        /// <param name="type">Specifies the type of curve. Must be either OpenGL.MAP1_TRIM_2 or OpenGL.MAP1_TRIM_3.</param>
        [DllImport(Win32.Glu32, SetLastError = true)]
        private static extern void gluPwlCurve(IntPtr nobj, int count, float array, int stride, uint type);

        /// <summary>
        /// This function defines a NURBS Curve.
        /// </summary>
        /// <param name="nurbsObject">The NURBS object.</param>
        /// <param name="knotsCount">The number of knots.</param>
        /// <param name="knots">The knots themselves.</param>
        /// <param name="stride">The stride, i.e. distance between vertices in the 
        /// control points array.</param>
        /// <param name="controlPointsArray">The array of control points.</param>
        /// <param name="order">The order of the polynomial.</param>
        /// <param name="type">The type of data to generate.</param>
        [DllImport(Win32.Glu32, SetLastError = true)]
        private static extern void gluNurbsCurve(IntPtr nobj, int nknots, float[] knot, int stride, float[] ctlarray, int order, uint type);

        /// <summary>
        /// This function defines a NURBS surface.
        /// </summary>
        /// <param name="nurbsObject">The NURBS object.</param>
        /// <param name="sknotsCount">The sknots count.</param>
        /// <param name="sknots">The s-knots.</param>
        /// <param name="tknotsCount">The number of t-knots.</param>
        /// <param name="tknots">The t-knots.</param>
        /// <param name="sStride">The distance between s vertices.</param>
        /// <param name="tStride">The distance between t vertices.</param>
        /// <param name="controlPointsArray">The control points.</param>
        /// <param name="sOrder">The order of the s polynomial.</param>
        /// <param name="tOrder">The order of the t polynomial.</param>
        /// <param name="type">The type of data to generate.</param>
        [DllImport(Win32.Glu32, SetLastError = true)]
        private static extern void gluNurbsSurface(IntPtr nobj, int sknot_count, float[] sknot, int tknot_count, float[] tknot, int s_stride, int t_stride, float[] ctlarray, int sorder, int torder, uint type);

        /// <summary>
        /// Load NURBS sampling and culling matrice.
        /// </summary>
        /// <param name="nobj">Specifies the NURBS object (created with gluNewNurbsRenderer).</param>
        /// <param name="modelMatrix">Specifies a modelview matrix (as from a glGetFloatv call).</param>
        /// <param name="projMatrix">Specifies a projection matrix (as from a glGetFloatv call).</param>
        /// <param name="viewport">Specifies a viewport (as from a glGetIntegerv call).</param>
        [DllImport(Win32.Glu32, SetLastError = true)]
        private static extern void gluLoadSamplingMatrices(IntPtr nobj, float[] modelMatrix, float[] projMatrix, int[] viewport);

        /// <summary>
        /// This function sets a NURBS property.
        /// </summary>
        /// <param name="nurbsObject">The object to set the property for.</param>
        /// <param name="property">The property to set.</param>
        /// <param name="value">The new value of the property.</param>
        [DllImport(Win32.Glu32, SetLastError = true)]
        private static extern void gluNurbsProperty(IntPtr nobj, int property, float value);

        /// <summary>
        /// Get a NURBS property.
        /// </summary>
        /// <param name="nobj">Specifies the NURBS object (created with gluNewNurbsRenderer).</param>
        /// <param name="property">Specifies the property whose value is to be fetched.</param>
        /// <param name="value">Specifies a pointer to the location into which the value of the named property is written.</param>
        [DllImport(Win32.Glu32, SetLastError = true)]
        private static extern void gluGetNurbsProperty(IntPtr nobj, int property, float value);
        [DllImport(Win32.Glu32, SetLastError = true)]
        private static extern void IntPtrCallback(IntPtr nobj, int which, IntPtr Callback);

        #endregion

    }
}
