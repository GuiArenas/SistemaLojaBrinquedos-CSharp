using System;
using System.Collections.Generic;
using System.Windows.Forms;
using LojaDeBrinquedos.Models;
using LojaDeBrinquedos.Controllers;

namespace LojaDeBrinquedos.Views
{
    public partial class TelaDeBrinquedos : Form
    {
        public TelaDeBrinquedos()
        {
            InitializeComponent();
            AtualizarListBox();
        }

        private void AtualizarListBox()
        {
            lstBrinquedos.Items.Clear();
            List<Brinquedo> brinquedos = BrinquedoExecucao.ObterBrinquedos();
            foreach (Brinquedo b in brinquedos)
            {
                lstBrinquedos.Items.Add(b);
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCnpj.Text) ||
                string.IsNullOrWhiteSpace(txtNomeFabricante.Text) ||
                string.IsNullOrWhiteSpace(txtCodigoBarras.Text) ||
                string.IsNullOrWhiteSpace(txtDescricao.Text) ||
                string.IsNullOrWhiteSpace(txtPreco.Text) ||
                string.IsNullOrWhiteSpace(txtCategoria.Text) ||
                string.IsNullOrWhiteSpace(txtIdadeMinima.Text))
            {
                MessageBox.Show("Por favor, preencha todos os campos.", "Campos Vazios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string cnpj = txtCnpj.Text.Replace(".", "").Replace("/", "").Replace("-", "");
            if (cnpj.Length != 14 || !long.TryParse(cnpj, out _))
            {
                MessageBox.Show("CNPJ inválido. Deve conter 14 dígitos numéricos.", "Erro de Validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string codigoBarras = txtCodigoBarras.Text;
            if (codigoBarras.Length != 13 || !long.TryParse(codigoBarras, out _))
            {
                MessageBox.Show("Código de Barras inválido. Deve conter 13 dígitos numéricos.", "Erro de Validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            decimal preco;
            if (!decimal.TryParse(txtPreco.Text, out preco))
            {
                MessageBox.Show("Preço inválido. Use apenas números e vírgula/ponto para decimais.", "Erro de Validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (preco <= 0)
            {
                MessageBox.Show("O preço deve ser maior que zero.", "Erro de Validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int idadeMinima;
            if (!int.TryParse(txtIdadeMinima.Text, out idadeMinima))
            {
                MessageBox.Show("Idade Mínima inválida. Use apenas números inteiros.", "Erro de Validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (idadeMinima < 0)
            {
                MessageBox.Show("A idade mínima não pode ser negativa.", "Erro de Validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Fabricante novoFabricante = new Fabricante
            {
                CNPJ = cnpj,
                Nome = txtNomeFabricante.Text
            };

            Brinquedo novoBrinquedo = new Brinquedo
            {
                CodigoDeBarras = codigoBarras,
                Descricao = txtDescricao.Text,
                Preco = preco,
                Categoria = txtCategoria.Text,
                IdadeMinima = idadeMinima,
                MeuFabricante = novoFabricante
            };

            BrinquedoExecucao.AdicionarBrinquedo(novoBrinquedo);
            AtualizarListBox();
            MessageBox.Show("Brinquedo adicionado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LimparCampos();
        }

        private void LimparCampos()
        {
            txtCnpj.Clear();
            txtNomeFabricante.Clear();
            txtCodigoBarras.Clear();
            txtDescricao.Clear();
            txtPreco.Clear();
            txtCategoria.Clear();
            txtIdadeMinima.Clear();
            txtCnpj.Focus();
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            if (lstBrinquedos.SelectedItem == null)
            {
                MessageBox.Show("Selecione um brinquedo na lista para remover.", "Nenhum Item Selecionado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirmacao = MessageBox.Show(
                "Tem certeza que deseja remover o brinquedo selecionado?",
                "Confirmar Remoção",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmacao == DialogResult.Yes)
            {
                Brinquedo brinquedoSelecionado = (Brinquedo)lstBrinquedos.SelectedItem;
                BrinquedoExecucao.RemoverBrinquedo(brinquedoSelecionado);
                AtualizarListBox();
                MessageBox.Show("Brinquedo removido com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            if (lstBrinquedos.SelectedItem == null)
            {
                MessageBox.Show("Selecione um brinquedo na lista para visualizar os detalhes.", "Nenhum Item Selecionado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Brinquedo brinquedoSelecionado = (Brinquedo)lstBrinquedos.SelectedItem;
            TelaDeVisualizacao telaVisualizacao = new TelaDeVisualizacao(brinquedoSelecionado);
            telaVisualizacao.ShowDialog();
        }
    }
}