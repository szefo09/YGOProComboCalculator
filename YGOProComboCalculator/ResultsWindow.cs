using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using YGOProComboCalculator.Model;
using YGOProComboCalculator.Services;

namespace YGOProComboCalculator
{
    public partial class ResultsWindow : Form
    {
        private List<List<Card>> _combos;
        private List<int> _deckMain;
        private List<List<int>> _combosIds = new List<List<int>>();
        private int _globalCombosCount;
        private bool goBack = false;
        private decimal _reshuffleAmount;
        private short handSize;
        private List<string> logs = new List<string>();
        private string LastComboLogFileName;
        private readonly string _logsFolder = "YGOPro Combo Calculator Logs";
        private string _deckName;
        public ResultsWindow(List<List<Card>> combos,Decklist deck, decimal reshuffleAmount, bool goFirst)
        {
            InitializeComponent();
            _combos = combos;
            _reshuffleAmount = reshuffleAmount;
            SetHandSize(goFirst);
            numericUpDown1.Value = _reshuffleAmount;
            foreach (var combo in _combos)
            {
                List<int> comboIds = combo.Select(x => x.Id).Distinct().ToList();
                _combosIds.Add(comboIds);
            }
            _deckMain = deck.Main.ToList();
            _deckName = deck.Name;
            CalculateResults();
        }
        private void CalculateResults()
        {
            int[] comboCount = new int[_combos.Count];
            for (int i = 0; i < _reshuffleAmount; i++)
            {
                List<int> randomHand = Decklist.rand(_deckMain).GetRange(0, handSize);
                bool firstFound = true;
                for (int j = 0; j < _combosIds.Count; j++)
                {
                    
                    bool resultFound = false;
                    List<int> combo = _combosIds[j];
                    if (ListComparer.ContainsAllItems(randomHand, combo))
                    {
                        resultFound = true;
                        comboCount[j]++;
                        if (firstFound)
                        {
                            _globalCombosCount++;
                            firstFound = false;
                        }
                    }
                    List<Card> randomHandCard = new List<Card>();
                    foreach (var c in randomHand)
                    {
                        randomHandCard.Add(CardsManager.GetCard(c));
                    }
                    logs.Add("Hand number " + i.ToString() + " Combo number: " + j.ToString() + " Found combo: " + resultFound + " Combo: " + string.Join(", ", _combos[j]) + " Hand: " + string.Join(", ", randomHandCard));
                } 
            }
            for (int j = 0; j < _combosIds.Count; j++)
            {
                logs.Add("\nResult for Combo" + j.ToString() + " is: " + comboCount[j].ToString() + "\n");
            }
            for (int i = 0; i < _combos.Count; i++)
            {
                DisplayResults(_combos[i], comboCount[i]);
            }
            decimal percentage = GetPercentage(_globalCombosCount, _reshuffleAmount);
            amountLabel.Text = _globalCombosCount.ToString() + " out of "+ _reshuffleAmount + " hands = " + percentage.ToString()+"%";
            LastComboLogFileName = $"ComboLogs_{_deckName}_{DateTime.Now.ToString("yyyyMMddTHHmmss")}.txt";
            try
            {
                if (!Directory.Exists(_logsFolder))
                {
                    Directory.CreateDirectory(_logsFolder);
                }
                File.WriteAllLines(Path.Combine(_logsFolder, LastComboLogFileName), logs);
            }
            catch
            {
                MessageBox.Show("The app experienced issues exporting logs into the folder.","Error saving logs to the logs folder",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            logs.Clear();
        }
        private void DisplayResults(List<Card> combo,int result)
        {
            var nameOfCombo = String.Join(", ", combo);
            ListViewItem listViewItem1 = new ListViewItem(nameOfCombo);
            listViewItem1.SubItems.Add(result.ToString());
            listViewItem1.SubItems.Add(GetPercentage(result, _reshuffleAmount).ToString());
            listView1.Items.Add(listViewItem1);
        }
        private decimal GetPercentage(int count,decimal reshuffleAmount)
        {
            return Math.Round((count / reshuffleAmount) * 100, 2);
        }
        private void ResultsWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!goBack)
            {
                Environment.Exit(1);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _globalCombosCount = 0;
            listView1.Items.Clear();
            _reshuffleAmount = numericUpDown1.Value;
            SetHandSize(GoFirstCheckbox.Checked);
            CalculateResults();
        }

        private void GoBackToComboMenu_Click(object sender, EventArgs e)
        {
            goBack = true;
            this.Dispose();
        }

        private void SetHandSize(bool goFirst)
        {
            if (goFirst)
            {
                handSize = 5;
            }
            else
            {
                handSize = 6;
            }
        }

        private void OpenLogsButton_Click(object sender, EventArgs e)
        {
            Process.Start(Path.Combine(_logsFolder,LastComboLogFileName));
        }
    }
}
