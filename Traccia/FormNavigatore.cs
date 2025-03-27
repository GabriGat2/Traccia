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
    public partial class FormNavigatore: Form
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

            // verifica se il file info della traccia esiste
            //GstErrori.EErrore esito = LeggeFileInfoTraccia(comboBoxNavigatore.Text);
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
            StampaOperazione(true, operazione);

            // esegue la selezine
            GstErrori.EErrore esito = AssegnaFile2();

            // stampa fine operazioni
            StampaOperazione(false, operazione, esito);

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
        /// Stampa l'operazione in corso
        /// </summary>
        /// <param name="inizio"></param>
        /// <param name="operazione"></param>
        /// <param name="esito"></param>
        /// <returns></returns>
        private GstErrori.EErrore StampaOperazione(bool inizio, string operazione, GstErrori.EErrore esito = GstErrori.EErrore.E0000_OK)
        {
            // stampa righe di separazione
            msg.Stampa("");

            // stampa operazione
            if (inizio)
            {
                msg.Stampa("=================================================================================================");
                msg.Stampa("Inizio " + operazione);
                msg.Stampa("-------------------------------------------------------------------------------------------------");

            }
            else
            {
                msg.Stampa("-------------------------------------------------------------------------------------------------");
                msg.Stampa("Fine " + operazione);

                // stampa l'esito dell'operazione
                if (esito == GstErrori.EErrore.E0000_OK)
                    msg.Stampa("L'operazione è stata completata con successo");
                else
                    msg.Stampa("L'operazione è FALLITA a causa dell'errore: " + esito.ToString());

                msg.Stampa("=================================================================================================");
            }

            // stampa righe di separazione
            msg.Stampa("");

            return esito;
        }
        /// <summary>
        /// Genera il file info del navigatore
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butGenera_Click(object sender, EventArgs e)
        {
            ScriveFileInfoNavigatore(comboBoxNavigatore.Text);
        }
        /// <summary>
        /// legge il file info del navigatore
        /// </summary>
        /// <param name="navigatore"></param>
        /// <returns></returns>
        private GstErrori.EErrore LeggeFileInfoNavigatore(string navigatore)
        {
            //// Compone il nome del file info del navigatore
            //string nomeFileNav = Traccia.Nome + "_" + navigatore + ".txt";

            ////  Compone il path nome del file info del navigatore
            //string pathFileNav = Traccia.GetPathTracciaInfo() + SeparaDir + nomeFile;

            //string line = string.Empty;
            //try
            //{
            //    // Pass the file path and file name to the StreamReader constructor
            //    StreamReader sr = new StreamReader(pathFileNav);
            //    // legge la prima linea del file
            //    line = sr.ReadLine();


            //    // Continue to read until you reach end of file
            //    while (line != null)
            //    {
            //        // scompone la riga letta
            //        string[] campo = line.Trim().Split('=');

            //        // verifica la dimensione di campi
            //        if (campo.Length != 3)
            //            continue;

            //        // analizza gruppo di informazione
            //        switch (AnalizzaGeuppoInfo(campo[0]))
            //        {
            //            case EGruppoInfo.Area:
            //                break;

            //            case EGruppoInfo.Escursione:
            //                break;

            //            case EGruppoInfo.Traccia:
            //                // Assegna l'informazione ricevuta
            //                Traccia.Set(campo[1], campo[2]);
            //                break;

            //            default:
            //                continue;
            //        }

            //        // Read the next line
            //        line = sr.ReadLine();
            //    }

            //    // Chiude il file
            //    sr.Close();
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine("Exception: " + e.Message);
            //    return GstErrori.EErrore.E0001_NOK;
            //}




            return GstErrori.EErrore.E0000_OK;
        }
        /// <summary>
        /// Scrive il file info del navigatore
        /// </summary>
        /// <param name="navigatore"></param>
        /// <returns></returns>
        private GstErrori.EErrore ScriveFileInfoNavigatore(string navigatore)
        {
            // Compone il nome del file info del navigatore
            string nomeFileNav = "Nav" + "_" + Traccia.Nome;

            //  Compone il path nome del file info del navigatore
            string pathFileNav = Traccia.GetPathTracciaInfo() + SeparaDir + nomeFileNav + ".txt";

            //  Compone il path nome del file info temporaneo del navigatore
            string pathFileTmp = Traccia.GetPathTracciaInfo() + SeparaDir + "Nav_tmp.txt";

            //  Compone il path nome del file info temporaneo del navigatore
            string pathFileBak = Traccia.GetPathTracciaInfo() + SeparaDir + nomeFileNav + ".bak";

            string lineaInfo;
            try
            {
                //File.Replace()

                // Apre lo il file da scrivere
                StreamWriter sw = new StreamWriter(pathFileTmp);

                // stampa il nome del navigatore                    
                lineaInfo = navigatore + "=" + "Nome" + "=" + navigatore;
                sw.WriteLine(lineaInfo);

                // Stampa il link al navigatore
                lineaInfo = navigatore + "=" + "Link" + "=" + textBoxLink.Text;
                sw.WriteLine(lineaInfo);

                // Stampa la descrizione
                string descrizione = richTextBoxDescrizione.Text;
                string [] righe = descrizione.Split('\n');
                for (int i = 0; i < righe.Length; i++)
                {
                    lineaInfo = navigatore + "=" + "Descrizione" + "=" + righe[i];
                    sw.WriteLine(lineaInfo);
                }

                // legge il file info esistente
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
                            // verifica il gruppo navigatore
                            if (navigatore != campo[0])
                                sw.WriteLine(lineaInfo);
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
    }
}
