using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Traccia
{
    public partial class FormCopiaFoto: Form
    {
        /// <summary>
        /// Data Inizio
        /// </summary>
        public DateTime DataInizio { get => dateTimePicker_DataInizio.Value; set => dateTimePicker_DataInizio.Value = value; }
        /// <summary>
        /// Ora Inizio
        /// </summary>
        public DateTime OraInizio { get => dateTimePicker_OraInizio.Value; set => dateTimePicker_OraInizio.Value = value; }
        /// <summary>
        /// Data Fine
        /// </summary>
        public DateTime DataFine { get => dateTimePicker_DataFine.Value; set => dateTimePicker_DataFine.Value = value; }
        /// <summary>
        /// Ora Fine
        /// </summary>
        public DateTime OraFine { get => dateTimePicker_OraFine.Value; set => dateTimePicker_OraFine.Value = value; }


        /// <summary>
        /// Costruttore
        /// </summary>
        public FormCopiaFoto()
        {
            InitializeComponent();
            InizializzaClasse();
        }
        /// <summary>
        /// Inizializza la classe
        /// </summary>
        private void InizializzaClasse ()
        {
            // inizilizza data e ora di ricerca
            dateTimePicker_DataInizio.Value = new DateTime(2000, 1, 1);
            dateTimePicker_OraInizio.Value = new DateTime(2000, 1, 1, 0, 0 , 0);
            dateTimePicker_DataFine.Value = new DateTime(2001, 1, 1);
            dateTimePicker_OraFine.Value = new DateTime(2000, 1, 1, 23, 59, 59);

            // inizializza il tipo di foto
            checkBoxJPEG.Enabled = true;
            checkBoxHEIC.Enabled = true;   
            checkBoxRAW.Enabled = true;
        }
        /// <summary>
        /// Analizza le foto selezionate
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butAnalizza_Click(object sender, EventArgs e)
        {

        }
    }
}
