using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Traccia
{
    public partial class FormIdentita: Form
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
        /// Gestore identità
        /// </summary>
        public CGestoreIdentita gstIdentita = null;

        public FormIdentita(ref CArchivioTraccia traccia)
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
        }

        /// <summary>
        /// Legge un file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            string filename;

            // compone il file name da leggere
            filename = Traccia.Escursione.AreaArchivio.GetPathComune() + SeparaDir + "identita.csv";

            LeggeFile(filename, ref Traccia.Escursione.AreaArchivio.Identita);
        }
        /// <summary>
        /// Legge un file di indentità
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="identita"></param>
        /// <returns></returns>
        public GstErrori.EErrore LeggeFile(string filename, ref CIdentita identita)
        {
            // compone operazione
            string operazione = "legge file " + filename;

            // stampa inizio operazioni
            msg.StampaOperazione(true, operazione);

            // esegue la selezine
            GstErrori.EErrore esito = LeggeFile2(filename, ref identita);

            // stampa fine operazioni
            msg.StampaOperazione(false, operazione, esito);

            return esito;
        }
        /// <summary>
        /// Legge un file di identità
        /// </summary>
        /// <param name="pathFileIdentita"></param>
        /// <param name="identita"></param>
        /// <returns></returns>
        public GstErrori.EErrore LeggeFile2(string pathFileIdentita, ref CIdentita identita)
        {
            GstErrori.EErrore esito = GstErrori.EErrore.E0001_NOK;
            string linea = string.Empty;

            // verifica se esite il file da leggere
            if (!File.Exists(pathFileIdentita))
            {
                return GstErrori.EErrore.E1350_FileNonEsiste;
            }
            else
            {
                // apre il file identità
                StreamReader sr = new StreamReader(pathFileIdentita);

                // legge la prima linea del file
                linea = sr.ReadLine();

                // decodifica il file
                esito = DecodificaFile(ref sr, ref identita);

                // Chiude il file in lettura
                sr.Close();
            }

            return esito;
        }
        /// <summary>
        /// decodifica le linee del file identità
        /// </summary>
        /// <param name="sr"></param>
        /// <param name="identita"></param>
        /// <returns></returns>
        private GstErrori.EErrore DecodificaFile(ref StreamReader sr, ref CIdentita identita)
        {
            GstErrori.EErrore esito = GstErrori.EErrore.E0001_NOK;

            try
            {
                // legge la prima linea del file
                string linea = sr.ReadLine();

                // continua a leggere finchè non ragiunge EOF
                while (linea != null)
                {
                    // assegna la linea all'istruzione
                    CIstruzione istruzione = new CIstruzione(linea);

                    // verifica che ci sia almeno un campo
                    if (istruzione.Campi > 0)
                    {
                        // analizza il primo campo che indica il tipo di istruzione
                        switch (istruzione.Operatore)
                        {
                            case CIstruzione.EOperatore.Commento:
                                esito = GstErrori.EErrore.E0000_OK;
                                break;


                            case CIstruzione.EOperatore.Campo:
                                esito = istruzione.AssegnaIdentita(ref identita);
                                break;

                            case CIstruzione.EOperatore.Link:
                                // compone il file name da leggere
                                string pathFileName = Traccia.Escursione.AreaArchivio.GetPathComune() + SeparaDir + istruzione.Link;
                                esito = LeggeFile(pathFileName, ref identita);
                                break;


                            default:
                                // stampa l'operatore sconosciuto
                                msg.Stampa(istruzione.GetCampo((CIstruzione.EIstruzione.Operatore)));
                                esito =  GstErrori.EErrore.E1360_IstruzioneSconosciuta;
                                break;
                        }
                    }

                    // varifica esito
                    if (esito != GstErrori.EErrore.E0000_OK)
                    {
                        msg.Stampa(linea);
                        return esito;
                    }

                    // legge una nuova linea
                    linea = sr.ReadLine();
                } // end while

                return GstErrori.EErrore.E0000_OK;
            }
            catch (Exception e)
            {
                GstErrori.StampaMessaggioErrore(GstErrori.EErrore.E0005_Exception, "Exception: " + e.Message);
                return GstErrori.EErrore.E0005_Exception;
            }
        }
    }
}
