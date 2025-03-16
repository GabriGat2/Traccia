using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traccia
{
    public class CMessaggio
    {
        private System.Windows.Forms.RichTextBox WinOutput;

        /// <summary>
        /// costruttore
        /// </summary>
        public CMessaggio(ref System.Windows.Forms.RichTextBox winOutput)
        {
            WinOutput = winOutput;
        }
        /// <summary>
        /// Verifica se WInOutput è configurato correttamente
        /// </summary>
        /// <returns></returns>
        public bool VerificaWinOutput()
        {
            if (WinOutput == null)
            {
                GstErrori.StampaMessaggioErrore(GstErrori.EErrore.E0003_FinestraDeiMessaggiNonDefinita, "", true, false);
                return false;
            }
            else
                return true;
        }
        /// <summary>
        /// Stampa un massaggio
        /// </summary>
        /// <param name="messaggio"></param>
        public void Stampa(string messaggio, bool acapo = true, bool muto = false)
        {
            if (muto)
                return;   
            
            // verifica WinOutput
            if (!VerificaWinOutput())
                return;

            if (acapo)
                WinOutput.AppendText("\n");

            // stampa il messaggio
            WinOutput.AppendText(messaggio);
            WinOutput.ScrollToCaret();
        }
        /// <summary>
        /// Stampa un messaggio in funzione dell'esito
        /// </summary>
        /// <param name="messaggio"></param>
        /// <param name="messaggioNOK"></param>
        /// <param name="esito"></param>
        /// <param name="acapo"></param>
        /// <param name="muto"></param>
        public void StampaConEsito(string messaggio, string messaggioNOK, GstErrori.EErrore esito, bool acapo = true, bool muto = false)
        {
            if (esito == GstErrori.EErrore.E0000_OK)
                Stampa(messaggio, acapo, muto);
            else
                Stampa(messaggioNOK, acapo, muto);
        }
    }
}
