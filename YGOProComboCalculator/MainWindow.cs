using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using YGOProComboCalculator.Model;
using YGOProComboCalculator.Services;

namespace YGOProComboCalculator
{
    public partial class MainWindow : Form
    {
        private List<Decklist> Decks = new List<Decklist>();
        public MainWindow()
        {
            InitializeComponent();
            LoadCDBs();
            LoadDecks();
            listBox1.DataSource = Decks;
            //listBox1.DataSource = new BindingSource(Decks, null);
            listBox1.DisplayMember = "Name";
            //listBox1.DisplayMember = "Value";
            //listBox1.ValueMember = "Key";
        }

        private void LoadCDBs()
        {
            try
            {
                FileInfo[] fileInfos = (new DirectoryInfo("cdb")).GetFiles().OrderByDescending(x => x.Name).ToArray(); //load cards.cdb last this way
                for (int i = 0; i < fileInfos.Length; i++)
                {
                    if (fileInfos[i].Name.Length > 4)
                    {
                        if (fileInfos[i].Name.Substring(fileInfos[i].Name.Length - 4, 4) == ".cdb")
                        {
                            CardsManager.initialize("cdb/" + fileInfos[i].Name);
                        }
                    }
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString() + "\n\n\nPlace the app in your YGOPro2 folder.\nIf this app is in YGOPro2 folder, send a screenshot of  this message to Szefo09", "Error loading files! Place this app in YGOPro2 folder!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(1);
            }

        }
        private void LoadDecks()
        {
            try
            {
                FileInfo[] fileInfos = (new DirectoryInfo("deck")).GetFiles().OrderByDescending(x => x.Name).ToArray();
                for (int i = 0; i < fileInfos.Length; i++)
                {
                    if (fileInfos[i].Name.Length > 4)
                    {
                        if (fileInfos[i].Name.Substring(fileInfos[i].Name.Length - 4, 4) == ".ydk")
                        {
                            var Decklist = new Decklist(fileInfos[i].FullName);
                            Decks.Add(Decklist);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString() + "\n\n\nPlace the app in your YGOPro2 folder.\nIf this app is in YGOPro2 folder, send a screenshot of  this message to Szefo09", "Error loading files! Place this app in YGOPro2 folder!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(1);
            }
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = this.listBox1.IndexFromPoint(e.Location);
            if (index != System.Windows.Forms.ListBox.NoMatches)
            {
                Decklist decklist = (Decklist)listBox1.Items[index];
                DeckWindow deckWindow = new DeckWindow(decklist);
                this.Hide();
                deckWindow.ShowDialog();
                deckWindow.Dispose();
                this.Show();
            }
        }
    }
}
