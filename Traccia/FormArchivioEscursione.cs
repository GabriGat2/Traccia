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
    public partial class FormArchivioEscursione: Form
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
        /// Gestore per la stampa dei messaggi
        /// </summary>
        private CMessaggio msg = null;
        /// </summary>
        /// Costruttore 
        /// </summary>
        /// <param name="DirectoryBase"></param>
        public FormArchivioEscursione(ref CArchivioTraccia traccia)
        {
            // Assegna Archivio traccia
            Traccia = traccia;

            // Assegna Archivio escursione
            Escursione = Traccia.Escursione;
            
            InitializeComponent();
            InizializzaClasse();
        }

        /// <summary>
        /// Inizilizzazione della classe
        /// </summary>
        private void InizializzaClasse()
        {
            // Definisce il gestore dei messaggi
            msg = new CMessaggio(ref richTextBoxOutput);

            // Aggiorna la casella con il path dell'area archivio
            textBoxDirectoryBase.Text = Escursione.AreaArchivio.PathBase;

            // Controlla lo stato della Escursione
            if (Escursione.StatoOk())
            {
                // disabilita aggiornamento traccia
                AbilitazioneAggiornamentoEscursione = false;

                // disabilita in scittura del caselle di impostazione del nome dell'escursione
                dateTimePicker1.Enabled = false;
                textBoxPrefisso.Enabled = false;
                textBoxNome.Enabled = false;

                // aggiorna i campi
                dateTimePicker1.Text = Escursione.Data;
                textBoxPrefisso.Text = Escursione.Prefisso;
                textBoxNome.Text = Escursione.NomeParziale;

                // Aggiorna il nome dell'archivio
                textBoxArchivio.Text = Escursione.Nome;
                textBoxArchivio.BackColor = Escursione.Colore;

                // Aggiorna il path dell'archivio
                textBoxPathArchivio.Text = Escursione.Path;
                textBoxPathArchivio.BackColor = Escursione.Colore;

                // Disabilita bottone crea escursione 
                butCrea.Enabled = false;

                // Abilita bottone archivia traccia
                butArchiviaTraccia.Enabled = true;
            }
            else
            {
                // disabilita aggiornamento traccia
                AbilitazioneAggiornamentoEscursione = true;

                // Abilita bottone archivia traccia
                butArchiviaTraccia.Enabled = false;
            }

        }
        /// <summary>
        /// Aggiorna il nome dell'archivio
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butAggiorna_Click(object sender, EventArgs e)
        {
            AggiornamentoEscursione();
        }
        /// <summary>
        /// Verifica il path dell'archivio
        /// </summary>
        private void AggiornamentoEscursione ()
        {
            if (!AbilitazioneAggiornamentoEscursione)
            {
                // Stampa il nome dell'archivio
                textBoxArchivio.Text = Escursione.Nome;
                textBoxArchivio.BackColor = Escursione.Colore;

                // Stampa il path dell'archivio
                textBoxPathArchivio.Text = Escursione.Path;
                textBoxPathArchivio.BackColor = Escursione.Colore;
            }


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
            }


            // compone il nome dell'Archivio
            string nArchivio = nData + '_' + nPrefisso + '_' + nNome;

            // Assegna il nome dell'archivio
            Escursione.Nome = nArchivio;


            // Stampa il nome dell'archivio
            textBoxArchivio.Text = Escursione.Nome;
            textBoxArchivio.BackColor = Escursione.Colore;

            // Stampa il path dell'archivio
            textBoxPathArchivio.Text = Escursione.Path;
            textBoxPathArchivio.BackColor = Escursione.Colore;
        }
        /// <summary>
        /// Il prefisso dell'archivio è cambiato
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxPrefisso_TextChanged(object sender, EventArgs e)
        {
            if (textBoxPrefisso.Enabled)
                AggiornamentoEscursione();
        }
        /// <summary>
        /// Il nome dell'archivio è cambiato
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxNome_TextChanged(object sender, EventArgs e)
        {
            if (textBoxNome.Enabled)
                AggiornamentoEscursione();
        }
        /// <summary>
        /// La data dell'Archivio è cambiato
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePicker1.Enabled)
                AggiornamentoEscursione();
        }
        /// <summary>
        /// Crea directory archivio 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butCrea_Click(object sender, EventArgs e)
        {
            // Crea l'archivio per un escursine
            msg.Stampa("Genera l'archivio: " + Escursione.Nome);

            GstErrori.EErrore esito = CreaArchivioEscursione();

            msg.Stampa("La generazione dell'archivio: " + Escursione.Nome);
            msg.StampaConEsito(" è stata  eseguita", " è FALLITA!", esito, false);

        }
        /// <summary>
        /// Crea archivo dell'escursione
        /// </summary>
        private GstErrori.EErrore CreaArchivioEscursione()
        {
            GstErrori.EErrore esito;

            // crea l'archivio della traccia 
            esito = Escursione.CreaDirectoryArchivio();

            if (esito != GstErrori.EErrore.E0000_OK)
                return esito;

            // disabilita l'aggiornamento del nome della traccia
            AbilitazioneAggiornamentoEscursione = false;

            // disabilita i campi di impostazione del nome
            dateTimePicker1.Enabled = false;
            textBoxPrefisso.Enabled = false;
            textBoxNome.Enabled = false;

            // disabilita il bottone crea l'escursione 
            butCrea.Enabled = false;

            // abilita il bottone nuova traccia 
            butArchiviaTraccia.Enabled = true;

            // Verifica se l'archivio è stato creato correttamente
            AggiornamentoEscursione();

            // Stampa il file delle Info
            Escursione.ScriveFileInfo();

            return GstErrori.EErrore.E0000_OK;
        }
        /// <summary>
        /// Apre la dialog per achiviare le tracce di una escursione
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butArchiviaTraccia_Click(object sender, EventArgs e)
        {
            // verifica l'esistenza dell'Escursione
            if (!Escursione.StatoOk())
            {
                GstErrori.StampaMessaggioErrore(GstErrori.EErrore.E1312_PathEscursioneErrato, Escursione.Path);
                return;
            }

            FormArchivoTraccia dlg = new FormArchivoTraccia(ref Traccia, false);
            dlg.ShowDialog();
        }
        /// <summary>
        /// Selezione e Modifica una traccia
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butModificaTraccia_Click(object sender, EventArgs e)
        {
            ModificaTraccia();
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
        /// Attiva la finestra explorer, se esiste, all'indirizzo della escursione
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butExplorerEscursione_Click(object sender, EventArgs e)
        {
            // Controlla lo stato della Escursione
            if (! Escursione.StatoOk())
            {
                GstErrori.StampaMessaggioErrore(GstErrori.EErrore.E1332_PathEscursioneEsiste);
            }

            // recupera il path dell'escursione e avvia explore
            ApreExplorer(Escursione.Path);
        }
        /// <summary>
        /// Attiva la finestra explorer, se esiste, all'indirizzo del'area escursione
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butExplorerArea_Click(object sender, EventArgs e)
        {
            // Controlla lo stato dell'Area Archivio
            if (!Escursione.AreaArchivio.StatoOk())
            {
                GstErrori.StampaMessaggioErrore(GstErrori.EErrore.E1321_PathAreaArchivioNonEsiste);
            }
            // recupera il path dell'escursione e avvia explore
            ApreExplorer(Escursione.AreaArchivio.Path);
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

    }
}
