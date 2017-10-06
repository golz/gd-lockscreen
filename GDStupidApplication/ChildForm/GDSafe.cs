using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.IO;

namespace GDStupidApplication.ChildForm
{
    public partial class GDSafe : Form
    {
        //Declaring Global objects
        private IntPtr ptrHook;
        private LowLevelKeyboardProc objKeyboardProcess;
        private int failCount;
        private bool locked;
        private int unlockSeconds;
        public GDSafe()
        {
            InitializeComponent();
            //Try Count = 0;
            failCount = 0;
            unlockSeconds = 0;
            locked = false;
            //Get Current Module
            ProcessModule objCurrentModule = Process.GetCurrentProcess().MainModule;
            //Assign callback function each time keyboard process
            objKeyboardProcess = new LowLevelKeyboardProc(CaptureKey);
            //Setting Hook of Keyboard Process for current module
            ptrHook = SetWindowsHookEx(13, objKeyboardProcess, GetModuleHandle(objCurrentModule.ModuleName), 0);
            ChangeStyle();
        }

        private void ChangeStyle() 
        {
            this.BackColor = Style.Global.grey900;

            foreach (Control c in this.Controls)
            {
                if (c is Button)
                {
                    ((Button)c).BackColor = Style.Global.green;
                    ((Button)c).ForeColor = Color.White;
                    ((Button)c).TabStop = false;
                    ((Button)c).FlatStyle = FlatStyle.Flat;
                    ((Button)c).FlatAppearance.BorderSize = 0;
                    ((Button)c).Font = new Font("Lato", 8.5f);
                }
            }
            lblError.BackColor = Style.Global.red;
            lblError.ForeColor = Color.White;
        }

        private void GDSafe_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            this.timer.Start();
            
            this.txtPassword.Location = new Point(this.Width / 2 - this.txtPassword.Width / 2, this.Height / 2 - this.txtPassword.Height / 2);
            this.btnUnlock.Location = new Point(this.Width / 2 + this.txtPassword.Width / 2 , this.Height / 2 - this.btnUnlock.Height / 2);
            this.lblError.Location = new Point(this.Width / 2 - this.lblError.Width - this.btnUnlock.Width , this.Height / 2 - this.lblError.Height/ 2 + 35 );
            this.credit.Location = new Point(this.Width - this.credit.Width, this.Height - this.credit.Height);
            //Load Image
            //string path = Directory.GetCurrentDirectory() + "\\assets\\wallpaper.png";
            string path = Handler.Session.WallpaperImage;

            Bitmap bitmap = new Bitmap(1366, 720);
            using (Graphics graphics = Graphics.FromImage((Image)bitmap))
            {
                Rectangle rect = new Rectangle(0, 0, 1366, 720);
                graphics.FillRectangle(Brushes.Black, rect);
            }
            if (File.Exists(path))
                this.pictureBox.ImageLocation = path;
            else
                this.pictureBox.Image = (Image)bitmap;
            this.pictureBox.Size = new Size(this.Width, this.Height);
            this.pictureBox.Location = new Point(0, 0);

            //AutoFocus
            this.ActiveControl = txtPassword;
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            txtPassword.BackColor = Color.White;

            if (e.KeyCode != Keys.Return)
                return;
            Login();
        }

        private void GDSafe_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            this.TopMost = true;
            this.BringToFront();

            clock.Text = DateTime.Now.ToString("hh:mm:ss tt");
            dayName.Text = DateTime.Now.ToString("  dddd, MMMM dd");

            if (locked == true)
            {
                isLocked();
                if (unlockSeconds <= 0) {
                    setUnlocked();
                }
            }

        }

        private IntPtr CaptureKey(int nCode, IntPtr wp, IntPtr lp)
        {
            if (nCode >= 0)
            {
                KBDLLHOOKSTRUCT objKeyInfo = (KBDLLHOOKSTRUCT)Marshal.PtrToStructure(lp, typeof(KBDLLHOOKSTRUCT));
                //if (objKeyInfo.key == Keys.RWin || objKeyInfo.key == Keys.LWin) // Disabling Windows keys
                if (PreventKey(objKeyInfo))
                {
                    //No Special Keyboard
                    lblError.Text = "Special key has been disabled";
                    txtPassword.BackColor = Style.Global.red;
                    txtPassword.Text = "";

                    return (IntPtr)1;
                }
            }
            return CallNextHookEx(ptrHook, nCode, wp, lp);
        }

        private bool PreventKey(KBDLLHOOKSTRUCT obj)
        {
            if (obj.key == Keys.RWin || obj.key == Keys.LWin || 
                obj.key == Keys.Alt || obj.key == Keys.Tab ||
                obj.key == Keys.F4 || obj.key == Keys.Escape || 
                obj.key == Keys.Delete || obj.key == Keys.Control || 
                obj.key == Keys.ControlKey)
                return true;
            return false;
        }

        private void btnUnlock_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void Login()
        {
            String encrypted = Handler.MD5Hash.encrypt(this.txtPassword.Text);
            if (encrypted.Equals(Handler.Session.SavedPassword) || this.txtPassword.Text.Equals(Handler.Session.DefaultPassword))
            {
                Application.Exit();
            }
            else
            {
                failCount++;
                lblError.Text = "Password doesn't match";
                txtPassword.BackColor = Style.Global.red;

                using (StreamWriter sw = File.AppendText("log.txt"))
                {
                    sw.WriteLine(DateTime.Now + "\t - TryPassword(Attempt."+ failCount +"):\t " + txtPassword.Text);
                }
                if (failCount % 5 == 0) {
                    setLocked();
                }
                txtPassword.Text = "";
            }
        }

        public void isLocked() {
            lblError.Text = "Please wait for " + unlockSeconds / 10;
            txtPassword.Enabled = false;
            btnUnlock.Enabled = false;
            unlockSeconds -= 1;
            txtPassword.BackColor = Style.Global.grey900;
        }

        private void setUnlocked() {
            locked = false;
            unlockSeconds = 300;
            txtPassword.Enabled = true;
            btnUnlock.Enabled = true;
            lblError.Text = "";
            txtPassword.BackColor = Color.White;
        }

        private void setLocked() {
            locked = true;
            unlockSeconds = 300;
            lblError.Text = "Please wait for " + unlockSeconds/10;
        }

        /**
         * @author https://stackoverflow.com/questions/13324059/suppress-certain-windows-keyboard-shortcuts
         */
        // System level functions to be used for hook and unhook keyboard inpu
        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int id, LowLevelKeyboardProc callback, IntPtr hMod, uint dwThreadId);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool UnhookWindowsHookEx(IntPtr hook);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hook, int nCode, IntPtr wp, IntPtr lp);
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string name);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern short GetAsyncKeyState(Keys key);

        // Structure contain information about low-level keyboard input event
        [StructLayout(LayoutKind.Sequential)]
        private struct KBDLLHOOKSTRUCT
        {
            public Keys key;
            public int scanCode;
            public int flags;
            public int time;
            public IntPtr extra;
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
