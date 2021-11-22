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
    public partial class KniffelSpiel : Form
    {
        private Hauptmenü hauptmenü;
        private List<Spieler> teilnehmer = new List<Spieler>();
        private Random zufall;

        private int spieleranzahl;
        private int spieler = 1;
        private int wurfzahl = 0;

        private List<int> letzterwurf = new List<int>();
        private bool[] würfelstatus = { true, true, true, true, true };

        public KniffelSpiel(int spieleranzahl, Hauptmenü hauptmenü)
        {
            this.spieleranzahl = spieleranzahl;
            this.hauptmenü = hauptmenü;
            zufall = new Random();

            InitializeComponent();
        }


        #region Input
        private void btHauptmenue_Click(object sender, EventArgs e)
        {
            hauptmenü.Show();
            this.Close();
        }
        private void btRegeln_Click(object sender, EventArgs e)
        {
            hauptmenü.erstelleREgeln();
            this.Close();
        }

        private void pbwuerfel_Click(object sender, EventArgs e)
        {
            wurfzahl++;
            if (wurfzahl < 3)
            {
                
                wuerfeln();

            }
            else
            {
                wurfzahl = 0;
                spieler++;
                if (spieler > spieleranzahl)
                {
                    spieler = 1;
                    erneuerBilder(new List<int>());
                }
            }

            lbPlayer.Text = "Player: " + spieler + "  Wurf:" + wurfzahl;
        }

        private void KniffelSpiel_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void pbzahl1_Click(object sender, EventArgs e)
        {
            if (würfelstatus[0])
            {
                würfelstatus[0] = false;
                pbstatus1.BackColor = Color.Red;
            }
            else
            {
                würfelstatus[0] = true;
                pbstatus1.BackColor = Color.Lime;
            }
        }
        private void pbzahl2_Click(object sender, EventArgs e)
        {
            if (würfelstatus[1])
            {
                würfelstatus[1] = false;
                pbstatus2.BackColor = Color.Red;
            }
            else
            {
                würfelstatus[1] = true;
                pbstatus2.BackColor = Color.Lime;
            }
        }
        private void pbzahl3_Click(object sender, EventArgs e)
        {
            if (würfelstatus[2])
            {
                würfelstatus[2] = false;
                pbstatus3.BackColor = Color.Red;
            }
            else
            {
                würfelstatus[2] = true;
                pbstatus3.BackColor = Color.Lime;
            }
        }
        private void pbzahl4_Click(object sender, EventArgs e)
        {
            if (würfelstatus[3])
            {
                würfelstatus[3] = false;
                pbstatus4.BackColor = Color.Red;
            }
            else
            {
                würfelstatus[3] = true;
                pbstatus4.BackColor = Color.Lime;
            }
        }
        private void pbzahl5_Click(object sender, EventArgs e)
        {
            if (würfelstatus[4])
            {
                würfelstatus[4] = false;
                pbstatus5.BackColor = Color.Red;
            }
            else
            {
                würfelstatus[4] = true;
                pbstatus5.BackColor = Color.Lime;
            }
        }

        #endregion


        public void wuerfeln()
        {
            //
            List<int> ergebnis = new List<int>();
            for (int i = 0; i < 5; i++)
            {
                if (würfelstatus[i] == false && letzterwurf.Count > 0)
                {
                    ergebnis.Add(letzterwurf.ElementAt(i));
                }
                else
                {
                    ergebnis.Add(zufall.Next(1, 7));
                }
            }

            letzterwurf = ergebnis;


            erneuerBilder(ergebnis);


            cbmöglichkeiten.Items.Clear();
            foreach (würfe w in pruefe(ergebnis))
            {
                cbmöglichkeiten.Items.Add(w.ToString());
            }
        }


        public List<würfe> pruefe(List<int> zahlen)
        {
            List<würfe> resultat = new List<würfe>();

            //einer
            if(zahlen.Where(i => i == 1).ToArray().Length > 0)
            {
                resultat.Add(würfe.einer);
            }
            //zwier
            if (zahlen.Where(i => i == 2).ToArray().Length > 0)
            {
                resultat.Add(würfe.zweier);
            }
            //dreier
            if (zahlen.Where(i => i == 3).ToArray().Length > 0)
            {
                resultat.Add(würfe.dreier);
            }
            //vierer
            if (zahlen.Where(i => i == 4).ToArray().Length > 0)
            {
                resultat.Add(würfe.vierer);
            }
            //fuenfer
            if (zahlen.Where(i => i == 5).ToArray().Length > 0)
            {
                resultat.Add(würfe.fuenfer);
            }
            //serchser
            if (zahlen.Where(i => i == 6).ToArray().Length > 0)
            {
                resultat.Add(würfe.sechser);
            }

            //Dreierpasch
            for (int i = 0; i < 6; i++)
            {
                if (zahlen.Where(z => z == i).ToArray().Length >= 3)
                {
                    resultat.Add(würfe.dreierpasch);
                    break;
                }

            }

            //Vierpasch
            for (int i = 0; i < 6; i++)
            {
                if (zahlen.Where(z => z == i).ToArray().Length >= 4)
                {
                    resultat.Add(würfe.viererpasch);
                    break;
                }
            }
            


            //kleine strasse
            if(
                zahlen.Where(i => i == 4).Contains(1) &&
                zahlen.Where(i => i == 4).Contains(2) &&
                zahlen.Where(i => i == 4).Contains(3) &&
                zahlen.Where(i => i == 4).Contains(4)
                ||
                zahlen.Where(i => i == 4).Contains(2) &&
                zahlen.Where(i => i == 4).Contains(3) &&
                zahlen.Where(i => i == 4).Contains(4) &&
                zahlen.Where(i => i == 4).Contains(5) 
                ||
                zahlen.Where(i => i == 4).Contains(3) &&
                zahlen.Where(i => i == 4).Contains(4) &&
                zahlen.Where(i => i == 4).Contains(5) &&
                zahlen.Where(i => i == 4).Contains(6)
                )
            {
                resultat.Add(würfe.kleiestrasse);
            }

            //grosse strasse
            if (
                zahlen.Where(i => i == 4).Contains(1) &&
                zahlen.Where(i => i == 4).Contains(2) &&
                zahlen.Where(i => i == 4).Contains(3) &&
                zahlen.Where(i => i == 4).Contains(4) &&
                zahlen.Where(i => i == 4).Contains(5)
                ||
                zahlen.Where(i => i == 4).Contains(2) &&
                zahlen.Where(i => i == 4).Contains(3) &&
                zahlen.Where(i => i == 4).Contains(4) &&
                zahlen.Where(i => i == 4).Contains(5) &&
                zahlen.Where(i => i == 4).Contains(6)
                )
            {
                resultat.Add(würfe.grossestrase);
            }


            return resultat;
        }
        
        public void erneuerBilder(List<int> zahlen)
        {
            if (zahlen.Count > 0)
            {
                lbzahl1.Text = 0.ToString();
                lbzahl2.Text = 0.ToString();
                lbzahl3.Text = 0.ToString();
                lbzahl4.Text = 0.ToString();
                lbzahl5.Text = 0.ToString();
                return;
            }

            lbzahl1.Text = zahlen.ElementAt(0).ToString();
            lbzahl2.Text = zahlen.ElementAt(1).ToString();
            lbzahl3.Text = zahlen.ElementAt(2).ToString();
            lbzahl4.Text = zahlen.ElementAt(3).ToString();
            lbzahl5.Text = zahlen.ElementAt(4).ToString();
        }




    }
}
