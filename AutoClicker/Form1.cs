using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using Gma.System.MouseKeyHook;

namespace Autoclicker
{
    public partial class Form1 : Form
    {
        private bool isClicking = false;
        private int delay = 100;
        private string clickType = "Left";
        private Thread? clickThread;
        private Thread? spinThread;
        private IKeyboardMouseEvents hook;
        private Keys customHotkey = Keys.F8;
        private Keys customToggleVisibilityKey = Keys.F9; 

        private bool isSpinning = false;
        private double angle = 0.0;
        private const int RADIUS_X = 40;
        private const int RADIUS_Y = 20;

        private NotifyIcon trayIcon = new NotifyIcon(); 
        private ContextMenuStrip trayMenu = new ContextMenuStrip();

        private bool exitingFromTray = false;

        [DllImport("user32.dll")]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, int dwExtraInfo);

        private const uint MOUSEEVENTF_LEFTDOWN = 0x0002;
        private const uint MOUSEEVENTF_LEFTUP = 0x0004;
        private const uint MOUSEEVENTF_RIGHTDOWN = 0x0008;
        private const uint MOUSEEVENTF_RIGHTUP = 0x0010;

        public Form1()
        {
            InitializeComponent();
            InitializeTrayIcon();
            cmbClickType.Items.AddRange(new string[] { "Left", "Right", "Left Double", "Right Double" });
            cmbClickType.SelectedIndex = 0;
            txtDelay.Text = "100"; 
            hook = Hook.GlobalEvents(); 
            hook.KeyDown += Hook_KeyDown; 
        }

        private void InitializeTrayIcon()
        {
            trayMenu.Items.Add("Show", null, TrayIcon_Show);
            trayMenu.Items.Add("Exit", null, TrayIcon_Exit);

            trayIcon.Text = "Auto Clicker";
            trayIcon.Icon = new Icon("icon.ico");
            trayIcon.ContextMenuStrip = trayMenu;
            trayIcon.DoubleClick += TrayIcon_DoubleClick;
            trayIcon.Visible = true;
        }

        private void TrayIcon_DoubleClick(object? sender, EventArgs e)
        {
            ShowForm();
        }

        private void TrayIcon_Show(object? sender, EventArgs e)
        {
            ShowForm();
        }

        private void TrayIcon_Exit(object? sender, EventArgs e)
        {
            exitingFromTray = true;
            Close();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (!exitingFromTray)
            {
                e.Cancel = true; 
                HideForm();
            }
            else
            {
                trayIcon.Visible = false;
                base.OnFormClosing(e);
            }
        }

        private void HideForm()
        {
            Hide();
            WindowState = FormWindowState.Minimized;
        }

        private void ShowForm()
        {
            Show();
            WindowState = FormWindowState.Normal;
            BringToFront();
        }

        private void Hook_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == customHotkey)
            {
                ToggleClicking();
            }
            else if (e.KeyCode == customToggleVisibilityKey)
            {
                ToggleVisibility();
            }
        }

        private void ToggleVisibility()
        {
            if (WindowState == FormWindowState.Minimized || !Visible)
            {
                ShowForm();
            }
            else
            {
                HideForm();
            }
        }

        private void btnStartStop_Click(object sender, EventArgs e)
        {
            ToggleClicking();
        }

        private void ToggleClicking()
        {
            isClicking = !isClicking;

            if (isClicking)
            {
                btnStartStop.Text = "Stop";
                StartClicking();
            }
            else
            {
                btnStartStop.Text = "Start";
                StopClicking();
            }
        }

        private void StartClicking()
        {
            clickThread = new Thread(() =>
            {
                while (isClicking)
                {
                    try
                    {
                        delay = int.Parse(txtDelay.Text);
                        clickType = cmbClickType.SelectedItem?.ToString() ?? "Left";
                        PerformClick();
                        Thread.Sleep(delay);
                    }
                    catch
                    {
                        MessageBox.Show("An error occurred while clicking.");
                    }
                }
            });

            clickThread.Start();

            if (isSpinning)
            {
                StartSpinning();
            }
        }

        private void StopClicking()
        {
            isClicking = false;
            if (clickThread != null && clickThread.IsAlive)
            {
                clickThread.Join();
            }

            if (spinThread != null && spinThread.IsAlive)
            {
                spinThread.Join();
            }
        }

        private void PerformClick()
        {
            switch (clickType)
            {
                case "Left":
                    mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
                    mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
                    break;
                case "Right":
                    mouse_event(MOUSEEVENTF_RIGHTDOWN, 0, 0, 0, 0);
                    mouse_event(MOUSEEVENTF_RIGHTUP, 0, 0, 0, 0);
                    break;
                case "Left Double":
                    mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
                    mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
                    Thread.Sleep(50);
                    mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
                    mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
                    break;
                case "Right Double":
                    mouse_event(MOUSEEVENTF_RIGHTDOWN, 0, 0, 0, 0);
                    mouse_event(MOUSEEVENTF_RIGHTUP, 0, 0, 0, 0);
                    Thread.Sleep(50);
                    mouse_event(MOUSEEVENTF_RIGHTDOWN, 0, 0, 0, 0);
                    mouse_event(MOUSEEVENTF_RIGHTUP, 0, 0, 0, 0);
                    break;
            }
        }

        private void StartSpinning()
        {
            spinThread = new Thread(() =>
            {
                while (isClicking && isSpinning)
                {
                    Cursor.Position = MoveMouseCircle(Cursor.Position);
                    Thread.Sleep(50);
                }
            });

            spinThread.Start();
        }

        private Point MoveMouseCircle(Point currentPos)
        {
            int newX = currentPos.X + (int)(RADIUS_X * Math.Cos(angle * Math.PI / 180));
            int newY = currentPos.Y + (int)(RADIUS_Y * Math.Sin(angle * Math.PI / 180));

            angle += 10.0;
            if (angle >= 360.0)
            {
                angle = 0.0;
            }

            return new Point(newX, newY);
        }

        private void chkSpinning_CheckedChanged(object sender, EventArgs e)
        {
            isSpinning = chkSpinning.Checked;

            if (isSpinning && isClicking)
            {
                StartSpinning();
            }
        }

        private void cmbClickType_SelectedIndexChanged(object sender, EventArgs e)
        {
            clickType = cmbClickType.SelectedItem?.ToString() ?? "Left";
        }

        private void txtHotkey_KeyDown(object sender, KeyEventArgs e)
        {
            customHotkey = e.KeyCode; 
            txtHotkey.Text = customHotkey.ToString();
        }
    }
}
