using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YGOProComboCalculator.Custom;
using YGOProComboCalculator.Model;

namespace YGOProComboCalculator
{
    public partial class CurrentCombosWindow : CustomForm
    {
        private List<List<Card>> _combos;

        public CurrentCombosWindow(List<List<Card>> combos)
        {
            InitializeComponent();
            _combos = combos;
            richTextBox1.Text = $"Current Combos ({_combos.Count}):\n\n";
            foreach (var combo in _combos)
            {
                richTextBox1.Text+=("Combo: "+String.Join(", ", combo)+"\n\n");
            }
        }

    }
}
