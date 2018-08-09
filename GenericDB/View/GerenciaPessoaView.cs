using GenericDB.DAO;
using GenericDB.Model;
using GenericDB.View;
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
            fillTable();
        }

        private void fillTable()
        {
            List<Pessoa> lista = pDAO.ListAll();
            dgvPessoas.Rows.Clear();
            foreach (Pessoa p in lista)
            {
                dgvPessoas.Rows.Add(p.Id, p.Cpf, p.Nome);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Pessoa p = new Pessoa();
            p = pDAO.Read(int.Parse(txtId.Text));
            p.Nome = txtNome.Text;
            pDAO.Update(p);
            fillTable();
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            Pessoa p = new Pessoa();

            p = pDAO.Read(int.Parse(txtId.Text));
            pDAO.Remove(p);
            fillTable();
        }

        private void dgvPessoas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = dgvPessoas.SelectedRows[0].Cells[0].Value.ToString();
            txtCPF.Text = dgvPessoas.SelectedRows[0].Cells[1].Value.ToString();
            txtNome.Text = dgvPessoas.SelectedRows[0].Cells[2].Value.ToString();
        }

        private void forragemDeVeraoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GerenciaForragemVeraoView gfvv = new GerenciaForragemVeraoView();
            gfvv.Show();
            //this.Dispose();
        }
    }
}
