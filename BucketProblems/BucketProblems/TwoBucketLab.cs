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
        public int SolutionVolume { get; set; }
        public List<int[]> StateSequence { get; set; }
        public List<int[]> StateSequenceNoRepeats { get; set; }

        public TwoBucketLab(Bucket bucketA, Bucket bucketB, int solutionVolume)
        {
            BucketA = bucketA;
            BucketB = bucketB;
            SolutionVolume = solutionVolume;
            StateSequence = new List<int[]>();
            StateSequenceNoRepeats = new List<int[]>();
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

            if (targetCapacity >= volume)
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

        public int[] GetVolumes()
        {
            return new[] {BucketA.Volume, BucketB.Volume, BucketA.Volume + BucketB.Volume};
        }

        public bool IsSolution()
        {
            return GetVolumes().Take(2).Any(x => x == SolutionVolume);
        }

        /// <summary>
        /// Logs first bucket, second bucket, and the sum volume.
        /// </summary>
        public void LogState()
        {
            StateSequence.Add(GetVolumes());
        }

        public void LogUniqueState()
        {
            var currentState = GetVolumes();

            if (StateSequenceNoRepeats.Count > 0 && StateSequenceNoRepeats.Last() != currentState)
            {

                if (currentState == new int[] {0, 0, 0})
                {
                    StateSequenceNoRepeats.Clear();
                }
                StateSequenceNoRepeats.Add(currentState);
            }
        }
    }
}
