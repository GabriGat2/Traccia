using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Traccia
{
    public partial class UserControlFoto: UserControl
    {
        /// <summary>
        /// Nome del gruppo
        /// </summary>
        public string Nome { get => groupBoxTipo.Text; set => groupBoxTipo.Text = value; }
        /// <summary>
        /// Abilita il gruppo
        /// </summary>
        public bool Abilita { get => checkBoxAbilita.Checked; set => checkBoxAbilita.Checked = value; }
        /// <summary>
        /// path directory file disponibili
        /// </summary>
        public string PathDisponibili { get => pathDisponibili; set => pathDisponibili = value; }
        private string pathDisponibili = String.Empty;
        /// <summary>
        /// path directory file copiati
        /// </summary>
        public string PathCopiati { get => pathCopiati; set => pathCopiati = value; }        
        private string pathCopiati = String.Empty;
        /// <summary>
        /// path directory file selezionati
        /// </summary>
        public string PathSelezionati { get => pathSelezionati; set => pathSelezionati = value; }
        private string pathSelezionati = String.Empty;
        /// <summary>
        /// path directory file assegnati
        /// </summary>
        public string PathAssegnati { get => pathAssegnati; set => pathAssegnati = value; }
 
        private string pathAssegnati = String.Empty;


        public UserControlFoto()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Aggiorna l'user control
        /// </summary>
        public void Aggiorna()
        {
            string[] srcList = null;

            // Disponibili
            srcList = Directory.GetFiles(pathDisponibili, "*.*");
            textBoxDisponibili.Text = srcList.Length.ToString();

            // Selezionati
            srcList = Directory.GetFiles(pathSelezionati, "*.*");
            textBoxSelezionati.Text = srcList.Length.ToString();

            // Copiati
            srcList = Directory.GetFiles(pathCopiati, "*.*");
            textBoxCopiati.Text = srcList.Length.ToString();

            // Assegnati
            srcList = Directory.GetFiles(pathAssegnati, "*.*");
            textBoxAssegnati.Text = srcList.Length.ToString();
        }
        /// <summary>
        /// Attiva la finestra explorer, se esiste, all'indirizzo path disponibili
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butDisponibili_Click(object sender, EventArgs e)
        {
            // Avvia explorer
            ApreExplorer(pathDisponibili);
        }
        /// <summary>
        /// Attiva la finestra explorer, se esiste, all'indirizzo path copiati
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butCopiati_Click(object sender, EventArgs e)
        {
            // Avvia explorer
            ApreExplorer(pathCopiati);
        }
        /// <summary>
        /// Attiva la finestra explorer, se esiste, all'indirizzo path selezionati
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butSelezionati_Click(object sender, EventArgs e)
        {
            // Avvia explorer
            ApreExplorer(pathSelezionati);
        }
        /// <summary>
        /// Attiva la finestra explorer, se esiste, all'indirizzo path assegnati
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butAssegnati_Click(object sender, EventArgs e)
        {
            // Avvia explorer
            ApreExplorer(pathAssegnati);
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
