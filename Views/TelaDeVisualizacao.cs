using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LojaDeBrinquedos.Models;

namespace LojaDeBrinquedos.Views
{
    public partial class TelaDeVisualizacao : Form
    {
        public TelaDeVisualizacao()
        {
            InitializeComponent();
        }
        public TelaDeVisualizacao(Brinquedo brinquedoParaExibir)
        {
            InitializeComponent();

            txtDetalhesCodigoBarras.Text = brinquedoParaExibir.CodigoDeBarras;
            txtDetalhesDescricao.Text = brinquedoParaExibir.Descricao;
            txtDetalhesPreco.Text = brinquedoParaExibir.Preco.ToString("C");
            txtDetalhesCategoria.Text = brinquedoParaExibir.Categoria;
            txtDetalhesIdadeMinima.Text = brinquedoParaExibir.IdadeMinima.ToString();
            txtDetalhesFabricante.Text = brinquedoParaExibir.MeuFabricante.CNPJNome;
        }
    }
}
