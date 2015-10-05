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

        public  void showAsNew()
        {
            this.clearAll();
            this.Show();
            synchroniseCategory();
        }

        private async void synchroniseCategory()
        {
            textBoxCategory.DataSource = null;
            textBoxCategory.DisplayMember = "Name";
            textBoxCategory.DataSource = await categoryRepository.GetAll();
        }

        public async void showAsEdit(Entry newEntry)
        {
            this.clearAll();
            this.Show();
            synchroniseCategory();

            Category tempCat;

            tempCat = await categoryRepository.FindbyId(newEntry.CategoryId);

            editFlag = true;
            editEntry = newEntry;
            textBoxName.Text = newEntry.Name;
            textBoxCategory.Text = tempCat.Name;
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
            Category tempCat;

            if (editFlag == true)
            {
                if (textBoxName.Text.Trim() == "")
                {
                    labelError.Show();
                    return;
                }
                if (textBoxLocation.Text.Trim() == "")
                {
                    labelError.Show();
                    return;
                }
                if (textBoxCategory.SelectedItem == null)
                {
                    if (textBoxCategory.Text.Trim() == "")
                    {
                        labelError.Show();
                        return;
                    }
                    tempCat = new Category(Name = textBoxCategory.Text);
                    categoryRepository.Add(tempCat);
                }
                else
                {
                    tempCat = (textBoxCategory.SelectedItem as Category);
                }
                editEntry.Name = textBoxName.Text;
                editEntry.CategoryId = tempCat.Id;
                editEntry.Location = textBoxLocation.Text;
                editFlag = false;
                entryRepository.Update(editEntry);
                await myTextboxMain.UpdateEntryDataSource();
                this.Hide();
                this.clearAll();
            }
            else
            {
                if (textBoxName.Text.Trim() == "")
                {
                    labelError.Show();
                    return;
                }
                if (textBoxCategory.Text == "")
                {
                    labelError.Show();
                    return;
                }
                if(textBoxCategory.SelectedItem == null)
                {
                    if(textBoxCategory.Text.Trim() == "")
                    {
                        labelError.Show();
                        return;
                    }
                    tempCat = new Category(Name = textBoxCategory.Text);
                    categoryRepository.Add(tempCat);
                }
                else
                {
                    tempCat = (textBoxCategory.SelectedItem as Category);
                }
                    
                Entry newEntry = new Entry { Name = textBoxName.Text, CategoryId = tempCat.Id, Location = textBoxLocation.Text };
                entryRepository.Add(newEntry);
                    
                await myTextboxMain.UpdateEntryDataSource();
                this.Hide();
                this.clearAll();
            }
        }
    }
}
