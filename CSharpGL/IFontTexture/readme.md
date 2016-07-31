# IFontTexture
定义了用[Bitmap + GlyphInfo Dictionary]保存的字形信息（可转换为OpenGL中的纹理，用以显示文字）。 
# IFontTexture
Glyph information stored in a Bitmap and a glyphInfo dictionary object. Bitmap can be transformed to a 2D texture to display text. 
# How to Get FontBitmap?
1. Get glyph's size by graphics.MeasureString(). 

This size is bigger than glyph's real size. So we must shrink it using the method 'RetargetGlyphRectangleInwards()'.
After this step, we can get every glyph's width and height. And the 'xoffset' field of GlyphInfo object describes the distance in the single glyph's bitmap.
![FontBitmapHelper.1_PrepareInitialGlyphDictcs.cs.png](https://github.com/bitzhuwei/CSharpGL/blob/gh-pages/images/CSharpGL/FontBitmapHelper.1_PrepareInitialGlyphDictcs.cs.png?raw=true)

2. Get final bitmap's size(width and height). 

We can layout the glyphs on a imaginary rectangle as we have already gotten all glyph's sizes.
We do this because the Bitmap's size must be settled(in constructor method) when its instance is created.
![FontBitmapHelper.2_PrepareFinalBitmapSize.cs.png](https://github.com/bitzhuwei/CSharpGL/blob/gh-pages/images/CSharpGL/FontBitmapHelper.2_PrepareFinalBitmapSize.cs.png?raw=true)

3. Create final bitmap and print all glyphs onto it.

We print all glyphs and setup glyph's xoffset/yoffset during the same loop.
![FontBitmapHelper.3_PrintBitmap.cs.png](https://github.com/bitzhuwei/CSharpGL/blob/gh-pages/images/CSharpGL/FontBitmapHelper.3_PrintBitmap.cs.png?raw=true)
