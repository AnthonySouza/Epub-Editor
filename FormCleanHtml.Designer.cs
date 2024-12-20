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
            this.cancelBtn = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cleanCodeBtn
            // 
            this.cleanCodeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cleanCodeBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.cleanCodeBtn.Location = new System.Drawing.Point(626, 112);
            this.cleanCodeBtn.Name = "cleanCodeBtn";
            this.cleanCodeBtn.Size = new System.Drawing.Size(135, 32);
            this.cleanCodeBtn.TabIndex = 0;
            this.cleanCodeBtn.Text = "Automatizar";
            this.cleanCodeBtn.UseVisualStyleBackColor = true;
            this.cleanCodeBtn.Click += new System.EventHandler(this.cleanCodeBtn_Click);
            // 
            // remCharOverrideCkb
            // 
            this.remCharOverrideCkb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.remCharOverrideCkb.AutoSize = true;
            this.remCharOverrideCkb.Checked = true;
            this.remCharOverrideCkb.CheckState = System.Windows.Forms.CheckState.Checked;
            this.remCharOverrideCkb.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.remCharOverrideCkb.Location = new System.Drawing.Point(15, 15);
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
            this.remGenCharOverrideCkb.Location = new System.Drawing.Point(15, 96);
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
            this.remEmptySpanCkb.Location = new System.Drawing.Point(15, 69);
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
            this.remParaOverrideCkb.Location = new System.Drawing.Point(15, 42);
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
            this.remObjStyleOverrideCkb.Location = new System.Drawing.Point(15, 123);
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
            this.insertBrTagCit.Location = new System.Drawing.Point(307, 15);
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
            this.insertStFootnote.Location = new System.Drawing.Point(307, 69);
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
            this.insertBrTagTop.Location = new System.Drawing.Point(307, 42);
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
            this.remLangAttrib.Location = new System.Drawing.Point(307, 96);
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
            this.resetNumChars.Location = new System.Drawing.Point(307, 123);
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 156);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(773, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 16;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar
            // 
            this.toolStripProgressBar.Name = "toolStripProgressBar";
            this.toolStripProgressBar.Size = new System.Drawing.Size(300, 16);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.cancelBtn.Location = new System.Drawing.Point(626, 74);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(135, 32);
            this.cancelBtn.TabIndex = 17;
            this.cancelBtn.Text = "Cancelar";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // FormCleanHtml
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 178);
            this.ControlBox = false;
            this.Controls.Add(this.cancelBtn);
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
            this.Controls.Add(this.cleanCodeBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormCleanHtml";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Epub Editor";
            this.Load += new System.EventHandler(this.FormCleanHtml_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cleanCodeBtn;
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
        private System.Windows.Forms.Button cancelBtn;
    }
}

