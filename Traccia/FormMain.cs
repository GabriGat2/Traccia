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
    public partial class FormMain : Form
    {
        /// <summary>
        /// Area Archivio
        /// </summary>
        public CAreaArchivio AreaArchivio = null;
        /// <summary>
        /// Archivio Escursione
        /// </summary>
        public CArchivioEscursione Escursione = null;
        /// <summary>
        /// Archivio Traccia
        /// </summary>
        public CArchivioTraccia Traccia = null;

        /// <summary>
        /// Costruttore
        /// </summary>
        public FormMain()
        {
            InitializeComponent();
            InizializzaClasse();

            // Verifica Area Archivio
            AreaArchivio.PathBase = "";// "D:\\Angelo\\Prj\\Traccia\\ArchiviazioneTraccia";
            AreaArchivio.Nome = "ArchivioEscursioni";
            MostraAreaArchivio();
        }
        /// <summary>
        /// Inizializza classe
        /// </summary>
        private void InizializzaClasse()
        {
            // Crea la classe AreaArchivio
            AreaArchivio = new CAreaArchivio();

            // Crea la classe Escursione
            Escursione = new CArchivioEscursione();

            // Assegna AreaArchivio
            Escursione.AreaArchivio = AreaArchivio;

            // Crea la classe Traccia
            Traccia = new CArchivioTraccia();

            // Assegna Archivio Escursione
            Traccia.Escursione = Escursione;
        }
        /// <summary>
        /// Avvia la dialog per l'archiviazione di una escursione
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butArchiviaEscursione_Click(object sender, EventArgs e)
        {
            //FormArchiviaEscursione dlg = new FormArchiviaEscursione();
            //dlg.ShowDialog();
        }
        /// <summary>
        /// Crea un archivio
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butCreaArchivio_Click(object sender, EventArgs e)
        {
            // Controlla c'è un escursione impostata
            if (Escursione.StatoOk())
            {
                // Chiede se deve continuare
                if (!GstErrori.StampaMessaggioAvviso
                        (
                            GstErrori.EErrore.E1324_EscursionePresente,
                            "Una escursione è il elaborazione, vuoi terminare l'elaborazione?"
                        )
                    )
                    return;
            }

            // Ripulisce l'Escursione
            Escursione.ClearNome();

            // Apre il form 
            OpenArchivioEscursione();
        }
        /// <summary>
        /// Apre il form Archivio escursione
        /// </summary>
        private void OpenArchivioEscursione()
        {
            Escursione.AreaArchivio = AreaArchivio;

            // verifica l'esistenza dell'Area Archivo
            if (!Escursione.AreaArchivio.StatoOk())
            {
                GstErrori.StampaMessaggioErrore(GstErrori.EErrore.E1311_PathAreaArchivioErrata, Escursione.AreaArchivio.Path);
                return;
            }

            FormArchivioEscursione dlg = new FormArchivioEscursione(ref Traccia);
            dlg.ShowDialog();
        }
        /// <summary>
        /// Crea l'Area Archivio
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butCreaAreaArchivio_Click(object sender, EventArgs e)
        {
            FormAreaArchivio dlg = new FormAreaArchivio(ref AreaArchivio);
            dlg.ShowDialog();

            // verifica se la directory esiste
            VerificaAreaArchivio(AreaArchivio.Path);
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
                AreaArchivio.PathBase = path;
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

            this.groupBoxArchivio.Enabled = (AreaArchivio.Colore != Color.Red);
        }
        /// <summary>
        /// Apre la dialog per l'archiviazione di una traccia
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butArchiviaTraccia_Click(object sender, EventArgs e)
        {
            // verifica l'esistenza dell'Area Archivo
            if (!Escursione.StatoOk())
            {
                GstErrori.StampaMessaggioErrore(GstErrori.EErrore.E1312_PathEscursioneErrato, Escursione.Path);
                return;
            }

            FormArchivioTraccia dlg = new FormArchivioTraccia(ref Traccia, false);
            dlg.ShowDialog();
        }
        /// <summary>
        /// Selezione un escursione
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butEscursione_Click(object sender, EventArgs e)
        {
            // Seleziona una escursione e apre la dialog per modificarla
            ModificaEscursione();
        }
        /// <summary>
        /// Attiva il form per la gestione dei prefissi
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butIdentita_Click(object sender, EventArgs e)
        {
            FormIdentita dlg = new FormIdentita(ref Traccia);
            dlg.ShowDialog();
        }

        private void butLuogo_Click(object sender, EventArgs e)
        {
            FormLuogo dlg = new FormLuogo(ref Traccia, "");
            dlg.ShowDialog();
        }
        /// <summary>
        /// Avvia explorer dal path specificato
        /// </summary>
        /// <param name="path"></param>
        private void ApreExplorer(string path)
        {
            string target = "Explorer";

            try
            {
                System.Diagnostics.Process.Start(target, path);
            }
            catch (System.ComponentModel.Win32Exception noBrowser)
            {
                if (noBrowser.ErrorCode == -2147467259)
                    MessageBox.Show(noBrowser.Message);
            }
            catch (System.Exception other)
            {
                MessageBox.Show(other.Message);
            }

        }

        private void butExplorerAreaBase_Click(object sender, EventArgs e)
        {
            //// Controlla lo stato della Escursione
            //if (!Escursione.StatoOk())
            //{
            //    GstErrori.StampaMessaggioErrore(GstErrori.EErrore.E1332_PathEscursioneEsiste);
            //}

            // recupera il path dell'escursione e avvia explore
            ApreExplorer(textBoxPathAreaArchivio.Text);
        }
        /// <summary>
        /// Selezione e Modifica una escursione
        /// </summary>
        /// <returns></returns>
        private GstErrori.EErrore ModificaEscursione()
        {
            // apre la dialog con il sommario delle escursioni
            FormSommarioEscursioni dlg = new FormSommarioEscursioni(ref Escursione);
            dlg.ShowDialog();
            if (dlg.DialogResult != DialogResult.OK)
                return GstErrori.EErrore.E0001_NOK;
            else if (dlg.PathEscursioneSelezionata == null)
                return GstErrori.EErrore.E0001_NOK;

            // Estrae path della escursione selezionata
            string pathEscursione = dlg.PathEscursioneSelezionata;

            // Assegna il nome dell'escursione
            Escursione.SetNome(pathEscursione);

            // Legge il file Info
            Escursione.LeggeFileInfo();

            // Apre il form Archivio Escursione
            OpenArchivioEscursione();

            return GstErrori.EErrore.E0000_OK;
        }
    }
}
