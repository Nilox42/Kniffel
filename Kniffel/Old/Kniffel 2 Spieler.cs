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
    
    public partial class Kniffel_2_Spieler : Form
    {
        public Kniffel_2_Spieler()
        {
            InitializeComponent();
        }

        private void btHauptmenue_Click(object sender, EventArgs e)
        {
            this.Close();
            Hauptmenü hauptmenue = new Hauptmenü();
            hauptmenue.Show();
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            
        }

        private void WürfelTimer_Tick(object sender, EventArgs e)
        {

        }

        private void btRegeln_Click(object sender, EventArgs e)
        {
            Kniffel_Regeln regeln = new Kniffel_Regeln();
            regeln.imSpiel = true;
            regeln.Show();
        }
    }
}
