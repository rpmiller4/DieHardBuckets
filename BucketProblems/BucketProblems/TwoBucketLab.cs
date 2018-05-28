using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BucketProblems
{
    public class TwoBucketLab : IUnaryBucketOperations, IBinaryBucketOperations
    {
        public Bucket BucketA { get; set; }
        public Bucket BucketB { get; set; }

        public TwoBucketLab(Bucket bucketA, Bucket bucketB)
        {
            BucketA = bucketA;
            BucketB = bucketB;
        }

        public void FillBucket(Bucket bucket)
        {
            bucket.FillBucket();
        }

        public void EmptyBucket(Bucket bucket)
        {
            bucket.EmptyBucket();
        }

        public void Transfer(Bucket source, Bucket target)
        {
            if (target.Add(source.Volume))
            {
                source.EmptyBucket();
            }
        }

        public void Transfer(Bucket source, Bucket target, int volume)
        {
            int targetCapacity = target.BucketSize - target.Volume;
            int sourceVolume = source.Volume;

            if (targetCapacity <= sourceVolume)
            {
                if (target.Add(volume))
                {
                    source.Subtract(volume);
                }
            }
        }

        public override string ToString()
        {
            return $"({BucketA.Volume}, {BucketB.Volume})";
        }
    }
}
