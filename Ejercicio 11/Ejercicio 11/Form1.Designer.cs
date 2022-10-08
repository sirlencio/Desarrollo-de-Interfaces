namespace Ejercicio_11
{
    partial class Ejercicio11
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.si = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.no = new System.Windows.Forms.Label();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.nsnc = new System.Windows.Forms.Label();
            this.total = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.progressBar3 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // si
            // 
            this.si.AutoSize = true;
            this.si.Location = new System.Drawing.Point(190, 34);
            this.si.Name = "si";
            this.si.Size = new System.Drawing.Size(38, 15);
            this.si.TabIndex = 0;
            this.si.Text = "label1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(116, 280);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 52);
            this.button1.TabIndex = 1;
            this.button1.Text = "Votar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(81, 32);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(34, 19);
            this.radioButton1.TabIndex = 2;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Si";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(81, 101);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(41, 19);
            this.radioButton2.TabIndex = 4;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "No";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // no
            // 
            this.no.AutoSize = true;
            this.no.Location = new System.Drawing.Point(190, 103);
            this.no.Name = "no";
            this.no.Size = new System.Drawing.Size(38, 15);
            this.no.TabIndex = 3;
            this.no.Text = "label2";
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(81, 163);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(62, 19);
            this.radioButton3.TabIndex = 6;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "NS/NC";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // nsnc
            // 
            this.nsnc.AutoSize = true;
            this.nsnc.Location = new System.Drawing.Point(190, 165);
            this.nsnc.Name = "nsnc";
            this.nsnc.Size = new System.Drawing.Size(38, 15);
            this.nsnc.TabIndex = 5;
            this.nsnc.Text = "label3";
            // 
            // total
            // 
            this.total.AutoSize = true;
            this.total.Location = new System.Drawing.Point(116, 229);
            this.total.Name = "total";
            this.total.Size = new System.Drawing.Size(38, 15);
            this.total.TabIndex = 7;
            this.total.Text = "label4";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(445, 32);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(253, 23);
            this.progressBar1.TabIndex = 8;
            // 
            // progressBar2
            // 
            this.progressBar2.Location = new System.Drawing.Point(445, 95);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(253, 23);
            this.progressBar2.TabIndex = 9;
            // 
            // progressBar3
            // 
            this.progressBar3.Location = new System.Drawing.Point(445, 157);
            this.progressBar3.Name = "progressBar3";
            this.progressBar3.Size = new System.Drawing.Size(253, 23);
            this.progressBar3.TabIndex = 10;
            // 
            // Ejercicio11
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 365);
            this.Controls.Add(this.progressBar3);
            this.Controls.Add(this.progressBar2);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.total);
            this.Controls.Add(this.radioButton3);
            this.Controls.Add(this.nsnc);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.no);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.si);
            this.Name = "Ejercicio11";
            this.Text = "Ejercicio 11";
            this.Load += new System.EventHandler(this.Ejercicio11_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label si;
        private Button button1;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private Label no;
        private RadioButton radioButton3;
        private Label nsnc;
        private Label total;
        private ProgressBar progressBar1;
        private ProgressBar progressBar2;
        private ProgressBar progressBar3;
    }
}