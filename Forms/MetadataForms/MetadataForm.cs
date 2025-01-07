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
        public MetadataForm()
        {
            InitializeComponent();
        }

        private void btnAddMetadata_Click(object sender, EventArgs e)
        {
            
            AddMetadataForm addMetadataForm = new AddMetadataForm();

            addMetadataForm.SendMetadataItem += AddMetadataForm_SendProperty;

            addMetadataForm.ShowDialog();

        }

        private void AddMetadataForm_SendProperty(AppCore.MetadataItem obj)
        {
            MessageBox.Show(obj.Info);
        }
    }
}
