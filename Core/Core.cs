using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;
using System.Windows.Forms;
using System.Security.AccessControl;
using System.Security.Policy;
using System.Drawing;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Epub_Editor.Core
{
    public static class Core
    {

        //private static EpubFile epubFile;

        public static string CreateTempDirectory(string tempDirectory)
        {
            
            string tempDir = string.Format("{0}{1}{2}", Path.GetDirectoryName(Application.ExecutablePath), "\\temp\\", tempDirectory);

            try
            {
                Directory.CreateDirectory(tempDir);
                return tempDir;
            } 
            catch { 
                throw new Exception(); 
            }

        }

        public static string CreateTempEpubDirName(string epubFileName)
        {
            return string.Format("{0}{1}{2}-{3}-dir", DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, epubFileName);
        }

        public static void DeleteTempDirectory(string dir)
        {
            if (Directory.Exists(dir))
            {
                Directory.Delete(dir, true);
            }
        }

        public static void DeleteFile(string fileDir)
        {
            if (Directory.Exists(fileDir))
            {
                try
                {
                    File.Delete(fileDir);
                }
                catch
                {
                    throw new Exception();
                }
                
            }
        }

        public static string RenameFile(string fileDir, string fileNewName)
        {
            try
            {
                string newName = string.Format("{0}\\{1}", Path.GetDirectoryName(fileDir), fileNewName);

                File.Move(fileDir, newName);
                return newName;
            }
            catch
            {

                throw new Exception();
            }
        }

        public static EpubFile ExportEpubFileToTempDirectory(string epubFileDir)
        {
            try
            {
                
                string extractPath = CreateTempDirectory(CreateTempEpubDirName(Path.GetFileName(epubFileDir)));
                EpubFile epub = new EpubFile();


                ZipFile.ExtractToDirectory(epubFileDir, extractPath);
                epub.OriginalPath = epubFileDir;
                epub.TempPath = extractPath;
                epub.FileName = Path.GetFileName(epubFileDir);

                return epub;
            }
            catch 
            { 
                throw new Exception();
            }
        }

        public static void ListEpubFiles(ZipArchive archive, System.Windows.Forms.TreeView treeView)
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

        public static void ListEpubFiles(string directoryPath, System.Windows.Forms.TreeView treeView, ContextMenuStrip contextMenuStrip)
        {
            // Limpa a TreeView antes de adicionar novos itens
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
                // Cria o nó raiz com o nome do diretório base
                DirectoryInfo rootDirectory = new DirectoryInfo(string.Format("{0}\\OEBPS\\", directoryPath));

                if (!rootDirectory.Exists)
                    throw new DirectoryNotFoundException($"O diretório '{directoryPath}' não foi encontrado.");

                TreeNode rootNode = new TreeNode(rootDirectory.Name) { ImageKey = "folderWithFiles", SelectedImageKey = "folderWithFiles" };
                treeView.Nodes.Add(rootNode);

                // Adiciona arquivos e pastas recursivamente
                PopulateTreeView(rootDirectory, rootNode, contextMenuStrip);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar arquivos: " + ex.Message);
            }
        }

        private static void PopulateTreeView(DirectoryInfo directory, TreeNode parentNode, ContextMenuStrip contextMenuStrip)
        {
            // Adiciona pastas
            foreach (DirectoryInfo subDirectory in directory.GetDirectories())
            {
                TreeNode directoryNode = new TreeNode(subDirectory.Name)
                {
                    ImageKey = "folderWithFiles",
                    SelectedImageKey = "folderWithFiles",
                    ContextMenuStrip = contextMenuStrip
                };

                parentNode.Nodes.Add(directoryNode);

                // Chamada recursiva para subdiretórios
                PopulateTreeView(subDirectory, directoryNode, contextMenuStrip);
            }

            // Adiciona arquivos
            foreach (FileInfo file in directory.GetFiles())
            {
                string fileExtension = file.Extension.ToLower();
                string iconKey = GetFileTypeIcon(fileExtension);

                TreeNode fileNode = new TreeNode(file.Name)
                {
                    ImageKey = iconKey,
                    SelectedImageKey = iconKey,
                    ContextMenuStrip = contextMenuStrip
                };

                parentNode.Nodes.Add(fileNode);
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

        public static string GetXhtmlFileContend(string fileName)
        {
            
            if (File.Exists(fileName))
            {
                return File.ReadAllText(fileName);
            }
            return null;

        }

        public static void SaveHtmlFile(string contend, string path)
        {
            if (!Directory.Exists(path))
            {
                try
                {
                    File.WriteAllText(path, contend);
                }
                catch (Exception)
                {

                    throw new Exception();
                }
            }
        }

        public static Color IntToColor(int rgb)
        {
            return Color.FromArgb(255, (byte)(rgb >> 16), (byte)(rgb >> 8), (byte)rgb);
        }

    }
}