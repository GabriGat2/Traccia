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
    public partial class FormMain: Form
    {
        public FormMain()
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
        /// <summary>
        /// Crea un archivio
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butCreaArchivio_Click(object sender, EventArgs e)
        {
            FormCreaArchivio dlg = new FormCreaArchivio();
            dlg.ShowDialog();
        }
    }
}
