using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traccia
{
    public class CArchivioDirectoryEscursione : CArchivioDirectoryBase
    {
        /// <summary>
        /// Definizione Directory archivio escursione
        /// </summary>
        private List<DirectoryParziale> DirArchivio = new List<DirectoryParziale>();
        protected override void Popola()
        {
            DirArchivio.Add(new DirectoryParziale("Info", "04-Info"));
            DirArchivio.Add(new DirectoryParziale("InfoT", "04-Info\\01-InfoTraccia"));
            DirArchivio.Add(new DirectoryParziale("InfoL", "04-Info\\02-Luogo"));

            DirArchivio.Add(new DirectoryParziale("Altro", "20-Altro"));

            DirArchivio.Add(new DirectoryParziale("Archivi", "30-Archivio"));

            DirArchivio.Add(new DirectoryParziale("Archivi", "40-Sommario"));
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
        public CArchivioDirectoryEscursione()
        {
            Popola();
        }
    }
}
