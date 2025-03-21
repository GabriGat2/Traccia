using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traccia
{
    public class CInfo
    {
        /// <summary>
        /// Informazioni relative all'applicazione e all'area di archiviazione
        /// </summary>
        public CInfoArea Area = new CInfoArea();    
        /// <summary>
        /// Escursione
        /// </summary>
        public CInfoEscursione Escursione = new CInfoEscursione() ;
        /// <summary>
        /// Traccia
        /// </summary>
        public CInfoTraccia Traccia = new CInfoTraccia() ;  

        /// <summary>
        /// Costruttore
        /// </summary>
        public CInfo()
        {

        }
        /// <summary>
        /// Scrive il file info pre escursione
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public GstErrori.EErrore ScriveFileInfoEscursione(string path)
        {
            try
            {
                // Apre lo il file da scrivere
                StreamWriter sw = new StreamWriter(path);

                // stampa le informazioni dell'applicazione    
                Area.ScriveGruppoInfo(ref sw, "Area");


                // stampa le informazioni dell'escursione    
                Escursione.ScriveGruppoInfo(ref sw, "Escursione");


                //Close the file
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
                return GstErrori.EErrore.E0001_NOK;
            }

            return GstErrori.EErrore.E0000_OK;
        }

        /// <summary>
        /// Scrive il file info pre escursione
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public GstErrori.EErrore ScriveFileInfoTraccia(string path)
        {
            try
            {
                // Apre lo il file da scrivere
                StreamWriter sw = new StreamWriter(path);

                // stampa le informazioni dell'applicazione    
                Area.ScriveGruppoInfo(ref sw, "Area");

                // stampa le informazioni dell'escursione    
                Escursione.ScriveGruppoInfo(ref sw, "Escursione");


                // stampa le informazioni della traccia    
                Traccia.ScriveGruppoInfo(ref sw, "Traccia");


                //Close the file
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
                return GstErrori.EErrore.E0001_NOK;
            }

            return GstErrori.EErrore.E0000_OK;
        }




    }

    // ======================================================================================================================
    // ======================================================================================================================
    // ======================================================================================================================

    public class CInfoBase
    {
        /// <summary>
        /// Costruttore
        /// </summary>
        public CInfoBase()
        {
            //StampaErroreOverride("Popola");
        }

        /// <summary>
        /// Popola la struttura delle info 
        /// </summary>
        protected virtual void Popola()
        {
            StampaErroreOverride("Popola");
        }
        /// <summary>
        /// Recupera il gruppo delle informazioni
        /// </summary>
        /// <param name="gruppoInfo"></param>
        /// <returns></returns>
        protected virtual bool GetGruppoInfo(out List<CInfoCampo> gruppoInfo)
        {
            StampaErroreOverride("GetGruppoInfoo");
            gruppoInfo = null;
            return false;
        }
        /// <summary>
        /// Stampa un errore di mancato override
        /// </summary>
        /// <param name="nomeFunzione"></param>
        /// <returns></returns>
        private GstErrori.EErrore StampaErroreOverride(string nomeFunzione)
        {
            GstErrori.StampaMessaggioErrore
            (
                GstErrori.EErrore.E0004_QuestaFunzioneNonPuoEssereChiamataFareOverride,
                "E' obbligatorio fare l'override della funzione: " + nomeFunzione
            );

            return GstErrori.EErrore.E0004_QuestaFunzioneNonPuoEssereChiamataFareOverride;
        }
        /// <summary>
        /// Scrive un valore nel campo specificato del gruppo info
        /// </summary>
        /// <param name="nome">Nome del campo</param>
        /// <param name="valore">Valore del campo</param>
        /// <returns></returns>
        public virtual bool Set(string nome, string valore)
        {
            // recupera la directory del gruppo info
            List<CInfoCampo> gruppoInfo;
            if (!GetGruppoInfo(out gruppoInfo))
                return false;

            // Esamina DirArchivioAreaEscursione
            foreach (var info in gruppoInfo)
            {
                if (info.Nome == nome)
                {
                    info.Valore = valore;
                    return true;
                }
            }

            // il nome richiesto non esite
            return false;
        }
        /// <summary>
        /// Legge un valore dal campo specificato del gruppo info
        /// </summary>
        /// <param name="nome">Nome del campo</param>
        /// <param name="valore">Valore del campo</param>
        /// <returns></returns>
        public virtual bool Get(string nome, out string valore)
        {
            // inizializza valore
            valore = null;  

            // recupera la directory del gruppo info
            List<CInfoCampo> gruppoInfo;
            if (!GetGruppoInfo(out gruppoInfo))
                return false;

            // Esamina DirArchivioAreaEscursione
            foreach (var info in gruppoInfo)
            {
                if (info.Nome == nome)
                {
                    valore = info.Valore;
                    return true;
                }
            }

            // il nome richiesto non esite
            return false;
        }
        /// <summary>
        /// Rende il valore del campo specificato del gruppo info
        /// </summary>
        /// <param name="nome">Nome del campo</param>
        /// <param name="path">Valore del campo</param>
        /// <returns></returns>
        public virtual string Get(string nome)
        {
            // recupera la directory del gruppo info
            List<CInfoCampo> gruppoInfo;
            if (!GetGruppoInfo(out gruppoInfo))
                return string.Empty;

            // Esamina DirArchivioAreaEscursione
            foreach (var info in gruppoInfo)
            {
                if (info.Nome == nome)
                {
                    return info.Valore;
                }
            }

            // il nome richiesto non esite
            return string.Empty;
        }
        /// <summary>
        /// scrive il gruppo di informazioni
        /// </summary>
        /// <param name="sw"></param>
        /// <returns></returns>
        public GstErrori.EErrore ScriveGruppoInfo(ref StreamWriter sw, string prefisso)
        {
            // recupera la directory del gruppo info
            List<CInfoCampo> gruppoInfo;
            if (!GetGruppoInfo(out gruppoInfo))
                return GstErrori.EErrore.E0001_NOK;


            try
            {
                foreach (var info in gruppoInfo)
                {
                    // compone l'informazione 
                    string lineaInfo = prefisso + "=" + info.Nome + "=" + info.Valore;

                    // scrive l'informazione
                    sw.WriteLine(lineaInfo);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
                return GstErrori.EErrore.E0001_NOK;
            }

            return GstErrori.EErrore.E0000_OK;
        }
    }


    // ======================================================================================================================
    // ======================================================================================================================
    // ======================================================================================================================

    public class CInfoArea : CInfoBase
    {
        /// <summary>
        /// Definizione Informazioni Applicazione
        /// </summary>
        private List<CInfoCampo> GruppoInfo = new List<CInfoCampo>();
        protected override void Popola()
        {
            GruppoInfo.Add(new CInfoCampo("Applicazione", "Traccia"));
            GruppoInfo.Add(new CInfoCampo("Versione", "1"));
            GruppoInfo.Add(new CInfoCampo("Revisione", "0"));
        }
        /// <summary>
        /// Recupera il gruppo delle informazioni
        /// </summary>
        /// <param name="gruppoInfo"></param>
        /// <returns></returns>
        protected override bool GetGruppoInfo(out List<CInfoCampo> gruppoInfo)
        {
            gruppoInfo = GruppoInfo;
            return true;
        }

        /// <summary>
        /// Costruttore
        /// </summary>
        public CInfoArea()
        {
            Popola();
        }
    }



    // ======================================================================================================================
    // ======================================================================================================================
    // ======================================================================================================================

    public class CInfoEscursione : CInfoBase
    {
        /// <summary>
        /// Definizione Informazioni Escursione
        /// </summary>
        private List<CInfoCampo> GruppoInfo = new List<CInfoCampo>();
        protected override void Popola()
        {
            GruppoInfo.Add(new CInfoCampo("Nome", ""));
        }
        /// Recupera il gruppo delle informazioni
        /// </summary>
        /// <param name="gruppoInfo"></param>
        /// <returns></returns>
        protected override bool GetGruppoInfo(out List<CInfoCampo> gruppoInfo)
        {
            gruppoInfo = GruppoInfo;
            return true;
        }
        /// <summary>
        /// Costruttore
        /// </summary>
        public CInfoEscursione()
        {
            Popola();
        }
    }

    // ======================================================================================================================
    // ======================================================================================================================
    // ======================================================================================================================


    public class CInfoTraccia : CInfoBase
    {
        /// <summary>
        /// Definizione Informazioni Traccia
        /// </summary>
        private List<CInfoCampo> GruppoInfo = new List<CInfoCampo>();
        protected override void Popola()
        {
            GruppoInfo.Add(new CInfoCampo("Nome", ""));
            GruppoInfo.Add(new CInfoCampo("Path", ""));

            GruppoInfo.Add(new CInfoCampo("OptGiorno", "0"));
            GruppoInfo.Add(new CInfoCampo("OptSingola", "0"));

            GruppoInfo.Add(new CInfoCampo("Mezzo", ""));
        }
        /// Recupera il gruppo delle informazioni
        /// </summary>
        /// <param name="gruppoInfo"></param>
        /// <returns></returns>
        protected override bool GetGruppoInfo(out List<CInfoCampo> gruppoInfo)
        {
            gruppoInfo = GruppoInfo;
            return true;
        }

        /// <summary>
        /// Costruttore
        /// </summary>
        public CInfoTraccia()
        {
            Popola();
        }
    }

    // ======================================================================================================================
    // ======================================================================================================================
    // ======================================================================================================================

    public class CInfoCampo
    {
        // nome dell'info
        private string nome;
        public string Nome { get => nome; }

        // valore dell'info in formato stringa
        private string valore;
        public string Valore { get => valore; set => valore = value; }
        /// <summary>



        // costruttore stringa
        public CInfoCampo(string nome, string valore)
        {
            this.nome = nome;   
            this.Valore = valore;
        }
    }




    // ======================================================================================================================
    // ======================================================================================================================
    // ======================================================================================================================

    public class CInfoCampoInt
    {
        // valore dell'info in formato stringa
        private string iValore;

        /// <summary>
        /// valore in formato stringa
        /// </summary>
        public string sValore { get => iValore; set => iValore = value; }
        /// <summary>
        /// valore in formato intero
        /// </summary>
        public int Valore { get => Convert.ToInt32(iValore); set => iValore = value.ToString(); }



        // costruttore stringa
        public CInfoCampoInt(string sValore)
        {
            this.sValore = sValore;
        }
        // costruttore int
        public CInfoCampoInt(int valore)
        {
            this.Valore = valore;
        }
    }
    
    // ======================================================================================================================
    // ======================================================================================================================
    // ======================================================================================================================

    public class CInfoCampoStringa
    {
        // valore dell'info in formato stringa
        private string iValore;

        /// <summary>
        /// valore in formato stringa
        /// </summary>
        public string sValore { get => iValore; set => iValore = value; }


        // costruttore stringa
        public CInfoCampoStringa(string sValore)
        {
            this.sValore = sValore;
        }
    }

    // ======================================================================================================================
    // ======================================================================================================================
    // ======================================================================================================================

    public class CInfoCampoBool
    {
        // valore dell'info in formato stringa
        private string iValore;

        /// <summary>
        /// valore in formato stringa
        /// </summary>
        public string sValore { get => iValore; set => iValore = value; }

        /// <summary>
        /// valore in formato booleano
        /// </summary>
        /// <param name="sValore"></param>
        private bool valore;
        public bool Valore { get => Convert.ToBoolean(iValore); set => iValore = value.ToString(); }


        // costruttore stringa
        public CInfoCampoBool(string sValore)
        {
            this.sValore = sValore;
        }
        
        // costruttore booleano
        public CInfoCampoBool(bool valore)
        {
            this.Valore = valore;
        }
    }



}
