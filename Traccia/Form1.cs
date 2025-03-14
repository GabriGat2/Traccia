using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Traccia
{
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Avvia la dialog per l'archiviazione di una escursione
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butArchiviaEscursione_Click(object sender, EventArgs e)
        {
            FormArchiviaEscursione dlg = new FormArchiviaEscursione();
            dlg.ShowDialog();
        }



    }
}
