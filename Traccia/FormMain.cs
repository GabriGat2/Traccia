using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Traccia
{
    public partial class FormMain: Form
    {
        /// <summary>
        /// Organizzazione Ambienti
        /// 
        /// Area Archivio Escursioni
        ///     Tipo
        ///     Stato
        ///     Path
        ///     Nome
        ///     Colore
        /// 
        /// Archivio Escursione
        ///     Tipo
        ///     Stato
        ///     Path
        ///     Nome
        ///     Colore
        ///  
        /// Archivio traccia
        ///     Tipo
        ///     Stato
        ///     Path
        ///     Nome
        ///     Colore
        /// 
        /// 
        /// 
        /// 
        /// </summary>
        int pippo;


        /// <summary>
        /// Area Archivio
        /// </summary>
        public CAreaArchivio AreaArchivio = null;
        /// <summary>
        /// Archivio Escursione
        /// </summary>
        public CArchivioEscursione ArchivioEscursione = null;
        /// <summary>
        /// Archivio Traccia
        /// </summary>
        public CArchivioTraccia Traccia = null;

        /// <summary>
        /// Costruttore
        /// </summary>
        public FormMain()
        {
            InitializeComponent();
            InizializzaClasse();

            // Verifica Area Archivio
            AreaArchivio.PathBase = "D:\\Angelo\\Prj\\Traccia\\ArchiviazioneTraccia";
            AreaArchivio.Nome = "ArchivioEscursioni";
            MostraAreaArchivio();
        }
        /// <summary>
        /// Inizializza classe
        /// </summary>
        private void InizializzaClasse()
        {
            // Crea la classe AreaArchivio
            AreaArchivio = new CAreaArchivio();

            // Crea la classe Escursione
            ArchivioEscursione = new CArchivioEscursione();

            // Assegna AreaArchivio
            ArchivioEscursione.AreaArchivio = AreaArchivio;

            // Crea la classe Traccia
            Traccia = new CArchivioTraccia();   

            // Assegna Archivio Escursione
            Traccia.Escursione = ArchivioEscursione;
        }
        /// <summary>
        /// Avvia la dialog per l'archiviazione di una escursione
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butArchiviaEscursione_Click(object sender, EventArgs e)
        {
            //FormArchiviaEscursione dlg = new FormArchiviaEscursione();
            //dlg.ShowDialog();
        }
        /// <summary>
        /// Crea un archivio
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butCreaArchivio_Click(object sender, EventArgs e)
        {
            // Controlla c'è un escursione impostata
            if (ArchivioEscursione.StatoOk())
            {
                // Chiede se deve continuare
                if  (!   GstErrori.StampaMessaggioAvviso
                        (
                            GstErrori.EErrore.E1324_EscursionePresente, 
                            "Una escursione è il elaborazione, vuoi terminare l'elaborazione?"
                        )
                    )
                    return;
            }

            // Ripulisce l'Escursione
            ArchivioEscursione.ClearNome();

            // Apre il form 
            OpenArchivioEscursione();
        }
        /// <summary>
        /// Apre il form Archivio escursione
        /// </summary>
        private void OpenArchivioEscursione()
        {
            ArchivioEscursione.AreaArchivio = AreaArchivio;

            // verifica l'esistenza dell'Area Archivo
            if (!ArchivioEscursione.AreaArchivio.StatoOk())
            {
                GstErrori.StampaMessaggioErrore(GstErrori.EErrore.E1303_PathAreaArchivioErrata, ArchivioEscursione.AreaArchivio.Path);
                return;
            }

            FormArchivioEscursione dlg = new FormArchivioEscursione(ref Traccia);
            dlg.ShowDialog();
        }
        /// <summary>
        /// Crea l'Area Archivio
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butCreaAreaArchivio_Click(object sender, EventArgs e)
        {
            FormAreaArchivio dlg = new FormAreaArchivio(ref AreaArchivio); 
            dlg.ShowDialog();

            // verifica se la directory esiste
            VerificaAreaArchivio(AreaArchivio.Path);
        }
        /// <summary>
        /// Seleziona Area Archivio
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butSelezionaAreaArchivio_Click(object sender, EventArgs e)
        {
            string path = string.Empty;

            // seleziona la direcory base
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                path = dlg.SelectedPath;
            }

            // verifica se la directory esiste
            VerificaAreaArchivio(path);

        }
        /// <summary>
        /// Verifica se il path dell'area archivio è corretta
        /// </summary>
        /// <param name="pathAreaArchivio"></param>
        void VerificaAreaArchivio(string pathAreaArchivio)
        {
            // pubblica lo stato di Area Archivio
            MostraAreaArchivio();
        }
        /// <summary>
        /// Mostra le informazioni sul Area Archivio
        /// </summary>
        private void MostraAreaArchivio()
        {
            textBoxNomeAreaArchivio.Text = AreaArchivio.Nome;
            textBoxPathAreaArchivio.Text = AreaArchivio.Path;

            textBoxNomeAreaArchivio.BackColor = AreaArchivio.Colore;
            textBoxPathAreaArchivio.BackColor = AreaArchivio.Colore;
         }
        /// <summary>
        /// Apre la dialog per l'archiviazione di una traccia
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butArchiviaTraccia_Click(object sender, EventArgs e)
        {
            // verifica l'esistenza dell'Area Archivo
            if (!ArchivioEscursione.StatoOk())
            {
                GstErrori.StampaMessaggioErrore(GstErrori.EErrore.E1303_PathAreaArchivioErrata, ArchivioEscursione.Path);
                return;
            }

            FormArchivoTraccia dlg = new FormArchivoTraccia(ref Traccia);  
            dlg.ShowDialog();
        }
        /// <summary>
        /// Selezione un escursione
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butEscursione_Click(object sender, EventArgs e)
        {
            // seleziona la direcory base
            FolderBrowserDialog dlg = new FolderBrowserDialog();

            // disabilita la possibilita di creare una nuova directory
            dlg.ShowNewFolderButton = false;

            // imposta la descrizione
            dlg.Description = "Seleziona la direcory dell'escursione";

            // imposta l'indirizzo dell'archivio escursioni
            dlg.SelectedPath = ArchivioEscursione.GetPathArchivoEscursioni();

            // esegue la dialog per selezionare il path dell'escursione
            if (dlg.ShowDialog() != DialogResult.OK)
                return;
            
            // salva il path reso
            string path = dlg.SelectedPath;

            // Assegna il nome della traccia
            ArchivioEscursione.SetNome(path);

            // Apre il form Archivio Escursione
            OpenArchivioEscursione();
        }
    }
}
