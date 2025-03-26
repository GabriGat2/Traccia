using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Traccia
{
    public partial class FormFoto : Form
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


        // path file sorgenti JPEG 
        private string JpegPathDisponibili = string.Empty;
        private string JpegPathCopiati = string.Empty;
        private string JpegPathSelezionati = string.Empty;
        private string JpegPathAssegnati = string.Empty;

        // path file sorgenti HEIC
        private string HeicPathDisponibili = string.Empty;
        private string HeicPathCopiati = string.Empty;
        private string HeicPathSelezionati = string.Empty;
        private string HeicPathAssegnati = string.Empty;

        // path file sorgenti RAW
        private string RawPathDisponibili = string.Empty;
        private string RawPathCopiati = string.Empty;
        private string RawPathSelezionati = string.Empty;
        private string RawPathAssegnati = string.Empty;


        //private string RawPathDisponibili  = string.Empty;

        //// path file destinazione
        //private string JpegDstPath = string.Empty;
        //private string HeicDstPath = string.Empty;
        //private string RawDstPath = string.Empty;


        /// <summary>
        /// Costruttore
        /// </summary>
        public FormFoto(ref CArchivioTraccia traccia)
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

            // inizilizza data e ora di ricerca
            dateTimePicker_DataInizio.Value = new DateTime(2000, 1, 1);
            dateTimePicker_OraInizio.Value = new DateTime(2000, 1, 1, 0, 0, 0);
            dateTimePicker_DataFine.Value = new DateTime(2001, 1, 1);
            dateTimePicker_OraFine.Value = new DateTime(2000, 1, 1, 23, 59, 59);

            // inizializza il tipo di foto
            ucFotoJpeg.Nome = "JPEG";
            ucFotoJpeg.Abilita = true; ;

            ucFotoHeic.Nome = "HEIC";
            ucFotoHeic.Abilita = true; ;

            ucFotoRaw.Nome = "RAW";
            ucFotoRaw.Abilita = true; ;
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
        /// Aggiorna i contatori delle directory
        /// </summary>
        private GstErrori.EErrore AggiornaContatori()
        {
            //GstErrori.EErrore esito = GstErrori.EErrore.E0001_NOK;

            // Aggiorna contatori foto
            ucFotoJpeg.Aggiorna();
            ucFotoHeic.Aggiorna();
            ucFotoRaw.Aggiorna();

            return GstErrori.EErrore.E0000_OK;
        }
        /// <summary>
        /// Attiva la selezione delle foto selezionate
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butSelezione_Click(object sender, EventArgs e)
        {
            GstErrori.EErrore esito = SelezioneFoto();
        }
        /// <summary>
        /// Seleziona le foto
        /// </summary>
        /// <returns></returns>
        private GstErrori.EErrore SelezioneFoto()
        {
            GstErrori.EErrore esito = GstErrori.EErrore.E0001_NOK;

            // Compone la data di inizio ricerca
            DataInizioRicerca = new DateTime(dateTimePicker_DataInizio.Value.Year,
                                                dateTimePicker_DataInizio.Value.Month,
                                                dateTimePicker_DataInizio.Value.Day,
                                                dateTimePicker_OraInizio.Value.Hour,
                                                dateTimePicker_OraInizio.Value.Minute,
                                                dateTimePicker_OraInizio.Value.Second);

            // Compone la data di fine ricerca
            DataFineRicerca = new DateTime(dateTimePicker_DataFine.Value.Year,
                                                dateTimePicker_DataFine.Value.Month,
                                                dateTimePicker_DataFine.Value.Day,
                                                dateTimePicker_OraFine.Value.Hour,
                                                dateTimePicker_OraFine.Value.Minute,
                                                dateTimePicker_OraFine.Value.Second);


            // Compone i path sorgenti
            esito = ComponePath();
            if (esito != GstErrori.EErrore.E0000_OK)
                return esito;

            // seleziona i file JPEG
            if (ucFotoJpeg.Abilita)
            {
                esito = SelezionaFile(JpegPathDisponibili, JpegPathSelezionati, "JPEG");
                if (esito != GstErrori.EErrore.E0000_OK)
                    return esito;
            }

            // seleziona i file HEIC
            if (ucFotoHeic.Abilita)
            {
                esito = SelezionaFile(HeicPathDisponibili, HeicPathSelezionati, "HEIC");
                if (esito != GstErrori.EErrore.E0000_OK)
                    return esito;
            }

            // seleziona i file RAW
            if (ucFotoRaw.Abilita)
            {
                esito = SelezionaFile(RawPathDisponibili, RawPathSelezionati, "RAW");
                if (esito != GstErrori.EErrore.E0000_OK)
                    return esito;
            }

            // Agggiorna contatori
            AggiornaContatori();

            return GstErrori.EErrore.E0000_OK;
        }
        /// <summary>
        /// Compone i path
        /// </summary>
        /// <returns></returns>
        public GstErrori.EErrore ComponePath()
        {
            string[] campi;

            //GstErrori.EErrore esito = GstErrori.EErrore.E0001_NOK;

            // directory JPEG
            JpegPathDisponibili = Traccia.Escursione.AreaArchivio.GetPathJpeg();
            ucFotoJpeg.PathDisponibili = JpegPathDisponibili;

            campi = Traccia.Escursione.AreaArchivio.Directory.Area.GetSubPath("JpegSel").Split('\\');
            JpegPathSelezionati = JpegPathDisponibili + SeparaDir + campi[1];
            ucFotoJpeg.PathSelezionati = JpegPathSelezionati;

            campi = Traccia.Escursione.AreaArchivio.Directory.Area.GetSubPath("JpegCop").Split('\\');
            JpegPathCopiati = JpegPathDisponibili + SeparaDir + campi[1];
            ucFotoJpeg.PathCopiati = JpegPathCopiati;

            JpegPathAssegnati = Traccia.Path + SeparaDir + Traccia.Escursione.AreaArchivio.Directory.Traccia.GetSubPath("JPEG");
            ucFotoJpeg.PathAssegnati = JpegPathAssegnati;


            // directory HEIC
            HeicPathDisponibili = Traccia.Escursione.AreaArchivio.GetPathHeic();
            ucFotoHeic.PathDisponibili = HeicPathDisponibili;

            campi = Traccia.Escursione.AreaArchivio.Directory.Area.GetSubPath("HeicSel").Split('\\');
            HeicPathSelezionati = HeicPathDisponibili + SeparaDir + campi[1];
            ucFotoHeic.PathSelezionati = HeicPathSelezionati;

            campi = Traccia.Escursione.AreaArchivio.Directory.Area.GetSubPath("HeicCop").Split('\\');
            HeicPathCopiati = HeicPathDisponibili + SeparaDir + campi[1];
            ucFotoHeic.PathCopiati = HeicPathCopiati;

            HeicPathAssegnati = Traccia.Path + SeparaDir + Traccia.Escursione.AreaArchivio.Directory.Traccia.GetSubPath("HEIC");
            ucFotoHeic.PathAssegnati = HeicPathAssegnati;


            // directory RAW
            RawPathDisponibili = Traccia.Escursione.AreaArchivio.GetPathRaw();
            ucFotoRaw.PathDisponibili = RawPathDisponibili;

            campi = Traccia.Escursione.AreaArchivio.Directory.Area.GetSubPath("RawSel").Split('\\');
            RawPathSelezionati = RawPathDisponibili + SeparaDir + campi[1];
            ucFotoRaw.PathSelezionati = RawPathSelezionati;

            campi = Traccia.Escursione.AreaArchivio.Directory.Area.GetSubPath("RawCop").Split('\\');
            RawPathCopiati = RawPathDisponibili + SeparaDir + campi[1];
            ucFotoRaw.PathCopiati = RawPathCopiati;

            RawPathAssegnati = Traccia.Path + SeparaDir + Traccia.Escursione.AreaArchivio.Directory.Traccia.GetSubPath("RAW");
            ucFotoRaw.PathAssegnati = RawPathAssegnati;


            return GstErrori.EErrore.E0000_OK;
        }
        /// <summary>
        /// Seleziona i file dalla directory specificata, con stampa dei messaggi
        /// </summary>
        /// <param name="pathDisponibili"></param>
        /// <param name="pathSelezionati"></param>
        /// <param name="operazione"></param>
        /// <returns></returns>
        private GstErrori.EErrore SelezionaFile(string pathDisponibili, string pathSelezionati, string tipoFoto)
        {
            // compone operazione
            string operazione = "selezione file " + tipoFoto;

            // stampa inizio operazioni
            StampaOperazione(true, operazione);

            // esegue la selezine
            GstErrori.EErrore esito = SelezionaFile(pathDisponibili, pathSelezionati);

            // stampa fine operazioni
            StampaOperazione(false, operazione, esito);

            return esito;
        }
        /// <summary>
        /// Seleziona i file dalla directory specificata
        /// </summary>
        /// <param name="pathDisponibili"></param>
        /// <param name="pathSelezionati"></param>
        /// <returns></returns>
        private GstErrori.EErrore SelezionaFile(string pathDisponibili, string pathSelezionati)
        {
            // Compone la lista delle foto disponibili
            string[] srcList = Directory.GetFiles(pathDisponibili, "*.*");

            // loop di analisi della directory
            foreach (string srcFile in srcList)
            {
                // Estrae il nome del file
                string srcFileName = srcFile.Substring(pathDisponibili.Length + 1);

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
                    string dstFile = pathSelezionati + SeparaDir + srcFileName;

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
        /// <summary>
        /// Attiva l'annullamento della selezione delle foto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butAnnulaSelezione_Click(object sender, EventArgs e)
        {
            AnnullaSelezioneFoto();
        }
        /// <summary>
        /// Annulla la selezione delle foto
        /// </summary>
        /// <returns></returns>
        private GstErrori.EErrore AnnullaSelezioneFoto()
        {
            GstErrori.EErrore esito = GstErrori.EErrore.E0001_NOK;


            // Compone i path sorgenti
            esito = ComponePath();
            if (esito != GstErrori.EErrore.E0000_OK)
                return esito;

            // Annulla selezione i file JPEG
            if (ucFotoJpeg.Abilita)
            {
                esito = AnnullaSelezionaFile(JpegPathDisponibili, JpegPathSelezionati, "JPEG");
                if (esito != GstErrori.EErrore.E0000_OK)
                    return esito;
            }

            // seleziona i file HEIC
            if (ucFotoHeic.Abilita)
            {
                esito = AnnullaSelezionaFile(HeicPathDisponibili, HeicPathSelezionati, "HEIC");
                if (esito != GstErrori.EErrore.E0000_OK)
                    return esito;
            }

            // seleziona i file RAW
            if (ucFotoRaw.Abilita)
            {
                esito = AnnullaSelezionaFile(RawPathDisponibili, RawPathSelezionati, "Raw");
                if (esito != GstErrori.EErrore.E0000_OK)
                    return esito;
            }

            // Agggiorna contatori
            AggiornaContatori();

            return GstErrori.EErrore.E0000_OK;
        }
        /// <summary>
        /// Annula la seleziona i file dalla directory specificata
        /// </summary>
        /// <param name="pathDisponibili"></param>
        /// <param name="pathSelezionati"></param>
        /// <param name="tipoFoto"></param>
        /// <returns></returns>
        private GstErrori.EErrore AnnullaSelezionaFile(string pathDisponibili, string pathSelezionati, string tipoFoto)
        {
            // compone operazione
            string operazione = "annulla Selezione foto " + tipoFoto;

            // stampa inizio operazioni
            StampaOperazione(true, operazione);

            // esegue la selezine
            GstErrori.EErrore esito = AnnullaSelezionaFile(pathDisponibili, pathSelezionati);

            // stampa fine operazioni
            StampaOperazione(false, operazione, esito);

            return esito;
        }
        /// <summary>
        /// Annula la seleziona i file dalla directory specificata
        /// </summary>
        /// <param name="pathDisponibili"></param>
        /// <param name="pathSelezionati"></param>
        /// <returns></returns>
        private GstErrori.EErrore AnnullaSelezionaFile(string pathDisponibili, string pathSelezionati)
        {
            // Compone la lista delle foto selezionate
            string[] srcList = Directory.GetFiles(pathSelezionati, "*.*");

            // loop di analisi della directory
            foreach (string srcFile in srcList)
            {
                // Estrae il nome del file
                string srcFileName = srcFile.Substring(pathSelezionati.Length + 1);

                // crea il path di destinazione in selezione
                string dstFile = pathDisponibili + SeparaDir + srcFileName;

                // stampa il nome del file selezionato
                msg.Stampa("Selezionato: " + srcFileName, true);

                try
                {
                    // Sposta il file nella directory disponibili
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

            return GstErrori.EErrore.E0000_OK;
        }
        /// <summary>
        /// Attiva l'assegnazione dei file selezionati
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButAssegna_Click(object sender, EventArgs e)
        {
            AssegnaFoto();
        }
        /// <summary>
        /// Assegna le foto selezionate
        /// </summary>
        /// <returns></returns>
        private GstErrori.EErrore AssegnaFoto()
        {
            GstErrori.EErrore esito = GstErrori.EErrore.E0001_NOK;


            // Compone i path sorgenti
            esito = ComponePath();
            if (esito != GstErrori.EErrore.E0000_OK)
                return esito;


            // Copia i file JPEG
            if (ucFotoJpeg.Abilita)
            {
                esito = AssegnaFile(JpegPathSelezionati, JpegPathAssegnati, JpegPathCopiati, "JPEG");
                if (esito != GstErrori.EErrore.E0000_OK)
                    return esito;
            }

            // Copia i file HEIC
            if (ucFotoHeic.Abilita)
            {
                esito = AssegnaFile(HeicPathSelezionati, HeicPathAssegnati, HeicPathCopiati, "HEIC");
                if (esito != GstErrori.EErrore.E0000_OK)
                    return esito;
            }

            // Copia i file RAW
            if (ucFotoRaw.Abilita)
            {
                esito = AssegnaFile(RawPathSelezionati, RawPathAssegnati, RawPathCopiati, "Raw");
                if (esito != GstErrori.EErrore.E0000_OK)
                    return esito;
            }

            // Agggiorna contatori
            AggiornaContatori();

            return GstErrori.EErrore.E0000_OK;
        }
        /// <summary>
        /// Assegna i file Selezionati directory della traccia corrispondente
        /// </summary>
        /// <param name="pathSelezionati"></param>
        /// <param name="pathAssegnati"></param>
        /// <param name="pathCopiati"></param>
        /// <param name="tipoFoto"></param>
        /// <returns></returns>
        private GstErrori.EErrore AssegnaFile(string pathSelezionati, string pathAssegnati, string pathCopiati, string tipoFoto)
        {
            // compone operazione
            string operazione = "assegna file " + tipoFoto;

            // stampa inizio operazioni
            StampaOperazione(true, operazione);

            // esegue la selezine
            GstErrori.EErrore esito = AssegnaFile(pathSelezionati, pathAssegnati, pathCopiati);

            // stampa fine operazioni
            StampaOperazione(false, operazione, esito);

            return esito;
        }
        /// <summary>
        /// Assegna i file Selezionati directory della traccia corrispondente
        /// </summary>
        /// <param name="pathSelezionati"></param>
        /// <param name="pathAssegnati"></param>
        /// <param name="pathCopiati"></param>
        /// <returns></returns>
        private GstErrori.EErrore AssegnaFile(string pathSelezionati, string pathAssegnati, string pathCopiati)
        {
            // Compone la lista delle foto disponibili
            string[] srcList = Directory.GetFiles(pathSelezionati, "*.*");

            // loop di analisi della directory
            foreach (string srcFile in srcList)
            {
                // Estrae il nome del file
                string srcFileName = srcFile.Substring(pathSelezionati.Length + 1);

                // Compone il path dove copiare il file
                string copiaFile = pathAssegnati + SeparaDir + srcFileName;

                // Compone il path dove spostare il file
                string muoveFile = pathCopiati + SeparaDir + srcFileName;


                // stampa il nome del file selezionato
                msg.Stampa("Assegnato: " + srcFileName, true);

                try
                {
                    // Copia il file nella relativa directory della traccia
                    File.Copy(srcFile, copiaFile);

                    // Verifica che il file esista nella directory della traccia
                    if (!File.Exists(copiaFile))
                        return GstErrori.EErrore.E1355_FileNonSpostato;

                    // Muove il file nella directory dei copiati
                    File.Move(srcFile, muoveFile);

                    // Verifica che il file esista dei copiati
                    if (!File.Exists(muoveFile))
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

            return GstErrori.EErrore.E0000_OK;
        }
        /// <summary>
        /// Attiva l'annulamento del'assegnazione dei file selezionati
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butAnnullaAssegna_Click(object sender, EventArgs e)
        {
            AnnullaAssegnaFoto();
        }
        /// <summary>
        /// Annula la copia delle foto
        /// </summary>
        /// <returns></returns>
        private GstErrori.EErrore AnnullaAssegnaFoto()
        {
            GstErrori.EErrore esito = GstErrori.EErrore.E0001_NOK;


            // Compone i path sorgenti
            esito = ComponePath();
            if (esito != GstErrori.EErrore.E0000_OK)
                return esito;


            // Annula copia file JPEG
            if (ucFotoJpeg.Abilita)
            {
                esito = AnnullaAssegnaFile(JpegPathSelezionati, JpegPathAssegnati, JpegPathCopiati, "JPEG");
                if (esito != GstErrori.EErrore.E0000_OK)
                    return esito;
            }

            // Annula copia file HEIC
            if (ucFotoHeic.Abilita)
            {
                esito = AnnullaAssegnaFile(HeicPathSelezionati, HeicPathAssegnati, HeicPathCopiati, "HEIC");
                if (esito != GstErrori.EErrore.E0000_OK)
                    return esito;
            }

            // Annulla copia  file RAW
            if (ucFotoRaw.Abilita)
            {
                esito = AnnullaAssegnaFile(RawPathSelezionati, RawPathAssegnati, RawPathCopiati, "Raw");
                if (esito != GstErrori.EErrore.E0000_OK)
                    return esito;
            }

            // Agggiorna contatori
            AggiornaContatori();

            return GstErrori.EErrore.E0000_OK;
        }
        /// <summary>
        /// Annulla la copia dei file Assegnati directory della traccia corrispondente
        /// </summary>
        /// <param name="pathSelezionati"></param>
        /// <param name="pathAssegnati"></param>
        /// <param name="pathCopiati"></param>
        /// <param name="tipoFoto"></param>
        /// <returns></returns>
        private GstErrori.EErrore AnnullaAssegnaFile(string pathSelezionati, string pathAssegnati, string pathCopiati, string tipoFoto)
        {
            // compone operazione
            string operazione = "annulla assegna file " + tipoFoto;

            // stampa inizio operazioni
            StampaOperazione(true, operazione);

            // esegue la selezine
            GstErrori.EErrore esito = AnnullaAssegnaFile(pathSelezionati, pathAssegnati, pathCopiati);

            // stampa fine operazioni
            StampaOperazione(false, operazione, esito);

            return esito;

        }
        /// <summary>
        /// Annulla la copia dei file Assegnati directory della traccia corrispondente
        /// </summary>
        /// <param name="pathSelezionati"></param>
        /// <param name="pathAssegnati"></param>
        /// <param name="pathCopiati"></param>
        /// <returns></returns>
        private GstErrori.EErrore AnnullaAssegnaFile(string pathSelezionati, string pathAssegnati, string pathCopiati)
        {
            // Compone la lista delle foto Assegnate
            string[] srcList = Directory.GetFiles(pathAssegnati, "*.*");

            // loop di analisi della directory
            foreach (string srcFile in srcList)
            {
                // Estrae il nome del file
                string srcFileName = srcFile.Substring(pathAssegnati.Length + 1);

                // Compone il path dove spostare il file
                string muoveFile = pathSelezionati + SeparaDir + srcFileName;

                // Compone il path del file da cancellare
                string cancellaFile = pathCopiati + SeparaDir + srcFileName;


                // stampa il nome del file selezionato
                msg.Stampa("Selezionato: " + srcFileName, true);

                try
                {
                    // Sposta il file nei selezionati
                    File.Move(srcFile, muoveFile);

                    // Verifica che il file esista nella directory dei selezionati
                    if (!File.Exists(muoveFile))
                        return GstErrori.EErrore.E1355_FileNonSpostato;

                    // Verifica che il file non esista nella directory degli assegnati della traccia
                    if (File.Exists(srcFile))
                        return GstErrori.EErrore.E1355_FileNonSpostato;


                    // cencella il file nella directory dei copiati
                    File.Delete(cancellaFile);

                    // Verifica che il file NON esista nei copiati
                    if (File.Exists(cancellaFile))
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
        /// Attiva a copia delle foto da sorgente a traccia
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butCopia_Click(object sender, EventArgs e)
        {
            Copia();
        }
        /// <summary>
        /// Copia delle foto da sorgente a traccia
        /// </summary>
        private GstErrori.EErrore Copia()
        {
            GstErrori.EErrore esito; 
            
            // compone operazione
            string operazione = "COPIA TUTTO";

            // stampa inizio operazioni
            StampaOperazione(true, operazione);

            // Seleziona le foto
            esito = SelezioneFoto();
            if (esito != GstErrori.EErrore.E0000_OK)
            {
                // stampa fine operazioni
                StampaOperazione(false, operazione, esito);
                return esito;
            }

            // stampa fine operazioni
            esito = AssegnaFoto();
            if (esito != GstErrori.EErrore.E0000_OK)
            {
                // stampa fine operazioni
                StampaOperazione(false, operazione, esito);
                return esito;
            }

            return GstErrori.EErrore.E0000_OK;
        }
        /// <summary>
        /// Attiva l'annulamento delle copia
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butAnnullaCopia_Click(object sender, EventArgs e)
        {
            AnnullaCopia();
        }
        /// <summary>
        /// Annula la copia delle foto
        /// </summary>
        private GstErrori.EErrore AnnullaCopia()
        {
            GstErrori.EErrore esito;

            // compone operazione
            string operazione = "ANNULLA COPIA TUTTO";

            // stampa inizio operazioni
            StampaOperazione(true, operazione);

            // Seleziona le foto
            esito = AnnullaAssegnaFoto();
            if (esito != GstErrori.EErrore.E0000_OK)
            {
                // stampa fine operazioni
                StampaOperazione(false, operazione, esito);
                return esito;
            }

            // stampa fine operazioni
            esito = AnnullaSelezioneFoto();
            if (esito != GstErrori.EErrore.E0000_OK)
            {
                // stampa fine operazioni
                StampaOperazione(false, operazione, esito);
                return esito;
            }

            return GstErrori.EErrore.E0000_OK;

        }
    }
}
