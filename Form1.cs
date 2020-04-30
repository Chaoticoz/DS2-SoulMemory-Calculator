using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoulMemory_Calc
{
    public partial class Form1 : Form
    {
        public Dictionary<int, Tuple<int,int>> soulTiers;
        int soulTier;

        public Form1()
        {
            InitializeComponent();
            SetupDictionary();
            txtInput.MaxLength = 9;
            this.TopMost = true;
        }


        private void txtInput_TextChanged(object sender, EventArgs e)
        {
            UpdateLabels();
        }

        private void txtInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verify that the pressed key isn't CTRL or any non-numeric digit
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // If you want, you can allow decimal (float) numbers
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }

            
        }

        private Tuple<int,int> getMatchingSoulLevels(int soulTier)
        {
            int minMatchTier, maxMatchTier;
            int minMatchSM, maxMatchSM;
            minMatchTier = chkRing.Checked ? soulTier - 6 : soulTier - 3;
            if(minMatchTier <=0) { minMatchTier = 1; }
            maxMatchTier = chkRing.Checked ? soulTier + 4 : soulTier + 1;
            if(maxMatchTier > 44) { maxMatchTier = 44; }

            soulTiers.TryGetValue(minMatchTier, out Tuple<int, int> resMin);
            minMatchSM = resMin.Item1;
            soulTiers.TryGetValue(maxMatchTier, out Tuple<int, int> resMax);
            maxMatchSM = resMax.Item2;
            return Tuple.Create(minMatchSM, maxMatchSM);

        }
        private int getTierFromSoulMemory(int sm)
        {
            for (int i = 1; i <= 44; i++)
            {
                soulTiers.TryGetValue(i, out Tuple<int, int> res);
                if (sm >= res.Item1 && sm <= res.Item2)
                {
                    return i;
                }
            }
            return 0;
        }
        private void SetupDictionary()
        {
            soulTiers = new Dictionary<int, Tuple<int, int>>();

            soulTiers.Add(1, Tuple.Create(0, 9999));
            soulTiers.Add(2, Tuple.Create(10000, 19999));
            soulTiers.Add(3, Tuple.Create(20000, 29999));
            soulTiers.Add(4, Tuple.Create(30000, 39999));
            soulTiers.Add(5, Tuple.Create(40000, 49999));
            soulTiers.Add(6, Tuple.Create(50000, 69999));
            soulTiers.Add(7, Tuple.Create(70000, 89999));
            soulTiers.Add(8, Tuple.Create(90000, 109999));
            soulTiers.Add(9, Tuple.Create(110000, 129999));
            soulTiers.Add(10, Tuple.Create(130000, 149999));
            soulTiers.Add(11, Tuple.Create(150000, 179999));
            soulTiers.Add(12, Tuple.Create(180000, 209999));
            soulTiers.Add(13, Tuple.Create(210000, 239999));
            soulTiers.Add(14, Tuple.Create(240000, 269999));
            soulTiers.Add(15, Tuple.Create(270000, 299999));
            soulTiers.Add(16, Tuple.Create(300000, 349999));
            soulTiers.Add(17, Tuple.Create(350000, 399999));
            soulTiers.Add(18, Tuple.Create(400000, 449999));
            soulTiers.Add(19, Tuple.Create(450000, 499999));
            soulTiers.Add(20, Tuple.Create(500000, 599999));
            soulTiers.Add(21, Tuple.Create(600000, 699999));
            soulTiers.Add(22, Tuple.Create(700000, 799999));
            soulTiers.Add(23, Tuple.Create(800000, 899999));
            soulTiers.Add(24, Tuple.Create(900000, 999999));
            soulTiers.Add(25, Tuple.Create(1000000, 1099999));
            soulTiers.Add(26, Tuple.Create(1100000, 1199999));
            soulTiers.Add(27, Tuple.Create(1200000, 1299999));
            soulTiers.Add(28, Tuple.Create(1300000, 1399999));
            soulTiers.Add(29, Tuple.Create(1400000, 1499999));
            soulTiers.Add(30, Tuple.Create(1500000, 1749999));
            soulTiers.Add(31, Tuple.Create(1750000, 1999999));
            soulTiers.Add(32, Tuple.Create(2000000, 2249999));
            soulTiers.Add(33, Tuple.Create(2250000, 2499999));
            soulTiers.Add(34, Tuple.Create(2500000, 2749999));
            soulTiers.Add(35, Tuple.Create(2750000, 2999999));
            soulTiers.Add(36, Tuple.Create(3000000, 4999999));
            soulTiers.Add(37, Tuple.Create(5000000, 6999999));
            soulTiers.Add(38, Tuple.Create(7000000, 8999999));
            soulTiers.Add(39, Tuple.Create(9000000, 11999999));
            soulTiers.Add(40, Tuple.Create(12000000, 14999999));
            soulTiers.Add(41, Tuple.Create(15000000, 19999999));
            soulTiers.Add(42, Tuple.Create(20000000, 29999999));
            soulTiers.Add(43, Tuple.Create(30000000, 44999999));
            soulTiers.Add(44, Tuple.Create(45000000, 999999999));

        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }
        private void UpdateLabels()
        {
            if (txtInput.Text == "") { return; }

            try
            {
                soulTier = getTierFromSoulMemory(Int32.Parse(txtInput.Text));
            }
            catch (Exception ex)
            {

            }
            if (soulTier != 0)
            {
                lblMin.Text = "Min : " + getMatchingSoulLevels(soulTier).Item1.ToString();
                lblMax.Text = "Max : " + getMatchingSoulLevels(soulTier).Item2.ToString();
            }
        }
        private void chkRing_CheckedChanged(object sender, EventArgs e)
        {
            UpdateLabels();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://github.com/Chaoticoz/DS2-SoulMemory-Calculator"));
        }
    }
}
