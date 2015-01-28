using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LR1
{
    public partial class FrmDibuja : Form
    {
        public List<string[]> edos;

        private int xcen = 400;
        private int ycen = 300;
        private int longi = 200;
        private Bitmap dibujo;
        private int curva = 20;
        private int dista = 10;

        private Font fuente = new Font("Arial", 18);
        private Font fuente2 = new Font("Arial", 11);
        private Font fuente3 = new Font("Arial", 25);
        private Brush coloranul = new SolidBrush(Color.Black);
        private Brush colorprimpos = new SolidBrush(Color.Black);
        private Brush colorultipos = new SolidBrush(Color.Yellow);
        private Brush colorbl = new SolidBrush(Color.White);
        private Brush relleno = new SolidBrush(Color.Chartreuse);
        private readonly Pen pincel = new Pen(Color.Blue, 2);
        private readonly Pen pincelbl = new Pen(Color.White, 2);
        private readonly Pen _plumaFlecha = new Pen(Color.Black, 3);
        private readonly Pen _plumaFlechaR = new Pen(Color.DarkRed, 3);
        private Graphics _graphics;

        public FrmDibuja()
        {
            InitializeComponent();
        }

        private void FrmDibuja_Load(object sender, EventArgs e)
        {
            ArbolEstados();
            DibujaEstados();
        }

        private void ArbolEstados()
        {
            tvEstados.Nodes.Clear();
            for (int i=0; i <= edos.LongCount()-1; i++)
            {
                tvEstados.Nodes.Add("Estado " + i );
                foreach (var dato in edos[i])                                    
                    tvEstados.Nodes[i].Nodes.Add(dato.ToString());                
            }
        }

        private void DibujaEstados()
        {

        }

       
    }
}
