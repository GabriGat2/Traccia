using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using static Traccia.CArchivio;

namespace Traccia
{
    public class CArchivioEscursione : CArchivio
    {
        private CAreaArchivio areaArchivio;
        public CAreaArchivio AreaArchivio { get => areaArchivio; set => areaArchivio = value; }

        public string Data { get => GetCampo(0); }
        /// <summary>
        /// Prefisso
        /// </summary>
        public string Prefisso { get => GetCampo(1); }
        /// <summary>
        /// Nome parziale
        /// </summary>
        public string NomeParziale { get => GetCampo(2); }

        public void CAreaEscursione()
        {
            InizializzaClasse();
        }
        /// <summary>
        /// Verifica lo stato del parent
        /// </summary>
        /// <returns></returns>
        protected override EArchivioStato StatoParent()
        {
            return AreaArchivio.Stato;
        }
        /// <summary>
        /// Compone la directory path
        /// </summary>
        protected override string ComponePath()
        {
            // estrae la subdir Archivi
            string subPath = AreaArchivio.Directory.GetSubPathSrcArchivio("Archivi");

            // compone il path
            return AreaArchivio.Path + SeparaDir + subPath + SeparaDir + nome;
        }
        /// <summary>
        /// Rende il path dell'archivio escursioni
        /// </summary>
        /// <returns></returns>
        public String GetPathArchivoEscursioni ()
        {
            // Verifica che l'Area Archivio o sia corretta
            if (!AreaArchivio.StatoOk())
                return string.Empty;

            // Estra il subPath dell'archivio escursioni
            string subPath = AreaArchivio.Directory.GetSubPathSrcArchivio("Archivi");

            // compone il path degli archivi
            string pathArchivioEscursione = AreaArchivio.Path + SeparaDir + subPath;

            return pathArchivioEscursione;
        }
        /// <summary>
        /// Imposta il nome dell'escursione estraendolo dal path specificato
        /// </summary>
        /// <param name="path"></param>
        public void SetNome (string path)
        {
            // scompone il path
            string [] campi = path.Trim().Split('\\');
                
            // assegna l'ultimo campo come nome
            if (campi.Length > 0)
            {
                Nome = campi[campi.Length - 1];
            }
        }
        /// <summary>
        /// Crea le directory dell'escursione
        /// </summary>
        /// <returns></returns>
        public override GstErrori.EErrore CreaDirectoryArchivio()
        {
            // verifica che ci siano le condizioni per creare la directory
            switch (Stato)
            {
                case EArchivioStato.ArchivioNonEsiste:
                    break;

                case EArchivioStato.ArchivioEsiste:
                    return GstErrori.EErrore.E1306_ArchivioEsiste;

                default:
                    return GstErrori.EErrore.E1300_NomeArchivioErrato;
            }

            // Crea directory traccia
            bool bEsito = AreaArchivio.Directory.CreaArchivioEscursione(Path, Nome);

            // Aggiorna lo stato della traccia
            EArchivioStato passa = Stato;

            // Rende l'esito delle operazioni
            if (bEsito)
                return GstErrori.EErrore.E0000_OK;
            else
                return GstErrori.EErrore.E1314_CreazioneArchivioEscursioneFallita;
        }

    }
}
