using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDeBrinquedos.Models
{
    public class Fabricante
    {
        public string CNPJ { get; set; }
        public string Nome { get; set; }
        public string CNPJNome
        {
            get
            {
                return $"{CNPJ} - {Nome}";
            }
        }
        public Fabricante()
        {
            this.CNPJ = string.Empty;
            this.Nome = string.Empty;
        }
    }
}
