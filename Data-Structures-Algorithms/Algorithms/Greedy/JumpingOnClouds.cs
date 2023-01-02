using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data_Structures_Algorithms.Algorithms
{
    public class JumpingOnClouds
    {
        public void Test()
        {
            //An array of clouds numbered 0. If they are safe is 1. If is 0, they must be avoided.
            int[] clouds = { 0, 0, 1, 0, 0, 0, 0, 1, 0, 0 }; // 6 jumps

            var jumps = MinimumJumpingOnClouds(clouds.ToList());
            Console.WriteLine(jumps);
        }

        public static int MinimumJumpingOnClouds(List<int> clouds)
        {
            var quantityOfClouds = clouds.Count;
            int jumps = 0;
            var removedCloudInvalid = false;

            for (var i = 0; i < quantityOfClouds; i++)
            {
                if (clouds.Count <= 1)
                {
                    //List is already traveled
                    return jumps;
                }

                var cloudsValidsToRemove = new List<int>();

                foreach (var currentCloud in clouds)
                {
                    //The limit of valid clouds per jump is 2
                    if (cloudsValidsToRemove.Count == 2)
                        break;

                    if (currentCloud == 0)
                    {
                        cloudsValidsToRemove.Add(currentCloud);
                    }
                    else
                    {
                        //One jump removig one and zeros
                        removedCloudInvalid = true;
                        clouds.Remove(1);

                        if (cloudsValidsToRemove.Count > 0)
                        {
                            foreach (var cloudsToRemove in cloudsValidsToRemove)
                            {
                                clouds.Remove(0);
                            }
                        }

                        jumps++;
                        break;
                    }
                }

                if (!removedCloudInvalid)
                {
                    //One jump removig zeros
                    jumps++;
                    if (cloudsValidsToRemove.Count > 0)
                    {
                        foreach (var cloudsToRemove in cloudsValidsToRemove)
                        {
                            clouds.Remove(0);
                        }
                    }
                }

                removedCloudInvalid = false;
            }

            return jumps;
        }

    }
}
