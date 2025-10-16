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
    public partial class FormArchivioTracciaModifica : Form
    {
        /// <summary>
        /// Archivio Traccia
        /// </summary>
        public CArchivioTraccia Traccia = new CArchivioTraccia();
        /// <summary>
        /// Copia di salvatagio della traccia
        /// </summary>
        public CArchivioTraccia TracciaSave;
        /// <summary>
        /// Gestore per la stampa dei messaggi
        /// </summary>
        private CMessaggio msg = null;
        /// <summary>
        /// Dichiara la dialog per copiare le foto
        /// </summary>
        private FormFoto DlgCopiaFoto = null;
        /// <summary>
        /// Abilita l'aggiornamento del nome della traccia
        /// </summary>
        private bool AbilitazioneAggiornamentoTraccia;
        /// <summary>
        /// Prenota la creazione automatica della traccia
        /// </summary>
        private bool PrenotaCreaTraccia = false;
        /// <summary>
        /// Costruttore 1
        /// </summary>
        /// <param name="traccia"></param>
        //public FormArchivioTracciaModifica()
        //{
        //    // Assegna Archivio traccia
        //    Traccia = null;

        //    InitializeComponent();
        //    //InizializzaClasse(false);

        //    // prenota creazione traccia
        //    PrenotaCreaTraccia = false;
        //}
        /// <summary>
        /// Costruttore 2
        /// </summary>
        /// <param name="traccia"></param>
        public FormArchivioTracciaModifica(ref CArchivioTraccia traccia, bool modifica, bool crea = false)
        {
            // Assegna Archivio traccia
            Traccia = traccia;

            // Salva una copia di salvataggio della Traccia
            TracciaSave = new CArchivioTraccia();
            GstErrori.EErrore esito = TracciaSave.Copia(Traccia);

            InitializeComponent();
            InizializzaClasse(modifica);

            // prenota creazione traccia
            PrenotaCreaTraccia = crea;
        }
        /// <summary>
        /// Inizilizzazione della classe
        /// </summary>
        private void InizializzaClasse(bool modifica)
        {
            // Definisce il gestore dei messaggi
            msg = new CMessaggio(ref richTextBoxOutput);

            // abilita l'aggiornamento del nome della traccia
            AbilitazioneAggiornamentoTraccia = !modifica;

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
            comboBoxLettera.SelectedIndex = 0;

            // Popola la combobox dei mezzi
            PopolaMezzi();
            if (comboBoxMezzo.Items.Count > 0)
                comboBoxMezzo.SelectedIndex = 0;

            // Impone il sigla dell'escursione
            textBoxPrefisso.Text = Traccia.Escursione.Prefisso;
            textBoxPrefisso.Enabled = false;

            // Crea la dialog per copiare le foto
            DlgCopiaFoto = new FormFoto(ref Traccia);

            // Abilita l'abilitazione dei campi in funzione dell'esistenza della traccia
            //AbilitaCampi(modifica); // DEBUG_AG
            AbilitaCampi(true);

            // abilita l'aggiornamento del nome della traccia al cambio dei campi
            AbilitazioneAggiornamentoTraccia = true; // DEBUG_AG_NUOVO

        }
        /// <summary>
        /// Abilita l'abilitazione dei campi in funzione dell'esistenza della traccia
        /// </summary>
        /// <param name="modifica"></param>
        private void AbilitaCampi(bool tracciaEsiste)
        {
            // abilita l'aggiornnamento del nome della traccia
            AbilitazioneAggiornamentoTraccia = !tracciaEsiste;

            // Propone il nome della traccia
            textBoxNome.Text = NomeTracciaProposto(tracciaEsiste);

            // aggiorna i campi luogo
            if (!tracciaEsiste)
            {
                Traccia.Luogo = Traccia.Escursione.Luogo;
                Traccia.LuogoID = Traccia.Escursione.LuogoID;
            }
            textBoxLuogo.Text = Traccia.Luogo;
            textBoxLuogoID.Text = Traccia.LuogoID;

            // Inizializza la data
            if (tracciaEsiste || true) // DEBUG_AG
                dateTimePicker1.Value = Traccia.GetData();
            else
                dateTimePicker1.Value = Traccia.Escursione.GetData();

            // Inizializza lettera
            if (tracciaEsiste || true) // DEBUG_AG
                comboBoxLettera.SelectedIndex = Traccia.GetLettera() - 'A';
            else
            {
                DateTime data = dateTimePicker1.Value;
                //comboBoxLettera.SelectedIndex = SelezionaLetteraDisponibile() - 'A';
                comboBoxLettera.SelectedIndex = SelezionaLetteraDisponibileNelGiorno(data) - 'A';
            }

            // inizializza il mezzo
            if (tracciaEsiste || true) // DEBUG_AG
            {
                int index = comboBoxMezzo.FindString(Traccia.Mezzo);
                comboBoxMezzo.SelectedIndex = index;
            }
            else
            {
                comboBoxMezzo.SelectedIndex = 0;
            }

            // inizializza opzioni
            checkBoxGiorno.Checked = Traccia.OptGiorno;
            checkBoxSingola.Checked = Traccia.OptSingola;

            // Bottoni abilitati quando la traccia NON esiste
            butCreaTraccia.Enabled = !tracciaEsiste || true; //  DEBUG_AG;
            butCreaTraccia.Visible = !tracciaEsiste || true; //  DEBUG_AG;

            // Bottoni abilitati quando la traccia esiste
            butNuovaTraccia.Enabled = tracciaEsiste && false; //  DEBUG_AG
            butNuovaTraccia.Visible = tracciaEsiste || true; //  DEBUG_AG;

            butFoto.Enabled = tracciaEsiste && false; //  DEBUG_AG
            butNavigatore.Enabled = tracciaEsiste || true; //  DEBUG_AG;

            butFoto.Visible = tracciaEsiste;
            butNavigatore.Visible = tracciaEsiste;

            butFoto.Enabled = false; // DEBUG_AG
            butNavigatore.Enabled = false; // DEBUG_AG

            // Bottoni sempre abilitati
            butModificaTraccia.Enabled = true && false; // DEBUG_AG
            butModificaTraccia.Visible = true;

            // Campi di impostazione del nome
            dateTimePicker1.Enabled = !tracciaEsiste || true; // DEBUG_AG
            comboBoxLettera.Enabled = !tracciaEsiste || true; // DEBUG_AG
            comboBoxMezzo.Enabled = !tracciaEsiste || true; // DEBUG_AG
            textBoxNome.Enabled = !tracciaEsiste || true; // DEBUG_AG;
            checkBoxGiorno.Enabled = !tracciaEsiste || true; // DEBUG_AG
            checkBoxSingola.Enabled = !tracciaEsiste || true; // DEBUG_AG


            // inizializza la dialog Copia Foto
            DlgCopiaFoto.DataInizio = dateTimePicker1.Value;
            DlgCopiaFoto.OraInizio = dateTimePicker1.Value;

            DlgCopiaFoto.DataFine = dateTimePicker1.Value;
            DlgCopiaFoto.OraFine = new DateTime(dateTimePicker1.Value.Year,
                                                dateTimePicker1.Value.Month,
                                                dateTimePicker1.Value.Day,
                                                23, 59, 59);
        }
        /// <summary>
        /// Propone il nome della traccia
        /// </summary>
        /// <param name="esiste"></param>
        /// <returns></returns>
        private string NomeTracciaProposto(bool tracciaEsiste)
        {
            // Propone il nome della traccia
            string nome1;
            string mezzo1;


            // Seleziona il nome in funzione dell'esistenza della traccia
            if (tracciaEsiste)
            {
                nome1 = Traccia.Nome;
                mezzo1 = Traccia.Mezzo;
            }
            else
            {
                nome1 = Traccia.Escursione.Nome;
                mezzo1 = "";
            }

            // scompone il nome della traccia
            string[] campiMezzo1 = mezzo1.Trim().Split('_');
            int delta = 0;
            if (campiMezzo1.Length > 0)
                if ((campiMezzo1[0] == "Cammino") || (campiMezzo1[0] == ""))
                    delta = 0;
                else
                    delta = 1;

            // ricompone il nome della traccia escludendo data, prefisso ed eventuale mezzo
            string nomeProposto = string.Empty;
            string[] campiNome = nome1.Trim().Split('_');
            if (campiNome.Length > 2)
            {
                nomeProposto = campiNome[2];
                for (int i = 3; i < (campiNome.Length - delta); i++)
                {
                    nomeProposto += "_" + campiNome[i];
                }
            }

            return nomeProposto;
        }
        /// <summary>
        /// Aggiorna le caselle con la nuova traccia
        /// </summary>
        private void NuovaTraccia()
        {
            AbilitaCampi(false);
        }
        /// <summary>
        /// Popola la combo box Mezzi
        /// </summary>
        private void PopolaMezzi()
        {
            // recupera il path della directory comune e aggiunge il nome del filee
            string pathMezzi = Traccia.Escursione.AreaArchivio.GetPathComune() + "\\" + "Mezzi.txt";

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

            // Recupera il valore del sigla
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

            // assegna il mezzo
            Traccia.Mezzo = mezzo;

            // compone il nome dell'Archivio
            string nArchivio = nData + '-' + lettera + '_' + nPrefisso + '_' + nNome;
            if (campiMezzo.Length > 0)
                if ((campiMezzo[0] != "Cammino") && (campiMezzo[0].Trim().Length > 0))
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
        /// Il sigla dell'archivio è cambiato
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
            // controlla se l'aggiornamento del nome della traccia è abilitato
            if (AbilitazioneAggiornamentoTraccia)
            {
                // verifica il la lettere 
                DateTime data = dateTimePicker1.Value;
                comboBoxLettera.SelectedIndex = SelezionaLetteraDisponibileNelGiorno(data) - 'A';
            }

            AggiornaNomeTraccia();
        }
        private void butCreaTraccia_Click(object sender, EventArgs e)
        {
            // Crea la traccia
            CreaTraccia();
        }
        private GstErrori.EErrore CreaTraccia()
        {
            msg.Stampa("Genera l'archivio: " + Traccia.Nome);

            // Crea la traccia
            GstErrori.EErrore esito = CreaTraccia2();

            msg.Stampa("La generazione dell'archivio: " + Traccia.Nome);
            msg.StampaConEsito("è stata  eseguita", "è FALLITA!", esito, false);

            return esito;
        }
        /// <summary>
        /// Crea la traccia
        /// </summary>
        /// <returns></returns>
        private GstErrori.EErrore CreaTraccia2()
        {
            GstErrori.EErrore esito;

            //// crea l'archivio della traccia 
            //esito = Traccia.CreaDirectoryArchivio();
            //if (esito != GstErrori.EErrore.E0000_OK)
            //    return esito;

            //// Crea il file con le informazioni di luogo
            //esito = Traccia.ScriveFileLuogo();

            //// Abilita i campi segnalando che la traccia esiste
            //AbilitaCampi(true);

            //// Stampa il file delle Info
            //Traccia.ScriveFileInfo();

            //// Aggiornamento traccia
            //AggiornaNomeTraccia();


            // Copia le info
            string pathInfoSrc = TracciaSave.GetPathTracciaInfo();
            string NomeTracciaSrc = TracciaSave.Nome;
            string [] listaSrc = Directory.GetFiles(pathInfoSrc, "*" + NomeTracciaSrc + "*.*"); 

            string pathInfoDst = Traccia.GetPathTracciaInfo();
            string NomeTracciaDst = Traccia.Nome;

            int cntErrori = 0;

            foreach (var pathSrc in listaSrc)
            {
                // recupera il nome del file dal path sorgente
                string [] campi = pathSrc.Split('\\');
                string nomeSrc = campi[campi.Length - 1];

                // Crea il nome di destinazione
                string nomeDst = nomeSrc.Replace(NomeTracciaSrc, NomeTracciaDst);

                // Crea il path destinazione
                string pathDst = pathSrc.Replace(nomeSrc, nomeDst);


                // Copia il file nella directory di destinazione cambiandogli il nome
                try 
                {
                    File.Copy(pathSrc, pathDst, true);
                }
                catch
                {
                    cntErrori++;
                }


                // cancella il file sorgente
                int pippo = 0;

                XXXXXX

            }




            return GstErrori.EErrore.E0000_OK;
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
        /// Attiva la dialog per la gestione delle foto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butFoto_Click(object sender, EventArgs e)
        {
            // Apre la dialog per copiare le foto
            DlgCopiaFoto.AggiornaClasse();
            DlgCopiaFoto.ShowDialog(this);
        }

        private GstErrori.EErrore CopiaFoto()
        {
            // recupera il path delle foto JPEG sorgente
            string srcJpegPath = Traccia.Escursione.AreaArchivio.GetPathJpeg();

            // Compone la lista delle foto JPEG
            string[] srcJpegList = Directory.GetFiles(srcJpegPath, "*.*");

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
        /// <summary>
        /// Attiva la finestra explorer, se esiste, all'indirizzo della traccia
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butExplorerTraccia_Click(object sender, EventArgs e)
        {
            // Controlla lo stato della Escursione
            if (!Traccia.StatoOk())
            {
                GstErrori.StampaMessaggioErrore(GstErrori.EErrore.E1323_PathTracciaNonEsiste);
            }

            // recupera il path dell'escursione e avvia explore
            ApreExplorer(Traccia.Path);
        }
        /// <summary>
        /// Attiva la finestra explorer, se esiste, all'indirizzo dell'escursione
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butExploreEscursione_Click(object sender, EventArgs e)
        {
            // Controlla lo stato della Escursione
            if (!Traccia.Escursione.StatoOk())
            {
                GstErrori.StampaMessaggioErrore(GstErrori.EErrore.E1322_PathEscursioneNonEsiste);
            }

            // recupera il path dell'escursione e avvia explore
            ApreExplorer(Traccia.Escursione.Path);
        }
        /// <summary>
        /// Attiva la finestra explorer, se esiste, all'indirizzo dell'area input
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butExplorerInputDati_Click(object sender, EventArgs e)
        {
            // Controlla lo stato della Escursione
            if (!Traccia.Escursione.AreaArchivio.StatoOk())
            {
                GstErrori.StampaMessaggioErrore(GstErrori.EErrore.E1321_PathAreaArchivioNonEsiste);
            }

            // recupera il path dell'escursione e avvia explore
            ApreExplorer(Traccia.Escursione.AreaArchivio.GetPathInput());

        }
        /// <summary>
        /// Avvia explorer dal path specificato
        /// </summary>
        /// <param name="path"></param>
        private void ApreExplorer(string path)
        {
            string target = "Explorer";
            EsegueProces(target, path);
        }
        /// <summary>
        /// Apre una pagina WEB
        /// </summary>
        /// <param name="link"></param>
        private void AprePaginaWeb(string link)
        {
            string target = link;
            string arg1 = string.Empty;
            EsegueProces(target, arg1);
        }
        /// <summary>
        /// Esegue un processo
        /// </summary>
        /// <param name="target"></param>
        /// <param name="arg1"></param>
        private void EsegueProces(string target, string arg1)
        {
            try
            {
                System.Diagnostics.Process.Start(target, arg1);
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
        /// <summary>
        /// Apre la pagina WEB specificata
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonInternetTool_Click(object sender, EventArgs e)
        {
            // recupera il link
            string link = textBoxLink.Text;
            AprePaginaWeb(link);
        }
        /// <summary>
        /// Apre la dialog per la gestione del navigatore
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butNavigatore_Click(object sender, EventArgs e)
        {
            FormNavigatore dlg = new FormNavigatore(ref Traccia);
            dlg.AggiornaClasse();
            dlg.ShowDialog();

        }
        /// <summary>
        /// Attiva la selezione e la modifica di una traccia
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
            /// apre il sommario delle tracce per selezionare una traccia
            FormSommario dlg = new FormSommario(ref Traccia);
            dlg.ShowDialog();
            if (dlg.DialogResult != DialogResult.OK)
                return GstErrori.EErrore.E0001_NOK;
            else if (dlg.PathTracciaSelezionata == null)
                return GstErrori.EErrore.E0001_NOK;

            // Estrae il nome del file info
            string pathFileInfo = dlg.PathTracciaSelezionata;

            // Legge il file info della traccia
            GstErrori.EErrore esito = Traccia.LeggeFileInfo(pathFileInfo);
            if (esito != GstErrori.EErrore.E0000_OK)
                return esito;

            // Abilita i campi segnalando che la traccia esiste
            AbilitaCampi(true);

            // Aggiornamento traccia
            AggiornaNomeTraccia();

            return GstErrori.EErrore.E0000_OK;
        }
        /// <summary>
        /// Selezione il lugo in cui si sviluppa la traccia
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butLuogo_Click(object sender, EventArgs e)
        {
            SelezionaLuogoTraccia();
        }
        /// <summary>
        /// Selezione il luogo in cui si sviluppa la traccia
        /// </summary>
        /// <returns></returns>
        private GstErrori.EErrore SelezionaLuogoTraccia()
        {
            FormLuogo dlg = new FormLuogo(ref Traccia, Traccia.LuogoID);
            dlg.ShowDialog();
            DialogResult esito = dlg.DialogResult;


            // Controlla se deve assegnare il luogo selezionato
            if ((esito == DialogResult.OK) && (!Traccia.FileInfoEsiste()))
            {
                // Assegna luogo 
                textBoxLuogo.Text = dlg.uContrLuogo1.textBoxNome.Text;
                Traccia.Luogo = textBoxLuogo.Text;

                // assegna ID luogo
                textBoxLuogoID.Text = dlg.uContrLuogo1.textBoxID.Text;
                Traccia.LuogoID = textBoxLuogoID.Text;
            }

            return GstErrori.EErrore.E0000_OK;
        }
        /// <summary>
        /// Crea in automativo la traccia
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormArchivoTraccia_Activated(object sender, EventArgs e)
        {
            // controlla se è richiesta la creazione automatica swlla traccia
            if (!PrenotaCreaTraccia)
                return;
            PrenotaCreaTraccia = false;

            // Assegna il nome dell'escursione
            textBoxNome.Text = NomeTracciaProposto(false);

            // Disabilita le opzioni
            Traccia.OptSingola = false;
            Traccia.OptGiorno = false;

            checkBoxGiorno.Checked = Traccia.OptGiorno;
            checkBoxSingola.Checked = Traccia.OptSingola;

            // Assegna il luogo dell'escursione
            Traccia.Luogo = Traccia.Escursione.Luogo;
            Traccia.LuogoID = Traccia.Escursione.LuogoID;

            textBoxLuogo.Text = Traccia.Luogo;
            textBoxLuogoID.Text = Traccia.LuogoID;

            // Aggiorna il nome della traccia
            AggiornaNomeTraccia();


            // Crea la traccia
            CreaTraccia();
        }
        /// <summary>
        /// Seleziona la prima lettera disponibile nelle tracce
        /// </summary>
        private char SelezionaLetteraDisponibile()
        {
            char lettera = 'A';


            // compone il path del file info
            string pathInfo = Traccia.GetPathInfo();


            // Compone la lista delle foto disponibili
            string[] srcList = Directory.GetFiles(pathInfo, "*.txt");

            try
            {
                // loop di analisi della directory
                foreach (string srcFile in srcList)
                {
                    // Estrae il nome del file
                    string srcFileName = srcFile.Substring(pathInfo.Length + 1);

                    // Scompone il nome della traccia
                    string[] campiNome = srcFileName.Trim().Split('_');

                    // Scompone la data
                    string[] campiData = campiNome[0].Trim().Split('-');

                    // Analizza la lettera estratta
                    if (campiData.Length >= 3)
                        if (campiData[3].ElementAt(0) >= lettera)
                            lettera = (char)(campiData[3].ElementAt(0) + 1);
                }
            }
            catch (Exception e)
            {
                return 'A';
            }

            return lettera;
        }
        /// <summary>
        /// Seleziona la prima lettera disponibile nelle tracce con la data specificata
        /// </summary>
        private char SelezionaLetteraDisponibileNelGiorno(DateTime data)
        {
            char lettera = 'A';


            // compone il path del file info
            string pathInfo = Traccia.GetPathInfo();


            // Compone la lista delle foto disponibili
            string[] srcList = Directory.GetFiles(pathInfo, "*.txt");

            try
            {
                // loop di analisi della directory
                foreach (string srcFile in srcList)
                {
                    // Estrae il nome del file
                    string srcFileName = srcFile.Substring(pathInfo.Length + 1);

                    // Scompone il nome della traccia
                    string[] campiNome = srcFileName.Trim().Split('_');

                    // Scompone la data
                    string[] campiData = campiNome[0].Trim().Split('-');

                    // ricompone la data
                    DateTime dataFile = new DateTime(Convert.ToInt32(campiData[0]), Convert.ToInt32(campiData[1]), Convert.ToInt32(campiData[2]));

                    // confronta le date
                    int resultInizio = dataFile.CompareTo(data);
                    if (resultInizio == 0)
                    {
                        // Analizza la lettera estratta
                        if (campiData.Length >= 3)
                            if (campiData[3].ElementAt(0) >= lettera)
                                lettera = (char)(campiData[3].ElementAt(0) + 1);
                    }
                }
            }
            catch (Exception e)
            {
                return 'A';
            }

            return lettera;
        }



    }
}
