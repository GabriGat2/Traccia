using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
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
            butArchiviaTraccia.Enabled = false;
        }
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
                textBoxArchivio.Text = Traccia.Nome;
                textBoxArchivio.BackColor = Traccia.Colore;
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
            string lettera = comboBoxLettera.Text;

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
                if (campiMezzo[0] != "Cammino")
                    nArchivio = nArchivio + '_' + campiMezzo[0];

            // Assegna il nome dell'archivio
            Traccia.Nome = nArchivio;

            // Stampa il nome dell'archivio
            textBoxArchivio.Text = Traccia.Nome;
            textBoxArchivio.BackColor = Traccia.Colore;
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

            // Aggiorna i colori
            textBoxArchivio.BackColor = Traccia.Colore;

            if (esito != GstErrori.EErrore.E0000_OK)
                return esito;

            // disabilita l'aggiornamento del nome della traccia
            AbilitazioneAggiornamentoTraccia = false;

            // disabilita i campi di impostazione del nome
            dateTimePicker1.Enabled = false;
            comboBoxLettera.Enabled = false;
            comboBoxMezzo.Enabled = false;
            textBoxNome.Enabled = false;
             
            // disabilita il bottone crea traccia 
            butCreaTraccia.Enabled = false;

            // abilita il bottone Archivia traccia 
            butArchiviaTraccia.Enabled = true;

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
    }
}
