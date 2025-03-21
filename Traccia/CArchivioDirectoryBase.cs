using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Traccia.CArchivio;

namespace Traccia
{
    public class CArchivioDirectoryBase
    {
        /// <summary>
        /// Speratore per path
        /// </summary>
        protected const string SeparaDir = "\\";
        /// <summary>
        /// Popola la struttura delle directory  
        /// </summary>
        protected virtual void Popola()
        {
            StampaErroreOverride("Popola");
        }
        /// <summary>
        /// Recupera la struttura delle directory dell'archivio
        /// </summary>
        /// <returns></returns>
        protected virtual bool GetDirArchivio(out List<DirectoryParziale> dirArchivio)
        {
            StampaErroreOverride("GetDirArchivio");
            dirArchivio = null;
            return false;
        }
        /// <summary>
        /// Crea l'archivio
        /// </summary>
        /// <param name="pathArchivio"></param>
        /// <param name="NomeArchivio"></param>
        /// <returns></returns>
        public virtual GstErrori.EErrore CreaArchivio(string pathArchivio, string NomeArchivio)
        {
            // recupera la directory dell'archivio
            List<DirectoryParziale> dirArchivio;
            if (!GetDirArchivio(out dirArchivio))
                return GstErrori.EErrore.E0001_NOK;

            // Crea la directory Dell'archivo
            CreaDirectory(pathArchivio);

            // crea le directory sorgenti nell'archivio
            foreach (var dir in dirArchivio)
            {
                string path = pathArchivio + SeparaDir + dir.Path;
                CreaDirectory(path);
            }

            return GstErrori.EErrore.E0000_OK;
        }
        /// <summary>
        /// Ricerca nella struttura delle directory: rende il subPath della key richiesta
        /// </summary>
        /// <param name="key"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public virtual bool GetSubPath(string key, out string path)
        {
            // inizializza path
            path = null;

            // recupera la directory dell'archivio
            List<DirectoryParziale> dirArchivio;
            if (! GetDirArchivio(out dirArchivio))
                return false;

            // Esamina DirArchivioAreaEscursione
            foreach (var dir in dirArchivio)
            {
                if (dir.Key == key)
                {
                    path = dir.Path;
                    return true;
                }
            }

            // la chiav richiesta non esite
            return false;
        }
        /// <summary>
        /// Ricerca nella struttura delle directory: rende il subPath della key richiesta
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public virtual string GetSubPath(string key)
        {
            // recupera la directory dell'archivio
            List<DirectoryParziale> dirArchivio;
            if (!GetDirArchivio(out dirArchivio))
                return string.Empty;

            // Esamina DirArchivioAreaEscursione
            foreach (var dir in dirArchivio)
            {
                if (dir.Key == key)
                {
                    return dir.Path;
                }
            }

            return string.Empty;
        }
        /// <summary>
        /// Stampa un errore di mancato override
        /// </summary>
        /// <param name="nomeFunzione"></param>
        /// <returns></returns>
        private GstErrori.EErrore StampaErroreOverride(string nomeFunzione)
        {
            GstErrori.StampaMessaggioErrore
            (
                GstErrori.EErrore.E0004_QuestaFunzioneNonPuoEssereChiamataFareOverride,
                "E' obbligatorio fare l'override della funzione: " + nomeFunzione
            );

            return GstErrori.EErrore.E0004_QuestaFunzioneNonPuoEssereChiamataFareOverride;
        }
        /// <summary>
        /// Crea una directory
        /// </summary>
        /// <param name="path"></param>
        /// <param name="muto"></param>
        /// <returns></returns>
        protected bool CreaDirectory(string path, bool muto = false)
        {
            // crea la directory
            DirectoryInfo dir = Directory.CreateDirectory(path);
            if (dir.Exists)
                return true;


            // la creazione della directory è fallita stampa l'esito
            if (!muto)
                GstErrori.StampaMessaggioErrore(GstErrori.EErrore.E1301_CreazioneDirectoryFallita, path);

            return false;
        }
    }
    // ======================================================================================================================
    // ======================================================================================================================
    // ======================================================================================================================
    /// <summary>
    /// Classe Directory parziale
    /// </summary>
    public class DirectoryParziale
    {
        public string Key { get; set; }
        public string Path { get; set; }

        public DirectoryParziale(string key, string path)
        {
            Key = key;
            Path = path;
        }
    }
}
