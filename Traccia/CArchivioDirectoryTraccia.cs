using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traccia
{
    public class CArchivioDirectoryTraccia : CArchivioDirectoryBase
    {
        /// <summary>
        /// Definizione Directory archivio traccia
        /// </summary>
        private List<DirectoryParziale> DirArchivio = new List<DirectoryParziale>();
        protected override void Popola()
        {
            DirArchivio.Add(new DirectoryParziale("Stampe", "01-Stampe"));
            DirArchivio.Add(new DirectoryParziale("Resoconto", "02-Resoconto"));
            DirArchivio.Add(new DirectoryParziale("Tracce", "03-Tracce"));
            DirArchivio.Add(new DirectoryParziale("PerRifInfo", "05-PercorsoDiRiferimento"));

            DirArchivio.Add(new DirectoryParziale("JPEG", "10-JPEG"));
            DirArchivio.Add(new DirectoryParziale("HEIC", "11-HEIC"));
            DirArchivio.Add(new DirectoryParziale("RAW", "12-RAW"));

            DirArchivio.Add(new DirectoryParziale("Altro", "20-Altro"));
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
        public CArchivioDirectoryTraccia ()
        {
            Popola();
        }

    }
}
