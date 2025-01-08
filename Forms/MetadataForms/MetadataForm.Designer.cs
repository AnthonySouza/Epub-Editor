using System.Windows.Forms;

namespace Epub_Editor.Forms.MetadataForms
{
    partial class MetadataForm : Form
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
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.listViewMetadata = new System.Windows.Forms.ListView();
            this.nameColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.valueColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnAddMetadata = new System.Windows.Forms.Button();
            this.btnAddProperty = new System.Windows.Forms.Button();
            this.btnRemoveMetadata = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.btnClose.Location = new System.Drawing.Point(504, 573);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(122, 28);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Fechar";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.btnSave.Location = new System.Drawing.Point(376, 573);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(122, 28);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Salvar Alterações";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // listViewMetadata
            // 
            this.listViewMetadata.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nameColumnHeader,
            this.valueColumnHeader});
            this.listViewMetadata.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.listViewMetadata.FullRowSelect = true;
            this.listViewMetadata.GridLines = true;
            this.listViewMetadata.HideSelection = false;
            this.listViewMetadata.Location = new System.Drawing.Point(12, 12);
            this.listViewMetadata.Name = "listViewMetadata";
            this.listViewMetadata.Size = new System.Drawing.Size(445, 544);
            this.listViewMetadata.TabIndex = 2;
            this.listViewMetadata.UseCompatibleStateImageBehavior = false;
            this.listViewMetadata.View = System.Windows.Forms.View.Details;
            // 
            // nameColumnHeader
            // 
            this.nameColumnHeader.Text = "Nome";
            this.nameColumnHeader.Width = 230;
            // 
            // valueColumnHeader
            // 
            this.valueColumnHeader.Text = "Valor";
            this.valueColumnHeader.Width = 200;
            // 
            // btnAddMetadata
            // 
            this.btnAddMetadata.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.btnAddMetadata.Location = new System.Drawing.Point(463, 253);
            this.btnAddMetadata.Name = "btnAddMetadata";
            this.btnAddMetadata.Size = new System.Drawing.Size(163, 28);
            this.btnAddMetadata.TabIndex = 3;
            this.btnAddMetadata.Text = "Adicionar Metadado";
            this.btnAddMetadata.UseVisualStyleBackColor = true;
            this.btnAddMetadata.Click += new System.EventHandler(this.btnAddMetadata_Click);
            // 
            // btnAddProperty
            // 
            this.btnAddProperty.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.btnAddProperty.Location = new System.Drawing.Point(463, 287);
            this.btnAddProperty.Name = "btnAddProperty";
            this.btnAddProperty.Size = new System.Drawing.Size(163, 28);
            this.btnAddProperty.TabIndex = 4;
            this.btnAddProperty.Text = "Adicionar Propriedade";
            this.btnAddProperty.UseVisualStyleBackColor = true;
            this.btnAddProperty.Click += new System.EventHandler(this.btnAddProperty_Click);
            // 
            // btnRemoveMetadata
            // 
            this.btnRemoveMetadata.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.btnRemoveMetadata.Location = new System.Drawing.Point(463, 321);
            this.btnRemoveMetadata.Name = "btnRemoveMetadata";
            this.btnRemoveMetadata.Size = new System.Drawing.Size(163, 28);
            this.btnRemoveMetadata.TabIndex = 5;
            this.btnRemoveMetadata.Text = "Remover";
            this.btnRemoveMetadata.UseVisualStyleBackColor = true;
            // 
            // btnUp
            // 
            this.btnUp.Font = new System.Drawing.Font("Wingdings", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnUp.Location = new System.Drawing.Point(508, 355);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(30, 28);
            this.btnUp.TabIndex = 6;
            this.btnUp.Text = "é";
            this.btnUp.UseVisualStyleBackColor = true;
            // 
            // btnDown
            // 
            this.btnDown.Font = new System.Drawing.Font("Wingdings", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnDown.Location = new System.Drawing.Point(555, 355);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(30, 28);
            this.btnDown.TabIndex = 7;
            this.btnDown.Text = "ê";
            this.btnDown.UseVisualStyleBackColor = true;
            // 
            // MetadataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 613);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.btnRemoveMetadata);
            this.Controls.Add(this.btnAddProperty);
            this.Controls.Add(this.btnAddMetadata);
            this.Controls.Add(this.listViewMetadata);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MetadataForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Metadados";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ListView listViewMetadata;
        private System.Windows.Forms.ColumnHeader nameColumnHeader;
        private System.Windows.Forms.ColumnHeader valueColumnHeader;
        private System.Windows.Forms.Button btnAddMetadata;
        private System.Windows.Forms.Button btnAddProperty;
        private System.Windows.Forms.Button btnRemoveMetadata;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnDown;
    }
}