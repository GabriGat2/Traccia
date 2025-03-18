using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace Traccia
{
    public class CArchivioEscursione : CArchivio
    {
        private CAreaArchivio areaArchivio;
        public CAreaArchivio AreaArchivio { get => areaArchivio; set => areaArchivio = value; }

        public string Data { get => GetCampo(0); }
        /// <summary>
        /// Prefisso
        /// </summary>
        public string Prefisso { get => GetCampo(1); }
        /// <summary>
        /// Nome parziale
        /// </summary>
        public string NomeParziale { get => GetCampo(2); }

        public void CAreaEscursione()
        {
            InizializzaClasse();
        }
        /// <summary>
        /// Aggiorna lo stato dei campi
        /// </summary>
        /// <returns></returns>
        public override EArchivioStato Aggiorna()
        {
            // verifica lo stato di Area Archivio
            if (areaArchivio.Stato != EArchivioStato.ArchivioEsiste)
                stato = areaArchivio.Stato;


            // Verifica se esiste il path dell'area archivio 
            if (!VerificaEsistenzaDirectory(AreaArchivio.Path))
            {
                path = string.Empty;
                stato = EArchivioStato.DirBaseNonEsiste;
                return stato;
            }

            // verifica il nome
            if (!VerificaNome())
                return stato;

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
        protected override void ComponePath()
        {
            string subPath = AreaArchivio.Directory.GetSubPathSrcArchivio("Archivi");

            path = AreaArchivio.Path + SeparaDir + subPath + SeparaDir + nome;
        }
        /// <summary>
        /// Rende il path dell'archivio escursioni
        /// </summary>
        /// <returns></returns>
        public String GetPathArchivoEscursioni ()
        {
            // Verifica che l'Area Archivio o sia corretta
            if (!AreaArchivio.StatoOk())
                return string.Empty;

            // Estra il subPath dell'archivio escursioni
            string subPath = AreaArchivio.Directory.GetSubPathSrcArchivio("Archivi");

            // compone il path degli archivi
            string pathArchivioEscursione = AreaArchivio.Path + SeparaDir + subPath;

            return pathArchivioEscursione;
        }
        /// <summary>
        /// Imposta il nome dell'escursione estraendolo dal path specificato
        /// </summary>
        /// <param name="path"></param>
        public void SetNome (string path)
        {
            // scompone il path
            string [] campi = path.Trim().Split('\\');
                
            // assegna l'ultimo campo come nome
            if (campi.Length > 0)
            {
                Nome = campi[campi.Length - 1];
            }
        }
    }
}
