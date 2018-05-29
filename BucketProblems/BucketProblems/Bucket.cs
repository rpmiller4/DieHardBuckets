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
        public int BucketSize { get; set; }
        public int Volume { get; set; }

        public Bucket(int bucketSize)
        {
            BucketSize = bucketSize;
            Volume = 0;
        }

        public bool FillBucket()
        {
            if (Volume == 0)
            {
                Volume = BucketSize;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool EmptyBucket()
        {
            if (Volume != 0)
            {
                Volume = 0;
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Add specific amount, but never allow overflow
        /// </summary>
        /// <returns>Add operation was successful</returns>
        public bool Add(int volume)
        {
            if (Volume + volume >= 0 && Volume + volume <= BucketSize)
            {
                Volume += volume;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Subtract(int volume)
        {
            if (Volume - volume >= 0 && Volume - volume <= BucketSize)
            {
                Volume -= volume;
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Whatever space is left to fill in the bucket.
        /// </summary>
        /// <returns></returns>
        public int CurrentCapacity()
        {
            return BucketSize - Volume;
        }
    }
}
