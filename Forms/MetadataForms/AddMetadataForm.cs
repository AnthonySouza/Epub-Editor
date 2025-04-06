using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using EpubEditor.Editor;
using EpubEditor.Epub.Metadata;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Epub_Editor.Forms.MetadataForms
{
    public partial class AddMetadataForm : Form
    {

        public event Action<MetadataItem> SendMetadataItem;
        
        private MetadataItem selectedMetadataItem;

        public AddMetadataForm()
        {
            InitializeComponent();
        }

        private void AddMetadataForm_Load(object sender, EventArgs e)
        {

            foreach (var metadataItem in Metadata.MetadataItem)
            {
                                
                AdvancedMetadataListViewItem item = new AdvancedMetadataListViewItem() {
                    MetadataItem = metadataItem,
                    Text = metadataItem.Name,
                    ToolTipText = metadataItem.Info
                };

                lstMetadataItems.Items.Add(item);

            }

        }

        private void lstMetadataItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verifica se o sender é um ListView
            if (sender is System.Windows.Forms.ListView listView)
            {
                // Verifica se há itens selecionados
                if (listView.SelectedItems.Count > 0)
                {
                    // Atualiza o texto do label com o ToolTipText do primeiro item selecionado
                    lblInfo.Text = listView.SelectedItems[0].ToolTipText;
                    selectedMetadataItem = ((AdvancedMetadataListViewItem)listView.SelectedItems[0]).MetadataItem;
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
            if (lstMetadataItems.SelectedItems.Count > 0)
            {
                SendMetadataItem?.Invoke(selectedMetadataItem);
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
