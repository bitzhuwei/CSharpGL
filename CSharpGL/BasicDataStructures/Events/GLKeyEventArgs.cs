using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// 
    /// </summary>
    public class GLKeyEventArgs : GLEventArgs
    {
        private readonly GLKeys keyData;
        private bool handled;
        private bool suppressKeyPress;

        /// <summary>
        /// 初始化 CSharpGL.GUIKeyEventArgs 类的新实例。
        /// </summary>
        /// <param name="keyData">一个 CSharpGL.GUIKeys，表示按下的键以及任何修饰符标志（指示同时按下的 Ctrl、Shift 和 Alt 键）。可通过将按位“或”(|)运算符应用于 CSharpGL.GUIKeys 枚举中的常数，来获取可能的值。</param>
        public GLKeyEventArgs(GLKeys keyData)
        {
            this.keyData = keyData;
        }

        /// <summary>
        /// 获取一个值，该值指示是否曾按下 Alt 键。
        /// </summary>
        public virtual bool Alt { get { return (this.keyData & GLKeys.Alt) == GLKeys.Alt; } }

        /// <summary>
        /// 获取一个值，该值指示是否曾按下 Ctrl 键。
        /// </summary>
        public bool Control { get { return (this.keyData & GLKeys.Control) == GLKeys.Control; } }

        /// <summary>
        /// 获取或设置一个值，该值指示是否处理过此事件。
        /// true 表示跳过控件的默认处理；false 表示还将该事件传递给默认控件处理程序。
        /// </summary>
        public bool Handled { get { return this.handled; } set { this.handled = value; } }

        /// <summary>
        /// 获取 System.Windows.Forms.Control.KeyDown 或 System.Windows.Forms.Control.KeyUp事件的键盘代码。
        /// 作为事件的键代码的 CSharpGL.GUIKeys 值。
        /// </summary>
        public GLKeys KeyCode
        {
            get
            {
                GLKeys keys = this.keyData & GLKeys.KeyCode;
                if (!Enum.IsDefined(typeof(GLKeys), (int)keys))
                {
                    return GLKeys.None;
                }
                return keys;
            }
        }

        /// <summary>
        /// 获取 System.Windows.Forms.Control.KeyDown 或 System.Windows.Forms.Control.KeyUp事件的键数据。
        /// 返回结果: 一个 CSharpGL.GUIKeys，表示按下的键的键代码以及修饰符标志（指示同时按下的 Ctrl、Shift 和 Alt 键的组合）。
        /// </summary>
        public GLKeys KeyData { get { return this.keyData; } }

        /// <summary>
        /// 获取 System.Windows.Forms.Control.KeyDown 或 System.Windows.Forms.Control.KeyUp事件的键盘值。
        /// 返回结果: CSharpGL.GUIKeyEventArgs.KeyCode 属性的整数表示形式。
        /// </summary>
        public int KeyValue { get { return (int)(this.keyData & GLKeys.KeyCode); } }

        /// <summary>
        /// 获取 System.Windows.Forms.Control.KeyDown 或 System.Windows.Forms.Control.KeyUp事件的修饰符标志。这些标志指示按下的 Ctrl、Shift 和 Alt 键的组合。
        /// 返回结果: CSharpGL.GUIKeys 值，该值表示一个或多个修饰符标志。
        /// </summary>
        public GLKeys Modifiers { get { return this.keyData & GLKeys.Modifiers; } }

        /// <summary>
        /// 获取一个值，该值指示是否曾按下 Shift 键。
        /// 返回结果: 如果曾按下 Shift 键，则为 true；否则为 false。
        /// </summary>
        public virtual bool Shift { get { return (this.keyData & GLKeys.Shift) == GLKeys.Shift; } }

        /// <summary>
        /// 获取或设置一个值，该值指示键事件是否应传递到基础控件。
        /// 返回结果: 如果键事件不应该发送到该控件，则为 true；否则为 false。
        /// </summary>
        public bool SuppressKeyPress
        {
            get
            {
                return this.suppressKeyPress;
            }
            set
            {
                this.suppressKeyPress = value;
                this.handled = value;
            }
        }
    }

    /// <summary>
    /// 指定键代码和修饰符。
    /// </summary>
    [Flags]
    public enum GLKeys
    {
        /// <summary>
        /// 从键值提取修饰符的位屏蔽。
        /// </summary>
        Modifiers = -65536,
        /// <summary>
        /// 没有按任何键。
        /// </summary>
        None = 0,
        /// <summary>
        /// 鼠标左按钮。
        /// </summary>
        LButton = 1,
        /// <summary>
        /// 鼠标右按钮。
        /// </summary>
        RButton = 2,
        /// <summary>
        /// Cancel 键。
        /// </summary>
        Cancel = 3,
        /// <summary>
        /// 鼠标中按钮（三个按钮的鼠标）。
        /// </summary>
        MButton = 4,
        /// <summary>
        /// 第一个 X 鼠标按钮（五个按钮的鼠标）。
        /// </summary>
        XButton1 = 5,
        /// <summary>
        /// 第二个 X 鼠标按钮（五个按钮的鼠标）。
        /// </summary>
        XButton2 = 6,
        /// <summary>
        /// Backspace 键。
        /// </summary>
        Back = 8,
        /// <summary>
        /// Tab 键。
        /// </summary>
        Tab = 9,
        /// <summary>
        /// LINEFEED 键。
        /// </summary>
        LineFeed = 10,
        /// <summary>
        /// Clear 键。
        /// </summary>
        Clear = 12,
        /// <summary>
        /// Enter 键。
        /// </summary>
        Enter = 13,
        /// <summary>
        /// Return 键。
        /// </summary>
        Return = 13,
        /// <summary>
        /// Shift 键。
        /// </summary>
        ShiftKey = 16,
        /// <summary>
        /// Ctrl 键。
        /// </summary>
        ControlKey = 17,
        /// <summary>
        /// Alt 键。
        /// </summary>
        Menu = 18,
        /// <summary>
        /// Pause 键。
        /// </summary>
        Pause = 19,
        /// <summary>
        /// Caps Lock 键。
        /// </summary>
        CapsLock = 20,
        /// <summary>
        /// Caps Lock 键。
        /// </summary>
        Capital = 20,
        /// <summary>
        /// IME Kana 模式键。
        /// </summary>
        KanaMode = 21,
        /// <summary>
        /// IME Hanguel 模式键。（为了保持兼容性而设置；使用 HangulMode）
        /// </summary>
        HanguelMode = 21,
        /// <summary>
        /// IME Hangul 模式键。
        /// </summary>
        HangulMode = 21,
        /// <summary>
        /// IME Junja 模式键。
        /// </summary>
        JunjaMode = 23,
        /// <summary>
        /// IME 最终模式键。
        /// </summary>
        FinalMode = 24,
        /// <summary>
        /// IME Kanji 模式键。
        /// </summary>
        KanjiMode = 25,
        /// <summary>
        /// IME Hanja 模式键。
        /// </summary>
        HanjaMode = 25,
        /// <summary>
        /// Esc 键。
        /// </summary>
        Escape = 27,
        /// <summary>
        /// IME 转换键。
        /// </summary>
        IMEConvert = 28,
        /// <summary>
        /// IME 非转换键。
        /// </summary>
        IMENonconvert = 29,
        /// <summary>
        /// IME 接受键。已过时，请改用 CSharpGL.GUIKeys.IMEAccept。
        /// </summary>
        IMEAceept = 30,
        /// <summary>
        /// IME 接受键，替换 CSharpGL.GUIKeys.IMEAceept。
        /// </summary>
        IMEAccept = 30,
        /// <summary>
        /// IME 模式更改键。
        /// </summary>
        IMEModeChange = 31,
        /// <summary>
        /// 空格键。
        /// </summary>
        Space = 32,
        /// <summary>
        /// Page Up 键。
        /// </summary>
        Prior = 33,
        /// <summary>
        /// Page Up 键。
        /// </summary>
        PageUp = 33,
        /// <summary>
        /// Page Down 键。
        /// </summary>
        Next = 34,
        /// <summary>
        /// Page Down 键。
        /// </summary>
        PageDown = 34,
        /// <summary>
        /// End 键。
        /// </summary>
        End = 35,
        /// <summary>
        /// Home 键。
        /// </summary>
        Home = 36,
        /// <summary>
        /// 向左键。
        /// </summary>
        Left = 37,
        /// <summary>
        /// 向上键。
        /// </summary>
        Up = 38,
        /// <summary>
        /// 向右键。
        /// </summary>
        Right = 39,
        /// <summary>
        /// 向下键。
        /// </summary>
        Down = 40,
        /// <summary>
        /// Select 键。
        /// </summary>
        Select = 41,
        /// <summary>
        /// Print 键。
        /// </summary>
        Print = 42,
        /// <summary>
        /// EXECUTE 键。
        /// </summary>
        Execute = 43,
        /// <summary>
        /// Print Screen 键。
        /// </summary>
        PrintScreen = 44,
        /// <summary>
        /// Print Screen 键。
        /// </summary>
        Snapshot = 44,
        /// <summary>
        /// Ins 键。
        /// </summary>
        Insert = 45,
        /// <summary>
        /// DeL 键。
        /// </summary>
        Delete = 46,
        /// <summary>
        /// Help 键。
        /// </summary>
        Help = 47,
        /// <summary>
        /// 0 键。
        /// </summary>
        D0 = 48,
        /// <summary>
        /// 1 键。
        /// </summary>
        D1 = 49,
        /// <summary>
        /// 2 键。
        /// </summary>
        D2 = 50,
        /// <summary>
        /// 3 键。
        /// </summary>
        D3 = 51,
        /// <summary>
        /// 4 键。
        /// </summary>
        D4 = 52,
        /// <summary>
        /// 5 键。
        /// </summary>
        D5 = 53,
        /// <summary>
        /// 6 键。
        /// </summary>
        D6 = 54,
        /// <summary>
        /// 7 键。
        /// </summary>
        D7 = 55,
        /// <summary>
        /// 8 键。
        /// </summary>
        D8 = 56,
        /// <summary>
        /// 9 键。
        /// </summary>
        D9 = 57,
        /// <summary>
        /// A 键。
        /// </summary>
        A = 65,
        /// <summary>
        /// B 键。
        /// </summary>
        B = 66,
        /// <summary>
        /// C 键。
        /// </summary>
        C = 67,
        /// <summary>
        /// D 键。
        /// </summary>
        D = 68,
        /// <summary>
        /// E 键。
        /// </summary>
        E = 69,
        /// <summary>
        /// F 键。
        /// </summary>
        F = 70,
        /// <summary>
        /// G 键。
        /// </summary>
        G = 71,
        /// <summary>
        /// H 键。
        /// </summary>
        H = 72,
        /// <summary>
        /// I 键。
        /// </summary>
        I = 73,
        /// <summary>
        /// J 键。
        /// </summary>
        J = 74,
        /// <summary>
        /// K 键。
        /// </summary>
        K = 75,
        /// <summary>
        /// L 键。
        /// </summary>
        L = 76,
        /// <summary>
        /// M 键。
        /// </summary>
        M = 77,
        /// <summary>
        /// N 键。
        /// </summary>
        N = 78,
        /// <summary>
        /// O 键。
        /// </summary>
        O = 79,
        /// <summary>
        /// P 键。
        /// </summary>
        P = 80,
        /// <summary>
        /// Q 键。
        /// </summary>
        Q = 81,
        /// <summary>
        /// R 键。
        /// </summary>
        R = 82,
        /// <summary>
        /// S 键。
        /// </summary>
        S = 83,
        /// <summary>
        /// T 键。
        /// </summary>
        T = 84,
        /// <summary>
        /// U 键。
        /// </summary>
        U = 85,
        /// <summary>
        /// V 键。
        /// </summary>
        V = 86,
        /// <summary>
        /// W 键。
        /// </summary>
        W = 87,
        /// <summary>
        /// X 键。
        /// </summary>
        X = 88,
        /// <summary>
        /// Y 键。
        /// </summary>
        Y = 89,
        /// <summary>
        /// Z 键。
        /// </summary>
        Z = 90,
        /// <summary>
        /// 左 Windows 徽标键（Microsoft Natural Keyboard，人体工程学键盘）。
        /// </summary>
        LWin = 91,
        /// <summary>
        /// 右 Windows 徽标键（Microsoft Natural Keyboard，人体工程学键盘）。
        /// </summary>
        RWin = 92,
        /// <summary>
        /// 应用程序键（Microsoft Natural Keyboard，人体工程学键盘）。
        /// </summary>
        Apps = 93,
        /// <summary>
        /// 计算机睡眠键。
        /// </summary>
        Sleep = 95,
        /// <summary>
        /// 数字键盘上的 0 键。
        /// </summary>
        NumPad0 = 96,
        //
        // 摘要: 
        //     
        /// <summary>
        /// 数字键盘上的 1 键。
        /// </summary>
        NumPad1 = 97,
        //
        // 摘要: 
        /// <summary>
        /// 数字键盘上的 2 键。
        /// </summary>
        //     
        NumPad2 = 98,
        /// <summary>
        /// 数字键盘上的 3 键。
        /// </summary>
        NumPad3 = 99,
        /// <summary>
        /// 数字键盘上的 4 键。
        /// </summary>
        NumPad4 = 100,
        /// <summary>
        /// 数字键盘上的 5 键。
        /// </summary>
        NumPad5 = 101,
        /// <summary>
        /// 数字键盘上的 6 键。
        /// </summary>
        NumPad6 = 102,
        /// <summary>
        /// 数字键盘上的 7 键。
        /// </summary>
        NumPad7 = 103,
        /// <summary>
        /// 数字键盘上的 8 键。
        /// </summary>
        NumPad8 = 104,
        /// <summary>
        /// 数字键盘上的 9 键。
        /// </summary>
        NumPad9 = 105,
        /// <summary>
        /// 乘号键。
        /// </summary>
        Multiply = 106,
        /// <summary>
        /// 加号键。
        /// </summary>
        Add = 107,
        /// <summary>
        /// 分隔符键。
        /// </summary>
        Separator = 108,
        /// <summary>
        /// 减号键。
        /// </summary>
        Subtract = 109,
        /// <summary>
        /// 句点键。
        /// </summary>
        Decimal = 110,
        /// <summary>
        /// 除号键。
        /// </summary>
        Divide = 111,
        /// <summary>
        /// F1 键。
        /// </summary>
        F1 = 112,
        /// <summary>
        /// F2 键。
        /// </summary>
        F2 = 113,
        /// <summary>
        /// F3 键。
        /// </summary>
        F3 = 114,
        /// <summary>
        /// F4 键。
        /// </summary>
        F4 = 115,
        /// <summary>
        /// F5 键。
        /// </summary>
        F5 = 116,
        /// <summary>
        /// F6 键。
        /// </summary>
        F6 = 117,
        /// <summary>
        /// F7 键。
        /// </summary>
        F7 = 118,
        /// <summary>
        /// F8 键。
        /// </summary>
        F8 = 119,
        /// <summary>
        /// F9 键。
        /// </summary>
        F9 = 120,
        /// <summary>
        /// F10 键。
        /// </summary>
        F10 = 121,
        /// <summary>
        /// F11 键。
        /// </summary>
        F11 = 122,
        /// <summary>
        /// F12 键。
        /// </summary>
        F12 = 123,
        /// <summary>
        /// F13 键。
        /// </summary>
        F13 = 124,
        /// <summary>
        /// F14 键。
        /// </summary>
        F14 = 125,
        /// <summary>
        /// F15 键。
        /// </summary>
        F15 = 126,
        /// <summary>
        /// F16 键。
        /// </summary>
        F16 = 127,
        /// <summary>
        /// F17 键。
        /// </summary>
        F17 = 128,
        /// <summary>
        /// F18 键。
        /// </summary>
        F18 = 129,
        /// <summary>
        /// F19 键。
        /// </summary>
        F19 = 130,
        /// <summary>
        /// F20 键。
        /// </summary>
        F20 = 131,
        /// <summary>
        /// F21 键。
        /// </summary>
        F21 = 132,
        /// <summary>
        /// F22 键。
        /// </summary>
        F22 = 133,
        /// <summary>
        /// F23 键。
        /// </summary>
        F23 = 134,
        /// <summary>
        /// F24 键。
        /// </summary>
        F24 = 135,
        /// <summary>
        /// Num Lock 键。
        /// </summary>
        NumLock = 144,
        /// <summary>
        /// Scroll Lock 键。
        /// </summary>
        Scroll = 145,
        /// <summary>
        /// 左 Shift 键。
        /// </summary>
        LShiftKey = 160,
        /// <summary>
        /// 右 Shift 键。
        /// </summary>
        RShiftKey = 161,
        /// <summary>
        /// 左 Ctrl 键。
        /// </summary>
        LControlKey = 162,
        /// <summary>
        /// 右 Ctrl 键。
        /// </summary>
        RControlKey = 163,
        /// <summary>
        /// 左 Alt 键。
        /// </summary>
        LMenu = 164,
        /// <summary>
        /// 右 Alt 键。
        /// </summary>
        RMenu = 165,
        /// <summary>
        /// 浏览器后退键（Windows 2000 或更高版本）。
        /// </summary>
        BrowserBack = 166,
        /// <summary>
        /// 浏览器前进键（Windows 2000 或更高版本）。
        /// </summary>
        BrowserForward = 167,
        /// <summary>
        /// 浏览器刷新键（Windows 2000 或更高版本）。
        /// </summary>
        BrowserRefresh = 168,
        /// <summary>
        /// 浏览器停止键（Windows 2000 或更高版本）。
        /// </summary>
        BrowserStop = 169,
        /// <summary>
        /// 浏览器搜索键（Windows 2000 或更高版本）。
        /// </summary>
        BrowserSearch = 170,
        /// <summary>
        /// 浏览器收藏夹键（Windows 2000 或更高版本）。
        /// </summary>
        BrowserFavorites = 171,
        /// <summary>
        /// 浏览器主页键（Windows 2000 或更高版本）。
        /// </summary>
        BrowserHome = 172,
        /// <summary>
        /// 静音键（Windows 2000 或更高版本）。
        /// </summary>
        VolumeMute = 173,
        /// <summary>
        /// 减小音量键（Windows 2000 或更高版本）。
        /// </summary>
        VolumeDown = 174,
        /// <summary>
        /// 增大音量键（Windows 2000 或更高版本）。
        /// </summary>
        VolumeUp = 175,
        /// <summary>
        /// 媒体下一曲目键（Windows 2000 或更高版本）。
        /// </summary>
        MediaNextTrack = 176,
        /// <summary>
        /// 媒体上一曲目键（Windows 2000 或更高版本）。
        /// </summary>
        MediaPreviousTrack = 177,
        /// <summary>
        /// 媒体停止键（Windows 2000 或更高版本）。
        /// </summary>
        MediaStop = 178,
        /// <summary>
        /// 媒体播放暂停键（Windows 2000 或更高版本）。
        /// </summary>
        MediaPlayPause = 179,
        /// <summary>
        /// 启动邮件键（Windows 2000 或更高版本）。
        /// </summary>
        LaunchMail = 180,
        /// <summary>
        /// 选择媒体键（Windows 2000 或更高版本）。
        /// </summary>
        SelectMedia = 181,
        /// <summary>
        /// 启动应用程序一键（Windows 2000 或更高版本）。
        /// </summary>
        LaunchApplication1 = 182,
        /// <summary>
        /// 启动应用程序二键（Windows 2000 或更高版本）。
        /// </summary>
        LaunchApplication2 = 183,
        /// <summary>
        /// OEM 1 键。
        /// </summary>
        Oem1 = 186,
        /// <summary>
        /// 美式标准键盘上的 OEM 分号键（Windows 2000 或更高版本）。
        /// </summary>
        OemSemicolon = 186,
        /// <summary>
        /// 任何国家/地区键盘上的 OEM 加号键（Windows 2000 或更高版本）。
        /// </summary>
        Oemplus = 187,
        /// <summary>
        /// 任何国家/地区键盘上的 OEM 逗号键（Windows 2000 或更高版本）。
        /// </summary>
        Oemcomma = 188,
        /// <summary>
        /// 任何国家/地区键盘上的 OEM 减号键（Windows 2000 或更高版本）。
        /// </summary>
        OemMinus = 189,
        /// <summary>
        /// 任何国家/地区键盘上的 OEM 句点键（Windows 2000 或更高版本）。
        /// </summary>
        OemPeriod = 190,
        /// <summary>
        /// 美式标准键盘上的 OEM 问号键（Windows 2000 或更高版本）。
        /// </summary>
        OemQuestion = 191,
        /// <summary>
        /// OEM 2 键。
        /// </summary>
        Oem2 = 191,
        /// <summary>
        /// 美式标准键盘上的 OEM 波形符键（Windows 2000 或更高版本）。
        /// </summary>
        Oemtilde = 192,
        /// <summary>
        /// OEM 3 键。
        /// </summary>
        Oem3 = 192,
        /// <summary>
        /// OEM 4 键。
        /// </summary>
        Oem4 = 219,
        /// <summary>
        /// 美式标准键盘上的 OEM 左括号键（Windows 2000 或更高版本）。
        /// </summary>
        OemOpenBrackets = 219,
        /// <summary>
        /// 美式标准键盘上的 OEM 管道键（Windows 2000 或更高版本）。
        /// </summary>
        OemPipe = 220,
        /// <summary>
        /// OEM 5 键。
        /// </summary>
        Oem5 = 220,
        /// <summary>
        /// OEM 6 键。
        /// </summary>
        Oem6 = 221,
        /// <summary>
        /// 美式标准键盘上的 OEM 右括号键（Windows 2000 或更高版本）。
        /// </summary>
        OemCloseBrackets = 221,
        /// <summary>
        /// OEM 7 键。
        /// </summary>
        Oem7 = 222,
        /// <summary>
        /// 美式标准键盘上的 OEM 单/双引号键（Windows 2000 或更高版本）。
        /// </summary>
        OemQuotes = 222,
        /// <summary>
        /// OEM 8 键。
        /// </summary>
        Oem8 = 223,
        /// <summary>
        /// OEM 102 键。
        /// </summary>
        Oem102 = 226,
        /// <summary>
        /// RT 102 键的键盘上的 OEM 尖括号或反斜杠键（Windows 2000 或更高版本）。
        /// </summary>
        OemBackslash = 226,
        /// <summary>
        /// Process Key 键。
        /// </summary>
        ProcessKey = 229,
        /// <summary>
        /// 用于将 Unicode 字符当作键击传递。Packet 键值是用于非键盘输入法的 32 位虚拟键值的低位字。
        /// </summary>
        Packet = 231,
        /// <summary>
        /// Attn 键。
        /// </summary>
        Attn = 246,
        /// <summary>
        /// Crsel 键。
        /// </summary>
        Crsel = 247,
        /// <summary>
        /// Exsel 键。
        /// </summary>
        Exsel = 248,
        /// <summary>
        /// ERASE EOF 键。
        /// </summary>
        EraseEof = 249,
        /// <summary>
        /// Play 键。
        /// </summary>
        Play = 250,
        /// <summary>
        /// Zoom 键。
        /// </summary>
        Zoom = 251,
        /// <summary>
        /// 保留以备将来使用的常数。
        /// </summary>
        NoName = 252,
        /// <summary>
        /// PA1 键。
        /// </summary>
        Pa1 = 253,
        /// <summary>
        /// Clear 键。
        /// </summary>
        OemClear = 254,
        /// <summary>
        /// 从键值提取键代码的位屏蔽。
        /// </summary>
        KeyCode = 65535,
        /// <summary>
        /// Shift 修改键。
        /// </summary>
        Shift = 65536,
        /// <summary>
        /// Ctrl 修改键。
        /// </summary>
        Control = 131072,
        /// <summary>
        /// Alt 修改键。
        /// </summary>
        Alt = 262144,
    }
}
