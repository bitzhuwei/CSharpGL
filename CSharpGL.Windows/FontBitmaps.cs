using System.Diagnostics;
using System.Drawing;

namespace CSharpGL.Windows {

    /// <summary>
    /// This class wraps the functionality of the wglUseFontBitmaps function to
    /// allow straightforward rendering of text.
    /// </summary>
    public class FontBitmaps {
        /// <summary>
        /// Cache of font bitmap enties.
        /// </summary>
        private static readonly List<FontBitmapEntry> fontBitmapEntries = new List<FontBitmapEntry>();

        /// <summary>
        /// Draws the text.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="color"></param>
        /// <param name="faceName"></param>
        /// <param name="fontSize"></param>
        /// <param name="text"></param>
        public static unsafe void DrawText(int x, int y, Color color, string faceName, float fontSize, string text) {
            var gl = GL.Current; Debug.Assert(gl != null);

            IntPtr renderContext = Win32.wglGetCurrentContext();
            IntPtr deviceContext = Win32.wglGetCurrentDC();

            //  Get the font size in pixels.
            var fontHeight = (int)(fontSize * (16.0f / 12.0f));

            //  Do we have a font bitmap entry for this OpenGL instance and face name?
            var result = (from fbe in fontBitmapEntries
                          where fbe.HDC == deviceContext
                          && fbe.HRC == renderContext
                          && String.Compare(fbe.FaceName, faceName, StringComparison.OrdinalIgnoreCase) == 0
                          && fbe.Height == fontHeight
                          select fbe).ToList();

            //  Get the FBE or null.
            var fontBitmapEntry = result.FirstOrDefault();

            //  If we don't have the FBE, we must create it.
            if (fontBitmapEntry == null)
                fontBitmapEntry = CreateFontBitmapEntry(faceName, fontHeight);

            var viewport = stackalloc int[4];
            gl.glGetIntegerv(GL.GL_VIEWPORT, viewport);
            double width = viewport[2];
            double height = viewport[3];

            //  Create the appropriate projection matrix.
            gl.glMatrixMode(GL.GL_PROJECTION);
            gl.glPushMatrix();
            gl.glLoadIdentity();

            gl.glOrtho(0, width, 0, height, -1, 1);

            //  Create the appropriate modelview matrix.
            gl.glMatrixMode(GL.GL_MODELVIEW);
            gl.glPushMatrix();
            gl.glLoadIdentity();
            //GL.Instance.Color(color.R, color.G, color.B);
            //GL.Instance.RasterPos2i(x, y);

            //GL.Instance.PushAttrib(GL.GL_LIST_BIT | GL.GL_CURRENT_BIT |
            //    GL.GL_ENABLE_BIT | GL.GL_TRANSFORM_BIT);
            gl.glColor3ub(color.R, color.G, color.B);
            //gl.glDisable(GL.GL_LIGHTING);
            //gl.glDisable(GL.GL_TEXTURE_2D);
            //gl.glDisable(GL.GL_DEPTH_TEST);
            gl.glRasterPos2i(x, y);

            //  Set the list base.
            gl.glListBase(fontBitmapEntry.ListBase);

            //  Create an array of lists for the glyphs.
            var lists = text.Select(c => (byte)c).ToArray();

            //  Call the lists for the string.
            fixed (byte* p = lists) {
                gl.glCallLists(lists.Length, GL.GL_UNSIGNED_BYTE, (IntPtr)p);
            }
            gl.glFlush();

            ////  Reset the list bit.
            //gl.glPopAttrib();

            //  Pop the modelview.
            gl.glPopMatrix();

            //  back to the projection and pop it, then back to the model view.
            gl.glMatrixMode(GL.GL_PROJECTION);
            gl.glPopMatrix();
            gl.glMatrixMode(GL.GL_MODELVIEW);
        }

        private unsafe static FontBitmapEntry CreateFontBitmapEntry(string faceName, int height) {
            var gl = GL.Current; Debug.Assert(gl != null);

            //  Make the OpenGL instance current.
            //GL.MakeCurrent();
            IntPtr renderContext = Win32.wglGetCurrentContext();
            IntPtr deviceContext = Win32.wglGetCurrentDC();
            Win32.wglMakeCurrent(deviceContext, renderContext);

            //  Create the font based on the face name.
            var hFont = Win32.CreateFont(height, 0, 0, 0,
                0/*Win32.FW_DONTCARE*/, 0, 0, 0, 1/*Win32.DEFAULT_CHARSET*/,
                8/*Win32.OUT_OUTLINE_PRECIS*/, 0/*Win32.CLIP_DEFAULT_PRECIS*/,
                5/*Win32.CLEARTYPE_QUALITY*/, 2/*Win32.VARIABLE_PITCH*/, faceName);

            //  Select the font handle.
            var hOldObject = Win32.SelectObject(deviceContext, hFont);

            //  Create the list base.
            var listBase = gl.glGenLists(1);

            //  Create the font bitmaps.
            bool result = Win32.wglUseFontBitmaps(deviceContext, 0, 255, listBase);

            //  Reselect the old font.
            Win32.SelectObject(deviceContext, hOldObject);

            //  Free the font.
            Win32.DeleteObject(hFont);

            //  Create the font bitmap entry.
            var fbe = new FontBitmapEntry() {
                HDC = deviceContext,
                HRC = renderContext,
                FaceName = faceName,
                Height = height,
                ListBase = listBase,
                ListCount = 255
            };

            //  Add the font bitmap entry to the internal list.
            fontBitmapEntries.Add(fbe);

            return fbe;
        }
    }
}
