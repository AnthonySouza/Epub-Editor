using System;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Windows.Forms;
using System.Security;
using ScintillaNET;

using Epub_Editor.AppCore;
using System.Linq;

namespace Epub_Editor
{
    public partial class EpubEditorMainForm : Form
    {

        private ZipArchive epubArchive;
        private EpubFile epubFile;

        public EpubFile EpubFile { get => epubFile; set => epubFile = value; }

        public EpubEditorMainForm()
        {
            InitializeComponent();
        }

        private void OpenHtmlFileInTab(XhtmlFile xhtmlFile, TreeNode node, TabControl tabControl)
        {

            // Lê o conteúdo do arquivo
            string fileContend = xhtmlFile.XhtmlContends;

            foreach (TabPage tab in tabControl.TabPages)
            {
                if (tab.Text == xhtmlFile.FileName)
                {
                    tabControl.SelectedTab = tab;
                    return;
                }
            }

            // Cria uma nova aba no TabControl
            TabPage newTab = new TabPage(xhtmlFile.FileName);


            AdvancedTextBox textEditor = new AdvancedTextBox
            {
                Dock = DockStyle.Fill,
                Text = fileContend,
                Font = new Font("Cascadia Mono", 10),
                WhitespaceBackColor = Color.White,
                WrapMode = WrapMode.None,
                IndentationGuides = IndentView.LookBoth,
                SelectionBackColor = Core.IntToColor(0x114D9C),
                LexerLanguage = "Html",
                HasEdited = false,
                Hash = Core.GetMd5Hash(fileContend)
            };

            textEditor.TextChanged += TextEditor_TextChanged;

            ConfigureHtmlSyntax(textEditor);

            // Adiciona o RichTextBox à aba
            newTab.Controls.Add(textEditor);

            // Adiciona a nova aba ao TabControl
            tabControl.TabPages.Add(newTab);

            // Seleciona a aba recém-criada
            tabControl.SelectedTab = newTab;

        }

        private void TextEditor_TextChanged(object sender, EventArgs e)
        {
            if (sender is AdvancedTextBox advancedTextBox)
            {
                string newHash = Core.GetMd5Hash(advancedTextBox.Text);
                if (advancedTextBox.Hash == newHash)
                {
                    advancedTextBox.HasEdited = false;
                    foreach (TabPage tab in tabControl.TabPages)
                    {
                        if (tab.Controls.Contains(advancedTextBox))
                        {
                            tab.Text = tab.Text.Replace("*", "");
                            EpubFile.HasEdited = false;
                        }
                    }
                }
                else
                {
                    foreach (TabPage tab in tabControl.TabPages)
                    {
                        if (tab.Controls.Contains(advancedTextBox))
                        {
                            if (tab.Text.Contains("*"))
                                tab.Text = tab.Text.Replace("*", "");

                            tab.Text = string.Format("*{0}", tab.Text);
                            advancedTextBox.HasEdited = true;
                            EpubFile.HasEdited = true;
                        }
                    }
                }
            }
            CheckHasEdited();
        }

        private bool CheckHasEdited()
        {
            int ci = 0;
            foreach (TabPage tab in tabControl.TabPages)
            {
                try
                {
                    AdvancedTextBox adTextBox = (AdvancedTextBox)tab.Controls[0];
                    string textBoxHash = Core.GetMd5Hash(adTextBox.Text);
                    string originalTextHash = "";
                    string tabFileName = tab.Text.Replace("*", "");

                    for (int i = 0; i < EpubFile.XhtmlFiles.Length; i++)
                    {
                        if (tabFileName == EpubFile.XhtmlFiles[i].FileName)
                        {
                            originalTextHash = EpubFile.XhtmlFiles[i].OriginalFileHash;
                        }
                    }

                    if (originalTextHash != textBoxHash)
                    {
                        ci++;
                        EpubFile.HasEdited = true;
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }

            if (ci > 0)
            {
                Text = "*Epub Editor";
                return true;
            }

            Text = "Epub Editor";
            return false;
        }

        private void ConfigureHtmlSyntax(Scintilla scintilla)
        {
            // Define cores e estilos
            scintilla.StyleResetDefault();
            scintilla.Styles[Style.Default].Font = "Consolas";
            scintilla.Styles[Style.Default].Size = 10;
            scintilla.StyleClearAll();

            // Configuração para HTML
            scintilla.Styles[Style.Html.Default].ForeColor = System.Drawing.Color.Black; // Texto padrão
            scintilla.Styles[Style.Html.Tag].ForeColor = System.Drawing.Color.Blue; // Tags
            scintilla.Styles[Style.Html.TagUnknown].ForeColor = System.Drawing.Color.Red; // Tags desconhecidas
            scintilla.Styles[Style.Html.Attribute].ForeColor = System.Drawing.Color.Brown; // Atributos
            scintilla.Styles[Style.Html.AttributeUnknown].ForeColor = System.Drawing.Color.Orange; // Atributos desconhecidos
            scintilla.Styles[Style.Html.Number].ForeColor = System.Drawing.Color.DarkCyan; // Números
            scintilla.Styles[Style.Html.DoubleString].ForeColor = System.Drawing.Color.Green; // Strings com aspas duplas
            scintilla.Styles[Style.Html.SingleString].ForeColor = System.Drawing.Color.Green; // Strings com aspas simples
            scintilla.Styles[Style.Html.Other].ForeColor = System.Drawing.Color.Gray; // Outros
            scintilla.Styles[Style.Html.Comment].ForeColor = System.Drawing.Color.ForestGreen; // Comentários
            scintilla.Styles[Style.Html.Entity].ForeColor = System.Drawing.Color.Violet; // Entidades HTML

            // Configuração de palavras-chave opcionais (ex.: tags conhecidas)
            scintilla.SetKeywords(0, "!doctype a abbr accept accept-charset accesskey acronym action address align alink alt applet archive " +
                "area article aside audio axis b background base basefont bdi bdo bgsound bgcolor big blink blockquote " +
                "body border br button canvas caption cellpadding cellspacing center char charoff charset checkbox checked " +
                "cite class classid clear code codebase codetype col colgroup color cols colspan command compact content " +
                "contenteditable contextmenu coords data datafld dataformatas datalist datapagesize datasrc datetime dd " +
                "declare defer del details dfn dialog dir disabled div dl draggable dropzone dt element em embed enctype " +
                "event face fieldset figcaption figure file font footer for form frame frameborder frameset h1 h2 h3 h4 h5 h6 " +
                "head header height hgroup hidden hr href hreflang hspace html http-equiv i id iframe image img input ins isindex " +
                "ismap kbd keygen label lang language leftmargin legend li link listing longdesc main map marginheight marginwidth " +
                "mark marquee maxlength media menu menuitem meta meter multicol method multiple name nav nobr noembed noframes nohref " +
                "noresize noscript noshade nowrap object ol onabort onautocomplete onautocompleteerror onafterprint onbeforeonload " +
                "onbeforeprint onblur oncancel oncanplay oncanplaythrough onchange onclick onclose oncontextmenu oncuechange " +
                "ondblclick ondrag ondragend ondragenter ondragleave ondragover ondragstart ondrop ondurationchange onemptied " +
                "onended onerror onfocus onhashchange oninput oninvalid onkeydown onkeypress onkeyup onload onloadeddata " +
                "onloadedmetadata onloadstart onmessage onmousedown onmouseenter onmouseleave onmousemove onmouseout onmouseover " +
                "onmouseup onmousewheel onoffline ononline onpagehide onpageshow onpause onplay onplaying onpointercancel onpointerdown " +
                "onpointerenter onpointerleave onpointerlockchange onpointerlockerror onpointermove onpointerout onpointerover " +
                "onpointerup onpopstate onprogress onratechange onreadystatechange onredo onreset onresize onscroll onseeked onseeking " +
                "onselect onshow onsort onselect onstalled onstorage onsubmit onsuspend ontimeupdate ontoggle onundo onunload " +
                "onvolumechange onwaiting optgroup option output p param picture plaintext password placeholder pre profile progress " +
                "prompt public q radio readonly rel reset rev rows rowspan rp rt rtc ruby rules s samp scheme scope script section " +
                "select shadow selected shape size small source spacer span spellcheck src standby start strike strong style sub submit " +
                "summary sup svg svg:svg tabindex table target tbody td template text textarea tfoot th thead time title topmargin " +
                "tr track tt type u ul usemap valign value valuetype var version video vlink vspace wbr xmp width xml xmlns");
            scintilla.SetKeywords(1, "class id href src style");

            // Outras configurações
            scintilla.Margins[0].Width = 20; // Margem para números de linha
            scintilla.IndentationGuides = IndentView.LookBoth; // Exibe guias de indentação
        }


        private bool NodeNameExists(TreeNode parentNode, string nodeName)
        {
            foreach (TreeNode sibling in parentNode.Nodes)
            {
                if (sibling.Text.Equals(nodeName, StringComparison.OrdinalIgnoreCase))
                {
                    return true; // O nome já existe entre os nós irmãos
                }
            }
            return false;
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                //string directoryPath = Path.GetDirectoryName(filePath);

                ProcessEpubFile(filePath);

            }
        }

        public void ProcessEpubFile(string filePath)
        {
            //EpubFile = Core.ExportEpubFileToTempDirectory(filePath);

            //Core.ListEpubFiles(EpubFile.TempPath, epubTreeView, treeViewMenuStrip);

            EpubFile = Core.ReadEpubDocument(filePath);
            Core.PopulateTreeView(epubTreeView, EpubFile);

        }

        public void ProcessEpub(EpubFile epub)
        {
            if (epub != null)
            {
                EpubFile = epub;
                Core.PopulateTreeView(epubTreeView, EpubFile);

                tabControl.TabPages.Clear();
            }

        }

        private void renomearToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (epubTreeView.Nodes.Count > 0)
            {

                epubTreeView.SelectedNode.BeginEdit();

            }

        }

        private void apagarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (epubTreeView.Nodes.Count > 0)
            {

                //epubTreeView.SelectedNode.BeginEdit();

            }
        }

        private void epubTreeView_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(e.Label))
            {
                // Bloqueia nomes vazios
                e.CancelEdit = true;
                return;
            }
            else if (e.Node.Parent != null && NodeNameExists(e.Node.Parent, e.Label))
            {
                // Bloqueia nomes duplicados no mesmo nível
                e.CancelEdit = true;
                return;
            }

            // Se estiver tudo certo, continua:
            TreeView treeView = sender as TreeView;
            TreeNode node = treeView.Nodes[0].Nodes[e.Node.Index];

            try
            {
                // Caminho atual do arquivo ou pasta (assumindo que foi salvo no Tag do item)
                string oldPath = node.Text;
                if (oldPath == null)
                    return;

                string newName = e.Label;
                string tempFolderFilePath = string.Format("{0}\\{1}", EpubFile.TempPath, node.FullPath);
                string newPath;


                //string NewDirectory = node.FullPath;
                //string newFileName = string.Format("{0}\\{1}", directory);

                // Verificar se o arquivo ou pasta existe
                if (File.Exists(tempFolderFilePath))
                {

                    newPath = Core.RenameFile(tempFolderFilePath, newName);

                }
                else
                {
                    throw new Exception("O arquivo ou diretório não foi encontrado.");
                }

                //Atualiza o Tag para o novo caminho
                node.Tag = newPath;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao renomear: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.CancelEdit = true; // Cancela a edição em caso de erro
            }
        }

        private void epubTreeView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {

            if (e.Node.Text != null && e.Node.Text.ToString().EndsWith(".xhtml", StringComparison.OrdinalIgnoreCase))
            {
                string filePath = e.Node.FullPath; // Caminho completo do arquivo


                // Chama a função para abrir o HTML no TabControl
                var treeViewTag = e.Node.Tag as XhtmlFile;
                OpenHtmlFileInTab((XhtmlFile)treeViewTag, e.Node, tabControl);
            }

        }

        private void epubTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            /*
            // Verifica se é um arquivo HTML
            if (e.Node.Tag != null && e.Node.Tag.ToString().EndsWith(".html", StringComparison.OrdinalIgnoreCase))
            {
                string filePath = e.Node.Tag.ToString(); // Caminho completo do arquivo

                // Chama a função para abrir o HTML no TabControl
                OpenHtmlFileInTab(filePath, tabControl);
            }
            */
        }

        private void tabControl_DrawItem(object sender, DrawItemEventArgs e)
        {
            TabControl tabControl = sender as TabControl;

            // Obter o retângulo da aba atual
            Rectangle tabRect = tabControl.GetTabRect(e.Index);

            // Margem para evitar sobreposição entre texto e botão
            int closeButtonWidth = 20; // Largura do botão "X"
            int textRightMargin = 20;  // Margem entre o texto e o botão
            int textMaxWidth = tabRect.Width - closeButtonWidth - textRightMargin;

            // Configurações de fonte e cores
            Font font = e.Font ?? tabControl.Font;
            Brush textBrush = Brushes.Black;

            // Texto da aba (corta caso seja maior que o espaço disponível)
            string tabText = tabControl.TabPages[e.Index].Text;
            SizeF textSize = e.Graphics.MeasureString(tabText, font);

            if (textSize.Width > textMaxWidth)
            {
                // Adiciona "..." no final se o texto for maior que o espaço disponível
                tabText = TextRenderer.MeasureText(tabText, font).Width > textMaxWidth
                    ? tabText.Substring(0, Math.Max(0, tabText.Length - 3)) + "..."
                    : tabText;
            }

            // Coordenadas para o texto
            int textX = tabRect.Left + 5; // Espaço à esquerda
            int textY = tabRect.Top + (tabRect.Height - (int)textSize.Height) / 2; // Centralizar verticalmente

            // Desenhar o texto
            e.Graphics.DrawString(tabText, font, textBrush, textX, textY);

            // Coordenadas para o botão "X"
            Rectangle closeButton = new Rectangle(
                tabRect.Right - closeButtonWidth, // Espaço à direita
                tabRect.Top + (tabRect.Height - 16) / 2, // Centralizar verticalmente
                16, // Largura do botão
                16  // Altura do botão
            );

            // Fundo do botão "X"
            e.Graphics.FillRectangle(Brushes.Gray, closeButton);

            // Desenhar o "X" dentro do botão
            using (Font closeFont = new Font("Arial", 8, FontStyle.Bold))
            {
                TextRenderer.DrawText(
                    e.Graphics,
                    "X",
                    closeFont,
                    closeButton,
                    Color.White,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter
                );
            }
        }

        private void tabControl_MouseDown(object sender, MouseEventArgs e)
        {
            TabControl tabControl = sender as TabControl;

            for (int i = 0; i < tabControl.TabPages.Count; i++)
            {
                Rectangle tabRect = tabControl.GetTabRect(i);

                // Coordenadas do botão "X"
                Rectangle closeButton = new Rectangle(
                    tabRect.Right - 20,
                    tabRect.Top + 4,
                    16,
                    16
                );

                if (closeButton.Contains(e.Location))
                {

                    TabPage tabPage = tabControl.TabPages[i];
                    AdvancedTextBox scintillatext = tabPage.Controls[0] as AdvancedTextBox;
                    bool isModified = (bool)scintillatext.HasEdited;

                    if (isModified)
                    {
                        DialogResult dr = MessageBox.Show("O texto foi alterado. Deseja salvar antes de fechar?", "Salvar Alterações", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                        if (dr == DialogResult.Yes)
                        {

                            Scintilla contend = tabPage.Controls[0] as Scintilla;
                            string filePath = "";

                            foreach (TreeNode node in epubTreeView.Nodes[0].Nodes)
                            {
                                if (node.Text == tabPage.Text.Replace("*", ""))
                                {
                                    filePath = string.Format("{0}\\{1}", EpubFile.TempPath, node.FullPath);
                                    Core.SaveHtmlFile(contend.Text, filePath);

                                    foreach (XhtmlFile xhtmlFile in EpubFile.XhtmlFiles)
                                    {
                                        if (xhtmlFile.FileName == tabPage.Text.Replace("*", "")) //Reseta o xhtml
                                        {
                                            xhtmlFile.XhtmlContends = contend.Text;
                                            xhtmlFile.HasEdited = false;
                                            xhtmlFile.OriginalFileHash = Core.GetMd5Hash(xhtmlFile.XhtmlContends);
                                            CheckHasEdited();
                                        }
                                    }

                                    tabControl.TabPages.RemoveAt(i);
                                    break;
                                }
                            }

                        }
                        else if (dr == DialogResult.No)
                        {
                            tabControl.TabPages.RemoveAt(i);
                            CheckHasEdited();
                        }
                        else if (dr == DialogResult.Cancel)
                        {
                            CheckHasEdited();
                            return;
                        }

                    }
                    else
                    {
                        tabControl.TabPages.RemoveAt(i);
                    }

                    break;
                }
            }

        }

        private void salvarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Core.ExportToEpubFile(EpubFile, true);
            /* if (tabControl.TabPages.Count == 0) 
             {
                 Core.ExportToEpubFile(EpubFile, true);
                 return; 
             }*/
        }

        private void salvarComoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Core.ExportToEpubFile(EpubFile, false);
        }

        private void automatizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCleanHtml formCleanHtml = new FormCleanHtml(this);
            formCleanHtml.ShowDialog();
        }
    }

}