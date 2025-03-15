using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Traccia
{
    public partial class FormCreaArchivio: Form
    {
        /// <summary>
        /// Directory Base
        /// </summary>
        public bool DirectoryBaseStato = false;
        public string DirectoryBasePath = string.Empty;
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
        /// Archivio
        /// </summary>
        public EArchivioStato ArchivioStato = EArchivioStato.Indefinito;
        public string ArchivioNome = string.Empty;
        public string ArchivioPath = string.Empty;
        /// <summary>
        /// Costruttore
        /// </summary>
        public FormCreaArchivio()
        {
            InitializeComponent();

            // Provvisosio
            DirectoryBasePath = "D:\\Angelo\\Prj\\Traccia\\ArchiviazioneTraccia";
            textBoxDirectoryBase.Text = DirectoryBasePath;
        }
        /// <summary>
        /// Seleziona la directory base di archiviazione
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butDirectoryBase_Click(object sender, EventArgs e)
        {
            // seleziona la direcory base
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                textBoxDirectoryBase.Text = dlg.SelectedPath;
            }

            // verifica se la directory esiste
            VerificaDirectoryBase();
        }
        /// <summary>
        /// Il path della directory base è cambiato
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxDirectoryBase_TextChanged(object sender, EventArgs e)
        {
            VerificaDirectoryBase();
        }
        /// <summary>
        /// Verifica la directory base
        /// </summary>
        private void VerificaDirectoryBase()
        {
            // Pone directory base falsa
            DirectoryBaseStato = false;
            DirectoryBasePath = string.Empty;

            // Recupera il path della directory base
            string dirBase = textBoxDirectoryBase.Text.Trim();
            if (dirBase.Length > 0)
            {
                // verifica se la directory esiste
                DirectoryInfo dir = new DirectoryInfo(dirBase);
                if (dir.Exists)
                {
                    DirectoryBasePath = dirBase;
                    DirectoryBaseStato = true;
                }
            }

            // colora il nome della directorybase
            if (DirectoryBaseStato)
            {
                textBoxDirectoryBase.BackColor = Color.LightGreen;
            }
            else
                textBoxDirectoryBase.BackColor = Color.LightPink;


            // verifica Archivio
            VerificaPathArchivio();
        }
        /// <summary>
        /// Aggiorna il nome dell'archivio
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butAggiorna_Click(object sender, EventArgs e)
        {
            VerificaPathArchivio();
        }
        /// <summary>
        /// Setta l'archivio di stato e i parametri associati
        /// </summary>
        /// <param name="stato"></param>
        /// <param name="nome"></param>
        /// <param name="path"></param>
        private void SetStatoArchivio(EArchivioStato stato, string nome = "", string path = "" )
        {
            ArchivioStato = stato;

            switch (stato)
            {
                case EArchivioStato.ArchivioEsiste:
                case EArchivioStato.ArchivioNonEsiste:
                    ArchivioNome = nome;
                    ArchivioPath = path;
                    break;

                case EArchivioStato.NomeArchivioErrato:
                case EArchivioStato.DirBaseNonEsiste:
                case EArchivioStato.Indefinito:
                default:
                    ArchivioNome = string.Empty;
                    ArchivioPath = string.Empty;
                    break;

            }
        }
        /// <summary>
        /// Verifica il path dell'archivio
        /// </summary>
        private void VerificaPathArchivio ()
        {
            // resetta lo stato dell'archivio
            SetStatoArchivio(EArchivioStato.Indefinito);

            bool ArchivioOk = true;

            // Recupera il valore della data
            string data;
            string nData;

            data = dateTimePicker1.Text;
            string[] campi = data.Split('/');
            if (campi.Length == 3)
            {
                nData = campi[2] + '-' + campi[1] + '-' + campi[0];
            }
            else
            {
                nData = "??";
                ArchivioOk = false;
            }

            // Recupera il valore del prefisso
            string prefisso;
            string nPrefisso;

            prefisso = textBoxPrefisso.Text.Trim();
            string[] prefissi = prefisso.Split(' ', '?');
            if ((prefisso.Length > 0) && (prefissi.Length == 1))
            {
                nPrefisso = prefisso;
            }
            else
            {
                nPrefisso = "??";
                ArchivioOk = false;
            }

            // Recupera il valore del nome
            string nome;
            string nNome;

            nome = textBoxNome.Text.Trim();
            string[] nomi = nome.Split(' ', '?');
            if ((nome.Length > 0) && (nomi.Length == 1))
            {
                nNome = nome;
            }
            else
            {
                nNome = "??";
                ArchivioOk = false;
            }


            // compone il nome dell'Archivio
            string nArchivio = nData + '_' + nPrefisso + '_' + nNome;

            // Stampa il nome dell'archivio
            textBoxArchivio.Text = nArchivio;

            // verifica se la directory base esiste
            if (ArchivioOk)
            {
                if (DirectoryBaseStato)
                {
                    // compone il path della directory
                    string pathArchivio = DirectoryBasePath + '\\' + nArchivio;

                    // verifica se la directory esiste
                    DirectoryInfo dir = new DirectoryInfo(pathArchivio);
                    if (dir.Exists)
                    {
                        SetStatoArchivio(EArchivioStato.ArchivioEsiste, nArchivio, pathArchivio);
                    }
                    else
                        SetStatoArchivio(EArchivioStato.ArchivioNonEsiste, nArchivio, pathArchivio);
                }
                else
                {
                    SetStatoArchivio(EArchivioStato.DirBaseNonEsiste); 
                }
            }
            else
                SetStatoArchivio(EArchivioStato.NomeArchivioErrato);


            // colora il nome dell'archivio in funzione dell'esito della composizione
            switch (ArchivioStato)
            {
                default:
                case EArchivioStato.Indefinito:
                    textBoxArchivio.BackColor = Color.White;
                    break;
                    
                case EArchivioStato.DirBaseNonEsiste:
                    textBoxArchivio.BackColor = Color.Yellow;
                    break;

                case EArchivioStato.NomeArchivioErrato:
                    textBoxArchivio.BackColor = Color.LightPink;
                    break;

                case EArchivioStato.ArchivioEsiste:
                    textBoxArchivio.BackColor = Color.Turquoise;
                    break;

                case EArchivioStato.ArchivioNonEsiste:
                    textBoxArchivio.BackColor = Color.LightGreen;
                    break;
            }
        }
        /// <summary>
        /// Il prefisso dell'archivio è cambiato
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxPrefisso_TextChanged(object sender, EventArgs e)
        {
            VerificaPathArchivio();
        }
        /// <summary>
        /// Il nome dell'archivio è cambiato
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxNome_TextChanged(object sender, EventArgs e)
        {
            VerificaPathArchivio();
        }
        /// <summary>
        /// La data dell'Archivio è cambiato
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            VerificaPathArchivio();
        }
        /// <summary>
        /// Crea directory archivio 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butCrea_Click(object sender, EventArgs e)
        {
            GstErrori.EErrore esito = CreaArchivioClassio();
        }
        /// <summary>
        /// Crea archivo nel Modo Classico
        /// </summary>
        private GstErrori.EErrore CreaArchivioClassio()
        {
            // verifica che ci siano le condizioni per creare la directory
            if (ArchivioStato != EArchivioStato.ArchivioNonEsiste)
                return GstErrori.EErrore.E1300_NomeArchivioErrato;

            CArchivio archivio = new CArchivio();
            archivio.CreaArchivio(ArchivioPath, ArchivioNome);


            return GstErrori.EErrore.E0000_OK;
        }

    }
}
