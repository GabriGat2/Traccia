using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traccia
{
    public class CArchivioTraccia : CArchivio
    {
        /// <summary>
        /// Area escursione
        /// </summary>
        private CArchivioEscursione escursione;
        public CArchivioEscursione Escursione { get => escursione; set => escursione = value; }

        /// <summary>
        /// Modi di archiviazione della traccia nell'area dell'escursione
        /// </summary>
        public enum EModoArchiviazione
        {
            Base,                       // 0                       
            Giorno,                     // 1
            Singola,                    // 2     
            GiornoSingola               // 3   
        };
        /// <summary>
        /// Opzione per l'aganizzzazione delle tracce per giorno
        /// </summary>
        private bool optGiorno;
        public bool OptGiorno { get => optGiorno; set => AggiornaOptGiorno(value); }
        private void AggiornaOptGiorno(bool value)
        {
            optGiorno = value;
            Aggiorna();
        }
        /// <summary>
        /// pzione per l'aganizzzazione delle tracce singolarmente
        /// </summary>
        private bool optSingola;
        public bool OptSingola { get => optSingola; set => AggiornaOptSingola(value); }
        private void AggiornaOptSingola(bool value)
        {
            optSingola = value;
            Aggiorna();
        }
        /// <summary>
        /// Mezzo
        /// </summary>
        public string mezzo;
        public string Mezzo { get => mezzo; set => mezzo = value; }



        /// Verifica lo stato del parent
        /// </summary>
        /// <returns></returns>
        protected override EArchivioStato StatoParent()
        {
            return Escursione.Stato;
        }
        /// <summary>
        /// Crea le directory della traccia
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
                    return GstErrori.EErrore.E1333_PathTracciaEsiste;

                default:
                    return GstErrori.EErrore.E1313_PathTracciaErrato;
            }

            // Crea directory traccia
            GstErrori.EErrore esito = Escursione.AreaArchivio.Directory.Traccia.CreaArchivio(Path, Nome);

            // Aggiorna lo stato della traccia
            //EArchivioStato passa = Stato;

            // Rende l'esito delle operazioni
            return esito;
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


            switch (ModoArchiviazione())
            {
                default:
                case EModoArchiviazione.Base:
                    path = pathEscursione;
                    break;

                case EModoArchiviazione.Singola:
                    path = pathEscursione + SeparaDir + subDirArchivio + SeparaDir + nome;
                    break;

                case EModoArchiviazione.Giorno:
                    path = pathEscursione + SeparaDir + subDirArchivio + SeparaDir + GetOnlyData();
                    break;

                case EModoArchiviazione.GiornoSingola:
                    path = pathEscursione + SeparaDir + subDirArchivio + SeparaDir + GetOnlyData() + SeparaDir + nome;
                    break;
            }

            return path;
        }
        /// <summary>
        /// Modo di archiviazione ottenuto codificando le opzioni
        /// </summary>
        /// <returns></returns>
        private EModoArchiviazione ModoArchiviazione()
        {
            EModoArchiviazione modo;

            if (!optSingola && !OptGiorno)
                modo = EModoArchiviazione.Base;
            else if (optSingola && !OptGiorno)
                modo = EModoArchiviazione.Singola;
            else if (!optSingola && OptGiorno)
                modo = EModoArchiviazione.Giorno;
            else if (optSingola && OptGiorno)
                modo = EModoArchiviazione.GiornoSingola;
            else
                modo = EModoArchiviazione.Base;

            return modo;
        }
        /// <summary>
        /// Scrive le informazioni Info TRaccia
        /// </summary>
        public bool ScriveInfo()
        {
            bool bEsito;
            bEsito = Escursione.Info.Traccia.Set("Nome", Nome);
 
            // Estrae il nome path relativo del file
            string pathRealtivo = Path.Substring(Escursione.Path.Length + 1);
            bEsito = Escursione.Info.Traccia.Set("Path", pathRealtivo);


            bEsito = Escursione.Info.Traccia.Set("OptGiorno", optGiorno.ToString());
            bEsito = Escursione.Info.Traccia.Set("OptSingola", optSingola.ToString());

            bEsito = Escursione.Info.Traccia.Set("Mezzo", Mezzo);

            return bEsito;
        }
        /// <summary>
        /// Scrive il file info Ttraccia
        /// </summary>
        public void ScriveFileInfo()
        {
            // aggiorna le info
            Escursione.ScriveInfo();
            ScriveInfo();


            // compone il path del file info
            string pathInfo = GetPathInfo() + SeparaDir + Nome + ".txt";


            GstErrori.EErrore esito = Escursione.Info.ScriveFileInfoTraccia(pathInfo);
        }
        /// <summary>
        /// Rende il path della directory Info delle tracce
        /// </summary>
        /// <returns></returns>
        public string GetPathInfo ()
        {
            // compone il path del file info
            return  Escursione.Path + SeparaDir + Escursione.AreaArchivio.Directory.Escursione.GetSubPath("InfoT");

        }

        /// <summary>
        /// Legge un file info traccia
        /// </summary>
        /// <param name="pathFileInfo"></param>
        /// <returns></returns>
        public GstErrori.EErrore LeggeFileInfo (string pathFileInfo)
        {
            // pulisce la traccia
            ClearTraccia();
            

            // Legge il file info della traccia specificata
            GstErrori.EErrore esito = Escursione.Info.LeggeFileInfoTraccia (pathFileInfo);
            if (esito != GstErrori.EErrore.E0000_OK)
                return esito;

            // Assegna i valori letti
            Mezzo = Escursione.Info.Traccia.Get("Mezzo");

            optGiorno = Convert.ToBoolean(Escursione.Info.Traccia.Get("OptGiorno"));
            optSingola = Convert.ToBoolean(Escursione.Info.Traccia.Get("OptSingola"));

            Nome = Escursione.Info.Traccia.Get("Nome");

            return GstErrori.EErrore.E0000_OK;
        }
        /// <summary>
        /// azzera tutti icampi della traccia
        /// </summary>
        public void ClearTraccia()
        {
            Mezzo = String.Empty;

            optGiorno = false;
            optSingola = false;

            Nome = String.Empty;    
        }
        /// <summary>
        /// Rende la lettera della data
        /// </summary>
        /// <returns></returns>
        public char GetLettera()
        {
            // estrae la data
            string data = GetCampo(0);

            // scompone la data
            string[] campo = data.Split('-');

            // rende la letterea
            if (campo.Length == 4)
            {
                if (campo[3].Length == 1)
                    return campo[3].ElementAt(0);
                else
                    return 'Z';
            }
            else
            {
                return 'Z';
            }

        }
        
    }
}
