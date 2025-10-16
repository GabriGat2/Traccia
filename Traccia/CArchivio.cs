using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        public string Path { get => path; }
        private string path;
        /// <summary>
        /// Path base dell'archivio
        /// </summary>
        public string PathBase { get => pathBase; set => AssegnaPathBase(value); }
        private string pathBase = string.Empty;
        /// <summary>
        /// Luogo
        /// </summary>
        public string Luogo { get => luogo; set => luogo = value; }
        private string luogo = string.Empty;
        /// <summary>
        /// ID del lugo
        /// </summary>
        public string LuogoID { get => luogoID; set => luogoID = value; }   
        private string luogoID = string.Empty;

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
            // verifica che la stringa non sia vuota
            if (path.Length == 0) 
                return false;

            // verifica se la directory esiste
            DirectoryInfo dir = new DirectoryInfo(path);
            return dir.Exists;
        }
        /// <summary>
        /// Rende il colore dello stato dell'archivio
        /// </summary>
        /// <returns></returns>
        public virtual Color ColoreStato(EArchivioStato lStato)
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
        /// Estrae un campo dal nome
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
        /// <summary>
        /// Rende la data senza la lettera
        /// </summary>
        /// <returns></returns>
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
        /// Rende la data in formato DataTIme
        /// </summary>
        /// <returns></returns>
        public virtual DateTime GetData()
        {
            // estrae la data con la lettera
            string sData = GetOnlyData();

            // scompone la data
            string[] cData = sData.Split('-');
            if (cData.Length == 3)
                return new DateTime(Convert.ToInt16(cData[0]), Convert.ToInt16(cData[1]), Convert.ToInt16(cData[2]));
            else if (cData.Length == 2)
                return new DateTime(Convert.ToInt16(cData[0]), Convert.ToInt16(cData[1]), 1);
            else if (cData.Length == 1)
                return new DateTime(Convert.ToInt16(cData[0]), 1, 1);
            else
                return new DateTime(1998, 1, 1);
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
        /// <summary>
        /// Scrive il file luogo
        /// </summary>
        /// <returns></returns>
        public virtual GstErrori.EErrore ScriveFileLuogo()
        {
            return GstErrori.EErrore.E0001_NOK;
        }
        /// <summary>
        /// scrive nel file luogo le informazioni dell'identità
        /// </summary>
        /// <param name="area"></param>
        /// <param name="sw"></param>
        /// <returns></returns>
        protected GstErrori.EErrore ScriveLuogo(ref CAreaArchivio area, ref StreamWriter sw)
        {
            GstErrori.EErrore esito = GstErrori.EErrore.E0001_NOK;
            try
            {
                // cerca l'identita del luogo
                CIdentita figlio;
                esito = area.Identita.CercaFiglio(area.Identita.IDToglieSeparatori(luogoID), out figlio);
                if (esito != GstErrori.EErrore.E0000_OK)
                    return esito;

                // Scrive i dati del luogo
                ScriveIdentita("Luogo", ref sw, ref figlio);

                // stampa i tag
                int i = 1;
                foreach (var tagID in figlio.Tag)
                {
                    // cerca l'identita del tag
                    CIdentita nipote;
                    esito = area.Identita.CercaFiglio(tagID, out nipote);
                    if (esito != GstErrori.EErrore.E0000_OK)
                        return esito;

                    // Scrive i dati del tag
                    ScriveIdentita("Tag " + i.ToString(), ref sw, ref nipote);

                    i++;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
                return GstErrori.EErrore.E0001_NOK;
            }

            return esito;
        }

        protected GstErrori.EErrore ScriveLuogo(ref CIdentita rIdentita, ref StreamWriter sw)
        {
            GstErrori.EErrore esito = GstErrori.EErrore.E0001_NOK;
            try
            {
                // cerca l'identita del luogo
                CIdentita figlio;
                esito = rIdentita.CercaFiglio(rIdentita.IDToglieSeparatori(luogoID), out figlio);
                if (esito != GstErrori.EErrore.E0000_OK)
                    return esito;

                // Scrive i dati del luogo
                ScriveIdentita("Luogo", ref sw, ref figlio);

                // stampa i tag
                int i = 1;
                foreach (var tagID in figlio.Tag)
                {
                    // cerca l'identita del tag
                    CIdentita nipote;
                    esito = rIdentita.CercaFiglio(tagID, out nipote);
                    if (esito != GstErrori.EErrore.E0000_OK)
                        return esito;

                    // Scrive i dati del tag
                    ScriveIdentita("Tag " + i.ToString(), ref sw, ref nipote);

                    i++;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
                return GstErrori.EErrore.E0001_NOK;
            }

            return esito;
        }


        /// <summary>
        /// Scrive i dati dell'identità 
        /// </summary>
        /// <param name="titolo"></param>
        /// <param name="sw"></param>
        /// <param name="identita"></param>
        /// <returns></returns>
        private GstErrori.EErrore ScriveIdentita(string titolo, ref StreamWriter sw, ref CIdentita identita)
        {

            try
            {
                sw.WriteLine("------------------------------------------------------------------");
                sw.WriteLine(titolo);
                sw.WriteLine("------------------------------------------------------------------");
                sw.WriteLine("nome    : " + identita.Nome);
                sw.WriteLine("Genitori: " + identita.StampaGenitori());
                sw.WriteLine("Sigla   : " + identita.Sigla);
                sw.WriteLine("ID      : " + identita.IDAggiungeSeparatori());
                sw.WriteLine("==================================================================");
                sw.WriteLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
                return GstErrori.EErrore.E0001_NOK;
            }

            return GstErrori.EErrore.E0000_OK;
        }
        /// <summary>
        /// Copia i dati della classe
        /// </summary>
        /// <returns></returns>
        public GstErrori.EErrore Copia(CArchivio archivioSrc)
        {
            return GstErrori.EErrore.E0001_NOK;
        }

    }
}
