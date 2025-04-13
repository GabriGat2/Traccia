using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using static Traccia.CArchivio;

namespace Traccia
{
    public class CArchivioEscursione : CArchivio
    {
        /// <summary>
        /// Informazioni traccia
        /// </summary>
        public CInfo Info = new CInfo();    

        private CAreaArchivio areaArchivio;
        public CAreaArchivio AreaArchivio { get => areaArchivio; set => areaArchivio = value; }

        public string Data { get => GetCampo(0); }
        /// <summary>
        /// Sigla
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
        /// Verifica lo stato del parent
        /// </summary>
        /// <returns></returns>
        protected override EArchivioStato StatoParent()
        {
            return AreaArchivio.Stato;
        }
        /// <summary>
        /// Compone la directory path
        /// </summary>
        protected override string ComponePath()
        {
            // estrae la subdir Archivi
            string subPath = AreaArchivio.Directory.Area.GetSubPath("Archivi");

            // compone il path
            return AreaArchivio.Path + SeparaDir + subPath + SeparaDir + nome;
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
            string subPath = AreaArchivio.Directory.Area.GetSubPath("Archivi");

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
        /// <summary>
        /// Crea le directory dell'escursione
        /// </summary>
        /// <returns></returns>
        public override GstErrori.EErrore CreaDirectoryArchivio()
        {
            // verifica che ci siano le condizioni per creare la directory
            switch (Stato)
            {
                case EArchivioStato.ArchivioNonEsiste:
                    break;

                case EArchivioStato.ArchivioEsiste:
                    return GstErrori.EErrore.E1332_PathEscursioneEsiste;

                default:
                    return GstErrori.EErrore.E1312_PathEscursioneErrato;
            }

            // Crea directory traccia
            GstErrori.EErrore esito = AreaArchivio.Directory.Escursione.CreaArchivio(Path, Nome);

            // Aggiorna lo stato della traccia
            EArchivioStato passa = Stato;

            // Rende l'esito delle operazioni
            return esito;
        }
        /// <summary>
        /// Legge un file info traccia
        /// </summary>
        /// <param name="pathFileInfo"></param>
        /// <returns></returns>
        public GstErrori.EErrore LeggeFileInfo(string pathFileInfo)
        {
            // pulisce la traccia
            //ClearEscursione();


            // Legge il file info della traccia specificata
            GstErrori.EErrore esito = Info.LeggeFileInfoEscursione(pathFileInfo);
            if (esito != GstErrori.EErrore.E0000_OK)
                return esito;

            // Assegna i valori letti
            Luogo = Info.Escursione.Get("Luogo");
            LuogoID = Info.Escursione.Get("LuogoID");

            return GstErrori.EErrore.E0000_OK;
        }
        /// <summary>
        /// Scrive le informazioni Info Escursione
        /// </summary>
        public bool ScriveInfo()
        {
            bool bEsito;

            bEsito = Info.Area.Set("Data", DateTime.Now.ToString());

            bEsito = Info.Escursione.Set("Nome", Nome);
            bEsito = Info.Escursione.Set("Luogo", Luogo);
            bEsito = Info.Escursione.Set("LuogoID", LuogoID);
            return bEsito;
        }
        /// <summary>
        /// Scrive il file info Escursione
        /// </summary>
        public void ScriveFileInfo()
        {
            // aggiorna le info
            bool bEsito = ScriveInfo();

            // compone il path del file info
            string pathInfo = Path + SeparaDir + AreaArchivio.Directory.Escursione.GetSubPath("Info") + SeparaDir + Nome + ".txt";

            GstErrori.EErrore esito = Info.ScriveFileInfoEscursione(pathInfo);
        }
        /// <summary>
        /// Scrive il file luogo
        /// </summary>
        /// <returns></returns>
        public override GstErrori.EErrore ScriveFileLuogo()
        {
            GstErrori.EErrore esito = GstErrori.EErrore.E0001_NOK;

            // compone il path del file luogo
            string pathLuogo = Path + SeparaDir + AreaArchivio.Directory.Escursione.GetSubPath("InfoL") + SeparaDir + "Luogo_" + Nome + ".txt";

            try
            {
                // Apre lo il file da scrivere
                StreamWriter sw = new StreamWriter(pathLuogo);

                // stampa le informazioni dell'applicazione
                esito = ScriveLuogo(ref areaArchivio, ref sw);

                //Close the file
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
                return GstErrori.EErrore.E0001_NOK;
            }

            return esito;
        }
    }
}
