using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LR1
{
    public partial class FrmDibuja : Form
    {
        public List<string[]> edos;
        public List<Nodo> AfdNodos { get; set; }

        private int xcen = 400;
        private int ycen = 300;
        private int longi = 250;
        private Bitmap dibujo;
        private int curva = 20;
        //private int dista = 10;

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

        public void FrmDibuja_Load(object sender, EventArgs e)
        {
            ArbolEstados();           
            DibujaEstados();
        }

        public void ArbolEstados()
        {
            //var lista = new List<Nodo>();
            //List<Nodo> lista = new List<Nodo>();
            //tvEstados.Nodes.Clear();
            //for (int i=0; i <= edos.LongCount()-1; i++)
            //{
                //var nuevosEstados = new Nodo { Id = i} ;           
                //tvEstados.Nodes.Add("Estado " + i );

               // foreach (var dato in edos[i])                                    
                 //   tvEstados.Nodes[i].Nodes.Add(dato.ToString());
               // lista.Add(nuevosEstados);
            //}
            //return lista;    
            tvEstados.Nodes.Clear();
            for (int i = 0; i < AfdNodos.Count; i++)
            {
                tvEstados.Nodes.Add("Estado " + AfdNodos[i].Id.ToString());
                foreach (var dato in AfdNodos[i].Produc)
                {
                    tvEstados.Nodes[i].Nodes.Add(dato.ToString());
                }
            }
        }
        
        private void DibujaEstados()
        {
            if (ClientSize.Width > pbDibujo.Width && ClientSize.Height > pbDibujo.Height)
                dibujo = new Bitmap(ClientSize.Width, pbDibujo.Height);
            else
                dibujo = new Bitmap(pbDibujo.Width, pbDibujo.Height);

            _graphics = Graphics.FromImage(dibujo);
            PintaNodosAfd(_graphics);
            PintaAristasAfd(_graphics);
            _graphics.DrawImage(dibujo, 0, 0);
            pbDibujo.Image = dibujo;
        }

        private void PintaNodosAfd(Graphics g)
        {
            if (AfdNodos == null)
                return;
            int teta = 360 / AfdNodos.Count;
            double opex = 0, opey = 0;
            double ope = 0;
            int xteta = 0, yteta = 0;

            for (int i = 0; i < AfdNodos.Count; i++)
            {
                ope = (double)((((teta * i) + teta) * (Math.PI)) / 180);
                opex = (Math.Cos(ope));
                opey = (Math.Sin(ope));
                xteta = (int)(xcen + ((longi) * (opex)));
                yteta = (int)(ycen - ((longi) * (opey)));
                AfdNodos[i].X = xteta;
                AfdNodos[i].Y = yteta;
            }
        }

        private void PintaAristasAfd(Graphics g)
        {
            if (AfdNodos == null)
                return;
            AdjustableArrowCap finfle = new AdjustableArrowCap(5, 5);
            _plumaFlecha.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            _plumaFlecha.CustomEndCap = finfle;
            int incurv = 0, inletr1 = 0, inletr2 = 0, inletr3 = 0, inletr4 = 0;
            int inletr1r = 0, inletr2r = 0, inletr3r = 0;
            string letcurv = "", letra1 = "", letra2 = "", letra3 = "", letra4 = "";
            string letra1r = "", letra2r = "", letra3r = "", letra4r = "";
            bool band1 = false, band2 = false, band3 = false, band4 = false;
            int tam = 0, tam2 = 0;
            int tamafue1 = 0, tamafue1a = 0;
            int tamafue2 = 0, tamafue2a = 0;
            int tamafue3 = 0, tamafue3a = 0;
            int tamafue4 = 0, tamafue4a = 0;

            for (int i = 0; i < AfdNodos.Count; i++)
            {
                for (int j = 0; j < AfdNodos[i].Aristas.Count; j++)
                {
                    //HazFlechas(AfdNodos[i], AfdNodos[i].Aristas[j].Nodo);
                    tam = ((AfdNodos[i].X) + (AfdNodos[i].Aristas[j].Nodo.X));
                    tam2 = ((AfdNodos[i].Y) + (AfdNodos[i].Aristas[j].Nodo.Y));

                    //c hacia adelante y hacia arriba 
                    if (AfdNodos[i].X < AfdNodos[i].Aristas[j].Nodo.X && AfdNodos[i].Y > AfdNodos[i].Aristas[j].Nodo.Y)
                    {
                        g.DrawLine(_plumaFlecha, AfdNodos[i].X + 20, AfdNodos[i].Y + 20, AfdNodos[i].Aristas[j].Nodo.X + 5, AfdNodos[i].Aristas[j].Nodo.Y + 30);

                        if (AfdNodos[i].Id > AfdNodos[i].Aristas[j].Nodo.Id)
                        {
                            for (int m = 0; m < AfdNodos[i].Aristas[j].Nodo.Aristas.Count; m++)
                                if (AfdNodos[i].Aristas[j].Nodo.Aristas[m].Nodo.Id == AfdNodos[i].Id)
                                    band1 = true;
                        }                        
                        /*if (band1)
                        {
                            if (letra1r == "")
                                letra1r = AfdNodos[i].Aristas[j].Id.ToString();
                            else
                            {
                                letra1r = letra1r + "," + AfdNodos[i].Aristas[j].Id.ToString();
                                inletr1r++;
                            }
                        }
                        else
                        {
                            if (letra1 == "")
                                letra1 = AfdNodos[i].Aristas[j].Id.ToString();
                            else
                            {
                                letra1 = letra1 + "," + AfdNodos[i].Aristas[j].Id.ToString();
                                inletr1++;
                            }
                        }*/
                        tamafue1 = tam;
                        tamafue1a = tam2;
                        g.DrawString(AfdNodos[i].Aristas[j].Id.ToString(), fuente2, colorprimpos, (int)(tam / 2), (int)(tam2 / 2) + 30);
                    }
                    //c hacia atras y hacia arriba
                    if (AfdNodos[i].X > AfdNodos[i].Aristas[j].Nodo.X && AfdNodos[i].Y > AfdNodos[i].Aristas[j].Nodo.Y)
                    {
                        g.DrawLine(_plumaFlecha, AfdNodos[i].X + 20, AfdNodos[i].Y + 20, AfdNodos[i].Aristas[j].Nodo.X + 30, AfdNodos[i].Aristas[j].Nodo.Y + 30);
                        if (AfdNodos[i].Id > AfdNodos[i].Aristas[j].Nodo.Id)
                        {
                            for (int m = 0; m < AfdNodos[i].Aristas[j].Nodo.Aristas.Count; m++)
                                if (AfdNodos[i].Aristas[j].Nodo.Aristas[m].Nodo.Id == AfdNodos[i].Id)
                                    band2 = true;
                        }
                        /*
                        if (band2)
                        {
                            if (letra2r == "")
                                letra2r = AfdNodos[i].Aristas[j].Id.ToString();
                            else
                            {
                                letra2r = letra2r + "," + AfdNodos[i].Aristas[j].Id.ToString();
                                inletr2r++;
                            }
                        }
                        else
                        {
                            if (letra2 == "")
                                letra2 = AfdNodos[i].Aristas[j].Id.ToString();
                            else
                            {
                                letra2 = letra2 + "," + AfdNodos[i].Aristas[j].Id.ToString();
                                inletr2++;
                            }
                        }*/
                        tamafue2 = tam;
                        tamafue2a = tam2;
                        g.DrawString(AfdNodos[i].Aristas[j].Id.ToString(), fuente2, colorprimpos, (int)(tam / 2), (int)(tam2 / 2) + 30);
                    }
                    // 
                    if (AfdNodos[i].X < AfdNodos[i].Aristas[j].Nodo.X && AfdNodos[i].Y < AfdNodos[i].Aristas[j].Nodo.Y)
                    {
                        g.DrawLine(_plumaFlecha, AfdNodos[i].X + 20, AfdNodos[i].Y + 20, AfdNodos[i].Aristas[j].Nodo.X + 5, AfdNodos[i].Aristas[j].Nodo.Y + 5);
                        if (AfdNodos[i].Id > AfdNodos[i].Aristas[j].Nodo.Id)
                        {
                            for (int m = 0; m < AfdNodos[i].Aristas[j].Nodo.Aristas.Count; m++)
                                if (AfdNodos[i].Aristas[j].Nodo.Aristas[m].Nodo.Id == AfdNodos[i].Id)
                                    band3 = true;
                        }
                        /*
                        if (band3)
                        {
                            if (letra3r == "")
                                letra3r = AfdNodos[i].Aristas[j].Id.ToString();
                            else
                            {
                                letra3r = letra3r + "," + AfdNodos[i].Aristas[j].Id.ToString();
                                inletr3r++;
                            }
                        }
                        else
                        {
                            if (letra3 == "")
                                letra3 = AfdNodos[i].Aristas[j].Id.ToString();
                            else
                            {
                                letra3 = letra3 + "," + AfdNodos[i].Aristas[j].Id.ToString();
                                inletr3++;
                            }
                        }*/
                        tamafue3 = tam;
                        tamafue3a = tam2;

                        g.DrawString(AfdNodos[i].Aristas[j].Id.ToString(), fuente2, colorprimpos, (int)(tam / 2), (int)(tam2 / 2) + 30);
                    }
                    //
                    if (AfdNodos[i].X > AfdNodos[i].Aristas[j].Nodo.X && AfdNodos[i].Y < AfdNodos[i].Aristas[j].Nodo.Y)
                    {
                        g.DrawLine(_plumaFlecha, AfdNodos[i].X + 20, AfdNodos[i].Y + 20, AfdNodos[i].Aristas[j].Nodo.X + 30, AfdNodos[i].Aristas[j].Nodo.Y + 5);

                        if (AfdNodos[i].X == AfdNodos[i].Aristas[j].Nodo.X + 1)
                        {
                            g.DrawString(AfdNodos[i].Aristas[j].Id.ToString(), fuente2, colorprimpos, (int)(tam / 2),
                                (int)(tam2 / 2) + 30);
                        }
                        else
                        {
                            /*if (letra4 == "")
                                letra4 = AfdNodos[i].Aristas[j].Id.ToString();
                            else
                            {
                                letra4 = letra4 + "," + AfdNodos[i].Aristas[j].Id.ToString();
                                inletr4++;
                            }*/

                            tamafue4 = tam;
                            tamafue4a = tam2;
                        }
                        g.DrawString(AfdNodos[i].Aristas[j].Id.ToString(), fuente2, colorprimpos, (int)(tam / 2), (int)(tam2 / 2) + 30);
                    }
                    //Igualdades que casi no existen, posible omitir las en y
                    if (AfdNodos[i].X == AfdNodos[i].Aristas[j].Nodo.X && AfdNodos[i].Y > AfdNodos[i].Aristas[j].Nodo.Y)
                    {
                        g.DrawLine(_plumaFlecha, AfdNodos[i].X + 20, AfdNodos[i].Y + 20, AfdNodos[i].Aristas[j].Nodo.X + 15, AfdNodos[i].Aristas[j].Nodo.Y + 30);
                        g.DrawString(AfdNodos[i].Aristas[j].Id.ToString(), fuente2, colorprimpos, (int)(tam / 2), (int)(tam2 / 2) + 30);
                    }
                    if (AfdNodos[i].X == AfdNodos[i].Aristas[j].Nodo.X && AfdNodos[i].Y < AfdNodos[i].Aristas[j].Nodo.Y)
                    {
                        g.DrawLine(_plumaFlecha, AfdNodos[i].X + 20, AfdNodos[i].Y + 20, AfdNodos[i].Aristas[j].Nodo.X + 15, AfdNodos[i].Aristas[j].Nodo.Y);
                        g.DrawString(AfdNodos[i].Aristas[j].Id.ToString(), fuente2, colorprimpos, (int)(tam / 2), (int)(tam2 / 2) + 30);
                    }
                    if (AfdNodos[i].X < AfdNodos[i].Aristas[j].Nodo.X && AfdNodos[i].Y == AfdNodos[i].Aristas[j].Nodo.Y)
                    {
                        g.DrawLine(_plumaFlecha, AfdNodos[i].X + 20, AfdNodos[i].Y + 20, AfdNodos[i].Aristas[j].Nodo.X - 5, AfdNodos[i].Aristas[j].Nodo.Y + 15);
                        g.DrawString(AfdNodos[i].Aristas[j].Id.ToString(), fuente2, colorprimpos, (int)(tam / 2), (int)(tam2 / 2) + 30);
                    }
                    if (AfdNodos[i].X > AfdNodos[i].Aristas[j].Nodo.X && AfdNodos[i].Y == AfdNodos[i].Aristas[j].Nodo.Y)
                    {
                        g.DrawLine(_plumaFlecha, AfdNodos[i].X + 20, AfdNodos[i].Y + 20, AfdNodos[i].Aristas[j].Nodo.X + 35, AfdNodos[i].Aristas[j].Nodo.Y + 15);
                        g.DrawString(AfdNodos[i].Aristas[j].Id.ToString(), fuente2, colorprimpos, (int)(tam / 2), (int)(tam2 / 2) + 30);
                    }

                    if (AfdNodos[i].Id.ToString() == AfdNodos[i].Aristas[j].Nodo.Id.ToString())
                    {
                        if (letcurv == "")
                            letcurv = AfdNodos[i].Aristas[j].Id.ToString();
                        else
                            letcurv = letcurv + "," + AfdNodos[i].Aristas[j].Id.ToString();
                        incurv++;
                    }

                    if (incurv != 0)
                    {
                        creaVuelta(AfdNodos[i], g, 1);
                        g.DrawString(letcurv, fuente2, coloranul, AfdNodos[i].X - (curva * 2) - 10, AfdNodos[i].Y - 23);
                    }

                    g.DrawString(letra1, fuente2, colorprimpos, (int)(tamafue1 / 2), (int)(tamafue1a / 2) + 30);
                    g.DrawString(letra2, fuente2, colorprimpos, (int)(tamafue2 / 2), (int)(tamafue2a / 2) + 30);
                    g.DrawString(letra3, fuente2, colorprimpos, (int)(tamafue3 / 2), (int)(tamafue3a / 2) + 30);
                    g.DrawString(letra4, fuente2, colorprimpos, (int)(tamafue4 / 2), (int)(tamafue4a / 2) + 30);
                    if (band1)
                        g.DrawString(letra1r, fuente2, colorprimpos, (int)(tamafue1 / 2), (int)(tamafue1a / 2) + 40);
                    if (band2)
                        g.DrawString(letra2r, fuente2, colorprimpos, (int)(tamafue2 / 2), (int)(tamafue2a / 2) + 40);
                    if (band3)
                        g.DrawString(letra3r, fuente2, colorprimpos, (int)(tamafue3 / 2), (int)(tamafue3a / 2) + 40);
                    if (band4)
                        g.DrawString(letra4r, fuente2, colorprimpos, (int)(tamafue4 / 2), (int)(tamafue4a / 2) + 40);
                }

                band1 = false;
                band2 = false;
                band3 = false;
                band4 = false;
                incurv = 0;
                inletr2 = 0;
                inletr1 = 0;
                inletr3 = 0;
                inletr4 = 0;
                letcurv = "";
                letra1 = "";
                letra2 = "";
                letra3 = "";
                letra4 = "";

                dibuja(AfdNodos[i], g);
            }
            _graphics.DrawRectangle(pincelbl, 20, 20, 51, 51);
            _graphics.FillRectangle(colorbl, 20, 20, 50, 50);
        }

        private void PintaArista(Nodo nodoIni, Nodo nodoEnd, Arista arista)
        {
            var nix = nodoIni.X;
            var niy = nodoIni.Y;
            var nfx = nodoEnd.X;
            var nfy = nodoEnd.Y;
            AdjustableArrowCap finfle = new AdjustableArrowCap(5, 5);
            _plumaFlechaR.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            _plumaFlechaR.CustomEndCap = finfle;

            if (nix < nfx && niy > nfy)
                _graphics.DrawLine(_plumaFlechaR, nix + 20, niy + 20, nfx + 5, nfy + 30);
            if (nix > nfx && niy > nfy)
                _graphics.DrawLine(_plumaFlechaR, nix + 20, niy + 20, nfx + 30, nfy + 30);
            if (nix < nfx && niy < nfy)
                _graphics.DrawLine(_plumaFlechaR, nix + 20, niy + 20, nfx + 5, nfy + 5);
            if (nix > nfx && niy < nfy)
                _graphics.DrawLine(_plumaFlechaR, nix + 20, niy + 20, nfx + 30, nfy + 5);
            if (nix == nfx && nix > nfy)
                _graphics.DrawLine(_plumaFlechaR, nix + 20, niy + 20, nfx + 15, nfy + 30);
            if (nix == nfx && niy < nfy)
                _graphics.DrawLine(_plumaFlechaR, nix + 20, niy + 20, nfx + 15, nfy + 30);
            if (nix < nfx && niy == nfy)
                _graphics.DrawLine(_plumaFlechaR, nix + 20, niy + 20, nfx - 5, nfy + 15);
            if (nix > nfx && niy == nfy)
                _graphics.DrawLine(_plumaFlechaR, nix + 20, niy + 20, nfx + 35, nfy + 15);
            if (nix == nfx && niy == nfy)
                creaVuelta(nodoIni, _graphics, 2);

            _graphics.DrawRectangle(pincel, 20, 20, 51, 51);
            _graphics.FillRectangle(colorultipos, 20, 20, 50, 50);
            _graphics.DrawString(arista.Id.ToString(), fuente3, coloranul, 25, 25);

            pbDibujo.Refresh();            
        }

        private void creaVuelta(Nodo afdNodo, Graphics g, int op)
        {
            PointF p1 = new PointF(afdNodo.X, afdNodo.Y + 15);
            PointF p2 = new PointF(afdNodo.X - curva - 10, afdNodo.Y + 15 + curva);
            PointF p3 = new PointF((afdNodo.X - (curva * 3)), afdNodo.Y + 15);
            PointF p4 = new PointF(afdNodo.X - curva - 10, afdNodo.Y - 5);
            PointF p5 = new PointF(afdNodo.X, afdNodo.Y + 15);
            PointF[] arreglo = { p1, p2, p3, p4, p5 };
            g.DrawCurve(_plumaFlecha, arreglo);
            if (op == 2)
                g.DrawCurve(_plumaFlechaR, arreglo);
        }

        private void dibuja(Nodo afdNodo, Graphics dib)
        {
            AdjustableArrowCap finfle = new AdjustableArrowCap(5, 5);
            _plumaFlecha.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            _plumaFlecha.CustomEndCap = finfle;

            if (afdNodo.Id == 0)
            {
                dib.DrawString("Inicio", fuente, coloranul, afdNodo.X - 20, afdNodo.Y - 50);
                dib.DrawLine(_plumaFlecha, afdNodo.X + 15, afdNodo.Y - 30, afdNodo.X + 15, afdNodo.Y);
            }
            dib.DrawEllipse(pincel, afdNodo.X, afdNodo.Y, 36, 36);
            dib.FillEllipse(relleno, afdNodo.X, afdNodo.Y, 35, 35);
            dib.DrawString(afdNodo.Id.ToString(), fuente, coloranul, afdNodo.X + 5, afdNodo.Y + 5);
            //if (afdNodo.Type == NodoType.Fin)
              //  dib.DrawEllipse(pincel, afdNodo.X + 2, afdNodo.Y + 2, 31, 31);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

       
    }
}
