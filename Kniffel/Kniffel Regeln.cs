using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Kniffel
{
    public partial class Kniffel_Regeln : Form
    {
        Hauptmenü hauptmenü;

        public Kniffel_Regeln(Hauptmenü hauptmenü)
        {
            this.hauptmenü = hauptmenü;

            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string spielregeln = "https://www.spielregeln.de/kniffel-regeln-ablauf-spielanleitung.html";
            Process.Start(spielregeln);
        }

        private void Kniffel_Regeln_FormClosing(object sender, FormClosingEventArgs e)
        {
            hauptmenü.zerstöreRegeln();
        }
    }
}
