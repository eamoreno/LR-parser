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
using System.Collections;

namespace LR1
{
    public partial class Form1 : Form
    {
        public List<string[]> setC;
        public List<State> Estados;
        public string[] array;
        public string[,] action;
        public string[] tokens;
        public string[] terminals;

        public Form1()
        {
            InitializeComponent();           
        }

        private void btnCarga_Click(object sender, EventArgs e)
        {
            OpenFileDialog o = new OpenFileDialog();
            o.Filter = "Archivos gramatica (*.txt)|*.txt";
            string linea;
            Inicia();
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
            Inicia();
            string aum = "";
            bool band =MakeAumentada(ref aum);
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
                array = LR1Parser.Tools.GetProductions(aum +  "\n" +this.rtbGramatica.Text);                
                string cad = LR1Parser.Tools.Normalization(array);
                this.rtbGramaticaA.Text = cad;
                setC = Parser.Items(array, ref Estados);
                ActionButtons();                
            }
        }

        public void Inicia()
        {           
            dGVAccion.Rows.Clear();
            dGVAccion.Visible = false;
            dGVAnalisis.Visible = false;
            txtbAnaliza.Enabled = false;
            txtbAnaliza.Text = "";
            btnAnaliza.Enabled = false;
            btnDibuja.Enabled = false;
            rtbGramaticaA.Text = "";
        }

        public void LRTable(List<string[]> setC, string[] gramarGp)
        {
            terminals = LR1Parser.Tools.GetTerminals(gramarGp);
            var noTerminals = LR1Parser.Tools.GetNoTerminals(gramarGp);
            tokens = terminals.Union(noTerminals).ToArray();            
            action = new string[setC.Count(), tokens.Count()];

            for (int i = 0; i < setC.Count(); i++)
            {
                for (int j = 0; j < tokens.Count(); j++)
                {
                    var isTerminal =LR1Parser.Tools.IsTerminal(tokens[j]);
                    var itemSet = Parser.GoTo(setC.ElementAt(i), tokens[j], gramarGp);
                    var index = LR1Parser.Tools.IndexOfItemsSet(setC, itemSet);

                    if (index != -1)                    
                        action[i, j] = isTerminal ? string.Format("s{0}", index) : index.ToString();

                    if (isTerminal)
                    {
                        for (int prod = 0; prod < setC[i].Count(); prod++)
                        {
                            var production = setC[i][prod].ToString();
                            var e1 = tokens[j].ToString();
                            var e2 = LR1Parser.Tools.RetLastElement(production);
                            if (LR1Parser.Tools.IsPointAtEnd(production) && e1 == e2)
                            {                                
                                index = LR1Parser.Tools.IndexOfGramar(gramarGp, production);
                                if (index != -1)                                    
                                    action[i, j] = string.Format("r{0}", index);
                                if (index == 0)
                                    action[i, j] = string.Format("Aceptar", index);
                            }
                        }
                    }
                }
            }
            PaintingTable(action, tokens, setC.Count());         
        }

        private void PaintingTable(string[,] table, string[] token, int tam)
        {
                   
            dGVAnalisis.ColumnCount = token.Count();            
            dGVAnalisis.ColumnHeadersVisible = true;

            DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();

            columnHeaderStyle.BackColor = Color.Aqua;
            columnHeaderStyle.Font = new Font("Verdana", 10, FontStyle.Bold);
            dGVAnalisis.ColumnHeadersDefaultCellStyle = columnHeaderStyle;
            
            for (int i = 0; i < token.Count(); i++)
                dGVAnalisis.Columns[i].Name = token[i].ToString();                
           
            for (int i = 0; i < tam; i++)
            {
                dGVAnalisis.Rows.Add(1);
                for (int j = 0; j < token.Count(); j++)
                {                    
                    if (table[i, j] != null)
                        dGVAnalisis.Rows[i].Cells[j].Value = table[i, j].ToString();                                             
                }                
            }                      
        }

        private void btnObtenTabla_Click(object sender, EventArgs e)
        {
            dGVAnalisis.Visible = true;
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

        private bool MakeAumentada(ref string dato)
        {
            bool band = false;
            if (this.rtbGramatica.Text != "")
            {
                dato = LR1Parser.Tools.Increases(rtbGramatica.Text);
                /*string finishA = Aumentada(dato);
                String dato = rtbGramatica.Text.Substring(0, 1);
                this.rtbGramaticaA.Text = dato + "' -> " + dato + "\n" + this.rtbGramatica.Text;
                this.rtbGramaticaA.Text = finishA + "\n" + rtbGramatica.Text;*/
                band = true;

            }
            else
                MessageBox.Show("Introduce Alguna Produccion");
            return band;
        }

        private string Aumentada(string dato)
        {
            var retaum = "";

            for (int i = 0; i < dato.Length; i++)
            {
                if (i == (dato.Length)- 1 && dato[i] == '>')                
                    retaum = retaum + "'>";                
                else
                    retaum = retaum + dato[i];                  
            }

            return retaum;
        }

        private void btnAnaliza_Click(object sender, EventArgs e)
        {
            if (LR1Parser.Tools.VerificateTokens(terminals, txtbAnaliza.Text))
            {
                ScreenView();
                var arrayInput = LR1Parser.Tools.GetTokens(txtbAnaliza.Text);
                Stack<string> stackAS = new Stack<string>();
                Stack<string> StackInput = new Stack<string>();

                StackInput.Push("$");
                string accion = "inicio";
                string production = "";

                for (int i = arrayInput.Count(); i > 0; i--)
                    StackInput.Push(arrayInput[i - 1]);

                stackAS.Push("$0");
                int inc = 0;
                while (accion != "Aceptar" || accion != "Fallo")
                {
                    dGVAccion.Rows.Add(1);
                    for (int i = 0; i < 3; i++)
                    {
                        if (i == 0)
                            //dGVAccion.Rows[inc].Cells[i].Value = stackAS.Peek(); 
                            dGVAccion.Rows[inc].Cells[i].Value = returnStringStack(stackAS);
                        if (i == 1)
                            //dGVAccion.Rows[inc].Cells[i].Value = StackInput.Peek();
                            dGVAccion.Rows[inc].Cells[i].Value = returnStringStack(StackInput);
                        if (i == 2)
                        {
                            int indexX = LR1Parser.Tools.GetIndexX(StackInput.Peek(), tokens);
                            int indexY = LR1Parser.Tools.GetIndexY(stackAS.Peek().ToString());
                            if (action[indexY, indexX] != null)
                                accion = action[indexY, indexX].ToString();
                            else
                            {
                                accion = "Fallo";
                                dGVAccion.Rows[inc].Cells[i].Value = "Fallo";
                                break;
                            }
                            if (accion == "Aceptar")
                            {
                                dGVAccion.Rows[inc].Cells[i].Value = accion;
                                break;
                            }

                            int nproduction = LR1Parser.Tools.GetIndexY(accion);
                            production = LR1Parser.Tools.GetProduction(array, nproduction);
                            if (accion.Contains('r'))
                                dGVAccion.Rows[inc].Cells[i].Value = action[indexY, indexX].ToString() + " (" + production + ")";
                            else
                                dGVAccion.Rows[inc].Cells[i].Value = action[indexY, indexX].ToString();
                        }
                    }
                    if (accion == "Aceptar" | accion == "Fallo")
                        break;
                    inc++;
                    int num = LR1Parser.Tools.GetIndexY(accion);
                    if (accion.Contains('s'))
                        stackAS.Push(StackInput.Pop() + num);
                    if (accion.Contains('r'))
                    {
                        string producepater = "";
                        int ndelete = LR1Parser.Tools.GetElementosDelete(production, ref producepater);
                        while (ndelete != 0)
                        {
                            stackAS.Pop();
                            ndelete--;
                        }
                        stackAS.Push(producepater + LR1Parser.Tools.GetIndexY(accion).ToString());
                    }
                }
            }
            else
            {
                MessageBox.Show("Debes Introducir Solamente Datos Terminales de La Gramatica en Prueba");
                txtbAnaliza.Text = "";
            }

        }

        private void ScreenView()
        {
            dGVAccion.Rows.Clear();
            dGVAccion.Visible = true;
            dGVAccion.Columns["Column1"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dGVAccion.Columns["Column2"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dGVAccion.Columns["Column3"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;    
        }

        public static string returnStringStack(IEnumerable myCollection)
        {
            string retcad = "";

            foreach (Object obj in myCollection)
                retcad = retcad + obj + " ";
               
            return retcad;
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

        private void button1_Click(object sender, EventArgs e)
        {
            Inicia();
            dGVAccion.Dispose();
            dGVAnalisis.Dispose();
            this.Close();
        }
	}   
}
