using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Bson;
using Restaurant.Model;

namespace Restaurant
{
    /// <summary>
    /// Represents the main form of the application
    /// </summary>
    public partial class TextboxMain : Form
    {
        private static TextboxMain _instance;
        public Repository<Entry> entryRepository;
        public Repository<Category> categoryRepository;
        private NewForm myNewForm = null;

        /// <summary>
        /// c'tor
        /// </summary>

        public static TextboxMain getInstance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new TextboxMain();
                }
                return _instance;
            }
        }

        private TextboxMain()
        {
            InitializeComponent();
        }
        
        protected async override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            myNewForm = new NewForm();
            entryRepository = new Repository<Entry>("RestaurantDemo", "Entry");
            categoryRepository = new Repository<Category>("RestaurantDemo", "Category");

            await UpdateEntryDataSource();
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            myNewForm.showAsNew();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            Entry editEntry = listBox1.SelectedItem as Entry;
            if (editEntry == null)
            {
                return;
            }

            myNewForm.showAsEdit(editEntry);
        }
        
        public async Task UpdateEntryDataSource()
        {
            listBox1.DataSource = null;
            listBox1.DisplayMember = "Name";
            listBox1.DataSource = await entryRepository.GetAll();
        }

        private async void buttonDelete_Click(object sender, EventArgs e)
        {
            Entry newEntry = listBox1.SelectedItem as Entry;
            if (newEntry == null)
            {
                return;
            }
            entryRepository.Delete(newEntry.Id);

            await UpdateEntryDataSource();
        }

        /*protected async override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            _albumRepository = new Repository<Album>("PhotobaseDemo", "Album");

            await UpdateAlbumDataSource();
        }

        private async Task UpdateAlbumDataSource()
        {
            _lstAlbum.DataSource = null;
            _lstAlbum.DisplayMember = "Name";
            _lstAlbum.DataSource = await _albumRepository.GetAll();
        }
        private void UpdatePhotoDataSource()
        {
            _lstPhoto.DataSource = null;

            Album album = _lstAlbum.SelectedItem as Album;
            if (album == null)
            {
                return;
            }
            _lstPhoto.DisplayMember = "Name";
            _lstPhoto.DataSource = album.Photos;
        }

        private async void _btAddAlbum_Click(object sender, EventArgs e)
        {
            Album album = new Album { Name = _txtAlbum.Text };
            _albumRepository.Add(album);
            _txtAlbum.Text = null;

            await UpdateAlbumDataSource();
        }
        private async void _btDeleteAlbum_Click(object sender, EventArgs e)
        {
            Album album = _lstAlbum.SelectedItem as Album;
            if (album == null)
            {
                return;
            }
            _albumRepository.Delete(album.Id);

            await UpdateAlbumDataSource();
        }

        private void _txtAlbum_TextChanged(object sender, EventArgs e)
        {
            _btAddAlbum.Enabled = !string.IsNullOrEmpty(_txtAlbum.Text);
            _btDeleteAlbum.Enabled = !string.IsNullOrEmpty(_txtAlbum.Text);
        }

        private void _lstAlbum_SelectedValueChanged(object sender, EventArgs e)
        {
            _btAddPhoto.Enabled = _lstAlbum.SelectedItem != null;
            _btDeleteAlbum.Enabled = _lstAlbum.SelectedItem != null;

            UpdatePhotoDataSource();
        }

        private async void _btAddPhoto_Click(object sender, EventArgs e)
        {
            Album album = _lstAlbum.SelectedItem as Album;
            if (album == null)
            {
                return;
            }

            if (album.Photos == null)
            {
                album.Photos = new List<Photo>();
            }

            OpenFileDialog openFileDialog = new OpenFileDialog { Filter = "Image Files|*.png;*.jpg;*.jpeg" };
            if (openFileDialog.ShowDialog(this) != DialogResult.OK)
                return;

            Photo photo = new Photo
            {
                Name = Path.GetFileName(openFileDialog.FileName)
            };
            using (var stream = File.OpenRead(openFileDialog.FileName))
            {
                photo.PhotoBinaryObjectId = await _albumRepository.UploadBinaryContent(photo.Name, stream);
            }
            album.Photos.Add(photo);

            _albumRepository.Update(album);
            UpdatePhotoDataSource();
            _lstPhoto.SelectedItem = photo;
        }

        private async void _btPhotoDelete_Click(object sender, EventArgs e)
        {
            Photo photo = _lstPhoto.SelectedItem as Photo;
            if (photo == null)
            {
                return;
            }

            Album album = _lstAlbum.SelectedItem as Album;
            if (album == null)
            {
                return;
            }

            album.Photos.Remove(photo);
            _albumRepository.Update(album);
            await UpdateAlbumDataSource();
        }

        private async void _lstPhoto_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                Photo photo = _lstPhoto.SelectedItem as Photo;
                if (photo == null)
                {
                    _pictureBox.Image = null;
                    return;
                }

                using (Stream stream = await _albumRepository.DownloadBinaryContent(photo.PhotoBinaryObjectId))
                {
                    _pictureBox.Image = Image.FromStream(stream);
                }
            }
            catch (Exception)
            {
                _pictureBox.Image = null;
            }
        }*/
    }
}
