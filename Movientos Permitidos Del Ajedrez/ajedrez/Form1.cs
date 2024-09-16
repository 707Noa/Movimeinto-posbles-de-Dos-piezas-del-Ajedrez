using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ajedrez
{
    public partial class Form1 : Form
    {
        //clases
        tablero tabla;
        ficha Ficha;

        string fichaSeleccionada = ""; //ficha seleccionada
        const int C = 10; //margen de las fichas

        Dictionary<Point, Panel> casillas; // Diccionario para mapear las casillas con los paneles

        public Form1()
        {
            InitializeComponent();

            tabla = new tablero();
            tabla.inicializarTablero();
            tabla.inicializarfichas();
            Ficha = new ficha();
            casillas = new Dictionary<Point, Panel>();

            //creador de evento click de los paneles
            foreach (Control control in this.Controls)
            {
                if (control is Panel)
                {
                    control.Click += new System.EventHandler(this.panel_Click);
                    // Mapear las posiciones de los paneles a las casillas del tablero
                    casillas[new Point(control.Location.X, control.Location.Y)] = (Panel)control;
                }
            }

            //inicializador de fichas
            reyna.Location = new Point(180 +C, 420+C);
            rey.Location = new Point(240 +C, 420+C);
        }

        private void panel_Click(object sender, EventArgs e)
        {
            Panel clickedPanel = sender as Panel; //obtiene que panel fue clickeado
            if (clickedPanel == null) return;

            int posX = clickedPanel.Location.X;
            int posY = clickedPanel.Location.Y;

            if (tabla.estaHabilitado(posX, posY))
            {
                if (fichaSeleccionada == "reyna")
                {
                    tabla.actualizarPosicion(reyna.Location.X-C, reyna.Location.Y-C, posX, posY);//back
                    reyna.Location = new Point(posX+C, posY+C);//front
                    tabla.limpiarCasillasHabilitadas();//back
                    limpiarResaltado();//front
                }
                else
                {
                    if(fichaSeleccionada == "rey")
                    {
                        tabla.actualizarPosicion(rey.Location.X-C, rey.Location.Y-C, posX, posY);
                        rey.Location = new Point(posX+C, posY+C);
                        tabla.limpiarCasillasHabilitadas();
                        limpiarResaltado();
                    }
                }
                
            }
        }

        private void reyna_Click(object sender, EventArgs e)
        {
            fichaSeleccionada = "reyna"; //seleccion
            tabla.limpiarCasillasHabilitadas(); //back
            limpiarResaltado(); //front
            Ficha.ReynaMovimientosPosibles(reyna.Location.X-C, reyna.Location.Y-C, ref tabla); //back
            pintarMovimientosPosibles(); //front
        }

        private void rey_Click(object sender, EventArgs e)
        {
            fichaSeleccionada = "rey"; //seleccion
            tabla.limpiarCasillasHabilitadas(); //back
            limpiarResaltado(); //front
            Ficha.ReyMovimientosPosibles(rey.Location.X-C, rey.Location.Y-C, ref tabla); //back
            pintarMovimientosPosibles(); //front
        }

        public void pintarMovimientosPosibles()
        {
            for (int x = 0; x < 8; x++)
                for (int y = 0; y < 8; y++)
                    if (tabla.estaHabilitado(x * 60, y * 60))
                    {
                        Point punto = new Point(x * 60 , y * 60 );
                        if (casillas.ContainsKey(punto))
                        {
                            casillas[punto].Paint += new PaintEventHandler(panel_Paint);
                            casillas[punto].Invalidate(); // Forzar el repintado del panel
                        }
                    }
        }
        private void panel_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = sender as Panel;
            if (panel != null)
            {
                Color rellenoColor = Color.Blue;
                // Crea la brocha para rellenar el circulo
                using (Brush brush = new SolidBrush(rellenoColor))
                {
                    // Define el rectángulo donde se dibujará el circulo
                    Rectangle rect = new Rectangle(20, 20, panel.Width - 40, panel.Height - 40);
                    // Rellena el circulo
                    e.Graphics.FillEllipse(brush, rect);
                }
            }
        }

        private void limpiarResaltado()
        {
            foreach (var panel in casillas.Values)
            {
                panel.Paint -= new PaintEventHandler(panel_Paint);
                panel.Invalidate(); //borra el pintado
            }
        }
    }
}


