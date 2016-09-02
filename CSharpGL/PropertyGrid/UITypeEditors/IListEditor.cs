using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;

namespace CSharpGL
{
    /// <summary>
    /// 用在IList&lt;GLSwitch&gt;类型的属性上。
    /// </summary>
    internal class IListEditor<T> : UITypeEditor
    {
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            // 打开属性编辑器修改数据
            var editor = new FormIListEditor<T>(context, provider, value as IList<T>);
            editor.ShowDialog();

            return value;
        }

        public override UITypeEditorEditStyle GetEditStyle(System.ComponentModel.ITypeDescriptorContext context)
        {
            // 指定为模式窗体属性编辑器类型
            return UITypeEditorEditStyle.Modal;
        }
    }
}