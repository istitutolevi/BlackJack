using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace BlackJack.Utilities
{
    internal static class NativeMethods 
    {
        internal const uint WS_EX_STATICEDGE = 0x00020000;
        internal const uint WS_CHILD = 0x40000000;
        internal const uint WS_VISIBLE = 0x10000000;
        internal const uint WS_HSCROLL = 0x00100000;
        internal const uint WS_VSCROLL = 0x00200000;

        internal const int GWL_WNDPROC = -4;

        internal const int WM_ACTIVATEAPP = 0x1C;
        internal const int WM_COMMAND = 0x111;
        internal const int WM_CLOSE = 0x10;
        internal const int WM_DESTROY = 2;
        internal const int WM_DROPFILES = 0x233;
        internal const int WM_ERASEBKGND = 0x14;
        internal const int WM_KEYDOWN = 256;
        internal const int WM_LBUTTONDBLCLK = 515;
        internal const int WM_LBUTTONDOWN = 513;
        internal const int WM_LBUTTONUP = 514;
        internal const int WM_MOVE = 0x3;
        internal const int WM_MOUSEMOVE = 512;
        internal const int WM_MOVING = 0x216;
        internal const int WM_NCHITTEST = 0x0084;
        internal const int WM_NCLBUTTONDOWN = 161;
        internal const int WM_NCLBUTTONDBLCLK = 163;
        internal const int WM_PAINT = 0xF;
        internal const int WM_RBUTTONDOWN = 516;
        internal const int WM_TIMER = 0x113;
        internal const int WM_PRINT = 0x317;
        internal const int WM_PRINTCLIENT = 0x318;
        internal const int WM_SETREDRAW = 0xB;
        internal const int WM_SIZING = 0x214;
        internal const int WM_SIZE = 0x5;
        internal const int WM_USER = 0x400;
        internal const int WM_STRINGDATA = WM_USER + 3;

        internal const int VK_HOME = 36;
        internal const int VK_END = 35;
        internal const int VK_PRIOR = 33;
        internal const int VK_NEXT = 34;
        internal const int VK_LEFT = 37;
        internal const int VK_UP = 38;
        internal const int VK_RIGHT = 39;
        internal const int VK_DOWN = 40;

        internal const int VK_NUMPAD1 = 97;
        internal const int VK_NUMPAD2 = 98;
        internal const int VK_NUMPAD3 = 99;
        internal const int VK_NUMPAD4 = 100;
        internal const int VK_NUMPAD5 = 101;
        internal const int VK_NUMPAD6 = 102;
        internal const int VK_NUMPAD7 = 103;
        internal const int VK_NUMPAD8 = 104;
        internal const int VK_NUMPAD9 = 105;

        internal const int VK_PGUP = 0x21;
        internal const int VK_PGDN = 0x22;

        internal const int GWL_ID = -12;

        internal const int PRF_CLIENT = 0x00000004;
        internal const int PRF_CHILDREN = 0x00000010;

        internal const int HTNOWHERE = 0;
        internal const int HTCLIENT = 1;
        internal const int HTCAPTION = 2;
        internal const int HTSYSMENU = 3;
        internal const int HTGROWBOX = 4;
        internal const int HTMENU = 5;
        internal const int HTHSCROLL = 6;
        internal const int HTVSCROLL = 7;
        internal const int HTMINBUTTON = 8;
        internal const int HTMAXBUTTON = 9;
        internal const int HTLEFT = 10;
        internal const int HTRIGHT = 11;
        internal const int HTTOP = 12;
        internal const int HTTOPLEFT = 13;
        internal const int HTTOPRIGHT = 14;
        internal const int HTBOTTOM = 15;
        internal const int HTBOTTOMLEFT = 16;
        internal const int HTBOTTOMRIGHT = 17;
        internal const int HTBORDER = 18;
        internal const int HTOBJECT = 19;
        internal const int HTCLOSE = 20;
        internal const int HTHELP = 21;
        internal const int MAX_PATH = 260;
        internal const int SRCCOPY = 0x00CC0020;
        internal const int GA_PARENT = 1;
        internal const int GA_ROOT = 2;
        internal const int GA_ROOTOWNER = 3;

        internal const uint SWP_NOSIZE = 0x0001;
        internal const uint SWP_NOMOVE = 0x0002;
        internal const uint SWP_NOREDRAW = 0x0008;
        internal const uint SWP_NOACTIVATE = 0x0010;
        internal const uint SWP_NOOWNERZORDER = 0x0200;  // Don't do owner Z ordering
        internal const uint SWP_NOSENDCHANGING = 0x0400; // Don't send WM_WINDOWPOSCHANGING

        internal const int SW_HIDE = 0;
        internal const int SW_SHOW = 5;
        internal const int SW_RESTORE = 9;

        internal const int RGN_AND = 1;
        internal const int RGN_OR = 2;
        internal const int RGN_XOR = 3;
        internal const int RGN_DIFF = 4;
        internal const int RGN_COPY = 5;
        internal const int RGN_MIN = RGN_AND;
        internal const int RGN_MAX = RGN_COPY;

        internal const int FW_BOLD = 700;

        internal const int SM_CXSCREEN = 0;
        internal const int SM_CYSCREEN = 1;

        private const string USER32 = "User32.DLL";
        private const string GDI32 = "GDI32.DLL";
        private const string KERNEL32 = "kernel32.Dll";
        private const string SHELL32 = "SHELL32.DLL";

        internal struct OSVERSIONINFOEX
        {
            internal int dwOSVersionInfoSize;
            internal int dwMajorVersion;
            internal int dwMinorVersion;
            internal int dwBuildNumber;
            internal int dwPlatformId;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
            internal string szCSDVersion;
            internal ushort wServicePackMajor;
            internal ushort wServicePackMinor;
            internal ushort wSuiteMask;
            internal byte wProductType;
            internal byte wReserved;
        }

        [StructLayout(LayoutKind.Explicit)]
        internal struct RECT
        {
            [FieldOffset(0)]
            internal int left;
            [FieldOffset(4)]
            internal int top;
            [FieldOffset(8)]
            internal int right;
            [FieldOffset(12)]
            internal int bottom;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct POINT
        {
            internal int x;
            internal int y;
        }

        internal static int RGB(byte R, byte G, byte B) { return ((B * 256) + G) * 256 + R; }
        internal static int ARGB(byte A, byte R, byte G, byte B) { return (((A * 256) + R) * 256 + G) * 256 + B; }

        internal static byte RGBRed(int colrRGB) { return (byte)(colrRGB & 0x000000FF); }
        internal static byte RGBGreen(int colrRGB) { return (byte)((colrRGB >> 8) & 0x000000FF); }
        internal static byte RGBBlue(int colrRGB) { return (byte)((colrRGB >> 16) & 0x000000FF); }
        internal static int LoWrd(uint value) { return (int)(value & 0xFFFF); }
        internal static int HiWrd(uint value) { return (int)(value >> 16); }
        internal static int MakeLong(int nLow, int nHigh) { return nLow + nHigh * 65536; }

        [DllImport(USER32, EntryPoint = "CreateWindowExA", CharSet = CharSet.Unicode)]
        internal static extern IntPtr CreateWindowEx(
            uint ExStyle,
            string ClassName,
            string Name,
            uint Style,
            int x,
            int y,
            int w,
            int h,
            IntPtr parent,
            int Menu,
            IntPtr Instance,
            int lpParam);

        internal static string ExePath()
        {
            return Application.StartupPath.TrimEnd('\\') + @"\";
        }

        [DllImport(USER32)] // Win32 encapsulation
        internal static extern bool PtInRect(ref RECT r, POINT p);

        [DllImport(USER32)] // Win32 encapsulation
        internal static extern int GetWindowDC(IntPtr hWnd);

        [DllImport(USER32)]
        internal static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport(GDI32)]
        internal static extern int BitBlt(
        int hDCDest, int xDest, int yDest, int Width, int Heifght,
        int hDCSrce, int xSrce, int ySrce, int CopyMode
        );

        [DllImport(KERNEL32, EntryPoint = "GetModuleHandleA", CharSet = CharSet.Unicode)]
        internal static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport(USER32)]
        internal static extern IntPtr GetWindow(IntPtr hWnd, int wCmd);

        [DllImport(USER32)]
        internal static extern IntPtr GetParent(IntPtr hWnd);

        [DllImport(SHELL32)]
        internal static extern void DragAcceptFiles(IntPtr hWnd, bool fAccept);

        [DllImport(SHELL32)]
        internal static extern void DragFinish(uint hDrop);

        [DllImport(SHELL32, EntryPoint = "DragQueryFileA")]
        internal static extern int DragQueryFile(uint hDrop, int uiFile, StringBuilder lpStr, int cch);

        [DllImport(USER32)]
        internal static extern int GetDC(IntPtr hWnd);

        [DllImport(USER32)]
        internal static extern int GetKeyboardState(byte[] keystate);

        [DllImport(USER32)]
        internal static extern bool ReleaseDC(IntPtr hWnd, int hDC);

        internal delegate void TimerProc(IntPtr hWnd, uint nMsg, int nIDEvent, int dwTime);
        [DllImport(USER32)]
        internal static extern int SetTimer(IntPtr hWnd, int nIDEvent, int uElapse, TimerProc callback);

        [DllImport(USER32)]
        internal static extern bool KillTimer(IntPtr hWnd, int nIDEvent);

        [DllImport(USER32)]
        internal static extern bool GetWindowRect(IntPtr hWnd, ref RECT rw);

        [DllImport(USER32)]
        internal static extern bool IsIconic(IntPtr hWnd);

        [DllImport(USER32)]
        static internal extern bool ValidateRect(IntPtr hWnd, ref RECT rw);

        [DllImport(USER32)]
        internal static extern bool GetClientRect(IntPtr hWnd, ref RECT rc);

        [DllImport(USER32, EntryPoint = "PostMessageA")] // Win32 encapsulation
        internal static extern int PostMessage(IntPtr hWnd, uint dwMsg, uint wParam, int lParam);

        [DllImport(USER32)]
        internal static extern bool SetLayeredWindowAttributes(IntPtr hWnd, int crKey, byte bAlpha, int dwFlags);

        [DllImport(USER32)]
        internal static extern IntPtr GetDesktopWindow();

        [DllImport(USER32)]
        internal static extern bool MoveWindow(IntPtr hWnd, int x, int y, int nWidth, int nHeight, bool bRepaint);

        [DllImport(USER32)]
        internal static extern bool SetWindowPos(
            IntPtr hWnd,               // window handle
            IntPtr hWndInsertAfter,    // placement-order handle
            int X,                     // horizontal position
            int Y,                     // vertical position
            int cx,                    // width
            int cy,                    // height
            uint uFlags);              // window positioning flags

        [DllImport(USER32)]
        internal static extern bool IsWindow(IntPtr hWnd);

        [DllImport(USER32, EntryPoint = "GetClassLongA")]
        internal static extern int GetClassLong(IntPtr hWnd, int nIndex);

        [DllImport(USER32, EntryPoint = "SetClassLongA")]
        internal static extern int SetClassLong(IntPtr hWnd, int nIndex, int lNewLong);

        [DllImport(USER32)] // Win32 encapsulation
        internal static extern bool GetWindowRgn(IntPtr hWnd, IntPtr hRgn);

        [DllImport(GDI32)] // Win32 encapsulation
        internal static extern IntPtr CreateRectRgn(int x1, int y1, int x2, int y2);

        [DllImport(USER32)] // Win32 encapsulation
        internal static extern bool SetWindowRgn(IntPtr hWnd, IntPtr hRgn, bool bRedraw);

        [DllImport(GDI32)]  // Win32 encapsulation
        internal static extern bool OffsetRgn(IntPtr hRgn, int x, int y);

        [DllImport(GDI32)]
        internal static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont, IntPtr pdv, [In] ref uint pcFonts);


        [DllImport(GDI32)]  // Win32 encapsulation
        internal static extern bool DeleteObject(IntPtr hObject);

        [DllImport(GDI32)]  // Win32 encapsulation
        internal static extern bool CombineRgn(IntPtr hDestRgn, IntPtr hSrcRgn1, IntPtr hSrcRgn2, int nCombineMode);

        [DllImport(KERNEL32)]
        internal static extern bool GetVersionEx(ref OSVERSIONINFOEX o);

        unsafe internal static int GetOsVersion()
        {
            OSVERSIONINFOEX os = new OSVERSIONINFOEX();
            int nRet = 0;
            os.dwOSVersionInfoSize = Marshal.SizeOf(typeof(OSVERSIONINFOEX)); // SIZEOF
            if (GetVersionEx(ref os))
            {
                switch (os.dwPlatformId)
                {
                    case 1:
                        nRet = os.dwPlatformId;
                        switch (os.dwMinorVersion)
                        {
                            case 0:
                                nRet = 95;   // 95
                                break;
                            case 10:
                                nRet = 98;  // 98
                                break;
                            case 90:
                                nRet = 100; // ME
                                break;
                        }
                        break;
                    case 2:
                        nRet = os.dwPlatformId;
                        switch (os.dwMajorVersion)
                        {
                            case 3:
                                nRet = 351; // NT 3.51
                                break;
                            case 4:
                                nRet = 400; // NT 4.0
                                break;
                            case 5:
                                nRet = 500;     // 2000
                                if (os.dwMinorVersion == 1)
                                {
                                    nRet = 501; // XP
                                }
                                break;
                            case 6:
                                nRet = 600;     // VISTA
                                break;
                        }
                        break;
                    default:
                        nRet = -1;
                        break;
                }
            }
            return nRet;
        }

        // Using Drop Shadow slows down display when using large window.
        internal static void UseDropShadow(IntPtr hWnd)
        {
            // Get the Operating System 
            if (GetOsVersion() > 499)
            { // OS NT only
                if (IsWindow(hWnd))
                {
                    int GCL_STYLE = -26;
                    int CS_DROPSHADOW = 131072;
                    int ClassLong = GetClassLong(hWnd, GCL_STYLE);
                    if ((ClassLong & CS_DROPSHADOW) == 0)
                    {
                        ClassLong += CS_DROPSHADOW;
                        SetClassLong(hWnd, GCL_STYLE, ClassLong);
                    }
                }

                //int WS_EX_COMPOSITED = 0x02000000;
                //int GWL_EXSTYLE = -20;
                //int WindowLong = GetWindowLong(hWnd, GWL_EXSTYLE);
                //SetWindowLong(hWnd, GWL_EXSTYLE, WindowLong | WS_EX_COMPOSITED);
            }
        }

        internal static void ButtonClick(IntPtr hButton)
        {
            PostMessage(hButton, WM_LBUTTONDOWN, 0, 0);
            PostMessage(hButton, WM_LBUTTONUP, 0, 0);
        }

        [DllImport(USER32)] // Win32 encapsulation
        internal static extern IntPtr GetDlgItem(IntPtr hCtrl, int DlgItem);

        [DllImport(USER32, EntryPoint = "GetAncestor")]
        internal static extern IntPtr GetAncestor(IntPtr hWnd, int GA_Flag);

        [DllImport(USER32, EntryPoint = "GetWindowLongA")]
        internal static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport(USER32, EntryPoint = "SetWindowLongA")]
        internal static extern int SetWindowLong(IntPtr hWnd, int nIndex, int lNewLong);

        [DllImport(USER32, EntryPoint = "SendMessageA")]
        internal static extern int SendMessage(IntPtr hWnd, int dwMsg, uint wParam, int lParam);

        [DllImport(USER32, EntryPoint = "CallWindowProcA")]
        internal static extern int CallWindowProc(int lpPrevWndFunc, IntPtr hWnd, int uMsg, uint wParam, uint lParam);

        //[DllImport(USER32)]
        //internal static extern bool InvalidateRect(IntPtr hWnd, int lprec, int erase);

        //[DllImport(USER32)]
        //internal static extern bool UpdateWindow(IntPtr hWnd);

        //[DllImport(USER32, EntryPoint = "SendMessageA")] // Win32 encapsulation
        //internal static extern int SendMessage(IntPtr hWnd, uint dwMsg, uint wParam, int lParam);

        //[DllImport(USER32)] // Win32 encapsulation
        //private static extern IntPtr GetSysColorBrush(int nIndex);

        //[DllImport(USER32, EntryPoint = "SetWindowTextA", CharSet = CharSet.Unicode)]
        //internal static extern int SetWindowText(IntPtr hWnd, string lpString);

        [DllImport(USER32)]
        internal static extern int GetDlgCtrlID(IntPtr hWnd);

        [DllImport(USER32)]
        internal static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport(USER32)]
        internal static extern IntPtr GetForegroundWindow();

        [DllImport(USER32)]
        internal static extern IntPtr SetFocus(IntPtr hWnd);

        [DllImport(USER32)]
        internal static extern IntPtr GetFocus();

        [DllImport(USER32)]
        internal static extern bool LockWindowUpdate(IntPtr hWndLock);

        [DllImport(USER32)]
        internal static extern IntPtr BeginDeferWindowPos(int nNumWindows);

        [DllImport(USER32)]
        internal static extern bool ShowCursor(bool bShow);

        [DllImport(USER32)]
        internal static extern bool DeferWindowPos(
            IntPtr hWinPosInfo,
            IntPtr hWnd,               // window handle
            IntPtr hWndInsertAfter,    // placement-order handle
            int X,                     // horizontal position
            int Y,                     // vertical position
            int cx,                    // width
            int cy,                    // height
            uint uFlags);              // window positioning flags

        [DllImport(USER32)]
        internal static extern bool EndDeferWindowPos(IntPtr hWinPosInfo);

        [DllImport(USER32)]
        internal static extern int GetSystemMetrics(int abc);

        internal static void ControlDrawingDisable(IntPtr hWnd)
        {
            SendMessage(hWnd, WM_SETREDRAW, 0, 0);
        }
        internal static void ControlDrawingEnable(IntPtr hWnd)
        {
            SendMessage(hWnd, WM_SETREDRAW, 1, 0);
            Control.FromHandle(hWnd).Refresh();
        }

    }
}

