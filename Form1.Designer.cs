namespace YTXDL
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            label1 = new Label();
            textBox_url = new TextBox();
            button_paste = new Button();
            label2 = new Label();
            radioButton_audio = new RadioButton();
            radioButton_video = new RadioButton();
            comboBox_quality = new ComboBox();
            label3 = new Label();
            button_out = new Button();
            textBox_out = new TextBox();
            button_download = new Button();
            label_status = new Label();
            panel_download = new Panel();
            pictureBox_cover = new PictureBox();
            label_video_title = new Label();
            timer_loop = new System.Windows.Forms.Timer(components);
            panel_download.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_cover).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Verdana", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label1.ForeColor = Color.LightSkyBlue;
            label1.Location = new Point(15, 15);
            label1.Margin = new Padding(0, 0, 0, 15);
            label1.Name = "label1";
            label1.Size = new Size(205, 25);
            label1.TabIndex = 0;
            label1.Text = "Youtube video link";
            // 
            // textBox_url
            // 
            textBox_url.BackColor = Color.FromArgb(25, 25, 25);
            textBox_url.BorderStyle = BorderStyle.FixedSingle;
            textBox_url.Font = new Font("Verdana", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            textBox_url.ForeColor = Color.FromArgb(224, 224, 224);
            textBox_url.Location = new Point(15, 55);
            textBox_url.Margin = new Padding(0, 0, 0, 25);
            textBox_url.Name = "textBox_url";
            textBox_url.Size = new Size(286, 31);
            textBox_url.TabIndex = 1;
            textBox_url.TextChanged += textBox_url_TextChanged;
            // 
            // button_paste
            // 
            button_paste.BackgroundImage = (Image)resources.GetObject("button_paste.BackgroundImage");
            button_paste.BackgroundImageLayout = ImageLayout.Center;
            button_paste.FlatStyle = FlatStyle.Flat;
            button_paste.ForeColor = Color.LightSkyBlue;
            button_paste.Location = new Point(291, 55);
            button_paste.Name = "button_paste";
            button_paste.Size = new Size(75, 31);
            button_paste.TabIndex = 2;
            button_paste.UseVisualStyleBackColor = true;
            button_paste.Click += button_paste_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Verdana", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label2.ForeColor = Color.LightSkyBlue;
            label2.Location = new Point(15, 111);
            label2.Margin = new Padding(0, 0, 0, 25);
            label2.Name = "label2";
            label2.Size = new Size(95, 25);
            label2.TabIndex = 3;
            label2.Text = "Save as";
            // 
            // radioButton_audio
            // 
            radioButton_audio.AutoSize = true;
            radioButton_audio.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            radioButton_audio.ForeColor = Color.Silver;
            radioButton_audio.Location = new Point(25, 161);
            radioButton_audio.Margin = new Padding(10, 0, 0, 20);
            radioButton_audio.Name = "radioButton_audio";
            radioButton_audio.Size = new Size(127, 22);
            radioButton_audio.TabIndex = 4;
            radioButton_audio.TabStop = true;
            radioButton_audio.Text = "Audio (mp3)";
            radioButton_audio.UseVisualStyleBackColor = true;
            radioButton_audio.CheckedChanged += radioButton_audio_CheckedChanged;
            // 
            // radioButton_video
            // 
            radioButton_video.AutoSize = true;
            radioButton_video.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            radioButton_video.ForeColor = Color.Silver;
            radioButton_video.Location = new Point(25, 203);
            radioButton_video.Margin = new Padding(10, 0, 0, 25);
            radioButton_video.Name = "radioButton_video";
            radioButton_video.Size = new Size(170, 22);
            radioButton_video.TabIndex = 5;
            radioButton_video.TabStop = true;
            radioButton_video.Text = "Video (mp4 / avi)";
            radioButton_video.UseVisualStyleBackColor = true;
            radioButton_video.CheckedChanged += radioButton_video_CheckedChanged;
            // 
            // comboBox_quality
            // 
            comboBox_quality.BackColor = Color.FromArgb(25, 25, 25);
            comboBox_quality.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_quality.FlatStyle = FlatStyle.Flat;
            comboBox_quality.ForeColor = Color.FromArgb(224, 224, 224);
            comboBox_quality.FormattingEnabled = true;
            comboBox_quality.Items.AddRange(new object[] { "144p", "240p", "360p", "480p", "720p", "1080p" });
            comboBox_quality.Location = new Point(245, 203);
            comboBox_quality.Margin = new Padding(0);
            comboBox_quality.Name = "comboBox_quality";
            comboBox_quality.Size = new Size(121, 26);
            comboBox_quality.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Verdana", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label3.ForeColor = Color.LightSkyBlue;
            label3.Location = new Point(15, 250);
            label3.Margin = new Padding(0, 0, 0, 25);
            label3.Name = "label3";
            label3.Size = new Size(152, 25);
            label3.TabIndex = 7;
            label3.Text = "Output folder";
            // 
            // button_out
            // 
            button_out.BackgroundImage = (Image)resources.GetObject("button_out.BackgroundImage");
            button_out.BackgroundImageLayout = ImageLayout.Center;
            button_out.FlatStyle = FlatStyle.Flat;
            button_out.ForeColor = Color.LightSkyBlue;
            button_out.Location = new Point(291, 300);
            button_out.Name = "button_out";
            button_out.Size = new Size(75, 31);
            button_out.TabIndex = 9;
            button_out.UseVisualStyleBackColor = true;
            button_out.Click += button_out_Click;
            // 
            // textBox_out
            // 
            textBox_out.BackColor = Color.FromArgb(25, 25, 25);
            textBox_out.BorderStyle = BorderStyle.FixedSingle;
            textBox_out.Font = new Font("Verdana", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            textBox_out.ForeColor = Color.FromArgb(224, 224, 224);
            textBox_out.Location = new Point(15, 300);
            textBox_out.Margin = new Padding(0, 0, 0, 25);
            textBox_out.Name = "textBox_out";
            textBox_out.Size = new Size(286, 31);
            textBox_out.TabIndex = 8;
            // 
            // button_download
            // 
            button_download.FlatStyle = FlatStyle.Flat;
            button_download.Font = new Font("Verdana", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            button_download.ForeColor = Color.MediumSeaGreen;
            button_download.Location = new Point(15, 386);
            button_download.Margin = new Padding(0);
            button_download.Name = "button_download";
            button_download.Size = new Size(351, 60);
            button_download.TabIndex = 10;
            button_download.Text = "Download";
            button_download.UseVisualStyleBackColor = true;
            button_download.Click += button_download_Click;
            // 
            // label_status
            // 
            label_status.AutoSize = true;
            label_status.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label_status.ForeColor = Color.Silver;
            label_status.Location = new Point(185, 350);
            label_status.Margin = new Padding(0);
            label_status.Name = "label_status";
            label_status.Size = new Size(18, 18);
            label_status.TabIndex = 11;
            label_status.Text = "_";
            // 
            // panel_download
            // 
            panel_download.Controls.Add(pictureBox_cover);
            panel_download.Controls.Add(label_video_title);
            panel_download.Location = new Point(15, 15);
            panel_download.Margin = new Padding(0);
            panel_download.Name = "panel_download";
            panel_download.Padding = new Padding(15);
            panel_download.Size = new Size(354, 316);
            panel_download.TabIndex = 12;
            // 
            // pictureBox_cover
            // 
            pictureBox_cover.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox_cover.BorderStyle = BorderStyle.FixedSingle;
            pictureBox_cover.Location = new Point(95, 35);
            pictureBox_cover.Margin = new Padding(0);
            pictureBox_cover.Name = "pictureBox_cover";
            pictureBox_cover.Size = new Size(150, 150);
            pictureBox_cover.TabIndex = 13;
            pictureBox_cover.TabStop = false;
            // 
            // label_video_title
            // 
            label_video_title.AutoSize = true;
            label_video_title.Font = new Font("Verdana", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label_video_title.ForeColor = Color.Silver;
            label_video_title.Location = new Point(70, 230);
            label_video_title.Margin = new Padding(0);
            label_video_title.Name = "label_video_title";
            label_video_title.Size = new Size(207, 25);
            label_video_title.TabIndex = 12;
            label_video_title.Text = "_______________";
            // 
            // timer_loop
            // 
            timer_loop.Enabled = true;
            timer_loop.Tick += timer_loop_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(15, 15, 15);
            ClientSize = new Size(384, 461);
            Controls.Add(panel_download);
            Controls.Add(label_status);
            Controls.Add(button_download);
            Controls.Add(button_out);
            Controls.Add(textBox_out);
            Controls.Add(label3);
            Controls.Add(comboBox_quality);
            Controls.Add(radioButton_video);
            Controls.Add(radioButton_audio);
            Controls.Add(label2);
            Controls.Add(button_paste);
            Controls.Add(textBox_url);
            Controls.Add(label1);
            Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            ForeColor = Color.FromArgb(224, 224, 224);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            MaximizeBox = false;
            MaximumSize = new Size(400, 500);
            MinimumSize = new Size(400, 500);
            Name = "Form1";
            Padding = new Padding(15);
            Text = "YTXDL - Release 1.0";
            Load += Form1_Load;
            panel_download.ResumeLayout(false);
            panel_download.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_cover).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox_url;
        private Button button_paste;
        private Label label2;
        private RadioButton radioButton_audio;
        private RadioButton radioButton_video;
        private ComboBox comboBox_quality;
        private Label label3;
        private Button button_out;
        private TextBox textBox_out;
        private Button button_download;
        private Label label_status;
        private Panel panel_download;
        private Label label_video_title;
        private PictureBox pictureBox_cover;
        private System.Windows.Forms.Timer timer_loop;
    }
}
