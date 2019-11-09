using System;
using System.Collections.Generic;
using System.Text;

namespace OficinaMVVM.Models
{
    public class Servico
    {
        public long? ServicoID { get; set; }
        public string Nome { get; set; }
        public double Valor { get; set; }
        public string ValorFormatado
        {
            get
            {
                return string.Format("R$ {0:N2}", this.Valor);
            }
        }
    }
}
