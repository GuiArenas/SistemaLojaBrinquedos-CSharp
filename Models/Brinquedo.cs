using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDeBrinquedos.Models
{
    public class Brinquedo : Produto
    {
        public string Categoria { get; set; }
        public int IdadeMinima { get; set; }
        public Fabricante MeuFabricante { get; set; }
        public Brinquedo()
        {
            this.Categoria = string.Empty;
            this.IdadeMinima = 0;
            this.MeuFabricante = new Fabricante();
        }

        public override string ToString()
        {
            return DadosParaListBox;
        }

        public string CodigoDescricaoCategoria
        {
            get
            {
                return $"{CodigoDeBarras} - {Descricao} - {Categoria}";
            }
        }

        public string DadosParaListBox
        {
            get
            {
                return $"{CodigoDeBarras} - {Descricao} - {Categoria} - {MeuFabricante.Nome}";
            }
        }

        public string DadosCompletos
        {
            get
            {
                return $"{CodigoDeBarras} - {Descricao} - {Categoria} - {IdadeMinima} anos - {Preco:C} - Fabricante: {MeuFabricante.CNPJNome}";
            }
        }
    }
}
