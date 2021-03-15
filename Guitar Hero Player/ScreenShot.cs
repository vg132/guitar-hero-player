using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;

namespace Guitar_Hero_Player
{
	public static class ScreenShot
	{
		[DllImport("User32.dll")]
		static extern int SetForegroundWindow(IntPtr point);

		[DllImport("user32.dll")]
		private static extern IntPtr GetForegroundWindow();

		[DllImport("user32.dll")]
		private static extern IntPtr GetWindowRect(IntPtr hWnd, ref Rect rect);

		[StructLayout(LayoutKind.Sequential)]
		private struct Rect
		{
			public int Left;
			public int Top;
			public int Right;
			public int Bottom;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct RECT
		{
			public int left;
			public int top;
			public int right;
			public int bottom;
		}
		[DllImport("user32.dll")]
		private static extern IntPtr GetDesktopWindow();
		[DllImport("user32.dll")]
		private static extern IntPtr GetWindowDC(IntPtr hWnd);
		[DllImport("user32.dll")]
		private static extern IntPtr ReleaseDC(IntPtr hWnd, IntPtr hDC);
		[DllImport("user32.dll")]
		private static extern IntPtr GetWindowRect(IntPtr hWnd, ref RECT rect);

		public const int SRCCOPY = 0x00CC0020; // BitBlt dwRop parameter
		[DllImport("gdi32.dll")]
		private static extern bool BitBlt(IntPtr hObject, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hObjectSource, int nXSrc, int nYSrc, int dwRop);
		[DllImport("gdi32.dll")]
		private static extern IntPtr CreateCompatibleBitmap(IntPtr hDC, int nWidth, int nHeight);
		[DllImport("gdi32.dll")]
		private static extern IntPtr CreateCompatibleDC(IntPtr hDC);
		[DllImport("gdi32.dll")]
		private static extern bool DeleteDC(IntPtr hDC);
		[DllImport("gdi32.dll")]
		private static extern bool DeleteObject(IntPtr hObject);
		[DllImport("gdi32.dll")]
		private static extern IntPtr SelectObject(IntPtr hDC, IntPtr hObject);

		public static Image GetPS3ScreenShot()
		{
			var process = Process.GetProcessesByName("rpcs3").FirstOrDefault();
			if (process == null)
			{
				return null;
			}
			var handle = process.MainWindowHandle;
			var hdcSrc = GetWindowDC(handle);
			var windowRect = new RECT();
			GetWindowRect(handle, ref windowRect);
			var width = windowRect.right - windowRect.left;
			var height = windowRect.bottom - windowRect.top;
			var hdcDest = CreateCompatibleDC(hdcSrc);
			var hBitmap = CreateCompatibleBitmap(hdcSrc, width, height);
			var hOld = SelectObject(hdcDest, hBitmap);
			BitBlt(hdcDest, 0, 0, width, height, hdcSrc, 0, 0, SRCCOPY);
			SelectObject(hdcDest, hOld);
			DeleteDC(hdcDest);
			ReleaseDC(handle, hdcSrc);
			var image = Image.FromHbitmap(hBitmap);
			DeleteObject(hBitmap);
			return image;
		}
	}
}