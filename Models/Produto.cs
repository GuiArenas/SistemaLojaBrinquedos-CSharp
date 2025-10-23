using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDeBrinquedos.Models
{
    public abstract class Produto
    {
        public string CodigoDeBarras { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public Produto()
        {
            this.CodigoDeBarras = string.Empty;
            this.Preco = 0.0m;
            this.Descricao = string.Empty;
        }

        public string CodigoDescricao
        {
            get
            {
                return $"{CodigoDeBarras} - {Descricao}";
            }
        }
    }
}
