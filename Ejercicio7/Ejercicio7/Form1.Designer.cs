namespace Ejercicio7
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.suma = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.multiplica = new System.Windows.Forms.RadioButton();
            this.resta = new System.Windows.Forms.RadioButton();
            this.divide = new System.Windows.Forms.RadioButton();
            this.todas = new System.Windows.Forms.RadioButton();
            this.rdo = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(438, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Calculadora";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(342, 100);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(59, 23);
            this.textBox1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.todas);
            this.groupBox1.Controls.Add(this.divide);
            this.groupBox1.Controls.Add(this.resta);
            this.groupBox1.Controls.Add(this.multiplica);
            this.groupBox1.Controls.Add(this.suma);
            this.groupBox1.Location = new System.Drawing.Point(58, 69);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(143, 214);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Acciones";
            // 
            // suma
            // 
            this.suma.AutoSize = true;
            this.suma.Location = new System.Drawing.Point(3, 19);
            this.suma.Name = "suma";
            this.suma.Size = new System.Drawing.Size(59, 19);
            this.suma.TabIndex = 0;
            this.suma.TabStop = true;
            this.suma.Text = "Sumar";
            this.suma.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(636, 291);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 48);
            this.button1.TabIndex = 1;
            this.button1.Text = "Aceptar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(421, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "Ingrese 3 numeros";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(457, 100);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(59, 23);
            this.textBox2.TabIndex = 4;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(576, 100);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(59, 23);
            this.textBox3.TabIndex = 5;
            // 
            // multiplica
            // 
            this.multiplica.AutoSize = true;
            this.multiplica.Location = new System.Drawing.Point(3, 100);
            this.multiplica.Name = "multiplica";
            this.multiplica.Size = new System.Drawing.Size(82, 19);
            this.multiplica.TabIndex = 1;
            this.multiplica.TabStop = true;
            this.multiplica.Text = "Multiplicar";
            this.multiplica.UseVisualStyleBackColor = true;
            // 
            // resta
            // 
            this.resta.AutoSize = true;
            this.resta.Location = new System.Drawing.Point(3, 59);
            this.resta.Name = "resta";
            this.resta.Size = new System.Drawing.Size(57, 19);
            this.resta.TabIndex = 2;
            this.resta.TabStop = true;
            this.resta.Text = "Restar";
            this.resta.UseVisualStyleBackColor = true;
            // 
            // divide
            // 
            this.divide.AutoSize = true;
            this.divide.Location = new System.Drawing.Point(3, 140);
            this.divide.Name = "divide";
            this.divide.Size = new System.Drawing.Size(59, 19);
            this.divide.TabIndex = 3;
            this.divide.TabStop = true;
            this.divide.Text = "Dividir";
            this.divide.UseVisualStyleBackColor = true;
            // 
            // todas
            // 
            this.todas.AutoSize = true;
            this.todas.Location = new System.Drawing.Point(3, 189);
            this.todas.Name = "todas";
            this.todas.Size = new System.Drawing.Size(56, 19);
            this.todas.TabIndex = 4;
            this.todas.TabStop = true;
            this.todas.Text = "Todas";
            this.todas.UseVisualStyleBackColor = true;
            // 
            // rdo
            // 
            this.rdo.AutoSize = true;
            this.rdo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rdo.Location = new System.Drawing.Point(324, 141);
            this.rdo.Name = "rdo";
            this.rdo.Size = new System.Drawing.Size(142, 21);
            this.rdo.TabIndex = 6;
            this.rdo.Text = "Los resultados son:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rdo);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Ejercicio 7 ";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private GroupBox groupBox1;
        private RadioButton suma;
        private Button button1;
        private Label label2;
        private TextBox textBox2;
        private TextBox textBox3;
        private RadioButton todas;
        private RadioButton divide;
        private RadioButton resta;
        private RadioButton multiplica;
        private Label rdo;
    }
}