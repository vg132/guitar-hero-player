using System;
using System.Drawing;

namespace Guitar_Hero_Player
{
	public static class ScreenShot
	{
		public static Image GetPS3ScreenShot(IntPtr handle)
		{
			var hdcSrc = WindowsAPI.GetWindowDC(handle);
			var windowRect = new WindowsAPI.RECT();
			WindowsAPI.GetWindowRect(handle, ref windowRect);
			var width = windowRect.right - windowRect.left;
			var height = windowRect.bottom - windowRect.top;
			var hdcDest = WindowsAPI.CreateCompatibleDC(hdcSrc);
			var hBitmap = WindowsAPI.CreateCompatibleBitmap(hdcSrc, width, height);
			var hOld = WindowsAPI.SelectObject(hdcDest, hBitmap);
			WindowsAPI.BitBlt(hdcDest, 0, 0, width, height, hdcSrc, 0, 0, WindowsAPI.SRCCOPY);
			WindowsAPI.SelectObject(hdcDest, hOld);
			WindowsAPI.DeleteDC(hdcDest);
			WindowsAPI.ReleaseDC(handle, hdcSrc);
			var image = Image.FromHbitmap(hBitmap);
			WindowsAPI.DeleteObject(hBitmap);
			return image;
		}
	}
}