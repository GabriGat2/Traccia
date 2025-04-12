using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        /// Costruttore
        /// </summary>
        public FormLuogo(ref CArchivioTraccia traccia)
        {
            // Assegna Archivio traccia
            Traccia = traccia;

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


        }

        private void button1_Click(object sender, EventArgs e)
        {
            VisualizzazioneEstesa = ! VisualizzazioneEstesa;
            AggiornaAlberoIdentita();
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
            GstErrori.EErrore esito = GstErrori.EErrore.E0001_NOK;

            // recuprea il nodo selezionato
            TreeNode nodo = treeViewIdentita.SelectedNode;

            // recupera l'ID del nodo
            UInt64 ID = (UInt64) nodo.Tag;

            // cerca l'identita
            CIdentita figlio;
            esito = Traccia.Escursione.AreaArchivio.Identita.CercaFiglio(ID, out figlio);
            if (esito != GstErrori.EErrore.E0000_OK)
                return;

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
        }
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
            //UCluogo.textBoxID.Text = identita.ID.ToString();
            UCluogo.textBoxID.Text = identita.ID.ToString("##-##-##-##-###-##-##");

            UCluogo.textBoxDati.Text = identita.StampaGenitori();

        }

    }
}
