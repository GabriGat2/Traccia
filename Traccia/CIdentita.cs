using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Security;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Traccia.CIstruzione;

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
        /// Azzera il contenuto dell'ientità
        /// </summary>
        public void Azzera()
        {
            foreach (var lIdentita in Gruppo)
            {
                lIdentita.Azzera();
            }

            Gruppo.Clear();
            Tag.Clear();
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
        /// <summary>
        ///  Costante divisione per il calcolo dell'ID locale
        /// </summary>
        private UInt64[] IDkDivisione = 
        {
            (UInt64) Math.Pow(10, 13),            // livello 1
            (UInt64) Math.Pow(10, 11),            // livello 2
            (UInt64) Math.Pow(10,  9),            // livello 3
            (UInt64) Math.Pow(10,  7),            // livello 4
            (UInt64) Math.Pow(10,  4),            // livello 5
            (UInt64) Math.Pow(10,  2),            // livello 6
            (UInt64) Math.Pow(10,  0),            // livello 7
        };
        /// <summary>
        ///  Costante resto per il calcolo dell'ID locale
        /// </summary>
        private UInt64[] IDkResto =
        {
            (UInt64) Math.Pow(10, 2),             // livello 1
            (UInt64) Math.Pow(10, 2),             // livello 2
            (UInt64) Math.Pow(10, 2),             // livello 3
            (UInt64) Math.Pow(10, 2),             // livello 4
            (UInt64) Math.Pow(10, 3),             // livello 5
            (UInt64) Math.Pow(10, 2),             // livello 6
            (UInt64) Math.Pow(10, 2),             // livello 7
        };
        /// <summary>
        /// Estrae l'ID locale in funzione del livello specificato
        /// </summary>
        /// <param name="vID"></param>
        /// <param name="vLivello"></param>
        /// <returns></returns>
        private UInt64 GetIdLocale(UInt64 vID, int vLivello)
        {
            // estrae il li9vello dell'identità
            uint liv = (uint)vLivello - 1;

            // esegue la divizione
            UInt64 div = IDkDivisione[liv]; 
            UInt64 IDdiv = vID / IDkDivisione[liv];

            // estra l'ID locale
            UInt64 res = IDkResto[liv];
            UInt64 IDloc = IDdiv % IDkResto[liv];

            return IDloc;
        }
        /// <summary>
        /// Toglie i separatori da una stringa ID
        /// </summary>
        /// <param name="sID"></param>
        /// <returns></returns>
        public UInt64 IDToglieSeparatori(string sID)
        {
            string [] campo = sID.Trim().Split('-');
            string zID = string.Empty;

            // ricomponme la stringa senza i separatori    
            for (int i = 0; i < campo.Length; i++)
            {
                zID += campo[i];
            }

            // sel la stringa esite esegue la conversione in UInt64
            if (!string.IsNullOrEmpty(zID))
                return Convert.ToUInt64(zID);
            else
                return 0;
        }
        /// <summary>
        /// Converte un ID in stringa aggiungend i separatori in una stringa ID
        /// </summary>
        /// <param name="sID"></param>
        /// <returns></returns>
        public string IDAggiungeSeparatori()
        {
            return ID.ToString("##-##-##-##-###-##-##");
        }
        /// <summary>
        /// Cerca un figlio atraverso l'ID
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="figlio"></param>
        /// <returns></returns>
        public GstErrori.EErrore CercaFiglio(UInt64 vID, out CIdentita figlio)
        {
            // controlla se l'ID coincide con l'ID dell'identità
            if (this.ID == vID)
            {
                figlio = this;
                return GstErrori.EErrore.E0000_OK;
            }

            // estrae l'ID locale
            UInt64 IDlocale = GetIdLocale(vID, Livello + 1);

            // controlla nel gruppo
            foreach (var lIdentita in Gruppo)
            {
                // calcola l'ID locale dell'identità presente nel gruppo
                UInt64 IDlocaleGruppo = lIdentita.GetIdLocale(lIdentita.ID, lIdentita.Livello);

                // controlla se gli ID locali coincidono
                if (IDlocale == IDlocaleGruppo)
                {
                    return lIdentita.CercaFiglio(vID, out figlio);
                }
            }

            // non ha trovato nessun figlio
            figlio = null;
            return GstErrori.EErrore.E1373_IdentitaNonEsiste;
        }
        /// <summary>
        /// Stampa i genitori
        /// </summary>
        /// <returns></returns>
        public string StampaGenitori()
        {
            string sGenitori = string.Empty;

            // controlla se c'è un genitore
            if (Genitore == null)
                return string.Empty;
            else
                sGenitori = Genitore.StampaGenitori();

            if (sGenitori.Length > 0)
                sGenitori += ", ";


            return sGenitori + Nome;
        }
    }
}
