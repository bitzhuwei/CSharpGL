using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// 用在IList&lt;GLSwitch&gt;类型的属性上。
    /// </summary>
    class IListEditor<T> : UITypeEditor
    {

        public override UITypeEditorEditStyle GetEditStyle(System.ComponentModel.ITypeDescriptorContext context)
        {
            // 指定为模式窗体属性编辑器类型
            return UITypeEditorEditStyle.Modal;
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            // 打开属性编辑器修改数据
            var editor = new FormIListEditor<T>(value as IList<T>);
            if (editor.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var sceneObject = context.Instance as SceneObject;
                if (sceneObject != null)
                {
                    SceneRootObject rootObject = null;
                    while (sceneObject != null && sceneObject.Parent != null)
                    {
                        sceneObject = sceneObject.Parent;
                    }
                    rootObject = sceneObject as SceneRootObject;
                    if (rootObject != null)
                    {
                        Scene scene = rootObject.BindingScene;
                        ICanvas canvas = scene.Canvas;
                        scene.Update();
                        canvas.Repaint();
                        //OpenGL.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT | OpenGL.GL_STENCIL_BUFFER_BIT);
                        //scene.Render(RenderModes.Render, canvas.CanvasRectangle, canvas.CursorPosition);
                    }
                }
            }

            return value;
        }
    }
}
