# Draw Mode Experiment.
I want to know how OpenGL acts when index buffer is not well designed. 
For example, if index buffer use byte.MaxValue(which is 255) as the primitive restart index, and the index buffer is for rendering triangles with content like this:
```0 1 2 255 3 255 4 5 255 255 ...```
How will OpenGL render the triangles?
