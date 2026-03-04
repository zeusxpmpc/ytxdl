using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Text.Json;

namespace YTXDL
{
    internal class Utils
    {
        public static bool isInPath(string exeName, string args = "")
        {
            try
            {
                var process = new Process();
                process.StartInfo.FileName = exeName;
                process.StartInfo.Arguments = args;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;
                process.Start();
                process.WaitForExit(3000);
                return process.ExitCode == 0;
            }
            catch
            {
                return false;
            }
        }

        public static bool isFileExist(string name)
        {
            string path = Path.Combine(AppContext.BaseDirectory, name);
            return System.IO.File.Exists(path);
        }

        public static async Task<VideoInfo> getVideoInfoAsync(string videoUrl)
        {
            try
            {
                string requestUrl = $"https://noembed.com/embed?url={System.Uri.EscapeDataString(videoUrl)}";

                using HttpClient client = new HttpClient();
                string json = await client.GetStringAsync(requestUrl);

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                VideoInfo info = JsonSerializer.Deserialize<VideoInfo>(json, options);

                return info;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }

            return new VideoInfo();
        }

        public static async Task loadImageFromUrlAsync(string imageUrl, PictureBox pictureBox)
        {
            try
            {
                using HttpClient client = new HttpClient();
                using Stream stream = await client.GetStreamAsync(imageUrl);
                pictureBox.BackgroundImage = Image.FromStream(stream);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
        }

        public static void setMp3Thumbnail(string mp3Path, string imagePath)
        {
            var file = TagLib.File.Create(mp3Path);

            byte[] bytes = System.IO.File.ReadAllBytes(imagePath);
            string extension = Path.GetExtension(imagePath).ToLowerInvariant();

            string mimeType = extension switch
            {
                ".jpg" or ".jpeg" => "image/jpeg",
                ".png" => "image/png",
                _ => "image/jpeg"
            };

            var picture = new TagLib.Picture
            {
                Type = TagLib.PictureType.FrontCover,
                Description = "Front Cover",
                MimeType = mimeType,
                Data = new TagLib.ByteVector(bytes)
            };

            var id3v2 = (TagLib.Id3v2.Tag)file.GetTag(TagLib.TagTypes.Id3v2, true);
            id3v2.Pictures = new TagLib.IPicture[] { picture };
            id3v2.Version = 3;

            file.Save();
        }

        public static string makeSafeFileName(string name)
        {
            foreach (char c in Path.GetInvalidFileNameChars())
            {
                name = name.Replace(c, '_');
            }
            return name;
        }

        public static bool isValidUrl(string url)
        {
            return Uri.TryCreate(url, UriKind.Absolute, out Uri? uriResult)
                && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
        }

        public static bool confirmation(string text)
        {
            DialogResult result = MessageBox.Show(
                text,
                "Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            return result == DialogResult.Yes;
        }

        public static void openWithDefaultProgram(string filePath)
        {
            var process = new Process();
            process.StartInfo = new ProcessStartInfo
            {
                FileName = filePath,
                UseShellExecute = true
            };
            process.Start();
        }
    }
}
