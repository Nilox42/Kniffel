using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kniffel
{
    public partial class Hauptmenü : Form
    {
        public Hauptmenü()
        {
            InitializeComponent();
        }

        private void btSpieler2_Click(object sender, EventArgs e)
        {
            Kniffel_2_Spieler spieler2 = new Kniffel_2_Spieler();
            spieler2.Show();
            this.Hide();
        }

        private void btSpieler3_Click(object sender, EventArgs e)
        {
            Kniffel_3_Spieler spieler3 = new Kniffel_3_Spieler();
            spieler3.Show();
            this.Hide();
        }

        private void btSpieler4_Click(object sender, EventArgs e)
        {
            Kniffel_4_Spieler spieler4 = new Kniffel_4_Spieler();
            spieler4.Show();
            this.Hide();
        }

        private void btSpieler5_Click(object sender, EventArgs e)
        {
            Kniffel_5_Spieler spieler5 = new Kniffel_5_Spieler();
            spieler5.Show();
            this.Hide();
        }

        private void btRegeln_Click(object sender, EventArgs e)
        {
            Kniffel_Regeln regeln = new Kniffel_Regeln();
            regeln.Show();
            this.Hide();
        }

        private void btMinimieren_Click(object sender, EventArgs e)
        {

        }

        private void btSchliessen_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
