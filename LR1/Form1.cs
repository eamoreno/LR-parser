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
        public List<string[]> Estados;

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
                StreamReader r = new StreamReader(o.FileName);
                while ((linea = r.ReadLine()) != null)
                {
                    this.rtbGramatica.Text += linea + "\n";
                }
            }
        }

        private void btnGenera_Click(object sender, EventArgs e)
        {            
            MakeAumentada();
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

            var array = this.rtbGramaticaA.Text.Split('\n');
            Estados = Parser.Items(array);
        }

        private void MakeAumentada()
        {
            if (this.rtbGramatica.Text != "")
            {
                String dato = rtbGramatica.Text.Substring(0, 1);
                this.rtbGramaticaA.Text = dato + "' -> " + dato + "\n" + this.rtbGramatica.Text;

            }
            else
                MessageBox.Show("Introduce Alguna Produccion");
        }

        private void btnAnaliza_Click(object sender, EventArgs e)
        {

        }

        private void btnDibuja_Click(object sender, EventArgs e)
        {
            FrmDibuja frmdib = new FrmDibuja();
            frmdib.edos = Estados;
            frmdib.ShowDialog();
        }
      
	}   
}
