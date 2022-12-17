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
            if (string.IsNullOrWhiteSpace(Url)) { MessageBox.Show("You didn't provide a Spotify song or playlist URL.", "Error"); return; }
            string commandText;

            if(Url.Contains("track") && dlPlaylist)
            {
                DialogResult dialogResult = MessageBox.Show("Your Url probably points to a song, but you have 'Playlist' selected. Are you sure you want to continue?", "Warning!", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No)
                {
                    return;
                }
            }
            if (Url.Contains("track") && dlAlbum)
            {
                DialogResult dialogResult = MessageBox.Show("Your Url probably points to a song, but you have 'Album' selected. Are you sure you want to continue?", "Warning!", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No)
                {
                    return;
                }
            }
            if (Url.Contains("playlist") && dlSong)
            {
                DialogResult dialogResult = MessageBox.Show("Your Url probably points to a playlist, but you have 'Song' selected. Are you sure you want to continue?", "Warning!", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No)
                {
                    return;
                }
            }
            if (Url.Contains("playlist") && dlAlbum)
            {
                DialogResult dialogResult = MessageBox.Show("Your Url probably points to a playlist, but you have 'Album' selected. Are you sure you want to continue?", "Warning!", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No)
                {
                    return;
                }
            }
            if (Url.Contains("album") && dlSong)
            {
                DialogResult dialogResult = MessageBox.Show("Your Url probably points to an album, but you have 'Song' selected. Are you sure you want to continue?", "Warning!", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No)
                {
                    return;
                }
            }
            if (Url.Contains("album") && dlPlaylist)
            {
                DialogResult dialogResult = MessageBox.Show("Your Url probably points to an album, but you have 'Playlist' selected. Are you sure you want to continue?", "Warning!", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No)
                {
                    return;
                }
            }

            if (dlSong) {
                commandText = "/c cd " + Path + " && spotdl -s " + Url;
            } else if (dlAlbum) {
                commandText = "/c cd " + Path + " && spotdl -a " + Url;
                var cmd = Process.Start("CMD.exe", commandText);
                cmd.WaitForExit();
                string[] listFile = Directory.GetFiles(Path, "*.txt");
                commandText = "/c cd \"" + Path + "\" && spotdl -l \"" + listFile[0] + "\" && del \"" + listFile[0] + "\"";
            } else if (dlPlaylist)
            {
                commandText = "/c cd " + Path + " && spotdl -p " + Url;
                var cmd = Process.Start("CMD.exe", commandText);
                cmd.WaitForExit();
                string[] listFile = Directory.GetFiles(Path, "*.txt");
                commandText = "/c cd \"" + Path + "\" && spotdl -l \"" + listFile[0] + "\" && del \"" + listFile[0] + "\"";

            } else { MessageBox.Show("Neither 'Song' nor 'Playlist' is selected.", "Exception"); return; }
            Process.Start("CMD.exe", commandText);
        }

        private void button_Credits_Click(object sender, EventArgs e)
        {
            var creditsForm = new Form_Credits();
            creditsForm.Show();
        }

        private async void button_Install_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to install spotdl and all dependencies? This requires Python 3.6+ and pip installed in PATH.", "Warning!", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No)
            {
                return;
            }

            if (!IsAdministrator())
            {
                MessageBox.Show("Application restart required. You'll be prompted to grant admin priviliges. After restart press 'Install SpotDL' again!", "Warning!");
                var exeName = Process.GetCurrentProcess().MainModule.FileName;
                ProcessStartInfo startInfo0 = new ProcessStartInfo(exeName);
                startInfo0.Verb = "runas";
                try
                {
                    Process.Start(startInfo0);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception: " + ex.Message);
                    return;
                }
                Application.Exit();
                return;
            }

            progressBar_Install.Visible = true;
            label_Progress.Text = "Installing spotdl...";

            ProcessStartInfo startInfo1 = new ProcessStartInfo();
            startInfo1.FileName = "cmd.exe";
            startInfo1.Arguments = "/c pip3 install -U spotdl"; ;
            var cmd1 = new Process();
            cmd1.StartInfo = startInfo1;
            await Task.Run(() => cmd1.Start());

            if (Directory.Exists(@"c:\ffmpeg"))
            {
                Directory.Delete(@"c:\ffmpeg", true);
            }
            label_Progress.Text = "Downloading ffmpeg...";
            using (WebClient client = new WebClient())
            {
                await Task.Run(() => client.DownloadFile("https://www.gyan.dev/ffmpeg/builds/ffmpeg-release-essentials.zip", Environment.ExpandEnvironmentVariables(@"%USERPROFILE%\Documents\ffmpeg.zip")));
            }
            label_Progress.Text = "Extracting and moving...";
            await Task.Run(() => ZipFile.ExtractToDirectory(Environment.ExpandEnvironmentVariables(@"%USERPROFILE%\Documents\ffmpeg.zip"), Environment.ExpandEnvironmentVariables(@"%USERPROFILE%\Documents")));

            ProcessStartInfo startInfo2 = new ProcessStartInfo();
            startInfo2.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo2.FileName = "cmd.exe";
            startInfo2.Arguments = "/c cd %USERPROFILE%\\Documents && del ffmpeg.zip && move ffmpeg-4.3.1-essentials_build c:\\ffmpeg";
            var cmd2 = new Process();
            cmd2.StartInfo = startInfo2;
            await Task.Run(() => cmd2.Start());

            label_Progress.Text = "Updating Environment variables...";
            try
            {
                AppDomain.CurrentDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);
                var name = "PATH";
                var scope = EnvironmentVariableTarget.Machine;
                var oldValue = Environment.GetEnvironmentVariable(name, scope);
                var newValue = oldValue + @";C:\ffmpeg\bin\";
                Environment.SetEnvironmentVariable(name, newValue, scope);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An exception occurred : " + ex.Message);
                MessageBox.Show("Couldn't add ffmpeg to PATH. This will result in encoding error. Please try again granting admin priviliges.", "Error!");
            }

            progressBar_Install.Visible = false;
            label_Progress.Text = "";
        }

        private static bool IsAdministrator()
        {
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }
    }
}