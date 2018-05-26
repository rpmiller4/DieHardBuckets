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
            var firstBucket = new Bucket(5);
            var secondBucket = new Bucket(3);

            //Setup
            var bucketLab = new BucketLab(firstBucket, secondBucket);
        }
    }
}
