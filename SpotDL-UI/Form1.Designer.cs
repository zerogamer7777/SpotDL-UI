namespace SpotDL_UI
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.textBox_Link = new System.Windows.Forms.TextBox();
            this.label_link = new System.Windows.Forms.Label();
            this.button_Browse = new System.Windows.Forms.Button();
            this.textBox_Dir = new System.Windows.Forms.TextBox();
            this.label_dir = new System.Windows.Forms.Label();
            this.button_Download = new System.Windows.Forms.Button();
            this.checkBox_Remember = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_Install = new System.Windows.Forms.Button();
            this.button_Credits = new System.Windows.Forms.Button();
            this.progressBar_Install = new System.Windows.Forms.ProgressBar();
            this.label_Progress = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox_Link
            // 
            this.textBox_Link.Location = new System.Drawing.Point(12, 205);
            this.textBox_Link.Name = "textBox_Link";
            this.textBox_Link.Size = new System.Drawing.Size(460, 20);
            this.textBox_Link.TabIndex = 0;
            this.textBox_Link.Enter += new System.EventHandler(this.textBox_link_Enter);
            this.textBox_Link.Leave += new System.EventHandler(this.textBox_link_Leave);
            // 
            // label_link
            // 
            this.label_link.AutoSize = true;
            this.label_link.Location = new System.Drawing.Point(12, 189);
            this.label_link.Name = "label_link";
            this.label_link.Size = new System.Drawing.Size(179, 13);
            this.label_link.TabIndex = 1;
            this.label_link.Text = "Spotify link to song, album or playlist:";
            // 
            // button_Browse
            // 
            this.button_Browse.Location = new System.Drawing.Point(397, 264);
            this.button_Browse.Name = "button_Browse";
            this.button_Browse.Size = new System.Drawing.Size(75, 23);
            this.button_Browse.TabIndex = 4;
            this.button_Browse.Text = "Browse";
            this.button_Browse.UseVisualStyleBackColor = true;
            this.button_Browse.Click += new System.EventHandler(this.button_Browse_Click);
            // 
            // textBox_Dir
            // 
            this.textBox_Dir.Location = new System.Drawing.Point(12, 266);
            this.textBox_Dir.Name = "textBox_Dir";
            this.textBox_Dir.Size = new System.Drawing.Size(379, 20);
            this.textBox_Dir.TabIndex = 5;
            this.textBox_Dir.Enter += new System.EventHandler(this.textBox_dir_Enter);
            this.textBox_Dir.Leave += new System.EventHandler(this.textBox_dir_Leave);
            // 
            // label_dir
            // 
            this.label_dir.AutoSize = true;
            this.label_dir.Location = new System.Drawing.Point(12, 250);
            this.label_dir.Name = "label_dir";
            this.label_dir.Size = new System.Drawing.Size(171, 13);
            this.label_dir.TabIndex = 6;
            this.label_dir.Text = "Directory you want to download to:";
            // 
            // button_Download
            // 
            this.button_Download.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button_Download.Location = new System.Drawing.Point(175, 389);
            this.button_Download.Name = "button_Download";
            this.button_Download.Size = new System.Drawing.Size(140, 60);
            this.button_Download.TabIndex = 7;
            this.button_Download.Text = "Download";
            this.button_Download.UseVisualStyleBackColor = true;
            this.button_Download.Click += new System.EventHandler(this.button_Download_Click);
            // 
            // checkBox_Remember
            // 
            this.checkBox_Remember.AutoSize = true;
            this.checkBox_Remember.Location = new System.Drawing.Point(395, 293);
            this.checkBox_Remember.Name = "checkBox_Remember";
            this.checkBox_Remember.Size = new System.Drawing.Size(77, 17);
            this.checkBox_Remember.TabIndex = 11;
            this.checkBox_Remember.Text = "Remember";
            this.checkBox_Remember.UseVisualStyleBackColor = true;
            this.checkBox_Remember.CheckedChanged += new System.EventHandler(this.checkBox_Remember_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(154, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 24);
            this.label1.TabIndex = 13;
            this.label1.Text = "Spotify downloader";
            // 
            // button_Install
            // 
            this.button_Install.Location = new System.Drawing.Point(12, 410);
            this.button_Install.Name = "button_Install";
            this.button_Install.Size = new System.Drawing.Size(120, 40);
            this.button_Install.TabIndex = 14;
            this.button_Install.Text = "Install SpotDL";
            this.button_Install.UseVisualStyleBackColor = true;
            this.button_Install.Click += new System.EventHandler(this.button_Install_Click);
            // 
            // button_Credits
            // 
            this.button_Credits.Location = new System.Drawing.Point(360, 410);
            this.button_Credits.Name = "button_Credits";
            this.button_Credits.Size = new System.Drawing.Size(112, 39);
            this.button_Credits.TabIndex = 15;
            this.button_Credits.Text = "Credits";
            this.button_Credits.UseVisualStyleBackColor = true;
            this.button_Credits.Click += new System.EventHandler(this.button_Credits_Click);
            // 
            // progressBar_Install
            // 
            this.progressBar_Install.Location = new System.Drawing.Point(15, 381);
            this.progressBar_Install.Name = "progressBar_Install";
            this.progressBar_Install.Size = new System.Drawing.Size(117, 23);
            this.progressBar_Install.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar_Install.TabIndex = 16;
            this.progressBar_Install.Visible = false;
            // 
            // label_Progress
            // 
            this.label_Progress.AutoSize = true;
            this.label_Progress.Location = new System.Drawing.Point(15, 362);
            this.label_Progress.Name = "label_Progress";
            this.label_Progress.Size = new System.Drawing.Size(0, 13);
            this.label_Progress.TabIndex = 17;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 461);
            this.Controls.Add(this.label_Progress);
            this.Controls.Add(this.progressBar_Install);
            this.Controls.Add(this.button_Credits);
            this.Controls.Add(this.button_Install);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBox_Remember);
            this.Controls.Add(this.button_Download);
            this.Controls.Add(this.label_dir);
            this.Controls.Add(this.textBox_Dir);
            this.Controls.Add(this.button_Browse);
            this.Controls.Add(this.label_link);
            this.Controls.Add(this.textBox_Link);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "SpotDL";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_Link;
        private System.Windows.Forms.Label label_link;
        private System.Windows.Forms.Button button_Browse;
        private System.Windows.Forms.TextBox textBox_Dir;
        private System.Windows.Forms.Label label_dir;
        private System.Windows.Forms.Button button_Download;
        private System.Windows.Forms.CheckBox checkBox_Remember;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_Install;
        private System.Windows.Forms.Button button_Credits;
        private System.Windows.Forms.ProgressBar progressBar_Install;
        private System.Windows.Forms.Label label_Progress;
    }
}

