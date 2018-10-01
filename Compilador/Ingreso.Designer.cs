namespace Compilador
{
    partial class Ingreso
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tBArchivo = new System.Windows.Forms.TextBox();
            this.cBTipoIngreso = new System.Windows.Forms.ComboBox();
            this.rTConsola = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.rTResultado = new System.Windows.Forms.RichTextBox();
            this.btnCompilar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tipo de Ingreso";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 463);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Archivo";
            // 
            // tBArchivo
            // 
            this.tBArchivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tBArchivo.Location = new System.Drawing.Point(174, 467);
            this.tBArchivo.Name = "tBArchivo";
            this.tBArchivo.Size = new System.Drawing.Size(358, 28);
            this.tBArchivo.TabIndex = 2;
            // 
            // cBTipoIngreso
            // 
            this.cBTipoIngreso.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cBTipoIngreso.FormattingEnabled = true;
            this.cBTipoIngreso.Items.AddRange(new object[] {
            "Consola",
            "Archivo"});
            this.cBTipoIngreso.Location = new System.Drawing.Point(176, 72);
            this.cBTipoIngreso.Name = "cBTipoIngreso";
            this.cBTipoIngreso.Size = new System.Drawing.Size(201, 33);
            this.cBTipoIngreso.TabIndex = 4;
            this.cBTipoIngreso.SelectedIndexChanged += new System.EventHandler(this.cBTipoIngreso_SelectedIndexChanged);
            // 
            // rTConsola
            // 
            this.rTConsola.Location = new System.Drawing.Point(56, 206);
            this.rTConsola.Name = "rTConsola";
            this.rTConsola.Size = new System.Drawing.Size(321, 228);
            this.rTConsola.TabIndex = 5;
            this.rTConsola.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(599, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 29);
            this.label3.TabIndex = 7;
            this.label3.Text = "Resultado";
            // 
            // rTResultado
            // 
            this.rTResultado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rTResultado.Location = new System.Drawing.Point(594, 126);
            this.rTResultado.Name = "rTResultado";
            this.rTResultado.Size = new System.Drawing.Size(513, 308);
            this.rTResultado.TabIndex = 8;
            this.rTResultado.Text = "";
            this.rTResultado.TextChanged += new System.EventHandler(this.rTResultado_TextChanged);
            // 
            // btnCompilar
            // 
            this.btnCompilar.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnCompilar.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCompilar.Location = new System.Drawing.Point(468, 516);
            this.btnCompilar.Name = "btnCompilar";
            this.btnCompilar.Size = new System.Drawing.Size(162, 61);
            this.btnCompilar.TabIndex = 10;
            this.btnCompilar.Text = "Compilar";
            this.btnCompilar.UseVisualStyleBackColor = false;
            this.btnCompilar.Click += new System.EventHandler(this.btnCompilar_Click);
            // 
            // Ingreso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1175, 650);
            this.Controls.Add(this.btnCompilar);
            this.Controls.Add(this.rTResultado);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.rTConsola);
            this.Controls.Add(this.cBTipoIngreso);
            this.Controls.Add(this.tBArchivo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "Ingreso";
            this.Text = "Ingreso";
            this.Load += new System.EventHandler(this.Ingreso_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tBArchivo;
        private System.Windows.Forms.ComboBox cBTipoIngreso;
        private System.Windows.Forms.RichTextBox rTConsola;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox rTResultado;
        private System.Windows.Forms.Button btnCompilar;
    }
}