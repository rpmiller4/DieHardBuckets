﻿using System;
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

        public bool FillBucket(Bucket bucket)
        {
            return bucket.FillBucket();
        }

        public bool EmptyBucket(Bucket bucket)
        {
            return bucket.EmptyBucket();
        }

        public bool Transfer(Bucket source, Bucket target)
        {
            if (target.Add(source.Volume))
            {
                return source.EmptyBucket();
            }
            else
            {
                return false;
            }
        }

        public bool Transfer(Bucket source, Bucket target, int volume)
        {
            // constraint Transfer should only go through if a bucket is filled or a bucket is emptied
            int sourceVolume = source.Volume;
            int targetVolume = target.Volume;

            if (sourceVolume - volume == 0 || targetVolume + volume == target.BucketSize)
            {
                if (target.Add(volume))
                {
                    return source.Subtract(volume);
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
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
            var volumes = GetVolumes();
            bool oneZero = volumes.Take(2).Any(x => x == 0);
            return volumes[2] == SolutionVolume && oneZero;
        }

        /// <summary>
        /// Logs first bucket, second bucket, and the sum volume.
        /// </summary>
        public void LogState()
        {
            StateSequence.Add(GetVolumes());
        }
    }
}
