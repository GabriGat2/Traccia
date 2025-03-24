using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traccia
{
    public class CArchivioDirectoryArea : CArchivioDirectoryBase
    {
        /// <summary>
        /// Lista con le  subdirectory presenti nell'area archivio escursioni
        /// </summary>
        private List<DirectoryParziale> DirArchivio = new List<DirectoryParziale>();
        protected override void Popola()
        {
            DirArchivio.Add(new DirectoryParziale("Input", "00-InputDatiTraccia"));
            DirArchivio.Add(new DirectoryParziale("Comune", "02-Comune"));

            DirArchivio.Add(new DirectoryParziale("JPEG", "10-JPEG"));
            DirArchivio.Add(new DirectoryParziale("JpegCop", "10-JPEG\\01-Copiati"));
            DirArchivio.Add(new DirectoryParziale("JpegSel", "10-JPEG\\02-Selezione"));


            DirArchivio.Add(new DirectoryParziale("HEIC", "11-HEIC"));
            DirArchivio.Add(new DirectoryParziale("HeicCop", "11-HEIC\\01-Copiati"));
            DirArchivio.Add(new DirectoryParziale("HeicSel", "11-HEIC\\02-Selezione"));

            DirArchivio.Add(new DirectoryParziale("RAW", "12-RAW"));
            DirArchivio.Add(new DirectoryParziale("RawCop", "12-RAW\\01-Copiati"));
            DirArchivio.Add(new DirectoryParziale("RawSel", "12-RAW\\02-Selezione"));

            DirArchivio.Add(new DirectoryParziale("Altro", "20-Altro"));

            DirArchivio.Add(new DirectoryParziale("Archivi", "30-Escursioni"));
        }
        /// <summary>
        /// Recupera la struttura delle directory dell'archivio
        /// </summary>
        /// <returns></returns>
        protected override bool GetDirArchivio(out List<DirectoryParziale> GetDirArchivio)
        {
            GetDirArchivio = DirArchivio;
            return true;
        }

        /// <summary>
        /// Costruttore
        /// </summary>
        public CArchivioDirectoryArea()
        {
            Popola();
        }

    }
}
