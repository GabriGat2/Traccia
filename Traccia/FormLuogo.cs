using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
            uContrLuogo1.Name = "luogo dell'escursione";
            uContrLuogoTag1.Nome = "Tag 1";
            uContrLuogoTag2.Nome = "Tag 2";
            uContrLuogoTag3.Nome = "Tag 3";
            uContrLuogoTag4.Nome = "Tag 4";
            uContrLuogoTag5.Nome = "Tag 5";


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

                // Aggiunge Sigla
                TreeNode nodoSigla = new TreeNode("Sigla: " + identita.Sigla);
                nodoFiglio.Nodes.Add(nodoSigla);

                // Aggiunge ID
                TreeNode nodoID = new TreeNode("ID: " + identita.ID.ToString());
                nodoFiglio.Nodes.Add(nodoID);

                // Aggiunge Livello
                TreeNode nodoLivello = new TreeNode("Livello: " + identita.Livello.ToString());
                nodoFiglio.Nodes.Add(nodoLivello);

                // Aggiunge Gruppo
                nodoGruppo = new TreeNode(identita.NomeGruppo + " (" + identita.Gruppo.Count.ToString() + ")");
                nodoFiglio.Nodes.Add(nodoGruppo);
            }
            else
            {
                // Aggiunge Gruppo
                nodoGruppo = new TreeNode(identita.Nome);
                nodo.Nodes.Add(nodoGruppo);
            }

            // Aggiunge i nodi nipote
            foreach (var identitaFiglio in identita.Gruppo)
            {
                AggiornaIdentita(identitaFiglio, ref nodoGruppo);
            }

            return esito;
        }

    }
}
