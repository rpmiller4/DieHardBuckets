using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

namespace BucketProblems.Solver
{
    public class NaiveMonteCarloSolver
    {
        public TwoBucketLab TwoBucketLab { get; set; }
        public static Random rng = new Random();

        public void Initialize(TwoBucketLab bucketLabState)
        {
            TwoBucketLab = bucketLabState;

        }

        public void RunWhileNotSolvedOrLimit(int limit)
        {
            for (int i = 0; i < limit; i++)
            {
                if (TwoBucketLab.IsSolution())
                {
                    return;
                }
                Run();
            }
        }

        public void Run()
        {
            DoRandomOperation();
            TwoBucketLab.LogState();
            //TwoBucketLab.LogUniqueState();
        }

        public void DoRandomOperation()
        {
            List<Bucket> buckets = new List<Bucket> {TwoBucketLab.BucketA, TwoBucketLab.BucketB};
            var indexOfSelectedBucket = rng.Next(2);
            var randomlySelectedBucket = buckets[indexOfSelectedBucket];
            // following selects other bucket, which necessarily is not the first bucket because we only have two buckets.
            var indexOfNonSelectedBucket = (indexOfSelectedBucket + 1) % buckets.Count;
            var randomlySelectedSecondBucket = buckets[indexOfNonSelectedBucket];

            int operation = rng.Next(10);
            switch (operation)
            {
                case 0:
                    //if (randomlySelectedBucket.Volume == 0)
                    {
                        TwoBucketLab.FillBucket(randomlySelectedBucket);
                    }
                    break;
                case 1:
                    //if (randomlySelectedSecondBucket.Volume != 0)
                    {
                        TwoBucketLab.EmptyBucket(randomlySelectedBucket);
                    }
                    break;
                case 2:
                default:
                    // constrain transfer volume to volume less than or equal to source bucket and more than or equal to second bucket
                    int availableToTransfer = randomlySelectedBucket.Volume;
                    int availableCapacity = randomlySelectedSecondBucket.CurrentCapacity();

                    if (availableToTransfer > 0 && availableCapacity > 0)
                    {
                        if (rng.Next(2) == 1)
                        {
                            //if (availableToTransfer <= availableCapacity)
                            {
                                TwoBucketLab.Transfer(randomlySelectedBucket, randomlySelectedSecondBucket,
                                    availableToTransfer);
                            }
                            //else
                            //{
                            //    TwoBucketLab.Transfer(randomlySelectedBucket, randomlySelectedSecondBucket,
                            //        availableCapacity);
                            //}
                        }
                        else
                        {
                            TwoBucketLab.Transfer(randomlySelectedBucket, randomlySelectedSecondBucket,
                                availableCapacity);
                        }
                    }
                    break;
            }

        }
    }
}
