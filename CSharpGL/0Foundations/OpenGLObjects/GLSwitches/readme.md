# OpenGL开关
OpenGL是个状态机。`GLSwitch`就是控制其状态的。  
例如`LineWidthSwitch`控制线的宽度。在渲染前将线宽设置为指定的宽度，在渲染后恢复到原来的宽度。  
这可以避免忘记恢复原有状态的bug。
# OpenGL switch
OpenGL works as a state machine. `GLSwitch` controls one of states in OpenGL.  
For example, `LineWidthSwitch` controls line's width. It sets line's width to specified value before rendering, and reset it to original value after rendering.  
This could prevent future bugs about forgetting to reset to original state.
