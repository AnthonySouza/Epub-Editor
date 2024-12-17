namespace Epub_Editor
{
    partial class FormCleanHtml
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.cleanCodeBtn = new System.Windows.Forms.Button();
            this.input = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.output = new System.Windows.Forms.RichTextBox();
            this.remCharOverrideCkb = new System.Windows.Forms.CheckBox();
            this.remGenCharOverrideCkb = new System.Windows.Forms.CheckBox();
            this.remEmptySpanCkb = new System.Windows.Forms.CheckBox();
            this.remParaOverrideCkb = new System.Windows.Forms.CheckBox();
            this.remObjStyleOverrideCkb = new System.Windows.Forms.CheckBox();
            this.insertBrTagCit = new System.Windows.Forms.CheckBox();
            this.insertStFootnote = new System.Windows.Forms.CheckBox();
            this.insertBrTagTop = new System.Windows.Forms.CheckBox();
            this.remLangAttrib = new System.Windows.Forms.CheckBox();
            this.resetNumChars = new System.Windows.Forms.CheckBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cleanCodeBtn
            // 
            this.cleanCodeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cleanCodeBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.cleanCodeBtn.Location = new System.Drawing.Point(903, 628);
            this.cleanCodeBtn.Name = "cleanCodeBtn";
            this.cleanCodeBtn.Size = new System.Drawing.Size(129, 32);
            this.cleanCodeBtn.TabIndex = 0;
            this.cleanCodeBtn.Text = "Limpar";
            this.cleanCodeBtn.UseVisualStyleBackColor = true;
            this.cleanCodeBtn.Click += new System.EventHandler(this.cleanCodeBtn_Click);
            // 
            // input
            // 
            this.input.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.input.Font = new System.Drawing.Font("Courier New", 10F);
            this.input.Location = new System.Drawing.Point(13, 38);
            this.input.Name = "input";
            this.input.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.input.Size = new System.Drawing.Size(500, 584);
            this.input.TabIndex = 1;
            this.input.Text = "";
            this.input.TextChanged += new System.EventHandler(this.input_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Entrada";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label2.Location = new System.Drawing.Point(529, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Saída";
            // 
            // output
            // 
            this.output.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.output.Font = new System.Drawing.Font("Courier New", 10F);
            this.output.Location = new System.Drawing.Point(532, 38);
            this.output.Name = "output";
            this.output.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.output.Size = new System.Drawing.Size(500, 584);
            this.output.TabIndex = 3;
            this.output.Text = "";
            this.output.MouseClick += new System.Windows.Forms.MouseEventHandler(this.output_MouseClick);
            // 
            // remCharOverrideCkb
            // 
            this.remCharOverrideCkb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.remCharOverrideCkb.AutoSize = true;
            this.remCharOverrideCkb.Checked = true;
            this.remCharOverrideCkb.CheckState = System.Windows.Forms.CheckState.Checked;
            this.remCharOverrideCkb.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.remCharOverrideCkb.Location = new System.Drawing.Point(8, 660);
            this.remCharOverrideCkb.Name = "remCharOverrideCkb";
            this.remCharOverrideCkb.Size = new System.Drawing.Size(173, 21);
            this.remCharOverrideCkb.TabIndex = 5;
            this.remCharOverrideCkb.Text = "Remover CharOverride";
            this.remCharOverrideCkb.UseVisualStyleBackColor = true;
            // 
            // remGenCharOverrideCkb
            // 
            this.remGenCharOverrideCkb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.remGenCharOverrideCkb.AutoSize = true;
            this.remGenCharOverrideCkb.Checked = true;
            this.remGenCharOverrideCkb.CheckState = System.Windows.Forms.CheckState.Checked;
            this.remGenCharOverrideCkb.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.remGenCharOverrideCkb.Location = new System.Drawing.Point(8, 741);
            this.remGenCharOverrideCkb.Name = "remGenCharOverrideCkb";
            this.remGenCharOverrideCkb.Size = new System.Drawing.Size(219, 21);
            this.remGenCharOverrideCkb.TabIndex = 6;
            this.remGenCharOverrideCkb.Text = "Remover _idGenCharOverride";
            this.remGenCharOverrideCkb.UseVisualStyleBackColor = true;
            // 
            // remEmptySpanCkb
            // 
            this.remEmptySpanCkb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.remEmptySpanCkb.AutoSize = true;
            this.remEmptySpanCkb.Checked = true;
            this.remEmptySpanCkb.CheckState = System.Windows.Forms.CheckState.Checked;
            this.remEmptySpanCkb.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.remEmptySpanCkb.Location = new System.Drawing.Point(8, 714);
            this.remEmptySpanCkb.Name = "remEmptySpanCkb";
            this.remEmptySpanCkb.Size = new System.Drawing.Size(164, 21);
            this.remEmptySpanCkb.TabIndex = 7;
            this.remEmptySpanCkb.Text = "Remover Empty Span";
            this.remEmptySpanCkb.UseVisualStyleBackColor = true;
            // 
            // remParaOverrideCkb
            // 
            this.remParaOverrideCkb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.remParaOverrideCkb.AutoSize = true;
            this.remParaOverrideCkb.Checked = true;
            this.remParaOverrideCkb.CheckState = System.Windows.Forms.CheckState.Checked;
            this.remParaOverrideCkb.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.remParaOverrideCkb.Location = new System.Drawing.Point(8, 687);
            this.remParaOverrideCkb.Name = "remParaOverrideCkb";
            this.remParaOverrideCkb.Size = new System.Drawing.Size(173, 21);
            this.remParaOverrideCkb.TabIndex = 8;
            this.remParaOverrideCkb.Text = "Remover ParaOverride";
            this.remParaOverrideCkb.UseVisualStyleBackColor = true;
            // 
            // remObjStyleOverrideCkb
            // 
            this.remObjStyleOverrideCkb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.remObjStyleOverrideCkb.AutoSize = true;
            this.remObjStyleOverrideCkb.Checked = true;
            this.remObjStyleOverrideCkb.CheckState = System.Windows.Forms.CheckState.Checked;
            this.remObjStyleOverrideCkb.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.remObjStyleOverrideCkb.Location = new System.Drawing.Point(8, 768);
            this.remObjStyleOverrideCkb.Name = "remObjStyleOverrideCkb";
            this.remObjStyleOverrideCkb.Size = new System.Drawing.Size(261, 21);
            this.remObjStyleOverrideCkb.TabIndex = 9;
            this.remObjStyleOverrideCkb.Text = "Remover _idGenObjectStyleOverride";
            this.remObjStyleOverrideCkb.UseVisualStyleBackColor = true;
            // 
            // insertBrTagCit
            // 
            this.insertBrTagCit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.insertBrTagCit.AutoSize = true;
            this.insertBrTagCit.Checked = true;
            this.insertBrTagCit.CheckState = System.Windows.Forms.CheckState.Checked;
            this.insertBrTagCit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.insertBrTagCit.Location = new System.Drawing.Point(300, 660);
            this.insertBrTagCit.Name = "insertBrTagCit";
            this.insertBrTagCit.Size = new System.Drawing.Size(273, 21);
            this.insertBrTagCit.TabIndex = 11;
            this.insertBrTagCit.Text = "Inserir tag <br/> cada seção de citação";
            this.insertBrTagCit.UseVisualStyleBackColor = true;
            // 
            // insertStFootnote
            // 
            this.insertStFootnote.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.insertStFootnote.AutoSize = true;
            this.insertStFootnote.Checked = true;
            this.insertStFootnote.CheckState = System.Windows.Forms.CheckState.Checked;
            this.insertStFootnote.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.insertStFootnote.Location = new System.Drawing.Point(300, 714);
            this.insertStFootnote.Name = "insertStFootnote";
            this.insertStFootnote.Size = new System.Drawing.Size(274, 21);
            this.insertStFootnote.TabIndex = 12;
            this.insertStFootnote.Text = "Inserir atributo \"st\" em notas de rodapé";
            this.insertStFootnote.UseVisualStyleBackColor = true;
            // 
            // insertBrTagTop
            // 
            this.insertBrTagTop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.insertBrTagTop.AutoSize = true;
            this.insertBrTagTop.Checked = true;
            this.insertBrTagTop.CheckState = System.Windows.Forms.CheckState.Checked;
            this.insertBrTagTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.insertBrTagTop.Location = new System.Drawing.Point(300, 687);
            this.insertBrTagTop.Name = "insertBrTagTop";
            this.insertBrTagTop.Size = new System.Drawing.Size(266, 21);
            this.insertBrTagTop.TabIndex = 13;
            this.insertBrTagTop.Text = "Inserir tag <br/> cada seção de topico";
            this.insertBrTagTop.UseVisualStyleBackColor = true;
            // 
            // remLangAttrib
            // 
            this.remLangAttrib.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.remLangAttrib.AutoSize = true;
            this.remLangAttrib.Checked = true;
            this.remLangAttrib.CheckState = System.Windows.Forms.CheckState.Checked;
            this.remLangAttrib.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.remLangAttrib.Location = new System.Drawing.Point(300, 741);
            this.remLangAttrib.Name = "remLangAttrib";
            this.remLangAttrib.Size = new System.Drawing.Size(184, 21);
            this.remLangAttrib.TabIndex = 14;
            this.remLangAttrib.Text = "Remover atributos \"lang\"";
            this.remLangAttrib.UseVisualStyleBackColor = true;
            // 
            // resetNumChars
            // 
            this.resetNumChars.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.resetNumChars.AutoSize = true;
            this.resetNumChars.Checked = true;
            this.resetNumChars.CheckState = System.Windows.Forms.CheckState.Checked;
            this.resetNumChars.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.resetNumChars.Location = new System.Drawing.Point(300, 768);
            this.resetNumChars.Name = "resetNumChars";
            this.resetNumChars.Size = new System.Drawing.Size(213, 21);
            this.resetNumChars.TabIndex = 15;
            this.resetNumChars.Text = "Corrigir caracteres numéricos";
            this.resetNumChars.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar});
            this.statusStrip1.Location = new System.Drawing.Point(0, 798);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1052, 22);
            this.statusStrip1.TabIndex = 16;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar
            // 
            this.toolStripProgressBar.Name = "toolStripProgressBar";
            this.toolStripProgressBar.Size = new System.Drawing.Size(300, 16);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1052, 820);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.resetNumChars);
            this.Controls.Add(this.remLangAttrib);
            this.Controls.Add(this.insertBrTagTop);
            this.Controls.Add(this.insertStFootnote);
            this.Controls.Add(this.insertBrTagCit);
            this.Controls.Add(this.remObjStyleOverrideCkb);
            this.Controls.Add(this.remParaOverrideCkb);
            this.Controls.Add(this.remEmptySpanCkb);
            this.Controls.Add(this.remGenCharOverrideCkb);
            this.Controls.Add(this.remCharOverrideCkb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.output);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.input);
            this.Controls.Add(this.cleanCodeBtn);
            this.Name = "Form1";
            this.Text = "Epub Editor";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cleanCodeBtn;
        private System.Windows.Forms.RichTextBox input;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox output;
        private System.Windows.Forms.CheckBox remCharOverrideCkb;
        private System.Windows.Forms.CheckBox remGenCharOverrideCkb;
        private System.Windows.Forms.CheckBox remEmptySpanCkb;
        private System.Windows.Forms.CheckBox remParaOverrideCkb;
        private System.Windows.Forms.CheckBox remObjStyleOverrideCkb;
        private System.Windows.Forms.CheckBox insertBrTagCit;
        private System.Windows.Forms.CheckBox insertStFootnote;
        private System.Windows.Forms.CheckBox insertBrTagTop;
        private System.Windows.Forms.CheckBox remLangAttrib;
        private System.Windows.Forms.CheckBox resetNumChars;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
    }
}

