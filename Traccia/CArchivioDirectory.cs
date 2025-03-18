using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Traccia
{
    public class CArchivioDirectory
    {
        /// <summary>
        /// Directory base della archiviazione traccia
        /// </summary>
        private string DirArchvioBase = "ArchiviaTracce";

        /// <summary>
        /// Speratore per path
        /// </summary>
        private const string SeparaDir = "\\";
        /// <summary>
        /// Costruttore
        /// </summary>
        public CArchivioDirectory ()
        {
            PopolaDirSrcArchivio();
            PopolaDirArchivio();
        }




        private List<DirectoryParziale> DirSrcArchivio = new List<DirectoryParziale>();
        private void PopolaDirSrcArchivio()
        {
            DirSrcArchivio.Add(new DirectoryParziale("Input",   "00-InputDatiTraccia"));
            DirSrcArchivio.Add(new DirectoryParziale("Comune",  "02-Comune"));

            DirSrcArchivio.Add(new DirectoryParziale("JPEG",    "10-JPEG"));
            DirSrcArchivio.Add(new DirectoryParziale("HEIC",    "11-HEIC"));
            DirSrcArchivio.Add(new DirectoryParziale("RAW",     "12-RAW"));

            DirSrcArchivio.Add(new DirectoryParziale("Altro",   "20-Altro"));

            DirSrcArchivio.Add(new DirectoryParziale("Archivi", "30-Archivi"));
        }
        /// <summary>
        /// Crea l'archivio SRC
        /// </summary>
        /// <param name="pathArchivio"></param>
        /// <param name="NomeArchivio"></param>
        /// <returns></returns>
        public bool CreaSrcArchivio(string pathArchivio, string NomeArchivio)
        {
            // Crea la directory Dell'archivo
            CreaDirectory(pathArchivio);

            // crea le directory sorgenti nell'archivio
            foreach (var dir in DirSrcArchivio)
            {
                string path = pathArchivio + SeparaDir + dir.Path;
                CreaDirectory(path);
            }

            return true;
        }
        /// <summary>
        /// Ricerca in SRC Archivio: Rende in path della key richiesta
        /// </summary>
        /// <param name="key"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public bool GetSubPathSrcArchivio(string key, out string path)
        {
            // Esamina DirSrcArchivio
            foreach (var dir in DirSrcArchivio)
            {
                if (dir.Key == key)
                {
                    path = dir.Path;
                    return true;
                }
            }

            // la chiav richiesta non esite
            path = null;    
            return false;

        }
        /// <summary>
        /// ricerca in SRC Archivio: Rende in path della key richiesta
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string GetSubPathSrcArchivio(string key)
        {
            // Esamina DirSrcArchivio
            foreach (var dir in DirSrcArchivio)
            {
                if (dir.Key == key)
                {
                    return  dir.Path;
                }
            }

            // la chiave richiesta non esite
            return string.Empty;

        }
        /// <summary>
        /// Definizione Directory archivio
        /// </summary>
        private List<DirectoryParziale> DirArchivio = new List<DirectoryParziale>();
        private void PopolaDirArchivio()
        {
            DirArchivio.Add(new DirectoryParziale("Stampe",       "01-Stampe"));
            DirArchivio.Add(new DirectoryParziale("Resoconto",    "02-Resoconto"));
            DirArchivio.Add(new DirectoryParziale("Tracce",       "03-Tracce"));
            DirArchivio.Add(new DirectoryParziale("Info",         "04-Info"));
            DirArchivio.Add(new DirectoryParziale("PerRifInfo",   "05-PercorsoDiRiferimento"));

            DirArchivio.Add(new DirectoryParziale("JPEG",         "10-JPEG"));
            DirArchivio.Add(new DirectoryParziale("HEIC",         "11-HEIC"));
            DirArchivio.Add(new DirectoryParziale("RAW",          "12-RAW"));

            DirArchivio.Add(new DirectoryParziale("Altro",        "20-Altro"));

            DirArchivio.Add(new DirectoryParziale("Archivi",      "30-Archivi"));
        }
        /// <summary>
        /// Crea L'archivio di una escursione
        /// </summary>
        /// <param name="pathArchivio"></param>
        /// <param name="NomeArchivio"></param>
        /// <returns></returns>
        public bool CreaArchivioEscursione(string pathArchivio, string NomeArchivio)
        {
            CreaDirectory(pathArchivio);
            return true;
        }
        /// <summary>
        /// Crea l'archivio di una traccia
        /// </summary>
        /// <param name="pathArchivio"></param>
        /// <param name="NomeArchivio"></param>
        /// <returns></returns>
        public bool CreaArchivioTraccia(string pathArchivio, string NomeArchivio)
        {
            foreach (var dir in DirArchivio)
            {
                string path = pathArchivio + SeparaDir + dir.Path;
                CreaDirectory(path);
            }

            return true;
        }
        /// <summary>
        /// Crea una directory
        /// </summary>
        /// <param name="path"></param>
        /// <param name="muto"></param>
        /// <returns></returns>
        private bool CreaDirectory(string path, bool muto = false)
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
