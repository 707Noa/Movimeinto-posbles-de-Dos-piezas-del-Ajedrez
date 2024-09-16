using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ajedrez
{
    class tablero
    {
        const int fila = 8; 
        const int columna = 8; 
        int[,] Tablero;

        public tablero()
        {
            Tablero = new int[fila + 1, columna + 1]; 
        }

        public void inicializarTablero()
        {
            for (int f = 1; f <= fila; f++)
                for (int c = 1; c <= columna; c++)
                    Tablero[f, c] = 0;
        }

        public void inicializarfichas()
        {
            Tablero[8, 4] = 1; //reyna
            Tablero[8, 5] = 1; //rey

        }

        private int ConvertirCoordenadaAPosicion(int coord)
        {
            return coord / 60 + 1; 
        }

        public bool casillaOcupada(int posX, int posY)
        {
            int x = ConvertirCoordenadaAPosicion(posX);
            int y = ConvertirCoordenadaAPosicion(posY);
            return (x <= columna && y <= fila) && (Tablero[y, x] > 0); 
        }

        public void habilitarCasilla(int posX, int posY)
        {
            int x = ConvertirCoordenadaAPosicion(posX);
            int y = ConvertirCoordenadaAPosicion(posY);
            if (x <= columna && y <= fila)
            {
                Tablero[y, x] = 10; 
            }
        }

        public void limpiarCasillasHabilitadas()
        {
            for (int f = 1; f <= fila; f++)
                for (int c = 1; c <= columna; c++)
                    if (Tablero[f, c] == 10)
                        Tablero[f, c] = 0;
        }

        public bool estaHabilitado(int posX, int posY)
        {
            int x = ConvertirCoordenadaAPosicion(posX);
            int y = ConvertirCoordenadaAPosicion(posY);
            return (x <= columna && y <= fila) && (Tablero[y, x] == 10); 
        }

        public void actualizarPosicion(int posX1, int posY1, int posX2, int posY2)
        {
            int x1 = ConvertirCoordenadaAPosicion(posX1);
            int y1 = ConvertirCoordenadaAPosicion(posY1);
            int x2 = ConvertirCoordenadaAPosicion(posX2);
            int y2 = ConvertirCoordenadaAPosicion(posY2);

            Tablero[y1, x1] = 0;
            Tablero[y2, x2] = 1;
        }
    }
}



