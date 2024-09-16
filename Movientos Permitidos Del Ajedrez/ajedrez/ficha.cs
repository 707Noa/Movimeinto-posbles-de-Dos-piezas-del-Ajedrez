using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ajedrez
{
    class ficha
    {
        public void ReynaMovimientosPosibles(int posX, int posY, ref tablero tabla)
        {
            // Movimientos rectos 
            MoverVerticalYHorizontal(posX, posY, ref tabla);

            // Movimientos diagonales
            MoverDiagonales(posX, posY,ref tabla);
        }

        private void MoverVerticalYHorizontal(int posX, int posY, ref tablero tabla)
        {
            // Movimientos verticales
            for (int i = posY - 60; i >= 0; i -= 60)
                if (tabla.casillaOcupada(posX, i)) break;
                else tabla.habilitarCasilla(posX, i);

            for (int i = posY + 60; i <= 420; i += 60)
                if (tabla.casillaOcupada(posX, i)) break;
                else tabla.habilitarCasilla(posX, i);

            

            // Movimientos horizontales
            for (int i = posX - 60; i >= 0; i -= 60)
                if (tabla.casillaOcupada(i, posY)) break;
                else tabla.habilitarCasilla(i, posY);

            for (int i = posX + 60; i <= 420; i += 60)
                if (tabla.casillaOcupada(i, posY)) break;
                else tabla.habilitarCasilla(i, posY);
        }

        private void MoverDiagonales(int posX, int posY, ref tablero tabla)
        {
            // Diagonal superior izquierda
            for (int i = 1; posX - i * 60 >= 0 && posY - i * 60 >= 0; i++)
                if (tabla.casillaOcupada(posX - i * 60, posY - i * 60)) break;
                else tabla.habilitarCasilla(posX - i * 60, posY - i * 60);

            // Diagonal superior derecha
            for (int i = 1; posX + i * 60 <= 420 && posY - i * 60 >= 0; i++)
                if (tabla.casillaOcupada(posX + i * 60, posY - i * 60)) break;
                else tabla.habilitarCasilla(posX + i * 60, posY - i * 60);

            // Diagonal inferior izquierda
            for (int i = 1; posX - i * 60 >= 0 && posY + i * 60 <= 420; i++)
                if (tabla.casillaOcupada(posX - i * 60, posY + i * 60)) break;
                else tabla.habilitarCasilla(posX - i * 60, posY + i * 60);

            // Diagonal inferior derecha
            for (int i = 1; posX + i * 60 <= 420 && posY + i * 60 <= 420; i++)
                if (tabla.casillaOcupada(posX + i * 60, posY + i * 60)) break;
                else tabla.habilitarCasilla(posX + i * 60, posY + i * 60);
        }

        public void ReyMovimientosPosibles(int posX, int posY, ref tablero tabla)
        {

            // Movimientos verticales
            for (int i = posY - 60; (i == posY - 60) && (i >= 0); i -= 60)
                if (tabla.casillaOcupada(posX, i)) break;
                else tabla.habilitarCasilla(posX, i);

            for (int i = posY + 60; (i <= 420) && (i==posY+60) ; i += 60)
                if (tabla.casillaOcupada(posX, i)) break;
                else tabla.habilitarCasilla(posX, i);

            // Movimientos horizontales
            for (int i = posX - 60; (i == posX - 60) && (i >= 0); i -= 60)
                if (tabla.casillaOcupada(i, posY)) break;
                else tabla.habilitarCasilla(i, posY);

            for (int i = posX + 60; (i <= 420) && (i == posX + 60); i += 60)
                if (tabla.casillaOcupada(i, posY)) break;
                else tabla.habilitarCasilla(i, posY);

            // Diagonal superior izquierda
            for (int i = 1; (posX - i * 60 >= 0 && posY - i * 60 >= 0)&&(i==1); i++)
                if (tabla.casillaOcupada(posX - i * 60, posY - i * 60)) break;
                else tabla.habilitarCasilla(posX - i * 60, posY - i * 60);

            // Diagonal superior derecha
            for (int i = 1; (posX + i * 60 <= 420 && posY - i * 60 >= 0)&&(i==1); i++)
                if (tabla.casillaOcupada(posX + i * 60, posY - i * 60)) break;
                else tabla.habilitarCasilla(posX + i * 60, posY - i * 60);

            // Diagonal inferior izquierda
            for (int i = 1; (posX - i * 60 >= 0 && posY + i * 60 <= 420) &&(i==1); i++)
                if (tabla.casillaOcupada(posX - i * 60, posY + i * 60)) break;
                else tabla.habilitarCasilla(posX - i * 60, posY + i * 60);

            // Diagonal inferior derecha
            for (int i = 1; (posX + i * 60 <= 420 && posY + i * 60 <= 420)&&(i==1); i++)
                if (tabla.casillaOcupada(posX + i * 60, posY + i * 60)) break;
                else tabla.habilitarCasilla(posX + i * 60, posY + i * 60);
        }
    }
}
