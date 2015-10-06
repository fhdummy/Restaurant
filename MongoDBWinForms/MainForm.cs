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

        private async void buttonCopy_Click(object sender, EventArgs e)
        {
            Entry toCopy = listBox1.SelectedItem as Entry;
            Entry newEntry = new Entry();
            if (toCopy == null)
            {
                return;
            }

            newEntry.Name = toCopy.Name;
            newEntry.CategoryId = toCopy.CategoryId;
            newEntry.Location = toCopy.Location;

            entryRepository.Add(newEntry);

            await UpdateEntryDataSource();
        }
    }
}
