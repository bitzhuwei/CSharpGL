# How to use `Texture` and `SamplerObject`?
```
glUniform1i(TextureIndex, index);
glActiveTexture(GL_TEXTURE0 + index);
glBindTexture(GL_TEXTURE_2D, TextureHandle);
glBindSampler(index, SamplerHandle);
```
