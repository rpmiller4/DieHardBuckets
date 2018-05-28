using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using BucketProblems.Solver;

namespace BucketProblems
{
    class Program
    {
        static void Main(string[] args)
        {
            // ManuallySolveForFour();

            // Initialize Problem

            List<List<int[]>> sequences = new List<List<int[]>>();
            List<List<int[]>> solutionsSequences = new List<List<int[]>>();


            for (int i = 0; i < 5000; i++)
            {

                var firstBucket = new Bucket(5);
                var secondBucket = new Bucket(7);
                int desiredSolutionVolume = 1;
                TwoBucketLab twoBucketLab = new TwoBucketLab(firstBucket, secondBucket, desiredSolutionVolume);

                NaiveMonteCarloSolver naiveMonteCarloSolver = new NaiveMonteCarloSolver();
                naiveMonteCarloSolver.Initialize(twoBucketLab);
                naiveMonteCarloSolver.RunWhileNotSolvedOrLimit(10000); // limit here, just in case


                var cleanSequence = CleanSequence(twoBucketLab);

                WriteSequence(cleanSequence);
                sequences.Add(cleanSequence);
                Console.WriteLine("Done!");
                if (twoBucketLab.IsSolution())
                {
                    solutionsSequences.Add(cleanSequence);
                    Console.WriteLine("Really Done!");
                    //break;
                }
            }

            var sequencesByLength = solutionsSequences.Where(s=>s.First()[0] ==0 && s.First()[1] == 0).OrderBy(m => m.Count());

            var firstTen = sequencesByLength.Take(20).ToList();

            foreach (var sequence in firstTen)
            {
                Console.WriteLine(sequence.Count);
                WriteSequence(sequence);
            }

            Console.ReadLine();
        }

        public static List<int[]> CleanSequence(TwoBucketLab twoBucketLab)
        {
            List<int[]> cleanedSequence = new List<int[]>();


            int lastA = -1;
            int lastB = -1;
            foreach (var state in twoBucketLab.StateSequence)
            {
                if (state[0] == 0 && state[1] == 0)
                {
                    cleanedSequence.Clear();
                    cleanedSequence.Add(state);
                }

                if (lastA != state[0] || lastB != state[1])
                {
                    cleanedSequence.Add(state);
                    lastA = state[0];
                    lastB = state[1];
                }
            }

            return cleanedSequence;
        }

        private static void WriteSequence(List<int[]> stateSequence)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var state in stateSequence)
            {
                sb.AppendLine($"({state[0]}, {state[1]})");
            }

            Console.WriteLine(sb);
        }

        private static void ManuallySolveForFour()
        {
            var firstBucket = new Bucket(5);
            var secondBucket = new Bucket(3);
            int desiredSolution = 4;

            //Setup
            var bucketLab = new TwoBucketLab(firstBucket, secondBucket, desiredSolution);

            Console.WriteLine(bucketLab);
            bucketLab.FillBucket(firstBucket);
            Console.WriteLine(bucketLab);
            bucketLab.Transfer(firstBucket, secondBucket, 3);
            Console.WriteLine(bucketLab);
            bucketLab.EmptyBucket(secondBucket);
            Console.WriteLine(bucketLab);
            bucketLab.Transfer(firstBucket, secondBucket);
            Console.WriteLine(bucketLab);
            bucketLab.FillBucket(firstBucket);
            Console.WriteLine(bucketLab);
            bucketLab.Transfer(firstBucket, secondBucket, 1);
            Console.WriteLine(bucketLab);
            bucketLab.EmptyBucket(secondBucket);
            Console.WriteLine(bucketLab);
            Console.ReadLine();
        }
    }
}
