# Object Oriented OpenGL in C\#   
:green_apple:CSharpGL is an Object-Orinted OpenGL wrapper in pure C# wihtout any third party support.  
It abstracts concepts(buffer, shader, state, matrix, vector, texture, canvas, scene, camera, light, picking, text, GUI ...) from OpenGL API and common requirements.  
More than 30 simple demonstration projects show how to use CSharpGL. And there will be more.  
## OpenGL via C# available now!

[![OpenGL via C#](demos.OpenGLviaCSharp/%E7%94%A8C%23%E5%AD%A6%E9%9D%A2%E5%90%91%E5%AF%B9%E8%B1%A1%E7%9A%84OpenGL.jpg)](https://item.jd.com/12582632.html)

## Stencil Shadow Volume.

![StencilShadowVolume.gif](demos.anything/demoCodes/Lighting.ShadowVolume/StencilShadowVolume.gif?raw=true)

## Skeleton Animation.

![SkeletonAnimation.gif](demos.anything/demoCodes/FirstSightOfAssimpNet/SkeletalAnimation.gif?raw=true)

## Physically Based Rendering.

![PBR.IBLSpecularTextured](demos.anything/demoCodes/PBR.IBLSpecularTextured/PBR.IBLSpecularTextured.png?raw=true)

## WorldSpace Billboard.

![WorldSpaceBillboard](demos.anything/demoCodes/WorldSpaceBillboard/WorldSpaceBillboard.png?raw=true)

## Picking.

Get to know how CSharpGL\OpenGL implements picking and draging with modern OpenGL!

![Color Coded Picking](demos.anything/demoCodes/ColorCodedPicking/ColorCodedPicking.png?raw=true)

## Front To Back Peeling.

![FrontToBackPeeling.gif](demos.anything/demoCodes/DepthPeeling.FrontToBackPeeling/FrontToBackPeeling.gif?raw=true)

## Environment Mapping.

![Refraction](demos.anything/demoCodes/EnvironmentMapping/Refraction.png?raw=true)

## VolumeRendering.Raycast.

![VolumeRendering.Raycast](demos.anything/demoCodes/VolumeRendering.Raycast/VolumeRendering.Raycast.png?raw=true)

## Order-Independent Transparency.

![OrderIndependentTransparency](demos.anything/demoCodes/OrderIndependentTransparency/OrderIndependentTransparency.png?raw=true)

# :question:Support or Contact

Check my blog [here](http://www.cnblogs.com/bitzhuwei/) or join my QQ Group<a target="_blank" href="http://shang.qq.com/wpa/qunwpa?idkey=98131e619f6da03b96ad2213a1278da4fdd05b42a58d053125ce6ba76cf991f9"><img border="0" src="http://pub.idqqimg.com/wpa/images/group.png" alt="CSharpGL(C#+OpenGL)" title="CSharpGL(C#+OpenGL)"></a>.

# simple guide

```
if (use OpenGL in C#) {
    add ref to CSharpGL.dll
    
    if (render with GPU) {
        if (on Windows) {
            add ref to CSharpGL.Windows.dll
        }
        else { not implemented. }
    }
    
    if (render with SoftGLImpl) {
        add ref to CSharpGL.SoftGL.dll
        add ref to SoftGLImpl.dll // work as graphics card
    }
}
else {
    go away.
}
```

# End
