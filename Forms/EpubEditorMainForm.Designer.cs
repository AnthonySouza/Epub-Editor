namespace EpubEditor.Forms
{
    partial class EpubEditorMainForm
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
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.epubToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openRecentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.salvarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salvarComoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.epubDocumentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xhtmlFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.desfazerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refazerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.corrigirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.caracteresNuméricosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inserirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tagBRCitacaoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.citacaoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.topicoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.charOverrideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.paraOverrideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.idGenCharOverrideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.idGenObjectOverrideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.atributoslangToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.automatizarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.epubChackerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.metadadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.epubTreeView = new System.Windows.Forms.TreeView();
            this.treeViewMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.renomearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.apagarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl = new EpubEditor.Controls.TabControler();
            this.mainMenuStrip.SuspendLayout();
            this.treeViewMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.epubToolStripMenuItem,
            this.editarToolStripMenuItem1,
            this.epubChackerToolStripMenuItem,
            this.metadadosToolStripMenuItem,
            this.editorsToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(1307, 24);
            this.mainMenuStrip.TabIndex = 0;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // epubToolStripMenuItem
            // 
            this.epubToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirToolStripMenuItem,
            this.openRecentToolStripMenuItem,
            this.toolStripSeparator1,
            this.salvarToolStripMenuItem,
            this.salvarComoToolStripMenuItem,
            this.toolStripSeparator2,
            this.exportToolStripMenuItem,
            this.toolStripSeparator5,
            this.sairToolStripMenuItem});
            this.epubToolStripMenuItem.Name = "epubToolStripMenuItem";
            this.epubToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.epubToolStripMenuItem.Text = "Epub";
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.abrirToolStripMenuItem.Text = "Abrir";
            this.abrirToolStripMenuItem.Click += new System.EventHandler(this.abrirToolStripMenuItem_Click);
            // 
            // openRecentToolStripMenuItem
            // 
            this.openRecentToolStripMenuItem.Name = "openRecentToolStripMenuItem";
            this.openRecentToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.openRecentToolStripMenuItem.Text = "Abrir Recente";
            this.openRecentToolStripMenuItem.MouseHover += new System.EventHandler(this.openRecentToolStripMenuItem_MouseHover);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(142, 6);
            // 
            // salvarToolStripMenuItem
            // 
            this.salvarToolStripMenuItem.Name = "salvarToolStripMenuItem";
            this.salvarToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.salvarToolStripMenuItem.Text = "Salvar";
            this.salvarToolStripMenuItem.Click += new System.EventHandler(this.salvarToolStripMenuItem_Click);
            // 
            // salvarComoToolStripMenuItem
            // 
            this.salvarComoToolStripMenuItem.Name = "salvarComoToolStripMenuItem";
            this.salvarComoToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.salvarComoToolStripMenuItem.Text = "Salvar como";
            this.salvarComoToolStripMenuItem.Click += new System.EventHandler(this.salvarComoToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(142, 6);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.epubDocumentToolStripMenuItem,
            this.xhtmlFilesToolStripMenuItem});
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.exportToolStripMenuItem.Text = "Exportar";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // epubDocumentToolStripMenuItem
            // 
            this.epubDocumentToolStripMenuItem.Name = "epubDocumentToolStripMenuItem";
            this.epubDocumentToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.epubDocumentToolStripMenuItem.Text = "Documento Epub";
            this.epubDocumentToolStripMenuItem.Click += new System.EventHandler(this.epubDocumentToolStripMenuItem_Click);
            // 
            // xhtmlFilesToolStripMenuItem
            // 
            this.xhtmlFilesToolStripMenuItem.Name = "xhtmlFilesToolStripMenuItem";
            this.xhtmlFilesToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.xhtmlFilesToolStripMenuItem.Text = "Arquivos *.xhtml";
            this.xhtmlFilesToolStripMenuItem.Click += new System.EventHandler(this.xhtmlFilesToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(142, 6);
            // 
            // sairToolStripMenuItem
            // 
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            this.sairToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.sairToolStripMenuItem.Text = "Sair";
            this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
            // 
            // editarToolStripMenuItem1
            // 
            this.editarToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.desfazerToolStripMenuItem,
            this.refazerToolStripMenuItem,
            this.toolStripSeparator3,
            this.corrigirToolStripMenuItem,
            this.inserirToolStripMenuItem,
            this.removerToolStripMenuItem,
            this.toolStripSeparator4,
            this.automatizarToolStripMenuItem});
            this.editarToolStripMenuItem1.Name = "editarToolStripMenuItem1";
            this.editarToolStripMenuItem1.Size = new System.Drawing.Size(49, 20);
            this.editarToolStripMenuItem1.Text = "Editar";
            // 
            // desfazerToolStripMenuItem
            // 
            this.desfazerToolStripMenuItem.Name = "desfazerToolStripMenuItem";
            this.desfazerToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.desfazerToolStripMenuItem.Text = "Desfazer";
            // 
            // refazerToolStripMenuItem
            // 
            this.refazerToolStripMenuItem.Name = "refazerToolStripMenuItem";
            this.refazerToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.refazerToolStripMenuItem.Text = "Refazer";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(136, 6);
            // 
            // corrigirToolStripMenuItem
            // 
            this.corrigirToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.caracteresNuméricosToolStripMenuItem});
            this.corrigirToolStripMenuItem.Name = "corrigirToolStripMenuItem";
            this.corrigirToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.corrigirToolStripMenuItem.Text = "Corrigir";
            // 
            // caracteresNuméricosToolStripMenuItem
            // 
            this.caracteresNuméricosToolStripMenuItem.Name = "caracteresNuméricosToolStripMenuItem";
            this.caracteresNuméricosToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.caracteresNuméricosToolStripMenuItem.Text = "Caracteres Numéricos";
            // 
            // inserirToolStripMenuItem
            // 
            this.inserirToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tagBRCitacaoToolStripMenuItem});
            this.inserirToolStripMenuItem.Name = "inserirToolStripMenuItem";
            this.inserirToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.inserirToolStripMenuItem.Text = "Inserir";
            // 
            // tagBRCitacaoToolStripMenuItem
            // 
            this.tagBRCitacaoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.citacaoToolStripMenuItem,
            this.topicoToolStripMenuItem});
            this.tagBRCitacaoToolStripMenuItem.Name = "tagBRCitacaoToolStripMenuItem";
            this.tagBRCitacaoToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.tagBRCitacaoToolStripMenuItem.Text = "Tag BR";
            // 
            // citacaoToolStripMenuItem
            // 
            this.citacaoToolStripMenuItem.Name = "citacaoToolStripMenuItem";
            this.citacaoToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.citacaoToolStripMenuItem.Text = "Citacao";
            // 
            // topicoToolStripMenuItem
            // 
            this.topicoToolStripMenuItem.Name = "topicoToolStripMenuItem";
            this.topicoToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.topicoToolStripMenuItem.Text = "Topico";
            // 
            // removerToolStripMenuItem
            // 
            this.removerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.charOverrideToolStripMenuItem,
            this.paraOverrideToolStripMenuItem,
            this.spanToolStripMenuItem,
            this.idGenCharOverrideToolStripMenuItem,
            this.idGenObjectOverrideToolStripMenuItem,
            this.atributoslangToolStripMenuItem});
            this.removerToolStripMenuItem.Name = "removerToolStripMenuItem";
            this.removerToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.removerToolStripMenuItem.Text = "Remover";
            // 
            // charOverrideToolStripMenuItem
            // 
            this.charOverrideToolStripMenuItem.Name = "charOverrideToolStripMenuItem";
            this.charOverrideToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.charOverrideToolStripMenuItem.Text = "CharOverride";
            // 
            // paraOverrideToolStripMenuItem
            // 
            this.paraOverrideToolStripMenuItem.Name = "paraOverrideToolStripMenuItem";
            this.paraOverrideToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.paraOverrideToolStripMenuItem.Text = "ParaOverride";
            // 
            // spanToolStripMenuItem
            // 
            this.spanToolStripMenuItem.Name = "spanToolStripMenuItem";
            this.spanToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.spanToolStripMenuItem.Text = "Span Vazio";
            // 
            // idGenCharOverrideToolStripMenuItem
            // 
            this.idGenCharOverrideToolStripMenuItem.Name = "idGenCharOverrideToolStripMenuItem";
            this.idGenCharOverrideToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.idGenCharOverrideToolStripMenuItem.Text = "IdGenCharOverride";
            // 
            // idGenObjectOverrideToolStripMenuItem
            // 
            this.idGenObjectOverrideToolStripMenuItem.Name = "idGenObjectOverrideToolStripMenuItem";
            this.idGenObjectOverrideToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.idGenObjectOverrideToolStripMenuItem.Text = "IdGenObjectStyleOverride";
            // 
            // atributoslangToolStripMenuItem
            // 
            this.atributoslangToolStripMenuItem.Name = "atributoslangToolStripMenuItem";
            this.atributoslangToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.atributoslangToolStripMenuItem.Text = "Atributos \"lang\"";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(136, 6);
            // 
            // automatizarToolStripMenuItem
            // 
            this.automatizarToolStripMenuItem.Name = "automatizarToolStripMenuItem";
            this.automatizarToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.automatizarToolStripMenuItem.Text = "Automatizar";
            this.automatizarToolStripMenuItem.Click += new System.EventHandler(this.automatizarToolStripMenuItem_Click);
            // 
            // epubChackerToolStripMenuItem
            // 
            this.epubChackerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirToolStripMenuItem2});
            this.epubChackerToolStripMenuItem.Name = "epubChackerToolStripMenuItem";
            this.epubChackerToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.epubChackerToolStripMenuItem.Text = "Epub-Checker";
            // 
            // abrirToolStripMenuItem2
            // 
            this.abrirToolStripMenuItem2.Name = "abrirToolStripMenuItem2";
            this.abrirToolStripMenuItem2.Size = new System.Drawing.Size(100, 22);
            this.abrirToolStripMenuItem2.Text = "Abrir";
            // 
            // metadadosToolStripMenuItem
            // 
            this.metadadosToolStripMenuItem.Name = "metadadosToolStripMenuItem";
            this.metadadosToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.metadadosToolStripMenuItem.Text = "Metadados";
            this.metadadosToolStripMenuItem.Click += new System.EventHandler(this.metadadosToolStripMenuItem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label2.Location = new System.Drawing.Point(12, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Navegador";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            this.openFileDialog.Filter = "Arquivos EPUB (*.epub)|*.epub";
            // 
            // epubTreeView
            // 
            this.epubTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.epubTreeView.FullRowSelect = true;
            this.epubTreeView.Indent = 12;
            this.epubTreeView.LabelEdit = true;
            this.epubTreeView.Location = new System.Drawing.Point(15, 96);
            this.epubTreeView.Name = "epubTreeView";
            this.epubTreeView.ShowRootLines = false;
            this.epubTreeView.Size = new System.Drawing.Size(287, 629);
            this.epubTreeView.TabIndex = 6;
            this.epubTreeView.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.epubTreeView_AfterLabelEdit);
            this.epubTreeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.epubTreeView_NodeMouseClick);
            this.epubTreeView.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.epubTreeView_NodeMouseDoubleClick);
            // 
            // treeViewMenuStrip
            // 
            this.treeViewMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.renomearToolStripMenuItem,
            this.apagarToolStripMenuItem});
            this.treeViewMenuStrip.Name = "treeViewMenuStrip";
            this.treeViewMenuStrip.Size = new System.Drawing.Size(129, 48);
            // 
            // renomearToolStripMenuItem
            // 
            this.renomearToolStripMenuItem.Name = "renomearToolStripMenuItem";
            this.renomearToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.renomearToolStripMenuItem.Text = "Renomear";
            this.renomearToolStripMenuItem.Click += new System.EventHandler(this.renomearToolStripMenuItem_Click);
            // 
            // apagarToolStripMenuItem
            // 
            this.apagarToolStripMenuItem.Name = "apagarToolStripMenuItem";
            this.apagarToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.apagarToolStripMenuItem.Text = "Excluir";
            this.apagarToolStripMenuItem.Click += new System.EventHandler(this.apagarToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // editorsToolStripMenuItem
            // 
            this.editorsToolStripMenuItem.Name = "editorsToolStripMenuItem";
            this.editorsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.editorsToolStripMenuItem.Text = "Editores";
            this.editorsToolStripMenuItem.Click += new System.EventHandler(this.editorsToolStripMenuItem_Click_1);
            this.editorsToolStripMenuItem.MouseHover += new System.EventHandler(this.editorsToolStripMenuItem_MouseHover);
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControl.Location = new System.Drawing.Point(308, 96);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(987, 629);
            this.tabControl.TabFileNamePath = null;
            this.tabControl.TabIndex = 10;
            this.tabControl.TabName = null;
            this.tabControl.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabControl_DrawItem);
            this.tabControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tabControl_MouseDown);
            // 
            // EpubEditorMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1307, 737);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.epubTreeView);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.mainMenuStrip);
            this.MainMenuStrip = this.mainMenuStrip;
            this.Name = "EpubEditorMainForm";
            this.Text = "Epub Editor";
            this.Load += new System.EventHandler(this.EpubEditorMainForm_Load);
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.treeViewMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem epubToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openRecentToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem salvarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salvarComoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem epubChackerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.TreeView epubTreeView;
        private System.Windows.Forms.ContextMenuStrip treeViewMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem renomearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem apagarToolStripMenuItem;
        private EpubEditor.Controls.TabControler tabControl;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editarToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem desfazerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refazerToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem removerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem charOverrideToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem paraOverrideToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem spanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem idGenCharOverrideToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem idGenObjectOverrideToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem corrigirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem caracteresNuméricosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inserirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tagBRCitacaoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem citacaoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem topicoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem atributoslangToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem automatizarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem metadadosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem epubDocumentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xhtmlFilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editorsToolStripMenuItem;
    }
}