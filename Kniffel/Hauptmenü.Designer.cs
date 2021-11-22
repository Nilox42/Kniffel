
namespace Kniffel
{
    partial class Hauptmenü
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.btSpieler2 = new System.Windows.Forms.Button();
            this.btSpieler5 = new System.Windows.Forms.Button();
            this.btSpieler4 = new System.Windows.Forms.Button();
            this.btSpieler3 = new System.Windows.Forms.Button();
            this.btRegeln = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bernard MT Condensed", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(230, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(291, 114);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kniffel";
            // 
            // btSpieler2
            // 
            this.btSpieler2.Location = new System.Drawing.Point(42, 259);
            this.btSpieler2.Name = "btSpieler2";
            this.btSpieler2.Size = new System.Drawing.Size(180, 80);
            this.btSpieler2.TabIndex = 2;
            this.btSpieler2.Text = "2 Spieler";
            this.btSpieler2.UseVisualStyleBackColor = true;
            this.btSpieler2.Click += new System.EventHandler(this.btSpieler2_Click);
            // 
            // btSpieler5
            // 
            this.btSpieler5.Location = new System.Drawing.Point(501, 259);
            this.btSpieler5.Name = "btSpieler5";
            this.btSpieler5.Size = new System.Drawing.Size(180, 80);
            this.btSpieler5.TabIndex = 3;
            this.btSpieler5.Text = "5 Spieler";
            this.btSpieler5.UseVisualStyleBackColor = true;
            this.btSpieler5.Click += new System.EventHandler(this.btSpieler5_Click);
            // 
            // btSpieler4
            // 
            this.btSpieler4.Location = new System.Drawing.Point(387, 148);
            this.btSpieler4.Name = "btSpieler4";
            this.btSpieler4.Size = new System.Drawing.Size(180, 80);
            this.btSpieler4.TabIndex = 5;
            this.btSpieler4.Text = "4 Spieler";
            this.btSpieler4.UseVisualStyleBackColor = true;
            this.btSpieler4.Click += new System.EventHandler(this.btSpieler4_Click);
            // 
            // btSpieler3
            // 
            this.btSpieler3.Location = new System.Drawing.Point(171, 148);
            this.btSpieler3.Name = "btSpieler3";
            this.btSpieler3.Size = new System.Drawing.Size(180, 80);
            this.btSpieler3.TabIndex = 4;
            this.btSpieler3.Text = "3 Spieler";
            this.btSpieler3.UseVisualStyleBackColor = true;
            this.btSpieler3.Click += new System.EventHandler(this.btSpieler3_Click);
            // 
            // btRegeln
            // 
            this.btRegeln.Location = new System.Drawing.Point(276, 319);
            this.btRegeln.Name = "btRegeln";
            this.btRegeln.Size = new System.Drawing.Size(180, 60);
            this.btRegeln.TabIndex = 6;
            this.btRegeln.Text = "Regeln";
            this.btRegeln.UseVisualStyleBackColor = true;
            this.btRegeln.Click += new System.EventHandler(this.btRegeln_Click);
            // 
            // Hauptmenü
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 411);
            this.Controls.Add(this.btRegeln);
            this.Controls.Add(this.btSpieler4);
            this.Controls.Add(this.btSpieler3);
            this.Controls.Add(this.btSpieler5);
            this.Controls.Add(this.btSpieler2);
            this.Controls.Add(this.label1);
            this.MaximumSize = new System.Drawing.Size(750, 450);
            this.MinimumSize = new System.Drawing.Size(750, 450);
            this.Name = "Hauptmenü";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hauptmenü";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btSpieler2;
        private System.Windows.Forms.Button btSpieler5;
        private System.Windows.Forms.Button btSpieler4;
        private System.Windows.Forms.Button btSpieler3;
        private System.Windows.Forms.Button btRegeln;
    }
}

