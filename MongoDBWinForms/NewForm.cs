using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Restaurant;
using Restaurant.Model;

namespace Restaurant
{
    public partial class NewForm : Form
    {
        public Repository<Entry> entryRepository;
        public Repository<Category> categoryRepository;
        private TextboxMain myTextboxMain = null;
        private bool editFlag = false;
        private Entry editEntry = null;

        public NewForm()
        {
            InitializeComponent();
            entryRepository = new Repository<Entry>("RestaurantDemo", "Entry");
            categoryRepository = new Repository<Category>("RestaurantDemo", "Category");
            myTextboxMain = TextboxMain.getInstance;
        }

        public void showAsNew()
        {
            this.clearAll();
            this.Show();
        }

        public void showAsEdit(Entry newEntry)
        {
            this.clearAll();
            this.Show();

            editFlag = true;
            editEntry = newEntry;
            textBoxName.Text = newEntry.Name;
            textBoxLocation.Text = newEntry.Location;
        }

        private void clearAll()
        {
            textBoxName.Text = "";
            textBoxLocation.Text = "";
            textBoxCategory.Text = "";
        }

        private void NewForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true; // cancels close event
        }

        private async void buttonSave_Click(object sender, EventArgs e)
        {
            if (editFlag == true)
            {
                if (textBoxName.Text.Trim() == "")
                {
                    labelError.Show();
                }
                else if (textBoxLocation.Text.Trim() == "")
                {
                    labelError.Show();
                }
                else if (textBoxCategory.Text == "")
                {
                    labelError.Show();
                }
                else
                {
                    editEntry.Name = textBoxName.Text;
                    editEntry.Location = textBoxLocation.Text;
                    editFlag = false;
                    entryRepository.Update(editEntry);
                    await myTextboxMain.UpdateEntryDataSource();
                    this.Hide();
                    this.clearAll();
                }
            }
            else
            {
                if (textBoxName.Text.Trim() == "")
                {
                    labelError.Show();
                }
                else if (textBoxLocation.Text.Trim() == "")
                {
                    labelError.Show();
                }
                else if (textBoxCategory.Text == "")
                {
                    labelError.Show();
                }
                else
                {
                    Entry newEntry = new Entry { Name = textBoxName.Text, CategoryId = System.Guid.NewGuid(), Location = textBoxLocation.Text };
                    entryRepository.Add(newEntry);
                    await myTextboxMain.UpdateEntryDataSource();
                    this.Hide();
                    this.clearAll();
                }
            }
        }
    }
}
