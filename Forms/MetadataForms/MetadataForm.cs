﻿using Epub_Editor.Forms.MetadataForms;
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

namespace EpubEditor.Forms.MetadataForms
{
    public partial class MetadataForm : Form
    {

        //variaveis
        private MetadataDocument _metadataDocument;

        //eventos
        public event Action<MetadataDocument> MetadataOPFChangedEvent;

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

        private void AddMetadataForm_SendProperty(MetadataItem obj)
        {
            MessageBox.Show(obj.Info);
        }

        private void btnAddProperty_Click(object sender, EventArgs e)
        {
            AddMetadataPropertyForm addMetadataPropertyForm = new AddMetadataPropertyForm();

            addMetadataPropertyForm.SendMetadataProperty += AddMetadataPropertyForm_SendMetadataProperty;

            addMetadataPropertyForm.ShowDialog(this);
        }

        private void AddMetadataPropertyForm_SendMetadataProperty(MetadataProperty obj)
        {
            MessageBox.Show(obj.Info);
        }

        public MetadataDocument MetadataDocument { get => _metadataDocument; set => _metadataDocument = value; }

        private void MetadataForm_Load(object sender, EventArgs e)
        {
            
        }
    }
}
