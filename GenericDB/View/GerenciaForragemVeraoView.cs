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

namespace GenericDB.View
{
    public partial class GerenciaForragemVeraoView : Form
    {
        ForragemVeraoDAO fvDAO = new ForragemVeraoDAO();
        GenericDBDAO gdb = new GenericDBDAO();
        public GerenciaForragemVeraoView()
        {
            InitializeComponent();
            fillTable();
        }

        public void fillTable()
        {
            /*List<ForragemDeVerao> forragens = fvDAO.ListAll();
            dgvForragemVerao.Rows.Clear();
            foreach(ForragemDeVerao fv in forragens)
                dgvForragemVerao.Rows.Add(fv.Id, fv.Desc, fv.Qnt, fv.Preco);*/
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            /*ForragemDeVerao fv = new ForragemDeVerao();
            fv.Desc = txtDesc.Text;
            fv.Qnt = int.Parse(txtQnt.Text);
            fv.Preco = double.Parse(txtPreco.Text);
            fvDAO.Insert(fv);
            fillTable();*/

            ForragemDeInverno fv = new ForragemDeInverno();
            fv.Desc = txtDesc.Text;
            fv.Qnt = int.Parse(txtQnt.Text);
            fv.Preco = double.Parse(txtPreco.Text);
            gdb.Insert(fv);
            fillTable();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            ForragemDeVerao fv = new ForragemDeVerao();
            fv = fvDAO.Read(int.Parse(txtId.Text));
            fv.Desc = txtDesc.Text;
            fv.Qnt = int.Parse(txtQnt.Text);
            fv.Preco = double.Parse(txtPreco.Text);
            fvDAO.Update(fv);
            fillTable();
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            ForragemDeVerao fv = new ForragemDeVerao();
            fv = fvDAO.Read(int.Parse(txtId.Text));
            fvDAO.Remove(fv);
            fillTable();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void dgvForragemVerao_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = dgvForragemVerao.SelectedRows[0].Cells[0].Value.ToString();
            txtDesc.Text = dgvForragemVerao.SelectedRows[0].Cells[1].Value.ToString();
            txtQnt.Text = dgvForragemVerao.SelectedRows[0].Cells[2].Value.ToString();
            txtPreco.Text = dgvForragemVerao.SelectedRows[0].Cells[3].Value.ToString();
        }
    }
}
