using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Traccia
{

    public class CIstruzione
    {
        /// <summary>
        /// Istruzione in formato stringa
        /// </summary>
        private string istruzione;
        /// <summary>
        /// Campi dell'istruzione
        /// </summary>
        private string[] campo;
        /// <summary>
        /// Rende il numero dei campi
        /// </summary>
        public int Campi { get => campo.Length; }
        /// <summary>
        /// Elenco operatori dell'istruzione
        /// </summary>
        public enum EOperatore
        {
            Sconosciuto = 0,
            Commento,
            Link,
            Campo
        }
        /// <summary>
        /// Operatore dell'istruzione
        /// </summary>
        public EOperatore Operatore { get => operatore; }
        private EOperatore operatore = EOperatore.Sconosciuto; 
        /// <summary>
        /// Sigla
        /// </summary>
        public string Sigla { get => GetCampo(EIstruzione.Sigla);}
        /// <summary>
        /// ID identificativo unico del blocco
        /// </summary>
        public UInt64 ID { get => Convert.ToUInt64(GetCampo(EIstruzione.ID).Trim('"')); }
        /// <summary>
        /// Link
        /// </summary>
        public string Link { get => GetCampo((EIstruzione) EIstruzioneLink.Link); }
        /// <summary>
        /// Nome del gruppo contenuto
        /// </summary>
        public string NomeGruppo { get => GetCampo(EIstruzione.NomeGruppo); }
        /// <summary>
        /// campi istruzione base
        /// </summary>
        public enum EIstruzione
        {
            Operatore = 0,              // 00
            Campo1,                     // 01
            Campo2,                     // 02
            Campo3,                     // 03
            Campo4,                     // 04
            Campo5,                     // 05
            Campo6,                     // 06
            Campo7,                     // 07
            Sigla,                      // 08
            ID,                         // 09    
            Descrizione,                // 10
            NomeGruppo,                 // 11
            Tag1,                       // 12
            Tag2,                       // 13
            Tag3,                       // 14
            Tag4,                       // 15                                   
            Tag5                        // 16
        }
        /// <summary>
        /// Campi istruzione link
        /// </summary>
        private enum EIstruzioneLink
        {
            Operatore = 0,             // 00
            Link,                        // 01 
            Campo2,                     // 02
            Campo3,                     // 03
            Campo4,                     // 04
            Campo5,                     // 05
            Campo6,                     // 06
            Campo7,                     // 07
            Sigla,                      // 08
            ID,                         // 09    
            Descrizione,                // 10
            NomeGruppo,                 // 11
            Tag1,                       // 12
            Tag2,                       // 13
            Tag3,                       // 14
            Tag4,                       // 15                                   
            Tag5                        // 16
        }
        /// <summary>
        /// Campo istruzione luogo
        /// </summary>
        private enum EIstruzioneLuogo
        {
            Operatore = 0,             // 00
            Continente,                 // 01
            Stato,                      // 02
            Regione,                    // 03
            Provincia,                  // 04
            Citta,                      // 05
            Luogo,                      // 06
            Altro,                      // 07
            Sigla,                      // 08
            ID,                         // 09    
            Descrizione,                // 10
            NomeGruppo,                 // 11
            Tag1,                       // 12
            Tag2,                       // 13
            Tag3,                       // 14
            Tag4,                       // 15                                   
            Tag5                        // 16
        }
        /// <summary>
        /// Costruttore
        /// </summary>
        /// <param name="istruzione"></param>
        public CIstruzione(string istruzione)
        {
            // assegna l'istruzione in formato stringa
            this.istruzione = istruzione;

            // scompone l'istruzione
            campo = istruzione.Split(';');

            // decodifica l'operatore dell'istruzine
            DecodificaOperatore();
        }
        /// <summary>
        /// decodifica la stringa operatore
        /// </summary>
        /// <param name="sOperatore"></param>
        private void DecodificaOperatore()
        {
            // verifica che il campo operatore esista
            if (Campi == 0)
            {
                operatore = EOperatore.Commento;
                return;
            }

            switch (GetCampo(EIstruzione.Operatore).Trim().ToLower())
            {
                case "campo":
                    operatore = EOperatore.Campo;
                    break;

                case "commento":
                    operatore = EOperatore.Commento;
                    break;

                case "link":
                    operatore = EOperatore.Link;
                    break;

                default:
                    operatore = EOperatore.Sconosciuto;
                    break;
            }
        }
        /// <summary>
        /// renda il valore del campo specificato
        /// </summary>
        /// <param name="indice"></param>
        /// <returns></returns>
        public string GetCampo(EIstruzione indice)
        {
            if ((int)indice < Campi)
                return campo[(int)indice];
            else
                return "";
        }
        /// <summary>
        /// rende il campo nome specificato dall'indice
        /// </summary>
        /// <param name="indice"></param>
        /// <returns></returns>
        private string GetNome(int indice)
        {
            // Calcola valore dell'indice nell'istruzione
            EIstruzione indiceCampoIstruzione = EIstruzione.Campo1 + indice;

            // Verifica il valore dell'indice
            if ((indiceCampoIstruzione < EIstruzione.Campo1) || (indiceCampoIstruzione > EIstruzione.Campo7))
                return "";

            return GetCampo(indiceCampoIstruzione);
        }
        /// <summary>
        /// Rende l'ultimo nome dell'istruzione
        /// </summary>
        /// <returns></returns>
        public string GetUltimoNome(int offset)
        {
            string ultimoNome = string.Empty;
            string penultimoNome = string.Empty;
            for (EIstruzione i = EIstruzione.Campo7;  i >= EIstruzione.Campo1; i--)
            {
                ultimoNome = GetCampo(i);
                if (ultimoNome.Length != 0)
                {
                    return GetCampo(i + offset);
                }
            }

            return "";
        }
        // Rende l'indice dell'ultimo nome valido dell'istruzione
        private int GetIndiceUltimoNome(int offset)
        {
            string ultimoNome = string.Empty;
            for (EIstruzione i = EIstruzione.Campo7; i >= EIstruzione.Campo1; i--)
            {
                ultimoNome = GetCampo(i);
                if (ultimoNome.Length != 0)
                    return i - EIstruzione.Campo1 - offset;
            }

            return -1;
        }
        /// <summary>
        /// Rende il tag specificato
        /// </summary>
        /// <param name="indice"></param>
        /// <returns></returns>
        public string GetTag(int indice)
        {
            // Calcola valore dell'indice nell'istruzione
            EIstruzione indiceCampoIstruzione = EIstruzione.Tag1 + indice;

            // Verifica il valore dell'indice
            if ((indiceCampoIstruzione < EIstruzione.Tag1) || (indiceCampoIstruzione > EIstruzione.Tag5))
                return "";

            return GetCampo(indiceCampoIstruzione).Trim('"');
        }
        /// <summary>
        /// Cerca l'dentità specificata nell'istruzione
        /// </summary>
        /// <param name="identita"></param>
        /// <param name="identitaFiglio"></param>
        /// <returns></returns>
        private GstErrori.EErrore CercaIdentita2(ref CIdentita identita, out CIdentita identitaParente)
        {
            GstErrori.EErrore esito = GstErrori.EErrore.E0001_NOK;

            // Inizializza identità
            CIdentita identitaPadre = identita;
            identitaParente = null;


            // estrae il nome
            string nome = GetNome(identita.Livello);

            // verifica il nome
            if (nome.Length == 0)
            {
                identitaParente = identitaPadre;
                return GstErrori.EErrore.E0000_OK;
            }


            // Cerca il figlio dell'identita
            
            esito = identita.CercaFiglio(nome, out identitaParente);
            if (esito == GstErrori.EErrore.E0000_OK)
            {
                // Ha trovato un figlio, prosegue la ricerca
                identitaPadre = identitaParente;
                return CercaIdentita2(ref identitaPadre, out identitaParente);
            }
            else
            {
                // NON ha trovato un figlio, termina la ricerca
                identitaParente = identitaPadre;
                return esito;
            }
        }
        /// <summary>
        /// cerca Cerca l'dentità specificata nell'istruzione
        /// </summary>
        /// <param name="identita"></param>
        /// <param name="identitaParente"></param>
        /// <returns></returns>
        public GstErrori.EErrore CercaIdentita(ref CIdentita identita, out CIdentita identitaParente)
        {
            GstErrori.EErrore esito = GstErrori.EErrore.E0001_NOK;
            string ultimoNome = GetUltimoNome(0);
            string penultimoNome = GetUltimoNome(-1);
            int IndiceUltimoNome = GetIndiceUltimoNome(0);

            // esegue ricerca parente
            esito = CercaIdentita2(ref identita, out identitaParente);

            // verifica se ha trovato l'identità ricercata
           
            if ((identitaParente.Nome == GetUltimoNome(0)) && 
                (identitaParente.Livello == GetIndiceUltimoNome(0)) &&
                (identitaParente.ID == ID))
                return GstErrori.EErrore.E0000_OK;

            // controlla se è sul livello base cioè, 0
            if ((identitaParente.Livello == 0) && (GetIndiceUltimoNome(0) == 0))
                    return GstErrori.EErrore.E1374_IdentitaGenitore;

            // controlla se è un genitore non sul livello base
            if ((identitaParente.Nome == GetUltimoNome(-1)) && (identitaParente.Livello == GetIndiceUltimoNome(0)))
                return GstErrori.EErrore.E1374_IdentitaGenitore;





            return GstErrori.EErrore.E1371_IdentitaNOK;

        }


        /// <summary>
        /// Assegna l'oggento specificato nell'istruzione
        /// </summary>
        public  GstErrori.EErrore AssegnaIdentita(ref CIdentita identita)
        {
            GstErrori.EErrore esito = GstErrori.EErrore.E0001_NOK;

            // Cerca il figlio dell'identita
            CIdentita identitaGenitore = null;
            esito = CercaIdentita(ref identita, out identitaGenitore);
            if (esito == GstErrori.EErrore.E0000_OK)
            {
                // esiste già un identita con questo nome
                esito = GstErrori.EErrore.E1372_IdentitaEsiste;
            }
            else if (esito == GstErrori.EErrore.E1374_IdentitaGenitore)
            {
                // Ha trovato l'identità genitore
                identitaGenitore.Gruppo.Add(new CIdentita(ref identitaGenitore, this));
                esito = GstErrori.EErrore.E0000_OK;
            }

            return esito;
        }

    }
}

