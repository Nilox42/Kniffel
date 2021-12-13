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
            btwürfeln_Click(sender, e);
        }
        private void btwürfeln_Click(object sender, EventArgs e)
        {
            bereiteWurfvor();
        }

        private void KniffelSpiel_FormClosing(object sender, FormClosingEventArgs e)
        {
            hauptmenü.zerstöreSpiel();
        }

        private void pbzahl1_Click(object sender, EventArgs e)
        {
            wechselStatus(0);    
        }
        private void pbzahl2_Click(object sender, EventArgs e)
        {
            wechselStatus(1);
        }
        private void pbzahl3_Click(object sender, EventArgs e)
        {
            wechselStatus(2);
        }
        private void pbzahl4_Click(object sender, EventArgs e)
        {
            wechselStatus(3);
        }
        private void pbzahl5_Click(object sender, EventArgs e)
        {
            wechselStatus(4);
        }
        #endregion
        //Incrementiere wurfzahl und teste ob 3 würfe gemacht wurden
        //Wenn weniger als 3 würfe gemacht wurden würfel
        //Wenn schon 3 würfe gemacht wurden dann setze alles zurück und wähle den nächsten spieler aus
        public void bereiteWurfvor()
        {
            wurfzahl++;
            if (wurfzahl < 4)
            {
                wuerfeln();

                if (wurfzahl == 3) //Beim letzten wurf
                {
                    btwürfeln.Text = "Weiter";
                }
            }
            else
            {
                //Setze alle würfel zurück
                for (int i = 0; i < 5; i++)
                {
                    würfelstatus[i] = true;
                }
                letzterwurf.Clear();

                wurfzahl = 0;
                spieler++;
                if (spieler > spieleranzahl)
                {
                    spieler = 1;
                }

                cbmöglichkeiten.Items.Clear();
                erneuereText(new List<int>());
                erneuereBilder();

                btwürfeln.Text = "Würfeln";
            }

            lbPlayer.Text = "Player: " + spieler;
            lbwuerfe.Text = "Wurf: " + wurfzahl;
        }

        public void wuerfeln()
        {
            //überprüfe ob würfel gesperrt ist und wenn nicht würfle Zahle erneut und lade "letzderwurf" mit neuem wurf
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

            //Lade neue Bilder
            erneuereText(ergebnis);

            //Bereinige Liste und lade sie mit neuen Daten
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
                zahlen.Contains(1) &&
                zahlen.Contains(2) &&
                zahlen.Contains(3) &&
                zahlen.Contains(4)
                ||
                zahlen.Contains(2) &&
                zahlen.Contains(3) &&
                zahlen.Contains(4) &&
                zahlen.Contains(5) 
                ||
                zahlen.Contains(3) &&
                zahlen.Contains(4) &&
                zahlen.Contains(5) &&
                zahlen.Contains(6)
                )
            {
                resultat.Add(würfe.kleinestrasse);
            }

            //grosse strasse
            if (
                zahlen.Contains(1) &&
                zahlen.Contains(2) &&
                zahlen.Contains(3) &&
                zahlen.Contains(4) &&
                zahlen.Contains(5)
                ||
                zahlen.Contains(2) &&
                zahlen.Contains(3) &&
                zahlen.Contains(4) &&
                zahlen.Contains(5) &&
                zahlen.Contains(6)
                )
            {
                resultat.Add(würfe.grossestrasse);
            }

            //überprüfe ob Liste leer ist
            if (resultat.Count <= 0)
            {
                resultat.Add(würfe.fehler);
            }


            return resultat;
        }
        
        public void erneuereText(List<int> zahlen)
        {
            if (zahlen.Count <= 0)
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

            erneuereBilder();
        }

        //Geht über alle würfel und setzt die faben jenachdem ob der würfel würfelbar ist oder nicht
        public void erneuereBilder()
        {
            for (int i = 0; i < 5; i++)
            {
                switch (i)
                {
                    case 0:
                        {
                            if (würfelstatus[0])
                            {
                                pbstatus1.BackColor = Color.Lime;
                            }
                            else
                            {
                                pbstatus1.BackColor = Color.Red;
                            }

                            break;
                        }
                    case 1:
                        {
                            if (würfelstatus[1])
                            {
                                pbstatus2.BackColor = Color.Lime;
                            }
                            else
                            {
                                pbstatus2.BackColor = Color.Red;
                            }

                            break;
                        }
                    case 2:
                        {
                            if (würfelstatus[2])
                            {
                                pbstatus3.BackColor = Color.Lime;
                            }
                            else
                            {
                                pbstatus3.BackColor = Color.Red;
                            }

                            break;
                        }
                    case 3:
                        {
                            if (würfelstatus[3])
                            {
                                pbstatus4.BackColor = Color.Lime;
                            }
                            else
                            {
                                pbstatus4.BackColor = Color.Red;
                            }

                            break;
                        }
                    case 4:
                        {
                            if (würfelstatus[4])
                            {
                                pbstatus5.BackColor = Color.Lime;
                            }
                            else
                            {
                                pbstatus5.BackColor = Color.Red;
                            }

                            break;
                        }
                }
                
            }
        }

        public void wechselStatus(int i)
        {
            if (würfelstatus[i])
            {
                würfelstatus[i] = false;
            }
            else
            {
                würfelstatus[i] = true;
            }

            erneuereBilder();
        }

    }
}
