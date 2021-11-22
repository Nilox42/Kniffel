
namespace Kniffel
{
    partial class Kniffel_5_Spieler
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btHauptmenue = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btHauptmenue
            // 
            this.btHauptmenue.Location = new System.Drawing.Point(713, 12);
            this.btHauptmenue.Name = "btHauptmenue";
            this.btHauptmenue.Size = new System.Drawing.Size(75, 23);
            this.btHauptmenue.TabIndex = 2;
            this.btHauptmenue.Text = "Hauptmenü";
            this.btHauptmenue.UseVisualStyleBackColor = true;
            this.btHauptmenue.Click += new System.EventHandler(this.btHauptmenue_Click);
            // 
            // Kniffel_5_Spieler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.btHauptmenue);
            this.Name = "Kniffel_5_Spieler";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kniffel_5_Spieler";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btHauptmenue;
    }
}