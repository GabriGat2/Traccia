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
        public string OraInizio { get => dateTimePicker_OraInizio.Text; set => dateTimePicker_OraInizio.Text = value; }
        /// <summary>
        /// Data Fine
        /// </summary>
        public DateTime DataFine { get => dateTimePicker_DataFine.Value; set => dateTimePicker_DataFine.Value = value; }
        /// <summary>
        /// Ora Fine
        /// </summary>
        public string OraFine { get => dateTimePicker_OraFine.Text; set => dateTimePicker_OraFine.Text = value; }


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
            dateTimePicker_OraInizio.Text= "00:00:00";
            dateTimePicker_DataFine.Value = new DateTime(2001, 1, 1);
            dateTimePicker_OraFine.Text = "00:00:00";
        }

        private void dateTimePicker_DataInizio_ValueChanged(object sender, EventArgs e)
        {
            ///dateTimePicker_DataFine.Text = dateTimePicker_DataInizio.Text;
            textBox1.Text = dateTimePicker_DataInizio.Text + " --- " + dateTimePicker_OraInizio.Text;
        }

        private void dateTimePicker_DataFine_ValueChanged(object sender, EventArgs e)
        {
            //textBox2.Text = dateTimePicker_DataFine.Text + " --- " + dateTimePicker_OraFine.Text;
        }

        private void dateTimePicker_OraInizio_ValueChanged(object sender, EventArgs e)
        {
            textBox1.Text = dateTimePicker_DataInizio.Text + " --- " + dateTimePicker_OraInizio.Text;
        }

        private void dateTimePicker_OraFine_ValueChanged(object sender, EventArgs e)
        {
            //TextBox2.Text = dateTimePicker_DataFine.Text + " --- " + dateTimePicker_OraFine.Text;
        }
    }
}
