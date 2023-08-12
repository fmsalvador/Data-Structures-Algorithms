using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Data_Structures_Algorithms
{
    public class TravelingSalesman
    {

        private static int numberOfCities = 1000;
        private static Travel travel = new Travel(numberOfCities);

        public void Test()
        {
            Console.WriteLine("Optimized distance for travel:" + simulateAnnealing(10, numberOfCities, 0.9995));
        }

        public static double simulateAnnealing(double startingTemperature, int numberOfIterations, double coolingRate)
        {
            Console.WriteLine("Starting SA with temperature: " + startingTemperature + ", # of iterations: " + numberOfIterations + " and colling rate: " + coolingRate);
            double t = startingTemperature;
            travel.generateInitialTravel();
            double bestDistance = travel.getDistance();
            Console.WriteLine("Initial distance of travel: " + bestDistance);
            Travel bestSolution = travel;
            Travel currentSolution = bestSolution;

            for (int i = 0; i < numberOfIterations; i++)
            {
                if (t > 0.1)
                {
                    currentSolution.swapCities();
                    double currentDistance = currentSolution.getDistance();
                    if (currentDistance < bestDistance)
                    {
                        bestDistance = currentDistance;
                    }
                    else if (Math.Exp((bestDistance - currentDistance) / t) < new Random().Next())
                    {
                        currentSolution.revertSwap();
                    }
                    t *= coolingRate;
                }
                else
                {
                    continue;
                }
                if (i % 100 == 0)
                {
                    Console.WriteLine("Iteration #" + i);
                }
            }
            return bestDistance;
        }

        public class Travel
        {
            private City[] travel = new City[numberOfCities];
            private City[] previousTravel = new City[numberOfCities];

            public Travel(int numberOfCities)
            {
                for (int i = 0; i < numberOfCities; i++)
                {
                    travel[i] = new City(i);
                }
            }

            public void generateInitialTravel()
            {
                ShuffleMe(travel);
            }

            public void ShuffleMe<T>(IList<T> list)
            {
                Random random = new Random(2);
                int n = list.Count;

                for (int i = list.Count - 1; i > 1; i--)
                {
                    int rnd = random.Next(i);

                    T value = list[rnd];
                    list[rnd] = list[i];
                    list[i] = value;
                }
            }

            public void swapCities()
            {
                int a = new Random().Next(0, numberOfCities);
                int b = new Random().Next(0, numberOfCities);
                previousTravel = travel;
                City x = travel[a];
                City y = travel[b];
                travel[a] = y;
                travel[b] = x;
            }

            public void revertSwap()
            {
                travel = previousTravel;
            }

            public City getCity(int index)
            {
                return travel[index];
            }

            public double getDistance()
            {
                double distance = 0;
                for (int index = 0; index < travel.Length; index++)
                {
                    City starting = getCity(index);
                    City destination;
                    if (index + 1 < travel.Length)
                    {
                        destination = getCity(index + 1);
                    }
                    else
                    {
                        destination = getCity(0);
                    }
                    distance += starting.distanceToCity(destination);
                }
                return distance;
            }
        }

        public class City
        {

            private int x;
            public int X
            {
                get { return x; }
                set { x = value; }
            }

            public City(int n)
            {
                //this.x = (int)(new Random().Next());
                this.x = n++;
            }

            public double distanceToCity(City city)
            {
                int x = Math.Abs(this.x - city.X);
                //int y = Math.Abs(this.y - city.Y);
                return Math.Sqrt(Math.Pow(x, 2));// + Math.Pow(y, 2));
            }
        }
    }
}
