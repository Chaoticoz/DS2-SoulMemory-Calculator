using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoulMemory_Calc
{
    public partial class Form1 : Form
    {
        public Dictionary<int, Tuple<int,int>> soulTiers;
        int soulTier;
        static int soulMemory;
        List<MPAction> actionList;
        int minMatchTier= 0;
        int maxMatchTier = 0;
        public static bool isAttached = false;
        public Form1()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            SetupStuff();
            (new Thread(new ThreadStart(this.UpdateMem))).Start();
            txtInput.MaxLength = 9;
            this.TopMost = true;
            Font font = new Font("Consolas", 10.0f);
            foreach (Control control in Controls)
            {
                if(!(control.Text == "Chaoticoz"))
                {
                    control.Font = font;
                }
            }
            
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

        private void SetupStuff()
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

            actionList = new List<MPAction>()
            {
                new MPAction("White Sign Soapstone", 1, 3, true),
                new MPAction("Small White Sign Soapstone", 2, 4, true),
                new MPAction("Red Sign Soapstone", 2, 5),
                new MPAction("Cracked Red Eye Orb", 4, 0),
                new MPAction("Crest of the Rat", 1, 3),
                new MPAction("Guardian's Seal", 4, 5),
                new MPAction("Dragon Eye", 5, 5),
                new MPAction("Cracked Blue Eye Orb", 3, 3),
                new MPAction("Bell Keeper's Seal", 3, 1)
            };

            foreach(MPAction ac in actionList){
                cmbAction.Items.Add(ac.clearName);
            }

            cmbAction.SelectedIndex = 0;
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
                foreach(MPAction ac in actionList)
                {
                    if(ac.clearName == cmbAction.SelectedItem.ToString())
                    {
                        if (ac.changedByRing)
                        {
                            if (chkRing.Checked)
                            {
                                maxMatchTier = soulTier + ac.upperTier + 3;
                                minMatchTier = soulTier - ac.lowerTier - 3;
                            }
                            else
                            {
                                maxMatchTier = soulTier + ac.upperTier;
                                minMatchTier = soulTier - ac.lowerTier;
                            }

                        }
                        else
                        {
                            maxMatchTier = soulTier + ac.upperTier;
                            minMatchTier = soulTier - ac.lowerTier;
                        }
                        if (minMatchTier < 1) { minMatchTier = 1; }
                        if (maxMatchTier > 44) { maxMatchTier = 44; }

                        
                        soulTiers.TryGetValue(minMatchTier, out Tuple<int, int> res);
                        soulTiers.TryGetValue(maxMatchTier, out Tuple<int, int> res2);
                        lblMin.Text = string.Format("{0:#,0}", res.Item1);
                        lblMax.Text = string.Format("{0:#,0}", res2.Item2);
                    }
                }

            }
        }
        private void chkRing_CheckedChanged(object sender, EventArgs e)
        {
            UpdateLabels();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void cmbAction_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateLabels();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://github.com/Chaoticoz/DS2-SoulMemory-Calculator"));
        }

        public void UpdateMem()
        {
            while (true)
            {
                Thread.Sleep(100);

                if (Memoryold.ProcessHandle == IntPtr.Zero)
                {
                    txtInput.Enabled = true;
                    isAttached = false;
                    Memoryold.ProcessHandle = Memoryold.AttachProc("DarkSoulsII");
                }
                else
                {
                    isAttached = true;

                }
                if (!Memoryold.isRunning)
                {
                    txtInput.Enabled = true;
                    isAttached = false;
                    Memoryold.ProcessHandle = Memoryold.AttachProc("DarkSoulsII");
                }
                if (isAttached)
                {
                    soulMemory = JunkCode.getSoulMemory();
                    if(soulMemory != 0)
                    {
                        txtInput.Text = soulMemory.ToString();
                        txtInput.Enabled = false;
                    }
                    else
                    {
                        txtInput.Enabled = true;
                    }
                }
            }

            
        }
    }
   
    public class MPAction
    {
        public int lowerTier { get; }
        public int upperTier { get; }
        public string clearName { get; }
        public bool changedByRing { get; }

        public MPAction(String clearName, int lowerTier, int upperTier, bool changedByRing = false)
        {
            this.clearName = clearName;
            this.lowerTier = lowerTier;
            this.upperTier = upperTier;
            this.changedByRing = changedByRing;
        }
    }
}
