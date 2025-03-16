using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        /// Directory Base Area Archivo
        /// </summary>
        public bool DirectoryBaseAreaArchivioStato = false;
        public string DirectoryBaseAreaArchivioPath = string.Empty;
        /// <summary>
        /// Stato archivio
        /// </summary>
        public enum EArchivioStato
        {
            Indefinito,                 // 0                       
            DirBaseNonEsiste,           // 1
            NomeArchivioErrato,         // 2     
            ArchivioEsiste,             // 3   
            ArchivioNonEsiste           // 4
        };
        /// <summary>
        /// Area Archivio
        /// </summary>
        public EArchivioStato AreaArchivioStato = EArchivioStato.Indefinito;
        public string AreaArchivioNome = string.Empty;
        public string AreaArchivioPath = string.Empty;

        /// <summary>
        /// Verifica l'sistenza della directory AreaArchivioPath
        /// </summary>
        /// <returns></returns>
        public bool VerificaEsistenzaArchivioStato()
        {
            // verifica se lo stato è corretto
            if (AreaArchivioStato != EArchivioStato.ArchivioEsiste)
                return false;

            // verifica se la directory esiste
            DirectoryInfo dir = new DirectoryInfo(AreaArchivioPath);
            return dir.Exists;
        }
        /// <summary>
        /// Costruttore
        /// </summary>
        public FormMain()
        {
            InitializeComponent();


            // Verifica Area Archivio
            string path = "D:\\Angelo\\Prj\\Traccia\\ArchiviazioneTraccia\\ArchivioEscursioni";
            VerificaAreaArchivio(path);
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
            if (! VerificaEsistenzaArchivioStato())
            {
                GstErrori.StampaMessaggioErrore(GstErrori.EErrore.E1303_PathAreaArchivioErrata, AreaArchivioPath);
                return;
            }

            FormCreaArchivio dlg = new FormCreaArchivio(AreaArchivioPath);
            dlg.ShowDialog();
            //dlg.Show();
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
            // estrae il nome dell'area Archivio
            string[] campi = pathAreaArchivio.Split('\\');
            string nAreaArchivio = campi[campi.Length - 1];

            // verifica se la directory esiste
            DirectoryInfo dir = new DirectoryInfo(pathAreaArchivio);
            if (dir.Exists)
            {
                DirectoryBaseAreaArchivioStato = true;
                SetStatoArchivio(EArchivioStato.ArchivioEsiste, nAreaArchivio, pathAreaArchivio);
            }
            else
            {
                DirectoryBaseAreaArchivioStato = false;
                SetStatoArchivio(EArchivioStato.ArchivioNonEsiste, nAreaArchivio, pathAreaArchivio);
            }

            // pubblica lo stato di Area Archivio
            MostraAreaArchivio();
        }

        private void MostraAreaArchivio()
        {
            textBoxNomeAreaArchivio.Text = AreaArchivioNome;
            textBoxPathAreaArchivio.Text = AreaArchivioPath;

            // colora il nome dell'archivio in funzione dell'esito della composizione
            switch (AreaArchivioStato)
            {
                default:
                case EArchivioStato.Indefinito:
                    textBoxNomeAreaArchivio.BackColor = Color.LightPink;
                    textBoxPathAreaArchivio.BackColor = Color.LightPink;
                    break;

                case EArchivioStato.DirBaseNonEsiste:
                    textBoxNomeAreaArchivio.BackColor = Color.LightPink;
                    textBoxPathAreaArchivio.BackColor = Color.LightPink;
                    break;

                case EArchivioStato.NomeArchivioErrato:
                    textBoxNomeAreaArchivio.BackColor = Color.LightPink;
                    textBoxPathAreaArchivio.BackColor = Color.LightPink;
                    break;

                case EArchivioStato.ArchivioEsiste:
                    textBoxNomeAreaArchivio.BackColor = Color.LightGreen;
                    textBoxPathAreaArchivio.BackColor = Color.LightGreen;
                    break;

                case EArchivioStato.ArchivioNonEsiste:
                    textBoxNomeAreaArchivio.BackColor = Color.LightPink;
                    textBoxPathAreaArchivio.BackColor = Color.LightPink;
                    break;
            }
        }

        /// <summary>
        /// Setta lo di AreaArchivio e i parametri assoviati
        /// </summary>
        /// <param name="stato"></param>
        /// <param name="nome"></param>
        /// <param name="path"></param>
        private void SetStatoArchivio(EArchivioStato stato, string nome = "", string path = "")
        {
            AreaArchivioStato = stato;

            switch (stato)
            {
                case EArchivioStato.ArchivioEsiste:
                case EArchivioStato.ArchivioNonEsiste:
                    AreaArchivioNome = nome;
                    AreaArchivioPath = path;
                    break;

                case EArchivioStato.NomeArchivioErrato:
                case EArchivioStato.DirBaseNonEsiste:
                case EArchivioStato.Indefinito:
                default:
                    AreaArchivioNome = string.Empty;
                    AreaArchivioPath = string.Empty;
                    break;

            }
        }

    }
}
