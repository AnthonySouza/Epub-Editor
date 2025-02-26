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
using System.Drawing.Text;
using System.Runtime.InteropServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Security.Cryptography;
using HtmlAgilityPack;
using ScintillaNET;
using System.Xml.Linq;
using System.Xml;
using System.Text.RegularExpressions;
using System.Net;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Xml.Serialization.Configuration;
using System.Diagnostics.Eventing.Reader;

namespace Epub_Editor.AppCore
{
    public static class Core
    {

        public const string APP_MAIN_CONFIG_FOLDER = "editor\\settings\\mainconfig.xml";
        public const string TEMP_PATH_FOLDER                = "\\temp\\";
        public const string METADATA_XML_NAMESPACE          = "http://purl.org/dc/elements/1.1/";
        public const string METADATA_PROPERTY_XML_NAMESPACE = "http://www.idpf.org/2007/opf";
        public const string DEFAULT_XML_NAMESPACE           = "http://www.idpf.org/2007/opf";
        public const string CONTENT_OPF_FILENAME            = "content.opf";
        public const string EPUB_XHTML_TEMP_PATH            = "temp\\epub\\";
        public const string EN_US_LANG = "en-US";
        public const string EN_GB_LANG = "en-GB";
        public const string EN_AU_LANG = "en-AU";
        public const string EN_CA_LANG = "en-CA";
        public const string EN_IN_LANG = "en-IN";
        public const string ES_ES_LANG = "es-ES";
        public const string ES_MX_LANG = "es-MX";
        public const string ES_AR_LANG = "es-AR";
        public const string ES_CO_LANG = "es-CO";
        public const string ES_US_LANG = "es-US";
        public const string FR_FR_LANG = "fr-FR";
        public const string FR_CA_LANG = "fr-CA";
        public const string FR_BE_LANG = "fr-BE";
        public const string PT_PT_LANG = "pt-PT";
        public const string PT_BR_LANG = "pt-BR";
        public const string DE_DE_LANG = "de-DE";
        public const string DE_AT_LANG = "de-AT";
        public const string DE_CH_LANG = "de-CH";
        public const string ZH_CN_LANG = "zh-CN";
        public const string ZH_TW_LANG = "zh-TW";
        public const string ZH_HK_LANG = "zh-HK";
        public const string JA_JP_LANG = "ja-JP";
        public const string KO_KR_LANG = "ko-KR";
        public const string RU_RU_LANG = "ru-RU";
        public const string IT_IT_LANG = "it-IT";
        public const string AR_SA_LANG = "ar-SA";
        public const string AR_AE_LANG = "ar-AE";
        public const string HI_IN_LANG = "hi-IN";
        public const string NL_NL_LANG = "nl-NL";
        public const string SV_SE_LANG = "sv-SE";
        public const string DA_DK_LANG = "da-DK";
        public const string NO_NO_LANG = "no-NO";
        public const string FI_FI_LANG = "fi-FI";
        public const string TR_TR_LANG = "tr-TR";
        public const string PL_PL_LANG = "pl-PL";
        public const string HE_IL_LANG = "he-IL";
        public const string TH_TH_LANG = "th-TH";
        public const string IDENTIFIER_SCHEME_AMAZON_CODE   = "AMAZON";
        public const string IDENTIFIER_SCHEME_DOI_CODE      = "DOI";
        public const string IDENTIFIER_SCHEME_ISBN_CODE     = "ISBN";
        public const string IDENTIFIER_SCHEME_ISSN_CODE     = "ISSN";
        public const string IDENTIFIER_SCHEME_UUID_CODE     = "UUID";
        public const string IDENTIFIER_SCHEME_BOOKID_CODE   = "bookid";
        public const string GUIDE_REFERENCE_ACKNOWLEDGEMENTS        = "acknowledgements";
        public const string GUIDE_REFERENCE_OTHER_APPENDIX          = "other.appendix";
        public const string GUIDE_REFERENCE_COVER                   = "cover";
        public const string GUIDE_REFERENCE_COLOPHON                = "colophon";
        public const string GUIDE_REFERENCE_OTHER_CONCLUSION        = "other.conclusion";
        public const string GUIDE_REFERENCE_OTHER_CONTRIBUITORS     = "other.contribuitors";
        public const string GUIDE_REFERENCE_DEDICATION              = "dedication";
        public const string GUIDE_REFERENCE_EPIGRAPH                = "epigraph";
        public const string GUIDE_REFERENCE_OTHER_EPILOGUE          = "other.epilogue";
        public const string GUIDE_REFERENCE_OTHER_ERRATA            = "other.errata";
        public const string GUIDE_REFERENCE_OTHER_IMPRINT           = "other.imprint";
        public const string GUIDE_REFERENCE_GLOSSARY                = "glossary";
        public const string GUIDE_REFERENCE_INDEX                   = "index";
        public const string GUIDE_REFERENCE_OTHER_INTRODUCTION      = "other.introduction";
        public const string GUIDE_REFERENCE_OTHER_LOA               = "other.loa";
        public const string GUIDE_REFERENCE_OTHER_LOV               = "other.lov";
        public const string GUIDE_REFERENCE_LOI                     = "loi";
        public const string GUIDE_REFERENCE_LOT                     = "lot";
        public const string GUIDE_REFERENCE_OTHER_BACKMATTER        = "other.backmatter";
        public const string GUIDE_REFERENCE_NOTES                   = "notes";
        public const string GUIDE_REFERENCE_OTHER_REARNOTES         = "other.rearnotes";
        public const string GUIDE_REFERENCE_OTHER_FOOTNOTES         = "other.footnotes";
        public const string GUIDE_REFERENCE_OTHER_CREDITS           = "other.other-credits";
        public const string GUIDE_REFERENCE_COPYRIGHT_PAGE          = "copyright-page";
        public const string GUIDE_REFERENCE_OTHER_HALFTITLEPAGE     = "other.halftitlepage";
        public const string GUIDE_REFERENCE_TITLE_PAGE              = "title-page";
        public const string GUIDE_REFERENCE_OTHER_FRONTMATTER       = "other.frontmatter";
        public const string GUIDE_REFERENCE_OTHER_IMPRIMATUR        = "other.imprimatur";
        public const string GUIDE_REFERENCE_OTHER_AFTERWORD         = "other.afterword";
        public const string GUIDE_REFERENCE_OTHER_PREAMBLE          = "other.preamble";
        public const string GUIDE_REFERENCE_FOREWORD                = "foreword";
        public const string GUIDE_REFERENCE_PREFACE                 = "preface";
        public const string GUIDE_REFERENCE_OTHER_PROLOGUE          = "other.prologue";
        public const string GUIDE_REFERENCE_TOC                     = "toc";
        public const string GUIDE_REFERENCE_TEXT                    = "text";


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
                                    SaveHtmlFile(item.XhtmlContends, Path.Combine(epub.FileName , item.FileTempPath));
                                }
                            }

                        //ZipFile.CreateFromDirectory(epub.TempPath, string.Format("{0}{1}", Path.GetDirectoryName(epub.OriginalPath), sfd.FileName), CompressionLevel.Optimal, false);

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
            string __path = Path.Combine(Path.Combine(AppContext.BaseDirectory, EPUB_XHTML_TEMP_PATH), path.Replace("/", "\\"));
            if (!Directory.Exists(__path))
            {
                try
                {

                    Directory.CreateDirectory(Path.GetDirectoryName(__path));

                }
                catch (Exception)
                {
                    throw new Exception();
                }
            }

            try
            {

                File.WriteAllText(__path, contend);

            }
            catch (Exception)
            {

                throw new Exception();
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

            string[] topicos = { 
                "topico",
                "topicos",
                "topico-abc",
                "topicos-abc",
                "topico-num",
                "topicos-num",
                "topico-abc-vazio",
                "topicos-abc-vazio",
                "topico-rom",
                "topicos-rom" 
            };
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
            List<EpubStyle> styleList = new List<EpubStyle>();
            List<EpubFont> fontList = new List<EpubFont>();
            List<EpubImage> images = new List<EpubImage>();
            List<MiscSettings> miscSettings = new List<MiscSettings>();
            List<TocSettings> tocSettings = new List<TocSettings>();
            Content contentDocument = new Content();


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

                        //Faz a leitura dos arquivos styles.css
                        if (Path.GetExtension(entry.FullName).Equals(".css", StringComparison.OrdinalIgnoreCase))
                        {
                            using (StreamReader reader = new StreamReader(entry.Open()))
                            {

                                styleList.Add(new EpubStyle { 
                                    CssFileName = entry.Name,
                                    FilePath = entry.FullName,
                                    CssFileContent = reader.ReadToEnd(),
                                    HasEdited = false,
                                    FileTempPath = entry.FullName,
                                    OriginalFileHash = GetMd5Hash(reader.ReadToEnd())
                                });

                            }
                        }

                        //Faz a leitura dos arquivos font.ttf / font.otf
                        //.ttf
                        if (Path.GetExtension(entry.FullName).Equals(".ttf", StringComparison.OrdinalIgnoreCase))
                        {

                            using (StreamReader reader = new StreamReader(entry.Open()))
                            {

                                fontList.Add(new EpubFont
                                {
                                    FilePath = entry.FullName,
                                    FontFileName = entry.Name,
                                    EpubFontType = EpubFontType.TrueTypeFont,
                                    HasEdited = false,
                                    OriginalHash = GetMd5Hash(reader.ReadToEnd()),
                                    TempFilePath = entry.FullName,
                                });

                            }

                        }

                        //.otf
                        if (Path.GetExtension(entry.FullName).Equals(".otf", StringComparison.OrdinalIgnoreCase))
                        {

                            using (StreamReader reader = new StreamReader(entry.Open()))
                            {

                                fontList.Add(new EpubFont
                                {
                                    FilePath = entry.FullName,
                                    FontFileName = entry.Name,
                                    EpubFontType = EpubFontType.OpenTypeFont,
                                    HasEdited = false,
                                    OriginalHash = GetMd5Hash(reader.ReadToEnd()),
                                    TempFilePath = entry.FullName,
                                });

                            }

                        }

                        //Faz a leitura das imagens
                        //.png
                        if (Path.GetExtension(entry.FullName).Equals(".png", StringComparison.OrdinalIgnoreCase))
                        {

                            using (StreamReader reader = new StreamReader(entry.Open()))
                            {

                                images.Add(new EpubImage
                                {
                                    FilePath = entry.FullName,
                                    HasEdited = false,
                                    OriginalHash = GetMd5Hash(reader.ReadToEnd()),
                                    TempFilePath = entry.FullName,
                                    FileName = entry.Name,
                                    Imagecontent = Image.FromStream(entry.Open()),
                                });

                            }

                        }

                        //Faz a leitura das imagens
                        //.jpg
                        if (Path.GetExtension(entry.FullName).Equals(".jpg", StringComparison.OrdinalIgnoreCase))
                        {

                            using (StreamReader reader = new StreamReader(entry.Open()))
                            {

                                images.Add(new EpubImage
                                {
                                    FilePath = entry.FullName,
                                    HasEdited = false,
                                    OriginalHash = GetMd5Hash(reader.ReadToEnd()),
                                    TempFilePath = entry.FullName,
                                    FileName = entry.Name,
                                    Imagecontent = Image.FromStream(entry.Open()),
                                });

                            }

                        }

                        //faz a leitura dos arquivos dentro da pasta /misc
                        string teste = Path.GetDirectoryName(entry.FullName);
                        if (Path.GetDirectoryName(entry.FullName).Equals("META-INF", StringComparison.OrdinalIgnoreCase))
                        {
                            using (StreamReader reader = new StreamReader(entry.Open()))
                            {

                                miscSettings.Add(new MiscSettings()
                                {
                                    MiscFileName = entry.Name,
                                    FileContent = reader.ReadToEnd(),
                                    FilePath = entry.FullName,
                                    OriginalHash = GetMd5Hash(reader.ReadToEnd()),
                                    TempFilePath = entry.FullName,
                                    HasEdited = false
                                });

                            }
                        }

                        //faz a leitura do arquivo toc.ncx
                        if (Path.GetExtension(entry.FullName).Equals(".ncx", StringComparison.OrdinalIgnoreCase))
                        {

                            using (StreamReader reader = new StreamReader(entry.Open()))
                            {

                                tocSettings.Add(new TocSettings
                                {
                                    FilePath = entry.FullName,
                                    HasEdited = false,
                                    OriginalHash = GetMd5Hash(reader.ReadToEnd()),
                                    TempFilePath = entry.FullName,
                                    FileName = entry.Name,
                                    FileContent= reader.ReadToEnd()
                                });

                            }

                        }

                        //faz a leitura do content.opf
                        if (Path.GetExtension(entry.FullName).Equals(".opf", StringComparison.OrdinalIgnoreCase))
                        {
                            using (StreamReader reader = new StreamReader(entry.Open()))
                            {

                                string content = reader.ReadToEnd();
                                contentDocument = ReadContentDocumentFromXml(entry.Name, entry.FullName, entry.FullName, content);

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
                        Styles = styleList.ToArray(),
                        Fonts = fontList.ToArray(),
                        Images = images.ToArray(),
                        MiscSettings = miscSettings.ToArray(),
                        TocSettings = tocSettings.ToArray(),
                        Content = contentDocument
                    };

                }

            }

            return null;
        }

        public static Content ReadContentDocumentFromXml(string contentFileName, string filePath, string tempFilePath, string content)
        {
            if(content != null)
            {
                string enconding;
                string version;
                string unique_identifier;
                MetadataDocument metadata;
                Manifest manifest;
                Spine spine;
                Guide guide;

                XmlDocument xdoc = new XmlDocument();
                xdoc.LoadXml(content);

                XmlNamespaceManager nsManager = new XmlNamespaceManager(xdoc.NameTable);
                nsManager.AddNamespace("dc", METADATA_XML_NAMESPACE);
                nsManager.AddNamespace("opf", METADATA_PROPERTY_XML_NAMESPACE);

                Match m = Regex.Match(content, @"encoding=[""'](.+?)[""']");
                if (m.Success)
                    enconding = m.Groups[1].Value;
                else
                    enconding = "error";

                version = xdoc.DocumentElement.GetAttribute("version");
                unique_identifier = xdoc.DocumentElement.GetAttribute("unique-identifier");
                metadata = ReadMetadataFromXml(xdoc);
                manifest = ReadManifestFromXml(xdoc);
                spine = ReadSpineFromXml(xdoc);
                guide = ReadGuideFromXml(xdoc);
                                
                Package package = new Package {
                    Version = version,
                    XmlNamespace = METADATA_XML_NAMESPACE,
                    XmlOpfNamespace = METADATA_PROPERTY_XML_NAMESPACE,
                    Guide = guide,
                    Manifest = manifest,
                    Spine = spine,
                    Metadata = metadata,
                    UniqueIdentifier = unique_identifier
                };

                Content _content = new Content
                {
                    FileName = contentFileName,
                    FilePath = filePath,
                    Enconding = enconding,
                    HasEdited = false,
                    OriginalHash = GetMd5Hash(content),
                    TempFilePath = tempFilePath,
                    Package = package
                };

                return _content;

            }

            return null ;
        }

        public static void PopulateTreeView(System.Windows.Forms.TreeView treeView, EpubFile epubFile)
        {
            treeView.Nodes.Clear();

            ImageList icons = new ImageList();
            icons.Images.Add("folder", Properties.Resources.pasta);
            icons.Images.Add("file", Properties.Resources.html);
            icons.Images.Add("img", Properties.Resources.imagem);
            icons.Images.Add("css", Properties.Resources.css);
            icons.Images.Add("fonte", Properties.Resources.fonte);
            icons.Images.Add("misc", Properties.Resources.ferramentas);
            icons.Images.Add("data", Properties.Resources.arquivo);

            treeView.ImageList = icons;

            // Cria o nó raiz
            TreeNode rootNode = new TreeNode($"EBOOK ({epubFile.FileName})")
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

            // Cria o nó "Text"
            TreeNode textNode = new TreeNode("Text")
            {
                ImageKey = "folder",
                SelectedImageKey = "folder"
            };

            // Cria o nó "Styles"
            TreeNode stylesNode = new TreeNode("Styles")
            {
                ImageKey = "folder",
                SelectedImageKey = "folder"
            };

            // Cria o nó "Images"
            TreeNode imagesNode = new TreeNode("Images")
            {
                ImageKey = "folder",
                SelectedImageKey = "folder"
            };

            // Cria o nó "Images"
            TreeNode fontsNode = new TreeNode("Fonts")
            {
                ImageKey = "folder",
                SelectedImageKey = "folder"
            };

            // Cria o nó "Images"
            TreeNode miscNode = new TreeNode("Misc")
            {
                ImageKey = "folder",
                SelectedImageKey = "folder"
            };

            //faz a leitura dos arquivos .html
            foreach (var xhtmlFile in epubFile.XhtmlFiles)
            {
                TreeNode xhtmlFileNode = new TreeNode(xhtmlFile.FileName)
                {
                    ImageKey = "file",
                    SelectedImageKey= "file",
                    Tag = xhtmlFile
                };

                textNode.Nodes.Add(xhtmlFileNode);

            }

            //faz a leitura dos arquivos .css
            foreach (var cssFile in epubFile.Styles)
            {
                TreeNode cssFileNode = new TreeNode(cssFile.CssFileName)
                {
                    ImageKey = "css",
                    SelectedImageKey = "css",
                    Tag = cssFile
                };

                stylesNode.Nodes.Add(cssFileNode);

            }

            //faz a leitura dos arquivos de imagem
            foreach (var imgFile in epubFile.Images)
            {
                TreeNode imgFileNode = new TreeNode(imgFile.FileName)
                {
                    ImageKey = "img",
                    SelectedImageKey = "img",
                    Tag = imgFile
                };

                imagesNode.Nodes.Add(imgFileNode);

            }

            //faz a leitura dos arquivos de fontes
            foreach (var fontFile in epubFile.Fonts)
            {
                TreeNode fontFileNode = new TreeNode(fontFile.FontFileName)
                {
                    ImageKey = "fonte",
                    SelectedImageKey = "fonte",
                    Tag = fontFile
                };

                fontsNode.Nodes.Add(fontFileNode);

            }

            //faz a leitura dos arquivos de fontes
            foreach (var miscFile in epubFile.MiscSettings)
            {
                TreeNode miscFileNode = new TreeNode(miscFile.MiscFileName)
                {
                    ImageKey = "misc",
                    SelectedImageKey = "misc",
                    Tag = miscFile
                };

                miscNode.Nodes.Add(miscFileNode);

            }

            //Adiciona arquivo .ncx no OEBPS raiz
            if (epubFile.TocSettings != null)
            {
                foreach (var tocFile in epubFile.TocSettings)
                {
                    TreeNode tocFileNode = new TreeNode(tocFile.FileName)
                    {
                        ImageKey = "data",
                        SelectedImageKey = "data",
                        Tag = tocFile
                    };

                    oebpsNode.Nodes.Add(tocFileNode);

                }

            }

            //Adiciona arquivo .opf no OEBPS raiz
            if (epubFile.Content != null)
            {

                TreeNode opfFileNode = new TreeNode(epubFile.Content.FileName)
                {
                    ImageKey = "data",
                    SelectedImageKey = "data",
                    Tag = epubFile.Content
                };

                oebpsNode.Nodes.Add(opfFileNode);

            }

            //Adiciona arquivo .opf no OEBPS raiz
            //var opfFile = epubFile.Metadata.


            oebpsNode.Nodes.Add(textNode);
            oebpsNode.Nodes.Add(stylesNode);
            oebpsNode.Nodes.Add(imagesNode);
            oebpsNode.Nodes.Add(fontsNode);
            oebpsNode.Nodes.Add(miscNode);
            rootNode.Nodes.Add(oebpsNode);

            textNode.Expand();
            oebpsNode.Expand();
            rootNode.Expand();
            treeView.Nodes.Add(rootNode);

            /*

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

            //Adiciona as pastas .xhtml
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
            */
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
                var relation = "";
                var coverage = "";
                var source = "";
                var rights = "";
                var identifier = "";
                List<EpubDateTime> epubDateTime = new List<EpubDateTime>();
                List<Language> languages = new List<Language>();
                List<Identifier> identifiers = new List<Identifier>();
                List<Meta> metas = new List<Meta>();


                title = xmlDocument.SelectSingleNode("//dc:title", nsManager)?.InnerText;
                creator = xmlDocument.SelectSingleNode("//dc:creator", nsManager)?.InnerText;
                subject = xmlDocument.SelectSingleNode("//dc:subject", nsManager)?.InnerText;
                description = xmlDocument.SelectSingleNode("//dc:description", nsManager)?.InnerText;
                publisher = xmlDocument.SelectSingleNode("//dc:publisher", nsManager)?.InnerText;
                relation = xmlDocument.SelectSingleNode("//dc:relation", nsManager)?.InnerText;
                coverage = xmlDocument.SelectSingleNode("//dc:coverage", nsManager)?.InnerText;
                source = xmlDocument.SelectSingleNode("//dc:source", nsManager)?.InnerText;
                rights = xmlDocument.SelectSingleNode("//dc:rights", nsManager)?.InnerText;
                identifier = xmlDocument.SelectSingleNode("//dc:identifier", nsManager)?.InnerText;

                //Faz leitura das tags Date
                XmlNodeList dateNodes = xmlDocument.SelectNodes("//opf:metadata/dc:date", nsManager);
                foreach(XmlNode node in dateNodes)
                {

                    string dateString = node.InnerText?.Trim();
                    DateTime parsedDate;

                    if (DateTime.TryParseExact(dateString, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out parsedDate)) { }
                    else if (DateTime.TryParseExact(dateString, "yyyy", null, System.Globalization.DateTimeStyles.None, out parsedDate)) { }
                    else
                        parsedDate = new DateTime(2000, 1, 1);
                  

                    epubDateTime.Add(new EpubDateTime
                    {

                        Date = parsedDate,
                        DateEvent = EpubDateTime.ConverStringToDateEvent(node.Attributes["opf:event"]?.Value ?? string.Empty)

                    });

                }

                //Faz a leitura das tags lang
                XmlNodeList langNodes = xmlDocument.SelectNodes("//opf:metadata/dc:language", nsManager);
                foreach (XmlNode node in langNodes)
                {
                    languages.Add(ConvertToLanguageEnum(node.InnerText.Trim()));
                }

                //Faz a leitura das tags identifier
                XmlNodeList identifierNodes = xmlDocument.SelectNodes("//opf:metadata/dc:identifier", nsManager);
                foreach (XmlNode node in identifierNodes)
                {

                    if (node.Attributes["id"]?.InnerText == IDENTIFIER_SCHEME_BOOKID_CODE)
                    {
                        identifiers.Add(new Identifier
                        {

                            IdentifierNumber = node.InnerText.Trim(),
                            Scheme = ConvertIdentifierStringToEnum(node.Attributes["id"]?.Value ?? string.Empty),

                        });
                    } else
                    {
                        identifiers.Add(new Identifier
                        {

                            IdentifierNumber = node.InnerText.Trim(),
                            Scheme = ConvertIdentifierStringToEnum(node.Attributes["opf:scheme"]?.Value ?? string.Empty),

                        });
                    }


                }

                //Faz a leitura das tags meta
                XmlNodeList metaNodes = xmlDocument.ChildNodes[1].SelectNodes("/opf:package/opf:metadata/opf:meta", nsManager);

                foreach (XmlNode node in metaNodes)
                {
                  
                    metas.Add(new Meta
                    {
                    
                        Name = node.Attributes["name"]?.Value ?? "",
                        Content = node.Attributes["content"]?.Value ?? ""
                    
                    });

                }

                return new MetadataDocument(title, creator, subject, description, publisher, epubDateTime.ToArray(), source, relation, coverage, rights, languages.ToArray(), identifiers.ToArray(), metas.ToArray());

            }   

            return null;
        }

        public static Manifest ReadManifestFromXml(XmlDocument xmlDocument)
        {

            if (xmlDocument != null)
            {
                XmlNamespaceManager nsManager = new XmlNamespaceManager(xmlDocument.NameTable);
                nsManager.AddNamespace("dc", METADATA_XML_NAMESPACE);
                nsManager.AddNamespace("opf", METADATA_PROPERTY_XML_NAMESPACE);

                Manifest manifest = new Manifest();
                
                XmlNodeList itemManifestNodes = xmlDocument.SelectNodes("/opf:package/opf:manifest/opf:item", nsManager);
                foreach (XmlNode node in itemManifestNodes)
                {

                    manifest.Items.Add(new ManifestItem
                    {
                        ItemId = node.Attributes["id"]?.Value ?? "",
                        ItemHref = node.Attributes["href"]?.Value ?? "",
                        MediaType = node.Attributes["media-type"]?.Value ?? ""
                    });

                }

                return manifest;

            }

            return null;

        }

        public static Spine ReadSpineFromXml(XmlDocument xmlDocument)
        {
            if (xmlDocument != null)
            {
                XmlNamespaceManager nsManager = new XmlNamespaceManager(xmlDocument.NameTable);
                nsManager.AddNamespace("dc", METADATA_XML_NAMESPACE);
                nsManager.AddNamespace("opf", METADATA_PROPERTY_XML_NAMESPACE);

                Spine spine = new Spine();

                XmlNodeList itemSpineNodes = xmlDocument.SelectNodes("/opf:package/opf:spine/opf:itemref", nsManager);
                foreach (XmlNode node in itemSpineNodes)
                {

                    spine.Items.Add(new SpineItem
                    {
                        ItemRefId = node.Attributes["idref"]?.Value ?? "",
                        Linear = node.Attributes["linear"]?.Value?.ToLower() != "no" 
                    });

                }

                return spine;

            }

            return null;

        }

        public static Guide ReadGuideFromXml(XmlDocument xmlDocument)
        {

            if (xmlDocument != null)
            {
                XmlNamespaceManager nsManager = new XmlNamespaceManager(xmlDocument.NameTable);
                nsManager.AddNamespace("dc", METADATA_XML_NAMESPACE);
                nsManager.AddNamespace("opf", METADATA_PROPERTY_XML_NAMESPACE);

                Guide guide = new Guide();

                XmlNodeList itemGuideNodes = xmlDocument.SelectNodes("/opf:package/opf:guide/opf:reference", nsManager);
                foreach (XmlNode node in itemGuideNodes)
                {

                    guide.GuideReferenceItems.Add(new GuideReference
                    {
                        GuideReferenceType = ConvertGuideRefTypeStringToEnum(node.Attributes["type"]?.Value ?? ""),
                        Href = node.Attributes["href"]?.Value ?? "",
                        Title = node.Attributes["title"]?.Value ?? "",
                    });

                }

                return guide;
            }

            return null;
        }

        public static GuideReferenceType ConvertGuideRefTypeStringToEnum(string input)
        {
            if (input != null)
            {
                switch (input)
                {
                    case GUIDE_REFERENCE_ACKNOWLEDGEMENTS: return GuideReferenceType.ACKNOWLEDGEMENTS;
                    case GUIDE_REFERENCE_OTHER_APPENDIX: return GuideReferenceType.OTHER_APPENDIX;
                    case GUIDE_REFERENCE_COVER: return GuideReferenceType.COVER;
                    case GUIDE_REFERENCE_COLOPHON: return GuideReferenceType.COLOPHON;
                    case GUIDE_REFERENCE_OTHER_CONCLUSION: return GuideReferenceType.OTHER_CONCLUSION;
                    case GUIDE_REFERENCE_OTHER_CONTRIBUITORS: return GuideReferenceType.OTHER_CONTRIBUITORS;
                    case GUIDE_REFERENCE_DEDICATION: return GuideReferenceType.DEDICATION;
                    case GUIDE_REFERENCE_EPIGRAPH: return GuideReferenceType.EPIGRAPH;
                    case GUIDE_REFERENCE_OTHER_EPILOGUE: return GuideReferenceType.OTHER_EPILOGUE;
                    case GUIDE_REFERENCE_OTHER_ERRATA: return GuideReferenceType.OTHER_ERRATA;
                    case GUIDE_REFERENCE_OTHER_IMPRINT: return GuideReferenceType.OTHER_IMPRINT;
                    case GUIDE_REFERENCE_GLOSSARY: return GuideReferenceType.GLOSSARY;
                    case GUIDE_REFERENCE_INDEX: return GuideReferenceType.INDEX;
                    case GUIDE_REFERENCE_OTHER_INTRODUCTION: return GuideReferenceType.OTHER_INTRODUCTION;
                    case GUIDE_REFERENCE_OTHER_LOA: return GuideReferenceType.OTHER_LOA;
                    case GUIDE_REFERENCE_OTHER_LOV: return GuideReferenceType.OTHER_LOV;
                    case GUIDE_REFERENCE_LOI: return GuideReferenceType.LOI;
                    case GUIDE_REFERENCE_LOT: return GuideReferenceType.LOT;
                    case GUIDE_REFERENCE_OTHER_BACKMATTER: return GuideReferenceType.OTHER_BACKMATTER;
                    case GUIDE_REFERENCE_NOTES: return GuideReferenceType.NOTES;
                    case GUIDE_REFERENCE_OTHER_REARNOTES: return GuideReferenceType.OTHER_REARNOTES;
                    case GUIDE_REFERENCE_OTHER_FOOTNOTES: return GuideReferenceType.OTHER_FOOTNOTES;
                    case GUIDE_REFERENCE_OTHER_CREDITS: return GuideReferenceType.OTHER_CREDITS;
                    case GUIDE_REFERENCE_COPYRIGHT_PAGE: return GuideReferenceType.COPYRIGHT_PAGE;
                    case GUIDE_REFERENCE_OTHER_HALFTITLEPAGE: return GuideReferenceType.OTHER_HALFTITLEPAGE;
                    case GUIDE_REFERENCE_TITLE_PAGE: return GuideReferenceType.TITLE_PAGE;
                    case GUIDE_REFERENCE_OTHER_FRONTMATTER: return GuideReferenceType.OTHER_FRONTMATTER;
                    case GUIDE_REFERENCE_OTHER_IMPRIMATUR: return GuideReferenceType.OTHER_IMPRIMATUR;
                    case GUIDE_REFERENCE_OTHER_AFTERWORD: return GuideReferenceType.OTHER_AFTERWORD;
                    case GUIDE_REFERENCE_OTHER_PREAMBLE: return GuideReferenceType.OTHER_PREAMBLE;
                    case GUIDE_REFERENCE_FOREWORD: return GuideReferenceType.FOREWORD;
                    case GUIDE_REFERENCE_PREFACE: return GuideReferenceType.PREFACE;
                    case GUIDE_REFERENCE_OTHER_PROLOGUE: return GuideReferenceType.OTHER_PROLOGUE;
                    case GUIDE_REFERENCE_TOC: return GuideReferenceType.TOC;
                    case GUIDE_REFERENCE_TEXT: return GuideReferenceType.TEXT;
                    default: return GuideReferenceType.UNKNOWN;
                }
            }

            return GuideReferenceType.UNKNOWN;

        }

        public static IdentifierScheme ConvertIdentifierStringToEnum(string input)
        {
            if (input != null)
            {
                switch (input)
                {
                    case IDENTIFIER_SCHEME_AMAZON_CODE: return IdentifierScheme.AMAZON;
                    case IDENTIFIER_SCHEME_DOI_CODE: return IdentifierScheme.DOI;
                    case IDENTIFIER_SCHEME_ISBN_CODE: return IdentifierScheme.ISBN;
                    case IDENTIFIER_SCHEME_ISSN_CODE: return IdentifierScheme.ISSN;
                    case IDENTIFIER_SCHEME_UUID_CODE: return IdentifierScheme.UUID;
                    case IDENTIFIER_SCHEME_BOOKID_CODE: return IdentifierScheme.BOOK_ID;
                    default: return IdentifierScheme.CUSTOM;
                }
            }
            return IdentifierScheme.CUSTOM;
        }

        public static Language ConvertToLanguageEnum(string langCode)
        {
            switch (langCode)
            {
                // English
                case EN_US_LANG: return Language.EN_US;
                case EN_GB_LANG: return Language.EN_GB;
                case EN_AU_LANG: return Language.EN_AU;
                case EN_CA_LANG: return Language.EN_CA;
                case EN_IN_LANG: return Language.EN_IN;

                // Spanish
                case ES_ES_LANG: return Language.ES_ES;
                case ES_MX_LANG: return Language.ES_MX;
                case ES_AR_LANG: return Language.ES_AR;
                case ES_CO_LANG: return Language.ES_CO;
                case ES_US_LANG: return Language.ES_US;

                // French
                case FR_FR_LANG: return Language.FR_FR;
                case FR_CA_LANG: return Language.FR_CA;
                case FR_BE_LANG: return Language.FR_BE;

                // Portuguese
                case PT_PT_LANG: return Language.PT_PT;
                case PT_BR_LANG: return Language.PT_BR;

                // German
                case DE_DE_LANG: return Language.DE_DE;
                case DE_AT_LANG: return Language.DE_AT;
                case DE_CH_LANG: return Language.DE_CH;

                // Chinese
                case ZH_CN_LANG: return Language.ZH_CN;
                case ZH_TW_LANG: return Language.ZH_TW;
                case ZH_HK_LANG: return Language.ZH_HK;

                // Japanese
                case JA_JP_LANG: return Language.JA_JP;

                // Korean
                case KO_KR_LANG: return Language.KO_KR;

                // Russian
                case RU_RU_LANG: return Language.RU_RU;

                // Italian
                case IT_IT_LANG: return Language.IT_IT;

                // Arabic
                case AR_SA_LANG: return Language.AR_SA;
                case AR_AE_LANG: return Language.AR_AE;

                // Hindi
                case HI_IN_LANG: return Language.HI_IN;

                // Others
                case NL_NL_LANG: return Language.NL_NL;
                case SV_SE_LANG: return Language.SV_SE;
                case DA_DK_LANG: return Language.DA_DK;
                case NO_NO_LANG: return Language.NO_NO;
                case FI_FI_LANG: return Language.FI_FI;
                case TR_TR_LANG: return Language.TR_TR;
                case PL_PL_LANG: return Language.PL_PL;
                case HE_IL_LANG: return Language.HE_IL;
                case TH_TH_LANG: return Language.TH_TH;

                // Valor padrão para não reconhecidos
                default: return Language.UNKNOWN;
            }
        }

        public static int ExportXhtmlArrayDataFilesToFolder(string folder, XhtmlFile[] xhtmlFiles)
        { 
        
            if(Directory.Exists(folder))
            {

                foreach (XhtmlFile xf in xhtmlFiles)
                {

                    string fileName = xf.FileName;
                    if (Path.GetExtension(fileName) == ".xhtml")
                    {
                        FileStream fs = new FileStream( $"{folder}\\{fileName}", FileMode.CreateNew, FileAccess.Write, FileShare.Read);
                        using (StreamWriter sw = new StreamWriter(fs))
                        {
                            sw.Write(xf.XhtmlContends);
                            sw.Close();
                        }

                        fs.Close();
                    }

                }

                return 0;

            }

            return -1;

        }

        public static int ExportToNewEpubDocument(EpubFile epub)
        {

            if (epub != null)
            {
                
                
                
                XmlDocument xmlDocument = new XmlDocument();
                


            }

            return -1;

        }
    }
}