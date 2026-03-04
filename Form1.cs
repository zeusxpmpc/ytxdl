using System.Media;
using System.Runtime.Intrinsics.Arm;

namespace YTXDL
{
    public partial class Form1 : Form
    {
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x84:
                    base.WndProc(ref m);
                    if ((int)m.Result == 0x1)
                        m.Result = (IntPtr)0x2;
                    return;
            }
            base.WndProc(ref m);
        }

        private string tempPath = "";
        private string outPath = "";
        private int counter = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void setStatus(string text, Color? c = null)
        {
            label_status.Text = text;
            label_status.Location = new Point(185 - (label_status.Width/2), 350); //185; 350

            Color actualColor = c ?? Color.Silver;
            label_status.ForeColor = actualColor;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tempPath = Path.Combine(Path.GetTempPath(), "YTXDL");

            if (!Directory.Exists(tempPath))
            {
                Directory.CreateDirectory(tempPath);
            }

            if (!string.IsNullOrEmpty(Properties.Settings.Default.outpath))
            {
                outPath = Properties.Settings.Default.outpath;
            }
            else
            {
                string downloadsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
                outPath = downloadsPath;
                Properties.Settings.Default.outpath = downloadsPath;
            }

            Properties.Settings.Default.Save();
            textBox_out.Text = outPath;

            comboBox_quality.SelectedIndex = 0;

            radioButton_video.Checked = Properties.Settings.Default.convert_type == "video";
            radioButton_audio.Checked = Properties.Settings.Default.convert_type == "audio";

            panel_download.Location = new Point(15, 15);
            panel_download.Visible = false;

            (new System.Windows.Forms.ToolTip()).SetToolTip(button_paste, "Paste url");

            (new System.Windows.Forms.ToolTip()).SetToolTip(button_out, "Select out directory");

            if (!checkRequiredFiles())
            {
                button_download.Enabled = false;
            }
        }

        public bool isFFmpegInPath()
        {
            var fileName = "ffmpeg.exe";
            var values = Environment.GetEnvironmentVariable("PATH");

            foreach (var path in values.Split(Path.PathSeparator))
            {
                var fullPath = Path.Combine(path, fileName);
                if (File.Exists(fullPath))
                    return true;
            }
            return false;
        }

        private bool checkRequiredFiles()
        {
            string message = string.Empty;

            bool error = false;

            if (!Utils.isFileExist("yt-dlp.exe"))
            {
                message += " yt-dlp,";
                error = true;
            }

            if (!Utils.isFileExist("ffmpeg.exe") && !Utils.isInPath("ffmpeg", "-version"))
            {
                message += " ffmpeg,";
                error = true;
            }

            if (!Utils.isFileExist("ffprobe.exe") && !Utils.isInPath("ffprobe", "-version"))
            {
                message += " ffprobe,";
                error = true;
            }

            if (error == true)
            {
                setStatus("This software are missing: " + message, Color.OrangeRed);
                return false;
            }

            return true;
        }

        private void button_out_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Select output folder";
                folderDialog.ShowNewFolderButton = true;

                DialogResult result = folderDialog.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderDialog.SelectedPath))
                {
                    outPath = folderDialog.SelectedPath;
                    textBox_out.Text = outPath;
                    Properties.Settings.Default.outpath = outPath;
                    Properties.Settings.Default.Save();
                }
            }
        }

        private async void button_download_Click(object sender, EventArgs e)
        {
            await download();
        }

        private async Task<bool> download()
        {
            try
            {
                if (!checkRequiredFiles()) return false;

                resetTemp();

                string url = textBox_url.Text;

                if (string.IsNullOrWhiteSpace(url) || !Utils.isValidUrl(url))
                {
                    MessageBox.Show("Video url incorrect!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                if (outPath != "")
                {
                    if (!Directory.Exists(outPath))
                    {
                        Directory.CreateDirectory(outPath);
                    }
                }

                VideoInfo video = await Utils.getVideoInfoAsync(url);

                if (video == null)
                {
                    MessageBox.Show("Video not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                button_download.Enabled = false;

                label_video_title.Text = video.Title;
                //160; 235
                label_video_title.Location = new Point(165 - (label_video_title.Width / 2), 235 - (label_video_title.Height / 2));
                panel_download.Visible = true;

                string safe_title = Utils.makeSafeFileName(video.Title);

                List<string> args = new List<string>();

                if (radioButton_audio.Checked)
                {
                    //AUDIO
                    args.Add("--no-playlist");
                    args.Add("-f");
                    args.Add("bestaudio");
                    args.Add("--extract-audio");
                    args.Add("--audio-format");
                    args.Add("mp3");
                    args.Add("--audio-quality");
                    args.Add("0");

                    args.Add("--write-thumbnail");
                    args.Add("--convert-thumbnails");
                    args.Add("jpg");
                }
                else if (radioButton_video.Checked)
                {
                    //VIDEO
                    string quality = "720";
                    if (comboBox_quality.SelectedItem != null)
                    {
                        var q = comboBox_quality.SelectedItem.ToString();
                        quality = q.Replace("p", "");
                    }

                    args.Add("-f");
                    args.Add($"bestvideo[height<={quality}]+bestaudio/best[height<={quality}]");
                    args.Add("--merge-output-format");
                    args.Add("mp4");
                }

                args.Add("-o");
                args.Add(Path.Combine(tempPath, safe_title + ".%(ext)s"));
                args.Add(url);

                var ytdlp = new YTDLPHelper();

                await Utils.loadImageFromUrlAsync(video.ThumbnailUrl, pictureBox_cover);

                bool success = await ytdlp.RunYTDLPWithProgressAsync(args);

                if (success)
                {

                    string target_file = Path.Combine(tempPath, safe_title);
                    string target_path = Path.Combine(outPath, safe_title);

                    if (radioButton_video.Checked)
                    {
                        target_file +=".mp4";
                        target_path += ".mp4";

                    }
                    else if (radioButton_audio.Checked)
                    {
                        target_file += ".mp3";
                        target_path += ".mp3";

                        var thumbnail = Directory.GetFiles(tempPath, "*.jpg").FirstOrDefault();

                        if(thumbnail != null)
                        {
                            Utils.setMp3Thumbnail(target_file, thumbnail);
                        }
                    }

                    if (!File.Exists(target_path))
                    {
                        File.Move(target_file, target_path);
                    }

                    SystemSounds.Beep.Play();

                    setStatus("Successful downloaded!", Color.SpringGreen);

                    return true;
                }
                else
                {
                    SystemSounds.Hand.Play();
                    setStatus("Download error...", Color.Yellow);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                resetTemp();
                button_download.Enabled = true;
                panel_download.Visible = false;
            }

            return false;
        }

        private void resetTemp()
        {
            Directory.Delete(tempPath, true);
            Directory.CreateDirectory(tempPath);
        }

        private void timer_loop_Tick(object sender, EventArgs e)
        {
            if (panel_download.Visible == false) return;

            setStatus("Downloading" + string.Concat(Enumerable.Repeat(".", counter)), Color.Gray);
            if (counter < 3)
                counter++;
            else
                counter = 1;
        }

        private void button_paste_Click(object sender, EventArgs e)
        {
            string url = Clipboard.GetText();
            textBox_url.Text = url;
        }

        private void radioButton_audio_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.convert_type = "audio";
            Properties.Settings.Default.Save();
            comboBox_quality.Enabled = false;
        }

        private void radioButton_video_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.convert_type = "video";
            Properties.Settings.Default.Save();
            comboBox_quality.Enabled = true;
        }

        private void textBox_url_TextChanged(object sender, EventArgs e)
        {
            var url = textBox_url.Text;

            if (string.IsNullOrWhiteSpace(url) || !Utils.isValidUrl(url))
            {
                textBox_url.ForeColor = Color.Red;
            }
            else
            {
                textBox_url.ForeColor = Color.Silver;
            }
        }
    }
}
