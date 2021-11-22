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
    public partial class Kniffel_4_Spieler : Form
    {
        public Kniffel_4_Spieler()
        {
            InitializeComponent();
        }

        private void btHauptmenue_Click(object sender, EventArgs e)
        {
            this.Close();
            Hauptmenü hauptmenue = new Hauptmenü();
            hauptmenue.Show();
        }
    }
}
