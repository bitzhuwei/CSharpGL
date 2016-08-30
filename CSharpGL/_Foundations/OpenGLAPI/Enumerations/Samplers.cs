using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CSharpGL
{
    /// <summary>
    /// 纹理坐标通常的范围是从(0, 0)到(1, 1)，如果我们把纹理坐标设置为范围以外会发生什么？OpenGL默认的行为是重复这个纹理图像（我们简单地忽略浮点纹理坐标的整数部分），但OpenGL提供了更多的选择
    /// </summary>
    public enum TextureWrapping : uint
    {
        /// <summary>
        /// 纹理的默认行为。重复纹理图像。
        /// </summary>
        Repeat = OpenGL.GL_REPEAT,
        /// <summary>
        /// 和GL_REPEAT一样，除了重复的图片是镜像放置的。
        /// </summary>
        MirroredRepeaet = OpenGL.GL_MIRRORED_REPEAT,
        /// <summary>
        /// 纹理坐标会在0到1之间。超出的部分会重复纹理坐标的边缘，就是边缘被拉伸。
        /// </summary>
        ClampToEdge = OpenGL.GL_CLAMP_TO_EDGE,
        /// <summary>
        /// 超出的部分是用户指定的边缘的颜色。
        /// </summary>
        ClampToBorder = OpenGL.GL_CLAMP_TO_BORDER,
    }

    /// <summary>
    /// 组成纹理的图片数据和其要贴上去的形状的大小往往是不一样的。两种情况，纹理图片小，贴图区域大，需要放大纹理称为：magnification；或者反过来，缩小纹理显示出来，称为 minification.在做放大喝缩小的操作的时候的具体的策略如下
    /// </summary>
    public enum TextureFilter : uint
    {
        /// <summary>
        /// 直接选择最临近的像素的颜色，magnification（放大）时：由于多个片元会在同一个纹理像素上面取值，故最终得到的图片颗粒度很大，会有锯齿。
        /// </summary>
        Nearest = OpenGL.GL_NEAREST,

        /// <summary>
        /// 根据临近四个的像素点的颜色值，做线性的插值计算，得到最终的颜色。magnification（放大）时：不会产生锯齿，显示更加平滑。
        /// </summary>
        Linear = OpenGL.GL_LINEAR,
    }

    /// <summary>
    /// Mipmap就是一系列纹理，每个后面的一个纹理是前一个的二分之一，这一系列的纹理是OpenGL生成的，生成时进行了图像质量的优化，使其拥有更多的细节。这一系列的纹理是提前生成的，程序运行时只需要从中挑出合适大小的纹理应用即可，而不是运行时进行图像大小的处理，效率上会有提高。
    /// OpenGL渲染的时候，两个不同级别的mipmap之间会产生不真实感的生硬的边界。就像普通的纹理过滤一样，也可以在两个不同mipmap级别之间使用NEAREST和LINEAR过滤。指定不同mipmap级别之间的过滤方式可以使用下面四种选项代替原来的过滤方式：
    /// </summary>
    public enum MipmapFilter : uint
    {
        /// <summary>
        /// 接收最近的mipmap来匹配像素大小，并使用最临近插值进行纹理采样。
        /// </summary>
        NearestMipmapNearest = OpenGL.GL_NEAREST_MIPMAP_NEAREST,
        /// <summary>
        /// 接收最近的mipmap级别，并使用线性插值采样。
        /// </summary>
        LinearMipmapNearest = OpenGL.GL_LINEAR_MIPMAP_NEAREST,
        /// <summary>
        /// 在两个mipmap之间进行线性插值，通过最邻近插值采样。
        /// </summary>
        NearestMipmapLinear = OpenGL.GL_NEAREST_MIPMAP_LINEAR,
        /// <summary>
        /// 在两个相邻的mipmap进行线性插值，并通过线性插值进行采样。
        /// </summary>
        LinearMipmapLinear = OpenGL.GL_LINEAR_MIPMAP_LINEAR,
    }

    // 总结一下：magnification和minification的时候都可以设置NEAREST和LINEAR两种方式；minification的时候还可以设置mipmap的方式，该方法效果更好。关于具体的算法的实现，可以参考《OpenGL ES specification》的8.13-8.14内容。
}

