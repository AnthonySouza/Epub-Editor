using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using HtmlAgilityPack;

namespace Epub_Editor
{
    public partial class FormCleanHtml : Form
    {
        public FormCleanHtml()
        {
            InitializeComponent();
        }
        public static void HighlightHtmlSyntax(RichTextBox richTextBox)
        {
            if (richTextBox == null) return;

            // Save the current caret position and disable updates to prevent flickering
            int currentSelectionStart = richTextBox.SelectionStart;
            int currentSelectionLength = richTextBox.SelectionLength;
            richTextBox.SuspendLayout();

            // Reset formatting
            richTextBox.SelectAll();
            richTextBox.SelectionColor = Color.Black;

            // Regex for HTML tags
            string tagPattern = "<(/?\\w+)([^>]*)>";

            // Regex for attributes within a tag
            string attributePattern = "(\\w+)=\\\"(.*?)\\\"";

            foreach (Match tagMatch in Regex.Matches(richTextBox.Text, tagPattern))
            {
                // Highlight the tag name
                richTextBox.Select(tagMatch.Index, tagMatch.Length);
                richTextBox.SelectionColor = Color.Blue;

                // Find attributes within the tag and highlight them
                foreach (Match attrMatch in Regex.Matches(tagMatch.Value, attributePattern))
                {
                    int attrIndex = tagMatch.Index + attrMatch.Index;

                    // Highlight attribute name
                    richTextBox.Select(attrIndex, attrMatch.Groups[1].Length);
                    richTextBox.SelectionColor = Color.Brown;

                    // Highlight attribute value
                    int valueStart = attrIndex + attrMatch.Groups[1].Length + 1; // +1 for the '=' character
                    richTextBox.Select(valueStart, attrMatch.Groups[2].Length + 2); // +2 for the surrounding quotes
                    richTextBox.SelectionColor = Color.DarkRed;
                }
            }

            // Restore the original caret position and re-enable updates
            richTextBox.Select(currentSelectionStart, currentSelectionLength);
            richTextBox.ResumeLayout();
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

            string[] topicos = {"topico", "topicos", "topico-abc", "topicos-abc", "topico-num", "topicos-num"};    
            bool insideCitationBlock = false;
            HtmlNode brBefore = null, brAfter = null;

            foreach (var paragraph in paragraphs)
            {

                foreach (var topic in topicos)
                {
                    bool isCitation = paragraph.GetAttributeValue("class", "").Equals(topic);

                    if (isCitation)
                    {
                        // Estamos no início de um bloco de topico
                        if (!insideCitationBlock)
                        {
                            // Adicionar <br/> antes do primeiro bloco
                            brBefore = HtmlNode.CreateNode("<br/>");
                            paragraph.ParentNode.InsertBefore(brBefore, paragraph);
                            insideCitationBlock = true;
                        }
                    }
                    else
                    {
                        // Se estávamos em um bloco de topico, mas saímos
                        if (insideCitationBlock)
                        {
                            // Adicionar <br/> após o último bloco
                            brAfter = HtmlNode.CreateNode("<br/>");
                            paragraph.ParentNode.InsertBefore(brAfter, paragraph);
                            insideCitationBlock = false;
                        }
                    }
                }
                
            }

            // Caso todo o HTML termine com um bloco de topico, garantir que <br/> seja adicionado no final
            if (insideCitationBlock && brAfter == null)
            {
                brAfter = HtmlNode.CreateNode("<br/>");
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


        public static string CleanCode(
            string html, 
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
            bool resetNumChars)
        {
            
            HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
            document.LoadHtml(html);

            int totalSteps = 10;
            int currentStep = 0;

            progressBar.Value = 0;
            progressBar.Maximum = totalSteps;

            if (remCharOverrideCkb)
            {
                html = RemoveCharOverride(document);
                progressBar.Value = ++currentStep;
            }

            if (remParaOverrideCkb)
            {
                html = RemoveParaOverride(document);
                progressBar.Value = ++currentStep;
            }

            if (remGenCharOverrideCkb)
            {
                html = RemoveIdGenCharOverride(document);
                progressBar.Value = ++currentStep;
            }

            if (remObjStyleOverrideCkb)
            {
                html = RemoveIdGenObjectStyleOverride(document);
                progressBar.Value = ++currentStep;
            }

            if (insertBrTagCit)
            {
                html = AddBrAroundCitationBlocks(document);
                progressBar.Value = ++currentStep;
            }

            if (insertBrTagTop)
            {
                html = AddBrAroundTopicBlocks(document);
                progressBar.Value = ++currentStep;
            }

            if (insertStFootnote)
            {
                html = AddStToFooterLinks(document);
                progressBar.Value = ++currentStep;
            }
            
            if (remLangAttrib)
            {
                html = RemoveLangAndXmlLangAttributes(document);
                progressBar.Value = ++currentStep;
            }
            
            if (resetNumChars)
            {
                html = ReplaceArabicNumbers(document);
                progressBar.Value = ++currentStep;
            }

            if (remEmptySpanCkb)
            {
                html = RemoveEmptySpan(document);
                progressBar.Value = ++currentStep;
            }

            progressBar.Value = totalSteps;
            return html;

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

        private string FindTagAtPosition(int charIndex, RichTextBox rtb)
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

        private void HighlightMatchingTags(string tagName, RichTextBox rtb)
        {
            // Marca todas as tags de abertura e fechamento com o mesmo nome de tag
            string tagPattern = $@"<(/?{tagName}[^>]*)>";
            var matches = Regex.Matches(rtb.Text, tagPattern);

            // Definindo a cor de destaque
            Color highlightColor = Color.Yellow;

            foreach (Match match in matches)
            {
                rtb.Select(match.Index, match.Length);
                rtb.SelectionBackColor = highlightColor; // Marca a tag
            }

            // Restaura a seleção original
            rtb.DeselectAll();
        }


        private void input_TextChanged(object sender, EventArgs e)
        {
            HighlightHtmlSyntax(input);
        }

        private void cleanCodeBtn_Click(object sender, EventArgs e)
        {
            output.Text = "";
            output.Text = CleanCode(
                input.Text, 
                toolStripProgressBar, 
                remCharOverrideCkb.Checked, 
                remParaOverrideCkb.Checked, 
                remEmptySpanCkb.Checked, 
                remGenCharOverrideCkb.Checked, 
                remObjStyleOverrideCkb.Checked,
                insertBrTagCit.Checked,
                insertBrTagTop.Checked,
                insertStFootnote.Checked,
                remLangAttrib.Checked,
                resetNumChars.Checked
                );
            HighlightHtmlSyntax(output);
        }

        private void output_MouseClick(object sender, MouseEventArgs e)
        {
            /*
            // Obtém a posição do mouse no RichTextBox
            int charIndex = output.GetCharIndexFromPosition(e.Location);

            // Encontra a tag que o mouse clicou
            string clickedTag = FindTagAtPosition(charIndex, output);

            if (clickedTag != null)
            {
                // Agora localiza a tag de abertura e a de fechamento
                HighlightMatchingTags(clickedTag, output);
            }
            */
        }
    }
}