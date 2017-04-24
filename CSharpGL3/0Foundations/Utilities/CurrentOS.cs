using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace CSharpGL
{
    /// <summary>
    /// Detects the current OS (Windows, Linux, MacOS)
    /// <para>CurrentOS Class by blez</para>
    /// <para>https://blez.wordpress.com/2012/09/17/determine-os-with-netmono/</para>
    /// </summary>
    public static class CurrentOS
    {
        static CurrentOS()
        {
            IsWindows = System.IO.Path.DirectorySeparatorChar == '\\';
            if (IsWindows)
            {
                Name = Environment.OSVersion.VersionString;

                Name = Name.Replace("Microsoft ", "");
                Name = Name.Replace("  ", " ");
                Name = Name.Replace(" )", ")");
                Name = Name.Trim();

                Name = Name.Replace("NT 6.2", "8 %bit 6.2");
                Name = Name.Replace("NT 6.1", "7 %bit 6.1");
                Name = Name.Replace("NT 6.0", "Vista %bit 6.0");
                Name = Name.Replace("NT 5.", "XP %bit 5.");
                Name = Name.Replace("%bit", (Is64bitWindows ? "64bit" : "32bit"));

                if (Is64bitWindows)
                    Is64bit = true;
                else
                    Is32bit = true;
            }
            else
            {
                var UnixName = ReadProcessOutput("uname");
                if (UnixName.Contains("Darwin"))
                {
                    IsUnix = true;
                    IsMac = true;

                    Name = "MacOS X " + ReadProcessOutput("sw_vers", "-productVersion");
                    Name = Name.Trim();

                    var machine = ReadProcessOutput("uname", "-m");
                    if (machine.Contains("x86_64"))
                        Is64bit = true;
                    else
                        Is32bit = true;

                    Name += " " + (Is32bit ? "32bit" : "64bit");
                }
                else if (UnixName.Contains("Linux"))
                {
                    IsUnix = true;
                    IsLinux = true;

                    Name = ReadProcessOutput("lsb_release", "-d");
                    Name = Name.Substring(Name.IndexOf(":") + 1);
                    Name = Name.Trim();

                    var machine = ReadProcessOutput("uname", "-m");
                    if (machine.Contains("x86_64"))
                        Is64bit = true;
                    else
                        Is32bit = true;

                    Name += " " + (Is32bit ? "32bit" : "64bit");
                }
                else if (UnixName != "")
                {
                    IsUnix = true;
                }
                else
                {
                    IsUnknown = true;
                }
            }
        }

        /// <summary>
        ///
        /// </summary>
        public static bool IsWindows { get; private set; }

        /// <summary>
        ///
        /// </summary>
        public static bool IsUnix { get; private set; }

        /// <summary>
        ///
        /// </summary>
        public static bool IsMac { get; private set; }

        /// <summary>
        ///
        /// </summary>
        public static bool IsLinux { get; private set; }

        /// <summary>
        ///
        /// </summary>
        public static bool IsUnknown { get; private set; }

        /// <summary>
        ///
        /// </summary>
        public static bool Is32bit { get; private set; }

        /// <summary>
        ///
        /// </summary>
        public static bool Is64bit { get; private set; }

        /// <summary>
        ///
        /// </summary>
        public static bool Is64BitProcess
        {
            get { return (IntPtr.Size == 8); }
        }

        /// <summary>
        ///
        /// </summary>
        public static bool Is32BitProcess
        {
            get { return (IntPtr.Size == 4); }
        }

        /// <summary>
        ///
        /// </summary>
        public static string Name { get; private set; }

        private static bool Is64bitWindows
        {
            get
            {
                if ((Environment.OSVersion.Version.Major == 5 && Environment.OSVersion.Version.Minor >= 1) ||
                   Environment.OSVersion.Version.Major >= 6)
                {
                    using (var p = Process.GetCurrentProcess())
                    {
                        bool retVal;
                        if (!IsWow64Process(p.Handle, out retVal)) return false;
                        return retVal;
                    }
                }
                return false;
            }
        }

        [DllImport("kernel32.dll", SetLastError = true, CallingConvention = CallingConvention.Winapi)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool IsWow64Process([In] IntPtr hProcess, [Out] out bool wow64Process);

        private static string ReadProcessOutput(string name, string args = null)
        {
            try
            {
                var p = new Process
                {
                    StartInfo =
                    {
                        UseShellExecute = false,
                        RedirectStandardOutput = true
                    }
                };
                if (!string.IsNullOrEmpty(args)) p.StartInfo.Arguments = " " + args;
                p.StartInfo.FileName = name;
                p.Start();
                // Do not wait for the child process to exit before
                // reading to the end of its redirected stream.
                // p.WaitForExit();
                // Read the output stream first and then wait.
                var output = p.StandardOutput.ReadToEnd();
                p.WaitForExit();
                output = output.Trim();
                return output;
            }
            catch
            {
                return "";
            }
        }
    }
}