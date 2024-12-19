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
using Epub_Editor.Core;

namespace Epub_Editor
{
    public partial class FormCleanHtml : Form
    {

        private EpubEditorMainForm mForm;

        public FormCleanHtml(EpubEditorMainForm mainForm)
        {
            InitializeComponent();
            mForm = mainForm;
            //mForm.EpubFile
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
                html = Core.Core.RemoveCharOverride(document);
                progressBar.Value = ++currentStep;
            }

            if (remParaOverrideCkb)
            {
                html = Core.Core.RemoveParaOverride(document);
                progressBar.Value = ++currentStep;
            }

            if (remGenCharOverrideCkb)
            {
                html = Core.Core.RemoveIdGenCharOverride(document);
                progressBar.Value = ++currentStep;
            }

            if (remObjStyleOverrideCkb)
            {
                html = Core.Core.RemoveIdGenObjectStyleOverride(document);
                progressBar.Value = ++currentStep;
            }

            if (insertBrTagCit)
            {
                html = Core.Core.AddBrAroundCitationBlocks(document);
                progressBar.Value = ++currentStep;
            }

            if (insertBrTagTop)
            {
                html = Core.Core.AddBrAroundTopicBlocks(document);
                progressBar.Value = ++currentStep;
            }

            if (insertStFootnote)
            {
                html = Core.Core.AddStToFooterLinks(document);
                progressBar.Value = ++currentStep;
            }
            
            if (remLangAttrib)
            {
                html = Core.Core.RemoveLangAndXmlLangAttributes(document);
                progressBar.Value = ++currentStep;
            }
            
            if (resetNumChars)
            {
                html = Core.Core.ReplaceArabicNumbers(document);
                progressBar.Value = ++currentStep;
            }

            if (remEmptySpanCkb)
            {
                html = Core.Core.RemoveEmptySpan(document);
                progressBar.Value = ++currentStep;
            }

            progressBar.Value = totalSteps;
            return html;

        }

        private void cleanCodeBtn_Click(object sender, EventArgs e)
        {
            Core.Core.CleanAllXhtmlFiles(
                mForm.EpubFile, 
                null, 
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
        }
    }
}