using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_P2_PROG_ESTRUT
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            string usuario = textBox1.Text.Trim();
            string senha = textBox2.Text.Trim();

            if (usuario == "ADMIN" && senha == "123")
            {
                frmPrinc frmPrinc = new frmPrinc();
                frmPrinc.ShowDialog();
                return;
            }
            string caminhoCSV = "usuario.csv";

            if (File.Exists(caminhoCSV))
            {
                bool credencialValida = false;

                using (StreamReader sr = new StreamReader(caminhoCSV))
                {
                    while (sr.EndOfStream)
                    {
                        string linha = sr.ReadLine();
                        string[] dados = linha.Split(',');

                        if (dados.Length == 2)
                        {
                            if (dados[0] == usuario && dados[1] == senha)
                            {
                                credencialValida = true;
                                break;
                            }
                        }
                    }
                }
                if (credencialValida)
                {
                    frmPrinc frmPrinc = new frmPrinc();
                    frmPrinc.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Usuario ou senha inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Arquivo de usuarios não encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmLogin_load(object sender, EventArgs e)
        {

        }
    }
}
