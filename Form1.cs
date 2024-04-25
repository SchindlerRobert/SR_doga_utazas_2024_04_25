using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SR_doga_utazas_2024_04_25
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBoxEllatas.Text = "reggeli";
        }

        private void dataGridViewUtazas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialogUtazas.ShowDialog() == DialogResult.OK)
            {
                UtazasRepository.Path = openFileDialogUtazas.FileName;
                dataGridViewUtazas.DataSource = UtazasRepository.FindAll();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Schindler R _ Doga _ 2024.04.25");
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Utazas NewUtazas = new Utazas()
            {
                Id = int.Parse(textBoxId.Text),
                Orszag = textBoxOrszag.Text,
                Honap = int.Parse(textBoxHonap.Text),
                Nap = int.Parse(textBoxNap.Text),
                Hossz = int.Parse(textBoxHossz.Text),
                Ar = int.Parse(textBoxAr.Text),
                Ellatas = comboBoxEllatas.Text
            };

            UtazasRepository.Save(NewUtazas);
            MessageBox.Show("Új elem hozzáadva!");
            dataGridViewUtazas.DataSource = UtazasRepository.FindAll();
        }
    }
}
