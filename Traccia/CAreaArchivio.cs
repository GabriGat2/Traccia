using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traccia
{
    public class CAreaArchivio
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
        private const string SeparaDir = "\\";

        /// <summary>
        /// Stato dell'archivio
        /// </summary>
        private EArchivioStato stato = EArchivioStato.Indefinito;
        public EArchivioStato Stato { get => stato; }

        /// <summary>
        /// Colore dello stato dell'archivio
        /// </summary>
        public Color Colore { get => ColoreStato(stato); }

        /// <summary>
        /// Nome dell'archivio
        /// </summary>
        private string nome = string.Empty;
        public string Nome {get => nome; set => AssegnaNome(value); }

        /// <summary>
        /// Path dell'archivio
        /// </summary>
        private string path = string.Empty;
        public string Path { get => path; }

        /// <summary>
        /// Path base dell'archivio
        /// </summary>
        private string pathBase = string.Empty;
        public string PathBase { get => pathBase; set => AssegnaPathBase(value); }


        /// <summary>
        /// Costruttore
        /// </summary>
        public CAreaArchivio() 
        { 
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
            nome = string.Empty;

            // Aggiorna lo stato dei campi
            Aggiorna();
        }
        /// <summary>
        /// Aggiorna lo stato dei campi
        /// </summary>
        /// <returns></returns>
        public EArchivioStato Aggiorna()
        {
            // Verifica se esiste il pathBase
            if (!VerificaEsistenzaDirectory(pathBase))
            {
                path = string.Empty;
                stato = EArchivioStato.DirBaseNonEsiste;
                return stato;
            }

            // verifica il nome
            if (nome.Length == 0)
            {
                path = string.Empty;
                stato = EArchivioStato.NomeArchivioErrato;
                return stato;
            }
            else
            {
                // verifica che nel nome non ci siano spazi o '?'
                string[] campi = nome.Split(new char[] { ' ', '?' });
                if (campi.Length != 1)
                {
                    path = string.Empty;
                    stato = EArchivioStato.NomeArchivioErrato;
                    return stato;
                }
            }
            
            // Compone il path
            ComponePath();

            // verifica se la directory path esiste 
            if (VerificaEsistenzaDirectory(path))
                stato = EArchivioStato.ArchivioEsiste;
            else
                stato = EArchivioStato.ArchivioNonEsiste;

            return stato; 
        }   

        /// <summary>
        /// Compone la directory path
        /// </summary>
        protected void ComponePath()
        {
            path = pathBase + SeparaDir + nome;
        }
        /// <summary>
        /// Verifica l'esitenza della directory
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private bool VerificaEsistenzaDirectory(string path)
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
            return stato == EArchivioStato.ArchivioEsiste;
        }


    }
}
