using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Security;
using System.Runtime.CompilerServices;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Traccia
{
    public class CIdentita
    {
        /// <summary>
        /// Nome
        /// </summary>
        public string Nome { get => nome; set => nome = value; }
        private string nome = string.Empty;
        /// <summary>
        /// Livello di nidificazione
        /// </summary>
        public int Livello { get => livello;}
        private int livello = 0;        
        /// <summary>
        /// Genitore
        /// </summary>
        public CIdentita Genitore { get => genitore; set => genitore = value; }        
        private CIdentita genitore = null;
        /// <summary>
        /// Sigla associato al nome
        /// </summary>
        public string Sigla { get => sigla; set => sigla = value; }
        private string sigla = string.Empty;
        /// <summary>
        /// Parenti del nome
        /// </summary>
        public string Parenti { get => parenti; set => parenti = value; }
        private string parenti = string.Empty;
        /// <summary>
        /// Tipo del nome
        /// </summary>
        public string Tipo { get => tipo; set => tipo = value; }
        private string tipo = string.Empty;
        /// <summary>
        /// Gruppo figli
        /// </summary>
        public List<CIdentita> Gruppo { get => gruppo; set => gruppo = value; }
        private List<CIdentita> gruppo = new List<CIdentita>();

        /// <summary>
        /// Esito operazioni esguite da costruttore
        /// </summary>
        public GstErrori.EErrore EsitoCostruttore { get => esitoCostruttore; }
        private GstErrori.EErrore esitoCostruttore = GstErrori.EErrore.E0001_NOK;

        /// <summary>
        /// Costruttore inizio albero
        /// </summary>
        public CIdentita(string nome) 
        {
            this.nome = nome;
            this.livello = 0;

            this.esitoCostruttore = GstErrori.EErrore.E0000_OK;
        }
        /// <summary>
        /// Costruttore con campi
        /// </summary>
        public CIdentita(ref CIdentita genitore, CIstruzione istruzione)
        {
            this.nome = istruzione.GetUltimoNome(0);
            this.livello = genitore.livello + 1;
            this.genitore = genitore;

            this.sigla = istruzione.Sigla;


            this.esitoCostruttore = GstErrori.EErrore.E0000_OK;
        }
        /// <summary>
        /// Cerca un figlio per nome
        /// </summary>
        /// <param name="nome"></param>
        /// <param name="figlio"></param>
        /// <returns></returns>
        public GstErrori.EErrore CercaFiglio(string nome, out CIdentita figlio)
        {
            //ricerca nel grupo figli
            foreach (var elemento in Gruppo)
            {
                if (elemento.Nome == nome)
                {
                    figlio = elemento;
                    return GstErrori.EErrore.E0000_OK;
                }

            }

            // non ha trovato nessun figlio
            figlio = null;
            return GstErrori.EErrore.E1373_IdentitaNonEsiste;
        }
        ///// <summary>
        ///// Scompone istruzione
        ///// </summary>
        ///// <param name="istruzione"></param>
        ///// <returns></returns>
        //public string[] ScomponeIstruzione(string istruzione)
        //{
        //    // scompone l'istruzione
        //    return istruzione.Trim().Split(';');



        //}
    }
}
