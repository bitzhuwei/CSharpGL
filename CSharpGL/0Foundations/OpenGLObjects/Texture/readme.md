# Texture
A texture is generated in 2 steps.
## set up texture's configurations
This is done by calling 'glTexParameteri()', `glSamplerParameteri()` etc.  
We can ask OpenGL for a ``sampler`` object to reduce OpenGL calls.
## set up texture's content
This is done by calling `glTexImage2D()`, `glTexImage1D()` etc.  
Generally we uses a `Bitmap` object to provide image data.
# To Be Continued
The concept of mipmap is still not applied to practice.
