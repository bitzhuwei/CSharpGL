﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace CSharpGL {
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
        public static void DrawText(int x, int y, Color color, string faceName, float fontSize, string text) {
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

            var viewport = new int[4];
            GL.Instance.GetIntegerv(GL.GL_VIEWPORT, viewport);
            double width = viewport[2];
            double height = viewport[3];

            //  Create the appropriate projection matrix.
            GL.Instance.MatrixMode(GL.GL_PROJECTION);
            GL.Instance.PushMatrix();
            GL.Instance.LoadIdentity();

            GL.Instance.Ortho(0, width, 0, height, -1, 1);

            //  Create the appropriate modelview matrix.
            GL.Instance.MatrixMode(GL.GL_MODELVIEW);
            GL.Instance.PushMatrix();
            GL.Instance.LoadIdentity();
            //GL.Instance.Color(color.R, color.G, color.B);
            //GL.Instance.RasterPos2i(x, y);

            //GL.Instance.PushAttrib(GL.GL_LIST_BIT | GL.GL_CURRENT_BIT |
            //    GL.GL_ENABLE_BIT | GL.GL_TRANSFORM_BIT);
            GL.Instance.Color3ub(color.R, color.G, color.B);
            //GL.Instance.Disable(GL.GL_LIGHTING);
            //GL.Instance.Disable(GL.GL_TEXTURE_2D);
            //GL.Instance.Disable(GL.GL_DEPTH_TEST);
            GL.Instance.RasterPos2i(x, y);

            //  Set the list base.
            GL.Instance.ListBase(fontBitmapEntry.ListBase);

            //  Create an array of lists for the glyphs.
            var lists = text.Select(c => (byte)c).ToArray();

            //  Call the lists for the string.
            GL.Instance.CallLists(lists.Length, GL.GL_UNSIGNED_BYTE, lists);
            GL.Instance.Flush();

            ////  Reset the list bit.
            //GL.Instance.PopAttrib();

            //  Pop the modelview.
            GL.Instance.PopMatrix();

            //  back to the projection and pop it, then back to the model view.
            GL.Instance.MatrixMode(GL.GL_PROJECTION);
            GL.Instance.PopMatrix();
            GL.Instance.MatrixMode(GL.GL_MODELVIEW);
        }

        private static FontBitmapEntry CreateFontBitmapEntry(string faceName, int height) {
            //  Make the OpenGL instance current.
            //GL.MakeCurrent();
            IntPtr renderContext = Win32.wglGetCurrentContext();
            IntPtr deviceContext = Win32.wglGetCurrentDC();
            Win32.wglMakeCurrent(deviceContext, renderContext);

            //  Create the font based on the face name.
            var hFont = Win32.CreateFont(height, 0, 0, 0, Win32.FW_DONTCARE, 0, 0, 0, Win32.DEFAULT_CHARSET,
                Win32.OUT_OUTLINE_PRECIS, Win32.CLIP_DEFAULT_PRECIS, Win32.CLEARTYPE_QUALITY, Win32.VARIABLE_PITCH, faceName);

            //  Select the font handle.
            var hOldObject = Win32.SelectObject(deviceContext, hFont);

            //  Create the list base.
            var listBase = GL.Instance.GenLists(1);

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