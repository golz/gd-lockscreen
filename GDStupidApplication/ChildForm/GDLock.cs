using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GDStupidApplication.ChildForm
{
    public partial class GDLock : Form
    {
        private MasterForm masterForm;
        private ChildForm.GDSafe gdSafe;

        public GDLock(MasterForm masterForm)
        {
            InitializeComponent();
            this.masterForm = masterForm;
            this.MdiParent = masterForm;

            ChangeStyle();
        }

        private void GDLock_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Return)
                return;
            Locking();
        }

        private void Locking() 
        {
            if (this.txtPassword.Text != "" && this.txtConfirm.Text.Equals(this.txtPassword.Text)) {
                
                Handler.Session.SavedPassword = Handler.MD5Hash.encrypt(this.txtPassword.Text);

                gdSafe = new ChildForm.GDSafe();
                gdSafe.TopMost = true;

                gdSafe.ShowInTaskbar = false;
                
                this.ShowInTaskbar = false;
                this.masterForm.ShowInTaskbar = false;
                this.masterForm.Hide();

                gdSafe.Show();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLock_Click(object sender, EventArgs e)
        {
            Locking();
        }

        private void ChangeStyle() {
            this.masterForm.BackColor = Style.Global.grey900;

            this.BackColor = Style.Global.grey900;
            this.label1.ForeColor = Color.White;

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
            btnExit.BackColor = Style.Global.red;
            btnChange.BackColor = Style.Global.deepOrange;
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog()) 
            {
                dlg.Title = "Open Image";
                dlg.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    pictureBoxPreview.Image = new Bitmap(dlg.FileName);
                    Handler.Session.WallpaperImage = dlg.FileName;

                    fileName.Text = dlg.FileName;
                }
            }
        }

        private void GDLock_Load(object sender, EventArgs e)
        {

        }
    }
}
