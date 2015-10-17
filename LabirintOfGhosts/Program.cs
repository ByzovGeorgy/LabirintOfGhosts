using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabirintOfGhosts
{
    class Program
    {
        public static int[,] labirint;
        public static bool[,] marks;
        private static int width;
        private static int counter = 0;
        public static List<Vector> Directions = new List<Vector>()
        { new Vector(0, -1), new Vector(0, 1) , new Vector(-1, 0), new Vector(1, 0)};
        private static void Main(string[] args)
        {
            StreamWriter writer = new StreamWriter("out.txt");
            Vector start=new Vector(0,0);
            Reader();
            DFS(start);
            writer.WriteLine((counter-4)*9);
            writer.Close();
        }

        public static void DFS(Vector start)
        {
            marks[start.X, start.Y] = true;
            Vector location;
            foreach (Vector i in Directions)
            {
                location = start.Add(i);
                if (CheckBounds(location) && marks[location.X, location.Y] == false)
                {
                    DFS(location);
                }
                else if(!CheckBounds(location) || labirint[location.X, location.Y]==1)
                {
                    counter++;
                }
            }
        }
        public static bool CheckBounds(Vector v)
        {
            return v.X >= 0 && v.Y >= 0 && v.X < width && v.Y < width;
        }
        private static void Reader()
        {
            StreamReader reader = new StreamReader("in.txt");
            width = int.Parse(reader.ReadLine());
            labirint = new int[width, width];
            marks = new bool[width, width];
            char[] cellsOfLabirint = new char[width];
            int count = 0;
            for (int i = 0; i < width; i++)
            {
                cellsOfLabirint = reader.ReadLine().ToCharArray();
                for (int j = 0; j < width; j++)
                {
                    if (cellsOfLabirint[j].Equals('.'))
                        labirint[i, j] = 0;
                    else
                    {
                        labirint[i, j] = 1;
                        marks[i, j] = true;
                    }
                }
            }
        }
    }
}
