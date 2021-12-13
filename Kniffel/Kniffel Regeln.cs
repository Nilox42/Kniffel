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
    public partial class Kniffel_Regeln : Form
    {
        public bool imSpiel { get;  set; }

        Hauptmenü hauptmenü;

        public Kniffel_Regeln(Hauptmenü hauptmenü)
        {
            this.hauptmenü = hauptmenü;

            InitializeComponent();

            if (imSpiel == true)
            {
                btHauptmenue.Visible = false;
            }
            else if (imSpiel == false)
            {
                btHauptmenue.Visible = true;
            }
        }

        private void btHauptmenue_Click(object sender, EventArgs e)
        {
            hauptmenü.zerstöreRegeln();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string spielregeln = "https://www.spielregeln.de/kniffel-regeln-ablauf-spielanleitung.html";
            System.Diagnostics.Process.Start(spielregeln);
        }

        private void Kniffel_Regeln_FormClosing(object sender, FormClosingEventArgs e)
        {
            hauptmenü.zerstöreRegeln();
        }
    }
}
