using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Traccia
{
    public static class GstErrori
    {
        // =====================================================================================
        // ====== Codice errore
        // =====================================================================================
        public enum EErrore
        {
            E0000_OK = 0,
            E0001_NOK = 1,
            E0002_ValoreNonRichiesto,

            // Errori relativi alla gestione di una tabelle
            E1000_TabellaInesistente,
            E1001_ColonnaTabellaFuoriLimiti,
            E1002_RigaTabellaFuoriLimiti,
            E1003_CellaTabellaFuoriLimiti,
            E1004_IndiceColonnaTabellaFuoriLimiti,
            E1005_IndiceRigaTabellaFuoriLimiti,
            E1006_IndiceCellaTabellaFuoriLimiti,
            E1007_LaDimensioniDelleTabelleSorgenteEDestinazioneSonoDiverse ,

            // Stato dei conti
            E1100_IContiNonSonoBilanciati,
            E1101_ISottoContiAttiviSonoDiversi,
            E1102_IContiBaseSonoDiversi,
            E1103_StrutturaDeiContiNonDisponibile,


            // Operazioni
            E1200_UnaOperazioneInCorso,

            // Gestione directory
            E1300_NomeArchivioErrato,
            E1301_CreazioneDirectoryFallita,
            E1302_CreazioneArchivioFallita,




            // Errori relativi ad un tipo di dato
            //10 sbyte System.SByte
            //20 byte System.Byte
            //30 short System.Int16
            //40 ushort System.UInt16
            //50 int System.Int32
            //60 uint System.UInt32
            //70 long System.Int64
            //80 ulong System.UInt64
            //90 char System.Char
            //100 float System.Single

            E2100_double_LaStringaNonContieneUnValoreDouble,
            // 110 bool System.Boolean
            // 120 decimal System.Decimal


        }



        /// <summary>
        /// Costruttore
        /// </summary>
        //public GstErrori()
        //{

        //}
        /// <summary>
        /// Esamina una stringa e sostituisce:
        /// - La lettera maiuscola con spazio + lettera maiuscola
        /// - il cratttere '_' con spazio
        /// </summary>
        /// <param name="error"></param>
        /// <returns></returns>
        public static string RestultToSting(EErrore error)
        {
            string errore = error.ToString();
            string messaggioErrore = "";

            // sostituisci tutte le lettere maiuscole con spazio-lettera
            bool maiuscola = true;
            for (int i = 0; i < errore.Length; i++)
            {
                               
                if (Char.IsUpper(errore[i]) && i > 0)
                {
                    messaggioErrore += " ";
                    if (maiuscola)
                    {
                        messaggioErrore += errore[i];
                        maiuscola = false;
                    }
                    else
                        messaggioErrore += Char.ToLower(errore[i]);
                }
                else if (errore[i] == '_')
                {
                    messaggioErrore += ":";
                    messaggioErrore += " ";
                    maiuscola = true;
                }
                else
                    messaggioErrore += errore[i];
            }

            return messaggioErrore;
        }
        /// <summary>
        /// Stampa un messaggio di errore
        /// </summary>
        /// <param name="result"></param>
        /// <param name="messaggio2"></param>
        /// <param name="stampaMessaggio"></param>
        /// <returns></returns>
        public static bool StampaMessaggioErrore(GstErrori.EErrore esito, string messaggio2 = "", bool stampaMessaggio = true, bool continuo = true)
        {
            // controlla l'esito del risultatao
            if (esito != EErrore.E0000_OK)
            {
                if (stampaMessaggio)
                {
                    // compone il messaggio da stampare
                    string titolo = "Errore!";
                    string messaggio = "Problema: \n" + messaggio2 + "\n\n" +
                                       "ha generato l'errore: \n\n" +
                                       RestultToSting(esito);

                    // Chiede la conferma per continuare                    
                    if (continuo)
                    {
                        messaggio += "\n\n" + "Continuo?";

                        //  stampa il messaggio con l'esito
                        var result3 = MessageBox.Show(messaggio, titolo, MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                        if (result3 == DialogResult.Yes)
                            return true;
                        else
                            return false;
                    }

                    // Rende sempre FALSE
                    if (!continuo)
                    {
                        //  stampa il messaggio con l'esito
                        var result3 = MessageBox.Show(messaggio, titolo, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    return false;
                }
                else
                    return false;
            }

            return true;
        }
    }
}
