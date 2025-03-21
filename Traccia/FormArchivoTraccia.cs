using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Traccia
{
    public partial class FormArchivoTraccia: Form
    {
        /// <summary>
        /// Archivio Traccia
        /// </summary>
        public CArchivioTraccia Traccia = new CArchivioTraccia();
        /// <summary>
        /// Gestore per la stampa dei messaggi
        /// </summary>
        private CMessaggio msg = null;
        /// <summary>
        /// Abilita l'aggiornamento del nome della traccia
        /// </summary>
        private bool AbilitazioneAggiornamentoTraccia;
        /// <summary>
        /// Costruttore
        /// </summary>
        /// <param name="traccia"></param>
        public FormArchivoTraccia(ref CArchivioTraccia traccia)
        {
            // Assegna Archivio traccia
            Traccia = traccia;

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

            // abilita l'aggiornnamento del nome della traccia
            AbilitazioneAggiornamentoTraccia = true;

            // Aggiorna l'area Escursione
            textBoxNomeEscursione.Text = Traccia.Escursione.Nome;
            textBoxPathEscursione.Text = Traccia.Escursione.Path;
            textBoxPathInputDati.Text = Traccia.Escursione.AreaArchivio.GetPathInput();

            // popola combobox lettera
            string[] lettere = new string[] 
            {   
                "A", "B", "C", "D", "E", "F", "G", "H",
                "I", "J", "K", "L", "M", "N", "O", "P",
                "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"
            };
            comboBoxLettera.Items.AddRange(lettere);

            // Popola la combobox dei mezzi
            PopolaMezzi();

            // Impone il prefisso dell'escursione
            textBoxPrefisso.Text = Traccia.Escursione.Prefisso;
            textBoxPrefisso.Enabled = false;

            // Inizializza la data come quella dell'escursione
            dateTimePicker1.Text = Traccia.Escursione.Data;

            // abilita il bottone crea traccia 
            butCreaTraccia.Enabled = true;

            // disabilita il bottone Archivia traccia 
            butNuovaTraccia.Enabled = false;
        }
        /// <summary>
        /// Aggiorna le caselle con la nuova traccia
        /// </summary>
        private void NuovaTraccia()
        {
            // abilita l'aggiornnamento del nome della traccia
            AbilitazioneAggiornamentoTraccia = true;

            // Inizializza la data come quella dell'escursione
            dateTimePicker1.Text = Traccia.Escursione.Data;

            // abilita il bottone crea traccia 
            butCreaTraccia.Enabled = true;

            // disabilita il bottone Archivia traccia 
            butNuovaTraccia.Enabled = false;

            // riabilita i campi di impostazione del nome
            dateTimePicker1.Enabled = true;
            comboBoxLettera.Enabled = true;
            comboBoxMezzo.Enabled = true;
            textBoxNome.Enabled = true;
            checkBoxGiorno.Enabled = true;
            checkBoxSingola.Enabled = true;
        }


        /// <summary>
        /// Popola la combo box Mezzi
        /// </summary>
        private void PopolaMezzi()
        {
            // recupera il path della directory comune e aggiunge il nome del filee
            string pathMezzi = Traccia.Escursione.AreaArchivio.GetPathComune()  + "\\" + "Mezzi.txt";
          
            String line;
            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader(pathMezzi);
                //Read the first line of text
                line = sr.ReadLine();
                //Continue to read until you reach end of file
                while (line != null)
                {
                    //write the line to console window
                    msg.Stampa(line); 

                    // Aggiunge line a combobox
                    comboBoxMezzo.Items.Add(line);

                    //Read the next line
                    line = sr.ReadLine();
                }
                //close the file
                sr.Close();
            }
            catch (Exception e)
            {
                msg.Stampa("Exception: " + e.Message);
            }
        }
        /// <summary>
        /// Attiva l'aggioramento del nome della traccia
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butAggiorna_Click(object sender, EventArgs e)
        {
            AggiornaNomeTraccia();
        }
        /// <summary>
        /// Aggiorna il nome della traccia
        /// </summary>
        private void AggiornaNomeTraccia()
        {
            // controlla se l'aggiornamento del nome della traccia è abilitato
            if (!AbilitazioneAggiornamentoTraccia)
            {
                StampaNomeTraccia();

                return; 
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

            // recupera il valore della lettera
            string lettera = string.Empty;

            if (comboBoxLettera.Text.Trim().Length > 0) 
                lettera = comboBoxLettera.Text;
            else
                lettera = "?";

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

            // recupera il valore del mezzzo
            string mezzo = comboBoxMezzo.Text;
            string[] campiMezzo = mezzo.Trim().Split('_');
           
            // compone il nome dell'Archivio
            string nArchivio = nData + '-' + lettera + '_' + nPrefisso + '_' + nNome;
            if (campiMezzo.Length > 0)
                if( (campiMezzo[0] != "Cammino") && (campiMezzo[0].Trim().Length > 0))
                    nArchivio = nArchivio + '_' + campiMezzo[0];

            // Assegna il nome dell'archivio
            Traccia.Nome = nArchivio;
            // mostra il nome della traccia
            StampaNomeTraccia();
        }
        /// <summary>
        /// AStampa il nome della traccia
        /// </summary>
        /// <returns></returns>
        private void StampaNomeTraccia()
        {
            // mostra il nome della traccia
            textBoxArchivio.Text = Traccia.Nome;
            textBoxArchivio.BackColor = Traccia.Colore;
            // mostra il path della traccia
            textBoxPathArchivio.Text = Traccia.Path; ;
            textBoxPathArchivio.BackColor = Traccia.Colore;

            if (Traccia.Path != null)
                msg.Stampa(Traccia.Path);
        }

        /// <summary>
        /// Il prefisso dell'archivio è cambiato
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxPrefisso_TextChanged(object sender, EventArgs e)
        {
            AggiornaNomeTraccia();
        }
        /// <summary>
        /// Il nome dell'archivio è cambiato
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxNome_TextChanged(object sender, EventArgs e)
        {
            AggiornaNomeTraccia();
        }
        /// <summary>
        /// La data dell'Archivio è cambiato
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            AggiornaNomeTraccia();
        }
        private void butCreaTraccia_Click(object sender, EventArgs e)
        {
            msg.Stampa("Genera l'archivio: " + Traccia.Nome);

            GstErrori.EErrore esito = CreaTraccia();

            msg.Stampa("La generazione dell'archivio: " + Traccia.Nome);
            msg.StampaConEsito("è stata  eseguita", "è FALLITA!", esito, false);

        }
        /// <summary>
        /// Crea la traccia
        /// </summary>
        /// <returns></returns>
        private GstErrori.EErrore CreaTraccia()
        {
            GstErrori.EErrore esito;

            // crea l'archivio della traccia 
            esito = Traccia.CreaDirectoryArchivio();


            if (esito != GstErrori.EErrore.E0000_OK)
                return esito;

            // disabilita l'aggiornamento del nome della traccia
            AbilitazioneAggiornamentoTraccia = false;

            // disabilita i campi di impostazione del nome
            dateTimePicker1.Enabled = false;
            comboBoxLettera.Enabled = false;
            comboBoxMezzo.Enabled = false;
            textBoxNome.Enabled = false;
            checkBoxGiorno.Enabled = false;
            checkBoxSingola.Enabled = false;
             
            // disabilita il bottone crea traccia 
            butCreaTraccia.Enabled = false;

            // abilita il bottone Archivia traccia 
            butNuovaTraccia.Enabled = true;

            // Aggiornamento traccia
            AggiornaNomeTraccia();

            // Stampa il file delle Info
            Traccia.ScriveFileInfo();

            return esito;
        }
        /// <summary>
        /// Il valore selezionato in Combobox mezzo è cambiato, aggiorna il nome della traccia
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxMezzo_SelectedValueChanged(object sender, EventArgs e)
        {
            AggiornaNomeTraccia();
        }
        /// <summary>
        /// Il valore selezionato in Combobox lettera è cambiato, aggiorna il nome della traccia
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxLettera_SelectedIndexChanged(object sender, EventArgs e)
        {
            AggiornaNomeTraccia();
        }
        /// <summary>
        /// Il valore dell'opzione giorno è cambiata
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxGiorno_CheckedChanged(object sender, EventArgs e)
        {
            Traccia.OptGiorno = checkBoxGiorno.Checked;
            AggiornaNomeTraccia();
        }
        /// <summary>
        /// Il valore dell'opzione singola è cambiato
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxSingola_CheckedChanged(object sender, EventArgs e)
        {
            Traccia.OptSingola = checkBoxSingola.Checked;
            AggiornaNomeTraccia();
        }
        /// <summary>
        /// Crea una nuova traccia
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butNuovaTraccia_Click(object sender, EventArgs e)
        {
            Traccia.ClearNome();
            NuovaTraccia();
        }
        /// <summary>
        /// Copia le foto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butCopiaFoto_Click(object sender, EventArgs e)
        {
            CopiaFoto();
        }

        private GstErrori.EErrore CopiaFoto ()
        {
            // recupera il path delle foto JPEG sorgente
            string srcJpegPath = Traccia.Escursione.AreaArchivio.GetPathJPEG();

            // Compone la lista delle foto JPEG
            string [] srcJpegList = Directory.GetFiles(srcJpegPath, "*.*");

            // Estra la data di ricerca
            string dataTraccia = Traccia.GetOnlyData();



            // loop di analisi della directory
            foreach (string srcFile in srcJpegList)
            {
                // Estrae il nome del file
                string srcFileName = srcFile.Substring(srcJpegPath.Length + 1);

                // stampa il nome del file
                msg.Stampa(srcFileName, false);

                // Estrae la data di creazione
                DateTime dataCreazione = File.GetCreationTime(srcFile);
                DateTime dataCreazione2 = File.GetCreationTimeUtc(srcFile);
                //msg.Stampa("    dataCreazione: " + dataCreazione.ToString(), false);

                // Estrae la data di ultimo accesso
                DateTime dataUltimoAccesso = File.GetLastAccessTime(srcFile);
                DateTime dataUltimoAccesso2 = File.GetLastAccessTime(srcFile);
                //msg.Stampa("    dataUltimo: " + dataUltimoAccesso.ToString(), false);

                // Estrae la data di ultimo accesso
                DateTime dataUltimaScritta = File.GetLastWriteTime(srcFile);
                DateTime dataUltimaScritta2 = File.GetLastAccessTimeUtc(srcFile);
                msg.Stampa("    dataScrittura: " + dataUltimaScritta.ToString(), false);
                string dataFile = dataUltimaScritta.Date.ToString();

                if (dataTraccia == dataFile)
                {

                    msg.Stampa("    file trovato: " + srcFileName, true);

                }


            }


            return GstErrori.EErrore.E0000_OK;
        }
    }
}
