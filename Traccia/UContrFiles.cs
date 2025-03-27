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
    public partial class UContrFiles: UserControl
    {
        /// <summary>
        /// Nome del gruppo
        /// </summary>
        public string Nome { get => groupBoxFiles.Text; set => groupBoxFiles.Text = value; }
        /// <summary>
        /// Abilita il gruppo
        /// </summary>
        public bool Abilita { get => checkBoxAbilita.Checked; set => checkBoxAbilita.Checked = value; }
        /// <summary>
        /// Path directory file disponibili
        /// </summary>
        public string PathDisponibili { get => pathDisponibili; set => pathDisponibili = value; }
        private string pathDisponibili = String.Empty;
        /// <summary>
        /// Path directory file copiati
        /// </summary>
        public string PathTracce { get => pathTracce; set => pathTracce = value; }
        private string pathTracce = String.Empty;
        /// <summary>
        /// Path directory file selezionati
        /// </summary>
        public string PathStampe { get => pathStampe; set => pathStampe = value; }
        private string pathStampe = String.Empty;
        /// <summary>
        /// Path directory file assegnati
        /// </summary>
        public string PathResoconto { get => pathResoconto; set => pathResoconto = value; }
        private string pathResoconto = String.Empty;
        /// <summary>
        /// Costruttore
        /// </summary>
        public UContrFiles()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Aggiorna
        /// </summary>
        public void Aggiorna()
        {
            string[] srcList = null;

            // Disponibili
            srcList = Directory.GetFiles(pathDisponibili, "*.*");
            textBoxDisponibili.Text = srcList.Length.ToString();

            // Stampe
            srcList = Directory.GetFiles(pathStampe, "*.*");
            textBoxStampe.Text = srcList.Length.ToString();

            // Tracce
            srcList = Directory.GetFiles(pathTracce, "*.*");
            textBoxTracce.Text = srcList.Length.ToString();

            // Resoconto
            srcList = Directory.GetFiles(pathResoconto, "*.*");
            textBoxResoconto.Text = srcList.Length.ToString();
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
        /// Attiva la finestra explorer, se esiste, all'indirizzo path stampe
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butStampe_Click(object sender, EventArgs e)
        {
            // Avvia explorer
            ApreExplorer(pathStampe);
        }
        /// <summary>
        /// Attiva la finestra explorer, se esiste, all'indirizzo path tracce
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butTracce_Click(object sender, EventArgs e)
        {
            // Avvia explorer
            ApreExplorer(pathTracce);
        }
        /// <summary>
        /// Attiva la finestra explorer, se esiste, all'indirizzo path Resoconto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butResoconto_Click(object sender, EventArgs e)
        {
            // Avvia explorer
            ApreExplorer(pathResoconto);
        }



    }
}
