using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Security.Principal;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace SpotDL_UI
{
    public partial class MainForm : Form
    {
        bool dlSong = true;
        bool dlPlaylist;
        bool dlAlbum;
        bool rememberPath;
        string Url;
        string Path;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            textBox_Link_setText();
            if (Properties.Settings.Default.savedPath == "")
            {
                textBox_Dir_setText();
            } else
            {
                textBox_Dir.Text = Properties.Settings.Default.savedPath;
                Path = Properties.Settings.Default.savedPath;
            }
        }

        private void textBox_Link_setText()
        {
            textBox_Link.Text = "Enter Spotify URL (open.spotify.com/...)";
            textBox_Link.ForeColor = Color.Gray;
        }

        private void textBox_Dir_setText()
        {
            textBox_Dir.Text = "Select download directory...";
            textBox_Dir.ForeColor = Color.Gray;
        }

        private void textBox_link_Enter(object sender, EventArgs e)
        {
            if (textBox_Link.ForeColor == Color.Black)
                return;
            textBox_Link.Text = "";
            textBox_Link.ForeColor = Color.Black;
        }

        private void textBox_dir_Enter(object sender, EventArgs e)
        {
            if (textBox_Dir.ForeColor != Color.Gray)
                return;
            textBox_Dir.Text = "";
            textBox_Dir.ForeColor = Color.Black;
        }

        private void textBox_link_Leave(object sender, EventArgs e)
        {
            Url = textBox_Link.Text;
            if (textBox_Link.Text.Trim() == "")
                textBox_Link_setText();
        }

        private void textBox_dir_Leave(object sender, EventArgs e)
        {
            Path = textBox_Dir.Text;
            if (textBox_Dir.Text.Trim() == "")
                textBox_Dir_setText();
        }

        private void radioButton_Song_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_Song.Checked)
            {
                dlSong = true;
                dlPlaylist = false;
                dlAlbum = false;
            }
        }

        private void radioButton_Album_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_Album.Checked)
            {
                dlAlbum = true;
                dlSong = false;
                dlPlaylist = false;
            }
        }

        private void radioButton_Playlist_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_Playlist.Checked)
            {
                dlPlaylist = true;
                dlSong = false;
                dlAlbum = false;
            }
        }

        private void button_Browse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();

            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
            {
                Path = fbd.SelectedPath;
                textBox_Dir.Text = fbd.SelectedPath;
                textBox_Dir.ForeColor = Color.Black;
            }
        }

        private void checkBox_Remember_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Remember.Checked)
            {
                rememberPath = true;
            } else
            {
                rememberPath = false;
            }
        }

        private void button_Download_Click(object sender, EventArgs e)
        {
            if (rememberPath) { Properties.Settings.Default.savedPath = Path; Properties.Settings.Default.Save(); }
            if (string.IsNullOrWhiteSpace(Url)) { MessageBox.Show("You didn't provide a Spotify URL.", "Error"); return; }
            string commandText = "/c " + Path[0] + ": && cd " + Path + " && spotdl " + Url;
            Process.Start("CMD.exe", commandText);
        }

        private void button_Credits_Click(object sender, EventArgs e)
        {
            var creditsForm = new Form_Credits();
            creditsForm.Show();
        }

        private async void button_Install_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("This requires Python 3.6+ and pip installed in PATH. Do you want to continue?", "Warning!", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No)
            {
                return;
            }

            progressBar_Install.Visible = true;
            label_Progress.Text = "Installing spotdl...";

            ProcessStartInfo startInfo1 = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = "/c pip3 install -U spotdl",
            };
            var cmd1 = new Process()
            {
                StartInfo = startInfo1
            };
            await Task.Run(() => cmd1.Start());
            cmd1.WaitForExit();

            label_Progress.Text = "Installing ffmpeg...";
            ProcessStartInfo startInfo2 = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = "/c spotdl --download-ffmpeg"
            };
            var cmd2 = new Process()
            {
                StartInfo = startInfo2
            };
            await Task.Run(() => cmd2.Start());

            progressBar_Install.Visible = false;
            label_Progress.Text = "";
        }
    }
}