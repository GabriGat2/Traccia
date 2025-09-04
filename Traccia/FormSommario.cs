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
    public partial class FormSommario: Form
    {
        /// <summary>
        /// Archivio Traccia
        /// </summary>
        public CArchivioTraccia Traccia;
        /// <summary>
        /// Archivio Escursione
        /// </summary>
        public CArchivioEscursione Escursione;
        /// <summary>
        /// Abilita l'aggiornamento del nome dell'escursione'
        /// </summary>
        private bool AbilitazioneAggiornamentoEscursione;
        /// <summary>
        /// Segnala che la data è stata impostata almeno una volta
        /// </summary>
        private bool DataImpostata = false;
        /// <summary>
        /// Gestore per la stampa dei messaggi
        /// </summary>
        private CMessaggio msg = null;
        /// <summary>
        /// Costruttore 
        /// </summary>
        public FormSommario(ref CArchivioTraccia traccia)
        {
            // Assegna Archivio traccia
            Traccia = traccia;

            // Assegna Archivio escursione
            Escursione = Traccia.Escursione;

            // Esegue inizializzazioni
            InitializeComponent();
            InizializzaClasse();
        }
        /// <summary>
        /// Inizilizzazione della classe
        /// </summary>
        private void InizializzaClasse()
        {
            //// Definisce il gestore dei messaggi
            //msg = new CMessaggio(ref richTextBoxOutput);

            //// Aggiorna la casella con il path dell'area archivio
            //textBoxDirectoryBase.Text = Escursione.AreaArchivio.PathBase;

            //// Segnal data non impostata
            //DataImpostata = false;

            //// aggiorna i campi luogo
            //textBoxLuogo.Text = Traccia.Escursione.Luogo;
            //textBoxLuogoID.Text = Traccia.Escursione.LuogoID;

            //// Controlla lo stato della Escursione
            //if (Escursione.StatoOk())
            //{
            //    // disabilita aggiornamento traccia
            //    AbilitazioneAggiornamentoEscursione = false;

            //    // disabilita in scittura del caselle di impostazione del nome dell'escursione
            //    dateTimePicker1.Enabled = false;
            //    textBoxPrefisso.Enabled = false;
            //    textBoxNome.Enabled = false;

            //    // aggiorna i campi
            //    dateTimePicker1.Value = Escursione.GetData();
            //    textBoxPrefisso.Text = Escursione.Prefisso;
            //    textBoxNome.Text = Escursione.NomeParziale;

            //    // Aggiorna il nome dell'archivio
            //    textBoxArchivio.Text = Escursione.Nome;
            //    textBoxArchivio.BackColor = Escursione.Colore;

            //    // Aggiorna il path dell'archivio
            //    textBoxPathArchivio.Text = Escursione.Path;
            //    textBoxPathArchivio.BackColor = Escursione.Colore;

            //    // Disabilita bottone crea escursione 
            //    butCrea.Enabled = false;

            //    // Abilita bottone archivia traccia
            //    butArchiviaTraccia.Enabled = true;
            //}
            //else
            //{
            //    // disabilita aggiornamento traccia
            //    AbilitazioneAggiornamentoEscursione = true;

            //    // Abilita bottone archivia traccia
            //    butArchiviaTraccia.Enabled = false;
            //}

        }
        /// <summary>
        /// Selezione e Modifica una traccia
        /// </summary>
        /// <returns></returns>
        private GstErrori.EErrore MostraListaTracce()
        {
            string data = string.Empty;
            string dataAttiva = string.Empty;

            // Estra il path con la lista delle tracce
            string pathTracce = Traccia.GetPathInfo();

            // crea la lista dell tracce
            string[] tracce = Directory.GetFiles(pathTracce);

            // stampa il nome delle tracce
            foreach (string pathNomeTraccia in tracce)
            {
                // estrae il nome della traccia
                string[] campiPathNomeTraccia = pathNomeTraccia.Split('\\');
                string nomeTraccia = ((campiPathNomeTraccia[campiPathNomeTraccia.Length - 1]).Split('.'))[0];


                // estrae la data della traccia
                string[] campiNomeTraccia = nomeTraccia.Split('_');
                // rimuove la data della traccia
                string[] campiDataTraccia = campiNomeTraccia[0].Split('-');
                // ricompone la data
                if (campiDataTraccia.Length <= 3)
                    data = campiDataTraccia[0];
                else
                    data = campiDataTraccia[0] + '-' + campiDataTraccia[1] + '-' + campiDataTraccia[2];


                // controlla se è cambita la data
                if (data != dataAttiva)
                {
                    dataAttiva = data;

                    // stampa la data  della traccia
                    richTextBoxSommarioTracce.AppendText("\n");
                    richTextBoxSommarioTracce.AppendText(data);
                    richTextBoxSommarioTracce.AppendText("\n");
                }

                // stampa il nome della traccia
                richTextBoxSommarioTracce.AppendText(nomeTraccia);
                richTextBoxSommarioTracce.AppendText("\n");
            }

            richTextBoxSommarioTracce.ScrollToCaret();



            //// Seleziona una traccia
            //OpenFileDialog dlg = new OpenFileDialog();
            //dlg.InitialDirectory = Traccia.GetPathInfo();
            //dlg.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            //dlg.FilterIndex = 1;
            //dlg.RestoreDirectory = true;

            //if (dlg.ShowDialog() != DialogResult.OK)
            //{
            //    return GstErrori.EErrore.E0001_NOK;
            //}

            //// Estrae il nome del file info
            //string pathFileInfo = dlg.FileName;

            //// Legge il file info della traccia
            //GstErrori.EErrore esito = Traccia.LeggeFileInfo(pathFileInfo);
            //if (esito != GstErrori.EErrore.E0000_OK)
            //    return esito;

            //// Apre la dialo della traccia
            //FormArchivoTraccia dlgT = new FormArchivoTraccia(ref Traccia, true);
            //dlgT.ShowDialog();


            return GstErrori.EErrore.E0000_OK;
        }
        /// <summary>
        /// Selezione e Modifica una traccia
        /// </summary>
        /// <returns></returns>
        private GstErrori.EErrore ModificaTraccia()
        {
            // Seleziona una traccia
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.InitialDirectory = Traccia.GetPathInfo();
            dlg.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            dlg.FilterIndex = 1;
            dlg.RestoreDirectory = true;

            if (dlg.ShowDialog() != DialogResult.OK)
            {
                return GstErrori.EErrore.E0001_NOK;
            }

            // Estrae il nome del file info
            string pathFileInfo = dlg.FileName;

            // Legge il file info della traccia
            GstErrori.EErrore esito = Traccia.LeggeFileInfo(pathFileInfo);
            if (esito != GstErrori.EErrore.E0000_OK)
                return esito;

            // Apre la dialo della traccia
            FormArchivoTraccia dlgT = new FormArchivoTraccia(ref Traccia, true);
            dlgT.ShowDialog();


            return GstErrori.EErrore.E0000_OK;
        }
        /// <summary>
        /// Mostra la lista delle tracce
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butAggiorna_Click(object sender, EventArgs e)
        {
            MostraListaTracce();
        }
    }
}
