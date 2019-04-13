using System;
using System.ComponentModel;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Windows.Forms;

namespace WslManager
{
    public partial class DownloadDistroForm : Form
    {
        public DownloadDistroForm()
        {
            InitializeComponent();
        }

        private string GetConfirmedTempFilePath(string ext)
        {
            var tempFilePath = Path.Combine(
                Path.GetTempPath(),
                Guid.NewGuid().ToString("n") + "." + ext.Trim().TrimStart('.'));

            if (Directory.Exists(tempFilePath))
                Directory.Delete(tempFilePath, true);

            if (File.Exists(tempFilePath))
                File.Delete(tempFilePath);

            return tempFilePath;
        }

        public string DownloadUrl { get; set; }

        public string LocalFilePath { get; private set; }

        private void DownloadDistroForm_Load(object sender, EventArgs e)
        {
            if (!Uri.TryCreate(DownloadUrl, UriKind.Absolute, out Uri downloadUri))
                return;

            DownloadUrl = downloadUri.AbsoluteUri;
            BackgroundWorker.RunWorkerAsync();
        }

        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var received = 0;
            var receivedBuffer = new byte[64000];
            var tempAppxFilePath = GetConfirmedTempFilePath(".zip");
            var tempTarGzipFilePath = GetConfirmedTempFilePath(".tar.gz");

            var request = HttpWebRequest.CreateHttp(DownloadUrl);
            request.AllowAutoRedirect = true;

            using (var response = request.GetResponse())
            {
                var totalContentLength = response.ContentLength;
                var stream = response.GetResponseStream();

                using (Stream appxFileStream = File.OpenWrite(tempAppxFilePath))
                {
                    BackgroundWorker.ReportProgress(0);
                    var accReceivedContentLength = 0L;

                    while ((received = stream.Read(receivedBuffer, 0, receivedBuffer.Length)) > 0)
                    {
                        appxFileStream.Write(receivedBuffer, 0, received);
                        accReceivedContentLength += received;

                        var receivedPercentage = Math.Max(0, Math.Min(99, (int)(accReceivedContentLength / (double)totalContentLength * 100d))) / 2;
                        BackgroundWorker.ReportProgress(receivedPercentage);
                    }

                    if (totalContentLength != accReceivedContentLength)
                    {
                        BackgroundWorker.ReportProgress(0);
                        throw new Exception("Downloading file failed.");
                    }

                    BackgroundWorker.ReportProgress(50);
                }
            }

            using (Stream appxFileStream = File.OpenRead(tempAppxFilePath))
            using (var zipArchive = new ZipArchive(appxFileStream, ZipArchiveMode.Read, false))
            {
                var installTarGzEntry = zipArchive
                    .Entries
                    .Where(x => x.Name.EndsWith(".tar.gz", StringComparison.OrdinalIgnoreCase) || x.Name.EndsWith(".tgz", StringComparison.OrdinalIgnoreCase))
                    .SingleOrDefault();

                var copied = 0;
                var copiedBuffer = new byte[64000];
                var totalFileLength = installTarGzEntry.Length;
                var accCopiedFileLength = 0L;

                var installTarGzStream = installTarGzEntry.Open();

                using (Stream tgzFileStream = File.OpenWrite(tempTarGzipFilePath))
                {
                    while ((copied = installTarGzStream.Read(copiedBuffer, 0, copiedBuffer.Length)) > 0)
                    {
                        tgzFileStream.Write(copiedBuffer, 0, copied);
                        accCopiedFileLength += copied;

                        var copiedPercentage = 50 + Math.Max(0, Math.Min(99, (int)(accCopiedFileLength / (double)totalFileLength * 100d))) / 2;
                        BackgroundWorker.ReportProgress(copiedPercentage);
                    }
                }
            }

            e.Result = tempTarGzipFilePath;
            File.Delete(tempAppxFilePath);
        }

        private void BackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            int value = e.ProgressPercentage;
            ProgressBar.Value = value;
        }

        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            string message;

            if (e.Error != null)
            {
                ProgressBar.Value = 0;
                message = $"Unexpected error occurred: {e.Error.Message}";
                RetryButton.Visible = true;
                
                MessageBox.Show(this, message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }

            if (e.Cancelled)
            {
                ProgressBar.Value = 0;
                message = "Download task cancelled.";
                RetryButton.Visible = true;

                MessageBox.Show(this, message, Text, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return;
            }

            var tempFilePath = e.Result as string;

            if (tempFilePath == null || !File.Exists(tempFilePath))
            {
                ProgressBar.Value = 0;
                message = "Cannot open downloaded file.";
                RetryButton.Visible = true;

                MessageBox.Show(this, message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }

            ProgressBar.Value = 100;
            message = "Download completed.";
            RetryButton.Visible = false;

            LocalFilePath = tempFilePath;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void RetryButton_Click(object sender, EventArgs e)
        {
            if (!Uri.TryCreate(DownloadUrl, UriKind.Absolute, out Uri downloadUri))
                return;

            DownloadUrl = downloadUri.AbsoluteUri;
            BackgroundWorker.RunWorkerAsync();
        }

        private void DownloadDistroForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (BackgroundWorker.IsBusy)
                BackgroundWorker.CancelAsync();
        }
    }
}
