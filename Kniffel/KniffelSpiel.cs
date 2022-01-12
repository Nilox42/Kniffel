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
        private Random zufall;

        private int spieleranzahl;
        private int maximalerundenzahl = 13;

        private int runde = 1;
        private int spieler = 1;
        private int wurfzahl = 0;

        private List<int> letzterwurf = new List<int>();
        private bool[] würfelstatus = { true, true, true, true, true };
        private int[] spielergesamtsummen = { 0, 0, 0, 0, 0 };

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


        private void btregeln_Click(object sender, EventArgs e)
        {
            hauptmenü.erstelleREgeln();
        }

        private void tbSp1Einer_TextChanged(object sender, EventArgs e)
        {
            berechneSummen();
        }
        #endregion

        #region Wuerfeln
        //Incrementiere wurfzahl und teste ob 3 würfe gemacht wurden
        //Wenn weniger als 3 würfe gemacht wurden würfel
        //Wenn schon 3 würfe gemacht wurden dann setze alles zurück und wähle den nächsten spieler aus
        private void bereiteWurfvor()
        {
            wurfzahl++;                         //erhöhe wurfelzahl
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


                wurfzahl = 0;                   //Wurfzahl Zurücksetzten
                spieler++;                      //Erhöhe Spielerzahl
                if (spieler > spieleranzahl)    //Wenn spielerzahl höher als maximale spieleranzahl ist springe zum ersten spieler zurück
                {
                    spieler = 1;

                    runde++;                        //Erhöhe Rundenzahl und wenn die 13. Runde vorüber ist beende das Spiel
                    if (runde > maximalerundenzahl)
                    {
                        waehleGewinner();
                        return;
                    }
                }

                erneuereText(new List<int>());  //erneure Text mit leerer Liste                        
                erneuereBilder();               //Erneuere Bilder

                btwürfeln.Text = "Würfeln";
            }

            lbrunde.Text = "Runde: " + runde.ToString();
            lbPlayer.Text = "Player: " + spieler.ToString();
            lbwuerfe.Text = "Wurf: " + wurfzahl.ToString();
        }

        private void wuerfeln()
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
        }
        #endregion

        #region oberfläche
        private void erneuereText(List<int> zahlen)
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
        private void erneuereBilder()
        {
            if (würfelstatus[0])
            {
                pbstatus1.BackColor = Color.Lime;
            }
            else
            {
                pbstatus1.BackColor = Color.Red;
            }

            if (würfelstatus[1])
            {
                pbstatus2.BackColor = Color.Lime;
            }
            else
            {
                pbstatus2.BackColor = Color.Red;
            }

            if (würfelstatus[1])
            {
                pbstatus2.BackColor = Color.Lime;
            }
            else
            {
                pbstatus2.BackColor = Color.Red;
            }

            if (würfelstatus[2])
            {
                pbstatus3.BackColor = Color.Lime;
            }
            else
            {
                pbstatus3.BackColor = Color.Red;
            }

            if (würfelstatus[3])
            {
                pbstatus4.BackColor = Color.Lime;
            }
            else
            {
                pbstatus4.BackColor = Color.Red;
            }

            if (würfelstatus[4])
            {
                pbstatus5.BackColor = Color.Lime;
            }
            else
            {
                pbstatus5.BackColor = Color.Red;
            }
        }

        private void wechselStatus(int i)
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
        #endregion

        #region berechnung
        private void berechneSummen()
        {
            int p1oben = 0;
            int p2oben = 0;
            int p3oben = 0;
            int p4oben = 0;
            int p5oben = 0;

            //Oben
            {
                //Player 1
                try
                {
                    p1oben = int.Parse(tbSp1Einer.Text);
                    p1oben += int.Parse(tbSp1Zweier.Text);
                    p1oben += int.Parse(tbSp1Dreier.Text);
                    p1oben += int.Parse(tbSp1Vierer.Text);
                    p1oben += int.Parse(tbSp1Fünfer.Text);
                    p1oben += int.Parse(tbSp1Sechser.Text);

                    lbSp1SummeOben.Text = p1oben.ToString();
                }
                catch
                {
                    lbSp1SummeOben.Text = "error";
                    p1oben = 0;
                }
                //Player 2
                try
                {
                    p2oben = int.Parse(tbSp2Einer.Text);
                    p2oben += int.Parse(tbSp2Zweier.Text);
                    p2oben += int.Parse(tbSp2Dreier.Text);
                    p2oben += int.Parse(tbSp2Vierer.Text);
                    p2oben += int.Parse(tbSp2Fünfer.Text);
                    p2oben += int.Parse(tbSp2Sechser.Text);

                    lbSp2SummeOben.Text = p2oben.ToString();
                }
                catch
                {
                    lbSp2SummeOben.Text = "error";
                    p2oben = 0;
                }
                //Player 3
                try
                {
                    p3oben = int.Parse(tbSp3Einer.Text);
                    p3oben += int.Parse(tbSp3Zweier.Text);
                    p3oben += int.Parse(tbSp3Dreier.Text);
                    p3oben += int.Parse(tbSp3Vierer.Text);
                    p3oben += int.Parse(tbSp3Fünfer.Text);
                    p3oben += int.Parse(tbSp3Sechser.Text);

                    lbSp3SummeOben.Text = p3oben.ToString();
                }
                catch
                {
                    lbSp3SummeOben.Text = "error";
                    p3oben = 0;
                }
                //Player 4
                try
                {
                    p4oben = int.Parse(tbSp4Einer.Text);
                    p4oben += int.Parse(tbSp4Zweier.Text);
                    p4oben += int.Parse(tbSp4Dreier.Text);
                    p4oben += int.Parse(tbSp4Vierer.Text);
                    p4oben += int.Parse(tbSp4Fünfer.Text);
                    p4oben += int.Parse(tbSp4Sechser.Text);

                    lbSp4SummeOben.Text = p4oben.ToString();
                }
                catch
                {
                    lbSp4SummeOben.Text = "error";
                    p4oben = 0;
                }
                //Player 5
                try
                {
                    p5oben = int.Parse(tbSp5Einer.Text);
                    p5oben += int.Parse(tbSp5Zweier.Text);
                    p5oben += int.Parse(tbSp5Dreier.Text);
                    p5oben += int.Parse(tbSp5Vierer.Text);
                    p5oben += int.Parse(tbSp5Fünfer.Text);
                    p5oben += int.Parse(tbSp5Sechser.Text);

                    lbSp5SummeOben.Text = p5oben.ToString();
                }
                catch
                {
                    lbSp5SummeOben.Text = "error";
                    p5oben = 0;
                }
            }

            int p1utnen = 0;
            int p2utnen = 0;
            int p3utnen = 0;
            int p4utnen = 0;
            int p5utnen = 0;
            //Unten
            {
                //Player 1
                try
                {
                    p1utnen += int.Parse(tbSp1Dreierpasch.Text);
                    p1utnen += int.Parse(tbSp1Viererpasch.Text);
                    p1utnen += int.Parse(tbSp1FullHouse.Text);
                    p1utnen += int.Parse(tbSp1KleineStraße.Text);
                    p1utnen += int.Parse(tbSp1GroßeStraße.Text);
                    p1utnen += int.Parse(tbSp1Kniffel.Text);

                    p1utnen += int.Parse(tbSp1Chance.Text);
                }
                catch
                {
                    p1utnen = 0;
                }
                //Player 2
                try
                {
                    p2utnen += int.Parse(tbSp2Dreierpasch.Text);
                    p2utnen += int.Parse(tbSp2Viererpasch.Text);
                    p2utnen += int.Parse(tbSp2FullHouse.Text);
                    p2utnen += int.Parse(tbSp2KleineStraße.Text);
                    p2utnen += int.Parse(tbSp2GroßeStraße.Text);
                    p2utnen += int.Parse(tbSp2Kniffel.Text);

                    p2utnen += int.Parse(tbSp2Chance.Text);
                }
                catch
                {
                    p2utnen = 0;
                }
                //Player 3
                try
                {
                    p3utnen += int.Parse(tbSp3Dreierpasch.Text);
                    p3utnen += int.Parse(tbSp3Viererpasch.Text);
                    p3utnen += int.Parse(tbSp3FullHouse.Text);
                    p3utnen += int.Parse(tbSp3KleineStraße.Text);
                    p3utnen += int.Parse(tbSp3GroßeStraße.Text);
                    p3utnen += int.Parse(tbSp3Kniffel.Text);

                    p3utnen += int.Parse(tbSp3Chance.Text);
                }
                catch
                {
                    p3utnen = 0;
                }
                //Player 4
                try
                {
                    p4utnen += int.Parse(tbSp4Dreierpasch.Text);
                    p4utnen += int.Parse(tbSp4Viererpasch.Text);
                    p4utnen += int.Parse(tbSp4FullHouse.Text);
                    p4utnen += int.Parse(tbSp4KleineStraße.Text);
                    p4utnen += int.Parse(tbSp4GroßeStraße.Text);
                    p4utnen += int.Parse(tbSp4Kniffel.Text);

                    p4utnen += int.Parse(tbSp4Chance.Text);
                }
                catch
                {
                    p4utnen = 0;
                }
                //Player 5
                try
                {
                    p5utnen += int.Parse(tbSp5Dreierpasch.Text);
                    p5utnen += int.Parse(tbSp5Viererpasch.Text);
                    p5utnen += int.Parse(tbSp5FullHouse.Text);
                    p5utnen += int.Parse(tbSp5KleineStraße.Text);
                    p5utnen += int.Parse(tbSp5GroßeStraße.Text);
                    p5utnen += int.Parse(tbSp5Kniffel.Text);

                    p5utnen += int.Parse(tbSp5Chance.Text);
                }
                catch
                {
                    p5utnen = 0;
                }
            }

            int bonusplus = 35;

            int p1bonus = 0;
            int p2bonus = 0;
            int p3bonus = 0;
            int p4bonus = 0;
            int p5bonus = 0;
            //Bonus
            {
                //Player 1
                if (p1oben >= 63)
                {
                    p1bonus = bonusplus;
                    tbSp1Bonus.Text = p1bonus.ToString();
                }
                else
                {
                    p1bonus = 0;
                    tbSp1Bonus.Text = p1bonus.ToString();
                }
                //Player 2
                if (p2oben >= 63)
                {
                    p2bonus = bonusplus;
                    tbSp2Bonus.Text = p2bonus.ToString();
                }
                else
                {
                    p2bonus = 0;
                    tbSp2Bonus.Text = p2bonus.ToString();
                }
                //Player 3
                if (p3oben >= 63)
                {
                    p3bonus = bonusplus;
                    tbSp3Bonus.Text = p3bonus.ToString();
                }
                else
                {
                    p3bonus = 0;
                    tbSp3Bonus.Text = p3bonus.ToString();
                }
                //Player 4
                if (p4oben >= 63)
                {
                    p4bonus = bonusplus;
                    tbSp4Bonus.Text = p4bonus.ToString();
                }
                else
                {
                    p4bonus = 0;
                    tbSp4Bonus.Text = p4bonus.ToString();
                }
                //Player 5
                if (p5oben >= 63)
                {
                    p5bonus = bonusplus;
                    tbSp5Bonus.Text = p5bonus.ToString();
                }
                else
                {
                    p5bonus = 0;
                    tbSp5Bonus.Text = p5bonus.ToString();
                }
            }

            //berechne des gesamtwert
            int p1gesamt = p1oben + p1utnen + p1bonus;
            int p2gesamt = p2oben + p2utnen + p2bonus;
            int p3gesamt = p3oben + p3utnen + p3bonus;
            int p4gesamt = p4oben + p4utnen + p4bonus;
            int p5gesamt = p5oben + p5utnen + p5bonus;

            //Speicher den gesamtwert in array 
            spielergesamtsummen[0] = p1gesamt;
            spielergesamtsummen[1] = p2gesamt;
            spielergesamtsummen[2] = p3gesamt;
            spielergesamtsummen[3] = p4gesamt;
            spielergesamtsummen[4] = p5gesamt;

            lbSp1Gesammtsumme.Text = p1gesamt.ToString();
            lbSp2Gesammtsumme.Text = p2gesamt.ToString();
            lbSp3Gesammtsumme.Text = p3gesamt.ToString();
            lbSp4Gesammtsumme.Text = p4gesamt.ToString();
            lbSp5Gesammtsumme.Text = p5gesamt.ToString();
        }
        #endregion

        #region Ende
        private void waehleGewinner()
        {
            //Überprüfe pb Spiler 1 gewonnen hat
            if (
                spielergesamtsummen[0] > spielergesamtsummen[1] &&
                spielergesamtsummen[0] > spielergesamtsummen[2] &&
                spielergesamtsummen[0] > spielergesamtsummen[3] &&
                spielergesamtsummen[0] > spielergesamtsummen[4]
                )
            {
                beendeSpiel(1);
            }

            //Überprüfe pb Spiler 2 gewonnen hat
            else if (
                spielergesamtsummen[1] > spielergesamtsummen[0] &&
                spielergesamtsummen[1] > spielergesamtsummen[2] &&
                spielergesamtsummen[1] > spielergesamtsummen[3] &&
                spielergesamtsummen[1] > spielergesamtsummen[4]
                )
            {
                beendeSpiel(2);
            }

            //Überprüfe pb Spiler 3 gewonnen hat
            else if (
                spielergesamtsummen[2] > spielergesamtsummen[0] &&
                spielergesamtsummen[2] > spielergesamtsummen[1] &&
                spielergesamtsummen[2] > spielergesamtsummen[3] &&
                spielergesamtsummen[2] > spielergesamtsummen[4]
                )
            {
                beendeSpiel(3);
            }

            //Überprüfe pb Spiler 4 gewonnen hat
            else if (
                spielergesamtsummen[3] > spielergesamtsummen[0] &&
                spielergesamtsummen[3] > spielergesamtsummen[1] &&
                spielergesamtsummen[3] > spielergesamtsummen[2] &&
                spielergesamtsummen[3] > spielergesamtsummen[4]
                )
            {
                beendeSpiel(4);
            }

            //Überprüfe pb Spiler 5 gewonnen hat
            else if (
                spielergesamtsummen[4] > spielergesamtsummen[0] &&
                spielergesamtsummen[4] > spielergesamtsummen[1] &&
                spielergesamtsummen[4] > spielergesamtsummen[2] &&
                spielergesamtsummen[4] > spielergesamtsummen[3]
                )
            {
                beendeSpiel(5);
            }
            else
            {
                beendeSpiel(-1);
            }
        }

        private void beendeSpiel(int spielerzahl)
        {
            if (spielerzahl == -1)
            {
                DialogResult result = MessageBox.Show("Unentschieden, einer muss sich mehr anstrengen!", "Unetschieden",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Exclamation);
            }
            else
            {
                DialogResult result = MessageBox.Show("Spieler " + spielerzahl + " ist der Gewinner der Runde!", "Spielende",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
            }

            hauptmenü.zerstöreSpiel();
        }
        #endregion

        
    }
} 