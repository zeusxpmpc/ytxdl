using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace YTXDL
{
    internal class YTDLPHelper
    {
        public async Task<bool> RunYTDLPWithProgressAsync(List<string> args)
        {
            try
            {
                using (Process process = new Process())
                {
                    process.StartInfo.FileName = "yt-dlp.exe";
                    process.StartInfo.Arguments = string.Join(" ", args.Select(a => $"\"{a}\""));
                    process.StartInfo.RedirectStandardOutput = true;
                    process.StartInfo.RedirectStandardError = true;
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.CreateNoWindow = true;

                    process.Start();
                    process.BeginOutputReadLine();
                    process.BeginErrorReadLine();

                    await process.WaitForExitAsync();

                    return process.ExitCode == 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
    }
}
