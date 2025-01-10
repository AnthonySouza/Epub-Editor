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
using System.Security.Cryptography;
using HtmlAgilityPack;
using ScintillaNET;
using System.Xml.Linq;
using System.Xml;
using System.Text.RegularExpressions;
using System.Net;
using System.Reflection;

namespace Epub_Editor.AppCore
{
    public static class Core
    {

        //private static EpubFile epubFile;
        public const string TEMP_PATH_FOLDER = "\\temp\\";
        public const string METADATA_XML_NAMESPACE = "http://purl.org/dc/elements/1.1/";
        public const string METADATA_PROPERTY_XML_NAMESPACE = "http://www.idpf.org/2007/opf";
        public const string DEFAULT_XML_NAMESPACE = "http://www.idpf.org/2007/opf";
        public const string CONTENT_OPF_FILENAME = "content.opf";

        public static string CreateTempDirectory(string tempDirectory)
        {

            string tempDir = string.Format("{0}{1}{2}", Path.GetDirectoryName(Application.ExecutablePath), TEMP_PATH_FOLDER, tempDirectory);

            try
            {
                Directory.CreateDirectory(tempDir);
                return tempDir;
            }
            catch
            {
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
                epub.XhtmlFiles = GetXhtmlEpubArray(extractPath);
                epub.HasEdited = false;

                return epub;
            }
            catch
            {
                throw new Exception();
            }
        }

        public static XhtmlFile[] GetXhtmlEpubArray(string tempPath)
        {

            if (Directory.Exists(tempPath))
            {
                List<XhtmlFile> list = new List<XhtmlFile>();

                try
                {
                    string[] files = Directory.GetFiles(tempPath, "*.xhtml", SearchOption.AllDirectories);

                    foreach (string file in files)
                    {
                        string content = File.ReadAllText(file);
                        list.Add(new XhtmlFile
                        {
                            FileName = Path.GetFileName(file),
                            HasEdited = false,
                            FileTempPath = file,
                            OriginalFileHash = Core.GetMd5Hash(content),
                            XhtmlContends = content
                        });
                    }
                }
                catch (Exception)
                {

                    throw new Exception();
                }

                return list.ToArray();

            }

            return null;
        }

        public static bool ExportToEpubFile(EpubFile epub, bool overrideFile)
        {
            try
            {
                if (File.Exists(epub.OriginalPath))
                    if (overrideFile)
                        File.Delete(epub.OriginalPath); //Se já existir exclui o arquivo original
                    else
                    {
                        SaveFileDialog sfd = new SaveFileDialog();
                        sfd.Filter = "Arquivo EPUB (*.epub)|*.epub";
                        sfd.FileName = epub.FileName;
                        sfd.Title = "Salvar Como";
                        sfd.InitialDirectory = epub.OriginalPath;
                        if (sfd.ShowDialog() == DialogResult.OK)

                            //Salva os arquivos xhtml no temp
                            foreach (XhtmlFile item in epub.XhtmlFiles)
                            {
                                if (item.HasEdited == true)
                                {
                                    SaveHtmlFile(item.XhtmlContends, item.FileTempPath);
                                }
                            }

                        ZipFile.CreateFromDirectory(epub.TempPath, string.Format("{0}{1}", Path.GetDirectoryName(epub.OriginalPath), sfd.FileName), CompressionLevel.Optimal, false);

                        return true;
                    }

                //Salva os arquivos xhtml no temp
                foreach (XhtmlFile item in epub.XhtmlFiles)
                {
                    if (item.HasEdited == true)
                    {
                        SaveHtmlFile(item.XhtmlContends, item.FileTempPath);
                    }
                }
                ZipFile.CreateFromDirectory(epub.TempPath, epub.OriginalPath, CompressionLevel.Optimal, false);
                return true;
            }
            catch
            {
                throw;
            }
            return false;
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

        public static string GetTempPath()
        {
            return string.Format("{0}{1}", Path.GetDirectoryName(Application.ExecutablePath), TEMP_PATH_FOLDER);
        }

        public static Color IntToColor(int rgb)
        {
            return Color.FromArgb(255, (byte)(rgb >> 16), (byte)(rgb >> 8), (byte)rgb);
        }

        public static string GetMd5Hash(string input)
        {
            using (var md5 = MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);
                return BytesToHexString(hashBytes);
            }
        }

        public static string BytesToHexString(byte[] bytes)
        {
            StringBuilder hex = new StringBuilder(bytes.Length * 2);
            foreach (byte b in bytes)
            {
                hex.AppendFormat("{0:x2}", b); // Formato hexadecimal em minúsculas
            }
            return hex.ToString();
        }
        public static string RemoveCharOverride(HtmlAgilityPack.HtmlDocument document)

        {
            var nodesWithClass = document.DocumentNode.SelectNodes("//*[@class]");
            if (nodesWithClass == null) return document.DocumentNode.OuterHtml;

            foreach (var node in nodesWithClass)
            {
                var classes = node.GetAttributeValue("class", "").Split(' ')
                                  .Where(c => !c.StartsWith("CharOverride-"))
                                  .ToArray();

                if (classes.Length == 0)
                    node.Attributes.Remove("class");
                else
                    node.SetAttributeValue("class", string.Join(" ", classes));

                // Manter o fechamento correto para tags auto-fechadas
                if (IsSelfClosingTag(node))
                {
                    string outerHtml = GetOuterHtmlWithSlash(node);
                    node.ParentNode.ReplaceChild(HtmlAgilityPack.HtmlNode.CreateNode(outerHtml), node);
                }
            }

            return document.DocumentNode.OuterHtml;
        }

        public static string RemoveParaOverride(HtmlAgilityPack.HtmlDocument document)
        {
            var nodesWithClass = document.DocumentNode.SelectNodes("//*[@class]");
            if (nodesWithClass == null) return document.DocumentNode.OuterHtml;

            foreach (var node in nodesWithClass)
            {
                var classes = node.GetAttributeValue("class", "").Split(' ')
                                  .Where(c => !c.StartsWith("ParaOverride-"))
                                  .ToArray();

                if (classes.Length == 0)
                    node.Attributes.Remove("class");
                else
                    node.SetAttributeValue("class", string.Join(" ", classes));

                // Manter o fechamento correto para tags auto-fechadas
                if (IsSelfClosingTag(node))
                {
                    string outerHtml = GetOuterHtmlWithSlash(node);
                    node.ParentNode.ReplaceChild(HtmlAgilityPack.HtmlNode.CreateNode(outerHtml), node);
                }
            }

            return document.DocumentNode.OuterHtml;
        }

        public static string RemoveEmptySpan(HtmlAgilityPack.HtmlDocument document)
        {
            var emptySpans = document.DocumentNode.SelectNodes("//span[not(@*) and not(normalize-space())]");
            if (emptySpans == null) return document.DocumentNode.OuterHtml;

            foreach (var span in emptySpans)
            {
                span.ParentNode.RemoveChild(span);
            }

            return document.DocumentNode.OuterHtml;
        }

        public static string RemoveIdGenCharOverride(HtmlAgilityPack.HtmlDocument document)
        {
            var nodesWithClass = document.DocumentNode.SelectNodes("//*[@class]");
            if (nodesWithClass == null) return document.DocumentNode.OuterHtml;

            foreach (var node in nodesWithClass)
            {
                var classes = node.GetAttributeValue("class", "").Split(' ')
                                  .Where(c => !c.StartsWith("_idGenCharOverride-"))
                                  .ToArray();

                if (classes.Length == 0)
                    node.Attributes.Remove("class");
                else
                    node.SetAttributeValue("class", string.Join(" ", classes));

                if (IsSelfClosingTag(node))
                {
                    string outerHtml = GetOuterHtmlWithSlash(node);
                    node.ParentNode.ReplaceChild(HtmlAgilityPack.HtmlNode.CreateNode(outerHtml), node);
                }
            }

            return document.DocumentNode.OuterHtml;
        }

        public static string RemoveIdGenParaOverride(HtmlAgilityPack.HtmlDocument document)
        {
            var nodesWithClass = document.DocumentNode.SelectNodes("//*[@class]");
            if (nodesWithClass == null) return document.DocumentNode.OuterHtml;

            foreach (var node in nodesWithClass)
            {
                var classes = node.GetAttributeValue("class", "").Split(' ')
                                  .Where(c => !c.StartsWith("_idGenParaOverride-"))
                                  .ToArray();

                if (classes.Length == 0)
                    node.Attributes.Remove("class");
                else
                    node.SetAttributeValue("class", string.Join(" ", classes));

                if (IsSelfClosingTag(node))
                {
                    string outerHtml = GetOuterHtmlWithSlash(node);
                    node.ParentNode.ReplaceChild(HtmlAgilityPack.HtmlNode.CreateNode(outerHtml), node);
                }
            }

            return document.DocumentNode.OuterHtml;
        }

        public static string RemoveIdGenObjectStyleOverride(HtmlAgilityPack.HtmlDocument document)
        {
            var nodesWithClass = document.DocumentNode.SelectNodes("//*[@class]");
            if (nodesWithClass == null) return document.DocumentNode.OuterHtml;

            foreach (var node in nodesWithClass)
            {
                var classes = node.GetAttributeValue("class", "").Split(' ')
                                  .Where(c => !c.StartsWith("_idGenObjectStyleOverride-"))
                                  .ToArray();

                if (classes.Length == 0)
                    node.Attributes.Remove("class");
                else
                    node.SetAttributeValue("class", string.Join(" ", classes));

                if (IsSelfClosingTag(node))
                {
                    string outerHtml = GetOuterHtmlWithSlash(node);
                    node.ParentNode.ReplaceChild(HtmlAgilityPack.HtmlNode.CreateNode(outerHtml), node);
                }
            }

            return document.DocumentNode.OuterHtml;
        }

        private static bool IsSelfClosingTag(HtmlAgilityPack.HtmlNode node)
        {
            // Verifica se a tag é auto-fechada
            var selfClosingTags = new HashSet<string> { "link", "img", "input", "br", "meta", "hr", "area", "base", "col", "embed", "source" };
            return selfClosingTags.Contains(node.Name);
        }

        private static string GetOuterHtmlWithSlash(HtmlAgilityPack.HtmlNode node)
        {
            // Reconstruir a tag com a barra de fechamento
            string outerHtml = node.OuterHtml;

            // Adicionar a barra de fechamento se necessário
            if (outerHtml.EndsWith(">"))
            {
                outerHtml = outerHtml.TrimEnd('>') + " />";  // Garante o fechamento adequado
            }

            return outerHtml;
        }

        public static string AddBrAroundCitationBlocks(HtmlAgilityPack.HtmlDocument document)
        {

            // Selecionar todos os parágrafos
            var paragraphs = document.DocumentNode.SelectNodes("//p");
            if (paragraphs == null)
                return document.DocumentNode.OuterHtml;

            bool insideCitationBlock = false;
            HtmlNode brBefore = null, brAfter = null;

            foreach (var paragraph in paragraphs)
            {
                bool isCitation = paragraph.GetAttributeValue("class", "").Equals("citacao");

                if (isCitation)
                {
                    // Estamos no início de um bloco de citações
                    if (!insideCitationBlock)
                    {
                        // Adicionar <br/> antes do primeiro bloco de citações
                        brBefore = HtmlNode.CreateNode("<br/>");
                        paragraph.ParentNode.InsertBefore(brBefore, paragraph);
                        insideCitationBlock = true;
                    }
                }
                else
                {
                    // Se estávamos em um bloco de citações, mas saímos
                    if (insideCitationBlock)
                    {
                        // Adicionar <br/> após o último bloco de citações
                        brAfter = HtmlNode.CreateNode("<br/>");
                        paragraph.ParentNode.InsertBefore(brAfter, paragraph);
                        insideCitationBlock = false;
                    }
                }
            }

            // Caso todo o HTML termine com um bloco de citações, garantir que <br/> seja adicionado no final
            if (insideCitationBlock && brAfter == null)
            {
                brAfter = HtmlNode.CreateNode("<br/>");
                paragraphs.Last().ParentNode.InsertAfter(brAfter, paragraphs.Last());
            }

            return document.DocumentNode.OuterHtml;
        }

        public static string AddBrAroundTopicBlocks(HtmlAgilityPack.HtmlDocument document)
        {
            // Selecionar todos os parágrafos
            var paragraphs = document.DocumentNode.SelectNodes("//p");
            if (paragraphs == null)
                return document.DocumentNode.OuterHtml;

            string[] topicos = { "topico", "topicos", "topico-abc", "topicos-abc", "topico-num", "topicos-num", "topico-abc-vazio", "topicos-abc-vazio", "topico-rom", "topicos-rom" };
            bool insideCitationBlock = false;
            HtmlNode brBefore = null;

            foreach (var paragraph in paragraphs)
            {
                // Verificar se o parágrafo atual pertence a um tópico
                bool isCitation = topicos.Contains(paragraph.GetAttributeValue("class", ""));

                if (isCitation)
                {
                    if (!insideCitationBlock)
                    {
                        // Adicionar <br/> antes do primeiro bloco de tópicos
                        brBefore = HtmlNode.CreateNode("<br/>");
                        paragraph.ParentNode.InsertBefore(brBefore, paragraph);
                        insideCitationBlock = true;
                    }
                }
                else
                {
                    if (insideCitationBlock)
                    {
                        // Adicionar <br/> após o último bloco de tópicos
                        var brAfter = HtmlNode.CreateNode("<br/>");
                        paragraph.ParentNode.InsertBefore(brAfter, paragraph);
                        insideCitationBlock = false;
                    }
                }
            }

            // Caso o bloco de tópicos termine no final do documento, adicionar <br/> ao final
            if (insideCitationBlock)
            {
                var brAfter = HtmlNode.CreateNode("<br/>");
                paragraphs.Last().ParentNode.InsertAfter(brAfter, paragraphs.Last());
            }

            return document.DocumentNode.OuterHtml;
        }

        public static string AddStToFooterLinks(HtmlAgilityPack.HtmlDocument document)
        {

            // Seleciona todas as tags <p> com classe "rodape"
            var footerParagraphs = document.DocumentNode.SelectNodes("//p[contains(@class, 'rodape')]");

            if (footerParagraphs == null) return document.DocumentNode.OuterHtml;

            foreach (var paragraph in footerParagraphs)
            {
                // Seleciona todas as tags <a> dentro do parágrafo
                var links = paragraph.SelectNodes(".//a");
                if (links == null) continue;

                // Adiciona a classe "st" a cada tag <a>
                foreach (var link in links)
                {
                    var existingClasses = link.GetAttributeValue("class", "");
                    var updatedClasses = string.Join(" ", existingClasses.Split(' ').Append("st").Distinct());
                    link.SetAttributeValue("class", updatedClasses.Trim());
                }
            }

            return document.DocumentNode.OuterHtml;
        }

        public static string RemoveLangAndXmlLangAttributes(HtmlAgilityPack.HtmlDocument document)
        {
            if (document == null) return document.DocumentNode.OuterHtml;

            // Criar um gerenciador de espaços de nomes
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(new NameTable());
            nsmgr.AddNamespace("xml", "http://www.w3.org/XML/1998/namespace");

            // Seleciona nós com atributo lang
            var nodesWithLangAttributes = document.DocumentNode.SelectNodes("//*[@lang]");
            if (nodesWithLangAttributes != null)
            {
                foreach (var node in nodesWithLangAttributes)
                {
                    node.Attributes.Remove("lang");
                }
            }

            /*
            // Seleciona nós com o atributo xml:lang usando o namespace
            var nodesWithXmlLangAttributes = document.DocumentNode.SelectNodes("//*[@xml:lang]", nsmgr);
            if (nodesWithXmlLangAttributes != null)
            {
                foreach (var node in nodesWithXmlLangAttributes)
                {
                    node.Attributes.Remove("xml:lang");
                }
            }
            */

            return document.DocumentNode.OuterHtml;
        }

        public static string ReplaceArabicNumbers(HtmlAgilityPack.HtmlDocument document)
        {
            // Dicionário de substituição dos números árabes pelos ocidentais
            var arabicToWesternNumbers = new Dictionary<char, char>
            {
                {'٠', '0'},
                {'١', '1'},
                {'٢', '2'},
                {'٣', '3'},
                {'٤', '4'},
                {'٥', '5'},
                {'٦', '6'},
                {'٧', '7'},
                {'٨', '8'},
                {'٩', '9'}
            };

            // Percorre todos os nós de texto no HTML
            var textNodes = document.DocumentNode.SelectNodes("//text()");
            if (textNodes != null)
            {
                foreach (var textNode in textNodes)
                {
                    var text = textNode.InnerText;
                    var updatedText = new String(text.Select(c =>
                        arabicToWesternNumbers.ContainsKey(c) ? arabicToWesternNumbers[c] : c).ToArray());

                    textNode.InnerHtml = updatedText;
                }
            }

            return document.DocumentNode.OuterHtml;
        }

        public static string FormatHtml(HtmlAgilityPack.HtmlDocument document)
        {

            // Usa um StringBuilder para criar a string formatada
            StringBuilder formattedHtml = new StringBuilder();

            // Chama o método para formatar o documento
            FormatNode(document.DocumentNode, formattedHtml, 0);

            return formattedHtml.ToString();
        }

        private static void FormatNode(HtmlNode node, StringBuilder builder, int indentLevel)
        {
            // Adiciona indentação antes da tag
            builder.AppendLine(new string('\t', indentLevel * 2)); // usa 2 espaços por nível, pode ser ajustado para tabulação

            // Se o nó for uma tag de início (como <div>, <p>, etc)
            builder.Append("<" + node.Name);

            // Adiciona os atributos da tag, se houver
            if (node.Attributes.Count > 0)
            {
                foreach (var attribute in node.Attributes)
                {
                    builder.Append($" {attribute.Name}=\"{attribute.Value}\"");
                }
            }

            builder.Append(">");

            // Verifica se o nó contém conteúdo (texto ou outros elementos)
            if (!node.HasChildNodes)
            {
                builder.Append(node.InnerHtml);
            }
            else
            {
                builder.AppendLine(); // Adiciona uma nova linha após a tag de abertura

                // Formata os filhos do nó com a indentação correta
                foreach (var child in node.ChildNodes)
                {
                    FormatNode(child, builder, indentLevel + 1); // aumenta a indentação para os filhos
                }

                builder.AppendLine(new string(' ', indentLevel * 2)); // fecha o nó com a indentação correta
            }

            // Fecha a tag
            builder.AppendLine($"</{node.Name}>");
        }

        public static string FindTagAtPosition(int charIndex, RichTextBox rtb)
        {
            // Regex para encontrar uma tag
            string tagPattern = @"<(/?[\w-]+)([^>]*?)>";

            // Procura pela tag que está na posição do clique
            var match = Regex.Match(rtb.Text, tagPattern);
            while (match.Success)
            {
                if (charIndex >= match.Index && charIndex <= match.Index + match.Length)
                {
                    // Retorna o nome da tag
                    return match.Groups[1].Value;
                }
                match = match.NextMatch();
            }
            return null;
        }

        public static EpubFile CleanAllXhtmlFiles(
            EpubFile epubFile,
            ToolStripProgressBar progressBar,
            bool remCharOverrideCkb,
            bool remParaOverrideCkb,
            bool remEmptySpanCkb,
            bool remGenCharOverrideCkb,
            bool remObjStyleOverrideCkb,
            bool insertBrTagCit,
            bool insertBrTagTop,
            bool insertStFootnote,
            bool remLangAttrib,
            bool resetNumChars,
            bool remGenParaOverrideCkb)
        {

            if (epubFile == null)
            {
                return null;
            }

            progressBar.Maximum = epubFile.XhtmlFiles.Length;
            progressBar.Value = 0;

            foreach (XhtmlFile xhtml in epubFile.XhtmlFiles)
            {
                var xhtmlAgility = new HtmlAgilityPack.HtmlDocument();
                xhtmlAgility.LoadHtml(xhtml.XhtmlContends);

                if (remCharOverrideCkb)
                {
                    xhtml.XhtmlContends = RemoveCharOverride(xhtmlAgility);
                    xhtml.HasEdited = true;
                }

                if (remParaOverrideCkb)
                {
                    xhtml.XhtmlContends = RemoveParaOverride(xhtmlAgility);
                    xhtml.HasEdited = true;
                }

                if (remGenCharOverrideCkb)
                {
                    xhtml.XhtmlContends = RemoveIdGenCharOverride(xhtmlAgility);
                    xhtml.HasEdited = true;
                }

                if (remGenParaOverrideCkb)
                {
                    xhtml.XhtmlContends = RemoveIdGenParaOverride(xhtmlAgility);
                    xhtml.HasEdited = true;
                }

                if (remObjStyleOverrideCkb)
                {
                    xhtml.XhtmlContends = RemoveIdGenObjectStyleOverride(xhtmlAgility);
                    xhtml.HasEdited = true;
                }

                if (insertBrTagCit)
                {
                    xhtml.XhtmlContends = AddBrAroundCitationBlocks(xhtmlAgility);
                    xhtml.HasEdited = true;
                }

                if (insertBrTagTop)
                {
                    xhtml.XhtmlContends = AddBrAroundTopicBlocks(xhtmlAgility);
                    xhtml.HasEdited = true;
                }

                if (insertStFootnote)
                {
                    xhtml.XhtmlContends = AddStToFooterLinks(xhtmlAgility);
                    xhtml.HasEdited = true;
                }

                if (remLangAttrib)
                {
                    xhtml.XhtmlContends = RemoveLangAndXmlLangAttributes(xhtmlAgility);
                    xhtml.HasEdited = true;
                }

                if (resetNumChars)
                {
                    xhtml.XhtmlContends = ReplaceArabicNumbers(xhtmlAgility);
                    xhtml.HasEdited = true;
                }

                if (remEmptySpanCkb)
                {
                    xhtml.XhtmlContends = RemoveEmptySpan(xhtmlAgility);
                    xhtml.HasEdited = true;
                }

                progressBar.Value++;
            }

            progressBar.Value = progressBar.Maximum;
            return epubFile;
        }

        public static EpubFile ReadEpubDocument(string filePath)
        {
            List<XhtmlFile> xhtmlFiles = new List<XhtmlFile>();
            MetadataDocument metadata = new MetadataDocument();

            if (File.Exists(filePath))
            {

                using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                using (ZipArchive archive = new ZipArchive(fs, ZipArchiveMode.Read))
                {
                    foreach (var entry in archive.Entries)
                    {
                        //faz a leitura de todos os arquivos .xhtml
                        if (Path.GetExtension(entry.FullName).Equals(".xhtml", StringComparison.OrdinalIgnoreCase))
                        {
                            using (StreamReader reader = new StreamReader(entry.Open()))
                            {
                                string content = reader.ReadToEnd();
                                string originalHash = CalculateHash(content);

                                xhtmlFiles.Add(new XhtmlFile
                                {
                                    FileTempPath = entry.FullName, // Nome no ZIP
                                    FileName = Path.GetFileName(entry.FullName),
                                    OriginalFileHash = originalHash,
                                    XhtmlContends = content,
                                    HasEdited = false
                                });
                            }
                        }

                        //faz a leitura do content.opf
                        if(Path.GetExtension(entry.FullName).Equals(".opf", StringComparison.OrdinalIgnoreCase))
                        {
                            using (StreamReader reader = new StreamReader(entry.Open()))
                            {

                                string content = reader.ReadToEnd();
                                metadata = ReadMetadataFromXml(LoadContentOPFXml(content));

                            }
                        }
                    }
                }

                return new EpubFile
                {
                    FileName = Path.GetFileName(filePath),
                    TempPath = "\\OEBPS\\",
                    OriginalPath = filePath,
                    XhtmlFiles = xhtmlFiles.ToArray(),
                    HasEdited = false,
                    Metadata = metadata
                };

            }

            return null;
        }

        public static void PopulateTreeView(System.Windows.Forms.TreeView treeView, EpubFile epubFile)
        {
            treeView.Nodes.Clear();

            ImageList icons = new ImageList();
            icons.Images.Add("folder", Properties.Resources.pasta);
            icons.Images.Add("file", Properties.Resources.html);

            treeView.ImageList = icons;

            // Cria o nó raiz
            TreeNode rootNode = new TreeNode(epubFile.FileName)
            {
                ImageKey = "folder",
                SelectedImageKey = "folder"
            };

            // Cria o nó "OEBPS"
            TreeNode oebpsNode = new TreeNode("OEBPS")
            {
                ImageKey = "folder",
                SelectedImageKey = "folder"
            };

            rootNode.Nodes.Add(oebpsNode);

            foreach (var xhtmlFile in epubFile.XhtmlFiles.Where(f => f.FileTempPath.Contains("OEBPS")))
            {
                TreeNode fileNode = new TreeNode(xhtmlFile.FileName)
                {
                    ImageKey = "file",
                    SelectedImageKey = "file",
                    Tag = xhtmlFile
                };

                oebpsNode.Nodes.Add(fileNode);
            }

            rootNode.Expand();
            treeView.Nodes.Add(rootNode);

        }

        private static string CalculateHash(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();
            }
        }

        public static XmlDocument LoadContentOPFXml(string opfXmlData)
        {
                
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(opfXmlData);
            return doc;

        }

        public static MetadataDocument ReadMetadataFromXml(XmlDocument xmlDocument)
        {

            if (xmlDocument != null)
            {

                XmlNamespaceManager nsManager = new XmlNamespaceManager(xmlDocument.NameTable);
                nsManager.AddNamespace("dc", METADATA_XML_NAMESPACE);
                nsManager.AddNamespace("opf", METADATA_PROPERTY_XML_NAMESPACE);

                var title = "";
                var creator = "";
                var subject = "";
                var description = "";
                var publisher = "";
                var date = "";
                var source = "";
                var rights = "";
                string[] language = new string[] { };
                var identifier = "";

                title = xmlDocument.SelectSingleNode("//dc:title", nsManager)?.InnerText;
                creator = xmlDocument.SelectSingleNode("//dc:creator", nsManager)?.InnerText;
                subject = xmlDocument.SelectSingleNode("//dc:subject", nsManager)?.InnerText;
                description = xmlDocument.SelectSingleNode("//dc:description", nsManager)?.InnerText;
                publisher = xmlDocument.SelectSingleNode("//dc:publisher", nsManager)?.InnerText;
                source = xmlDocument.SelectSingleNode("//dc:source", nsManager)?.InnerText;
                rights = xmlDocument.SelectSingleNode("//dc:rights", nsManager)?.InnerText;
                identifier = xmlDocument.SelectSingleNode("//dc:identifier", nsManager)?.InnerText;

                //Faz a leitura da tag dc:language
                int i = 0;
                foreach (XmlNode __language in xmlDocument.SelectNodes("//dc:language", nsManager))
                {
                    language[i] = __language?.InnerXml;
                    i++;
                }


                //return new MetadataDocument(generator, cover, title, creator, subject, description, publisher, date, source, relation, coverate, rights, language);

            }   

            return null;
        }
    }
}