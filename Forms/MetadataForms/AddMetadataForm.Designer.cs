namespace Epub_Editor.Forms.MetadataForms
{
    partial class AddMetadataForm
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
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblInfo = new System.Windows.Forms.Label();
            this.lstMetadataItems = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Enabled = false;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.btnSave.Location = new System.Drawing.Point(315, 472);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(122, 28);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "OK";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.btnClose.Location = new System.Drawing.Point(443, 472);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(122, 28);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Cancelar";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(12, 392);
            this.lblInfo.MaximumSize = new System.Drawing.Size(549, 0);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(31, 17);
            this.lblInfo.TabIndex = 5;
            this.lblInfo.Text = "info";
            // 
            // lstMetadataItems
            // 
            this.lstMetadataItems.Alignment = System.Windows.Forms.ListViewAlignment.SnapToGrid;
            this.lstMetadataItems.FullRowSelect = true;
            this.lstMetadataItems.GridLines = true;
            this.lstMetadataItems.HideSelection = false;
            this.lstMetadataItems.Location = new System.Drawing.Point(12, 12);
            this.lstMetadataItems.MultiSelect = false;
            this.lstMetadataItems.Name = "lstMetadataItems";
            this.lstMetadataItems.Size = new System.Drawing.Size(549, 377);
            this.lstMetadataItems.TabIndex = 6;
            this.lstMetadataItems.UseCompatibleStateImageBehavior = false;
            this.lstMetadataItems.View = System.Windows.Forms.View.List;
            this.lstMetadataItems.SelectedIndexChanged += new System.EventHandler(this.lstMetadataItems_SelectedIndexChanged);
            // 
            // AddMetadataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 508);
            this.Controls.Add(this.lstMetadataItems);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AddMetadataForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Adicionar Metadados";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.AddMetadataForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.ListView lstMetadataItems;
    }
}