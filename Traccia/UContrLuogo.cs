using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Traccia
{
    public partial class UContrLuogo: UserControl
    {
        /// <summary>
        /// Nome del controllo
        /// </summary>
        public string NomeControllo { get => groupBoxLuogo.Text; set => groupBoxLuogo.Text = value; }
        // <summary>
        /// Costruttore
        /// </summary>
        public UContrLuogo()
        {
            InitializeComponent();
            InizializzaClasse();
        }
        /// <summary>
        /// Inizializzazione della classe
        /// </summary>
        private void InizializzaClasse()
        {

        }
    }
}
