namespace WinFormsApp1
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
            components = new System.ComponentModel.Container();
            SKU = new Label();
            richTextBox1 = new RichTextBox();
            Consultar = new Button();
            Cancelar = new Button();
            bindingSource1 = new BindingSource(components);
            Dimensoes_Produto = new Label();
            richTextBox2 = new RichTextBox();
            label1 = new Label();
            btExExcel = new Button();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            SuspendLayout();
            // 
            // SKU
            // 
            SKU.AutoSize = true;
            SKU.Location = new Point(12, 37);
            SKU.Name = "SKU";
            SKU.Size = new Size(39, 20);
            SKU.TabIndex = 1;
            SKU.Text = "SKU:";
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(12, 60);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(776, 121);
            richTextBox1.TabIndex = 2;
            richTextBox1.Text = "";
            richTextBox1.TextChanged += richTextBox1_TextChanged;
            // 
            // Consultar
            // 
            Consultar.Location = new Point(12, 204);
            Consultar.Name = "Consultar";
            Consultar.Size = new Size(94, 29);
            Consultar.TabIndex = 3;
            Consultar.Text = "Consultar";
            Consultar.UseVisualStyleBackColor = true;
            Consultar.Click += Consultar_Click;
            // 
            // Cancelar
            // 
            Cancelar.Location = new Point(133, 204);
            Cancelar.Name = "Cancelar";
            Cancelar.Size = new Size(94, 29);
            Cancelar.TabIndex = 4;
            Cancelar.Text = "Cancelar";
            Cancelar.UseVisualStyleBackColor = true;
            Cancelar.Click += Cancelar_Click;
            // 
            // Dimensoes_Produto
            // 
            Dimensoes_Produto.AutoSize = true;
            Dimensoes_Produto.Location = new Point(12, 7);
            Dimensoes_Produto.Name = "Dimensoes_Produto";
            Dimensoes_Produto.Size = new Size(142, 20);
            Dimensoes_Produto.TabIndex = 5;
            Dimensoes_Produto.Text = "Dimensoes_produto";
            // 
            // richTextBox2
            // 
            richTextBox2.Location = new Point(12, 268);
            richTextBox2.Name = "richTextBox2";
            richTextBox2.Size = new Size(1650, 600);
            richTextBox2.TabIndex = 6;
            richTextBox2.Text = "";
            richTextBox2.TextChanged += richTextBox2_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 245);
            label1.Name = "label1";
            label1.Size = new Size(78, 20);
            label1.TabIndex = 7;
            label1.Text = "Resultado:";
            // 
            // btExExcel
            // 
            btExExcel.Location = new Point(268, 204);
            btExExcel.Name = "btExExcel";
            btExExcel.Size = new Size(150, 29);
            btExExcel.TabIndex = 8;
            btExExcel.Text = "Exp. Excel";
            btExExcel.UseVisualStyleBackColor = true;
            btExExcel.Click += btExExcel_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1682, 771);
            Controls.Add(btExExcel);
            Controls.Add(label1);
            Controls.Add(richTextBox2);
            Controls.Add(Dimensoes_Produto);
            Controls.Add(Cancelar);
            Controls.Add(Consultar);
            Controls.Add(richTextBox1);
            Controls.Add(SKU);
            ForeColor = SystemColors.ActiveCaptionText;
            Name = "Form1";
            Text = "Consulta de Produtos";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label SKU;
        private RichTextBox richTextBox1;
        private Button Consultar;
        private Button Cancelar;
        private BindingSource bindingSource1;
        private Label Dimensoes_Produto;
        private RichTextBox richTextBox2;
        private Label label1;
        private Button btExExcel;
    }
}
