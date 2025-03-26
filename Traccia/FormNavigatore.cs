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
            //msg = new CMessaggio(ref richTextBoxOutput);

            // Stampa Nome e path della traccia
            textBoxNomeTraccia.Text = Traccia.Nome;
            textBoxPathTraccia.Text = Traccia.Path;



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
