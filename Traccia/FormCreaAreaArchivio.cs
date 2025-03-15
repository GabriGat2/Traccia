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
    public partial class FormCreaAreaArchivio: Form
    {
        /// <summary>
        /// Directory Base Area Archivo
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
        /// Area Archivio
        /// </summary>
        public EArchivioStato ArchivioStato = EArchivioStato.Indefinito;
        public string ArchivioNome = string.Empty;
        public string ArchivioPath = string.Empty;

        public FormCreaAreaArchivio()
        {
            InitializeComponent();

            // Provvisosio
            DirectoryBasePath = "D:\\Angelo\\Prj\\Traccia\\ArchiviazioneTraccia";
            textBoxDirectoryBaseAreaArchivio.Text = DirectoryBasePath;

            // nome di default dell'area archivio
            textBoxNome.Text = "ArchivioEscursioni";
        }

        private void butDirectoryBaseAreaArchivio_Click(object sender, EventArgs e)
        {
            // seleziona la direcory base
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                textBoxDirectoryBaseAreaArchivio.Text = dlg.SelectedPath;
            }

            // verifica se la directory esiste
            VerificaDirectoryBase();
        }
        /// <summary>
        /// Il path della directory Base Area Archivio è cambiato
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxDirectoryBaseAreaArchivio_TextChanged(object sender, EventArgs e)
        {
            // verifica se la directory esiste
            VerificaDirectoryBase();
        }
        /// <summary>
        /// Verifica la directoryBase
        /// </summary>
        private void VerificaDirectoryBase()
        {
            // Pone directory base falsa
            DirectoryBaseStato = false;
            DirectoryBasePath = string.Empty;

            // Recupera il path della directory base
            string dirBase = textBoxDirectoryBaseAreaArchivio.Text.Trim();
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
                textBoxDirectoryBaseAreaArchivio.BackColor = Color.LightGreen;
            }
            else
                textBoxDirectoryBaseAreaArchivio.BackColor = Color.LightPink;


            // verifica Archivio
            VerificaPathArchivio();
        }
        /// <summary>
        /// Aggiorna il nome dell'area archivio
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butAggiorna_Click(object sender, EventArgs e)
        {
            // verifica Archivio
            VerificaPathArchivio();
        }
        /// <summary>
        /// Il nome dell'area Archivio è cambiata
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxNome_TextChanged(object sender, EventArgs e)
        {
            // verifica Archivio
            VerificaPathArchivio();
        }
        /// <summary>
        /// Il nome del Postfisso dell'area Archivio è cambiato
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxPostfisso_TextChanged(object sender, EventArgs e)
        {
            // verifica Archivio
            VerificaPathArchivio();
        }
        /// <summary>
        /// Setta lo di AreaArchivio e i parametri assoviati
        /// </summary>
        /// <param name="stato"></param>
        /// <param name="nome"></param>
        /// <param name="path"></param>
        private void SetStatoArchivio(EArchivioStato stato, string nome = "", string path = "")
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
        private void VerificaPathArchivio()
        {
            // resetta lo stato dell'archivio
            SetStatoArchivio(EArchivioStato.Indefinito);

            bool ArchivioOk = true;

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

            // Recupera il valore del postfisso
            string postfisso;
            string nPostfisso;

            postfisso = textBoxPostfisso.Text.Trim();
            string[] prefissi = postfisso.Split(' ', '?');
            if ((postfisso.Length >= 0) && (prefissi.Length == 1))
            {
                nPostfisso = postfisso;
            }
            else
            {
                nPostfisso = "??";
                ArchivioOk = false;
            }

            // compone il nome dell'Archivio
            string nArchivio = nNome;
            if (nPostfisso.Length > 0)
                nArchivio += '_' + nPostfisso;

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
                        SetStatoArchivio(EArchivioStato.ArchivioEsiste, nArchivio, pathArchivio);
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
        /// Imposta i valori di default
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butDefault_Click(object sender, EventArgs e)
        {
            textBoxNome.Text = "ArchivioEscursioni";
            textBoxPostfisso.Text = string.Empty;
        }

        private void butCrea_Click(object sender, EventArgs e)
        {
            CreaAreaArchivio();
        }
        /// <summary>
        /// Crea l'area Archivio
        /// </summary>
        /// <returns></returns>
        private GstErrori.EErrore CreaAreaArchivio()
        {
            // verifica che ci siano le condizioni per creare la directory
            if (ArchivioStato != EArchivioStato.ArchivioNonEsiste)
                return GstErrori.EErrore.E1300_NomeArchivioIErrato;

            CArchivio archivio = new CArchivio();
            archivio.CreaSrcArchivio(ArchivioPath, ArchivioNome);

            return GstErrori.EErrore.E0000_OK;
        }
    }
}
