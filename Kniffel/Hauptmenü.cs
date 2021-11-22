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
        public Kniffel_Regeln kniffel_Regeln;
        public KniffelSpiel kniffelSpiel;

        public Hauptmenü()
        {
            InitializeComponent();
        }

        #region Input
        private void btSpieler2_Click(object sender, EventArgs e)
        {
            erstelleSpiel(2);
        }
        private void btSpieler3_Click(object sender, EventArgs e)
        {
            erstelleSpiel(3);
        }
        private void btSpieler4_Click(object sender, EventArgs e)
        {
            erstelleSpiel(4);
        }
        private void btSpieler5_Click(object sender, EventArgs e)
        {
            erstelleSpiel(5);
        }

        private void btRegeln_Click(object sender, EventArgs e)
        {
            erstelleREgeln();
        }
        #endregion

        //erstelle Kniffel_Regeln und verstecke hauptmenü
        public void erstelleREgeln()
        {
            if (kniffel_Regeln == null)
            {
                kniffel_Regeln = new Kniffel_Regeln();
            }

            kniffel_Regeln.Show();
            this.Hide();
        }

        //erstelle KniffelSpiel Form und gib spieleranzahl und referenz ans Hauptmenü weiter
        private void erstelleSpiel(int spieleranzahl)
        {
            kniffelSpiel = new KniffelSpiel(spieleranzahl, this);
            kniffelSpiel.Show();

            this.Hide();
        }

        

    }
}
