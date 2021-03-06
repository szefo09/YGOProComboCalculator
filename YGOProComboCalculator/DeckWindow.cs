﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using YGOProComboCalculator.Custom;
using YGOProComboCalculator.Model;

namespace YGOProComboCalculator
{
    public partial class DeckWindow : CustomForm
    {
        private List<List<Card>> _combos = new List<List<Card>>();
        private Decklist _decklist;
        private bool goBack = false;
        public DeckWindow(Decklist decklist)
        {
            InitializeComponent();
            _decklist = decklist;
            LoadCardsToDecklistBox();
        }
        private void LoadCardsToDecklistBox()
        {
            DeckListBox.Items.Clear();
            try
            {
                DeckListBox.Items.AddRange(_decklist.CardMain.ToArray());
            }
            catch
            {
                MessageBox.Show("Error loading the selected decklist. Make sure the decklist contains cards.");
            }
        }

        private void DeckWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!goBack)
            {
                Environment.Exit(1);
            }
        }

        private void DeckListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = this.DeckListBox.IndexFromPoint(e.Location);
            if (index != System.Windows.Forms.ListBox.NoMatches)
            {
                Card card = (Card)DeckListBox.Items[index];
                if (ComboListBox.Items.Cast<Card>().Where(x => x.Id == card.Id).Count() < 3)
                {
                    ComboListBox.Items.Add(card);
                }

            }
        }

        private void ComboListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = this.ComboListBox.IndexFromPoint(e.Location);
            if (index != System.Windows.Forms.ListBox.NoMatches)
            {
                Card card = (Card)ComboListBox.Items[index];
                DeckListBox.Items.Add(card);
                ComboListBox.Items.Remove(card);
            }
        }

        private void AddAnotherButton_Click(object sender, EventArgs e)
        {
            List<Card> combo = ComboListBox.Items.Cast<Card>().ToList();
            if (combo.Count > 0)
            {
                _combos.Add(combo);
            }
            ComboListBox.Items.Clear();
            LoadCardsToDecklistBox();
        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            List<Card> combo = ComboListBox.Items.Cast<Card>().ToList();
            if (combo.Count == 0 && _combos.Count == 0)
            {
                return;
            }
            if (combo.Count > 0)
            {
                _combos.Add(combo);
            }

            ResultsWindow resultsWindow = new ResultsWindow(_combos, _decklist, numericUpDown1.Value, GoFirstCheckbox.Checked);
            this.Hide();
            resultsWindow.ShowDialog();
            resultsWindow.Dispose();
            this.Show();
            ComboListBox.Items.Clear();
        }

        private void ResetCombosButton_Click(object sender, EventArgs e)
        {
            _combos.Clear();
            ComboListBox.Items.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            goBack = true;
            this.Dispose();
        }

        private void ViewAlreadyAddedCombos(object sender, EventArgs e)
        {
            CurrentCombosWindow currentCombosWindow = new CurrentCombosWindow(_combos);
            currentCombosWindow.ShowDialog();
            currentCombosWindow.Dispose();
        }
    }
}
