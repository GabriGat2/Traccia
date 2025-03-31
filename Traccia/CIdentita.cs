using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traccia
{
    public class CIdentita
    {
        /// <summary>
        /// Nome
        /// </summary>
        public string Nome { get => nome; set => nome = value; }
        private string nome;
        /// <summary>
        /// Prefisso associato al nome
        /// </summary>
        public string Prefisso { get => prefisso; set => prefisso = value; }
        private string prefisso;
        /// <summary>
        /// Parenti del nome
        /// </summary>
        public string Parenti { get => parenti; set => parenti = value; }
        private string parenti;
        /// <summary>
        /// Tipo del nome
        /// </summary>
        public string Tipo { get => Tipo; set => Tipo = value; }
        private string tipo;
        /// <summary>
        /// Genitore
        /// </summary>
        public CIdentita Genitore { get => genitore; set => genitore = value; }        
        private CIdentita genitore;
        /// <summary>
        /// Gruppo figli
        /// </summary>
        public List<CIdentita> Gruppo { get => gruppo; set => gruppo = value; }
        private List<CIdentita> gruppo = new List<CIdentita>();
        /// <summary>
        /// Costruttore
        /// </summary>
        public CIdentita() 
        { 
        }

    }
}
