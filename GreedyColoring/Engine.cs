﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreedyColoring
{
    public static class Engine
    {
        public static Form1 form;
        public static Bitmap bitmap;
        public static Graphics graphics;

        public static int n, index = 0;
        public static List<Country> countries;
        public static List<Neighbours> neighbours;
        public static bool[,] mAdiacenta;

        public static List<Color> defaultColors = new List<Color>
        {
            Color.Red,
            Color.Orange,
            Color.Yellow,
            Color.Green,
            Color.Blue,
            Color.Indigo,
            Color.Violet
        };

        public static List<List<Country>> solutions = new List<List<Country>>();

        public static void Init(Form1 f)
        {
            form = f;
            countries = new List<Country>();
            neighbours = new List<Neighbours>();

            bitmap = new Bitmap(form.pictureBox1.Width, form.pictureBox1.Height);
            graphics = Graphics.FromImage(bitmap);

            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
        }

        public static void ReadFromFile(string path)
        {
            TextReader reader = new StreamReader(path);
            string buffer = reader.ReadLine();

            n = int.Parse(buffer);
            mAdiacenta = new bool[n, n];

            for(int i = 0; i < n; i++)
            {
                buffer = reader.ReadLine();
                countries.Add(new Country(buffer));
            }

            while((buffer =  reader.ReadLine()) != null)
            {
                string[] inputs = buffer.Split(' ');
                int i = int.Parse(inputs[0]);
                int j = int.Parse(inputs[1]);

                Country start = Engine.countries.FirstOrDefault(country => country.id == i);
                Country end = Engine.countries.FirstOrDefault(country => country.id == j);
                neighbours.Add(new Neighbours(start, end));

                mAdiacenta[i-1, j-1] = true;
                mAdiacenta[j-1, i-1] = true;
            }
        }

        public static void GreedyColoring()
        {
            countries[0].color = defaultColors[0];
            for( int i = 1; i < countries.Count; i++)
            {
                bool[] local = new bool[n];

                for(int j = 0; j < n; j++)
                {
                    if (mAdiacenta[i, j] && countries[j].color != Color.White)
                    {
                        int indexOfColor = defaultColors.IndexOf(countries[j].color);
                        local[indexOfColor] = true;
                    }
                }

                int index = 0;
                while (local[index])
                    index++;

                countries[i].color = defaultColors[index];
            }
        }

        public static void Hamiltonian()
        {
            List<Country> road = new List<Country>();
            bool[] visited = new bool[n];

            for (int i = 0; i < n; i++)
            {
                road.Add(countries[i]);
                visited[i] = true;
                FindRoad(road, visited);

                road.Remove(countries[i]);
                visited[i] = false;
            }
        }

        public static void DisplayRoads()
        {
            for (int i = 0; i < solutions[index].Count; i++)
            {
                solutions[index][i].color = defaultColors[i % defaultColors.Count];
            }
            DrawMap();
        }

        private static void FindRoad(List<Country> road, bool[] visited)
        {
            Country current = road.Last();

            for(int j = 0; j<n; j++)
            {
                if (mAdiacenta[current.id - 1, j] && !visited[j]) 
                {
                    road.Add(countries[j]);
                    visited[j] = true;

                    if(road.Count == n)
                    {
                        //pentru ciclu hamiltonian
                        //if (mAdiacenta[j, road.First().id - 1])
                        //    solutions.Add(new List<Country>(road));

                        solutions.Add(new List<Country>(road));
                    }

                    FindRoad(road, visited);
                    
                    road.Remove(countries[j]);
                    visited[j] = false;
                }
            }
        }

        public static void DrawMap()
        {
            foreach(Country country in countries)
            {
                graphics.FillPolygon(new SolidBrush(country.color), country.borders.ToArray());
                graphics.DrawPolygon(Pens.Black, country.borders.ToArray());
            }

            foreach(Country country in countries)
            {
                Point center = CentruGreutate(country.borders);
                center = new Point(center.X - country.countryName.Length * 6, center.Y - 8);

                graphics.DrawString(country.countryName,
                                    new Font("Arial", 16),
                                    new SolidBrush(Color.Black),
                                    center);
            }
            form.pictureBox1.Image = bitmap;
        }

        public static Point CentruGreutate(List<Point> points)
        {
            int sumaX = 0, sumaY = 0;

            for(int i = 0; i < points.Count; i++)
            {
                sumaX += points[i].X;
                sumaY += points[i].Y;
            }

            return new Point(sumaX / points.Count, sumaY / points.Count);
        }
    }
}
