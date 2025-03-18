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
    public partial class FormAreaArchivio: Form
    {
        /// <summary>
        /// Archivio Escursione
        /// </summary>
        public CAreaArchivio AreaArchivio = null;
        /// <summary>
        /// costruttore 2
        /// </summary>
        /// <param name="areaArchivio"></param>
        public FormAreaArchivio(ref CAreaArchivio areaArchivio)
        {
            InitializeComponent();

            AreaArchivio = areaArchivio;

            // Aggiorna le caselle di impostazione   
            textBoxNome.Text = AreaArchivio.Nome;
            textBoxDirectoryBaseAreaArchivio.Text = AreaArchivio.PathBase;
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
            // Recupera il path della directory base
            AreaArchivio.PathBase = textBoxDirectoryBaseAreaArchivio.Text;
            textBoxDirectoryBaseAreaArchivio.BackColor = AreaArchivio.Colore;

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
        /// Verifica il path dell'area archivio
        /// </summary>
        private void VerificaPathArchivio()
        {
            //// resetta lo stato dell'archivio
            //SetStatoArchivio(EArchivioStato.Indefinito);

            //bool ArchivioOk = true;

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
            }

            // compone il nome dell'Archivio
            string nArchivio = nNome;
            if (nPostfisso.Length > 0)
                nArchivio += '_' + nPostfisso;

            // Aeegna il nome dell'archivio
            AreaArchivio.Nome = nArchivio;


            // Stampa il nome dell'archivio
            textBoxArchivio.Text = AreaArchivio.Nome;


            // colora il nome dell'archivio in funzione dello stato 
            textBoxArchivio.BackColor = AreaArchivio.Colore;
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
            if (AreaArchivio.Stato == CArchivio.EArchivioStato.ArchivioEsiste)
            {

            }
            else if (AreaArchivio.Stato != CArchivio.EArchivioStato.ArchivioNonEsiste)
            {
                return GstErrori.EErrore.E1300_NomeArchivioErrato;
            }

            // Crea l'archivio
            CArchivioDirectory archivio = new CArchivioDirectory();
            archivio.CreaSrcArchivio(AreaArchivio.Path, AreaArchivio.Nome);

            // colora il nome dell'archivio in funzione dello stato 
            textBoxArchivio.BackColor = AreaArchivio.Colore;

            return GstErrori.EErrore.E0000_OK;
        }
    }
}
