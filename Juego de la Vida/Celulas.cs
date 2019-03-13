using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juego_de_la_Vida
{

    public class Celulas
    {

        public int sizeX { get; set; }
        public int sizeY { get; set; }
        bool[,] RamdonCuadrado;
        bool[,] MiCuadrado;

        public Celulas(int x, int y)
        {
                this.MiCuadrado = new bool[x, y];
            this.RamdonCuadrado = new bool[x, y];

        }

        //MATRIZ RAMDON
        
        public void GenerarMatriz()
        {
            for (int x = 0; x < sizeX; x++)
            {
                for (int y = 0; y < sizeY; y++)
                {
                    Console.Write("|");
                    if (this.RamdonCuadrado[x, y])
                    {
                        Console.Write("X");
                    }
                    else
                        Console.Write(" ");
                }

                Console.WriteLine("|");
            }
        }
        public void RamdomMatriz()
        {
            Random Aleatorio = new Random();
            for (int x = 0; x < sizeX; x++)
            {
                for (int y = 0; y < sizeY; y++)
                {
                    this.RamdonCuadrado[x, y] = Aleatorio.NextDouble() < 0.2;
                }
            }
        }       
        
        public int SiExiste(int x, int y)
        {
            if (x < 0 || x > sizeX - 1)
                return 0;
            if (y < 0 || y > sizeY - 1)
                return 0;

            if (this.RamdonCuadrado[x, y])
            {
                return 1;
            }
            else return 0;
        }

        public int Proceso(int x, int y)
        {
            return
                SiExiste(x, y + 1) +
                SiExiste(x, y - 1) +
                SiExiste(x + 1, y) +
                SiExiste(x - 1, y) +
                SiExiste(x + 1, y + 1) +
                SiExiste(x + 1, y - 1) +
                SiExiste(x - 1, y + 1) +
                SiExiste(x - 1, y - 1);
        }
        public void Avanzar()
        {
            bool[,] Almaceno = new bool[sizeX, sizeY];
            for (int x = 0; x < sizeX; x++)
            {
                for (int y = 0; y < sizeY; y++)
                {
                    Almaceno[x, y] = this.CasiFin(x, y);
                }

            }
            this.RamdonCuadrado = Almaceno;
        }
        public bool CasiFin(int x, int y)
        {
            bool vivo = this.RamdonCuadrado[x, y];
            int CelularAlrededos = this.Proceso(x, y);
            if (!vivo)
            {
                if (CelularAlrededos == 3)
                {
                    return true;
                }
            }
            if (vivo)
            {
                if (CelularAlrededos == 2 || CelularAlrededos == 3)
                {
                    return true;
                }
            }
            return false;
        }
        public void Final()
        {
            string Fin = "";
            for (int x = 0; x < sizeX; x++)
            {
                for (int y = 0; y < sizeY; y++)
                {
                    Fin += "|";
                    if (RamdonCuadrado[x, y])
                    {
                        Fin += "X";
                    }
                    else
                        Fin += " ";

                }
                Fin += "|\n";
            }
            Console.WriteLine(Fin);

        }
        // MI MATRIZ
        public void GenerarMiMatriz ()
        {
            int x = 1;
            Console.WriteLine("Cuanta celula quiere viva?");
           int vivos = Convert.ToInt32(Console.ReadLine());
            while ( x <= vivos){
                Console.WriteLine("Esta es la celula: " + x + " \nIntroduzca la coordenada de x: ");
                int.TryParse(Console.ReadLine(), out int PosX);
                Console.WriteLine("Introduzca la coordenada de y: ");
                int.TryParse(Console.ReadLine(), out int PosY);
                if (PosX < 0 || PosX >= sizeX || PosY < 0 || PosY >= sizeY)
                {
                    Console.WriteLine("No es valido. Introduzca de nuevo.");
                    continue;
                }else

                MiCuadrado[PosX, PosY] = true;
                x++;

                Console.WriteLine();
            }
            
        }

        public int SiExisteMiMatriz(int x, int y)
        {
            if (x < 0 || x > sizeX - 1)
                return 0;
            if (y < 0 || y > sizeY - 1)
                return 0;

            if (this.MiCuadrado[x, y])
            {
                return 1;
            }
            else return 0;
        }

        public int ProcesoMiMatriz(int x, int y)
        {
            return
                SiExisteMiMatriz(x, y + 1) +
                SiExisteMiMatriz(x, y - 1) +
                SiExisteMiMatriz(x + 1, y) +
                SiExisteMiMatriz(x - 1, y) +
                SiExisteMiMatriz(x + 1, y + 1) +
                SiExisteMiMatriz(x + 1, y - 1) +
                SiExisteMiMatriz(x - 1, y + 1) +
                SiExisteMiMatriz(x - 1, y - 1);
        }

        public void AvanzarMiMatriz()
        {
            bool[,] AlmacenoMio = new bool[sizeX, sizeY];
            for (int x = 0; x < sizeX; x++)
            {
                for (int y = 0; y < sizeY; y++)
                {
                    AlmacenoMio[x, y] = this.CasiFinMiMatriz(x, y);
                }

            }
            this.MiCuadrado = AlmacenoMio;
        }

        public void GenerarMatrizPropia()
        {
            for (int x = 0; x < sizeX; x++)
            {
                for (int y = 0; y < sizeY; y++)
                {
                    Console.Write("|");
                    if (this.MiCuadrado[x, y])
                    {
                        Console.Write("X");
                    }
                    else
                        Console.Write(" ");
                }
                Console.WriteLine("|");

            }
        }

        public bool CasiFinMiMatriz(int x, int y)
        {
            bool vivo = this.MiCuadrado[x, y];
            int CelulaAlrededor = this.ProcesoMiMatriz(x, y);
            if (!vivo)
            {
                if (CelulaAlrededor == 3)
                {
                    return true;
                }
            }
            if (vivo)
            {
                if (CelulaAlrededor == 2 || CelulaAlrededor == 3)
                {
                    return true;
                }
            }
            return false;
        }

        public void FinalMiMatriz()
        {
            string Quitar = "";
            for (int x = 0; x < sizeX; x++)
            {
                for (int y = 0; y < sizeY; y++)
                {
                    Quitar += "|";
                    if (MiCuadrado[x, y])
                    {
                        Quitar += "X";
                    }
                    else
                        Quitar += " ";

                }
                Quitar += "|\n";
            }
            Console.WriteLine(Quitar);
        }

    }
}
