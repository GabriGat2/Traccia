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
    public partial class FormSommario: Form
    {
        /// <summary>
        /// Archivio Traccia
        /// </summary>
        public CArchivioTraccia Traccia;
        /// <summary>
        /// Archivio Escursione
        /// </summary>
        public CArchivioEscursione Escursione;
        /// <summary>
        /// Abilita l'aggiornamento del nome dell'escursione'
        /// </summary>
        private bool AbilitazioneAggiornamentoEscursione;
        /// <summary>
        /// Segnala che la data è stata impostata almeno una volta
        /// </summary>
        private bool DataImpostata = false;
        /// <summary>
        /// Gestore per la stampa dei messaggi
        /// </summary>
        private CMessaggio msg = null;
        /// <summary>
        /// Traccia selezionata
        /// </summary>
        public string PathTracciaSelezionata { get => pathTracciaSelezionata;}
        private string pathTracciaSelezionata = null;
        /// <summary>
        /// Costruttore 
        /// </summary>
        public FormSommario(ref CArchivioTraccia traccia)
        {
            // Assegna Archivio traccia
            Traccia = traccia;

            // Assegna Archivio escursione
            Escursione = Traccia.Escursione;

            // Esegue inizializzazioni
            InitializeComponent();
            InizializzaClasse();
        }
        /// <summary>
        /// Inizilizzazione della classe
        /// </summary>
        private void InizializzaClasse()
        {
            // Invalida traccia selezionata
            pathTracciaSelezionata = null;

            // stampa il nome dell'escursione
            string nomeEscursione = Escursione.Nome;
            this.Text = "Sommario delle tracce dell'escursione: " + nomeEscursione;

            // Aggiorna la lista delle tracce
            MostraListaTracce();
        }
        /// <summary>
        /// Selezione e Modifica una traccia
        /// </summary>
        /// <returns></returns>
        private GstErrori.EErrore MostraListaTracce()
        {
            string data = string.Empty;
            string dataAttiva = string.Empty;

            // Estra il path con la lista delle tracce
            string pathTracce = Traccia.GetPathInfo();

            // crea la lista dell tracce
            string[] tracce = Directory.GetFiles(pathTracce);

            // Aggiorna l'albero delle tracce
            AggiornaAlberoTracce(ref tracce);

            return GstErrori.EErrore.E0000_OK;
        }
        /// <summary>
        /// Mostra la lista delle tracce
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butAggiorna_Click(object sender, EventArgs e)
        {
            MostraListaTracce();
        }
        /// <summary>
        /// Aggiorna l'albero delle tracce
        /// </summary>
        /// <returns></returns>
        private GstErrori.EErrore AggiornaAlberoTracce(ref string[] tracce)
        {
            // esito
            GstErrori.EErrore esito = GstErrori.EErrore.E0000_OK;
            // data
            string data = string.Empty;
            string dataAttiva = string.Empty;
            // nodo data
            TreeNode nodoData = null;

            // Invalida traccia selezionata
            pathTracciaSelezionata = null;

            // inizia aggiornamnto
            treeViewSommarioTracce.BeginUpdate();

            // Azzeera Tree view
            treeViewSommarioTracce.Nodes.Clear();

            // stampa il nome delle tracce
            foreach (string pathNomeTraccia in tracce)
            {
                // estrae il nome della traccia
                string[] campiPathNomeTraccia = pathNomeTraccia.Split('\\');
                string nomeTraccia = ((campiPathNomeTraccia[campiPathNomeTraccia.Length - 1]).Split('.'))[0];


                // estrae la data della traccia
                string[] campiNomeTraccia = nomeTraccia.Split('_');
                // rimuove la data della traccia
                string[] campiDataTraccia = campiNomeTraccia[0].Split('-');
                // ricompone la data
                if (campiDataTraccia.Length <= 3)
                    data = campiDataTraccia[0];
                else
                    data = campiDataTraccia[0] + '-' + campiDataTraccia[1] + '-' + campiDataTraccia[2];


                // controlla se è cambita la data
                if (data != dataAttiva)
                {
                    // Aggiunge il primo nodo
                    nodoData = new TreeNode(data);
                    treeViewSommarioTracce.Nodes.Add(nodoData);


                    dataAttiva = data;
                }

                // Aggiunge il nodo della traccia
                TreeNode nodo = new TreeNode(nomeTraccia);
                nodo.Tag = pathNomeTraccia;
                nodoData.Nodes.Add(nodo);
            }

            // Espandi il sommario
            treeViewSommarioTracce.ExpandAll();

            // termina aggiornamnto
            treeViewSommarioTracce.EndUpdate();

            return esito;
        }
        /// <summary>
        /// Estra il tag selezionato
        /// </summary>
        /// <returns></returns>
        private GstErrori.EErrore EstraeTag()
        {
            // recuprea il nodo selezionato
            TreeNode nodo = treeViewSommarioTracce.SelectedNode;
            if (nodo == null)
                return GstErrori.EErrore.E0001_NOK;

            // recupera l'ID del nodo
            if (nodo.Tag == null)
                return GstErrori.EErrore.E0001_NOK;
            string pathTraccia = (string)nodo.Tag;

            // stampa i dati completi dell'identita del lugo selezionato
            textBoxPathTraccia.Text = nodo.Text;//  pathTraccia;

            // Assegna la traccia selezionata
            pathTracciaSelezionata = pathTraccia;

            return GstErrori.EErrore.E0000_OK;
        }
        /// <summary>
        /// Chiude la dialog
        /// </summary>
        /// <param name="reso"></param>
        private void ChiudeDialog(bool reso)
        {
            if (reso && (pathTracciaSelezionata != null))
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
            ChiudeDialog(true);        }
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
        /// Seleziona traccia
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeViewSommarioTracce_AfterSelect(object sender, TreeViewEventArgs e)
        {
            EstraeTag();
        }
    }
}
