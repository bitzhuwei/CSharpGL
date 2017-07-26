using System;
using System.ComponentModel;
using System.Drawing.Design;

namespace CSharpGL
{
    /// <summary>
    /// For any single object.
    /// </summary>
    public class PropertyGridEditor : UITypeEditor
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="provider"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            // 打开属性编辑器修改数据
            var editor = new FormPropertyGridEditor(context, provider, value);
            editor.ShowDialog();

            return value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override UITypeEditorEditStyle GetEditStyle(System.ComponentModel.ITypeDescriptorContext context)
        {
            // 指定为模式窗体属性编辑器类型
            return UITypeEditorEditStyle.Modal;
        }
    }
}