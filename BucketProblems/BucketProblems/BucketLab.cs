using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BucketProblems
{
    /// <summary>
    /// Represents a two bucket setup.
    /// </summary>
    public class BucketLab
    {
        public Bucket BucketA { get; set; }
        public Bucket BucketB { get; set; }
        public BucketLab(Bucket bucketA, Bucket bucketB)
        {
            BucketA = bucketA;
            BucketB = bucketB;
        }
    }
}
