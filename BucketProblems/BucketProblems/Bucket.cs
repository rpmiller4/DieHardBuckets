using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BucketProblems
{
    /// <summary>
    /// Likely don't need an entire bucket class for 2-bucket problems, but demonstrates OOP.
    /// </summary>
    public class Bucket
    {
        private int BucketSize { get; set; }
        public int Volume { get; set; }

        public Bucket(int bucketSize)
        {
            BucketSize = bucketSize;
        }
    }
}
