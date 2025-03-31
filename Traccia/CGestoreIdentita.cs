using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traccia
{
    public class CGestoreIdentita
    {


        /// <summary>
        /// Costruttore
        /// </summary>
        public CGestoreIdentita()
        { 
        }

        /// <summary>
        /// Legge un file di indentità
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public GstErrori.EErrore  LeggeFile(string filename)
        {
            GstErrori.EErrore esito = GstErrori.EErrore.E0000_OK;

            esito = LeggeFile2(filename);

            return esito;   
        }
        /// <summary>
        /// Legge un file di identità
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public GstErrori.EErrore LeggeFile2(string filename)
        {
            GstErrori.EErrore esito = GstErrori.EErrore.E0000_OK;

            return esito;
        }

    }
}
