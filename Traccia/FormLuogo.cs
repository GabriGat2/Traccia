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



    }
}
