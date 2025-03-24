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
    public partial class FormCopiaFoto: Form
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
        /// <summary>
        /// Data Inizio
        /// </summary>
        public DateTime DataInizio { get => dateTimePicker_DataInizio.Value; set => dateTimePicker_DataInizio.Value = value; }
        /// <summary>
        /// Ora Inizio
        /// </summary>
        public DateTime OraInizio { get => dateTimePicker_OraInizio.Value; set => dateTimePicker_OraInizio.Value = value; }
        /// <summary>
        /// Data Fine
        /// </summary>
        public DateTime DataFine { get => dateTimePicker_DataFine.Value; set => dateTimePicker_DataFine.Value = value; }
        /// <summary>
        /// Ora Fine
        /// </summary>
        public DateTime OraFine { get => dateTimePicker_OraFine.Value; set => dateTimePicker_OraFine.Value = value; }
        /// <summary>
        /// Data inizio ricerca
        /// </summary>
        private DateTime DataInizioRicerca;
        /// <summary>
        /// Data fine ricerca
        /// </summary>
        private DateTime DataFineRicerca;


        // path file sorgenti
        private string JpegSrcPath = string.Empty;
        private string HeicSrcPath = string.Empty;
        private string RawSrcPath  = string.Empty;

        // path file destinazione
        private string JpegDstPath = string.Empty;
        private string HeicDstPath = string.Empty;
        private string RawDstPath = string.Empty;


        /// <summary>
        /// Costruttore
        /// </summary>
        public FormCopiaFoto(ref CArchivioTraccia traccia)
        {
            // Assegna Archivio traccia
            Traccia = traccia;

            InitializeComponent();
            InizializzaClasse();
        }
        /// <summary>
        /// Inizializza la classe
        /// </summary>
        private void InizializzaClasse ()
        {
            // Definisce il gestore dei messaggi
            msg = new CMessaggio(ref richTextBoxOutput);

            // inizilizza data e ora di ricerca
            dateTimePicker_DataInizio.Value = new DateTime(2000, 1, 1);
            dateTimePicker_OraInizio.Value = new DateTime(2000, 1, 1, 0, 0 , 0);
            dateTimePicker_DataFine.Value = new DateTime(2001, 1, 1);
            dateTimePicker_OraFine.Value = new DateTime(2000, 1, 1, 23, 59, 59);

            // inizializza il tipo di foto
            checkBoxJPEG.Enabled = true;
            checkBoxHEIC.Enabled = true;   
            checkBoxRAW.Enabled = true;
        }
        /// <summary>
        /// Attiva l'analisi delle foto selezionate
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butAnalizza_Click(object sender, EventArgs e)
        {
            GstErrori.EErrore esito = Analizza();
        }
        /// <summary>
        /// Analizza le foto selezionate
        /// </summary>
        /// <returns></returns>
        private GstErrori.EErrore Analizza()
        {
            GstErrori.EErrore esito = GstErrori.EErrore.E0001_NOK;

            // Compone la data di inizio ricerca
            DataInizioRicerca = new DateTime(  dateTimePicker_DataInizio.Value.Year,
                                                dateTimePicker_DataInizio.Value.Month,
                                                dateTimePicker_DataInizio.Value.Day,
                                                dateTimePicker_OraInizio.Value.Hour,
                                                dateTimePicker_OraInizio.Value.Minute,
                                                dateTimePicker_OraInizio.Value.Second);

            // Compone la data di fine ricerca
            DataFineRicerca = new DateTime(    dateTimePicker_DataFine.Value.Year,
                                                dateTimePicker_DataFine.Value.Month,
                                                dateTimePicker_DataFine.Value.Day,
                                                dateTimePicker_OraFine.Value.Hour,
                                                dateTimePicker_OraFine.Value.Minute,
                                                dateTimePicker_OraFine.Value.Second);


            // Compone i path sorgenti
            esito = ComponePathSorgente();
            if (esito != GstErrori.EErrore.E0000_OK)
                return esito;

            // selezioan i file compresi nelle date di ricerca
            esito = SelezionaFile(JpegSrcPath, "JpegSel");
            if (esito != GstErrori.EErrore.E0000_OK)
                return esito;




            //// Compone la lista delle foto JPEG
            //string[] srcJpegList = Directory.GetFiles(JpegSrcPath, "*.*");


            //// loop di analisi della directory
            //foreach (string srcFile in srcJpegList)
            //{
            //    // Estrae il nome del file
            //    string srcFileName = srcFile.Substring(JpegSrcPath.Length + 1);

            //    // stampa il nome del file
            //    //msg.Stampa(srcFileName, false);

            //    // Estrae la data di creazione
            //    DateTime dataCreazione = File.GetCreationTime(srcFile);
            //    // Estrae la data di ultimo accesso
            //    DateTime dataUltimoAccesso = File.GetLastAccessTime(srcFile);
            //    // Estrae la data di ultimo accesso
            //    DateTime dataUltimaScritta = File.GetLastWriteTime(srcFile);

            //    // verifica se la data del file è successiva alla data di inizio
            //    int resultInizio = dataInizio.CompareTo(dataUltimaScritta);
            //    int resultFine = dataFine.CompareTo(dataUltimaScritta);
            //    if ((resultInizio <= 0) && (resultFine > 0))
            //    {



            //        // Sposta il file nella directory Selezione



            //        msg.Stampa(srcFileName, true);
            //    }
            //}

            return GstErrori.EErrore.E0000_OK;
        }
        /// <summary>
        /// Compone i path dell delle directory sorgente
        /// </summary>
        /// <returns></returns>
        private GstErrori.EErrore ComponePathSorgente()
        {
            JpegSrcPath = Traccia.Escursione.AreaArchivio.GetPathJpeg();
            HeicSrcPath = Traccia.Escursione.AreaArchivio.GetPathHeic();
            RawSrcPath = Traccia.Escursione.AreaArchivio.GetPathRaw();

            return GstErrori.EErrore.E0000_OK;
        }
        /// <summary>
        /// seleziona i file dalla directory specificata
        /// </summary>
        /// <param name="fileSrcPath"></param>
        /// <returns></returns>
        private GstErrori.EErrore SelezionaFile(string fileSrcPath, string keySeleziona)
        {
            // Compone la lista delle foto
            string[] srcList = Directory.GetFiles(fileSrcPath, "*.*");

            // Recupera il subPath di selezione 
            string[] cSelezionaSubPath = Traccia.Escursione.AreaArchivio.Directory.Area.GetSubPath(keySeleziona).Split('\\');
            string selezionaSubPath = cSelezionaSubPath[1];

            // Stampa inizio slelezione
            msg.Stampa("");
            msg.Stampa("=================================================================================================");
            msg.Stampa("Inizio Selezione foto: " + cSelezionaSubPath[0]);
            msg.Stampa("");

            // loop di analisi della directory
            foreach (string srcFile in srcList)
            {
                // Estrae il nome del file
                string srcFileName = srcFile.Substring(fileSrcPath.Length + 1);

                // Estrae la data di creazione
                DateTime dataCreazione = File.GetCreationTime(srcFile);
                // Estrae la data di ultimo accesso
                DateTime dataUltimoAccesso = File.GetLastAccessTime(srcFile);
                // Estrae la data di ultimo accesso
                DateTime dataUltimaScritta = File.GetLastWriteTime(srcFile);

                // verifica se la data del file è successiva alla data di inizio
                int resultInizio = DataInizioRicerca.CompareTo(dataUltimaScritta);
                int resultFine = DataFineRicerca.CompareTo(dataUltimaScritta);
                if ((resultInizio <= 0) && (resultFine > 0))
                {
                    // crea il path di destinazione in selezione
                    string dstFile = fileSrcPath + SeparaDir + selezionaSubPath + SeparaDir + srcFileName;

                    // stampa il nome del file selezionato
                    msg.Stampa("Selezionato: " + srcFileName, true);

                    try
                    {
                        // Sposta il file nella directory Selezione
                        //======================================

                        // Sposta il file nella directory Selezione
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
                    }
                }
            }

            return GstErrori.EErrore.E0000_OK;
        }
    }
}
