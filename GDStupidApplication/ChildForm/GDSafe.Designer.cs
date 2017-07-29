namespace GDStupidApplication.ChildForm
{
    partial class GDSafe
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.btnUnlock = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.lblError = new System.Windows.Forms.Label();
            this.clock = new System.Windows.Forms.Label();
            this.dayName = new System.Windows.Forms.Label();
            this.credit = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(25, 136);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(184, 20);
            this.txtPassword.TabIndex = 0;
            this.txtPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
            this.txtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyDown);
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(-6, 2);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(287, 264);
            this.pictureBox.TabIndex = 1;
            this.pictureBox.TabStop = false;
            // 
            // btnUnlock
            // 
            this.btnUnlock.Font = new System.Drawing.Font("Lato", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUnlock.Location = new System.Drawing.Point(208, 136);
            this.btnUnlock.Name = "btnUnlock";
            this.btnUnlock.Size = new System.Drawing.Size(64, 20);
            this.btnUnlock.TabIndex = 2;
            this.btnUnlock.Text = "Unlock";
            this.btnUnlock.UseVisualStyleBackColor = true;
            this.btnUnlock.Click += new System.EventHandler(this.btnUnlock_Click);
            // 
            // timer
            // 
            this.timer.Interval = 50;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.BackColor = System.Drawing.SystemColors.Control;
            this.lblError.Font = new System.Drawing.Font("Lato", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError.Location = new System.Drawing.Point(91, 162);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(0, 13);
            this.lblError.TabIndex = 3;
            this.lblError.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // clock
            // 
            this.clock.AutoSize = true;
            this.clock.Font = new System.Drawing.Font("Lato", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clock.ForeColor = System.Drawing.Color.White;
            this.clock.Location = new System.Drawing.Point(12, 9);
            this.clock.Name = "clock";
            this.clock.Size = new System.Drawing.Size(197, 77);
            this.clock.TabIndex = 4;
            this.clock.Text = "00:00";
            this.clock.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dayName
            // 
            this.dayName.AutoSize = true;
            this.dayName.Font = new System.Drawing.Font("Lato", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dayName.ForeColor = System.Drawing.Color.White;
            this.dayName.Location = new System.Drawing.Point(12, 86);
            this.dayName.Name = "dayName";
            this.dayName.Size = new System.Drawing.Size(67, 35);
            this.dayName.TabIndex = 5;
            this.dayName.Text = "Day";
            // 
            // credit
            // 
            this.credit.AutoSize = true;
            this.credit.Font = new System.Drawing.Font("Lato", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.credit.ForeColor = System.Drawing.Color.White;
            this.credit.Location = new System.Drawing.Point(19, 236);
            this.credit.Name = "credit";
            this.credit.Size = new System.Drawing.Size(107, 13);
            this.credit.TabIndex = 6;
            this.credit.Text = "Designed by GD16-1";
            // 
            // GDSafe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.credit);
            this.Controls.Add(this.dayName);
            this.Controls.Add(this.clock);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.btnUnlock);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.pictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GDSafe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GDSafe";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.GDSafe_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GDSafe_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button btnUnlock;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Label clock;
        private System.Windows.Forms.Label dayName;
        private System.Windows.Forms.Label credit;
    }
}