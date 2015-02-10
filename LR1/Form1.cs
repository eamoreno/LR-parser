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
        public List<string[]> setC;
        public List<State> Estados;
        string[] array;

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
               // array = this.rtbGramaticaA.Text.Split('\n');
                array = LR1Parser.Tools.GetProductions(this.rtbGramaticaA.Text);
                setC = Parser.Items(array, ref Estados);
                ActionButtons();                
            }
        }

        public static void LRTable(List<string[]> setC, string[] gramarGp)
        {
            var terminals = LR1Parser.Tools.GetTerminals(gramarGp);
            var noTerminals = LR1Parser.Tools.GetNoTerminals(gramarGp);
            var tokens = terminals.Union(noTerminals).ToArray();
            var action = new string[setC.Count(), tokens.Count()];

            for (int i = 0; i < setC.Count(); i++)
            {
                for (int j = 0; j < tokens.Count(); j++)
                {
                    var isTerminal =LR1Parser.Tools.IsTerminal(tokens[j]);
                    var itemSet = Parser.GoTo(setC.ElementAt(i), tokens[j], gramarGp);
                    var index = LR1Parser.Tools.IndexOfItemsSet(setC, itemSet);

                    if (index != -1)
                    {
                        action[i, j] = isTerminal ? string.Format("s{0}", index) : index.ToString();
                    }
                    if (isTerminal)
                    {
                        //var production = setC[i].FirstOrDefault();
                        //if (Tools.IsPointOfEnd (production)) {
                        //Verificar que la gramatica este en el formato adecuado
                        //index = IndexOfGramar(gramarGp, production);
                        //action [i, j] = string.Format ("r{0}", index);
                        //}
                    }
                }
            }
        }
        
        private void btnObtenTabla_Click(object sender, EventArgs e)
        {
            LRTable(setC, array);
            ActiveVerString();
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
