using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Traccia
{
    public partial class FormLuogo: Form
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
        /// Abilita la visualizzazione estesa dell'albero delle identita
        /// </summary>
        private bool VisualizzazioneEstesa = false;
        /// <summary>
        /// ID luogo selezionato
        /// </summary>
        private UInt64 LuogoID;
        /// <summary>
        /// Costruttore
        /// </summary>
        public FormLuogo(ref CArchivioTraccia traccia, string IDspaziato)
        {
            // Assegna Archivio traccia
            Traccia = traccia;

            // Assegna l'ID del luogo
            LuogoID = traccia.Escursione.AreaArchivio.Identita.IDToglieSeparatori(IDspaziato);


            InitializeComponent();
            InizializzaClasse();
        }
        /// <summary>
        /// InizializzazioneClasse
        /// </summary>
        private void InizializzaClasse()
        {
            // Definisce il gestore dei messaggi
            msg = new CMessaggio(ref richTextBoxOutput);

            // imposta il nome dei Controlli di luogo
            uContrLuogo1.NomeControllo = "luogo dell'escursione";
            uContrLuogoTag1.NomeControllo = "Tag 1";
            uContrLuogoTag2.NomeControllo = "Tag 2";
            uContrLuogoTag3.NomeControllo = "Tag 3";
            uContrLuogoTag4.NomeControllo = "Tag 4";
            uContrLuogoTag5.NomeControllo = "Tag 5";

            // Aggiorna l'albero delle identità
            AggiornaAlberoIdentita();

            // stampa i dati completi dell'identita del lugo selezionato
            StampaIdentitaCompleta();
        }
        /// <summary>
        /// Ricarica le identità
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butRicarica_Click(object sender, EventArgs e)
        {
            GstErrori.EErrore esito = GstErrori.EErrore.E0001_NOK;

            // Aggiorna identità
            esito = AggiornaIdentita();
            if (esito != GstErrori.EErrore.E0000_OK)
                return;


            // Aggiorna albero identità
            esito = AggiornaAlberoIdentita();
            if (esito != GstErrori.EErrore.E0000_OK)
                return;

            // stampa i dati completi dell'identita del lugo selezionato
            StampaIdentitaCompleta();
        }
        private GstErrori.EErrore AggiornaIdentita()
        {
            string filename;

            // Azzera l'albero delle identità
            Traccia.Escursione.AreaArchivio.Identita.Azzera();


            // compone il file name da leggere
            filename = Traccia.Escursione.AreaArchivio.GetPathComune() + SeparaDir + "identita.csv";

            // legge il file delle identità
            return LeggeFile(filename, ref Traccia.Escursione.AreaArchivio.Identita);


            //// Aggiorna tree view identita
            //AggiornaAlberoIdentita();

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
        private GstErrori.EErrore AggiornaIdentita(CIdentita identita, ref TreeNode nodo)
        {
            GstErrori.EErrore esito = GstErrori.EErrore.E0000_OK;

            TreeNode nodoGruppo = null;

            if (VisualizzazioneEstesa)
            {

                // Aggiunge il nodo figlio
                TreeNode nodoFiglio = new TreeNode(identita.Nome);
                nodo.Nodes.Add(nodoFiglio);
                nodoFiglio.Tag = identita.ID;

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
                    TreeNode nodoTag = new TreeNode("Tag " + i.ToString() + ": " + tag.ToString());
                    nodoTags.Nodes.Add(nodoTag);
                    i++;
                }

                // Aggiunge Gruppo
                nodoGruppo = new TreeNode(identita.NomeGruppo + " (" + identita.Gruppo.Count.ToString() + ")");
                nodoFiglio.Nodes.Add(nodoGruppo);
            }
            else
            {
                // Aggiunge Gruppo
                nodoGruppo = new TreeNode(identita.Nome);
                nodo.Nodes.Add(nodoGruppo);
                nodoGruppo.Tag = identita.ID;
            }

            // Aggiunge i nodi nipote
            foreach (var identitaFiglio in identita.Gruppo)
            {
                AggiornaIdentita(identitaFiglio, ref nodoGruppo);
            }

            return esito;
        }
        /// <summary>
        /// Assegna l'identità selezionata
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butAssegna_Click(object sender, EventArgs e)
        {
            VisualizzazioneEstesa = !VisualizzazioneEstesa;
            if (VisualizzazioneEstesa)
                butEstesa.Text = "Normale";
            else
                butEstesa.Text = "Estesa";

            // Aggiorna l'albero delle identità
            AggiornaAlberoIdentita();

        }

        /// <summary>
        /// Estra il tag selezionato
        /// </summary>
        /// <returns></returns>
        private GstErrori.EErrore EstraeTag()
        {
            // recuprea il nodo selezionato
            TreeNode nodo = treeViewIdentita.SelectedNode;
            if (nodo == null)
                return GstErrori.EErrore.E0001_NOK;

            // recupera l'ID del nodo
            if (nodo.Tag == null)
                return GstErrori.EErrore.E0001_NOK;
            LuogoID = (UInt64)nodo.Tag;

            // stampa i dati completi dell'identita del lugo selezionato
            return StampaIdentitaCompleta();
        }
        /// <summary>
        /// Mostra i dati dell'identita specificata dall'ID
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        private GstErrori.EErrore StampaIdentitaCompleta()
        { 
            GstErrori.EErrore esito = GstErrori.EErrore.E0001_NOK;

            // cerca l'identita
            CIdentita figlio;
            esito = Traccia.Escursione.AreaArchivio.Identita.CercaFiglio(LuogoID, out figlio);
            if (esito != GstErrori.EErrore.E0000_OK)
                return esito;

            // Pubblica i dati dell'identità
            StampaIdentita(ref uContrLuogo1, ref figlio);


            // stampa i tag
            int i = 1;
            foreach (var tag in figlio.Tag)
            {
                switch (i)
                {
                    case 1:
                        esito = StampaIdentitaTag(tag, ref uContrLuogoTag1);
                        break;
                    case 2:
                        esito = StampaIdentitaTag(tag, ref uContrLuogoTag2);
                        break;
                    case 3:
                        esito = StampaIdentitaTag(tag, ref uContrLuogoTag3);
                        break;
                    case 4:
                        esito = StampaIdentitaTag(tag, ref uContrLuogoTag4);
                        break;
                    case 5:
                        esito = StampaIdentitaTag(tag, ref uContrLuogoTag5);
                        break;
                    default:
                        break;
                }
                i++;    
            }

            return esito;
        }
        /// <summary>
        /// Stampa identità
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="UCluogo"></param>
        /// <returns></returns>
        private GstErrori.EErrore StampaIdentitaTag(UInt64 ID, ref UContrLuogo UCluogo)
        {
            GstErrori.EErrore esito = GstErrori.EErrore.E0001_NOK;

            // cerca l'identita
            CIdentita figlio;
            esito = Traccia.Escursione.AreaArchivio.Identita.CercaFiglio(ID, out figlio);
            if (esito != GstErrori.EErrore.E0000_OK)
                return esito;

            // Pubblica i dati dell'identità
            StampaIdentita(ref UCluogo, ref figlio);

            return GstErrori.EErrore.E0000_OK;
        }
        /// <summary>
        /// Stampa i dati dell'identità 
        /// </summary>
        /// <param name="UCluogo"></param>
        /// <param name="identita"></param>
        private void StampaIdentita(ref UContrLuogo UCluogo, ref CIdentita identita)
        {
            UCluogo.textBoxNome.Text = identita.Nome;
            UCluogo.textBoxSigla.Text = identita.Sigla;
            UCluogo.textBoxID.Text = identita.IDAggiungeSeparatori();

            UCluogo.textBoxDati.Text = identita.StampaGenitori();

        }
        /// <summary>
        /// Rende esito positivo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        /// <summary>
        /// Rende esito negativo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butNOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
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
                                esito = GstErrori.EErrore.E1360_IstruzioneSconosciuta;
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
        /// Seleziona luogo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeViewIdentita_AfterSelect(object sender, TreeViewEventArgs e)
        {
            EstraeTag();
        }
    }
}
