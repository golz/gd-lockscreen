using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace GDStupidApplication
{
    public partial class MasterForm : Form
    {
        private ChildForm.GDLock gdLock;
        public MasterForm()
        {
            InitializeComponent();
            gdLock = new ChildForm.GDLock(this);
            gdLock.Show();

            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is MdiClient)
                {
                    ctrl.BackColor = Style.Global.grey900;
                    ctrl.TabStop = false;
                }
            }
        }

        private void MasterForm_Load(object sender, EventArgs e)
        {
           
        }
    }
}
