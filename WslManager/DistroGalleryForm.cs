using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Cache;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WslManager.Models;

namespace WslManager
{
    public partial class DistroGalleryForm : Form
    {
        public DistroGalleryForm()
        {
            InitializeComponent();
        }

        public DistroFeedItem SelectedItem { get; set; }

        private void FeedLoadWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var feedUrl = ConfigurationManager.AppSettings["FeedUrl"];
            var targetUri = new Uri($"{feedUrl}?t={DateTime.UtcNow.Ticks}", UriKind.Absolute);

            using (var client = new WebClient()
            {
                CachePolicy = new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore),
            })
            {
                var feed = default(DistroFeed);
                using (var feedStream = client.OpenRead(targetUri))
                {
                    var deserializer = new DataContractJsonSerializer(typeof(DistroFeed));
                    feed = deserializer.ReadObject(feedStream) as DistroFeed;
                }

                if (feed != null)
                    e.Result = feed;
            }
        }

        private void DistroGalleryForm_Load(object sender, EventArgs e)
        {
            ItemListView.Groups.Add("official", "Official");
            ItemListView.Groups.Add("user_created", "User Created");
            FeedLoadWorker.RunWorkerAsync();
        }

        private void FeedLoadWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(this, $"Cannot load feed data from remote server - {e.Error.Message}", Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }

            if (e.Cancelled)
            {
                MessageBox.Show(this, "Feed data loading cancelled.", Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);
                return;
            }

            var feed = e.Result as DistroFeed;

            if (feed == null)
            {
                MessageBox.Show(this, "Cannot load feed data from remote server.", Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }

            foreach (var eachItem in feed.Items.ToArray())
            {
                var lvItem = new ListViewItem(eachItem.Title);
                lvItem.ImageKey = "linux";
                lvItem.Tag = eachItem;

                if (eachItem.IsOfficialDistro())
                    lvItem.Group = ItemListView.Groups["official"];
                else
                    lvItem.Group = ItemListView.Groups["user_created"];

                lvItem.SubItems.Add(new ListViewItem.ListViewSubItem(lvItem, eachItem.Author.Name));
                ItemListView.Items.Add(lvItem);
            }

            IconLoader.RunWorkerAsync(feed.Items.ToArray());
        }

        private void IconLoader_DoWork(object sender, DoWorkEventArgs e)
        {
            var targetItems = e.Argument as DistroFeedItem[];

            if (targetItems == null || targetItems.Length < 1)
                return;

            var images = new Dictionary<string, Image>();
            foreach (var eachItem in targetItems)
            {
                try
                {
                    var webRequest = WebRequest.Create(eachItem.Image);
                    using (var webResponse = webRequest.GetResponse())
                    {
                        var respStream = webResponse.GetResponseStream();
                        var image = new Bitmap(respStream);
                        respStream.Dispose();
                        images.Add(eachItem.Id, image);
                    }
                }
                catch { }
            }

            e.Result = images;
        }

        private void IconLoader_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null || e.Cancelled)
                return;

            var loadedImages = e.Result as Dictionary<string, Image>;

            if (loadedImages == null || loadedImages.Count < 1)
                return;

            foreach (var eachImage in loadedImages)
            {
                if (DefaultImageList.Images.ContainsKey(eachImage.Key))
                    DefaultImageList.Images.RemoveByKey(eachImage.Key);

                DefaultImageList.Images.Add(eachImage.Key, eachImage.Value);
            }

            foreach (ListViewItem eachItem in ItemListView.Items)
            {
                var tag = eachItem.Tag as DistroFeedItem;

                if (tag == null)
                    continue;

                if (DefaultImageList.Images.ContainsKey(tag.Id))
                    eachItem.ImageKey = tag.Id;
            }
        }

        private void ItemListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            var lvItem = ItemListView.SelectedItems.Cast<ListViewItem>().FirstOrDefault();

            if (lvItem == null)
                return;

            var item = lvItem.Tag as DistroFeedItem;

            if (item == null)
                return;

            DetailView.DocumentText = $@"
<div style=""font-family: Arial, Gulim; font-size: 1.3em;"">
<img src=""{item.Image}"" alt=""{item.Title}"" align=""right"" />
<h1>{item.Title}</h1>
<p><a href=""{item.Author.Url}"" target=""_blank"">{item.Author.Name}</a></p>
<hr />
<p style=""font-size: 0.9em;"">{item.ContentText}</p>
</div>
";
        }

        private void ItemListView_ItemActivate(object sender, EventArgs e)
        {
            InstallButton.PerformClick();
        }

        private void InstallButton_Click(object sender, EventArgs e)
        {
            var lvItem = ItemListView.SelectedItems.Cast<ListViewItem>().FirstOrDefault();

            if (lvItem == null)
                return;

            var item = lvItem.Tag as DistroFeedItem;

            if (item == null)
                return;

            SelectedItem = item;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void ContributeButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this, "Send a pull request to the GitHub repository's feed.json file with information about the distro you want.", Text,
                MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }

        private void BrowseMSStoreButton_Click(object sender, EventArgs e)
        {
            Process.Start("ms-windows-store://search/?query=Linux");
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
