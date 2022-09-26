namespace Ejercicio2
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.textPalabra = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textLetra = new System.Windows.Forms.TextBox();
            this.solucion = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(112, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(223, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Introduzca palabra o frase:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // textPalabra
            // 
            this.textPalabra.Location = new System.Drawing.Point(341, 62);
            this.textPalabra.Name = "textPalabra";
            this.textPalabra.Size = new System.Drawing.Size(100, 23);
            this.textPalabra.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(352, 234);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Buscar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(125, 144);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(210, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Introduzca letra a buscar:";
            // 
            // textLetra
            // 
            this.textLetra.Location = new System.Drawing.Point(341, 147);
            this.textLetra.Name = "textLetra";
            this.textLetra.Size = new System.Drawing.Size(100, 23);
            this.textLetra.TabIndex = 4;
            // 
            // solucion
            // 
            this.solucion.AutoSize = true;
            this.solucion.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.solucion.Location = new System.Drawing.Point(452, 306);
            this.solucion.Name = "solucion";
            this.solucion.Size = new System.Drawing.Size(81, 25);
            this.solucion.TabIndex = 5;
            this.solucion.Text = "Se repite";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.solucion);
            this.Controls.Add(this.textLetra);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textPalabra);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Ejercico 2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private TextBox textPalabra;
        private Button button1;
        private Label label2;
        private TextBox textLetra;
        private Label solucion;
    }
}