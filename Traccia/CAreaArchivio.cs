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
            return Path + SeparaDir + Directory.Area.GetSubPath("Input");
        }
        /// <summary>
        /// Rende il path dell'area comune
        /// </summary>
        /// <returns></returns>
        public string GetPathComune()
        {
            return Path + SeparaDir + Directory.Area.GetSubPath("Comune");
        }
        /// <summary>
        /// Rende il path dell'area comune
        /// </summary>
        /// <returns></returns>
        public string GetPathJPEG()
        {
            return Path + SeparaDir + Directory.Area.GetSubPath("JPEG");
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
                    return GstErrori.EErrore.E1331_PathAreaArchivioEsiste;

                default:
                    return GstErrori.EErrore.E1311_PathAreaArchivioErrata;
            }

            // Crea directory traccia
            GstErrori.EErrore esito = Directory.Area.CreaArchivio(Path, Nome);

            // Aggiorna lo stato della traccia
            EArchivioStato passa = Stato;

            // Rende l'esito delle operazioni
            return esito;
        }

    }
}
