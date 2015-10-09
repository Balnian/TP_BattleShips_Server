using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP_BattleShips_Server
{
    public partial class Form1 : Form
    {
        MatchMakingServeur serv;
        public Form1()
        {
            InitializeComponent();
            AllocConsole();
            serv = new MatchMakingServeur();
            Thread Serveur = new Thread(serv.ListenServeur);
            timer1.Start();
        }
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = serv.GameInstances.Count.ToString();
        }
    }
}
