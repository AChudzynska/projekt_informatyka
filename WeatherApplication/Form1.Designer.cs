namespace WeatherApplication
{
    partial class ApplicationForm
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
            this.components = new System.ComponentModel.Container();
            this.pogodaTC = new System.Windows.Forms.TabControl();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.miastoCB = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // pogodaTC
            // 
            this.pogodaTC.Location = new System.Drawing.Point(12, 121);
            this.pogodaTC.Name = "pogodaTC";
            this.pogodaTC.SelectedIndex = 0;
            this.pogodaTC.Size = new System.Drawing.Size(327, 212);
            this.pogodaTC.TabIndex = 3;
            this.pogodaTC.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(221, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Pogoda dla miasta: ";
            // 
            // miastoCB
            // 
            this.miastoCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.miastoCB.FormattingEnabled = true;
            this.miastoCB.Location = new System.Drawing.Point(16, 43);
            this.miastoCB.Name = "miastoCB";
            this.miastoCB.Size = new System.Drawing.Size(200, 32);
            this.miastoCB.TabIndex = 5;
            this.miastoCB.Text = "Wybierz miasto...";
            this.miastoCB.SelectedIndexChanged += new System.EventHandler(this.miastoCB_SelectedIndexChanged);
            // 
            // ApplicationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 348);
            this.Controls.Add(this.miastoCB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pogodaTC);
            this.Name = "ApplicationForm";
            this.Text = "Pogodynka";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl pogodaTC;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ComboBox miastoCB;
    }
}

