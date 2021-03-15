using System;
using System.Runtime.InteropServices;

namespace Guitar_Hero_Player
{
  public class WindowsAPI
  {
    [DllImport("user32.dll")]
    public static extern int SendMessage(IntPtr hWnd, int Msg, uint wParam, int lParam);

		[DllImport("user32.dll")]
		public static extern IntPtr GetWindowDC(IntPtr hWnd);

		[DllImport("user32.dll")]
		public static extern IntPtr ReleaseDC(IntPtr hWnd, IntPtr hDC);

		[DllImport("user32.dll")]
		public static extern IntPtr GetWindowRect(IntPtr hWnd, ref RECT rect);

		[DllImport("gdi32.dll")]
		public static extern bool BitBlt(IntPtr hObject, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hObjectSource, int nXSrc, int nYSrc, int dwRop);

		[DllImport("gdi32.dll")]
		public static extern IntPtr CreateCompatibleBitmap(IntPtr hDC, int nWidth, int nHeight);

		[DllImport("gdi32.dll")]
		public static extern IntPtr CreateCompatibleDC(IntPtr hDC);

		[DllImport("gdi32.dll")]
		public static extern bool DeleteDC(IntPtr hDC);

		[DllImport("gdi32.dll")]
		public static extern bool DeleteObject(IntPtr hObject);

		[DllImport("gdi32.dll")]
		public static extern IntPtr SelectObject(IntPtr hDC, IntPtr hObject);

		#region Structs

		[StructLayout(LayoutKind.Sequential)]
		public struct RECT
		{
			public int left;
			public int top;
			public int right;
			public int bottom;
		}

		#endregion

		#region Messages

		public const ushort WM_KEYDOWN = 0x0100;
    public const ushort WM_KEYUP = 0x0101;
    public const ushort WM_CHAR = 0x102;

		#endregion

		#region Constants

		public const int SRCCOPY = 0x00CC0020; // BitBlt dwRop parameter
		public const int KEY_LPARAM = 0x002D0001;

		#endregion
	}
}
