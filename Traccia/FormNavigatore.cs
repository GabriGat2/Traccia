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

            // Stampa Nome e path della traccia
            textBoxNomeTraccia.Text = Traccia.Nome;
            textBoxPathTraccia.Text = Traccia.Path;
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
    }
}
