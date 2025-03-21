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
        /// Directory area archiviazione
        /// </summary>
        public CArchivioDirectoryArea Area = new CArchivioDirectoryArea();
        /// <summary>
        /// Directory archiviazione escursione
        /// </summary>
        public CArchivioDirectoryEscursione Escursione = new CArchivioDirectoryEscursione();
        /// <summary>
        /// Directory archiviazione Traccia
        /// </summary>
        public CArchivioDirectoryTraccia Traccia = new CArchivioDirectoryTraccia();

        /// <summary>
        /// Costruttore
        /// </summary>
        public CArchivioDirectory()
        {

        }

    }
        //=========================================================================================================
        //=========================================================================================================
        //=========================================================================================================
        //=========================================================================================================
        //=========================================================================================================
        //=========================================================================================================
        //=========================================================================================================
        //=========================================================================================================




        ///// <summary>
        ///// Directory base della archiviazione traccia
        ///// </summary>
        //private string DirArchvioBase = "ArchiviaTracce";

    //    /// <summary>
    //    /// Speratore per path
    //    /// </summary>
    //    private const string SeparaDir = "\\";
    //    /// <summary>
    //    /// Costruttore
    //    /// </summary>
    //    public CArchivioDirectory ()
    //    {
    //        PopolaDirSrcArchivio();
    //        PopolaDirArchivio();
    //        PopolaDirArchivioTraccia();
    //    }


    //    //=====================================================================================================
    //    // Area Base
    //    //=====================================================================================================
    //    private List<DirectoryParziale> DirArchivioAreaEscursione = new List<DirectoryParziale>();
    //    private void PopolaDirSrcArchivio()
    //    {
    //        DirArchivioAreaEscursione.Add(new DirectoryParziale("Input",   "00-InputDatiTraccia"));
    //        DirArchivioAreaEscursione.Add(new DirectoryParziale("Comune",  "02-Comune"));

    //        DirArchivioAreaEscursione.Add(new DirectoryParziale("JPEG",    "10-JPEG"));
    //        DirArchivioAreaEscursione.Add(new DirectoryParziale("HEIC",    "11-HEIC"));
    //        DirArchivioAreaEscursione.Add(new DirectoryParziale("RAW",     "12-RAW"));

    //        DirArchivioAreaEscursione.Add(new DirectoryParziale("Altro",   "20-Altro"));

    //        DirArchivioAreaEscursione.Add(new DirectoryParziale("Archivi", "30-Escursioni"));
    //    }
    //    /// <summary>
    //    /// Crea l'archivio Area Escursioni
    //    /// </summary>
    //    /// <param name="pathArchivio"></param>
    //    /// <param name="NomeArchivio"></param>
    //    /// <returns></returns>
    //    public bool CreaArchivioAreaEscursioni(string pathArchivio, string NomeArchivio)
    //    {
    //        // Crea la directory Dell'archivo
    //        CreaDirectory(pathArchivio);

    //        // crea le directory sorgenti nell'archivio
    //        foreach (var dir in DirArchivioAreaEscursione)
    //        {
    //            string path = pathArchivio + SeparaDir + dir.Path;
    //            CreaDirectory(path);
    //        }

    //        return true;
    //    }
    //    /// <summary>
    //    /// Ricerca in SRC Archivio: Rende in path della key richiesta
    //    /// </summary>
    //    /// <param name="key"></param>
    //    /// <param name="path"></param>
    //    /// <returns></returns>
    //    public bool GetSubPathAreaEscursioni(string key, out string path)
    //    {
    //        // Esamina DirArchivioAreaEscursione
    //        foreach (var dir in DirArchivioAreaEscursione)
    //        {
    //            if (dir.Key == key)
    //            {
    //                path = dir.Path;
    //                return true;
    //            }
    //        }

    //        // la chiav richiesta non esite
    //        path = null;    
    //        return false;

    //    }
    //    /// <summary>
    //    /// ricerca in SRC Archivio: Rende in path della key richiesta
    //    /// </summary>
    //    /// <param name="key"></param>
    //    /// <returns></returns>
    //    public string GetSubPathAreaEscursioni(string key)
    //    {
    //        // Esamina DirArchivioAreaEscursione
    //        foreach (var dir in DirArchivioAreaEscursione)
    //        {
    //            if (dir.Key == key)
    //            {
    //                return  dir.Path;
    //            }
    //        }

    //        // la chiave richiesta non esite
    //        return string.Empty;

    //    }
    //    //=====================================================================================================
    //    // Escursione
    //    //=====================================================================================================


    //    /// <summary>
    //    /// Definizione Directory archivio escursione
    //    /// </summary>
    //    private List<DirectoryParziale> DirArchivioEscursione = new List<DirectoryParziale>();
    //    private void PopolaDirArchivio()
    //    {
    //        DirArchivioEscursione.Add(new DirectoryParziale("Info",         "04-Info"));
    //        DirArchivioEscursione.Add(new DirectoryParziale("InfoT",        "04-Info\\InfoTraccia"));

    //        DirArchivioEscursione.Add(new DirectoryParziale("Altro",        "20-Altro"));

    //        DirArchivioEscursione.Add(new DirectoryParziale("Archivi",      "30-Archivio"));
    //    }
    //    /// <summary>
    //    /// Crea l'archivio di una escursione
    //    /// </summary>
    //    /// <param name="pathArchivio"></param>
    //    /// <param name="NomeArchivio"></param>
    //    /// <returns></returns>
    //    public bool CreaArchivioEscursione(string pathArchivio, string NomeArchivio)
    //    {
    //        CreaDirectory(pathArchivio);
            
    //        foreach (var dir in DirArchivioEscursione)
    //        {
    //            string path = pathArchivio + SeparaDir + dir.Path;
    //            CreaDirectory(path);
    //        }
    //        return true;
    //    }

    //    /// <summary>
    //    /// Ricerca in Archivio escursione: Rende in path della key richiesta
    //    /// </summary>
    //    /// <param name="key"></param>
    //    /// <param name="path"></param>
    //    /// <returns></returns>
    //    public bool GetSubPathEscursione(string key, out string path)
    //    {
    //        // Esamina DirArchivioAreaEscursione
    //        foreach (var dir in DirArchivioEscursione)
    //        {
    //            if (dir.Key == key)
    //            {
    //                path = dir.Path;
    //                return true;
    //            }
    //        }

    //        // la chiav richiesta non esite
    //        path = null;
    //        return false;

    //    }
    //    /// <summary>
    //    /// ricerca in Archivio Escursione: Rende in path della key richiesta
    //    /// </summary>
    //    /// <param name="key"></param>
    //    /// <returns></returns>
    //    public string GetSubPathEscursione(string key)
    //    {
    //        // Esamina DirArchivioAreaEscursione
    //        foreach (var dir in DirArchivioEscursione)
    //        {
    //            if (dir.Key == key)
    //            {
    //                return dir.Path;
    //            }
    //        }

    //        // la chiave richiesta non esite
    //        return string.Empty;

    //    }



    //    //=====================================================================================================
    //    // Traccia
    //    //=====================================================================================================


    //    /// <summary>
    //    /// Definizione Directory archivio traccia
    //    /// </summary>
    //    private List<DirectoryParziale> DirArchivioTraccia = new List<DirectoryParziale>();
    //    private void PopolaDirArchivioTraccia()
    //    {
    //        DirArchivioTraccia.Add(new DirectoryParziale("Stampe", "01-Stampe"));
    //        DirArchivioTraccia.Add(new DirectoryParziale("Resoconto", "02-Resoconto"));
    //        DirArchivioTraccia.Add(new DirectoryParziale("Tracce", "03-Tracce"));
    //        DirArchivioTraccia.Add(new DirectoryParziale("PerRifInfo", "05-PercorsoDiRiferimento"));

    //        DirArchivioTraccia.Add(new DirectoryParziale("JPEG", "10-JPEG"));
    //        DirArchivioTraccia.Add(new DirectoryParziale("HEIC", "11-HEIC"));
    //        DirArchivioTraccia.Add(new DirectoryParziale("RAW", "12-RAW"));

    //        DirArchivioTraccia.Add(new DirectoryParziale("Altro", "20-Altro"));
    //    }
    //    /// <summary>
    //    /// Crea l'archivio di una traccia
    //    /// </summary>
    //    /// <param name="pathArchivio"></param>
    //    /// <param name="NomeArchivio"></param>
    //    /// <returns></returns>
    //    public bool CreaArchivioTraccia(string pathArchivio, string NomeArchivio)
    //    {
    //        CreaDirectory(pathArchivio);

    //        foreach (var dir in DirArchivioTraccia)
    //        {
    //            string path = pathArchivio + SeparaDir + dir.Path;
    //            CreaDirectory(path);
    //        }
    //        return true;
    //    }



    //    /// <summary>
    //    /// Ricerca in Archivio Traccia: Rende in path della key richiesta
    //    /// </summary>
    //    /// <param name="key"></param>
    //    /// <param name="path"></param>
    //    /// <returns></returns>
    //    public bool GetSubPathTraccia(string key, out string path)
    //    {
    //        // Esamina DirArchivioAreaEscursione
    //        foreach (var dir in DirArchivioTraccia)
    //        {
    //            if (dir.Key == key)
    //            {
    //                path = dir.Path;
    //                return true;
    //            }
    //        }

    //        // la chiav richiesta non esite
    //        path = null;
    //        return false;

    //    }
    //    /// <summary>
    //    /// ricerca in Archivio Escursione: Rende in path della key richiesta
    //    /// </summary>
    //    /// <param name="key"></param>
    //    /// <returns></returns>
    //    public string GetSubPathTraccia(string key)
    //    {
    //        // Esamina DirArchivioAreaEscursione
    //        foreach (var dir in DirArchivioTraccia)
    //        {
    //            if (dir.Key == key)
    //            {
    //                return dir.Path;
    //            }
    //        }

    //        // la chiave richiesta non esite
    //        return string.Empty;

    //    }


    //    //=====================================================================================================
    //    // Comune
    //    //=====================================================================================================

    //    /// <summary>
    //    /// Crea una directory
    //    /// </summary>
    //    /// <param name="path"></param>
    //    /// <param name="muto"></param>
    //    /// <returns></returns>
    //    private bool CreaDirectory(string path, bool muto = false)
    //    {
    //        // crea la directory
    //        DirectoryInfo dir = Directory.CreateDirectory(path);
    //        if (dir.Exists)
    //            return true;


    //        // la creazione della directory è fallita stampa l'esito
    //        if (!muto)
    //            GstErrori.StampaMessaggioErrore(GstErrori.EErrore.E1301_CreazioneDirectoryFallita, path);

    //        return false;
    //    }
    //}
    // ======================================================================================================================
    // ======================================================================================================================
    // ======================================================================================================================
    /// <summary>
    /// Classe Directory parziale
    /// </summary>
    //public class DirectoryParziale
    //{
    //    public string Key { get; set; }
    //    public string Path { get; set; }

    //    public DirectoryParziale(string key, string path)
    //    {
    //        Key = key;
    //        Path = path;
    //    }
    //}
}
