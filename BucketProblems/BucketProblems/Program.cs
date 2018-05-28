using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BucketProblems
{
    class Program
    {
        static void Main(string[] args)
        {
            ManuallySolveForFour();
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
