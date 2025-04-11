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
        public string Sigla { get => sigla; }
        private string sigla = string.Empty;
        /// <summary>
        /// ID identificatore unico dell'identità
        /// </summary>
        public UInt64 ID { get => iD; }
        private UInt64 iD = 0;
        /// <summary>
        /// Parenti del nome
        /// </summary>
        public string Parenti { get => parenti; set => parenti = value; }
        private string parenti = string.Empty;
        /// <summary>
        /// Tag
        /// </summary>
        public List<UInt64> Tag { get => tag; /*set => tag = value;*/ }  
        private List<UInt64> tag = new List<UInt64>();
        /// <summary>
        /// Tipo del nome
        /// </summary>
        public string Tipo { get => tipo; set => tipo = value; }
        private string tipo = string.Empty;
        /// <summary>
        /// Nome del gruppo
        /// </summary>
        public string NomeGruppo { get => nomeGruppo;} 
        private string nomeGruppo = string.Empty;
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
            this.iD = Convert.ToUInt64(istruzione.ID);
            this.livello = genitore.livello + 1;
            this.genitore = genitore;

            this.sigla = istruzione.Sigla;
            this.nomeGruppo = istruzione.NomeGruppo;

            // Aggiunge Tag
            AggiungeTags(ref istruzione);

            this.esitoCostruttore = GstErrori.EErrore.E0000_OK;
        }
        /// <summary>
        /// Aggiunge i tags
        /// </summary>
        /// <param name="istruzione"></param>
        private void AggiungeTags(ref CIstruzione istruzione)
        {
            string sTag;
            UInt64 lTag = 0;

            for (int i = 0; i < 5; i++)
            {
                sTag = istruzione.GetTag(i);
                if ((sTag == null) || (sTag.Length == 0))
                    lTag = 0;
                else
                    lTag = Convert.ToUInt64(sTag);
 
                tag.Add(lTag);
            }
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

        public GstErrori.EErrore CercaFiglio(UInt64 ID, out CIdentita figlio)
        {
            // estrae l'ID locale





            // non ha trovato nessun figlio
            figlio = null;
            return GstErrori.EErrore.E1373_IdentitaNonEsiste;
        }


    }
}
