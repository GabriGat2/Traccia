using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traccia
{
    public class CArchivio
    {
        public enum EArchivioStato
        {
            Indefinito,                 // 0                       
            DirBaseNonEsiste,           // 1
            NomeArchivioErrato,         // 2     
            ArchivioEsiste,             // 3   
            ArchivioNonEsiste           // 4
        };

        /// <summary>
        /// Speratore per path
        /// </summary>
        protected const string SeparaDir = "\\";
        /// <summary>
        /// Stato dell'archivio
        /// </summary>
        public EArchivioStato Stato { get => Aggiorna(); }

        /// <summary>
        /// Colore dello stato dell'archivio
        /// </summary>
        public Color Colore { get => ColoreStato(Aggiorna()); }

        /// <summary>
        /// Nome dell'archivio
        /// </summary>
        protected string nome = string.Empty;
        public string Nome {get => nome; set => AssegnaNome(value); }

        /// <summary>
        /// Path dell'archivio
        /// </summary>
        private string path;
        public string Path { get => path; }

        /// <summary>
        /// Path base dell'archivio
        /// </summary>
        private string pathBase = string.Empty;
        public string PathBase { get => pathBase; set => AssegnaPathBase(value); }


        /// <summary>
        /// Costruttore
        /// </summary>
        public CArchivio() 
        {
            InizializzaClasse();
        }
        protected void InizializzaClasse ()
        {
            //// Estrae la subdirectory degli archivi
            //CArchivioDirectory Arch = new CArchivioDirectory();
            //Arch.GetSubPathAreaEscursioni("Archivi", out string SubDirArchivi);
        }
        /// <summary>
        /// Assegna il path base
        /// </summary>
        /// <param name="value"></param>
        public void AssegnaPathBase(string value)
        {
            // assegna
            pathBase = value;

            // Aggiorna lo stato dei campi
            Aggiorna();
        }
        /// <summary>
        /// assegna il nome dell'archivio
        /// </summary>
        /// <param name="value"></param>
        public void AssegnaNome(string value)
        {
            // assegna il nome
            nome = value;

            // Aggiorna lo stato dei campi
            Aggiorna();
        }
        /// <summary>
        /// Aggiorna lo stato dei campi
        /// </summary>
        /// <returns></returns>
        public EArchivioStato Aggiorna()
        {
            // Verifica lo stato del parent
            EArchivioStato statoParent = StatoParent();
            if (statoParent != EArchivioStato.ArchivioEsiste)
                return statoParent;

            // verifica il nome
            if (!VerificaNome())
                return EArchivioStato.NomeArchivioErrato;

            // compone il path
            path = ComponePath();
            
            // verifica se la directory path esiste 
            if (VerificaEsistenzaDirectory(path))
                return EArchivioStato.ArchivioEsiste;
            else
                return EArchivioStato.ArchivioNonEsiste;
        }  
        /// <summary>
        /// Verifica lo stato del parent
        /// Questa funzione DEVE avere un override
        /// </summary>
        /// <returns></returns>
        protected virtual EArchivioStato StatoParent()
        {
            GstErrori.StampaMessaggioErrore
            (
                GstErrori.EErrore.E0004_QuestaFunzioneNonPuoEssereChiamataFareOverride,
                "E' obbligatorio fare l'override della funzione: ParentOK"
            );

            return EArchivioStato.Indefinito;
        }
        /// <summary>
        /// Compone la directory path
        /// ATTENZIONE è obbligatorio fare l'override di questa funzione
        /// </summary>
        protected virtual string ComponePath()
        {
            GstErrori.StampaMessaggioErrore
            (
                GstErrori.EErrore.E0004_QuestaFunzioneNonPuoEssereChiamataFareOverride,
                "E' obbligatorio fare l'override della funzione: ComponePath"
            );

            return string.Empty;
            //path = pathBase + SeparaDir + nome;
        }
        /// <summary>
        /// Verifica l'esitenza della directory
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        protected bool VerificaEsistenzaDirectory(string path)
        {
            // verifica se la directory esiste
            DirectoryInfo dir = new DirectoryInfo(path);
            return dir.Exists;
        }
        /// <summary>
        /// Rende il colore dello stato dell'archivio
        /// </summary>
        /// <returns></returns>
        public Color ColoreStato(EArchivioStato lStato)
        {
            Color colore;

            // colora il nome dell'archivio in funzione dell'esito della composizione
            switch (lStato)
            {
                default:
                case EArchivioStato.Indefinito:
                    colore = Color.White;
                    break;

                case EArchivioStato.DirBaseNonEsiste:
                    colore = Color.Red;
                    break;

                case EArchivioStato.NomeArchivioErrato:
                    colore = Color.LightPink;
                    break;

                case EArchivioStato.ArchivioEsiste:
                    colore = Color.LightGreen;
                    break;

                case EArchivioStato.ArchivioNonEsiste:
                    colore = Color.Yellow;
                    break;
            }

            return colore;
        }
        /// <summary>
        /// Torna vero se l'archivio esiste
        /// </summary>
        /// <returns></returns>
        public bool StatoOk()
        {
            EArchivioStato stato = Aggiorna();
            return stato == EArchivioStato.ArchivioEsiste;
        }
        /// <summary>
        /// Torna vero se il nome dell'archivio è corretto
        /// </summary>
        /// <returns></returns>
        public bool StatoOkNome()
        {
            EArchivioStato stato = Aggiorna();
            return ((stato == EArchivioStato.ArchivioEsiste) || stato == (EArchivioStato.ArchivioNonEsiste));
        }
        /// <summary>
        /// Verifica la composizione del nome
        /// </summary>
        /// <returns></returns>
        protected bool VerificaNome()
        {
            // verifica il nome
            if (nome.Length == 0)
            {
                return false;
            }
            else
            {
                // verifica che nel nome non ci siano spazi o '?'
                string[] campi = nome.Split(new char[] { ' ', '?' });
                if (campi.Length != 1)
                {
                    return false;
                }
            }

            return true;
        }
        /// <summary>
        /// Estra un campo dal nome
        /// </summary>
        /// <param name="indice"></param>
        /// <returns></returns>
        protected string GetCampo(int indice)
        {
            // scompone nome
            string[] campi = nome.Split('_');

            // verifica indice
            if (indice < campi.Length)
                return campi[indice];
            else
                return string.Empty;
        }
        public string GetOnlyData()
        {
            // estrae la data con la lettera
            string data1 = GetCampo(0);

            // scompone la data
            string[] campi = data1.Split(new char[] { '-' });

            if (campi.Length <= 3)
                return data1;
            else
                return campi[0] + '-' + campi[1] + '-' + campi[2];

        }
        /// <summary>
        /// Azzera il Nome e di conseguenza tutte le informazioni della traccia
        /// </summary>
        public void ClearNome()
        {
            Nome = string.Empty;
        }
        /// <summary>
        /// Crea le directory dell'archivio
        /// </summary>
        /// <returns></returns>
        public virtual GstErrori.EErrore CreaDirectoryArchivio()
        {
            return GstErrori.EErrore.E0001_NOK;
        }
    }
}
