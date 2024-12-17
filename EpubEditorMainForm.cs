using System;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Windows.Forms;

namespace Epub_Editor
{
    public partial class EpubEditorMainForm : Form
    {

        ZipArchive epubArchive;

        public EpubEditorMainForm()
        {
            InitializeComponent();
        }

        public static void ListEpubFiles(ZipArchive archive, TreeView treeView)
        {
            // Limpa a ListView antes de adicionar novos itens
            treeView.Nodes.Clear();

            // Cria e adiciona ícones na SmallImageList
            ImageList icons = new ImageList();
            icons.ImageSize = new System.Drawing.Size(16, 16);

            // Adiciona ícones
            icons.Images.Add("folderWithFiles", Properties.Resources.pasta);  // Pasta com arquivos
            icons.Images.Add("emptyFolder", Properties.Resources.pasta);      // Pasta vazia
            icons.Images.Add("html", Properties.Resources.html);              // Arquivo HTML
            icons.Images.Add("css", Properties.Resources.css);                // Arquivo CSS
            icons.Images.Add("font", Properties.Resources.fonte);             // Arquivo de fonte
            icons.Images.Add("config", Properties.Resources.ferramentas);     // Arquivo de configuração
            icons.Images.Add("audio", Properties.Resources.audio);            // Arquivo de Audio
            icons.Images.Add("video", Properties.Resources.video);            // Arquivo de Video
            icons.Images.Add("generic", Properties.Resources.arquivo);        // Arquivo genérico

            treeView.ImageList = icons;

            try
            {
                // Abre o arquivo .epub como um arquivo ZIP

                TreeNode rootNode = new TreeNode("EPUB") { ImageKey = "folder", SelectedImageKey = "folder" };
                treeView.Nodes.Add(rootNode);

                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    string[] pathParts = entry.FullName.Split('/');
                    AddToTree(rootNode, pathParts, entry);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar arquivos: " + ex.Message);
            }

        }

        // Função recursiva para adicionar pastas e arquivos ao TreeView
        private static void AddToTree(TreeNode parentNode, string[] pathParts, ZipArchiveEntry entry, int depth = 0)
        {
            if (depth >= pathParts.Length || string.IsNullOrEmpty(pathParts[depth]))
                return;

            TreeNode foundNode = null;

            // Procura se o nó (pasta ou arquivo) já existe
            foreach (TreeNode node in parentNode.Nodes)
            {
                if (node.Text == pathParts[depth])
                {
                    foundNode = node;
                    break;
                }
            }

            // Se o nó não existe, cria um novo
            if (foundNode == null)
            {
                string name = pathParts[depth];
                bool isFile = (depth == pathParts.Length - 1 && !string.IsNullOrEmpty(Path.GetExtension(name)));

                string imageKey = isFile ? GetFileTypeIcon(name) : "folder";
                foundNode = new TreeNode(name)
                {
                    ImageKey = imageKey,
                    SelectedImageKey = imageKey
                };
                parentNode.Nodes.Add(foundNode);
                parentNode.Expand();
            }

            // Chama a função recursiva para o próximo nível
            AddToTree(foundNode, pathParts, entry, depth + 1);
        }

        // Retorna a chave do ícone baseado no tipo do arquivo
        private static string GetFileTypeIcon(string fileName)
        {
            string extension = Path.GetExtension(fileName).ToLower();
            switch (extension)
            {
                case ".html":
                    return "html";
                case ".css":
                    return "css";
                case ".ttf":
                case ".otf":
                    return "font";
                case ".opf":
                case ".ncx":
                    return "config";
                default:
                    return "generic";
            }
        }

        // Função auxiliar para verificar se a pasta contém arquivos
        private static bool HasFilesInFolder(string folderPath, ZipArchive archive)
        {
            foreach (var entry in archive.Entries)
            {
                if (entry.FullName.StartsWith(folderPath) && !string.IsNullOrEmpty(entry.Name))
                {
                    return true;
                }
            }
            return false;
        }

        private void OpenHtmlFileInTab(string filePath, TreeNode node, TabControl tabControl)
        {

            // Lê o conteúdo do arquivo
            //string fileContent = epubArchive.GetEntry(node.FullPath).Archive.;


            /**/ /**/ /**/ /**/ /**/ /**/ /**/ /**/ /**/ /**/ /**/ /**/ /**/ /**/ /**/
            /**/ /**/ /**/ /**/ /**/ /**/ /**/ /**/ /**/ /**/ /**/ /**/ /**/ /**/ /**/
            /**/ /**/ /**/ /**/ /**/ /**/ /**/ /**/ /**/ /**/ /**/ /**/ /**/ /**/ /**/
            /**/ /**/ /**/ /**/ /**/ /**/ /**/ /**/ /**/ /**/ /**/ /**/ /**/ /**/ /**/

            // Cria uma nova aba no TabControl
            TabPage newTab = new TabPage(Path.GetFileName(filePath));

            // Cria um RichTextBox para exibir o conteúdo do HTML
            RichTextBox richTextBox = new RichTextBox
            {
                Dock = DockStyle.Fill,
                Text = fileContent,
                ReadOnly = false, // Permite edição
                Font = new Font("Consolas", 10), // Define uma fonte monoespaçada
                WordWrap = false
            };

            // Adiciona o RichTextBox à aba
            newTab.Controls.Add(richTextBox);

            // Adiciona a nova aba ao TabControl
            tabControl.TabPages.Add(newTab);

            // Seleciona a aba recém-criada
            tabControl.SelectedTab = newTab;
        }



        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                string directoryPath = Path.GetDirectoryName(filePath);

                if (Directory.Exists(directoryPath))
                {
                    using (ZipArchive archive = ZipFile.OpenRead(filePath))
                    {
                        ListEpubFiles(archive, epubTreeView);
                        ActiveForm.Text = (string.Format("{0} - {1}", "Epub Editor", filePath));
                    }
                }
            }
        }

        private void epubTreeView_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (e.Label == null) // Se não houver novo nome, cancelar
                return;

            TreeView treeView = sender as TreeView;
            TreeNode node = treeView.Nodes[e.Node.Index];

            try
            {
                // Caminho atual do arquivo ou pasta (assumindo que foi salvo no Tag do item)
                string oldPath = node.Tag as string;
                if (string.IsNullOrEmpty(oldPath))
                    return;

                string newName = e.Label;
                string directory = Path.GetDirectoryName(oldPath);
                string newPath = Path.Combine(directory, newName);

                // Verificar se o arquivo ou pasta existe
                if (File.Exists(oldPath))
                {
                    File.Move(oldPath, newPath);
                }
                else if (Directory.Exists(oldPath))
                {
                    Directory.Move(oldPath, newPath);
                }
                else
                {
                    throw new Exception("O arquivo ou diretório não foi encontrado.");
                }

                // Atualiza o Tag para o novo caminho
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
                OpenHtmlFileInTab(filePath, tabControl);
            }

            /*
            if (e.Node != null)
            {
                // Inicia a edição do nó ao clicar duas vezes
                e.Node.BeginEdit();
            }
            */
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
    }

}