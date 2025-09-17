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
    public partial class FormSommarioEscursioni : Form
    {
        /// <summary>
        /// Archivio Escursione
        /// </summary>
        public CArchivioEscursione Escursione;
        /// <summary>
        /// Abilita l'aggiornamento del nome dell'escursione'
        /// </summary>
        private bool AbilitazioneAggiornamentoEscursione;
        ///// <summary>
        ///// Segnala che la data è stata impostata almeno una volta
        ///// </summary>
        //private bool DataImpostata = false;
        /// <summary>
        /// Gestore per la stampa dei messaggi
        /// </summary>
        private CMessaggio msg = null;
        /// <summary>
        /// Traccia selezionata
        /// </summary>
        public string PathEscursioneSelezionata { get => pathEscursioneSelezionata; }
        private string pathEscursioneSelezionata = null;
        /// <summary>
        /// Costruttore 
        /// </summary>
        public FormSommarioEscursioni(ref CArchivioEscursione escursione)
        {
            // Assegna Archivio escursione
            Escursione = escursione;

            InitializeComponent();
            InizializzaClasse();
        }
        /// <summary>
        /// Inizilizzazione della classe
        /// </summary>
        private void InizializzaClasse()
        {
            // Invalida escursione selezionata
            pathEscursioneSelezionata = null;

            // Aggiorna la lista delle escursioni
            MostraListaEscursioni();
        }
        /// <summary>
        /// Selezione e Modifica una escursione
        /// </summary>
        /// <returns></returns>
        private GstErrori.EErrore MostraListaEscursioni()
        {
            string data = string.Empty;
            string dataAttiva = string.Empty;

            // Estra il path con la lista delle escursioni
            string pathEscursioni = Escursione.GetPathArchivoEscursioni();

            // crea la lista delle escursioni
            string[] escursioni = Directory.GetDirectories(pathEscursioni);

            // Aggiorna l'albero delle escursioni
            AggiornaAlberoEscursioni(ref escursioni);

            return GstErrori.EErrore.E0000_OK;
        }
        /// <summary>
        /// Aggiorna l'albero delle escursioni
        /// </summary>
        /// <returns></returns>
        private GstErrori.EErrore AggiornaAlberoEscursioni(ref string[] escursioni)
        {
            // esito
            GstErrori.EErrore esito = GstErrori.EErrore.E0000_OK;
            // data
            //string data = string.Empty;
            //string dataAttiva = string.Empty;
            //// nodo data
            //TreeNode nodoData = null;

            // Invalida escursiuone selezionata
            pathEscursioneSelezionata = null;

            // inizia aggiornamnto
            treeViewSommarioEscursioni.BeginUpdate();

            // Azzeera Tree view
            treeViewSommarioEscursioni.Nodes.Clear();

            // stampa il nome delle tracce
            foreach (string pathNomeEscursione in escursioni)
            {
                // estrae il nome della escursioni
                string[] campiPathNomeEscursione = pathNomeEscursione.Split('\\');
                string nomeTraccia = ((campiPathNomeEscursione[campiPathNomeEscursione.Length - 1]).Split('.'))[0];


                //// estrae la data della traccia
                //string[] campiNomeTraccia = nomeTraccia.Split('_');
                //// rimuove la data della traccia
                //string[] campiDataTraccia = campiNomeTraccia[0].Split('-');
                //// ricompone la data
                //if (campiDataTraccia.Length <= 3)
                //    data = campiDataTraccia[0];
                //else
                //    data = campiDataTraccia[0] + '-' + campiDataTraccia[1] + '-' + campiDataTraccia[2];


                //// controlla se è cambita la data
                //if (data != dataAttiva)
                //{
                //    // Aggiunge il primo nodo
                //    nodoData = new TreeNode(data);
                //    treeViewSommarioTracce.Nodes.Add(nodoData);


                //    dataAttiva = data;
                //}

                // Aggiunge il nodo della traccia
                TreeNode nodo = new TreeNode(nomeTraccia);
                nodo.Tag = pathNomeEscursione;
                //nodoData.Nodes.Add(nodo);
                treeViewSommarioEscursioni.Nodes.Add(nodo);
            }

            // termina aggiornamnto
            treeViewSommarioEscursioni.EndUpdate();

            return esito;
        }
        /// <summary>
        /// Chiude la dialog
        /// </summary>
        /// <param name="reso"></param>
        private void ChiudeDialog(bool reso)
        {
            if (reso && (pathEscursioneSelezionata != null))
                this.DialogResult = DialogResult.OK;
            else
                this.DialogResult = DialogResult.No;

            this.Close();
        }
        /// <summary>
        /// Chiude dialog con la richiesta di aprire una traccia
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butApri_Click(object sender, EventArgs e)
        {
            ChiudeDialog(true);
        }
        /// <summary>
        /// Chiude la dialog senza la richiesta di maprire una traccia
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butAnnulla_Click(object sender, EventArgs e)
        {
            ChiudeDialog(false); 
        }
        /// <summary>
        /// Estra il tag selezionato
        /// </summary>
        /// <returns></returns>
        private GstErrori.EErrore EstraeTag()
        {
            // recuprea il nodo selezionato
            TreeNode nodo = treeViewSommarioEscursioni.SelectedNode;
            if (nodo == null)
                return GstErrori.EErrore.E0001_NOK;

            // recupera l'ID del nodo
            if (nodo.Tag == null)
                return GstErrori.EErrore.E0001_NOK;
            string pathEscursione = (string)nodo.Tag;

            // stampa il path dell'escursione
            textBoxPathEscursione.Text = nodo.Text;

            // Assegna la traccia selezionata
            pathEscursioneSelezionata = pathEscursione;

            return GstErrori.EErrore.E0000_OK;
        }
        /// <summary>
        /// Seleziona escursione
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeViewSommarioEscursioni_AfterSelect(object sender, TreeViewEventArgs e)
        {
            EstraeTag();
        }
    }
}
