﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Traccia
{
    public class CArchivio
    {
        /// <summary>
        /// Directory base della archiviazione traccia
        /// </summary>
        private string DirArchvioBase = "ArchiviaTracce";


        private string SeparaDir = "\\";



        //List<string> [] DirSrcArchivio =
        //[
        //    "pippo" ,
        //    "pluto" ,

        //];


        /// <summary>
        /// Costruttore
        /// </summary>
        public CArchivio ()
        {
            PopolaDirSrcArchivio();
            PopolaDirArchivio();
        }


        private List<DirectoryParziale> DirSrcArchivio = new List<DirectoryParziale>();
        private void PopolaDirSrcArchivio()
        {
            DirSrcArchivio.Add(new DirectoryParziale("src","Src"));
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

        }
        /// <summary>
        /// Crea un Archivio
        /// </summary>
        /// <param name="pathArchivio"></param>
        /// <param name="NomeArchivio"></param>
        /// <returns></returns>
        public bool CreaArchivio(string pathArchivio, string NomeArchivio)
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
