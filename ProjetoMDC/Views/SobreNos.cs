﻿using ProjetoMDC.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoMDC
{
    public partial class SobreNos : Form
    {
        public SobreNos()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void SobreNos_Load(object sender, EventArgs e)
        {

        }

        private void txtHome_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }

        private void txtFechar_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtSobreNos_Click(object sender, EventArgs e)
        {
            SobreNos sobreNos = new SobreNos();
            sobreNos.Show();
            this.Hide();
        }

        private void txtContato_Click(object sender, EventArgs e)
        {
            Contato contato = new Contato();
            contato.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void txtLogin_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
