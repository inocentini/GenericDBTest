using GenericDB.DAO;
using GenericDB.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GenericDB
{
    public partial class Form1 : Form
    {
        PessoaDAO pDAO = new PessoaDAO();
        public Form1()
        {
            InitializeComponent();
            fillTable();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Pessoa p = new Pessoa();
            p.Nome = txtNome.Text;
            p.Cpf = txtCPF.Text;
            pDAO.Insert(p);
        }

        private void fillTable()
        {
            dgvPessoas.Rows.Clear();
            dgvPessoas.DataSource = pDAO.ListAll();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
