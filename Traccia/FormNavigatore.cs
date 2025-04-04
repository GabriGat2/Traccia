using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Traccia
{
    public partial class FormNavigatore : Form
    {
        /// <summary>
        /// Archivio Traccia
        /// </summary>
        public CArchivioTraccia Traccia = new CArchivioTraccia();
        /// Gestore per la stampa dei messaggi
        /// </summary>
        private CMessaggio msg = null;
        /// <summary>
        /// Speratore per path
        /// </summary>
        protected const string SeparaDir = "\\";

        // path directory
        private string PathDisponibili = string.Empty;
        private string PathStampe = string.Empty;
        private string PathTracce = string.Empty;
        private string PathResoconto = string.Empty;
        private string PathInfo = string.Empty;

        /// <summary>
        /// Oggetto per gestire l'aggiornamento automatico del file info del navigatore
        /// </summary>
        private CAggiornamentoInfo AggiornamentoInfo = new CAggiornamentoInfo();

        /// <summary>
        /// Costruttore
        /// </summary>
        public FormNavigatore(ref CArchivioTraccia traccia)
        {
            // Assegna Archivio traccia
            Traccia = traccia;

            InitializeComponent();
            InizializzaClasse();
        }
        /// <summary>
        /// Inizializza la classe
        /// </summary>
        private void InizializzaClasse()
        {
            // Definisce il gestore dei messaggi
            msg = new CMessaggio(ref richTextBoxOutput);

            // Popola la combo box Navigatore
            PopolaNavigatore();
            comboBoxNavigatore.SelectedIndex = 0;

            // Abilita files
            ucFiles.Abilita = true;

            // Stampa Nome e path della traccia
            textBoxNomeTraccia.Text = Traccia.Nome;
            textBoxPathTraccia.Text = Traccia.Path;

            // abilita aggiornamento automatico
            checkBoxAggiorna.Checked = true;
        }
        /// <summary>
        /// Aggiorna la classe
        /// </summary>
        public void AggiornaClasse()
        {
            // compone i path delle directory
            ComponePath();

            // Aggiorna i contatori delle directory
            AggiornaContatori();
        }
        /// <summary>
        /// Compone i path
        /// </summary>
        /// <returns></returns>
        public GstErrori.EErrore ComponePath()
        {
            // disponibili
            PathDisponibili = Traccia.Escursione.AreaArchivio.GetPathInput();
            ucFiles.PathDisponibili = PathDisponibili;

            // Stampe
            PathStampe = Traccia.Path + SeparaDir + Traccia.Escursione.AreaArchivio.Directory.Traccia.GetSubPath("Stampe");
            ucFiles.PathStampe = PathStampe;

            // Tracce
            PathTracce = Traccia.Path + SeparaDir + Traccia.Escursione.AreaArchivio.Directory.Traccia.GetSubPath("Tracce");
            ucFiles.PathTracce = PathTracce;

            // Resoconto
            PathResoconto = Traccia.Path + SeparaDir + Traccia.Escursione.AreaArchivio.Directory.Traccia.GetSubPath("Resoconto");
            ucFiles.PathResoconto = PathResoconto;

            // Info
            PathInfo = Traccia.Path + SeparaDir + Traccia.Escursione.AreaArchivio.Directory.Traccia.GetSubPath("Info");

            return GstErrori.EErrore.E0000_OK;
        }
        /// <summary>
        /// Aggiorna i contatori delle directory
        /// </summary>
        private GstErrori.EErrore AggiornaContatori()
        {
            string[] srcList = null;

            ucFiles.Aggiorna();

            return GstErrori.EErrore.E0000_OK;
        }
        /// <summary>
        /// Attiva la finestra explorer, se esiste, al path della traccia
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butExplorerTraccia_Click(object sender, EventArgs e)
        {
            ApreExplorer(Traccia.Path);
        }
        /// <summary>
        /// Ape la pagina web indicata
        /// </summary>
        /// <param name="link"></param>
        private void AprePaginaWeb(string link)
        {
            string target = link;
            string arg1 = string.Empty;
            EsegueProces(target, arg1);
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
        /// Attiva la rinomina e l'assegnazione dei file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butAssegna_Click(object sender, EventArgs e)
        {
            AssegnaFile();
        }
        /// <summary>
        /// Rinomina e assegna i file
        /// </summary>
        /// <returns></returns>
        private GstErrori.EErrore AssegnaFile()
        {
            // compone operazione
            string operazione = "assegna file";

            // stampa inizio operazioni
            msg.StampaOperazione(true, operazione);

            // esegue la selezine
            GstErrori.EErrore esito = AssegnaFile2();

            // stampa fine operazioni
            msg.StampaOperazione(false, operazione, esito);

            // Aggiorna la classe
            AggiornaClasse();

            return esito;
        }
        /// <summary>
        /// Assegna i file Selezionati directory della traccia corrispondente
        /// </summary>
        /// <param name="pathSelezionati"></param>
        /// <param name="pathAssegnati"></param>
        /// <param name="pathCopiati"></param>
        /// <returns></returns>
        private GstErrori.EErrore AssegnaFile2()
        {
            string dstDir = string.Empty;

            // Compone la lista dei file disponibili
            string[] srcList = Directory.GetFiles(PathDisponibili, "*.*");

            // loop di analisi della directory
            foreach (string srcFile in srcList)
            {
                // Estrae il nome del file
                string srcFileName = srcFile.Substring(PathDisponibili.Length + 1);

                // Estrae l'estensione del file
                string[] campi = srcFileName.Split('.');
                string estensione = campi[1].Trim().ToLower();

                // sceglie la directory di destinazione
                switch (estensione)
                {

                    case "bmp":
                    case "gif":
                    case "heic":
                    case "jpe":
                    case "jpeg":
                    case "jpg":
                    case "png":
                    case "tiff":
                        dstDir = PathStampe;
                        break;

                    case "gpx":
                    case "kml":
                    case "fit":
                        dstDir = PathTracce;
                        break;

                    case "doc":
                    case "docx":
                    case "pdf":
                        dstDir = PathResoconto;
                        break;

                    default:
                        continue;
                }

                // compone il nuovo nome
                string nuovoNome = Traccia.Nome + "." + estensione;
                // compone path nome nuovo
                string pathNuovoNome = dstDir + SeparaDir + nuovoNome;
                // dichiara la lettera di postfisso
                char lettera = 'a';

                // Trova la lettera di postifisso
                bool cercaLettera = true;
                while (cercaLettera)
                {
                    // controlla se esiste un file con questo nome
                    if (!File.Exists(pathNuovoNome))
                        break;

                    // Incrementa la lettera di postfisso
                    lettera++;

                    // ricompone il nuovo nome
                    nuovoNome = Traccia.Nome + "_" + lettera + "." + estensione;
                    // ricompone il path del nome nuovo
                    pathNuovoNome = dstDir + SeparaDir + nuovoNome;
                }

                // stampa il nome del file selezionato
                msg.Stampa("Rinominato: >" + srcFileName + "< in >" + nuovoNome + "<");

                try
                {
                    // Copia e rinomina il file nella directory di destinazione
                    File.Copy(srcFile, pathNuovoNome);

                    // Verifica che il file esista nella directory destinazione
                    if (!File.Exists(pathNuovoNome))
                        return GstErrori.EErrore.E1355_FileNonSpostato;

                    // Elimina il file nella directory dei disponibili
                    File.Delete(srcFile);

                    // Verifica che il file sia stato cancellato dai file disponibili
                    if (File.Exists(srcFile))
                        return GstErrori.EErrore.E1359_FileNonCancellato;
                }
                catch (Exception e)
                {
                    msg.Stampa("The process failed: {0}" + e.ToString());
                    return GstErrori.EErrore.E0001_NOK;
                }
            }

            return GstErrori.EErrore.E0000_OK;
        }
        /// <summary>
        /// Popola la combo box Navigatore
        /// </summary>
        private void PopolaNavigatore()
        {
            // recupera il path della directory comune e aggiunge il nome del filee
            string pathNavigatore = Traccia.Escursione.AreaArchivio.GetPathComune() + "\\" + "Navigatore.txt";

            String line;
            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader(pathNavigatore);

                //Read the first line of text
                line = sr.ReadLine();

                //Continue to read until you reach end of file
                while (line != null)
                {
                    //write the line to console window
                    msg.Stampa(line);

                    // Aggiunge line a combobox
                    comboBoxNavigatore.Items.Add(line);

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
        /// Genera il file info del navigatore
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butGenera_Click(object sender, EventArgs e)
        {
            // sospende l'aggiornamento automatico
            AggiornamentoInfo.Sospende(true);

            ScriveFileInfoNavigatore(comboBoxNavigatore.Text);

            // ripristina l'aggiornamento automatico
            AggiornamentoInfo.Sospende(false);

        }
        /// <summary>
        /// legge il file info del navigatore
        /// </summary>
        /// <param name="navigatore"></param>
        /// <returns></returns>
        private GstErrori.EErrore LeggeFileInfoNavigatore(string navigatore)
        {
            GstErrori.EErrore esito = GstErrori.EErrore.E0001_NOK;

            // Compone il nome del file info del navigatore
            string nomeFileNav = "Nav" + "_" + Traccia.Nome;

            //  Compone il path nome del file info del navigatore
            string pathFileNav = Traccia.GetPathTracciaInfo() + SeparaDir + nomeFileNav + ".txt";

            string lineaInfo = string.Empty;
            try
            {

                // legge il file info esistente
                if (!File.Exists(pathFileNav))
                {
                    // il file non esite
                    return GstErrori.EErrore.E1350_FileNonEsiste;
                }
                else
                {
                    // apre il file info 
                    StreamReader sr = new StreamReader(pathFileNav);

                    // legge la prima linea del file
                    lineaInfo = sr.ReadLine();

                    // continua a leggere finchè non ragiunge EOF
                    while (lineaInfo != null)
                    {
                        // scompone la riga letta
                        //string[] campo = lineaInfo.Trim().Split('=');
                        string[] campo = ScomponeLinea(lineaInfo);

                        // verifica la dimensione di campo
                        if (campo.Length == 3)
                        {
                            // verifica il gruppo navigatore
                            if (navigatore == campo[0])
                            {
                                switch (campo[1])
                                {
                                    case "Nome":
                                        esito = GstErrori.EErrore.E0000_OK;
                                        break;

                                    case "Link":
                                        textBoxLink.Text = campo[2];
                                        break;

                                    case "Descrizione":
                                        richTextBoxDescrizione.AppendText(campo[2] + "\n");
                                        break;

                                    default:
                                        break;
                                }
                            }
                        }

                        // legga una nuova linea
                        lineaInfo = sr.ReadLine();
                    }

                    // Chiude il file in lettura
                    sr.Close();

                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
                return GstErrori.EErrore.E0001_NOK;
            }

            return esito;
        }
        /// <summary>
        ///  Scompone una linea del file info
        /// </summary>
        /// <param name="linea"></param>
        private string [] ScomponeLinea(string linea)
        {
            // scompone la riga letta
            string[] campo = linea.Trim().Split('=');

            // verifica in quanti scampi è stata scomposta la linea
            if (campo.Length > 3)
            {
                string campo3 = campo[2];
                for (int i = 3; i < campo.Length; i++)
                {
                    campo3 += "=" + campo[i];
                }

                // ricompone i nuovi campi
                string[] NuovoCampo = new string[3];
                NuovoCampo[0] = campo[0];
                NuovoCampo[1] = campo[1];
                NuovoCampo[2] = campo3;

                // rende nuovoCampo
                return NuovoCampo;
            }

            // rende campo
            return campo;

        }
        /// <summary>
        /// Scrive il file info del navigatore
        /// </summary>
        /// <param name="navigatore"></param>
        /// <returns></returns>
        private GstErrori.EErrore ScriveFileInfoNavigatore(string navigatore)
        {
            // compone operazione
            string operazione = "scrive file info del navigatore ";

            // stampa inizio operazioni
            msg.StampaOperazione(true, operazione);

            // esegue la selezine
            GstErrori.EErrore esito = ScriveFileInfoNavigatore2(navigatore);

            // stampa fine operazioni
            msg.StampaOperazione(false, operazione, esito);

            return esito;

        }
        /// <summary>
        /// Scrive il file info del navigatore
        /// </summary>
        /// <param name="navigatore"></param>
        /// <returns></returns>
        private GstErrori.EErrore ScriveFileInfoNavigatore2(string navigatore)
        {
            // Compone il nome del file info del navigatore
            string nomeFileNav = "Nav" + "_" + Traccia.Nome;

            //  Compone il path nome del file info del navigatore
            string pathFileNav = Traccia.GetPathTracciaInfo() + SeparaDir + nomeFileNav + ".txt";

            //  Compone il path nome del file info temporaneo del navigatore
            string pathFileTmp = Traccia.GetPathTracciaInfo() + SeparaDir + "Nav_tmp.txt";

            //  Compone il path nome del file info temporaneo del navigatore
            string pathFileBak = Traccia.GetPathTracciaInfo() + SeparaDir + nomeFileNav + ".bak";

            // Aggiorna i campi delle info del navigatore
            bool bEsito;
            bEsito = Traccia.Escursione.ScriveInfo();
            //bEsito = Traccia.Escursione.Info.Navigatore.Set("Nome", navigatore);
            //bEsito = Traccia.Escursione.Info.Navigatore.Set("Link", textBoxLink.Text);

            // scrive il file info del navigatore
            GstErrori.EErrore esito = Traccia.Escursione.Info.ScriveFileInfoNavigatore(pathFileTmp);



            string lineaInfo;
            try
            {
                StreamWriter sw;
                // verifica se esiste il file temporaneo
                if (! File.Exists(pathFileNav))
                {
                    // apre in modo append il file temporaneo
                    sw = File.CreateText(pathFileTmp);
                }
                else
                {
                    // crea il file temporaneo
                    sw = File.AppendText(pathFileTmp);
                }

                //StreamWriter sw = new StreamWriter(pathFileTmp);

                // stampa il nome del navigatore                    
                lineaInfo = navigatore + "=" + "Nome" + "=" + navigatore;
                sw.WriteLine(lineaInfo);

                // Stampa il link al navigatore
                lineaInfo = navigatore + "=" + "Link" + "=" + textBoxLink.Text;
                sw.WriteLine(lineaInfo);

                // Stampa la descrizione
                string descrizione = richTextBoxDescrizione.Text;
                string[] righe = descrizione.Split('\n');
                for (int i = 0; i < righe.Length; i++)
                {
                    lineaInfo = navigatore + "=" + "Descrizione" + "=" + righe[i];
                    sw.WriteLine(lineaInfo);
                }

                // verifica se esite il file info del navigatore
                if (File.Exists(pathFileNav))
                {
                    // apre il file info esistente
                    StreamReader sr = new StreamReader(pathFileNav);

                    // legge la prima linea del file
                    lineaInfo = sr.ReadLine();

                    // continua a leggere finchè non ragiunge EOF
                    while (lineaInfo != null)
                    {
                        // scompone la riga letta
                        string[] campo = lineaInfo.Trim().Split('=');

                        // verifica la dimensione di campo
                        if (campo.Length > 0)
                        {
                            // verifica se è un gruppo base
                            if (Traccia.Escursione.Info.VerificaGruppoNavigatore(campo[0]))
                            {
                                // verifica il gruppo navigatore
                                if (navigatore != campo[0])
                                    sw.WriteLine(lineaInfo);
                            }
                        }

                        // legg una nuova linea
                        lineaInfo = sr.ReadLine();
                    }

                    // Chiude il file in lettura
                    sr.Close();

                    // Chiude il file in scrittura
                    sw.Close();

                    // sostituisci il file info di navigazione
                    File.Replace(pathFileTmp, pathFileNav, pathFileBak);
                }
                else
                {
                    // Chiude il file in scrittura
                    sw.Close();

                    // Rinomina il file info tmp
                    File.Move(pathFileTmp, pathFileNav);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
                return GstErrori.EErrore.E0001_NOK;
            }

            return GstErrori.EErrore.E0000_OK;
        }
        /// <summary>
        ///  Apre la pagina WEB specificata
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buInternetNavigatore_Click(object sender, EventArgs e)
        {
            // recupera il link
            string link = textBoxLink.Text;
            AprePaginaWeb(link);

        }
        /// <summary>
        /// Copia il nome della traccia nella clipboard
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butCBCopiaNomeTraccia_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBoxNomeTraccia.Text);
        }
        /// <summary>
        /// Assegna al link il contenuto della clipboard
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butCBIncollaLink_Click(object sender, EventArgs e)
        {
            textBoxLink.Text = Clipboard.GetText();
        }
        /// <summary>
        /// Assegna alla descrizione il contenuto della clipboard
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butCBIncollaDescrizione_Click(object sender, EventArgs e)
        {
            richTextBoxDescrizione.Text = Clipboard.GetText();
        }
        // Cambiato il tipo di navigatore selezionato
        private void comboBoxNavigatore_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApreFileInfoNavigatore();
        }
        /// <summary>
        /// Apre il file info del navigtore selezionato,
        /// se non esiste lo crea.
        /// </summary>
        /// <returns></returns>
        private GstErrori.EErrore ApreFileInfoNavigatore()
        {
            // compone operazione
            string operazione = "legge file info navigatore ";

            // stampa inizio operazioni
            msg.StampaOperazione(true, operazione);

            // esegue la selezine
            GstErrori.EErrore esito = ApreFileInfoNavigatore2();

            // stampa fine operazioni
            msg.StampaOperazione(false, operazione, esito);

            return esito;

        }
        /// <summary>
        /// Apre il file info del navigtore selezionato,
        /// se non esiste lo crea.
        /// </summary>
        /// <returns></returns>
        private GstErrori.EErrore ApreFileInfoNavigatore2()
        {
            GstErrori.EErrore esito;

            // controlla se c'è una prenotazione 
            esito = AggiornaFileInfo();
            if (esito != GstErrori.EErrore.E0000_OK)
                return esito;

            // Sospende aggiornamento automatico file info
            AggiornamentoInfo.Sospende(true);
            //if (aggiornamentoInfo != EAggiornamentoInfo.Disabilitato)
            //    aggiornamentoInfo = EAggiornamentoInfo.Sospeso;

            // inizializza i cmapi link e destrizione
            textBoxLink.Text = "";
            richTextBoxDescrizione.Clear();

            // estra il nome del navigatore
            string navigatore = comboBoxNavigatore.Text;

            // verifica se esite  il file info del navigatore selezionato
            esito = LeggeFileInfoNavigatore(navigatore);
            if (esito != GstErrori.EErrore.E0000_OK)
            {
                // inizializza i cmapi link e destrizione
                textBoxLink.Text = "";
                richTextBoxDescrizione.Clear();

                // il file non esite quidi lo crea
                esito = ScriveFileInfoNavigatore(navigatore);
            }

            // Rimuove la sospensione dell'aggiornamento automatico
            AggiornamentoInfo.Sospende(false);
            //if (aggiornamentoInfo != EAggiornamentoInfo.Disabilitato)
            //    aggiornamentoInfo = EAggiornamentoInfo.Libero;

            return esito;
        }
        /// <summary>
        /// Il campo link è cambiato 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxLink_TextChanged(object sender, EventArgs e)
        {
            // prenota l'aggiornamento del file info del navigatore
            AggiornamentoInfo.Prenota(comboBoxNavigatore.Text);
            //PrenotaAggiornamentoFileInfo();
        }
        /// <summary>
        /// Aggiorna l'abilitazione all'aggiornamento del file info
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxAggiorna_CheckedChanged(object sender, EventArgs e)
        {
            AggiornamentoInfo.Abilita(checkBoxAggiorna.Checked);
            //if (checkBoxAggiorna.Checked)
            //    aggiornamentoInfo = EAggiornamentoInfo.Libero;
            //else
            //    aggiornamentoInfo = EAggiornamentoInfo.Disabilitato;
        }
        /// <summary>
        /// Esegue aggiornamento file info
        /// </summary>
        private GstErrori.EErrore AggiornaFileInfo()
        {
            GstErrori.EErrore esito = GstErrori.EErrore.E0000_OK;

            // controlla se è prenotato l'aggiornamento del file info del navigatore
            if (AggiornamentoInfo.Prenotato)
            {
                // rimuove la prenotazione
                AggiornamentoInfo.Libera();

                // esegue aggiornamento
                esito = ScriveFileInfoNavigatore(AggiornamentoInfo.Navigatore);
            }

            return esito;
        }
        /// <summary>
        /// Generato quando si sta chiudendo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormNavigatore_FormClosing(object sender, FormClosingEventArgs e)
        {
            AggiornaFileInfo();
        }
        /// <summary>
        /// Crea e apre il file resoconto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butResoconto_Click(object sender, EventArgs e)
        {
            ApreFileResoconto();
        }
        /// <summary>
        /// Apre il file resoconto, se non c'è lo crea
        /// </summary>
        /// <returns></returns>

        private GstErrori.EErrore ApreFileResoconto()
        {
            GstErrori.EErrore esito = GstErrori.EErrore.E0001_NOK;

            // compone il nome del file resoconto
            string resocontoFileName = Traccia.Nome + ".odt";

            // compone il path del nome del file resoconto
            string resocontoPathName = PathResoconto + SeparaDir + resocontoFileName;

            // verifica se il file resoconto esiste
            if (!File.Exists(resocontoPathName))
            {
                // Il file resoconto non esiste lo copia

                // Crea il path dei file resocondo modello
                string resocontoPathModello = Traccia.Escursione.AreaArchivio.GetPathComune() + SeparaDir + "Resoconto.odt";

                // copia il file modello e rinominalo
                try
                {
                    // Copia e rinomina il file nella directory di destinazione
                    File.Copy(resocontoPathModello, resocontoPathName);

                    // Verifica che il file esista nella directory destinazione
                    if (!File.Exists(resocontoPathName))
                        return GstErrori.EErrore.E1355_FileNonSpostato;
                }
                catch (Exception e)
                {
                    msg.Stampa("The process failed: {0}" + e.ToString());
                    return GstErrori.EErrore.E0001_NOK;
                }
            }

            // apre il file resoconto
            ApreWord(resocontoPathName);

            return esito;
        }
        /// <summary>
        /// Apre word
        /// </summary>
        /// <param name="link"></param>
        private void ApreWord(string pathName)
        {
            string target = "winword";
            string arg1 = "/t " + pathName;
            EsegueProces(target, arg1);
        }

        private void butPreleva_Click(object sender, EventArgs e)
        {
            PrelevaDaDownload();
        }
        /// <summary>
        /// Preleva i file disponibili nella directory dowload
        /// </summary>
        /// <returns></returns>
        private GstErrori.EErrore PrelevaDaDownload()
        {
            // compone operazione
            string operazione = "preleva file dalla directory download ";

            // stampa inizio operazioni
            msg.StampaOperazione(true, operazione);

            // esegue la selezine
            GstErrori.EErrore esito = PrelevaDaDowload2();

            // stampa fine operazioni
            msg.StampaOperazione(false, operazione, esito);

            return esito;

        }
        /// <summary>
        /// Preleva i file disponibili nella directory download
        /// </summary>
        /// <returns></returns>
        private GstErrori.EErrore PrelevaDaDowload2()
        {
            GstErrori.EErrore esito = GstErrori.EErrore.E0001_NOK;

            // compone il path della directory dowload
            string pathDownloads = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");

            // definisce il delta di minuti di ricenrca
            double minuti = 5;

            // Compone la data di inizio ricerca
            DateTime DataInizioRicerca = DateTime.Now.AddMinutes(-minuti);

            // Compone la data di fine ricerca
            DateTime DataFineRicerca = DateTime.Now.AddMinutes(minuti);

            // Compone la lista delle foto disponibili
            string[] srcList = Directory.GetFiles(pathDownloads, "*.*");

            // loop di analisi della directory
            foreach (string srcFile in srcList)
            {
                // Estrae il nome del file
                string srcFileName = srcFile.Substring(pathDownloads.Length + 1);

                // Estrae la data di ultimo accesso
                DateTime dataUltimaScritta = File.GetLastWriteTime(srcFile);

                // verifica se la data del file è compresa nel tempo di ricerca
                int resultInizio = DataInizioRicerca.CompareTo(dataUltimaScritta);
                int resultFine = DataFineRicerca.CompareTo(dataUltimaScritta);
                if ((resultInizio <= 0) && (resultFine > 0))
                {
                    // crea il path di destinazione in Disponibili
                    string dstFile = PathDisponibili + SeparaDir + srcFileName;

                    // stampa il nome del file selezionato
                    msg.Stampa("Selezionato: " + srcFileName, true);

                    try
                    {
                        // Sposta il file nella directory Selezione
                        //======================================

                        // Sposta il file nella directory disponibile
                        File.Move(srcFile, dstFile);


                        // Verifica che il file esista nella directory destinazione
                        if (!File.Exists(dstFile))
                            return GstErrori.EErrore.E1355_FileNonSpostato;

                        // Verifica che il file non esista nella directory sorgente
                        if (File.Exists(srcFile))
                            return GstErrori.EErrore.E1355_FileNonSpostato;
                    }
                    catch (Exception e)
                    {
                        msg.Stampa("The process failed: {0}" + e.ToString());
                        return GstErrori.EErrore.E0001_NOK;
                    }
                }
            }

            return GstErrori.EErrore.E0000_OK;
        }
        /// <summary>
        /// Il campo descrizione è cambiato
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void richTextBoxDescrizione_TextChanged(object sender, EventArgs e)
        {
            // prenota l'aggiornamento del file info del navigatore
            AggiornamentoInfo.Prenota(comboBoxNavigatore.Text);
            //PrenotaAggiornamentoFileInfo();
        }

    }


    // ======================================================================================================================
    // ======================================================================================================================
    // ======================================================================================================================

    public class CAggiornamentoInfo
    {
        /// <summary>
        /// Stati dell'aggiornamento automatico del file info
        /// </summary>
        private enum EAggiornamentoInfo
        {
            Disabilitato,
            Sospeso,
            Libero,
            prenotato
        };
        /// <summary>
        /// Gestione aggiornamento automatico file info
        /// </summary>
        private EAggiornamentoInfo aggiornamentoInfo = EAggiornamentoInfo.Disabilitato;
        /// <summary>
        /// Tipo del navigatore che ha prenotato l'aggiornamento
        /// </summary>
        public string Navigatore { get => navigatore;}
        private string navigatore = string.Empty;
        /// <summary>
        /// Stato della prenotazione
        /// </summary>
        public bool Prenotato { get => (aggiornamentoInfo == EAggiornamentoInfo.prenotato); }


        /// <summary>
        /// Costruttore
        /// </summary>
        public CAggiornamentoInfo()
        {
            Abilita(false);
        }
        /// <summary>
        /// Abilita / disabilita l'aggiornamento automatico del file info
        /// </summary>
        /// <param name="abilita"></param>
        public void Abilita (bool abilita)
        {
            if (abilita)
                aggiornamentoInfo = EAggiornamentoInfo.Libero;
            else
                aggiornamentoInfo = EAggiornamentoInfo.Disabilitato;
        }
        /// <summary>
        /// Prenota l'aggiornamento del file info
        /// </summary>
        /// <param name="tipoNavigatore"></param>
        public void Prenota(string tipoNavigatore)
        {
            // prenota l'aggiornamento del file info del navigatore
            if (aggiornamentoInfo == EAggiornamentoInfo.Libero)
            {
                aggiornamentoInfo = EAggiornamentoInfo.prenotato;
                navigatore = tipoNavigatore;
            }
        }
        /// <summary>
        /// Abilita / disabilita la sospensione del file info
        /// </summary>
        public void Sospende(bool abilita)
        {
            // Sospende aggiornamento automatico file info
            if (aggiornamentoInfo != EAggiornamentoInfo.Disabilitato)
            {
                if (abilita)
                    aggiornamentoInfo = EAggiornamentoInfo.Sospeso;
                else
                    aggiornamentoInfo = EAggiornamentoInfo.Libero;

            }
        }
        /// <summary>
        /// Abilita l'aggiornamento del file info
        /// </summary>
        public void Libera()
        {
            // Attiva aggiornamento automatico file info
            if (aggiornamentoInfo == EAggiornamentoInfo.prenotato)
                aggiornamentoInfo = EAggiornamentoInfo.Libero;
        }

    }




}
