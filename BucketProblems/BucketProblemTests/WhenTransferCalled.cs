using System.Collections.Generic;
using BucketProblems;
using NUnit.Framework;

namespace BucketProblemTests
{
    namespace BucketProblemsUnitTesting
    {
        [TestFixture]
        public class WhenTransferCalledOnTwoBucketLab
        {
            [Test]
            public void IfTransferDoesntFillOrEmptyOneBucket_ThenOperationReturnsFalse()
            {
                TwoBucketLab twoBucketLab = new TwoBucketLab(new Bucket(5), new Bucket(3), 4);

                twoBucketLab.BucketB.FillBucket();

                Assert.AreEqual(0, twoBucketLab.BucketA.Volume);
                Assert.AreEqual(3, twoBucketLab.BucketB.Volume);


                bool operationResult = twoBucketLab.Transfer(twoBucketLab.BucketB, twoBucketLab.BucketA, 2);

                Assert.IsFalse(operationResult);

                Assert.AreEqual(0, twoBucketLab.BucketA.Volume);
                Assert.AreEqual(3, twoBucketLab.BucketB.Volume);
            }

            [Test]
            public void IfTransferDoesntFillOrEmptyOneBucket_ThenOperationReturnsFalse2()
            {
                TwoBucketLab twoBucketLab = new TwoBucketLab(new Bucket(3), new Bucket(5), 4);

                twoBucketLab.BucketA.Volume = 2;
                twoBucketLab.BucketB.Volume = 0;

                Assert.AreEqual(2, twoBucketLab.BucketA.Volume);
                Assert.AreEqual(0, twoBucketLab.BucketB.Volume);


                bool operationResult = twoBucketLab.Transfer(twoBucketLab.BucketB, twoBucketLab.BucketA, 2);

                Assert.IsFalse(operationResult);

                Assert.AreEqual(2, twoBucketLab.BucketA.Volume);
                Assert.AreEqual(0, twoBucketLab.BucketB.Volume);
            }

            [Test]
            public void IfTransferEmptiesOneBucket_ThenOperationReturnsTrue()
            {
                TwoBucketLab twoBucketLab = new TwoBucketLab(new Bucket(5), new Bucket(3), 4);

                twoBucketLab.BucketB.FillBucket();

                Assert.AreEqual(0, twoBucketLab.BucketA.Volume);
                Assert.AreEqual(3, twoBucketLab.BucketB.Volume);


                bool operationResult = twoBucketLab.Transfer(twoBucketLab.BucketB, twoBucketLab.BucketA, 3);

                Assert.IsTrue(operationResult);

                Assert.AreEqual(3, twoBucketLab.BucketA.Volume);
                Assert.AreEqual(0, twoBucketLab.BucketB.Volume);
            }

            [Test]
            public void IfTransferFillsOneBucket_ThenOperationReturnsTrue()
            {
                TwoBucketLab twoBucketLab = new TwoBucketLab(new Bucket(5), new Bucket(3), 4);

                twoBucketLab.BucketB.FillBucket();

                Assert.AreEqual(0, twoBucketLab.BucketA.Volume);
                Assert.AreEqual(3, twoBucketLab.BucketB.Volume);

                twoBucketLab.Transfer(twoBucketLab.BucketB, twoBucketLab.BucketA, 3);
                bool operationResult = twoBucketLab.Transfer(twoBucketLab.BucketA, twoBucketLab.BucketB, 3);

                Assert.IsTrue(operationResult);

                Assert.AreEqual(0, twoBucketLab.BucketA.Volume);
                Assert.AreEqual(3, twoBucketLab.BucketB.Volume);
            }

            //[Test]
            //public void IfTransferDoesntFillOrEmptyOneBucket_ThenOperationDoesntTakeEffect()
            //{

            //}
        }
    }

}

