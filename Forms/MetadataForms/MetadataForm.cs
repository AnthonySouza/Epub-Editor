using Epub_Editor.AppCore;
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
    public partial class MetadataForm : Form
    {

        private MetadataDocument _metadataDocument;

        public MetadataForm()
        {
            InitializeComponent();
        }

        public void ShowDialog(MetadataDocument metadata)
        {

            if (metadata != null)
            {
                MetadataDocument = metadata;
                Show();
            }
            
        }

        private void btnAddMetadata_Click(object sender, EventArgs e)
        {
            
            AddMetadataForm addMetadataForm = new AddMetadataForm();

            addMetadataForm.SendMetadataItem += AddMetadataForm_SendProperty;

            addMetadataForm.ShowDialog(this);

        }

        private void AddMetadataForm_SendProperty(AppCore.MetadataItem obj)
        {
            MessageBox.Show(obj.Info);
        }

        private void btnAddProperty_Click(object sender, EventArgs e)
        {
            AddMetadataPropertyForm addMetadataPropertyForm = new AddMetadataPropertyForm();

            addMetadataPropertyForm.SendMetadataProperty += AddMetadataPropertyForm_SendMetadataProperty;

            addMetadataPropertyForm.ShowDialog(this);
        }

        private void AddMetadataPropertyForm_SendMetadataProperty(AppCore.MetadataProperty obj)
        {
            MessageBox.Show(obj.Info);
        }

        public MetadataDocument MetadataDocument { get => _metadataDocument; set => _metadataDocument = value; }
    }
}
