using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Guitar_Hero_Player
{
	public partial class Form1 : Form
	{
		[DllImport("User32.dll")]
		static extern int SetForegroundWindow(IntPtr point);

		[DllImport("user32.dll")]
		private static extern int SendMessage(IntPtr hWnd, int Msg, uint wParam, int lParam);

		public const ushort WM_KEYDOWN = 0x0100;
		public const ushort WM_KEYUP = 0x0101;
		public const ushort WM_CHAR = 0x102;

		private DebugForm _debugForm;
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			_debugForm = new DebugForm();
			_debugForm.Show();
		}

		public Form1()
		{
			InitializeComponent();
		}

		private long ticks = 0;
		private void timer1_Tick(object sender, EventArgs e)
		{
			AnalyseScreenShot();
			//AnalyseImage();
		}

		private void AnalyseImage()
		{
			ticks++;
			//var screenShot = new Bitmap("C:\\Temp\\good images\\2021_28_14_22_28_16_45.png");
			var screenShot = new Bitmap("C:\\Temp\\good images\\good4.png");
			//var screenShot = new Bitmap("C:\\Temp\\good images\\2021_27_14_22_27_57_36.png");
			
			if (screenShot != null)
			{
				Analyse(screenShot);
				if ((ticks % 15) == 0)
				{
					var g = CreateGraphics();
					g.DrawImage(screenShot, 0, 0);
				}
			}
		}

		private void AnalyseScreenShot()
		{
			ticks++;
			var screenShot = ScreenShot.GetPS3ScreenShot();
			if (screenShot != null)
			{
				_debugForm.AddImage(screenShot);
				Analyse(screenShot);
				if ((ticks % 15) == 0)
				{
					var g = CreateGraphics();
					g.DrawImage(screenShot, 0, 0);
				}
			}
		}

		private void Analyse(Image screenShot)
		{
			var bmp = new Bitmap(screenShot);
			if(active==null)
			{
				active = new Dictionary<string, bool>();
				active.Add(pnlGreen.Name, false);
				active.Add(pnlYellow.Name, false);
				active.Add(pnlRed.Name, false);
			}
			AnalysePanel(bmp, pnlGreen, Color.Green, 0.35f, 'r');
			AnalysePanel(bmp, pnlRed, Color.Red, 0.35f, 'q');
			AnalysePanel(bmp, pnlYellow, Color.Yellow, 0.35f, 'e');
			//AnalysePanel(bmp, pnlBlue, Color.Blue, 0, 't');
			//AnalysePanel(bmp, pnlOrange, Color.Orange, 0, 'x');
		}
		Dictionary<string, bool> active = null;
		private void AnalysePanel(Bitmap image, Panel panel, Color baseColor, float threshold, char key)
		{
			var value = ImageAnalyser.AnalysePanel(image, panel);
			_debugForm.UpdateValue(panel.Name, value);

			if (value > threshold)
			{
				_debugForm.Debug($"{panel.Name} active - {value}");
				new Task(() =>
				{
					System.Threading.Thread.Sleep(100);
					SendKeyDown(key);
				}).Start();			
				active[panel.Name] = true;
			}
			else if (active[panel.Name])
			{
				new Task(() =>
				{
					System.Threading.Thread.Sleep(100);
					SendKeyUp(key);
				}).Start();
				_debugForm.Debug($"{panel.Name} not active - {value}");
				active[panel.Name] = false;
			}
			//if (value > colorThreshold && !greenButtonDown)
			//{
			//	//SendKeyToWindow(key);
			//	SendKeyDown(key);
			//	greenButtonDown = true;
			//}
			//else if (value < colorThreshold && greenButtonDown)
			//{
			//	SendKeyUp(key);
			//	greenButtonDown = false;
			//}
		}

		private void SendKeyToWindow(char key)
		{
			//var p = Process.GetProcessesByName("rpcs3").FirstOrDefault();
			//if (p != null)
			//{
			//	IntPtr h = p.MainWindowHandle;
			//	SetForegroundWindow(h);
			//	SendKeys.SendWait(key);
			//}
		}

		private void SendKeyDown(char key)
		{
			var p = Process.GetProcessesByName("rpcs3").FirstOrDefault();

			if(key=='r')
			{
				SendMessage(p.MainWindowHandle, WM_KEYDOWN, (int)Keys.R, 2949121);
			}
			else if(key=='q')
			{
				SendMessage(p.MainWindowHandle, WM_KEYDOWN, (int)Keys.Q, 2949121);
			}
			else if(key=='e')
			{
				SendMessage(p.MainWindowHandle, WM_KEYDOWN, (int)Keys.E, 2949121);
			}
			
			SendMessage(p.MainWindowHandle, WM_CHAR, key, 2949121);

			//var p = Process.GetProcessesByName("rpcs3").FirstOrDefault();
			//var p = Process.GetProcessesByName("notepad").FirstOrDefault();
			//if (p != null)
			//{
			//	//IntPtr h = p.MainWindowHandle;
			//	WindowsAPI.SwitchWindow(p.MainWindowHandle);
			//	System.Threading.Thread.Sleep(2000);
			//	//SetForegroundWindow(h);
			//	_debugForm.Debug($"Send key down: {key}");
			//	byte vk = WindowsAPI.VkKeyScan(key);
			//	ushort scanCode = (ushort)WindowsAPI.MapVirtualKey(vk, 0);

			//	INPUT[] inputs = new INPUT[1];
			//	inputs[0].type = WindowsAPI.INPUT_KEYBOARD;
			//	inputs[0].ki.dwFlags = WindowsAPI.KEYEVENTF_KEYDOWN | WindowsAPI.KEYEVENTF_SCANCODE;
			//	inputs[0].ki.wScan = 0x11;//(ushort)(scanCode & 0xff);

			//	uint intReturn = WindowsAPI.SendInput(1, inputs, Marshal.SizeOf(inputs[0]));
			//	if (intReturn != 1)
			//	{
			//		throw new Exception("Could not send key: " + scanCode);
			//	}
			//}
		}

		private void SendKeyUp(char key)
		{
			var p = Process.GetProcessesByName("rpcs3").FirstOrDefault();

			if (key == 'r')
			{
				SendMessage(p.MainWindowHandle, WM_KEYUP, (int)Keys.R, 2949121);
			}
			else if (key == 'q')
			{
				SendMessage(p.MainWindowHandle, WM_KEYUP, (int)Keys.Q, 2949121);
			}
			else if (key == 'e')
			{
				SendMessage(p.MainWindowHandle, WM_KEYUP, (int)Keys.E, 2949121);
			}

			
			//var p = Process.GetProcessesByName("rpcs3").FirstOrDefault();
			//var p = Process.GetProcessesByName("notepad").FirstOrDefault();
			//if (p != null)
			//{
			//	//IntPtr h = p.MainWindowHandle;
			//	//SetForegroundWindow(h);
			//	WindowsAPI.SwitchWindow(p.MainWindowHandle);
			//	_debugForm.Debug($"Send key up: {key}");
			//	byte vk = WindowsAPI.VkKeyScan(key);
			//	ushort scanCode = (ushort)WindowsAPI.MapVirtualKey(vk, 0);
			//	INPUT[] inputs = new INPUT[1];
			//	inputs[0].type = WindowsAPI.INPUT_KEYBOARD;
			//	inputs[0].ki.wScan = 0x11;// scanCode;
			//	inputs[0].ki.dwFlags = WindowsAPI.KEYEVENTF_KEYUP | WindowsAPI.KEYEVENTF_SCANCODE;
			//	uint intReturn = WindowsAPI.SendInput(1, inputs, Marshal.SizeOf(inputs[0]));
			//	if (intReturn != 1)
			//	{
			//		throw new Exception("Could not send key: " + scanCode);
			//	}
			//}
		}

		private Point start;

		private void Panel_MouseDown(object sender, MouseEventArgs e)
		{
			var panel = sender as Panel;
			panel.MouseMove += Panel_MouseMove;
			panel.MouseUp += Panel_MouseUp;
			start = e.Location;
			_debugForm.Debug("\r\nMouse Down: "+panel.Name);
		}

		private void Panel_MouseUp(object sender, MouseEventArgs e)
		{
			var panel = sender as Panel;
			_debugForm.Debug("\r\nMouse Up: " + panel.Name + "(" + panel.Location.X + ", " + panel.Location.Y + ")");
			panel.MouseMove -= Panel_MouseMove;
			panel.MouseUp -= Panel_MouseUp;
		}

		private void Panel_MouseMove(object sender, MouseEventArgs e)
		{
			var panel = sender as Panel;
			_debugForm.Debug("Mouse move: " + panel.Name);
			panel.Location = new Point(panel.Location.X - (start.X - e.X), panel.Location.Y - (start.Y - e.Y));
		}
	}
}