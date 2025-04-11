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

            //msg.Stampa("dimensione identita : ", sizeof(Traccia.Escursione.AreaArchivio.Identita));

            LeggeFile(filename, ref Traccia.Escursione.AreaArchivio.Identita);


            // Aggiorna tree view identita
            AggiornaAlberoIdentita();
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
        /// <summary>
        /// Aggiorna l'albero delle identità
        /// </summary>
        /// <returns></returns>
        private GstErrori.EErrore AggiornaAlberoIdentita()
        {
            GstErrori.EErrore esito = GstErrori.EErrore.E0000_OK;

            // inizia aggiornamnto
            treeViewIdentita.BeginUpdate();

            // Azzeera Tree view
            treeViewIdentita.Nodes.Clear();

            // estrae identita
            CIdentita identita = Traccia.Escursione.AreaArchivio.Identita;


            // Aggiunge il primo nodo
            TreeNode nodo = new TreeNode(identita.Nome);
            treeViewIdentita.Nodes.Add(nodo);

            // Aggiunge i nodi figli
            foreach (var identitaFiglio in identita.Gruppo)
            {
                AggiornaIdentita(identitaFiglio, ref nodo);
            }



            // termina aggiornamnto
            treeViewIdentita.EndUpdate();

            return esito;
        }
        /// <summary>
        /// Aggiorna un blocco identita figlio
        /// </summary>
        /// <param name="identita"></param>
        /// <param name="nodo"></param>
        /// <returns></returns>
        private GstErrori.EErrore AggiornaIdentita (CIdentita identita, ref TreeNode nodo)
        {
            GstErrori.EErrore esito = GstErrori.EErrore.E0000_OK;

            // Aggiunge il nodo figlio
            TreeNode nodoFiglio = new TreeNode(identita.Nome);
            nodo.Nodes.Add(nodoFiglio);

            // Aggiunge Sigla
            TreeNode nodoSigla = new TreeNode("Sigla: " + identita.Sigla);
            nodoFiglio.Nodes.Add(nodoSigla);

            // Aggiunge ID
            TreeNode nodoID = new TreeNode("ID: " + identita.ID.ToString());
            nodoFiglio.Nodes.Add(nodoID);

            // Aggiunge Livello
            TreeNode nodoLivello = new TreeNode("Livello: " + identita.Livello.ToString());
            nodoFiglio.Nodes.Add(nodoLivello);

            // Aggiorna Tag
            TreeNode nodoTags = new TreeNode("Tag: " + " (" + identita.Tag.Count.ToString() + ")");
            nodoFiglio.Nodes.Add(nodoTags);
            int i = 0;
            foreach (var tag in identita.Tag)
            {
                TreeNode nodoTag = new TreeNode("Tag " + i.ToString()+ ": " + tag.ToString());
                nodoTags.Nodes.Add(nodoTag);
                i++;
            }

            // Aggiunge Gruppo
            TreeNode nodoGruppo = new TreeNode(identita.NomeGruppo + " ("  + identita.Gruppo.Count.ToString() + ")");
            nodoFiglio.Nodes.Add(nodoGruppo);



            // Aggiunge i nodi nipote
            foreach (var identitaFiglio in identita.Gruppo)
            {
                AggiornaIdentita(identitaFiglio, ref nodoGruppo);
            }

            return esito;
        }

        private void treeViewIdentita_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ;
        }

        private void treeViewIdentita_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string nodo = e.Node.Text;
        }

        private void treeViewIdentita_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode nodo = (TreeNode)e.Node;
            string sNodo = nodo.Text;


        }
    }
}
