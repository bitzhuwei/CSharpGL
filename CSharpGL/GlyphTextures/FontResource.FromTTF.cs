using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Xml.Linq;

namespace CSharpGL
{
    /// <summary>
    /// 含有字形贴图及其配置信息的单例类型。
    /// </summary>
    public sealed partial class FontResource
    {

        public static FontResource Load(string ttfFilename)
        {
            Bitmap bitmap;
            XElement config;
            Load(ttfFilename, out bitmap, out config);
            var result = new FontResource(bitmap, config);
            bitmap.Dispose(); 
            return result;
        }

        private static void Load(string ttfFilename, out Bitmap bitmap, out XElement config)
        {
            throw new NotImplementedException();
        }
    }
}
