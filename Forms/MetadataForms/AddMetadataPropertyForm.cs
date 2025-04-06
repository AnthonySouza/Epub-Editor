using EpubEditor.Editor;
using EpubEditor.Epub.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Epub_Editor.Forms.MetadataForms
{
    public partial class AddMetadataPropertyForm : Form
    {

        public event Action<MetadataProperty> SendMetadataProperty;

        private MetadataProperty selectedMetadataProperty;

        public AddMetadataPropertyForm()
        {
            InitializeComponent();
        }

        private void AddMetadataPropertyForm_Load(object sender, EventArgs e)
        {

            foreach (var metadataProp in Metadata.MetadataProperty)
            {

                AdvancedMetadataListViewItem item = new AdvancedMetadataListViewItem()
                {
                    MetadataProperty = metadataProp,
                    Text = metadataProp.Name,
                    ToolTipText = metadataProp.Info
                };

                lstPropertyItems.Items.Add(item);

            }

        }

        private void lstPropertyItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verifica se o sender é um ListView
            if (sender is ListView listView)
            {
                // Verifica se há itens selecionados
                if (listView.SelectedItems.Count > 0)
                {
                    // Atualiza o texto do label com o ToolTipText do primeiro item selecionado
                    lblInfo.Text = listView.SelectedItems[0].ToolTipText;
                    selectedMetadataProperty = ((AdvancedMetadataListViewItem)listView.SelectedItems[0]).MetadataProperty;
                    btnSave.Enabled = true;
                }
                else
                {
                    // Limpa o texto do label caso não haja itens selecionados
                    lblInfo.Text = "";
                    btnSave.Enabled = false;
                }
            }
            else
            {
                throw new InvalidCastException("ERRO INTERNO");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Verifica se há itens selecionados
            if (lstPropertyItems.SelectedItems.Count > 0)
            {
                SendMetadataProperty?.Invoke(selectedMetadataProperty);
                Close();
            }
            else
            {
                return;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
