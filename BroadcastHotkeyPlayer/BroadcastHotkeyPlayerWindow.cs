using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BroadcastHotkeyPlayer
{
    public partial class BroadcastHotkeyPlayerWindow : Form
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);
         
        private BroadcastHotkeyPlayer player = new BroadcastHotkeyPlayer();
        private BroadcastHotkeyPlayerNetListen listener;
        private BroadcastHotkeyPlayerNetSend sender = new BroadcastHotkeyPlayerNetSend();

        private static int WM_HOTKEY = 0x0312;

        private bool fstDigitRecorded = false;
        private int fstDigit = 0;

        enum KeyModifier
        {
            NOMOD = 0x0000,
            ALT = 0x0001,
            CTRL = 0x0002,
            SHIFT = 0x0004,
            WIN = 0x0008
        }

        public BroadcastHotkeyPlayerWindow()
        {
            Console.WriteLine("est");
            InitializeComponent();
            listener = new BroadcastHotkeyPlayerNetListen(this);
            
            mynotifyIcon.BalloonTipText = "Listening for Hotkeys...";
            mynotifyIcon.BalloonTipTitle = "BroadcastHotkeyPlayer";
            mynotifyIcon.BalloonTipIcon = ToolTipIcon.Info;
            
            RegisterHotKey(this.Handle, 0, (int)KeyModifier.CTRL, (int)Keys.NumPad0);
            RegisterHotKey(this.Handle, 1, (int)KeyModifier.CTRL, (int)Keys.NumPad1);
            RegisterHotKey(this.Handle, 2, (int)KeyModifier.CTRL, (int)Keys.NumPad2);
            RegisterHotKey(this.Handle, 3, (int)KeyModifier.CTRL, (int)Keys.NumPad3);
            RegisterHotKey(this.Handle, 4, (int)KeyModifier.CTRL, (int)Keys.NumPad4);
            RegisterHotKey(this.Handle, 5, (int)KeyModifier.CTRL, (int)Keys.NumPad5);
            RegisterHotKey(this.Handle, 6, (int)KeyModifier.CTRL, (int)Keys.NumPad6);
            RegisterHotKey(this.Handle, 7, (int)KeyModifier.CTRL, (int)Keys.NumPad7);
            RegisterHotKey(this.Handle, 8, (int)KeyModifier.CTRL, (int)Keys.NumPad8);
            RegisterHotKey(this.Handle, 9, (int)KeyModifier.CTRL, (int)Keys.NumPad9);

            listener.StartListener();
        }
         
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == WM_HOTKEY)
            { 
                Keys key = (Keys)(((int)m.LParam >> 16) & 0xFFFF);                  // The key of the hotkey that was pressed.
                KeyModifier modifier = (KeyModifier)((int)m.LParam & 0xFFFF);       // The modifier of the hotkey that was pressed.
                int id = m.WParam.ToInt32();                                        // The id of the hotkey that was pressed.

                if (fstDigitRecorded == false)
                {
                    fstDigitRecorded = true;
                    fstDigit = id;
                }
                else if (fstDigitRecorded)
                {
                    sender.Send("" + fstDigit + id);
                    fstDigitRecorded = false;
                }
                /*
                if (id == 2)
                    fstDigitRecorded = true;
                else if (id == 5 && fstDigitRecorded)
                    sender.Send("25");
                else
                    fstDigitRecorded = false;
                */
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState)
            {
                mynotifyIcon.Visible = true;
                mynotifyIcon.ShowBalloonTip(500);
                this.Hide();
            }
            else if (FormWindowState.Normal == this.WindowState)
            {
                mynotifyIcon.Visible = false;
            }
        }

        private void mynotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void play()
        {
            try
            {
                player.LoadSoundAsync();
            }
            catch (Exception e)
            {
                MessageBox.Show("unable to laod sound: {0}", e.ToString());
            }
        }
    }
}
