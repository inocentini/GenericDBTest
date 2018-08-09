namespace GenericDB.View
{
    partial class GerenciaForragemVeraoView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.txtQnt = new System.Windows.Forms.TextBox();
            this.txtPreco = new System.Windows.Forms.TextBox();
            this.lbDesc = new System.Windows.Forms.Label();
            this.lbQnt = new System.Windows.Forms.Label();
            this.lbPreco = new System.Windows.Forms.Label();
            this.dgvForragemVerao = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qnt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.preco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnRemover = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.txtId = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvForragemVerao)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(91, 24);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(274, 20);
            this.txtDesc.TabIndex = 0;
            // 
            // txtQnt
            // 
            this.txtQnt.Location = new System.Drawing.Point(91, 50);
            this.txtQnt.Name = "txtQnt";
            this.txtQnt.Size = new System.Drawing.Size(61, 20);
            this.txtQnt.TabIndex = 1;
            // 
            // txtPreco
            // 
            this.txtPreco.Location = new System.Drawing.Point(91, 76);
            this.txtPreco.Name = "txtPreco";
            this.txtPreco.Size = new System.Drawing.Size(99, 20);
            this.txtPreco.TabIndex = 2;
            // 
            // lbDesc
            // 
            this.lbDesc.AutoSize = true;
            this.lbDesc.Location = new System.Drawing.Point(27, 27);
            this.lbDesc.Name = "lbDesc";
            this.lbDesc.Size = new System.Drawing.Size(58, 13);
            this.lbDesc.TabIndex = 4;
            this.lbDesc.Text = "Descrição:";
            // 
            // lbQnt
            // 
            this.lbQnt.AutoSize = true;
            this.lbQnt.Location = new System.Drawing.Point(20, 53);
            this.lbQnt.Name = "lbQnt";
            this.lbQnt.Size = new System.Drawing.Size(65, 13);
            this.lbQnt.TabIndex = 5;
            this.lbQnt.Text = "Quantidade:";
            // 
            // lbPreco
            // 
            this.lbPreco.AutoSize = true;
            this.lbPreco.Location = new System.Drawing.Point(47, 79);
            this.lbPreco.Name = "lbPreco";
            this.lbPreco.Size = new System.Drawing.Size(38, 13);
            this.lbPreco.TabIndex = 6;
            this.lbPreco.Text = "Preço:";
            // 
            // dgvForragemVerao
            // 
            this.dgvForragemVerao.AllowUserToAddRows = false;
            this.dgvForragemVerao.AllowUserToDeleteRows = false;
            this.dgvForragemVerao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvForragemVerao.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.desc,
            this.qnt,
            this.preco});
            this.dgvForragemVerao.Location = new System.Drawing.Point(12, 142);
            this.dgvForragemVerao.Name = "dgvForragemVerao";
            this.dgvForragemVerao.ReadOnly = true;
            this.dgvForragemVerao.Size = new System.Drawing.Size(624, 176);
            this.dgvForragemVerao.TabIndex = 7;
            this.dgvForragemVerao.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvForragemVerao_CellClick);
            // 
            // id
            // 
            this.id.DataPropertyName = "dgvId";
            this.id.HeaderText = "Id:";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Width = 30;
            // 
            // desc
            // 
            this.desc.DataPropertyName = "dgvDesc";
            this.desc.HeaderText = "Descrição:";
            this.desc.Name = "desc";
            this.desc.ReadOnly = true;
            this.desc.Width = 350;
            // 
            // qnt
            // 
            this.qnt.DataPropertyName = "dgvQnt";
            this.qnt.HeaderText = "Quantidade:";
            this.qnt.Name = "qnt";
            this.qnt.ReadOnly = true;
            this.qnt.Width = 75;
            // 
            // preco
            // 
            this.preco.DataPropertyName = "dgvPreco";
            this.preco.HeaderText = "Preço:";
            this.preco.Name = "preco";
            this.preco.ReadOnly = true;
            this.preco.Width = 75;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(50, 111);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "Adicionar";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(145, 111);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(75, 23);
            this.btnEditar.TabIndex = 9;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnRemover
            // 
            this.btnRemover.Location = new System.Drawing.Point(236, 111);
            this.btnRemover.Name = "btnRemover";
            this.btnRemover.Size = new System.Drawing.Size(75, 23);
            this.btnRemover.TabIndex = 10;
            this.btnRemover.Text = "Remover";
            this.btnRemover.UseVisualStyleBackColor = true;
            this.btnRemover.Click += new System.EventHandler(this.btnRemover_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(328, 111);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 11;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(579, 12);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(57, 20);
            this.txtId.TabIndex = 12;
            // 
            // GerenciaForragemVeraoView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 320);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnRemover);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dgvForragemVerao);
            this.Controls.Add(this.lbPreco);
            this.Controls.Add(this.lbQnt);
            this.Controls.Add(this.lbDesc);
            this.Controls.Add(this.txtPreco);
            this.Controls.Add(this.txtQnt);
            this.Controls.Add(this.txtDesc);
            this.Name = "GerenciaForragemVeraoView";
            this.Text = "GerenciaForragemVeraoView";
            ((System.ComponentModel.ISupportInitialize)(this.dgvForragemVerao)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.TextBox txtQnt;
        private System.Windows.Forms.TextBox txtPreco;
        private System.Windows.Forms.Label lbDesc;
        private System.Windows.Forms.Label lbQnt;
        private System.Windows.Forms.Label lbPreco;
        private System.Windows.Forms.DataGridView dgvForragemVerao;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn desc;
        private System.Windows.Forms.DataGridViewTextBoxColumn qnt;
        private System.Windows.Forms.DataGridViewTextBoxColumn preco;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnRemover;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox txtId;
    }
}