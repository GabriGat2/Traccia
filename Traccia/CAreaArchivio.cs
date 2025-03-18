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
        /// Rende il path dell'area input
        /// </summary>
        /// <returns></returns>
        public string GetPathInput ()
        {
            return path + SeparaDir + Directory.GetSubPathSrcArchivio("Input");
        }
        /// <summary>
        /// Rende il path dell'area comune
        /// </summary>
        /// <returns></returns>
        public string GetPathComune()
        {
            return path + SeparaDir + Directory.GetSubPathSrcArchivio("Comune");
        }
        /// <summary>
        /// Compone la directory path
        /// </summary>
        protected override void ComponePath()
        {
            path = PathBase + SeparaDir + nome;
        }
    }
}
