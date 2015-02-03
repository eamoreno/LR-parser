using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;


namespace LR1
{
    public partial class Form1 : Form
    {
        //public List<string[]> Estados;
        public List<Nodo> Estados;

        public Form1()
        {
            InitializeComponent();           
        }

        private void btnCarga_Click(object sender, EventArgs e)
        {
            OpenFileDialog o = new OpenFileDialog();
            o.Filter = "Archivos gramatica (*.txt)|*.txt";
            string linea;

            if (o.ShowDialog() == DialogResult.OK)
            {
                rtbGramatica.Text = "";                
                rtbGramaticaA.Text = "";
                NotActionButtons();                
                ActiveNotVerString();
                StreamReader r = new StreamReader(o.FileName);
                while ((linea = r.ReadLine()) != null)
                {
                    this.rtbGramatica.Text += linea + "\n";
                }
            }
        }

        private void btnGenera_Click(object sender, EventArgs e)
        {            
            bool band =MakeAumentada();
           /* var gramarG = new[] {
				"S' -> S", 
				"S -> C C",
				"C -> c C | d"
			};

            gramarG = new[]{ 
				"S' -> S",
				"S -> id | V igual E",
				"V -> id",
				"E -> V | num"
			};*/
            if (band)
            {
                var array = this.rtbGramaticaA.Text.Split('\n');
                Estados = Parser.Items(array);
                ActionButtons();
            }
        }

        private void ActionButtons()
        {           
            btnDibuja.Enabled = true;
            btnObtenTabla.Enabled = true;
        }

        private void NotActionButtons()
        {
            btnDibuja.Enabled = false; ;
            btnObtenTabla.Enabled = false; ;
        }

        private bool MakeAumentada()
        {
            bool band = false;
            if (this.rtbGramatica.Text != "")
            {
                String dato = rtbGramatica.Text.Substring(0, 1);
                this.rtbGramaticaA.Text = dato + "' -> " + dato + "\n" + this.rtbGramatica.Text;
                band = true;

            }
            else
                MessageBox.Show("Introduce Alguna Produccion");
            return band;
        }

        private void btnAnaliza_Click(object sender, EventArgs e)
        {

        }

        private void btnDibuja_Click(object sender, EventArgs e)
        {
            FrmDibuja frmdib = new FrmDibuja();
            frmdib.AfdNodos = Estados;
            frmdib.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btnObtenTabla_Click(object sender, EventArgs e)
        {
            ActiveVerString();           
        }

        private void ActiveVerString()
        {
            btnAnaliza.Enabled = true;
            txtbAnaliza.Enabled = true;
        }

        private void ActiveNotVerString()
        {
            btnAnaliza.Enabled = false;
            txtbAnaliza.Enabled = false;
        }
	}   
}
