using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public static class OpenFolderHelper
    {
        [DllImport("shell32.dll", ExactSpelling = true)]
        static extern int SHOpenFolderAndSelectItems(
           IntPtr pidlFolder,
           uint cidl,
           [In, MarshalAs(UnmanagedType.LPArray)] IntPtr[] apidl,
           uint dwFlags);

        [DllImport("shell32.dll", CharSet = CharSet.Auto)]
        static extern IntPtr ILCreateFromPath([MarshalAs(UnmanagedType.LPTStr)] string pszPath);

        [ComImport]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        [Guid("000214F9-0000-0000-C000-000000000046")]
        interface IShellLinkW
        {
            [PreserveSig]
            int GetPath(StringBuilder pszFile, int cch, [In, Out] ref WIN32_FIND_DATAW pfd, uint fFlags);

            [PreserveSig]
            int GetIDList([Out] out IntPtr ppidl);

            [PreserveSig]
            int SetIDList([In] ref IntPtr pidl);

            [PreserveSig]
            int GetDescription(StringBuilder pszName, int cch);

            [PreserveSig]
            int SetDescription([MarshalAs(UnmanagedType.LPWStr)] string pszName);

            [PreserveSig]
            int GetWorkingDirectory(StringBuilder pszDir, int cch);

            [PreserveSig]
            int SetWorkingDirectory([MarshalAs(UnmanagedType.LPWStr)] string pszDir);

            [PreserveSig]
            int GetArguments(StringBuilder pszArgs, int cch);

            [PreserveSig]
            int SetArguments([MarshalAs(UnmanagedType.LPWStr)] string pszArgs);

            [PreserveSig]
            int GetHotkey([Out] out ushort pwHotkey);

            [PreserveSig]
            int SetHotkey(ushort wHotkey);

            [PreserveSig]
            int GetShowCmd([Out] out int piShowCmd);

            [PreserveSig]
            int SetShowCmd(int iShowCmd);

            [PreserveSig]
            int GetIconLocation(StringBuilder pszIconPath, int cch, [Out] out int piIcon);

            [PreserveSig]
            int SetIconLocation([MarshalAs(UnmanagedType.LPWStr)] string pszIconPath, int iIcon);

            [PreserveSig]
            int SetRelativePath([MarshalAs(UnmanagedType.LPWStr)] string pszPathRel, uint dwReserved);

            [PreserveSig]
            int Resolve(IntPtr hwnd, uint fFlags);

            [PreserveSig]
            int SetPath([MarshalAs(UnmanagedType.LPWStr)] string pszFile);
        }

        [Serializable, StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode), BestFitMapping(false)]
        struct WIN32_FIND_DATAW
        {
            public uint dwFileAttributes;
            public FILETIME ftCreationTime;
            public FILETIME ftLastAccessTime;
            public FILETIME ftLastWriteTime;
            public uint nFileSizeHigh;
            public uint nFileSizeLow;
            public uint dwReserved0;
            public uint dwReserved1;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string cFileName;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 14)]
            public string cAlternateFileName;
        }

        public static void OpenFolderAndSelectFiles(string folder, params string[] filesToSelect)
        {
            IntPtr dir = ILCreateFromPath(folder);

            var filesToSelectIntPtrs = new IntPtr[filesToSelect.Length];
            for (int i = 0; i < filesToSelect.Length; i++)
            {
                filesToSelectIntPtrs[i] = ILCreateFromPath(filesToSelect[i]);
            }

            SHOpenFolderAndSelectItems(dir, (uint)filesToSelect.Length, filesToSelectIntPtrs, 0);
            ReleaseComObject(dir);
            ReleaseComObject(filesToSelectIntPtrs);
        }

        private static void ReleaseComObject(params object[] comObjs)
        {
            foreach (object obj in comObjs)
            {
                if (obj != null && Marshal.IsComObject(obj))
                    Marshal.ReleaseComObject(obj);
            }
        }
    }
}
