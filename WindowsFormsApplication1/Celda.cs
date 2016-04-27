using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace WindowsFormsApplication1
{
    class Celda
    {
        enum Estado {viva, muerta };
        int x, y;
        Estado estado;
        static int lado = 20;

        public Celda(int x, int y, Random r)
        {
            
            double d =  r.NextDouble();
            if (d < .80)
                estado = Estado.muerta;
            else
                estado = Estado.viva;

            this.x = x; this.y = y;
        }
        public void Dibuja(Form f)
        {

            Graphics g = f.CreateGraphics();
            g.DrawRectangle(new Pen(Color.Black, 1), x, y, lado, lado);
            if (estado == Estado.viva)
                g.FillRectangle(new SolidBrush(Color.Black),x,y,lado,lado);

            
        }

    }

    class Tablero
    {
        List<List<Celda>> tablero;
        int tamaño;
        Random r = new Random();
        public Tablero (int tamaño)
        {
            tablero = new List<List<Celda>>();
            this.tamaño = tamaño;
            for(int i=0; i < tamaño; i++)
            {
                List<Celda> temp = new List<Celda>();
                for (int j = 0; j < tamaño; j++)
                {
                    temp.Add(new Celda(20+i*20,20+j*20, r));
                }
                tablero.Add(temp);

            }

        }

        public void Dibuja(Form f)
        {

            for (int i = 0; i < tamaño; i++)
                for (int j = 0; j < tamaño; j++)
                {
                    tablero[i][j].Dibuja(f);
                }
        }
    }
}
