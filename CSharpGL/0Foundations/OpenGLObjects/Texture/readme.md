# Texture
A texture is generated from 2 main steps.
## 1. set up texture's content
This is done by calling `glTexImage2D()`, `glTexImage1D()` etc.
Generally we uses a `Bitmap` object to provide image data.
## 2. set up texture's configurations
This is done by calling 'glTexParameteri()' etc.
We can ask OpenGL for a `sampler' object to reduce OpenGL commands.
# To Be Continued
The concept of mipmap is still not applied.
