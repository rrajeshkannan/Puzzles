using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoordinateWithMaximumNetworkQuality
{
    public class Tower : IComparable<Tower>
    {
        public int Id { get; private set; }
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Quality { get; private set; }
        public int NetQuality { get; set; }

        public Tower(int id, int x, int y, int quality)
        {
            Id = id;
            X = x;
            Y = y;
            Quality = quality;
        }

        //public bool IsTowerReachableFrom(Tower other, int radius)
        //{
        //    var distance = (int)Math.Floor(Distance(this.X, this.Y, other.X, other.Y));

        //    return (distance <= radius);
        //}

        public double DistanceFrom(Tower other)
        {
            return Distance(this.X, this.Y, other.X, other.Y);
        }

        private double Distance(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2)));
        }

        public override string ToString()
        {
            return String.Format("{0},[{1},{2}],{3},{4}", Id, X, Y, Quality, NetQuality);
        }

        public int CompareTo(Tower other)
        {
            // If there are multiple coordinates with the same network 
            // quality, return the lexicographically minimum coordinate.
            //   A coordinate (x1, y1) is lexicographically smaller than (x2, y2), 
            //     if either x1 < x2 or x1 == x2 and y1 < y2.

            if (this.NetQuality < other.NetQuality)
            {
                return -1;
            }
            else if (this.NetQuality > other.NetQuality)
            {
                return 1;
            }
            else
            {
                // Return the lexicographically minimum coordinate.
                //   A coordinate (x1, y1) is lexicographically smaller than (x2, y2), 
                //     if either x1 < x2 or x1 == x2 and y1 < y2.
                var x1 = this.X;
                var y1 = this.Y;

                var x2 = other.X;
                var y2 = other.Y;

                if (x1 < x2)
                {
                    // Give more weightage, since it is lexicographically minimum coordinate.
                    return 1;
                }

                if (x1 > x2)
                {
                    // Give least weightage, since it is lexicographically maximum coordinate.
                    return -1;
                }

                // it means: (x1 == x2)
                if (y1 == y2)
                {
                    // both are same coordinates with same net quality => can be in any order
                    return 0;
                }
                
                if (y1 < y2)
                {
                    // Give more weightage, since it is lexicographically minimum coordinate.
                    return 1;
                }

                // Give least weightage, since it is lexicographically maximum coordinate.
                return -1;
            }
        }
    }

    public class Solution
    {
        public int[] BestCoordinate(int[][] towersArray, int radius)
        {
            int towersCount = towersArray.Length;
            var towers = new List<Tower>();

            for (int i = 0; i < towersCount; i++)
            {
                var towerOuter = new Tower(i, towersArray[i][0], towersArray[i][1], towersArray[i][2]);

                var towerNetQuality = towerOuter.Quality;

                for (int j = 0; j < towersCount; j++)
                {
                    if (i == j) continue;

                    var towerInner = new Tower(i, towersArray[j][0], towersArray[j][1], towersArray[j][2]);

                    var interTowerDistance = towerOuter.DistanceFrom(towerInner);
                    var towerReachable = (interTowerDistance <= radius);

                    if (!towerReachable) continue;

                    var interTowerQuality = (int)Math.Floor((double)towerInner.Quality / (1.0 + interTowerDistance));

                    towerNetQuality += interTowerQuality;
                }

                towerOuter.NetQuality = towerNetQuality;
                towers.Add(towerOuter);
            }

            towers.Sort();

            var bestTower = towers.Count - 1;

            return new int[] { towers[bestTower].X, towers[bestTower].Y };
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();

            //int[][] towers1 = new int[][]
            //{
            //    new int[]{ 1, 2, 5 },
            //    new int[]{ 2, 1, 7 },
            //    new int[]{ 3, 1, 9 },
            //};

            //int radius1 = 2;

            //var coordinate1 = solution.BestCoordinate(towers1, radius1);

            //Console.WriteLine("[{0},{1}]", coordinate1[0], coordinate1[1]);

            //int[][] towers2 = new int[][]
            //{
            //    new int[]{ 23, 11, 21 }
            //};

            //int radius2 = 9;

            //var coordinate2 = solution.BestCoordinate(towers2, radius2);

            //Console.WriteLine("[{0},{1}]", coordinate2[0], coordinate2[1]);

            //int[][] towers3 = new int[][]
            //{
            //    new int[]{ 1, 2, 13 },
            //    new int[]{ 2, 1, 7 },
            //    new int[]{ 0, 1, 9 },
            //};

            //int radius3 = 2;

            //var coordinate3 = solution.BestCoordinate(towers3, radius3);

            //Console.WriteLine("[{0},{1}]", coordinate3[0], coordinate3[1]);

            //int[][] towers4 = new int[][]
            //{
            //    new int[]{ 2, 1, 9 },
            //    new int[]{ 0, 1, 9 },
            //};

            //int radius4 = 2;

            //var coordinate4 = solution.BestCoordinate(towers4, radius4);

            //Console.WriteLine("[{0},{1}]", coordinate4[0], coordinate4[1]);

            //int[][] towers5 = new int[][]
            //{
            //    new int[]{ 45, 12, 4 },
            //    new int[]{ 13, 21, 27 },
            //    new int[]{ 31, 17, 40 },
            //    new int[]{ 25, 29, 45 },
            //    new int[]{ 37, 29, 25 },
            //    new int[]{ 16, 37, 48 },
            //    new int[]{ 4, 3, 31 },
            //};

            //int radius5 = 42;

            //var coordinate5 = solution.BestCoordinate(towers5, radius5);

            //Console.WriteLine("[{0},{1}]", coordinate5[0], coordinate5[1]);

            int[][] towers6 = new int[][]
            {
                new int[]{ 28, 6, 30 },
                new int[]{ 23, 16, 0 },
                new int[]{ 21, 42, 22 },
                new int[]{ 50, 33, 34 },
                new int[]{ 14, 7, 50 },
                new int[]{ 40, 31, 4 },
                new int[]{ 39, 45, 17 },
                new int[]{ 46, 21, 12 },
                new int[]{ 45, 36, 45 },
                new int[]{ 35, 43, 43 },
                new int[]{ 29, 41, 48 },
                new int[]{ 22, 27, 5 },
                new int[]{ 42, 44, 45 },
                new int[]{ 10, 49, 50 },
                new int[]{ 47, 43, 26 },
                new int[]{ 40, 36, 25 },
                new int[]{ 10, 25, 6 },
                new int[]{ 27, 30, 30 },
                new int[]{ 50, 35, 20 },
                new int[]{ 11, 0, 44 },
                new int[]{ 34, 29, 28 },
            };

            int radius6 = 12;

            var coordinate6 = solution.BestCoordinate(towers6, radius6);

            Console.WriteLine("[{0},{1}]", coordinate6[0], coordinate6[1]);

            Console.ReadKey();
        }
    }
}
