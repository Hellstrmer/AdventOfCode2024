using System.Collections.Generic;
using System.Drawing;
using System.Numerics;

namespace AdventOfCode._2024
{
    internal class Day12
    {
        private int _width;
        private int _height;
        private char[,] _grid;
        HashSet<Point> Plants = new HashSet<Point>();
        public void ReadFile()
        {
            // 1546338 
            //Reading out a grid
            bool example = true;
            string[] input = File.ReadAllLines(example
                ? "C:\\Users\\jespe\\Source\\Repos\\Hellstrmer\\AdventOfCode2024\\2024\\Day12\\Example.txt"
                : "C:\\Users\\jespe\\Source\\Repos\\Hellstrmer\\AdventOfCode2024\\2024\\Day12\\Input.txt");

            _width = input[0].Length;
            _height = input.Length;
            _grid = new char[_height, _width];
            for (var y = 0; y < _height; y++)
            {
                var line = input[y];
                for (var x = 0; x < _width; x++)
                {
                    var character = line[x];
                    _grid[y, x] = character;
                }
            }
        }
        public void FirstStar()
        {
            ReadFile();
            List<Point> FoundPoints = new List<Point>();
            Char PlantChar = new Char();
            Point PlantPoint = new Point();
            Plant plant = new Plant();
            int PriceInt = 0;
            int TotalPrice = 0;            

            for (int x = 0; x < _width; x++)
            {
                for (int y = 0; y < _height; y++)
                {
                    PlantChar = _grid[x, y];
                    PlantPoint = new Point(x, y);
                    if (!Plants.Contains(PlantPoint))
                    {
                        Plants.Add(PlantPoint);
                        FoundPoints.Add(PlantPoint);
                        plant.Area++;
                        plant = CheckPlants(PlantChar, PlantPoint, FoundPoints, plant);
                        plant.Perimeter = CheckPerimeterP2(PlantChar, FoundPoints, plant, PriceInt);
                        Console.WriteLine("Char: " + PlantChar );
                        Console.WriteLine("Area: " + plant.Area);
                        foreach(Point p in plant.Perimeter)
                        {

                            Console.WriteLine("Sides: " + p);
                        }
                        Console.WriteLine();
                        TotalPrice += plant.Area * plant.PerimeterInt;     
                        plant.Area = 0; 
                        plant.PerimeterInt = 0;
                        plant.Perimeter.Clear();
                        FoundPoints.Clear();
                    }
                }                
            }
            Console.WriteLine("Numbers: " + TotalPrice);
        }

        private Plant CheckPlants(Char PlantChar, Point PlantPoint, List<Point> FoundPoints, Plant plant)
        {
            int Finds = 0;
            Point Y1 = new Point(PlantPoint.X, PlantPoint.Y + 1);
            Finds += CheckPlant(Y1, plant, PlantChar, FoundPoints);

            Point Y2 = new Point(PlantPoint.X, PlantPoint.Y - 1);
            Finds += CheckPlant(Y2, plant, PlantChar, FoundPoints);
            
            Point X1 = new Point(PlantPoint.X +1, PlantPoint.Y);
            Finds += CheckPlant(X1, plant, PlantChar, FoundPoints);
            
            Point X2 = new Point(PlantPoint.X -1, PlantPoint.Y);
            Finds += CheckPlant(X2, plant, PlantChar, FoundPoints);

            if (Finds > 0)
            {
                List<Point> points = new List<Point>();
                for (int i =  0; i < FoundPoints.Count; i++)
                {
                    points.Add(FoundPoints[i]);
                }
                foreach(Point p in points)
                {
                    plant = CheckPlants(PlantChar, p, FoundPoints, plant);
                }                
            }
            return plant;
        }

        private int CheckPerimeter(Char PlantChar, List<Point> FoundPoints, Plant plant, int Price)
        {
            foreach (Point PlantPoint in FoundPoints) 
            {
                Point Y1 = new Point(PlantPoint.X, PlantPoint.Y + 1);
                if (!OutOfBound(Y1) && _grid[Y1.X, Y1.Y] != PlantChar)                
                    Price++;                

                Point Y2 = new Point(PlantPoint.X, PlantPoint.Y - 1);
                if (!OutOfBound(Y2) && _grid[Y2.X, Y2.Y] != PlantChar)
                    Price++;

                Point X1 = new Point(PlantPoint.X + 1, PlantPoint.Y);
                if (!OutOfBound(X1) && _grid[X1.X, X1.Y] != PlantChar)
                    Price++;

                Point X2 = new Point(PlantPoint.X - 1, PlantPoint.Y);
                if (!OutOfBound(X2) && _grid[X2.X, X2.Y] != PlantChar)
                    Price++;
                if(OutOfBound(Y1))
                    Price++;
                if (OutOfBound(Y2))
                    Price++;
                if (OutOfBound(X1))
                    Price++;
                if (OutOfBound(X2))
                    Price++;
            }
            return Price;
        }
        private List<Point> CheckPerimeterP2(Char PlantChar, List<Point> FoundPoints, Plant plant, int Price)
        {
            List<Point> pPerimeter = new List<Point>();
            foreach (var p in FoundPoints)
            {
                Point Perimeter = new Point(p.X, p.Y - 1);
                if (!OutOfBound(Perimeter) && !pPerimeter.Contains(Perimeter) && _grid[Perimeter.X, Perimeter.Y] != PlantChar)
                {
                    pPerimeter.Add(Perimeter);
                }
                else if (OutOfBound(Perimeter))
                {
                    pPerimeter.Add(Perimeter);
                }
                Perimeter = new Point(p.X, p.Y + 1);
                if (!OutOfBound(Perimeter) && !pPerimeter.Contains(Perimeter) && _grid[Perimeter.X, Perimeter.Y] != PlantChar)
                {
                    pPerimeter.Add(Perimeter);
                }
                else if (OutOfBound(Perimeter))
                {
                    pPerimeter.Add(Perimeter);
                }
                Perimeter = new Point(p.X + 1, p.Y);
                if (!OutOfBound(Perimeter) && !pPerimeter.Contains(Perimeter) && _grid[Perimeter.X, Perimeter.Y] != PlantChar)
                {
                    pPerimeter.Add(Perimeter);
                }
                else if (OutOfBound(Perimeter))
                {
                    pPerimeter.Add(Perimeter);
                }
                Perimeter = new Point(p.X - 1, p.Y);
                if (!OutOfBound(Perimeter) && !pPerimeter.Contains(Perimeter) && _grid[Perimeter.X, Perimeter.Y] != PlantChar)
                {
                    pPerimeter.Add(Perimeter);
                }
                else if (OutOfBound(Perimeter))
                {
                    pPerimeter.Add(Perimeter);
                }
            }
            return pPerimeter;
        }

        private int CheckPlant(Point p, Plant plant, Char PlantChar, List<Point> FoundPoints)
        {
            int Finds = 0;
            if (!OutOfBound(p) && !Plants.Contains(p))
            {
                if (_grid[p.X, p.Y] == PlantChar)
                {
                    plant.Area++;
                    Plants.Add(p);
                    FoundPoints.Add(p);
                    Finds++;                    
                }
            }
            return Finds;
        }

        private bool OutOfBound(Point ControlPoint)
        {
            return ControlPoint.X > _width - 1 || ControlPoint.X < 0 || ControlPoint.Y > _height - 1 || ControlPoint.Y < 0;
        }
    }

    public class Plant
    {
        public List<Point> Perimeter { get; set; }
        public int PerimeterInt { get; set; }
        public int Area { get; set; }
        public int Price { get; set; }        
    }
}

