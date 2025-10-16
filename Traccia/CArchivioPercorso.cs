using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traccia
{
    public class CArchivioPercorso : CArchivioTraccia
    {
        /// <summary>
        /// Costruttore
        /// </summary>
        public CArchivioPercorso() : base()
        {
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
            string subDirArchivio = Escursione.AreaArchivio.Directory.Escursione.GetSubPath("Archivi");

            //  Estra la subdir Percorso di riferimento 
            string subDirPercorsoRif = Escursione.AreaArchivio.Directory.Traccia.GetSubPath("PerRifInfo");


            switch (ModoArchiviazione())
            {
                default:
                case EModoArchiviazione.Base:
                    path = pathEscursione + SeparaDir + subDirArchivio + subDirPercorsoRif;
                    break;

                case EModoArchiviazione.Singola:
                    path = pathEscursione + SeparaDir + subDirArchivio + SeparaDir + nome + subDirPercorsoRif;
                    break;

                case EModoArchiviazione.Giorno:
                    path = pathEscursione + SeparaDir + subDirArchivio + SeparaDir + GetOnlyData() + subDirPercorsoRif;
                    break;

                case EModoArchiviazione.GiornoSingola:
                    path = pathEscursione + SeparaDir + subDirArchivio + SeparaDir + GetOnlyData() + SeparaDir + nome + subDirPercorsoRif;
                    break;
            }

            return path;
        }

    }
}
