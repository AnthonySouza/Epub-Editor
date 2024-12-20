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
using Epub_Editor.AppCore;

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
                html = Core.RemoveCharOverride(document);
                progressBar.Value = ++currentStep;
            }

            if (remParaOverrideCkb)
            {
                html = Core.RemoveParaOverride(document);
                progressBar.Value = ++currentStep;
            }

            if (remGenCharOverrideCkb)
            {
                html = Core.RemoveIdGenCharOverride(document);
                progressBar.Value = ++currentStep;
            }

            if (remObjStyleOverrideCkb)
            {
                html = Core.RemoveIdGenObjectStyleOverride(document);
                progressBar.Value = ++currentStep;
            }

            if (insertBrTagCit)
            {
                html = Core.AddBrAroundCitationBlocks(document);
                progressBar.Value = ++currentStep;
            }

            if (insertBrTagTop)
            {
                html = Core.AddBrAroundTopicBlocks(document);
                progressBar.Value = ++currentStep;
            }

            if (insertStFootnote)
            {
                html = Core.AddStToFooterLinks(document);
                progressBar.Value = ++currentStep;
            }
            
            if (remLangAttrib)
            {
                html = Core.RemoveLangAndXmlLangAttributes(document);
                progressBar.Value = ++currentStep;
            }
            
            if (resetNumChars)
            {
                html = Core.ReplaceArabicNumbers(document);
                progressBar.Value = ++currentStep;
            }

            if (remEmptySpanCkb)
            {
                html = Core.RemoveEmptySpan(document);
                progressBar.Value = ++currentStep;
            }

            progressBar.Value = totalSteps;
            return html;

        }

        private void cleanCodeBtn_Click(object sender, EventArgs e)
        {

            remCharOverrideCkb.Enabled = false;
            remParaOverrideCkb.Enabled = false;
            remEmptySpanCkb.Enabled = false;
            remGenCharOverrideCkb.Enabled = false;
            remObjStyleOverrideCkb.Enabled = false;
            insertBrTagCit.Enabled = false;
            insertBrTagTop.Enabled = false;
            insertStFootnote.Enabled = false;
            remLangAttrib.Enabled = false;
            resetNumChars.Enabled = false;
            cleanCodeBtn.Enabled = false;
            cancelBtn.Enabled = false;


            Core.CleanAllXhtmlFiles(
                mForm.EpubFile, 
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

            remCharOverrideCkb.Enabled = true;
            remParaOverrideCkb.Enabled = true;
            remEmptySpanCkb.Enabled = true;
            remGenCharOverrideCkb.Enabled = true;
            remObjStyleOverrideCkb.Enabled = true;
            insertBrTagCit.Enabled = true;
            insertBrTagTop.Enabled = true;
            insertStFootnote.Enabled = true;
            remLangAttrib.Enabled = true;
            resetNumChars.Enabled = true;
            cleanCodeBtn.Enabled = true;
            cancelBtn.Enabled = true;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormCleanHtml_Load(object sender, EventArgs e)
        {
            if(mForm.EpubFile == null)
            {
                cleanCodeBtn.Enabled=false;
            }
        }
    }
}