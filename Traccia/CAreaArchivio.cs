using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traccia
{
    public class CAreaArchivio : CArchivio
    {
        /// <summary>
        /// Gestore delle directory nell'area archivio
        /// </summary>
        public CArchivioDirectory Directory = new CArchivioDirectory();
        /// <summary>
        /// Verifica lo stato del parent
        /// </summary>
        /// <returns></returns>
        protected override EArchivioStato StatoParent()
        {
            if (VerificaEsistenzaDirectory(PathBase))
                return EArchivioStato.ArchivioEsiste;
            else
                return EArchivioStato.DirBaseNonEsiste;
            
        }
        /// <summary>
        /// Rende il path dell'area input
        /// </summary>
        /// <returns></returns>
        public string GetPathInput ()
        {
            return Path + SeparaDir + Directory.GetSubPathSrcArchivio("Input");
        }
        /// <summary>
        /// Rende il path dell'area comune
        /// </summary>
        /// <returns></returns>
        public string GetPathComune()
        {
            return Path + SeparaDir + Directory.GetSubPathSrcArchivio("Comune");
        }
        /// <summary>
        /// Compone la directory path
        /// </summary>
        protected override string ComponePath()
        {
            // compone il path
            return PathBase + SeparaDir + nome;
        }
        /// <summary>
        /// Crea le directory della AreaArchivio
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
            bool bEsito = Directory.CreaSrcArchivio(Path, Nome);

            // Aggiorna lo stato della traccia
            EArchivioStato passa = Stato;

            // Rende l'esito delle operazioni
            if (bEsito)
                return GstErrori.EErrore.E0000_OK;
            else
                return GstErrori.EErrore.E1315_CreazioneArchivioTracciaFallita;
        }

    }
}
