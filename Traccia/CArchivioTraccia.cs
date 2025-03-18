﻿using System;
using System.Collections.Generic;
using System.Data;
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
        /// Modi di archiviazione della traccia nell'area dell'escursione
        /// </summary>
        public enum EModoArchiviazione
        {
            Base,                       // 0                       
            Giorno,                     // 1
            Singola,                    // 2     
            GiornoSingola               // 3   
        };
        /// <summary>
        /// Opzione per l'aganizzzazione delle tracce per giorno
        /// </summary>
        private bool optGiorno;
        public bool OptGiorno { get => optGiorno; set => AggiornaOptGiorno(value); }
        private void AggiornaOptGiorno(bool value)
        {
            optGiorno = value;
            Aggiorna();
        }
        /// <summary>
        /// pzione per l'aganizzzazione delle tracce singolarmente
        /// </summary>
        private bool optSingola;
        public bool OptSingola { get => optSingola; set => AggiornaOptSingola(value); }
        private void AggiornaOptSingola(bool value)
        {
            optSingola = value;
            Aggiorna();
        }



        /// Verifica lo stato del parent
        /// </summary>
        /// <returns></returns>
        protected override EArchivioStato StatoParent()
        {
            return Escursione.Stato;
        }
        /// <summary>
        /// Crea le directory della traccia
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
            bool bEsito = Escursione.AreaArchivio.Directory.CreaArchivioTraccia(Path, Nome);

            // Aggiorna lo stato della traccia
            //EArchivioStato passa = Stato;

            // Rende l'esito delle operazioni
            if (bEsito)
                return GstErrori.EErrore.E0000_OK;
            else
                return GstErrori.EErrore.E1313_CreazioneAreaArchivioFallita;
        }
        /// <summary>
        /// Compone la directory path
        /// </summary>
        protected override string ComponePath()
        {
            string path = string.Empty;

            // estra il path dell'escursione
            string pathEscursione = Escursione.Path;

            // Estra la subdir Archivi di escursione
            string subDirArchivio = Escursione.AreaArchivio.Directory.GetSubPathSrcArchivio("Archivi");


            switch (ModoArchiviazione())
            {
                default:
                case EModoArchiviazione.Base:
                    path = pathEscursione;
                    break;

                case EModoArchiviazione.Singola:
                    path = pathEscursione + SeparaDir + subDirArchivio + SeparaDir + nome;
                    break;

                case EModoArchiviazione.Giorno:
                    path = pathEscursione + SeparaDir + subDirArchivio + SeparaDir + GetOnlyData();
                    break;

                case EModoArchiviazione.GiornoSingola:
                    path = pathEscursione + SeparaDir + subDirArchivio + SeparaDir + GetOnlyData() + SeparaDir + nome;
                    break;
            }

            return path;
        }
        /// <summary>
        /// Modo di archiviazione ottenuto codificando le opzioni
        /// </summary>
        /// <returns></returns>
        private EModoArchiviazione ModoArchiviazione()
        {
            EModoArchiviazione modo;

            if (!optSingola && !OptGiorno)
                modo = EModoArchiviazione.Base;
            else if (optSingola && !OptGiorno)
                modo = EModoArchiviazione.Singola;
            else if (!optSingola && OptGiorno)
                modo = EModoArchiviazione.Giorno;
            else if (optSingola && OptGiorno)
                modo = EModoArchiviazione.GiornoSingola;
            else
                modo = EModoArchiviazione.Base;

            return modo;
        }



    }
}
