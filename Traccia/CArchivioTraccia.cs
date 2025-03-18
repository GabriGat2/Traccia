using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traccia
{
    public class CArchivioTraccia : CArchivio
    {
        /// <summary>
        /// Area escursione
        /// </summary>
        private CArchivioEscursione escursione;
        public CArchivioEscursione Escursione { get => escursione; set => escursione = value; }


        /// <summary>
        /// Aggiorna lo stato dei campi
        /// </summary>
        /// <returns></returns>
        public override EArchivioStato Aggiorna()
        {
            // verifica lo stato di Area Archivio
            if (Escursione.Stato != EArchivioStato.ArchivioEsiste)
                stato = Escursione.Stato;

            // verifica il nome
            if (!VerificaNome())
                return stato;

            // Compone il path
            ComponePath();

            // verifica se la directory path esiste 
            if (VerificaEsistenzaDirectory(path))
                stato = EArchivioStato.ArchivioEsiste;
            else
                stato = EArchivioStato.ArchivioNonEsiste;

            return stato;
        }
        /// <summary>
        /// Crea le directory della traccia
        /// </summary>
        /// <returns></returns>
        public override GstErrori.EErrore CreaDirectoryArchivio()
        {
            // verifica che ci siano le condizioni per creare la directory
            switch (stato)
            {
                case EArchivioStato.ArchivioNonEsiste:
                    break;

                case EArchivioStato.ArchivioEsiste:
                    return GstErrori.EErrore.E1306_ArchivioEsiste;

                default:
                    return GstErrori.EErrore.E1300_NomeArchivioErrato;
            }

            // Crea directory traccia
            bool bEsito = Escursione.AreaArchivio.Directory.CreaArchivioTraccia(Path, Nome);

            // Aggiorna lo stato della traccia
            EArchivioStato passa = Stato;

            // Rende l'esito delle operazioni
            if (bEsito)
                return GstErrori.EErrore.E0000_OK;
            else
                return GstErrori.EErrore.E1315_CreazioneArchivioTracciaFallita;
        }
        /// <summary>
        /// Compone la directory path
        /// </summary>
        protected override void ComponePath()
        {
            string subPath = Escursione.AreaArchivio.Directory.GetSubPathSrcArchivio("Archivi");

            path = Escursione.AreaArchivio.Path + SeparaDir + subPath + SeparaDir + nome;
        }
    }
}
