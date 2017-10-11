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
    public class GUIKeyEventArgs : GUIEventArgs
    {
        // 摘要: 
        //     初始化 System.Windows.Forms.KeyEventArgs 类的新实例。
        //
        // 参数: 
        //   keyData:
        //     一个 System.Windows.Forms.Keys，表示按下的键以及任何修饰符标志（指示同时按下的 Ctrl、Shift 和 Alt 键）。可通过将按位“或”(|)
        //     运算符应用于 System.Windows.Forms.Keys 枚举中的常数，来获取可能的值。
        public GUIKeyEventArgs(GUIKeys keyData)
        {
            this.KeyData = keyData;
        }

        // 摘要: 
        //     获取一个值，该值指示是否曾按下 Alt 键。
        //
        // 返回结果: 
        //     如果曾按下 Alt 键，则为 true；否则为 false。
        public virtual bool Alt { get { return (this.KeyData & GUIKeys.Alt) == GUIKeys.Alt; } }
        //
        // 摘要: 
        //     获取一个值，该值指示是否曾按下 Ctrl 键。
        //
        // 返回结果: 
        //     如果曾按下 Ctrl 键，则为 true；否则为 false。
        public bool Control { get; }
        //
        // 摘要: 
        //     获取或设置一个值，该值指示是否处理过此事件。
        //
        // 返回结果: 
        //     true 表示跳过控件的默认处理；false 表示还将该事件传递给默认控件处理程序。
        public bool Handled { get; set; }
        //
        // 摘要: 
        //     获取 System.Windows.Forms.Control.KeyDown 或 System.Windows.Forms.Control.KeyUp
        //     事件的键盘代码。
        //
        // 返回结果: 
        //     作为事件的键代码的 System.Windows.Forms.Keys 值。
        public GUIKeys KeyCode { get; }
        //
        // 摘要: 
        //     获取 System.Windows.Forms.Control.KeyDown 或 System.Windows.Forms.Control.KeyUp
        //     事件的键数据。
        //
        // 返回结果: 
        //     一个 System.Windows.Forms.Keys，表示按下的键的键代码以及修饰符标志（指示同时按下的 Ctrl、Shift 和 Alt 键的组合）。
        public GUIKeys KeyData { get; }
        //
        // 摘要: 
        //     获取 System.Windows.Forms.Control.KeyDown 或 System.Windows.Forms.Control.KeyUp
        //     事件的键盘值。
        //
        // 返回结果: 
        //     System.Windows.Forms.KeyEventArgs.KeyCode 属性的整数表示形式。
        public int KeyValue { get; }
        //
        // 摘要: 
        //     获取 System.Windows.Forms.Control.KeyDown 或 System.Windows.Forms.Control.KeyUp
        //     事件的修饰符标志。这些标志指示按下的 Ctrl、Shift 和 Alt 键的组合。
        //
        // 返回结果: 
        //     System.Windows.Forms.Keys 值，该值表示一个或多个修饰符标志。
        public GUIKeys Modifiers { get; }
        //
        // 摘要: 
        //     获取一个值，该值指示是否曾按下 Shift 键。
        //
        // 返回结果: 
        //     如果曾按下 Shift 键，则为 true；否则为 false。
        public virtual bool Shift { get; }
        //
        // 摘要: 
        //     获取或设置一个值，该值指示键事件是否应传递到基础控件。
        //
        // 返回结果: 
        //     如果键事件不应该发送到该控件，则为 true；否则为 false。
        public bool SuppressKeyPress { get; set; }
    }
    // 摘要: 
    //     指定键代码和修饰符。
    [Flags]
    public enum GUIKeys
    {
        // 摘要: 
        //     从键值提取修饰符的位屏蔽。
        Modifiers = -65536,
        //
        // 摘要: 
        //     没有按任何键。
        None = 0,
        //
        // 摘要: 
        //     鼠标左按钮。
        LButton = 1,
        //
        // 摘要: 
        //     鼠标右按钮。
        RButton = 2,
        //
        // 摘要: 
        //     Cancel 键。
        Cancel = 3,
        //
        // 摘要: 
        //     鼠标中按钮（三个按钮的鼠标）。
        MButton = 4,
        //
        // 摘要: 
        //     第一个 X 鼠标按钮（五个按钮的鼠标）。
        XButton1 = 5,
        //
        // 摘要: 
        //     第二个 X 鼠标按钮（五个按钮的鼠标）。
        XButton2 = 6,
        //
        // 摘要: 
        //     Backspace 键。
        Back = 8,
        //
        // 摘要: 
        //     Tab 键。
        Tab = 9,
        //
        // 摘要: 
        //     LINEFEED 键。
        LineFeed = 10,
        //
        // 摘要: 
        //     Clear 键。
        Clear = 12,
        //
        // 摘要: 
        //     Enter 键。
        Enter = 13,
        //
        // 摘要: 
        //     Return 键。
        Return = 13,
        //
        // 摘要: 
        //     Shift 键。
        ShiftKey = 16,
        //
        // 摘要: 
        //     Ctrl 键。
        ControlKey = 17,
        //
        // 摘要: 
        //     Alt 键。
        Menu = 18,
        //
        // 摘要: 
        //     Pause 键。
        Pause = 19,
        //
        // 摘要: 
        //     Caps Lock 键。
        CapsLock = 20,
        //
        // 摘要: 
        //     Caps Lock 键。
        Capital = 20,
        //
        // 摘要: 
        //     IME Kana 模式键。
        KanaMode = 21,
        //
        // 摘要: 
        //     IME Hanguel 模式键。（为了保持兼容性而设置；使用 HangulMode）
        HanguelMode = 21,
        //
        // 摘要: 
        //     IME Hangul 模式键。
        HangulMode = 21,
        //
        // 摘要: 
        //     IME Junja 模式键。
        JunjaMode = 23,
        //
        // 摘要: 
        //     IME 最终模式键。
        FinalMode = 24,
        //
        // 摘要: 
        //     IME Kanji 模式键。
        KanjiMode = 25,
        //
        // 摘要: 
        //     IME Hanja 模式键。
        HanjaMode = 25,
        //
        // 摘要: 
        //     Esc 键。
        Escape = 27,
        //
        // 摘要: 
        //     IME 转换键。
        IMEConvert = 28,
        //
        // 摘要: 
        //     IME 非转换键。
        IMENonconvert = 29,
        //
        // 摘要: 
        //     IME 接受键。已过时，请改用 System.Windows.Forms.Keys.IMEAccept。
        IMEAceept = 30,
        //
        // 摘要: 
        //     IME 接受键，替换 System.Windows.Forms.Keys.IMEAceept。
        IMEAccept = 30,
        //
        // 摘要: 
        //     IME 模式更改键。
        IMEModeChange = 31,
        //
        // 摘要: 
        //     空格键。
        Space = 32,
        //
        // 摘要: 
        //     Page Up 键。
        Prior = 33,
        //
        // 摘要: 
        //     Page Up 键。
        PageUp = 33,
        //
        // 摘要: 
        //     Page Down 键。
        Next = 34,
        //
        // 摘要: 
        //     Page Down 键。
        PageDown = 34,
        //
        // 摘要: 
        //     End 键。
        End = 35,
        //
        // 摘要: 
        //     Home 键。
        Home = 36,
        //
        // 摘要: 
        //     向左键。
        Left = 37,
        //
        // 摘要: 
        //     向上键。
        Up = 38,
        //
        // 摘要: 
        //     向右键。
        Right = 39,
        //
        // 摘要: 
        //     向下键。
        Down = 40,
        //
        // 摘要: 
        //     Select 键。
        Select = 41,
        //
        // 摘要: 
        //     Print 键。
        Print = 42,
        //
        // 摘要: 
        //     EXECUTE 键。
        Execute = 43,
        //
        // 摘要: 
        //     Print Screen 键。
        PrintScreen = 44,
        //
        // 摘要: 
        //     Print Screen 键。
        Snapshot = 44,
        //
        // 摘要: 
        //     Ins 键。
        Insert = 45,
        //
        // 摘要: 
        //     DeL 键。
        Delete = 46,
        //
        // 摘要: 
        //     Help 键。
        Help = 47,
        //
        // 摘要: 
        //     0 键。
        D0 = 48,
        //
        // 摘要: 
        //     1 键。
        D1 = 49,
        //
        // 摘要: 
        //     2 键。
        D2 = 50,
        //
        // 摘要: 
        //     3 键。
        D3 = 51,
        //
        // 摘要: 
        //     4 键。
        D4 = 52,
        //
        // 摘要: 
        //     5 键。
        D5 = 53,
        //
        // 摘要: 
        //     6 键。
        D6 = 54,
        //
        // 摘要: 
        //     7 键。
        D7 = 55,
        //
        // 摘要: 
        //     8 键。
        D8 = 56,
        //
        // 摘要: 
        //     9 键。
        D9 = 57,
        //
        // 摘要: 
        //     A 键。
        A = 65,
        //
        // 摘要: 
        //     B 键。
        B = 66,
        //
        // 摘要: 
        //     C 键。
        C = 67,
        //
        // 摘要: 
        //     D 键。
        D = 68,
        //
        // 摘要: 
        //     E 键。
        E = 69,
        //
        // 摘要: 
        //     F 键。
        F = 70,
        //
        // 摘要: 
        //     G 键。
        G = 71,
        //
        // 摘要: 
        //     H 键。
        H = 72,
        //
        // 摘要: 
        //     I 键。
        I = 73,
        //
        // 摘要: 
        //     J 键。
        J = 74,
        //
        // 摘要: 
        //     K 键。
        K = 75,
        //
        // 摘要: 
        //     L 键。
        L = 76,
        //
        // 摘要: 
        //     M 键。
        M = 77,
        //
        // 摘要: 
        //     N 键。
        N = 78,
        //
        // 摘要: 
        //     O 键。
        O = 79,
        //
        // 摘要: 
        //     P 键。
        P = 80,
        //
        // 摘要: 
        //     Q 键。
        Q = 81,
        //
        // 摘要: 
        //     R 键。
        R = 82,
        //
        // 摘要: 
        //     S 键。
        S = 83,
        //
        // 摘要: 
        //     T 键。
        T = 84,
        //
        // 摘要: 
        //     U 键。
        U = 85,
        //
        // 摘要: 
        //     V 键。
        V = 86,
        //
        // 摘要: 
        //     W 键。
        W = 87,
        //
        // 摘要: 
        //     X 键。
        X = 88,
        //
        // 摘要: 
        //     Y 键。
        Y = 89,
        //
        // 摘要: 
        //     Z 键。
        Z = 90,
        //
        // 摘要: 
        //     左 Windows 徽标键（Microsoft Natural Keyboard，人体工程学键盘）。
        LWin = 91,
        //
        // 摘要: 
        //     右 Windows 徽标键（Microsoft Natural Keyboard，人体工程学键盘）。
        RWin = 92,
        //
        // 摘要: 
        //     应用程序键（Microsoft Natural Keyboard，人体工程学键盘）。
        Apps = 93,
        //
        // 摘要: 
        //     计算机睡眠键。
        Sleep = 95,
        //
        // 摘要: 
        //     数字键盘上的 0 键。
        NumPad0 = 96,
        //
        // 摘要: 
        //     数字键盘上的 1 键。
        NumPad1 = 97,
        //
        // 摘要: 
        //     数字键盘上的 2 键。
        NumPad2 = 98,
        //
        // 摘要: 
        //     数字键盘上的 3 键。
        NumPad3 = 99,
        //
        // 摘要: 
        //     数字键盘上的 4 键。
        NumPad4 = 100,
        //
        // 摘要: 
        //     数字键盘上的 5 键。
        NumPad5 = 101,
        //
        // 摘要: 
        //     数字键盘上的 6 键。
        NumPad6 = 102,
        //
        // 摘要: 
        //     数字键盘上的 7 键。
        NumPad7 = 103,
        //
        // 摘要: 
        //     数字键盘上的 8 键。
        NumPad8 = 104,
        //
        // 摘要: 
        //     数字键盘上的 9 键。
        NumPad9 = 105,
        //
        // 摘要: 
        //     乘号键。
        Multiply = 106,
        //
        // 摘要: 
        //     加号键。
        Add = 107,
        //
        // 摘要: 
        //     分隔符键。
        Separator = 108,
        //
        // 摘要: 
        //     减号键。
        Subtract = 109,
        //
        // 摘要: 
        //     句点键。
        Decimal = 110,
        //
        // 摘要: 
        //     除号键。
        Divide = 111,
        //
        // 摘要: 
        //     F1 键。
        F1 = 112,
        //
        // 摘要: 
        //     F2 键。
        F2 = 113,
        //
        // 摘要: 
        //     F3 键。
        F3 = 114,
        //
        // 摘要: 
        //     F4 键。
        F4 = 115,
        //
        // 摘要: 
        //     F5 键。
        F5 = 116,
        //
        // 摘要: 
        //     F6 键。
        F6 = 117,
        //
        // 摘要: 
        //     F7 键。
        F7 = 118,
        //
        // 摘要: 
        //     F8 键。
        F8 = 119,
        //
        // 摘要: 
        //     F9 键。
        F9 = 120,
        //
        // 摘要: 
        //     F10 键。
        F10 = 121,
        //
        // 摘要: 
        //     F11 键。
        F11 = 122,
        //
        // 摘要: 
        //     F12 键。
        F12 = 123,
        //
        // 摘要: 
        //     F13 键。
        F13 = 124,
        //
        // 摘要: 
        //     F14 键。
        F14 = 125,
        //
        // 摘要: 
        //     F15 键。
        F15 = 126,
        //
        // 摘要: 
        //     F16 键。
        F16 = 127,
        //
        // 摘要: 
        //     F17 键。
        F17 = 128,
        //
        // 摘要: 
        //     F18 键。
        F18 = 129,
        //
        // 摘要: 
        //     F19 键。
        F19 = 130,
        //
        // 摘要: 
        //     F20 键。
        F20 = 131,
        //
        // 摘要: 
        //     F21 键。
        F21 = 132,
        //
        // 摘要: 
        //     F22 键。
        F22 = 133,
        //
        // 摘要: 
        //     F23 键。
        F23 = 134,
        //
        // 摘要: 
        //     F24 键。
        F24 = 135,
        //
        // 摘要: 
        //     Num Lock 键。
        NumLock = 144,
        //
        // 摘要: 
        //     Scroll Lock 键。
        Scroll = 145,
        //
        // 摘要: 
        //     左 Shift 键。
        LShiftKey = 160,
        //
        // 摘要: 
        //     右 Shift 键。
        RShiftKey = 161,
        //
        // 摘要: 
        //     左 Ctrl 键。
        LControlKey = 162,
        //
        // 摘要: 
        //     右 Ctrl 键。
        RControlKey = 163,
        //
        // 摘要: 
        //     左 Alt 键。
        LMenu = 164,
        //
        // 摘要: 
        //     右 Alt 键。
        RMenu = 165,
        //
        // 摘要: 
        //     浏览器后退键（Windows 2000 或更高版本）。
        BrowserBack = 166,
        //
        // 摘要: 
        //     浏览器前进键（Windows 2000 或更高版本）。
        BrowserForward = 167,
        //
        // 摘要: 
        //     浏览器刷新键（Windows 2000 或更高版本）。
        BrowserRefresh = 168,
        //
        // 摘要: 
        //     浏览器停止键（Windows 2000 或更高版本）。
        BrowserStop = 169,
        //
        // 摘要: 
        //     浏览器搜索键（Windows 2000 或更高版本）。
        BrowserSearch = 170,
        //
        // 摘要: 
        //     浏览器收藏夹键（Windows 2000 或更高版本）。
        BrowserFavorites = 171,
        //
        // 摘要: 
        //     浏览器主页键（Windows 2000 或更高版本）。
        BrowserHome = 172,
        //
        // 摘要: 
        //     静音键（Windows 2000 或更高版本）。
        VolumeMute = 173,
        //
        // 摘要: 
        //     减小音量键（Windows 2000 或更高版本）。
        VolumeDown = 174,
        //
        // 摘要: 
        //     增大音量键（Windows 2000 或更高版本）。
        VolumeUp = 175,
        //
        // 摘要: 
        //     媒体下一曲目键（Windows 2000 或更高版本）。
        MediaNextTrack = 176,
        //
        // 摘要: 
        //     媒体上一曲目键（Windows 2000 或更高版本）。
        MediaPreviousTrack = 177,
        //
        // 摘要: 
        //     媒体停止键（Windows 2000 或更高版本）。
        MediaStop = 178,
        //
        // 摘要: 
        //     媒体播放暂停键（Windows 2000 或更高版本）。
        MediaPlayPause = 179,
        //
        // 摘要: 
        //     启动邮件键（Windows 2000 或更高版本）。
        LaunchMail = 180,
        //
        // 摘要: 
        //     选择媒体键（Windows 2000 或更高版本）。
        SelectMedia = 181,
        //
        // 摘要: 
        //     启动应用程序一键（Windows 2000 或更高版本）。
        LaunchApplication1 = 182,
        //
        // 摘要: 
        //     启动应用程序二键（Windows 2000 或更高版本）。
        LaunchApplication2 = 183,
        //
        // 摘要: 
        //     OEM 1 键。
        Oem1 = 186,
        //
        // 摘要: 
        //     美式标准键盘上的 OEM 分号键（Windows 2000 或更高版本）。
        OemSemicolon = 186,
        //
        // 摘要: 
        //     任何国家/地区键盘上的 OEM 加号键（Windows 2000 或更高版本）。
        Oemplus = 187,
        //
        // 摘要: 
        //     任何国家/地区键盘上的 OEM 逗号键（Windows 2000 或更高版本）。
        Oemcomma = 188,
        //
        // 摘要: 
        //     任何国家/地区键盘上的 OEM 减号键（Windows 2000 或更高版本）。
        OemMinus = 189,
        //
        // 摘要: 
        //     任何国家/地区键盘上的 OEM 句点键（Windows 2000 或更高版本）。
        OemPeriod = 190,
        //
        // 摘要: 
        //     美式标准键盘上的 OEM 问号键（Windows 2000 或更高版本）。
        OemQuestion = 191,
        //
        // 摘要: 
        //     OEM 2 键。
        Oem2 = 191,
        //
        // 摘要: 
        //     美式标准键盘上的 OEM 波形符键（Windows 2000 或更高版本）。
        Oemtilde = 192,
        //
        // 摘要: 
        //     OEM 3 键。
        Oem3 = 192,
        //
        // 摘要: 
        //     OEM 4 键。
        Oem4 = 219,
        //
        // 摘要: 
        //     美式标准键盘上的 OEM 左括号键（Windows 2000 或更高版本）。
        OemOpenBrackets = 219,
        //
        // 摘要: 
        //     美式标准键盘上的 OEM 管道键（Windows 2000 或更高版本）。
        OemPipe = 220,
        //
        // 摘要: 
        //     OEM 5 键。
        Oem5 = 220,
        //
        // 摘要: 
        //     OEM 6 键。
        Oem6 = 221,
        //
        // 摘要: 
        //     美式标准键盘上的 OEM 右括号键（Windows 2000 或更高版本）。
        OemCloseBrackets = 221,
        //
        // 摘要: 
        //     OEM 7 键。
        Oem7 = 222,
        //
        // 摘要: 
        //     美式标准键盘上的 OEM 单/双引号键（Windows 2000 或更高版本）。
        OemQuotes = 222,
        //
        // 摘要: 
        //     OEM 8 键。
        Oem8 = 223,
        //
        // 摘要: 
        //     OEM 102 键。
        Oem102 = 226,
        //
        // 摘要: 
        //     RT 102 键的键盘上的 OEM 尖括号或反斜杠键（Windows 2000 或更高版本）。
        OemBackslash = 226,
        //
        // 摘要: 
        //     Process Key 键。
        ProcessKey = 229,
        //
        // 摘要: 
        //     用于将 Unicode 字符当作键击传递。Packet 键值是用于非键盘输入法的 32 位虚拟键值的低位字。
        Packet = 231,
        //
        // 摘要: 
        //     Attn 键。
        Attn = 246,
        //
        // 摘要: 
        //     Crsel 键。
        Crsel = 247,
        //
        // 摘要: 
        //     Exsel 键。
        Exsel = 248,
        //
        // 摘要: 
        //     ERASE EOF 键。
        EraseEof = 249,
        //
        // 摘要: 
        //     Play 键。
        Play = 250,
        //
        // 摘要: 
        //     Zoom 键。
        Zoom = 251,
        //
        // 摘要: 
        //     保留以备将来使用的常数。
        NoName = 252,
        //
        // 摘要: 
        //     PA1 键。
        Pa1 = 253,
        //
        // 摘要: 
        //     Clear 键。
        OemClear = 254,
        //
        // 摘要: 
        //     从键值提取键代码的位屏蔽。
        KeyCode = 65535,
        //
        // 摘要: 
        //     Shift 修改键。
        Shift = 65536,
        //
        // 摘要: 
        //     Ctrl 修改键。
        Control = 131072,
        //
        // 摘要: 
        //     Alt 修改键。
        Alt = 262144,
    }
}
