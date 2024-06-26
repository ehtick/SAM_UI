﻿using SAM.Geometry.Mollier;
using System;
using System.Windows.Forms;

namespace SAM.Core.Mollier.UI.Forms
{
    public partial class UIMollierProcessForm_Limited : Form
    {
        public UIMollierProcessForm_Limited()
        {
            InitializeComponent();
        }
        public UIMollierProcessForm_Limited(UIMollierProcess uIMollierProcess)
        {
            InitializeComponent();
            if(uIMollierProcess == null)
            {
                return;
            }
            customizeProcessControl.UIMollierProcess = uIMollierProcess;
        }
        
        public UIMollierProcess UIMollierProcess
        {
            get
            {
                return customizeProcessControl.UIMollierProcess;
            }
            set
            {
                customizeProcessControl.UIMollierProcess = value;
            }
        }
        private void OK_Button_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
