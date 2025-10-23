using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LojaDeBrinquedos.Views;

namespace LojaDeBrinquedos
{
    public partial class TelaPrincipal : Form
    {
        public TelaPrincipal()
        {
            InitializeComponent();
        }

        private void btnAcessarCadastro_Click(object sender, EventArgs e)
        {
            TelaDeBrinquedos telaDeBrinquedos = new TelaDeBrinquedos();
            telaDeBrinquedos.Show();
            this.Hide();
        }
    }
}
