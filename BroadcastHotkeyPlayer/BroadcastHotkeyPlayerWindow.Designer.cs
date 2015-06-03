namespace BroadcastHotkeyPlayer
{
    partial class BroadcastHotkeyPlayerWindow
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BroadcastHotkeyPlayerWindow));
            this.mynotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.SuspendLayout();
            // 
            // mynotifyIcon
            // 
            this.mynotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("mynotifyIcon.Icon")));
            this.mynotifyIcon.Text = "notifyIcon1";
            this.mynotifyIcon.Visible = true;
            this.mynotifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.mynotifyIcon_MouseDoubleClick);
            // 
            // BroadcastHotkeyPlayerWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Name = "BroadcastHotkeyPlayerWindow";
            this.Text = "BroadcastHotkeyPlayer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon mynotifyIcon;

    }
}

