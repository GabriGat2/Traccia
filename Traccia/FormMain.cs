using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Traccia
{
    public partial class FormMain: Form
    {
        /// <summary>
        /// Organizzazione Ambienti
        /// 
        /// Area Archivio Escursioni
        ///     Tipo
        ///     Stato
        ///     Path
        ///     Nome
        ///     Colore
        /// 
        /// Archivio Escursione
        ///     Tipo
        ///     Stato
        ///     Path
        ///     Nome
        ///     Colore
        ///  
        /// Archivio traccia
        ///     Tipo
        ///     Stato
        ///     Path
        ///     Nome
        ///     Colore
        /// 
        /// 
        /// 
        /// 
        /// </summary>
        int pippo;
        

        /// <summary>
        /// Area Archivio
        /// </summary>
        public CAreaArchivio AreaArchivio = new CAreaArchivio();
        /// <summary>
        /// Archivio Escursione
        /// </summary>
        public CArchivioEscursione ArchivioEscursione = new CArchivioEscursione();
        /// <summary>
        /// Costruttore
        /// </summary>
        public FormMain()
        {
            InitializeComponent();


            // Verifica Area Archivio
            AreaArchivio.PathBase = "D:\\Angelo\\Prj\\Traccia\\ArchiviazioneTraccia";
            AreaArchivio.Nome = "ArchivioEscursioni";
            MostraAreaArchivio();
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
            // verifica l'esistenza dell'Area Archivo
            if (! AreaArchivio.StatoOk())
            {
                GstErrori.StampaMessaggioErrore(GstErrori.EErrore.E1303_PathAreaArchivioErrata, AreaArchivio.Path);
                return;
            }

            FormCreaArchivio dlg = new FormCreaArchivio(AreaArchivio.Path);
            dlg.ShowDialog();
        }
        /// <summary>
        /// Crea l'Area Archivio
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butCreaAreaArchivio_Click(object sender, EventArgs e)
        {
            FormCreaAreaArchivio dlg = new FormCreaAreaArchivio(); 
            dlg.ShowDialog();

            // estra il path dell'area archivio
            string path = dlg.ArchivioPath;

            // verifica se la directory esiste
            VerificaAreaArchivio(path);
        }
        /// <summary>
        /// Seleziona Area Archivio
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butSelezionaAreaArchivio_Click(object sender, EventArgs e)
        {
            string path = string.Empty;

            // seleziona la direcory base
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                path = dlg.SelectedPath;
            }

            // verifica se la directory esiste
            VerificaAreaArchivio(path);

        }
        /// <summary>
        /// Verifica se il path dell'area archivio è corretta
        /// </summary>
        /// <param name="pathAreaArchivio"></param>
        void VerificaAreaArchivio(string pathAreaArchivio)
        {
            // pubblica lo stato di Area Archivio
            MostraAreaArchivio();
        }
        /// <summary>
        /// Mostra le informazioni sul Area Archivio
        /// </summary>
        private void MostraAreaArchivio()
        {
            textBoxNomeAreaArchivio.Text = AreaArchivio.Nome;
            textBoxPathAreaArchivio.Text = AreaArchivio.Path;

            textBoxNomeAreaArchivio.BackColor = AreaArchivio.Colore;
            textBoxPathAreaArchivio.BackColor = AreaArchivio.Colore;
         }
        /// <summary>
        /// Apre la dialog per l'archiviazione di una traccia
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butArchiviaTraccia_Click(object sender, EventArgs e)
        {
            // verifica l'esistenza dell'Area Archivo
            if (!ArchivioEscursione.StatoOk())
            {
                GstErrori.StampaMessaggioErrore(GstErrori.EErrore.E1303_PathAreaArchivioErrata, ArchivioEscursione.Path);
                return;
            }

            FormArchivaTraccia dlg = new FormArchivaTraccia(ArchivioEscursione.Path);  
            dlg.ShowDialog();
        }

    }
}
